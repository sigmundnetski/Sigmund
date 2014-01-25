namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.AnimateVariables), Tooltip("Animates the value of a Vector3 Variable using an Animation Curve.")]
    public class AnimateVector3 : AnimateFsmAction
    {
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to vectorVariable.x.")]
        public AnimateFsmAction.Calculation calculationX;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to vectorVariable.y.")]
        public AnimateFsmAction.Calculation calculationY;
        [Tooltip("Calculation lets you set a type of curve deformation that will be applied to vectorVariable.z.")]
        public AnimateFsmAction.Calculation calculationZ;
        [RequiredField]
        public FsmAnimationCurve curveX;
        [RequiredField]
        public FsmAnimationCurve curveY;
        [RequiredField]
        public FsmAnimationCurve curveZ;
        private bool finishInNextStep;
        private Vector3 vct;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmVector3 vectorVariable;

        public override void OnEnter()
        {
            base.OnEnter();
            this.finishInNextStep = false;
            base.resultFloats = new float[3];
            base.fromFloats = new float[] { !this.vectorVariable.IsNone ? this.vectorVariable.Value.x : 0f, !this.vectorVariable.IsNone ? this.vectorVariable.Value.y : 0f, !this.vectorVariable.IsNone ? this.vectorVariable.Value.z : 0f };
            base.curves = new AnimationCurve[] { this.curveX.curve, this.curveY.curve, this.curveZ.curve };
            base.calculations = new AnimateFsmAction.Calculation[] { this.calculationX, this.calculationY, this.calculationZ };
            base.Init();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!this.vectorVariable.IsNone && base.isRunning)
            {
                this.vct = new Vector3(base.resultFloats[0], base.resultFloats[1], base.resultFloats[2]);
                this.vectorVariable.Value = this.vct;
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
                if (!this.vectorVariable.IsNone)
                {
                    this.vct = new Vector3(base.resultFloats[0], base.resultFloats[1], base.resultFloats[2]);
                    this.vectorVariable.Value = this.vct;
                }
                this.finishInNextStep = true;
            }
        }

        public override void Reset()
        {
            base.Reset();
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.vectorVariable = vector;
        }
    }
}

