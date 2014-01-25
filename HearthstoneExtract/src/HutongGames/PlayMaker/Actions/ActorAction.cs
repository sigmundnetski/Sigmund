namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("INTERNAL USE ONLY. Do not put this on your FSMs."), ActionCategory("Pegasus")]
    public abstract class ActorAction : FsmStateAction
    {
        protected Actor m_actor;

        protected ActorAction()
        {
        }

        public Actor GetActor()
        {
            if (this.m_actor == null)
            {
                GameObject actorOwner = this.GetActorOwner();
                if (actorOwner != null)
                {
                    this.m_actor = SceneUtils.FindComponentInThisOrParents<Actor>(actorOwner);
                }
            }
            return this.m_actor;
        }

        protected abstract GameObject GetActorOwner();
        public override void OnEnter()
        {
            this.GetActor();
            if (this.m_actor == null)
            {
                Debug.LogError(string.Format("{0}.OnEnter() - FAILED to find Actor component on Owner \"{1}\"", this, base.Owner));
            }
        }

        public override void Reset()
        {
        }
    }
}

