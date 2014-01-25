namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.AnimateVariables), Tooltip("Animates the value of a Color Variable FROM-TO with assistance of Deformation Curves.")]
    public class CurveColor : CurveFsmAction
    {
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to otherwise linear move between fromValue.Alpha and toValue.Alpha.")]
        public CurveFsmAction.Calculation calculationA;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to otherwise linear move between fromValue.Blue and toValue.Blue.")]
        public CurveFsmAction.Calculation calculationB;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to otherwise linear move between fromValue.Green and toValue.Green.")]
        public CurveFsmAction.Calculation calculationG;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to otherwise linear move between fromValue.Red and toValue.Rec.")]
        public CurveFsmAction.Calculation calculationR;
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
        [RequiredField]
        public FsmColor fromValue;
        [RequiredField]
        public FsmColor toValue;

        public override void OnEnter()
        {
            base.OnEnter();
            this.finishInNextStep = false;
            base.resultFloats = new float[4];
            base.fromFloats = new float[] { !this.fromValue.IsNone ? this.fromValue.Value.r : 0f, !this.fromValue.IsNone ? this.fromValue.Value.g : 0f, !this.fromValue.IsNone ? this.fromValue.Value.b : 0f, !this.fromValue.IsNone ? this.fromValue.Value.a : 0f };
            base.toFloats = new float[] { !this.toValue.IsNone ? this.toValue.Value.r : 0f, !this.toValue.IsNone ? this.toValue.Value.g : 0f, !this.toValue.IsNone ? this.toValue.Value.b : 0f, !this.toValue.IsNone ? this.toValue.Value.a : 0f };
            base.curves = new AnimationCurve[] { this.curveR.curve, this.curveG.curve, this.curveB.curve, this.curveA.curve };
            base.calculations = new CurveFsmAction.Calculation[4];
            base.calculations[0] = this.calculationR;
            base.calculations[1] = this.calculationG;
            base.calculations[2] = this.calculationB;
            base.calculations[2] = this.calculationA;
            base.Init();
        }

        public override void OnExit()
        {
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
            color = new FsmColor {
                UseVariable = true
            };
            this.toValue = color;
            color = new FsmColor {
                UseVariable = true
            };
            this.fromValue = color;
        }
    }
}

