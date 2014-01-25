namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Effects), Tooltip("Simulates a Particle System at a variable speed.")]
    public class ParticleSimulateAction : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault m_GameObject;
        [Tooltip("Run this action on all child objects' Particle Systems.")]
        public FsmBool m_IncludeChildren;
        [Tooltip("Time at which this particle displays. This leave the system in a paused state.")]
        public FsmFloat m_TimeToFastForwardTo;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget != null)
            {
                ParticleSystem component = ownerDefaultTarget.GetComponent<ParticleSystem>();
                if (component == null)
                {
                    Debug.LogWarning(string.Format("ParticleSimulateAction.OnEnter() - GameObject {0} has no ParticleSystem component", ownerDefaultTarget));
                }
                else
                {
                    component.Simulate(this.m_TimeToFastForwardTo.Value, this.m_IncludeChildren.Value);
                }
            }
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            this.m_TimeToFastForwardTo = 0f;
            this.m_IncludeChildren = 0;
        }
    }
}

