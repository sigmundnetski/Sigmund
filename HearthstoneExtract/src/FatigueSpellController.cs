using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FatigueSpellController : SpellController
{
    private readonly Vector3 FATIGUE_ACTOR_FINAL_LOCAL_ROTATION = Vector3.zero;
    private readonly float FATIGUE_ACTOR_FINAL_SCALE = 1f;
    private readonly Vector3 FATIGUE_ACTOR_INITIAL_LOCAL_ROTATION = new Vector3(270f, 270f, 0f);
    private readonly float FATIGUE_ACTOR_START_SCALE = 0.88f;
    private readonly float FATIGUE_DRAW_ANIM_TIME = 3f;
    private readonly float FATIGUE_DRAW_SCALE_TIME = 2f;
    private Network.HistTagChange m_armorTagChange;
    private Network.HistTagChange m_damageTagChange;
    private Actor m_fatigueActor;
    private Network.HistTagChange m_fatigueTagChange;
    private int m_previousArmorValue;
    private int m_previousDamageValue;
    private static int s_numFatigueSpellsPlaying;

    protected override bool AddPowerSourceAndTargets(PowerTaskList taskList)
    {
        this.m_armorTagChange = null;
        this.m_damageTagChange = null;
        this.m_fatigueTagChange = null;
        PowerTask task = null;
        PowerTask task2 = null;
        List<PowerTask> list = base.m_taskList.GetTaskList();
        for (int i = 0; i < list.Count; i++)
        {
            Network.HistTagChange change;
            PowerTask task3 = list[i];
            Network.PowerHistory power = task3.GetPower();
            if (power.Type == Network.PowerHistory.PowType.TAG_CHANGE)
            {
                change = power as Network.HistTagChange;
                GAME_TAG tag = (GAME_TAG) change.Tag;
                if (tag != GAME_TAG.FATIGUE)
                {
                    if (tag == GAME_TAG.DAMAGE)
                    {
                        goto Label_0099;
                    }
                    if (tag == GAME_TAG.ARMOR)
                    {
                        goto Label_00BA;
                    }
                    goto Label_00DB;
                }
                this.m_fatigueTagChange = change;
                task3.DoTask();
            }
            continue;
        Label_0099:
            if (this.SetDamageTagChange(change))
            {
                task = task3;
            }
            else
            {
                task3.DoTask();
            }
            continue;
        Label_00BA:
            if (this.SetArmorTagChange(change))
            {
                task2 = task3;
            }
            else
            {
                task3.DoTask();
            }
            continue;
        Label_00DB:
            task3.DoTask();
        }
        if (this.m_fatigueTagChange == null)
        {
            return false;
        }
        if ((this.m_armorTagChange == null) && (this.m_damageTagChange == null))
        {
            return false;
        }
        if (this.m_damageTagChange != null)
        {
            base.GetSource().GetEntity().SetTag(this.m_damageTagChange.Tag, this.m_damageTagChange.Value);
            task.SetCompleted(true);
        }
        if (this.m_armorTagChange != null)
        {
            base.GetSource().GetEntity().SetTag(this.m_armorTagChange.Tag, this.m_armorTagChange.Value);
            task2.SetCompleted(true);
        }
        return true;
    }

    private void DestroyFatigueCard()
    {
        s_numFatigueSpellsPlaying--;
        if (this.m_fatigueActor == null)
        {
            this.FinishSpellController();
        }
        else
        {
            Spell spell = this.m_fatigueActor.GetSpell(SpellType.DEATH);
            if (spell == null)
            {
                this.FinishSpellController();
            }
            else
            {
                spell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnFatigueDeathSpellFinished));
                spell.Activate();
            }
        }
    }

    private void DoDamageAndArmorChanges()
    {
        Card source = base.GetSource();
        Entity entity = source.GetEntity();
        HistoryManager.Get().CreateFatigueTile();
        if (this.m_damageTagChange != null)
        {
            entity.SetTag(this.m_damageTagChange.Tag, this.m_previousDamageValue);
            HistoryManager.Get().NotifyAboutDamageChanged(entity, this.m_damageTagChange.Value);
            entity.SetTagAndUpdateCard(this.m_damageTagChange.Tag, this.m_damageTagChange.Value);
        }
        if (this.m_armorTagChange != null)
        {
            entity.SetTag(this.m_armorTagChange.Tag, this.m_previousArmorValue);
            HistoryManager.Get().NotifyAboutArmorChanged(entity, this.m_armorTagChange.Value);
            entity.SetTagAndUpdateCard(this.m_armorTagChange.Tag, this.m_armorTagChange.Value);
        }
        HistoryManager.Get().MarkCurrentHistoryEntryAsCompleted();
        Spell spell = source.GetActor().GetSpell(SpellType.FATIGUE_DEATH);
        spell.AddFinishedCallback(new Spell.FinishedCallback(this.OnFatigueDamageFinished));
        spell.ActivateState(SpellStateType.BIRTH);
    }

    private void FinishSpellController()
    {
        base.OnFinishedTaskList();
        base.OnFinished();
    }

    private void OnFatigueActorLoaded(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("FatigueSpellController.OnFatigueActorLoaded() - FAILED to load actor \"{0}\"", actorName));
            this.DoDamageAndArmorChanges();
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("FatigueSpellController.OnFatigueActorLoaded() - ERROR actor \"{0}\" has no Actor component", actorName));
                this.DoDamageAndArmorChanges();
            }
            else
            {
                this.m_fatigueActor = component;
                UberText powersTextMesh = this.m_fatigueActor.GetPowersTextMesh();
                if (powersTextMesh != null)
                {
                    powersTextMesh.Text = string.Format(GameStrings.Get("GAMEPLAY_FATIGUE_TEXT"), this.m_fatigueTagChange.Value);
                }
                ZoneDeck deck = !base.GetSource().GetEntity().IsControlledByLocalPlayer() ? GameState.Get().GetRemotePlayer().GetDeckZone() : GameState.Get().GetLocalPlayer().GetDeckZone();
                deck.DoFatigueGlow();
                this.m_fatigueActor.transform.localEulerAngles = this.FATIGUE_ACTOR_INITIAL_LOCAL_ROTATION;
                this.m_fatigueActor.transform.position = deck.transform.position;
                this.m_fatigueActor.transform.localScale = new Vector3(this.FATIGUE_ACTOR_START_SCALE, this.FATIGUE_ACTOR_START_SCALE, this.FATIGUE_ACTOR_START_SCALE);
                Vector3[] vectorArray = new Vector3[] { this.m_fatigueActor.transform.position, new Vector3(this.m_fatigueActor.transform.position.x, this.m_fatigueActor.transform.position.y + 3.6f, this.m_fatigueActor.transform.position.z), Board.Get().FindBone("FatigueCardBone").position };
                object[] args = new object[] { "path", vectorArray, "time", this.FATIGUE_DRAW_ANIM_TIME, "easetype", iTween.EaseType.easeInSineOutExpo };
                iTween.MoveTo(this.m_fatigueActor.gameObject, iTween.Hash(args));
                object[] objArray2 = new object[] { "rotation", this.FATIGUE_ACTOR_FINAL_LOCAL_ROTATION, "time", this.FATIGUE_DRAW_ANIM_TIME, "delay", this.FATIGUE_DRAW_ANIM_TIME / 8f };
                iTween.RotateTo(this.m_fatigueActor.gameObject, iTween.Hash(objArray2));
                iTween.ScaleTo(this.m_fatigueActor.gameObject, new Vector3(this.FATIGUE_ACTOR_FINAL_SCALE, this.FATIGUE_ACTOR_FINAL_SCALE, this.FATIGUE_ACTOR_FINAL_SCALE), this.FATIGUE_DRAW_SCALE_TIME);
                base.StartCoroutine(this.WaitThenDoDamageAndArmorChanges(this.FATIGUE_DRAW_ANIM_TIME));
            }
        }
    }

    private void OnFatigueDamageFinished(Spell spell, object userData)
    {
        spell.RemoveFinishedCallback(new Spell.FinishedCallback(this.OnFatigueDamageFinished));
        this.DestroyFatigueCard();
    }

    private void OnFatigueDeathSpellFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (this.m_fatigueActor != null)
        {
            this.m_fatigueActor.Destroy();
            this.m_fatigueActor = null;
        }
        this.FinishSpellController();
    }

    protected override void OnProcessTaskList()
    {
        base.StartCoroutine(this.WaitThenProcessTaskList());
    }

    private bool SetArmorTagChange(Network.HistTagChange armorTagChange)
    {
        Entity entity = GameState.Get().GetEntity(armorTagChange.Entity);
        if (entity == null)
        {
            return false;
        }
        if (!entity.IsHero())
        {
            return false;
        }
        this.SetSourceIfNeeded(entity.GetCard());
        this.m_previousArmorValue = entity.GetArmor();
        this.m_armorTagChange = armorTagChange;
        return true;
    }

    private bool SetDamageTagChange(Network.HistTagChange damageTagChange)
    {
        Entity entity = GameState.Get().GetEntity(damageTagChange.Entity);
        if (entity == null)
        {
            return false;
        }
        if (!entity.IsHero())
        {
            return false;
        }
        this.SetSourceIfNeeded(entity.GetCard());
        this.m_previousDamageValue = entity.GetDamage();
        this.m_damageTagChange = damageTagChange;
        return true;
    }

    private void SetSourceIfNeeded(Card sourceCard)
    {
        if (base.GetSource() != null)
        {
            if (sourceCard != base.GetSource())
            {
                Log.Rachelle.Print(string.Format("FatigueSpellController.SetSourceIfNeeded(): existing source card ({0}) does not match a subsequent source received ({1})!", base.GetSource(), sourceCard));
            }
        }
        else
        {
            base.SetSource(sourceCard);
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitThenDoDamageAndArmorChanges(float seconds)
    {
        return new <WaitThenDoDamageAndArmorChanges>c__IteratorAD { seconds = seconds, <$>seconds = seconds, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitThenProcessTaskList()
    {
        return new <WaitThenProcessTaskList>c__IteratorAC { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenDoDamageAndArmorChanges>c__IteratorAD : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal float <$>seconds;
        internal FatigueSpellController <>f__this;
        internal float seconds;

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
                    this.$current = new WaitForSeconds(this.seconds);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.DoDamageAndArmorChanges();
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
    private sealed class <WaitThenProcessTaskList>c__IteratorAC : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal FatigueSpellController <>f__this;

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
                    if (FatigueSpellController.s_numFatigueSpellsPlaying > 0)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    FatigueSpellController.s_numFatigueSpellsPlaying++;
                    AssetLoader.Get().LoadActor("Card_Hand_Fatigue", new AssetLoader.GameObjectCallback(this.<>f__this.OnFatigueActorLoaded));
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
}

