namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Note("Kill all queued delayed events."), Tooltip("Kill all queued delayed events. Delayed events are 'fire and forget', but sometimes this can cause problems."), ActionCategory(ActionCategory.StateMachine)]
    public class KillDelayedEvents : FsmStateAction
    {
        public override void OnEnter()
        {
            base.Fsm.KillDelayedEvents();
            base.Finish();
        }
    }
}

