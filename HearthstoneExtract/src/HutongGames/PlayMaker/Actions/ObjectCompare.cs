namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Logic), Tooltip("Compare 2 Object Variables and send events based on the result.")]
    public class ObjectCompare : FsmStateAction
    {
        [RequiredField]
        public FsmObject compareTo;
        [Tooltip("Event to send if the 2 object values are equal.")]
        public FsmEvent equalEvent;
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        [Tooltip("Event to send if the 2 object values are not equal.")]
        public FsmEvent notEqualEvent;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmObject objectVariable;
        [Tooltip("Store the result in a variable."), UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        private void DoObjectCompare()
        {
            bool flag = this.objectVariable.Value == this.compareTo.Value;
            this.storeResult.Value = flag;
            base.Fsm.Event(!flag ? this.notEqualEvent : this.equalEvent);
        }

        public override void OnEnter()
        {
            this.DoObjectCompare();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoObjectCompare();
        }

        public override void Reset()
        {
            this.objectVariable = null;
            this.compareTo = null;
            this.storeResult = null;
            this.equalEvent = null;
            this.notEqualEvent = null;
            this.everyFrame = false;
        }
    }
}

