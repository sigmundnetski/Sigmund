namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.AnimateVariables), Tooltip("Animates the value of a Color Variable using an Animation Curve.")]
    public class AnimateColor : AnimateFsmAction
    {
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to colorVariable.a.")]
        public AnimateFsmAction.Calculation calculationA;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to colorVariable.b.")]
        public AnimateFsmAction.Calculation calculationB;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to colorVariable.g.")]
        public AnimateFsmAction.Calculation calculationG;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to colorVariable.r.")]
        public AnimateFsmAction.Calculation calculationR;
        private Color clr;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmColor colorVariable;
        [RequiredField]
        public FsmAnimationCurve curveA;
        [RequiredField]
        public FsmAnimationCurve curveB;
        [RequiredField]
        public FsmAnimationCurve curveG;
        [RequiredField]
        public FsmAnimationCurve curveR;
        private bool finishInNextStep;

        public override void OnEnter()
        {
            base.OnEnter();
            this.finishInNextStep = false;
            base.resultFloats = new float[4];
            base.fromFloats = new float[] { !this.colorVariable.IsNone ? this.colorVariable.Value.r : 0f, !this.colorVariable.IsNone ? this.colorVariable.Value.g : 0f, !this.colorVariable.IsNone ? this.colorVariable.Value.b : 0f, !this.colorVariable.IsNone ? this.colorVariable.Value.a : 0f };
            base.curves = new AnimationCurve[] { this.curveR.curve, this.curveG.curve, this.curveB.curve, this.curveA.curve };
            base.calculations = new AnimateFsmAction.Calculation[] { this.calculationR, this.calculationG, this.calculationB, this.calculationA };
            base.Init();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!this.colorVariable.IsNone && base.isRunning)
            {
                this.clr = new Color(base.resultFloats[0], base.resultFloats[1], base.resultFloats[2], base.resultFloats[3]);
                this.colorVariable.Value = this.clr;
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
                if (!this.colorVariable.IsNone)
                {
                    this.clr = new Color(base.resultFloats[0], base.resultFloats[1], base.resultFloats[2], base.resultFloats[3]);
                    this.colorVariable.Value = this.clr;
                }
                this.finishInNextStep = true;
            }
        }

        public override void Reset()
        {
            base.Reset();
            FsmColor color = new FsmColor {
                UseVariable = true
            };
            this.colorVariable = color;
        }
    }
}

