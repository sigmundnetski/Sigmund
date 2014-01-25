using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class JaraxxusHeroSpell : Spell
{
    private PowerTask m_heroPowerTask;
    private PowerTask m_weaponTask;

    public override bool AddPowerTargets()
    {
        foreach (PowerTask task in base.m_taskList.GetTaskList())
        {
            Network.PowerHistory power = task.GetPower();
            if (power.Type == Network.PowerHistory.PowType.FULL_ENTITY)
            {
                Network.HistFullEntity entity = power as Network.HistFullEntity;
                int iD = entity.Entity.ID;
                Entity entity2 = GameState.Get().GetEntity(iD);
                if (entity2 == null)
                {
                    UnityEngine.Debug.LogWarning(string.Format("{0}.AddPowerTargets() - WARNING encountered HistFullEntity where entity id={1} but there is no entity with that id", this, iD));
                    return false;
                }
                if (entity2.IsHeroPower())
                {
                    this.m_heroPowerTask = task;
                    this.AddTarget(entity2.GetCard().gameObject);
                    if (this.m_weaponTask != null)
                    {
                        return true;
                    }
                }
                else if (entity2.IsWeapon())
                {
                    this.m_weaponTask = task;
                    this.AddTarget(entity2.GetCard().gameObject);
                    if (this.m_heroPowerTask != null)
                    {
                        return true;
                    }
                }
            }
        }
        this.Reset();
        return false;
    }

    private void Finish()
    {
        this.Reset();
        this.OnSpellFinished();
    }

    private Card GetCardFromTask(PowerTask task)
    {
        Network.HistFullEntity power = task.GetPower() as Network.HistFullEntity;
        int iD = power.Entity.ID;
        return GameState.Get().GetEntity(iD).GetCard();
    }

    private Entity LoadCardFromTask(PowerTask task)
    {
        Network.HistFullEntity power = task.GetPower() as Network.HistFullEntity;
        Network.Entity entity = power.Entity;
        int iD = entity.ID;
        Entity entity3 = GameState.Get().GetEntity(iD);
        entity3.LoadCard(entity.CardID);
        return entity3;
    }

    protected override void OnAction(SpellStateType prevStateType)
    {
        base.OnAction(prevStateType);
        base.StartCoroutine(this.SetupCards());
    }

    private void OnSpellFinished_HeroPower(Spell spell, object userData)
    {
        this.m_heroPowerTask.SetCompleted(true);
        if (this.m_weaponTask.IsCompleted())
        {
            this.Finish();
        }
    }

    private void OnSpellFinished_Weapon(Spell spell, object userData)
    {
        Card cardFromTask = this.GetCardFromTask(this.m_weaponTask);
        cardFromTask.ShowCard();
        cardFromTask.CreateStartingCardStateEffects();
        this.m_weaponTask.SetCompleted(true);
        if (this.m_heroPowerTask.IsCompleted())
        {
            this.Finish();
        }
    }

    private void PlayCardSpells(Card heroPowerCard, Card weaponCard)
    {
        heroPowerCard.ShowCard();
        heroPowerCard.CreateStartingCardStateEffects();
        heroPowerCard.ActivateActorSpell(SpellType.SUMMON_JARAXXUS, new Spell.FinishedCallback(this.OnSpellFinished_HeroPower));
        weaponCard.ActivateActorSpell(SpellType.SUMMON_JARAXXUS, new Spell.FinishedCallback(this.OnSpellFinished_Weapon));
    }

    private void Reset()
    {
        this.m_heroPowerTask = null;
        this.m_weaponTask = null;
    }

    [DebuggerHidden]
    private IEnumerator SetupCards()
    {
        return new <SetupCards>c__IteratorAE { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <SetupCards>c__IteratorAE : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal JaraxxusHeroSpell <>f__this;
        internal Entity <heroPower>__0;
        internal Card <heroPowerCard>__2;
        internal Zone <heroPowerZone>__3;
        internal Entity <weapon>__1;
        internal Card <weaponCard>__4;
        internal Zone <weaponZone>__5;

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
                    this.<heroPower>__0 = this.<>f__this.LoadCardFromTask(this.<>f__this.m_heroPowerTask);
                    this.<weapon>__1 = this.<>f__this.LoadCardFromTask(this.<>f__this.m_weaponTask);
                    break;

                case 1:
                    break;

                case 2:
                    goto Label_0133;

                default:
                    goto Label_0171;
            }
            if (!this.<heroPower>__0.IsCardReady() || !this.<weapon>__1.IsCardReady())
            {
                this.$current = null;
                this.$PC = 1;
                goto Label_0173;
            }
            this.<heroPowerCard>__2 = this.<heroPower>__0.GetCard();
            this.<heroPowerCard>__2.HideCard();
            this.<heroPowerZone>__3 = ZoneMgr.Get().FindZoneForEntity(this.<heroPower>__0);
            this.<heroPowerCard>__2.TransitionToZone(this.<heroPowerZone>__3);
            this.<weaponCard>__4 = this.<weapon>__1.GetCard();
            this.<weaponCard>__4.HideCard();
            this.<weaponZone>__5 = ZoneMgr.Get().FindZoneForEntity(this.<weapon>__1);
            this.<weaponCard>__4.TransitionToZone(this.<weaponZone>__5);
        Label_0133:
            while (this.<heroPowerCard>__2.IsActorLoading() || this.<weaponCard>__4.IsActorLoading())
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_0173;
            }
            this.<>f__this.PlayCardSpells(this.<heroPowerCard>__2, this.<weaponCard>__4);
            this.$PC = -1;
        Label_0171:
            return false;
        Label_0173:
            return true;
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

