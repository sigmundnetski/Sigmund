namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Math), Tooltip("Flips the value of a Bool Variable.")]
    public class BoolFlip : FsmStateAction
    {
        [RequiredField, Tooltip("Bool variable to flip."), UIHint(UIHint.Variable)]
        public FsmBool boolVariable;

        public override void OnEnter()
        {
            this.boolVariable.Value = !this.boolVariable.Value;
            base.Finish();
        }

        public override void Reset()
        {
            this.boolVariable = null;
        }
    }
}

