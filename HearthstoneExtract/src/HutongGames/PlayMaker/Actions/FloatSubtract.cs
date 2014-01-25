namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Math), Tooltip("Subtracts a value from a Float Variable.")]
    public class FloatSubtract : FsmStateAction
    {
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        [RequiredField, UIHint(UIHint.Variable), Tooltip("The float variable to subtract from.")]
        public FsmFloat floatVariable;
        [Tooltip("Used with Every Frame. Adds the value over one second to make the operation frame rate independent.")]
        public bool perSecond;
        [RequiredField, Tooltip("Value to subtract from the float variable.")]
        public FsmFloat subtract;

        private void DoFloatSubtract()
        {
            if (!this.perSecond)
            {
                this.floatVariable.Value -= this.subtract.Value;
            }
            else
            {
                this.floatVariable.Value -= this.subtract.Value * Time.deltaTime;
            }
        }

        public override void OnEnter()
        {
            this.DoFloatSubtract();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoFloatSubtract();
        }

        public override void Reset()
        {
            this.floatVariable = null;
            this.subtract = null;
            this.everyFrame = false;
            this.perSecond = false;
        }
    }
}

