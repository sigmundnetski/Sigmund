namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Sends Events based on the value of a Boolean Variable."), ActionCategory(ActionCategory.Logic)]
    public class BoolTest : FsmStateAction
    {
        [RequiredField, UIHint(UIHint.Variable), Tooltip("The Bool variable to test.")]
        public FsmBool boolVariable;
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        [Tooltip("Event to send if the Bool variable is False.")]
        public FsmEvent isFalse;
        [Tooltip("Event to send if the Bool variable is True.")]
        public FsmEvent isTrue;

        public override void OnEnter()
        {
            base.Fsm.Event(!this.boolVariable.Value ? this.isFalse : this.isTrue);
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            base.Fsm.Event(!this.boolVariable.Value ? this.isFalse : this.isTrue);
        }

        public override void Reset()
        {
            this.boolVariable = null;
            this.isTrue = null;
            this.isFalse = null;
            this.everyFrame = false;
        }
    }
}

