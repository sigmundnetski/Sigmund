namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("AnimateVariables"), Tooltip("Animates the value of a Rect Variable using an Animation Curve.")]
    public class AnimateRect : AnimateFsmAction
    {
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to rectVariable.height.")]
        public AnimateFsmAction.Calculation calculationH;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to rectVariable.width.")]
        public AnimateFsmAction.Calculation calculationW;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to rectVariable.x.")]
        public AnimateFsmAction.Calculation calculationX;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to rectVariable.y.")]
        public AnimateFsmAction.Calculation calculationY;
        [RequiredField]
        public FsmAnimationCurve curveH;
        [RequiredField]
        public FsmAnimationCurve curveW;
        [RequiredField]
        public FsmAnimationCurve curveX;
        [RequiredField]
        public FsmAnimationCurve curveY;
        private bool finishInNextStep;
        private Rect rct;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmRect rectVariable;

        public override void OnEnter()
        {
            base.OnEnter();
            this.finishInNextStep = false;
            base.resultFloats = new float[4];
            base.fromFloats = new float[] { !this.rectVariable.IsNone ? this.rectVariable.Value.x : 0f, !this.rectVariable.IsNone ? this.rectVariable.Value.y : 0f, !this.rectVariable.IsNone ? this.rectVariable.Value.width : 0f, !this.rectVariable.IsNone ? this.rectVariable.Value.height : 0f };
            base.curves = new AnimationCurve[] { this.curveX.curve, this.curveY.curve, this.curveW.curve, this.curveH.curve };
            base.calculations = new AnimateFsmAction.Calculation[] { this.calculationX, this.calculationY, this.calculationW, this.calculationH };
            base.Init();
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
        }
    }
}

