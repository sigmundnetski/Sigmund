using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ManaCrystalMgr : MonoBehaviour
{
    private const float ANIMATE_TIME = 0.6f;
    private int m_additionalRecalledCrystalsOwedNextTurn;
    private int m_additionalRecalledCrystalsOwedThisTurn;
    public ManaCrystalEventSpells m_eventSpells;
    private int m_numCrystalsLoading;
    private int m_numQueuedToReady;
    private int m_numQueuedToSpawn;
    private int m_numQueuedToSpend;
    private List<ManaCrystal> m_permanentCrystals;
    private int m_proposedManaSourceEntID = -1;
    private bool m_recallLocksAreShowing;
    private List<ManaCrystal> m_temporaryCrystals;
    public GameObject manaLockPrefab;
    private static ManaCrystalMgr s_instance;
    private const float SECS_BETW_MANA_READIES = 0.2f;
    private const float SECS_BETW_MANA_SPAWNS = 0.2f;
    private const float SECS_BETW_MANA_SPENDS = 0.2f;
    public Material tempManaCrystalMaterial;
    public Material tempManaCrystalProposedQuadMaterial;

    public void AddManaCrystals(int numCrystals, bool isTurnStart)
    {
        for (int i = 0; i < numCrystals; i++)
        {
            GameState.Get().GetGameEntity().NotifyOfManaCrystalSpawned();
            base.StartCoroutine(this.WaitThenAddManaCrystal(false, isTurnStart));
        }
    }

    public void AddTempManaCrystals(int numCrystals)
    {
        for (int i = 0; i < numCrystals; i++)
        {
            base.StartCoroutine(this.WaitThenAddManaCrystal(true, false));
        }
    }

    private void Awake()
    {
        s_instance = this;
        if (base.gameObject.audio == null)
        {
            base.gameObject.AddComponent("AudioSource");
        }
    }

    public void CancelAllProposedMana(Entity entity)
    {
        if ((entity != null) && (this.m_proposedManaSourceEntID == entity.GetEntityId()))
        {
            this.m_proposedManaSourceEntID = -1;
            this.m_eventSpells.m_proposeUsageSpell.ActivateState(SpellStateType.DEATH);
            for (int i = 0; i < this.m_temporaryCrystals.Count; i++)
            {
                if (this.m_temporaryCrystals[i].state == ManaCrystal.State.PROPOSED)
                {
                    this.m_temporaryCrystals[i].state = ManaCrystal.State.READY;
                }
            }
            for (int j = this.m_permanentCrystals.Count - 1; j >= 0; j--)
            {
                if (this.m_permanentCrystals[j].state == ManaCrystal.State.PROPOSED)
                {
                    this.m_permanentCrystals[j].state = ManaCrystal.State.READY;
                }
            }
        }
    }

    private void DestroyManaCrystal()
    {
        if (this.m_permanentCrystals.Count > 0)
        {
            int index = 0;
            ManaCrystal crystal = this.m_permanentCrystals[index];
            this.m_permanentCrystals.RemoveAt(index);
            crystal.GetComponent<ManaCrystal>().Destroy();
            this.UpdateLayout();
            base.StartCoroutine(this.UpdatePermanentCrystalStates());
        }
    }

    public void DestroyManaCrystals(int numCrystals)
    {
        base.StartCoroutine(this.WaitThenDestroyManaCrystals(false, numCrystals));
    }

    private void DestroyTempManaCrystal()
    {
        if (this.m_temporaryCrystals.Count > 0)
        {
            int index = this.m_temporaryCrystals.Count - 1;
            ManaCrystal crystal = this.m_temporaryCrystals[index];
            this.m_temporaryCrystals.RemoveAt(index);
            crystal.GetComponent<ManaCrystal>().Destroy();
            this.UpdateLayout();
        }
    }

    public void DestroyTempManaCrystals(int numCrystals)
    {
        base.StartCoroutine(this.WaitThenDestroyManaCrystals(true, numCrystals));
    }

    public static ManaCrystalMgr Get()
    {
        return s_instance;
    }

    public Vector3 GetManaCrystalSpawnPosition()
    {
        return base.transform.position;
    }

    private void LoadCrystalCallback(string actorName, GameObject actorObject, object callbackData)
    {
        this.m_numCrystalsLoading--;
        LoadCrystalCallbackData data = callbackData as LoadCrystalCallbackData;
        ManaCrystal component = actorObject.GetComponent<ManaCrystal>();
        if (data.IsTempCrystal)
        {
            component.MarkAsTemp();
            this.m_temporaryCrystals.Add(component);
        }
        else
        {
            this.m_permanentCrystals.Add(component);
            if (data.IsTurnStart)
            {
                if (this.m_additionalRecalledCrystalsOwedThisTurn > 0)
                {
                    component.PayRecall();
                    this.m_additionalRecalledCrystalsOwedThisTurn--;
                }
            }
            else if (this.m_additionalRecalledCrystalsOwedNextTurn > 0)
            {
                component.state = ManaCrystal.State.USED;
                component.MarkAsOwedForRecall();
                this.m_additionalRecalledCrystalsOwedNextTurn--;
            }
        }
        component.transform.parent = base.transform;
        component.transform.localPosition = Vector3.zero;
        component.PlayCreateAnimation();
        SoundManager.Get().LoadAndPlay("mana_crystal_add", base.gameObject);
        this.UpdateLayout();
    }

    public void MarkCrystalsOwedForRecall(int numCrystals)
    {
        if (numCrystals > 0)
        {
            this.m_recallLocksAreShowing = true;
        }
        int num = 0;
        for (int i = 0; numCrystals != num; i++)
        {
            if (i == this.m_permanentCrystals.Count)
            {
                this.m_additionalRecalledCrystalsOwedNextTurn += numCrystals - num;
                break;
            }
            ManaCrystal crystal = this.m_permanentCrystals[i];
            if (!crystal.IsOwedForRecall())
            {
                crystal.MarkAsOwedForRecall();
                num++;
            }
        }
    }

    public void NotifyOfTurnChange()
    {
        this.m_additionalRecalledCrystalsOwedThisTurn = this.m_additionalRecalledCrystalsOwedNextTurn;
        this.m_additionalRecalledCrystalsOwedNextTurn = 0;
        if (this.m_additionalRecalledCrystalsOwedThisTurn > 0)
        {
            this.m_recallLocksAreShowing = true;
        }
        else
        {
            this.m_recallLocksAreShowing = false;
        }
        for (int i = 0; i < this.m_permanentCrystals.Count; i++)
        {
            ManaCrystal crystal = this.m_permanentCrystals[i];
            if (crystal.IsRecalled())
            {
                crystal.UnlockRecall();
            }
            if (crystal.IsOwedForRecall())
            {
                this.m_recallLocksAreShowing = true;
                crystal.PayRecall();
            }
            else if (this.m_additionalRecalledCrystalsOwedThisTurn > 0)
            {
                crystal.PayRecall();
                this.m_additionalRecalledCrystalsOwedThisTurn--;
            }
        }
    }

    public void ProposeManaCrystalUsage(Entity entity)
    {
        if (entity != null)
        {
            this.m_proposedManaSourceEntID = entity.GetEntityId();
            int cost = entity.GetCost();
            this.m_eventSpells.m_proposeUsageSpell.ActivateState(SpellStateType.BIRTH);
            int num2 = 0;
            for (int i = this.m_temporaryCrystals.Count - 1; i >= 0; i--)
            {
                if (this.m_temporaryCrystals[i].state == ManaCrystal.State.USED)
                {
                    Log.Rachelle.Print("Found a SPENT temporary mana crystal... this shouldn't happen!");
                }
                else if (num2 < cost)
                {
                    this.m_temporaryCrystals[i].state = ManaCrystal.State.PROPOSED;
                    num2++;
                }
                else
                {
                    this.m_temporaryCrystals[i].state = ManaCrystal.State.READY;
                }
            }
            for (int j = 0; j < this.m_permanentCrystals.Count; j++)
            {
                if ((this.m_permanentCrystals[j].state != ManaCrystal.State.USED) && !this.m_permanentCrystals[j].IsRecalled())
                {
                    if (num2 < cost)
                    {
                        this.m_permanentCrystals[j].state = ManaCrystal.State.PROPOSED;
                        num2++;
                    }
                    else
                    {
                        this.m_permanentCrystals[j].state = ManaCrystal.State.READY;
                    }
                }
            }
        }
    }

    private void ReadyManaCrystal()
    {
        base.StartCoroutine(this.WaitThenReadyManaCrystal());
    }

    public void ReadyManaCrystals(int numCrystals)
    {
        for (int i = 0; i < numCrystals; i++)
        {
            this.ReadyManaCrystal();
        }
    }

    public bool ShouldShowRecallTooltip()
    {
        return this.m_recallLocksAreShowing;
    }

    private void SpendManaCrystal()
    {
        base.StartCoroutine(this.WaitThenSpendManaCrystal());
    }

    public void SpendManaCrystals(int numCrystals)
    {
        SoundManager.Get().LoadAndPlay("mana_crystal_expend", base.gameObject);
        for (int i = 0; i < numCrystals; i++)
        {
            this.SpendManaCrystal();
        }
    }

    private void Start()
    {
        this.m_permanentCrystals = new List<ManaCrystal>();
        this.m_temporaryCrystals = new List<ManaCrystal>();
    }

    private void UpdateLayout()
    {
        if (this.m_permanentCrystals.Count > 0)
        {
            float x = this.m_permanentCrystals[0].transform.FindChild("Gem_Mana").renderer.bounds.size.x;
            float num2 = base.transform.position.x;
            float y = base.transform.position.y;
            float z = base.transform.position.z;
            for (int i = this.m_permanentCrystals.Count - 1; i >= 0; i--)
            {
                this.m_permanentCrystals[i].transform.position = new Vector3(num2, y, z);
                num2 += x;
            }
            for (int j = 0; j < this.m_temporaryCrystals.Count; j++)
            {
                this.m_temporaryCrystals[j].transform.position = new Vector3(num2, y, z);
                num2 += x;
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator UpdatePermanentCrystalStates()
    {
        return new <UpdatePermanentCrystalStates>c__Iterator49 { <>f__this = this };
    }

    public void UpdateSpentMana(int shownChangeAmount)
    {
        if (shownChangeAmount > 0)
        {
            this.SpendManaCrystals(shownChangeAmount);
        }
        else if (GameState.Get().IsTurnStartManagerActive())
        {
            TurnStartManager.Get().NotifyOfManaCrystalFilled(-shownChangeAmount);
        }
        else
        {
            this.ReadyManaCrystals(-shownChangeAmount);
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitThenAddManaCrystal(bool isTemp, bool isTurnStart)
    {
        return new <WaitThenAddManaCrystal>c__Iterator4A { isTemp = isTemp, isTurnStart = isTurnStart, <$>isTemp = isTemp, <$>isTurnStart = isTurnStart, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitThenDestroyManaCrystals(bool isTemp, int numCrystals)
    {
        return new <WaitThenDestroyManaCrystals>c__Iterator4B { numCrystals = numCrystals, isTemp = isTemp, <$>numCrystals = numCrystals, <$>isTemp = isTemp, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitThenReadyManaCrystal()
    {
        return new <WaitThenReadyManaCrystal>c__Iterator4C { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitThenSpendManaCrystal()
    {
        return new <WaitThenSpendManaCrystal>c__Iterator4D { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <UpdatePermanentCrystalStates>c__Iterator49 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ManaCrystalMgr <>f__this;
        internal int <i>__1;
        internal int <j>__2;
        internal int <numUsedCrystals>__0;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                case 1:
                    if (((this.<>f__this.m_numQueuedToReady > 0) || (this.<>f__this.m_numCrystalsLoading > 0)) || (this.<>f__this.m_numQueuedToSpend > 0))
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<numUsedCrystals>__0 = GameState.Get().GetLocalPlayer().GetTag(GAME_TAG.RESOURCES_USED);
                    this.<i>__1 = 0;
                    while (this.<i>__1 < this.<numUsedCrystals>__0)
                    {
                        if (this.<i>__1 == this.<>f__this.m_permanentCrystals.Count)
                        {
                            break;
                        }
                        if (this.<>f__this.m_permanentCrystals[this.<i>__1].state != ManaCrystal.State.USED)
                        {
                            this.<>f__this.m_permanentCrystals[this.<i>__1].state = ManaCrystal.State.USED;
                        }
                        this.<i>__1++;
                    }
                    break;

                default:
                    goto Label_0192;
            }
            this.<j>__2 = this.<i>__1;
            while (this.<j>__2 < this.<>f__this.m_permanentCrystals.Count)
            {
                if (this.<>f__this.m_permanentCrystals[this.<j>__2].state != ManaCrystal.State.READY)
                {
                    this.<>f__this.m_permanentCrystals[this.<j>__2].state = ManaCrystal.State.READY;
                }
                this.<j>__2++;
            }
            this.$PC = -1;
        Label_0192:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <WaitThenAddManaCrystal>c__Iterator4A : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal bool <$>isTemp;
        internal bool <$>isTurnStart;
        internal ManaCrystalMgr <>f__this;
        internal ManaCrystalMgr.LoadCrystalCallbackData <callbackData>__0;
        internal bool isTemp;
        internal bool isTurnStart;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<>f__this.m_numCrystalsLoading++;
                    this.<>f__this.m_numQueuedToSpawn++;
                    this.$current = new WaitForSeconds(this.<>f__this.m_numQueuedToSpawn * 0.2f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<callbackData>__0 = new ManaCrystalMgr.LoadCrystalCallbackData(this.isTemp, this.isTurnStart);
                    AssetLoader.Get().LoadActor("Resource", new AssetLoader.GameObjectCallback(this.<>f__this.LoadCrystalCallback), this.<callbackData>__0);
                    this.<>f__this.m_numQueuedToSpawn--;
                    this.$PC = -1;
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <WaitThenDestroyManaCrystals>c__Iterator4B : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal bool <$>isTemp;
        internal int <$>numCrystals;
        internal ManaCrystalMgr <>f__this;
        internal int <i>__0;
        internal bool isTemp;
        internal int numCrystals;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                case 1:
                    if (this.<>f__this.m_numCrystalsLoading > 0)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<i>__0 = 0;
                    while (this.<i>__0 < this.numCrystals)
                    {
                        if (this.isTemp)
                        {
                            this.<>f__this.DestroyTempManaCrystal();
                        }
                        else
                        {
                            this.<>f__this.DestroyManaCrystal();
                        }
                        this.<i>__0++;
                    }
                    this.$PC = -1;
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <WaitThenReadyManaCrystal>c__Iterator4C : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ManaCrystalMgr <>f__this;
        internal int <i>__0;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<>f__this.m_numQueuedToReady++;
                    this.$current = new WaitForSeconds(this.<>f__this.m_numQueuedToReady * 0.2f);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (this.<>f__this.m_permanentCrystals.Count > 0)
                    {
                        this.<i>__0 = this.<>f__this.m_permanentCrystals.Count - 1;
                        while (this.<i>__0 >= 0)
                        {
                            if (this.<>f__this.m_permanentCrystals[this.<i>__0].state == ManaCrystal.State.USED)
                            {
                                SoundManager.Get().LoadAndPlay("mana_crystal_refresh", this.<>f__this.gameObject);
                                this.<>f__this.m_permanentCrystals[this.<i>__0].state = ManaCrystal.State.READY;
                                break;
                            }
                            this.<i>__0--;
                        }
                    }
                    break;

                default:
                    goto Label_0125;
            }
            this.<>f__this.m_numQueuedToReady--;
            this.$PC = -1;
        Label_0125:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <WaitThenSpendManaCrystal>c__Iterator4D : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ManaCrystalMgr <>f__this;
        internal int <i>__0;
        internal Card <mousedOverCard>__1;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<>f__this.m_numQueuedToSpend++;
                    this.$current = new WaitForSeconds((this.<>f__this.m_numQueuedToSpend - 1) * 0.2f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<i>__0 = 0;
                    while (this.<i>__0 < this.<>f__this.m_permanentCrystals.Count)
                    {
                        if ((this.<>f__this.m_permanentCrystals[this.<i>__0].state != ManaCrystal.State.USED) && !this.<>f__this.m_permanentCrystals[this.<i>__0].IsRecalled())
                        {
                            this.<>f__this.m_permanentCrystals[this.<i>__0].state = ManaCrystal.State.USED;
                            break;
                        }
                        this.<i>__0++;
                    }
                    break;

                default:
                    goto Label_0181;
            }
            this.<>f__this.m_numQueuedToSpend--;
            if (this.<>f__this.m_numQueuedToSpend <= 0)
            {
                this.<mousedOverCard>__1 = InputManager.Get().GetMousedOverCard();
                if ((this.<mousedOverCard>__1 != null) && this.<mousedOverCard>__1.GetEntity().GetController().IsLocal())
                {
                    this.<>f__this.ProposeManaCrystalUsage(this.<mousedOverCard>__1.GetEntity());
                }
                this.$PC = -1;
            }
        Label_0181:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    private class LoadCrystalCallbackData
    {
        private bool m_isTempCrystal;
        private bool m_isTurnStart;

        public LoadCrystalCallbackData(bool isTempCrystal, bool isTurnStart)
        {
            this.m_isTempCrystal = isTempCrystal;
            this.m_isTurnStart = isTurnStart;
        }

        public bool IsTempCrystal
        {
            get
            {
                return this.m_isTempCrystal;
            }
        }

        public bool IsTurnStart
        {
            get
            {
                return this.m_isTurnStart;
            }
        }
    }
}

