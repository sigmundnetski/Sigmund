namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Send an event based on an Actor's Card's rarity."), ActionCategory("Pegasus")]
    public class ActorRarityEventAction : ActorAction
    {
        public FsmOwnerDefault m_ActorObject;
        public FsmEvent m_CommonEvent;
        public FsmEvent m_EpicEvent;
        public FsmEvent m_FreeEvent;
        public FsmEvent m_LegendaryEvent;
        public FsmEvent m_RareEvent;

        protected override GameObject GetActorOwner()
        {
            return base.Fsm.GetOwnerDefaultTarget(this.m_ActorObject);
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (base.m_actor == null)
            {
                base.Finish();
            }
            else
            {
                TAG_RARITY rarity = base.m_actor.GetRarity();
                switch (rarity)
                {
                    case TAG_RARITY.COMMON:
                        base.Fsm.Event(this.m_CommonEvent);
                        break;

                    case TAG_RARITY.FREE:
                        base.Fsm.Event(this.m_FreeEvent);
                        break;

                    case TAG_RARITY.RARE:
                        base.Fsm.Event(this.m_RareEvent);
                        break;

                    case TAG_RARITY.EPIC:
                        base.Fsm.Event(this.m_EpicEvent);
                        break;

                    case TAG_RARITY.LEGENDARY:
                        base.Fsm.Event(this.m_LegendaryEvent);
                        break;

                    default:
                        Debug.LogError(string.Format("ActorRarityEventAction.OnEnter() - unknown rarity {0} on actor {1}", rarity, base.m_actor));
                        break;
                }
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.m_ActorObject = null;
            this.m_FreeEvent = null;
            this.m_CommonEvent = null;
            this.m_RareEvent = null;
            this.m_EpicEvent = null;
            this.m_LegendaryEvent = null;
        }
    }
}

