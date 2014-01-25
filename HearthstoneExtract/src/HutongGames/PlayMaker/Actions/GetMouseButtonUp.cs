namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Input), Tooltip("Sends an Event when the specified Mouse Button is released. Optionally store the button state in a bool variable.")]
    public class GetMouseButtonUp : FsmStateAction
    {
        [RequiredField]
        public MouseButton button;
        public FsmEvent sendEvent;
        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public override void OnUpdate()
        {
            bool mouseButtonUp = Input.GetMouseButtonUp((int) this.button);
            if (mouseButtonUp)
            {
                base.Fsm.Event(this.sendEvent);
            }
            this.storeResult.Value = mouseButtonUp;
        }

        public override void Reset()
        {
            this.button = MouseButton.Left;
            this.sendEvent = null;
            this.storeResult = null;
        }
    }
}

