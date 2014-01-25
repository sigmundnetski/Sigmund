namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Send an event based on an Actor's Card's elite flag."), ActionCategory("Pegasus")]
    public class ActorEliteEventAction : ActorAction
    {
        public FsmOwnerDefault m_ActorObject;
        public FsmEvent m_EliteEvent;
        public FsmEvent m_NonEliteEvent;

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
                if (base.m_actor.IsElite())
                {
                    base.Fsm.Event(this.m_EliteEvent);
                }
                else
                {
                    base.Fsm.Event(this.m_NonEliteEvent);
                }
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.m_ActorObject = null;
            this.m_EliteEvent = null;
            this.m_NonEliteEvent = null;
        }
    }
}

