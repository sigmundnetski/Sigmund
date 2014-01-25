namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Invokes a Method in a Behaviour attached to a Game Object. See Unity InvokeMethod docs."), ActionCategory(ActionCategory.ScriptControl)]
    public class InvokeMethod : FsmStateAction
    {
        [UIHint(UIHint.Script), RequiredField]
        public FsmString behaviour;
        public FsmBool cancelOnExit;
        private MonoBehaviour component;
        [HasFloatSlider(0f, 10f)]
        public FsmFloat delay;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [UIHint(UIHint.Method), RequiredField]
        public FsmString methodName;
        [HasFloatSlider(0f, 10f)]
        public FsmFloat repeatDelay;
        public FsmBool repeating;

        private void DoInvokeMethod(GameObject go)
        {
            if (go != null)
            {
                this.component = go.GetComponent(this.behaviour.Value) as MonoBehaviour;
                if (this.component == null)
                {
                    this.LogWarning("InvokeMethod: " + go.name + " missing behaviour: " + this.behaviour.Value);
                }
                else if (this.repeating.Value)
                {
                    this.component.InvokeRepeating(this.methodName.Value, this.delay.Value, this.repeatDelay.Value);
                }
                else
                {
                    this.component.Invoke(this.methodName.Value, this.delay.Value);
                }
            }
        }

        public override void OnEnter()
        {
            this.DoInvokeMethod(base.Fsm.GetOwnerDefaultTarget(this.gameObject));
            base.Finish();
        }

        public override void OnExit()
        {
            if ((this.component != null) && this.cancelOnExit.Value)
            {
                this.component.CancelInvoke(this.methodName.Value);
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.behaviour = null;
            this.methodName = string.Empty;
            this.delay = null;
            this.repeating = 0;
            this.repeatDelay = 1f;
            this.cancelOnExit = 0;
        }
    }
}

