using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ManaCrystal : MonoBehaviour
{
    private readonly string ANIM_MANA_GEM_BIRTH = "ManaGemBirth";
    private readonly string ANIM_PROPOSED_TO_READY = "ManaGemProposed_Cancel";
    private readonly string ANIM_PROPOSED_TO_USED = "ManaGemProposed_Used";
    private readonly string ANIM_READY_TO_PROPOSED = "ManaGemProposed";
    private readonly string ANIM_READY_TO_USED = "ManaGemUsed";
    private readonly string ANIM_SPAWN_EFFECTS = "mana_spawn_edit";
    private readonly string ANIM_TEMP_MANA_GEM_BIRTH = "ManaGemBirth_Temp";
    private readonly string ANIM_TEMP_PROPOSED_TO_READY = "ManaGemProposed_Cancel_Temp";
    private readonly string ANIM_TEMP_READY_TO_PROPOSED = "ManaGemProposed_Temp";
    private readonly string ANIM_TEMP_SPAWN_EFFECTS = "mana_spawn_edit_temp";
    private readonly string ANIM_USED_TO_PROPOSED = "ManaGemUsed_Proposed";
    private readonly string ANIM_USED_TO_READY = "ManaGem_Restore";
    public GameObject gem;
    public GameObject gemDestroy;
    private bool m_birthAnimationPlayed;
    private bool m_isInGame = true;
    private bool m_isTemp;
    private bool m_playingAnimation;
    private Spell m_recallOwedSpell;
    private Spell m_recallPaidSpell;
    private State m_state;
    private State m_visibleState;
    public GameObject spawnEffects;
    public GameObject tempGemDestroy;
    public GameObject tempSpawnEffects;

    public void Destroy()
    {
        this.m_state = State.DESTROYED;
        base.StartCoroutine(this.WaitThenDestroy());
    }

    private string GetTransitionAnimName(State oldState, State newState)
    {
        string str = string.Empty;
        switch (oldState)
        {
            case State.READY:
                if (newState != State.PROPOSED)
                {
                    if (newState != State.USED)
                    {
                        return str;
                    }
                    return this.ANIM_READY_TO_USED;
                }
                return (!this.m_isTemp ? this.ANIM_READY_TO_PROPOSED : this.ANIM_TEMP_READY_TO_PROPOSED);

            case State.USED:
                if (newState != State.READY)
                {
                    if (newState != State.PROPOSED)
                    {
                        return str;
                    }
                    return this.ANIM_USED_TO_PROPOSED;
                }
                return this.ANIM_USED_TO_READY;

            case State.PROPOSED:
                if (newState != State.READY)
                {
                    if (newState != State.USED)
                    {
                        return str;
                    }
                    return this.ANIM_PROPOSED_TO_USED;
                }
                return (!this.m_isTemp ? this.ANIM_PROPOSED_TO_READY : this.ANIM_TEMP_PROPOSED_TO_READY);

            case State.DESTROYED:
                Log.Rachelle.Print("Trying to get an anim name for a mana that's been destroyed!!!");
                return str;
        }
        return str;
    }

    public bool IsOwedForRecall()
    {
        return (this.m_recallOwedSpell != null);
    }

    public bool IsRecalled()
    {
        return (this.m_recallPaidSpell != null);
    }

    public void MarkAsNotInGame()
    {
        this.m_isInGame = false;
    }

    public void MarkAsOwedForRecall()
    {
        this.MarkAsOwedForRecall(false);
    }

    public void MarkAsOwedForRecall(bool immediatelyLockForRecall)
    {
        if (this.IsOwedForRecall())
        {
            if (immediatelyLockForRecall)
            {
                this.PayRecall();
            }
        }
        else
        {
            GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(ManaCrystalMgr.Get().manaLockPrefab);
            obj2.transform.parent = base.transform;
            obj2.transform.localPosition = Vector3.zero;
            float x = 1f / base.transform.localScale.x;
            obj2.transform.localScale = new Vector3(x, x, x);
            this.m_recallOwedSpell = obj2.transform.FindChild("Lock_Mana").GetComponent<Spell>();
            if (immediatelyLockForRecall)
            {
                this.m_recallOwedSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnRecallBirthCompletePayRecall));
            }
            this.m_recallOwedSpell.ActivateState(SpellStateType.BIRTH);
        }
    }

    public void MarkAsTemp()
    {
        this.m_isTemp = true;
        ManaCrystalMgr mgr = ManaCrystalMgr.Get();
        this.gem.GetComponentInChildren<MeshRenderer>().material = mgr.tempManaCrystalMaterial;
        this.gem.transform.FindChild("Proposed_Quad").gameObject.GetComponent<MeshRenderer>().material = mgr.tempManaCrystalProposedQuadMaterial;
    }

    private void OnGemDestroyedAnimComplete(Spell spell, SpellStateType spellStateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            UnityEngine.Object.Destroy(base.gameObject);
        }
    }

    private void OnRecallBirthCompletePayRecall(Spell spell, SpellStateType spellStateType, object userData)
    {
        spell.RemoveStateFinishedCallback(new Spell.StateFinishedCallback(this.OnRecallBirthCompletePayRecall));
        this.PayRecall();
    }

    private void OnRecallUnlockedAnimComplete(Spell spell, SpellStateType spellStateType, object userData)
    {
        UnityEngine.Object.Destroy(spell.transform.parent.gameObject);
    }

    public void PayRecall()
    {
        if (!this.IsOwedForRecall())
        {
            this.state = State.USED;
            this.MarkAsOwedForRecall(true);
        }
        else
        {
            this.m_recallPaidSpell = this.m_recallOwedSpell;
            this.m_recallOwedSpell = null;
            this.m_recallPaidSpell.ActivateState(SpellStateType.ACTION);
        }
    }

    public void PlayCreateAnimation()
    {
        this.spawnEffects.SetActive(!this.m_isTemp);
        this.tempSpawnEffects.SetActive(this.m_isTemp);
        if (this.m_isTemp)
        {
            this.tempSpawnEffects.animation.Play(this.ANIM_TEMP_SPAWN_EFFECTS);
            this.PlayGemAnimation(this.ANIM_TEMP_MANA_GEM_BIRTH, State.READY);
        }
        else
        {
            this.spawnEffects.animation.Play(this.ANIM_SPAWN_EFFECTS);
            this.PlayGemAnimation(this.ANIM_MANA_GEM_BIRTH, State.READY);
        }
    }

    private void PlayGemAnimation(string animName, State newVisibleState)
    {
        if (this.m_isInGame && !this.m_birthAnimationPlayed)
        {
            if (!(animName.Equals(this.ANIM_MANA_GEM_BIRTH) || animName.Equals(this.ANIM_TEMP_MANA_GEM_BIRTH)))
            {
                return;
            }
            this.m_birthAnimationPlayed = true;
        }
        if (this.gem.animation[animName] == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("Mana gem animation named '{0}' doesn't exist.", animName));
        }
        else if ((this.state != State.DESTROYED) && !this.m_playingAnimation)
        {
            this.m_playingAnimation = true;
            this.gem.animation[animName].normalizedTime = 1f;
            this.gem.animation[animName].time = 0f;
            this.gem.animation[animName].speed = 1f;
            this.gem.animation.Play(animName);
            base.StartCoroutine(this.WaitForAnimation(animName, newVisibleState));
        }
    }

    private void Start()
    {
    }

    public void UnlockRecall()
    {
        if (this.IsRecalled())
        {
            this.m_recallPaidSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnRecallUnlockedAnimComplete));
            this.m_recallPaidSpell.ActivateState(SpellStateType.DEATH);
            this.m_recallPaidSpell = null;
        }
    }

    private void Update()
    {
        State newState = this.state;
        if ((newState != this.m_visibleState) && (newState != State.DESTROYED))
        {
            string transitionAnimName = this.GetTransitionAnimName(this.m_visibleState, newState);
            this.PlayGemAnimation(transitionAnimName, newState);
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitForAnimation(string animName, State newVisibleState)
    {
        return new <WaitForAnimation>c__Iterator47 { animName = animName, newVisibleState = newVisibleState, <$>animName = animName, <$>newVisibleState = newVisibleState, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitThenDestroy()
    {
        return new <WaitThenDestroy>c__Iterator48 { <>f__this = this };
    }

    public State state
    {
        get
        {
            return this.m_state;
        }
        set
        {
            if (this.m_state != State.DESTROYED)
            {
                if (value == State.DESTROYED)
                {
                    this.Destroy();
                }
                else
                {
                    this.m_state = value;
                }
            }
        }
    }

    [CompilerGenerated]
    private sealed class <WaitForAnimation>c__Iterator47 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal string <$>animName;
        internal ManaCrystal.State <$>newVisibleState;
        internal ManaCrystal <>f__this;
        internal string animName;
        internal ManaCrystal.State newVisibleState;

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
                    this.$current = new WaitForSeconds(this.<>f__this.gem.animation[this.animName].length);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.m_visibleState = this.newVisibleState;
                    this.<>f__this.m_playingAnimation = false;
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
    private sealed class <WaitThenDestroy>c__Iterator48 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ManaCrystal <>f__this;
        internal Spell <spell>__0;

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
                    if (this.<>f__this.m_playingAnimation)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<spell>__0 = !this.<>f__this.m_isTemp ? this.<>f__this.gemDestroy.GetComponent<Spell>() : this.<>f__this.tempGemDestroy.GetComponent<Spell>();
                    this.<spell>__0.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.<>f__this.OnGemDestroyedAnimComplete));
                    this.<spell>__0.Activate();
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

    public enum State
    {
        READY,
        USED,
        PROPOSED,
        DESTROYED
    }
}

