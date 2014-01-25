namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Sends an Event in the next frame. Useful if you want to loop states every frame.")]
    public class NextFrameEvent : FsmStateAction
    {
        [RequiredField]
        public FsmEvent sendEvent;

        public override void OnEnter()
        {
        }

        public override void OnUpdate()
        {
            base.Finish();
            base.Fsm.Event(this.sendEvent);
        }

        public override void Reset()
        {
            this.sendEvent = null;
        }
    }
}

