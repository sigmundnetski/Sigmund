using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AttackSpellController : SpellController
{
    public AllyAttackDef m_AllyInfo;
    private AttackType m_attackType;
    public Spell m_DefaultImpactSpellPrefab;
    public HeroAttackDef m_HeroInfo;
    public List<AttackImpactDef> m_ImpactDefs;
    public float m_ImpactStagingPoint = 1f;
    private Card m_prevAttackerCard;
    private AttackType m_prevAttackType;
    private Spell m_sourceAttackSpell;
    private Vector3 m_sourceFacing;
    public float m_SourceImpactOffset = -0.25f;
    private Vector3 m_sourcePos;
    private Vector3 m_sourceToTarget;
    private const float PROPOSED_ATTACK_IMPACT_POINT_SCALAR = 0.5f;
    private const float WINDFURY_REMINDER_WAIT_SEC = 1.2f;

    private void ActivateImpactEffects(Card sourceCard, Card targetCard)
    {
        Spell original = this.DetermineImpactSpellPrefab(sourceCard);
        if (original != null)
        {
            Spell spell2 = (Spell) UnityEngine.Object.Instantiate(original);
            spell2.SetSource(sourceCard.gameObject);
            spell2.AddTarget(targetCard.gameObject);
            Vector3 position = targetCard.transform.position;
            spell2.SetPosition(position);
            Quaternion orientation = Quaternion.LookRotation(this.m_sourceToTarget);
            spell2.SetOrientation(orientation);
            spell2.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnImpactSpellStateFinished));
            spell2.Activate();
        }
    }

    protected override bool AddPowerSourceAndTargets(PowerTaskList taskList)
    {
        Card card;
        Card card2;
        PowerTaskList.AttackInfo attackInfo = taskList.GetAttackInfo();
        this.m_attackType = this.DetermineAttackType(attackInfo);
        if (this.m_attackType == AttackType.INVALID)
        {
            this.m_prevAttackerCard = null;
            this.m_prevAttackType = AttackType.INVALID;
            return false;
        }
        if (this.m_attackType == AttackType.REGULAR)
        {
            card = attackInfo.m_attacker.GetCard();
            card2 = attackInfo.m_defender.GetCard();
            base.SetSource(card);
            base.AddTarget(card2);
            return true;
        }
        if (this.m_attackType == AttackType.PROPOSED)
        {
            card = attackInfo.m_proposedAttacker.GetCard();
            card2 = attackInfo.m_proposedDefender.GetCard();
            base.SetSource(card);
            base.AddTarget(card2);
            return true;
        }
        if (this.m_attackType == AttackType.CANCELED)
        {
            base.SetSource(this.m_prevAttackerCard);
            return true;
        }
        return false;
    }

    private bool CanPlayWindfuryReminder(Entity entity, Card card)
    {
        if (!entity.HasWindfury())
        {
            return false;
        }
        if (entity.IsExhausted())
        {
            return false;
        }
        if (entity.GetZone() != TAG_ZONE.PLAY)
        {
            return false;
        }
        if (!entity.GetController().IsCurrentPlayer())
        {
            return false;
        }
        if (card.GetActorSpell(SpellType.WINDFURY_BURST) == null)
        {
            return false;
        }
        return true;
    }

    private Vector3 ComputeImpactOffset(Card sourceCard, Vector3 impactPos)
    {
        float num;
        if (object.Equals(this.m_SourceImpactOffset, 0.5f))
        {
            return Vector3.zero;
        }
        Bounds bounds = sourceCard.GetActor().GetMeshRenderer().bounds;
        bounds.center = this.m_sourcePos;
        Ray ray = new Ray(impactPos, bounds.center - impactPos);
        if (!bounds.IntersectRay(ray, out num))
        {
            return Vector3.zero;
        }
        Vector3 vector = ray.origin + ((Vector3) (num * ray.direction));
        Vector3 vector2 = ((Vector3) (2f * bounds.center)) - vector;
        Vector3 vector3 = vector2 - vector;
        Vector3 vector4 = (Vector3) (0.5f * vector3);
        return (vector4 - ((Vector3) (this.m_SourceImpactOffset * vector3)));
    }

    private Vector3 ComputeImpactPos()
    {
        float num = 1f;
        if (this.m_attackType == AttackType.PROPOSED)
        {
            num = 0.5f;
        }
        Vector3 vector = (Vector3) ((num * this.m_ImpactStagingPoint) * this.m_sourceToTarget);
        return (this.m_sourcePos + vector);
    }

    private AttackType DetermineAttackType(PowerTaskList.AttackInfo attackInfo)
    {
        if (attackInfo == null)
        {
            UnityEngine.Debug.LogWarning("AttackSpellController.DetermineAttackType() - INVALID no attack info is present");
            return AttackType.INVALID;
        }
        if ((attackInfo.m_attacker != null) || (attackInfo.m_defender != null))
        {
            if (attackInfo.m_attacker == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("AttackSpellController.DetermineAttackType() - INVALID attacker={0} defender=null", attackInfo.m_attacker));
                return AttackType.INVALID;
            }
            if (attackInfo.m_defender == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("AttackSpellController.DetermineAttackType() - INVALID attacker=null defender={0}", attackInfo.m_defender));
                return AttackType.INVALID;
            }
            return AttackType.REGULAR;
        }
        if ((attackInfo.m_proposedAttacker != null) || (attackInfo.m_proposedDefender != null))
        {
            if (attackInfo.m_proposedAttacker == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("AttackSpellController.DetermineAttackType() - INVALID proposedAttacker={0} proposedDefender=null", attackInfo.m_proposedAttacker));
                return AttackType.INVALID;
            }
            if (attackInfo.m_proposedDefender == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("AttackSpellController.DetermineAttackType() - INVALID proposedAttacker=null proposedDefender={0}", attackInfo.m_proposedDefender));
                return AttackType.INVALID;
            }
            return AttackType.PROPOSED;
        }
        if (this.m_prevAttackType == AttackType.PROPOSED)
        {
            return AttackType.CANCELED;
        }
        return AttackType.INVALID;
    }

    private Spell DetermineImpactSpellPrefab(Card sourceCard)
    {
        if (this.m_ImpactDefs != null)
        {
            int aTK = sourceCard.GetEntity().GetATK();
            for (int i = 0; i < this.m_ImpactDefs.Count; i++)
            {
                AttackImpactDef def = this.m_ImpactDefs[i];
                if (((def.m_MinAttack <= aTK) && (def.m_MaxAttack >= aTK)) && (def.m_SpellPrefab != null))
                {
                    return def.m_SpellPrefab;
                }
            }
        }
        return this.m_DefaultImpactSpellPrefab;
    }

    private void DoTasks(Card sourceCard, Card targetCard)
    {
        List<PowerTask> taskList = base.m_taskList.GetTaskList();
        if ((taskList != null) && (taskList.Count != 0))
        {
            int entityId = sourceCard.GetEntity().GetEntityId();
            int num2 = targetCard.GetEntity().GetEntityId();
            foreach (PowerTask task in taskList)
            {
                Network.PowerHistory power = task.GetPower();
                if (power.Type == Network.PowerHistory.PowType.TAG_CHANGE)
                {
                    Network.HistTagChange change = power as Network.HistTagChange;
                    if ((change.Entity == entityId) || (change.Entity == num2))
                    {
                        switch (((GAME_TAG) change.Tag))
                        {
                            case GAME_TAG.DAMAGE:
                            case GAME_TAG.EXHAUSTED:
                                task.DoTask();
                                break;
                        }
                    }
                }
            }
        }
    }

    private void FinishEverything()
    {
        this.FinishTaskList();
        base.OnFinished();
    }

    private void FinishTaskList()
    {
        this.m_prevAttackerCard = base.GetSource();
        this.m_prevAttackType = this.m_attackType;
        base.OnFinishedTaskList();
    }

    private void LaunchAttack()
    {
        Card source = base.GetSource();
        Entity sourceEntity = source.GetEntity();
        Card target = base.GetTarget();
        bool flag = this.m_attackType == AttackType.PROPOSED;
        if (flag && sourceEntity.IsHero())
        {
            this.m_sourceAttackSpell.ActivateState(SpellStateType.IDLE);
            this.FinishEverything();
        }
        else
        {
            this.m_sourcePos = source.transform.position;
            this.m_sourceToTarget = target.transform.position - this.m_sourcePos;
            Vector3 impactPos = this.ComputeImpactPos();
            source.SetDoNotSort(true);
            this.MoveSourceToTarget(source, sourceEntity, impactPos);
            if (sourceEntity.IsHero())
            {
                this.OrientSourceHeroToTarget(source);
            }
            if (!flag)
            {
                target.SetDoNotSort(true);
                this.MoveTargetToSource(target, sourceEntity, impactPos);
            }
        }
    }

    private void MoveSourceHeroBack(Card sourceCard)
    {
        object[] args = new object[] { "position", this.m_sourcePos, "time", this.m_HeroInfo.m_MoveBackDuration, "easetype", this.m_HeroInfo.m_MoveBackEaseType, "oncomplete", "OnHeroMoveBackFinished", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(sourceCard.gameObject, hashtable);
    }

    private void MoveSourceToTarget(Card sourceCard, Entity sourceEntity, Vector3 impactPos)
    {
        Vector3 vector = this.ComputeImpactOffset(sourceCard, impactPos);
        Vector3 vector2 = impactPos + vector;
        float moveToTargetDuration = 0f;
        iTween.EaseType linear = iTween.EaseType.linear;
        if (sourceEntity.IsHero())
        {
            moveToTargetDuration = this.m_HeroInfo.m_MoveToTargetDuration;
            linear = this.m_HeroInfo.m_MoveToTargetEaseType;
        }
        else
        {
            moveToTargetDuration = this.m_AllyInfo.m_MoveToTargetDuration;
            linear = this.m_AllyInfo.m_MoveToTargetEaseType;
        }
        object[] args = new object[] { "position", vector2, "time", moveToTargetDuration, "easetype", linear, "oncomplete", "OnMoveToTargetFinished", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(sourceCard.gameObject, hashtable);
    }

    private void MoveTargetToSource(Card targetCard, Entity sourceEntity, Vector3 impactPos)
    {
        float moveToTargetDuration = 0f;
        iTween.EaseType linear = iTween.EaseType.linear;
        if (sourceEntity.IsHero())
        {
            moveToTargetDuration = this.m_HeroInfo.m_MoveToTargetDuration;
            linear = this.m_HeroInfo.m_MoveToTargetEaseType;
        }
        else
        {
            moveToTargetDuration = this.m_AllyInfo.m_MoveToTargetDuration;
            linear = this.m_AllyInfo.m_MoveToTargetEaseType;
        }
        object[] args = new object[] { "position", impactPos, "time", moveToTargetDuration, "easetype", linear };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(targetCard.gameObject, hashtable);
    }

    private void OnHeroMoveBackFinished()
    {
        Card source = base.GetSource();
        Entity entity = source.GetEntity();
        source.SetDoNotSort(false);
        source.EnableAttacking(false);
        if (entity.GetController().IsLocal() || (this.m_sourceAttackSpell.GetActiveState() == SpellStateType.NONE))
        {
            this.PlayWindfuryReminderIfPossible(entity, source);
            this.FinishEverything();
        }
        else
        {
            this.m_sourceAttackSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnHeroSourceAttackStateFinished));
        }
    }

    private void OnHeroSourceAttackStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            spell.RemoveStateFinishedCallback(new Spell.StateFinishedCallback(this.OnHeroSourceAttackStateFinished));
            Card source = base.GetSource();
            Entity entity = source.GetEntity();
            this.PlayWindfuryReminderIfPossible(entity, source);
            this.FinishEverything();
        }
    }

    private void OnImpactSpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            UnityEngine.Object.Destroy(spell.gameObject);
        }
    }

    private void OnMinionSourceAttackStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            spell.RemoveStateFinishedCallback(new Spell.StateFinishedCallback(this.OnMinionSourceAttackStateFinished));
            Card source = base.GetSource();
            Entity entity = source.GetEntity();
            source.EnableAttacking(false);
            if (!this.CanPlayWindfuryReminder(entity, source))
            {
                this.FinishEverything();
            }
            else
            {
                this.FinishTaskList();
                base.StartCoroutine(this.WaitThenPlayWindfuryReminder(entity, source));
            }
        }
    }

    private void OnMoveToTargetFinished()
    {
        Card source = base.GetSource();
        Entity entity = source.GetEntity();
        Card target = base.GetTarget();
        bool flag = this.m_attackType == AttackType.PROPOSED;
        this.DoTasks(source, target);
        if (!flag)
        {
            this.ActivateImpactEffects(source, target);
        }
        if (entity.IsHero())
        {
            this.MoveSourceHeroBack(source);
            this.OrientSourceHeroBack(source);
            target.SetDoNotSort(false);
            target.GetZone().UpdateLayout();
        }
        else if (flag)
        {
            this.FinishEverything();
        }
        else
        {
            source.SetDoNotSort(false);
            source.GetZone().UpdateLayout();
            target.SetDoNotSort(false);
            target.GetZone().UpdateLayout();
            this.m_sourceAttackSpell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnMinionSourceAttackStateFinished));
            this.m_sourceAttackSpell.ActivateState(SpellStateType.DEATH);
        }
    }

    protected override void OnProcessTaskList()
    {
        Card source = base.GetSource();
        Entity entity = source.GetEntity();
        Zone zone = source.GetZone();
        bool flag = zone.m_Side == Player.Side.FRIENDLY;
        if (flag)
        {
            this.m_sourceAttackSpell = source.GetActorSpell(SpellType.FRIENDLY_ATTACK);
        }
        else
        {
            this.m_sourceAttackSpell = source.GetActorSpell(SpellType.OPPONENT_ATTACK);
        }
        if (this.m_attackType == AttackType.CANCELED)
        {
            if (this.m_sourceAttackSpell != null)
            {
                if (entity.IsHero())
                {
                    this.m_sourceAttackSpell.ActivateState(SpellStateType.CANCEL);
                }
                else
                {
                    this.m_sourceAttackSpell.ActivateState(SpellStateType.DEATH);
                }
            }
            source.SetDoNotSort(false);
            zone.UpdateLayout();
            source.EnableAttacking(false);
            this.FinishEverything();
        }
        else
        {
            source.EnableAttacking(true);
            this.m_sourceAttackSpell.AddStateStartedCallback(new Spell.StateStartedCallback(this.OnSourceAttackStateStarted));
            if (flag)
            {
                if (this.m_sourceAttackSpell.GetActiveState() != SpellStateType.IDLE)
                {
                    this.m_sourceAttackSpell.ActivateState(SpellStateType.BIRTH);
                }
                else
                {
                    this.m_sourceAttackSpell.ActivateState(SpellStateType.ACTION);
                }
            }
            else
            {
                this.m_sourceAttackSpell.ActivateState(SpellStateType.BIRTH);
            }
        }
    }

    private void OnSourceAttackStateStarted(Spell spell, SpellStateType prevStateType, object userData)
    {
        switch (spell.GetActiveState())
        {
            case SpellStateType.IDLE:
                spell.ActivateState(SpellStateType.ACTION);
                break;

            case SpellStateType.ACTION:
                spell.RemoveStateStartedCallback(new Spell.StateStartedCallback(this.OnSourceAttackStateStarted));
                this.LaunchAttack();
                break;
        }
    }

    private void OrientSourceHeroBack(Card sourceCard)
    {
        Quaternion quaternion = Quaternion.LookRotation(this.m_sourceFacing);
        object[] args = new object[] { "rotation", quaternion.eulerAngles, "time", this.m_HeroInfo.m_OrientBackDuration, "easetype", this.m_HeroInfo.m_OrientBackEaseType };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(sourceCard.gameObject, hashtable);
    }

    private void OrientSourceHeroToTarget(Card sourceCard)
    {
        Quaternion quaternion;
        this.m_sourceFacing = sourceCard.transform.forward;
        if (this.m_sourceAttackSpell.GetSpellType() == SpellType.OPPONENT_ATTACK)
        {
            quaternion = Quaternion.LookRotation(-this.m_sourceToTarget);
        }
        else
        {
            quaternion = Quaternion.LookRotation(this.m_sourceToTarget);
        }
        object[] args = new object[] { "rotation", quaternion.eulerAngles, "time", this.m_HeroInfo.m_OrientToTargetDuration, "easetype", this.m_HeroInfo.m_OrientToTargetEaseType };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(sourceCard.gameObject, hashtable);
    }

    private void PlayWindfuryReminderIfPossible(Entity entity, Card card)
    {
        if (this.CanPlayWindfuryReminder(entity, card))
        {
            card.ActivateActorSpell(SpellType.WINDFURY_BURST);
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitThenPlayWindfuryReminder(Entity entity, Card card)
    {
        return new <WaitThenPlayWindfuryReminder>c__IteratorAB { entity = entity, card = card, <$>entity = entity, <$>card = card, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenPlayWindfuryReminder>c__IteratorAB : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <$>card;
        internal Entity <$>entity;
        internal AttackSpellController <>f__this;
        internal Card card;
        internal Entity entity;

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
                    this.$current = new WaitForSeconds(1.2f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.PlayWindfuryReminderIfPossible(this.entity, this.card);
                    this.<>f__this.OnFinished();
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

    private enum AttackType
    {
        INVALID,
        REGULAR,
        PROPOSED,
        CANCELED
    }
}

