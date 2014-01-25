namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Sends an Event based on the value of a String Variable."), ActionCategory(ActionCategory.Logic)]
    public class StringSwitch : FsmStateAction
    {
        [CompoundArray("String Switches", "Compare String", "Send Event")]
        public FsmString[] compareTo;
        public bool everyFrame;
        public FsmEvent[] sendEvent;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmString stringVariable;

        private void DoStringSwitch()
        {
            if (!this.stringVariable.IsNone)
            {
                for (int i = 0; i < this.compareTo.Length; i++)
                {
                    if (this.stringVariable.Value == this.compareTo[i].Value)
                    {
                        base.Fsm.Event(this.sendEvent[i]);
                        return;
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoStringSwitch();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoStringSwitch();
        }

        public override void Reset()
        {
            this.stringVariable = null;
            this.compareTo = new FsmString[1];
            this.sendEvent = new FsmEvent[1];
            this.everyFrame = false;
        }
    }
}

