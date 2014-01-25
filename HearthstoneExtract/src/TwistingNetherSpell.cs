using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TwistingNetherSpell : SuperSpell
{
    [CompilerGenerated]
    private static Action<object> <>f__am$cache7;
    [CompilerGenerated]
    private static Action<object> <>f__am$cache8;
    private static readonly Vector3 DEAD_SCALE = new Vector3(0.01f, 0.01f, 0.01f);
    public TwistingNetherDrainInfo m_DrainInfo;
    public float m_FinishTime;
    public TwistingNetherFloatInfo m_FloatInfo;
    public TwistingNetherLiftInfo m_LiftInfo;
    public TwistingNetherSqueezeInfo m_SqueezeInfo;
    private List<Victim> m_victims = new List<Victim>();

    private void Begin()
    {
        base.m_effectsPendingFinish++;
        if (<>f__am$cache7 == null)
        {
            <>f__am$cache7 = delegate (object amount) {
            };
        }
        Action<object> action = <>f__am$cache7;
        object[] args = new object[] { "from", 0f, "to", 1f, "time", this.m_FinishTime, "onupdate", action, "oncomplete", "OnFinishTimeFinished", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(base.gameObject, hashtable);
        this.Setup();
        this.Lift();
    }

    private bool CanFinish()
    {
        foreach (Victim victim in this.m_victims)
        {
            if (victim.m_state != VictimState.DEAD)
            {
                return false;
            }
        }
        return true;
    }

    protected override void CleanUp()
    {
        base.CleanUp();
        this.m_victims.Clear();
    }

    private void Drain(Victim victim)
    {
        victim.m_state = VictimState.LIFTING;
        float num = UnityEngine.Random.Range(this.m_DrainInfo.m_DelayMin, this.m_DrainInfo.m_DelayMax);
        float num2 = UnityEngine.Random.Range(this.m_DrainInfo.m_DurationMin, this.m_DrainInfo.m_DurationMax);
        object[] args = new object[] { "position", base.transform.position, "delay", num, "time", num2, "easeType", this.m_DrainInfo.m_EaseType, "oncomplete", "OnDrainFinished", "oncompletetarget", base.gameObject, "oncompleteparams", victim };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(victim.m_card.gameObject, hashtable);
        float num3 = UnityEngine.Random.Range(this.m_SqueezeInfo.m_DelayMin, this.m_SqueezeInfo.m_DelayMax);
        float num4 = UnityEngine.Random.Range(this.m_SqueezeInfo.m_DurationMin, this.m_SqueezeInfo.m_DurationMax);
        object[] objArray2 = new object[] { "scale", DEAD_SCALE, "delay", num3, "time", num4, "easeType", this.m_SqueezeInfo.m_EaseType };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.ScaleTo(victim.m_card.gameObject, hashtable2);
    }

    private void Float(Victim victim)
    {
        victim.m_state = VictimState.FLOATING;
        float num = UnityEngine.Random.Range(this.m_FloatInfo.m_DurationMin, this.m_FloatInfo.m_DurationMax);
        if (<>f__am$cache8 == null)
        {
            <>f__am$cache8 = delegate (object amount) {
            };
        }
        Action<object> action = <>f__am$cache8;
        object[] args = new object[] { "from", 0f, "to", 1f, "time", num, "onupdate", action, "oncomplete", "OnFloatFinished", "oncompletetarget", base.gameObject, "oncompleteparams", victim };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(victim.m_card.gameObject, hashtable);
    }

    protected override Card GetTargetCardFromPowerTask(PowerTask task)
    {
        Network.PowerHistory power = task.GetPower();
        if (power.Type != Network.PowerHistory.PowType.TAG_CHANGE)
        {
            return null;
        }
        Network.HistTagChange change = power as Network.HistTagChange;
        if (Gameplay.Get() != null)
        {
            if (change.Tag != 360)
            {
                return null;
            }
            if (change.Value != 1)
            {
                return null;
            }
        }
        Entity entity = GameState.Get().GetEntity(change.Entity);
        if (entity == null)
        {
            Debug.LogWarning(string.Format("{0}.GetTargetCardFromPowerTask() - WARNING trying to target entity with id {1} but there is no entity with that id", this, change.Entity));
            return null;
        }
        return entity.GetCard();
    }

    private void Lift()
    {
        foreach (Victim victim in this.m_victims)
        {
            victim.m_state = VictimState.LIFTING;
            Vector3 vector = TransformUtil.RandomVector3(this.m_LiftInfo.m_OffsetMin, this.m_LiftInfo.m_OffsetMax);
            Vector3 vector2 = victim.m_card.transform.position + vector;
            float num = UnityEngine.Random.Range(this.m_LiftInfo.m_DelayMin, this.m_LiftInfo.m_DelayMax);
            float num2 = UnityEngine.Random.Range(this.m_LiftInfo.m_DurationMin, this.m_LiftInfo.m_DurationMax);
            object[] args = new object[] { "position", vector2, "delay", num, "time", num2, "easeType", this.m_LiftInfo.m_EaseType, "oncomplete", "OnLiftFinished", "oncompletetarget", base.gameObject, "oncompleteparams", victim };
            Hashtable hashtable = iTween.Hash(args);
            Vector3 vector3 = new Vector3(UnityEngine.Random.Range(this.m_LiftInfo.m_RotationMin, this.m_LiftInfo.m_RotationMax), UnityEngine.Random.Range(this.m_LiftInfo.m_RotationMin, this.m_LiftInfo.m_RotationMax), UnityEngine.Random.Range(this.m_LiftInfo.m_RotationMin, this.m_LiftInfo.m_RotationMax));
            float num3 = UnityEngine.Random.Range(this.m_LiftInfo.m_RotDelayMin, this.m_LiftInfo.m_RotDelayMax);
            float num4 = UnityEngine.Random.Range(this.m_LiftInfo.m_RotDurationMin, this.m_LiftInfo.m_RotDurationMax);
            object[] objArray2 = new object[] { "rotation", vector3, "delay", num3, "time", num4, "easeType", this.m_LiftInfo.m_EaseType };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.MoveTo(victim.m_card.gameObject, hashtable);
            iTween.RotateTo(victim.m_card.gameObject, hashtable2);
        }
    }

    protected override void OnAction(SpellStateType prevStateType)
    {
        base.OnAction(prevStateType);
        if (!base.IsFinished())
        {
            this.Begin();
            if (this.CanFinish())
            {
                base.m_effectsPendingFinish--;
                base.FinishIfPossible();
            }
        }
    }

    private void OnDrainFinished(Victim victim)
    {
        victim.m_state = VictimState.DEAD;
        victim.m_card.SetDoNotSort(false);
    }

    private void OnFinishTimeFinished()
    {
        base.m_effectsPendingFinish--;
        base.FinishIfPossible();
    }

    private void OnFloatFinished(Victim victim)
    {
        this.Drain(victim);
    }

    private void OnLiftFinished(Victim victim)
    {
        this.Float(victim);
    }

    private void Setup()
    {
        foreach (GameObject obj2 in base.GetTargets())
        {
            Card component = obj2.GetComponent<Card>();
            component.SetDoNotSort(true);
            Victim item = new Victim {
                m_state = VictimState.NONE,
                m_card = component
            };
            this.m_victims.Add(item);
        }
    }

    private class Victim
    {
        public Card m_card;
        public TwistingNetherSpell.VictimState m_state;
    }

    private enum VictimState
    {
        NONE,
        LIFTING,
        FLOATING,
        DRAINING,
        DEAD
    }
}

