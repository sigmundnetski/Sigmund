namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using UnityEngine;

    [Tooltip("Emit particles in a Particle System immediately.\nIf the particle system is not playing it will start playing."), ActionCategory(ActionCategory.Effects)]
    public class ParticleEmitAction : FsmStateAction
    {
        [Tooltip("The number of particles to emit.")]
        public FsmInt m_Count;
        [RequiredField]
        public FsmOwnerDefault m_GameObject;
        [Tooltip("Run this action on all child objects' Particle Systems.")]
        public FsmBool m_IncludeChildren;

        private void EmitParticles(GameObject go)
        {
            ParticleSystem component = go.GetComponent<ParticleSystem>();
            if (component == null)
            {
                Debug.LogWarning(string.Format("ParticleEmitAction.OnEnter() - GameObject {0} has no ParticleSystem component", go));
            }
            else
            {
                component.Emit(this.m_Count.Value);
            }
        }

        private void EmitParticlesRecurse(GameObject go)
        {
            ParticleSystem component = go.GetComponent<ParticleSystem>();
            if (component != null)
            {
                component.Emit(this.m_Count.Value);
            }
            IEnumerator enumerator = go.transform.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Transform current = (Transform) enumerator.Current;
                    this.EmitParticlesRecurse(current.gameObject);
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                }
                disposable.Dispose();
            }
        }

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget == null)
            {
                base.Finish();
            }
            else
            {
                if (this.m_IncludeChildren.Value)
                {
                    this.EmitParticlesRecurse(ownerDefaultTarget);
                }
                else
                {
                    this.EmitParticles(ownerDefaultTarget);
                }
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            this.m_Count = 10;
        }
    }
}

