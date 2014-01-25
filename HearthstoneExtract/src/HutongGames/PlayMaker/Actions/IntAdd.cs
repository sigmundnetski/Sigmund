namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Adds a value to an Integer Variable."), ActionCategory(ActionCategory.Math)]
    public class IntAdd : FsmStateAction
    {
        [RequiredField]
        public FsmInt add;
        public bool everyFrame;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmInt intVariable;

        public override void OnEnter()
        {
            this.intVariable.Value += this.add.Value;
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.intVariable.Value += this.add.Value;
        }

        public override void Reset()
        {
            this.intVariable = null;
            this.add = null;
            this.everyFrame = false;
        }
    }
}

