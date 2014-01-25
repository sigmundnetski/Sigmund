namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Logic), Tooltip("Sends Events based on whether or not an option is enabled by the player.")]
    public class IsOptionEnabledAction : FsmStateAction
    {
        [Tooltip("Check if the option is enabled every frame.")]
        public bool m_EveryFrame;
        [Tooltip("Event sent if the option is off.")]
        public FsmEvent m_FalseEvent;
        [Tooltip("The option to check.")]
        public Option m_Option;
        [Tooltip("Event sent if the option is on.")]
        public FsmEvent m_TrueEvent;

        public override string ErrorCheck()
        {
            if (FsmEvent.IsNullOrEmpty(this.m_TrueEvent) && FsmEvent.IsNullOrEmpty(this.m_FalseEvent))
            {
                return "Action sends no events!";
            }
            return string.Empty;
        }

        private void FireEvents()
        {
            if (Options.Get().GetBool(this.m_Option))
            {
                base.Fsm.Event(this.m_TrueEvent);
            }
            else
            {
                base.Fsm.Event(this.m_FalseEvent);
            }
        }

        public override void OnEnter()
        {
            this.FireEvents();
            if (!this.m_EveryFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.FireEvents();
        }

        public override void Reset()
        {
            this.m_Option = Option.INVALID;
            this.m_TrueEvent = null;
            this.m_FalseEvent = null;
            this.m_EveryFrame = false;
        }
    }
}

