namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Logic), Tooltip("Tests if any of the given Bool Variables are True.")]
    public class BoolAnyTrue : FsmStateAction
    {
        [RequiredField, UIHint(UIHint.Variable), Tooltip("The Bool variables to check.")]
        public FsmBool[] boolVariables;
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        [Tooltip("Event to send if any of the Bool variables are True.")]
        public FsmEvent sendEvent;
        [UIHint(UIHint.Variable), Tooltip("Store the result in a Bool variable.")]
        public FsmBool storeResult;

        private void DoAnyTrue()
        {
            if (this.boolVariables.Length != 0)
            {
                this.storeResult.Value = false;
                for (int i = 0; i < this.boolVariables.Length; i++)
                {
                    if (this.boolVariables[i].Value)
                    {
                        base.Fsm.Event(this.sendEvent);
                        this.storeResult.Value = true;
                        return;
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoAnyTrue();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoAnyTrue();
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

