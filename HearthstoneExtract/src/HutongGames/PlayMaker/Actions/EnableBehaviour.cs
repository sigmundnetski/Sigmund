namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.ScriptControl), Tooltip("Enables/Disables a Behaviour on a GameObject. Optionally reset the Behaviour on exit - useful if you only want the Behaviour to be active while this state is active.")]
    public class EnableBehaviour : FsmStateAction
    {
        [Tooltip("The name of the Behaviour to enable/disable."), UIHint(UIHint.Behaviour)]
        public FsmString behaviour;
        [Tooltip("Optionally drag a component directly into this field (behavior name will be ignored).")]
        public Component component;
        private Behaviour componentTarget;
        [RequiredField, Tooltip("Set to True to enable, False to disable.")]
        public FsmBool enable;
        [Tooltip("The GameObject that owns the Behaviour."), RequiredField]
        public FsmOwnerDefault gameObject;
        public FsmBool resetOnExit;

        private void DoEnableBehaviour(GameObject go)
        {
            if (go != null)
            {
                if (this.component != null)
                {
                    this.componentTarget = this.component as Behaviour;
                }
                else
                {
                    this.componentTarget = go.GetComponent(this.behaviour.Value) as Behaviour;
                }
                if (this.componentTarget == null)
                {
                    this.LogWarning(" " + go.name + " missing behaviour: " + this.behaviour.Value);
                }
                else
                {
                    this.componentTarget.enabled = this.enable.Value;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoEnableBehaviour(base.Fsm.GetOwnerDefaultTarget(this.gameObject));
            base.Finish();
        }

        public override void OnExit()
        {
            if ((this.componentTarget != null) && this.resetOnExit.Value)
            {
                this.componentTarget.enabled = !this.enable.Value;
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.behaviour = null;
            this.component = null;
            this.enable = 1;
            this.resetOnExit = 1;
        }
    }
}

