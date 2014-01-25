namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Multiplies a Float by Time.deltaTime to use in frame-rate independent operations. E.g., 10 becomes 10 units per second."), ActionCategory(ActionCategory.Time)]
    public class PerSecond : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmFloat floatValue;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmFloat storeResult;

        private void DoPerSecond()
        {
            if (this.storeResult != null)
            {
                this.storeResult.Value = this.floatValue.Value * Time.deltaTime;
            }
        }

        public override void OnEnter()
        {
            this.DoPerSecond();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoPerSecond();
        }

        public override void Reset()
        {
            this.floatValue = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}

