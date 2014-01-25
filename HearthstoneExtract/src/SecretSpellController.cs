using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SecretSpellController : SpellController
{
    public List<SecretBannerDef> m_BannerDefs;
    private Spell m_bannerSpell;
    public Spell m_DefaultBannerSpellPrefab;
    private Spell m_triggerSpell;

    protected override bool AddPowerSourceAndTargets(PowerTaskList taskList)
    {
        Entity sourceEntity = taskList.GetSourceEntity();
        if (sourceEntity == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("{0}.AddPowerSourceAndTargets() - FAILED to get source entity from task list {1}", this, taskList.GetId()));
            return false;
        }
        Card card = sourceEntity.GetCard();
        if (card == null)
        {
            return false;
        }
        bool flag = false;
        if (this.InitBannerSpell(sourceEntity))
        {
            flag = true;
        }
        Spell triggerSpell = this.GetTriggerSpell(card);
        if ((triggerSpell != null) && this.InitTriggerSpell(card, triggerSpell))
        {
            flag = true;
        }
        base.SetSource(card);
        return flag;
    }

    private Spell DetermineBannerSpellPrefab(Entity sourceEntity)
    {
        if (this.m_BannerDefs == null)
        {
            return null;
        }
        TAG_CLASS classTag = sourceEntity.GetClass();
        SpellClassTag tag = SpellUtils.ConvertHeroTagToSpellEnum(classTag);
        if (tag == SpellClassTag.NONE)
        {
            UnityEngine.Debug.LogWarning(string.Format("{0}.DetermineBannerSpellPrefab() - entity {1} has unknown class tag {2}. Using default banner.", this, sourceEntity, classTag));
        }
        else if ((this.m_BannerDefs != null) && (this.m_BannerDefs.Count > 0))
        {
            for (int i = 0; i < this.m_BannerDefs.Count; i++)
            {
                SecretBannerDef def = this.m_BannerDefs[i];
                if (tag == def.m_HeroClass)
                {
                    return def.m_SpellPrefab;
                }
            }
            Log.Asset.Print(string.Format("{0}.DetermineBannerSpellPrefab() - class type {1} has no Banner Def. Using default banner.", this, tag));
        }
        return this.m_DefaultBannerSpellPrefab;
    }

    private bool FireBannerSpell()
    {
        if (this.m_bannerSpell == null)
        {
            return false;
        }
        this.m_bannerSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnBannerSpellFinished));
        this.m_bannerSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnBannerSpellStateFinished));
        this.m_bannerSpell.Activate();
        return true;
    }

    private bool FireSecretActorSpell()
    {
        Card source = base.GetSource();
        Actor actor = source.GetActor();
        if (actor == null)
        {
            Log.Power.Print(string.Format("{0}.FireSecretActorSpell() - card {1} has no actor", this, source));
            return false;
        }
        Spell component = actor.GetComponent<Spell>();
        if (component == null)
        {
            Log.Power.Print(string.Format("{0}.FireSecretActorSpell() - actor for card {1} has no Spell component", this, source));
            return false;
        }
        component.ActivateState(SpellStateType.ACTION);
        return true;
    }

    private bool FireTriggerSpell()
    {
        Card source = base.GetSource();
        Spell triggerSpell = this.GetTriggerSpell(source);
        if (triggerSpell == null)
        {
            return false;
        }
        if ((triggerSpell.GetPowerTaskList() != base.m_taskList) && !this.InitTriggerSpell(source, triggerSpell))
        {
            return false;
        }
        triggerSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnTriggerSpellFinished));
        triggerSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnTriggerSpellStateFinished));
        triggerSpell.SafeActivateState(SpellStateType.ACTION);
        return true;
    }

    private Spell GetTriggerSpell(Card card)
    {
        Network.HistActionStart sourceAction = base.m_taskList.GetSourceAction();
        return card.GetTriggerSpell(sourceAction.Index);
    }

    private bool InitBannerSpell(Entity sourceEntity)
    {
        Spell spell = this.DetermineBannerSpellPrefab(sourceEntity);
        if (spell == null)
        {
            return false;
        }
        this.m_bannerSpell = ((GameObject) UnityEngine.Object.Instantiate(spell.gameObject)).GetComponent<Spell>();
        return true;
    }

    private bool InitTriggerSpell(Card card, Spell triggerSpell)
    {
        if (!triggerSpell.AttachPowerTaskList(base.m_taskList))
        {
            Network.HistActionStart sourceAction = base.m_taskList.GetSourceAction();
            Log.Power.Print(string.Format("{0}.InitTriggerSpell() - FAILED to attach task list to trigger spell {1} for {2}", this, sourceAction.Index, card));
            return false;
        }
        return true;
    }

    private void OnBannerSpellFinished(Spell spell, object userData)
    {
        base.StartCoroutine(this.RunPostBannerEvents());
    }

    private void OnBannerSpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (this.m_bannerSpell.GetActiveState() == SpellStateType.NONE)
        {
            UnityEngine.Object.Destroy(this.m_bannerSpell.gameObject);
            this.m_bannerSpell = null;
        }
    }

    protected override void OnProcessTaskList()
    {
        this.FireSecretActorSpell();
        if (!this.FireBannerSpell() && !this.FireTriggerSpell())
        {
            base.OnProcessTaskList();
        }
    }

    private void OnTriggerSpellFinished(Spell triggerSpell, object userData)
    {
        base.OnFinishedTaskList();
    }

    private void OnTriggerSpellStateFinished(Spell triggerSpell, SpellStateType prevStateType, object userData)
    {
        if (triggerSpell.GetActiveState() == SpellStateType.NONE)
        {
            base.OnFinished();
        }
    }

    [DebuggerHidden]
    private IEnumerator RunPostBannerEvents()
    {
        return new <RunPostBannerEvents>c__IteratorB2 { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <RunPostBannerEvents>c__IteratorB2 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SecretSpellController <>f__this;

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
                    HistoryManager.Get().NotifyOfSecretSpellFinished();
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (!this.<>f__this.FireTriggerSpell())
                    {
                        this.<>f__this.OnProcessTaskList();
                        this.$PC = -1;
                        break;
                    }
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

