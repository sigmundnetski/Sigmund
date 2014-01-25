namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("AnimateVariables"), Tooltip("Animates the value of a Rect Variable FROM-TO with assistance of Deformation Curves.")]
    public class CurveRect : CurveFsmAction
    {
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to otherwise linear move between fromValue.height and toValue.height.")]
        public CurveFsmAction.Calculation calculationH;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to otherwise linear move between fromValue.width and toValue.width.")]
        public CurveFsmAction.Calculation calculationW;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to otherwise linear move between fromValue.x and toValue.x.")]
        public CurveFsmAction.Calculation calculationX;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to otherwise linear move between fromValue.y and toValue.y.")]
        public CurveFsmAction.Calculation calculationY;
        [RequiredField]
        public FsmAnimationCurve curveH;
        [RequiredField]
        public FsmAnimationCurve curveW;
        [RequiredField]
        public FsmAnimationCurve curveX;
        [RequiredField]
        public FsmAnimationCurve curveY;
        private bool finishInNextStep;
        [RequiredField]
        public FsmRect fromValue;
        private Rect rct;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmRect rectVariable;
        [RequiredField]
        public FsmRect toValue;

        public override void OnEnter()
        {
            base.OnEnter();
            this.finishInNextStep = false;
            base.resultFloats = new float[4];
            base.fromFloats = new float[] { !this.fromValue.IsNone ? this.fromValue.Value.x : 0f, !this.fromValue.IsNone ? this.fromValue.Value.y : 0f, !this.fromValue.IsNone ? this.fromValue.Value.width : 0f, !this.fromValue.IsNone ? this.fromValue.Value.height : 0f };
            base.toFloats = new float[] { !this.toValue.IsNone ? this.toValue.Value.x : 0f, !this.toValue.IsNone ? this.toValue.Value.y : 0f, !this.toValue.IsNone ? this.toValue.Value.width : 0f, !this.toValue.IsNone ? this.toValue.Value.height : 0f };
            base.curves = new AnimationCurve[] { this.curveX.curve, this.curveY.curve, this.curveW.curve, this.curveH.curve };
            base.calculations = new CurveFsmAction.Calculation[4];
            base.calculations[0] = this.calculationX;
            base.calculations[1] = this.calculationY;
            base.calculations[2] = this.calculationW;
            base.calculations[2] = this.calculationH;
            base.Init();
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!this.rectVariable.IsNone && base.isRunning)
            {
                this.rct = new Rect(base.resultFloats[0], base.resultFloats[1], base.resultFloats[2], base.resultFloats[3]);
                this.rectVariable.Value = this.rct;
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
                if (!this.rectVariable.IsNone)
                {
                    this.rct = new Rect(base.resultFloats[0], base.resultFloats[1], base.resultFloats[2], base.resultFloats[3]);
                    this.rectVariable.Value = this.rct;
                }
                this.finishInNextStep = true;
            }
        }

        public override void Reset()
        {
            base.Reset();
            FsmRect rect = new FsmRect {
                UseVariable = true
            };
            this.rectVariable = rect;
            rect = new FsmRect {
                UseVariable = true
            };
            this.toValue = rect;
            rect = new FsmRect {
                UseVariable = true
            };
            this.fromValue = rect;
        }
    }
}

