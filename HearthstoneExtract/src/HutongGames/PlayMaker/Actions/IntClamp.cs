namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Math), Tooltip("Clamp the value of an Integer Variable to a Min/Max range.")]
    public class IntClamp : FsmStateAction
    {
        public bool everyFrame;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmInt intVariable;
        [RequiredField]
        public FsmInt maxValue;
        [RequiredField]
        public FsmInt minValue;

        private void DoClamp()
        {
            this.intVariable.Value = Mathf.Clamp(this.intVariable.Value, this.minValue.Value, this.maxValue.Value);
        }

        public override void OnEnter()
        {
            this.DoClamp();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoClamp();
        }

        public override void Reset()
        {
            this.intVariable = null;
            this.minValue = null;
            this.maxValue = null;
            this.everyFrame = false;
        }
    }
}

