namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.AnimateVariables), Tooltip("Animates the value of a Float Variable using an Animation Curve.")]
    public class AnimateFloatV2 : AnimateFsmAction
    {
        [RequiredField]
        public FsmAnimationCurve animCurve;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to floatVariable")]
        public AnimateFsmAction.Calculation calculation;
        private bool finishInNextStep;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmFloat floatVariable;

        public override void OnEnter()
        {
            base.OnEnter();
            this.finishInNextStep = false;
            base.resultFloats = new float[1];
            base.fromFloats = new float[] { !this.floatVariable.IsNone ? this.floatVariable.Value : 0f };
            base.calculations = new AnimateFsmAction.Calculation[] { this.calculation };
            base.curves = new AnimationCurve[] { this.animCurve.curve };
            base.Init();
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!this.floatVariable.IsNone && base.isRunning)
            {
                this.floatVariable.Value = base.resultFloats[0];
            }
            if (this.finishInNextStep && !base.looping)
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
                    this.floatVariable.Value = base.resultFloats[0];
                }
                this.finishInNextStep = true;
            }
        }

        public override void Reset()
        {
            base.Reset();
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.floatVariable = num;
        }
    }
}

