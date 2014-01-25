namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Logic), Tooltip("Tests if all the Bool Variables are False.\nSend an event or store the result.")]
    public class BoolNoneTrue : FsmStateAction
    {
        [RequiredField, UIHint(UIHint.Variable), Tooltip("The Bool variables to check.")]
        public FsmBool[] boolVariables;
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        [Tooltip("Event to send if none of the Bool variables are True.")]
        public FsmEvent sendEvent;
        [Tooltip("Store the result in a Bool variable."), UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        private void DoNoneTrue()
        {
            if (this.boolVariables.Length != 0)
            {
                bool flag = true;
                for (int i = 0; i < this.boolVariables.Length; i++)
                {
                    if (this.boolVariables[i].Value)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    base.Fsm.Event(this.sendEvent);
                }
                this.storeResult.Value = flag;
            }
        }

        public override void OnEnter()
        {
            this.DoNoneTrue();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoNoneTrue();
        }

        public override void Reset()
        {
            this.boolVariables = null;
            this.sendEvent = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}

