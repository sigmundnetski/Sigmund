namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.AnimateVariables), Tooltip("Easing Animation - Color")]
    public class EaseColor : EaseFsmAction
    {
        [UIHint(UIHint.Variable)]
        public FsmColor colorVariable;
        private bool finishInNextStep;
        [RequiredField]
        public FsmColor fromValue;
        [RequiredField]
        public FsmColor toValue;

        public override void OnEnter()
        {
            base.OnEnter();
            base.fromFloats = new float[] { this.fromValue.Value.r, this.fromValue.Value.g, this.fromValue.Value.b, this.fromValue.Value.a };
            base.toFloats = new float[] { this.toValue.Value.r, this.toValue.Value.g, this.toValue.Value.b, this.toValue.Value.a };
            base.resultFloats = new float[4];
            this.finishInNextStep = false;
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!this.colorVariable.IsNone && base.isRunning)
            {
                this.colorVariable.Value = new Color(base.resultFloats[0], base.resultFloats[1], base.resultFloats[2], base.resultFloats[3]);
            }
            if (this.finishInNextStep)
            {
                base.Finish();
                if (base.finishEvent != null)
                {
                    base.Fsm.Event(base.finishEvent);
                }
            }
            if (base.finishAction && !this.finishInNextStep)
            {
                if (!this.colorVariable.IsNone)
                {
                    this.colorVariable.Value = new Color(!base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value.r : this.fromValue.Value.r) : this.toValue.Value.r, !base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value.g : this.fromValue.Value.g) : this.toValue.Value.g, !base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value.b : this.fromValue.Value.b) : this.toValue.Value.b, !base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value.a : this.fromValue.Value.a) : this.toValue.Value.a);
                }
                this.finishInNextStep = true;
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.colorVariable = null;
            this.fromValue = null;
            this.toValue = null;
            this.finishInNextStep = false;
        }
    }
}

