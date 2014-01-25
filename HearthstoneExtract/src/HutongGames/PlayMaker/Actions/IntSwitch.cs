namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Logic), Tooltip("Sends an Event based on the value of an Integer Variable.")]
    public class IntSwitch : FsmStateAction
    {
        [CompoundArray("Int Switches", "Compare Int", "Send Event")]
        public FsmInt[] compareTo;
        public bool everyFrame;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmInt intVariable;
        public FsmEvent[] sendEvent;

        private void DoIntSwitch()
        {
            if (!this.intVariable.IsNone)
            {
                for (int i = 0; i < this.compareTo.Length; i++)
                {
                    if (this.intVariable.Value == this.compareTo[i].Value)
                    {
                        base.Fsm.Event(this.sendEvent[i]);
                        return;
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoIntSwitch();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoIntSwitch();
        }

        public override void Reset()
        {
            this.intVariable = null;
            this.compareTo = new FsmInt[1];
            this.sendEvent = new FsmEvent[1];
            this.everyFrame = false;
        }
    }
}

