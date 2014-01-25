namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Easing Animation - Float"), ActionCategory(ActionCategory.AnimateVariables)]
    public class EaseFloat : EaseFsmAction
    {
        private bool finishInNextStep;
        [UIHint(UIHint.Variable)]
        public FsmFloat floatVariable;
        [RequiredField]
        public FsmFloat fromValue;
        [RequiredField]
        public FsmFloat toValue;

        public override void OnEnter()
        {
            base.OnEnter();
            base.fromFloats = new float[] { this.fromValue.Value };
            base.toFloats = new float[] { this.toValue.Value };
            base.resultFloats = new float[1];
            this.finishInNextStep = false;
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!this.floatVariable.IsNone && base.isRunning)
            {
                this.floatVariable.Value = base.resultFloats[0];
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
                if (!this.floatVariable.IsNone)
                {
                    this.floatVariable.Value = !base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value : this.fromValue.Value) : this.toValue.Value;
                }
                this.finishInNextStep = true;
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.floatVariable = null;
            this.fromValue = null;
            this.toValue = null;
            this.finishInNextStep = false;
        }
    }
}

