namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Input), Tooltip("Sends an Event when a Key is released.")]
    public class GetKeyUp : FsmStateAction
    {
        [RequiredField]
        public KeyCode key;
        public FsmEvent sendEvent;
        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public override void OnUpdate()
        {
            bool keyUp = Input.GetKeyUp(this.key);
            if (keyUp)
            {
                base.Fsm.Event(this.sendEvent);
            }
            this.storeResult.Value = keyUp;
        }

        public override void Reset()
        {
            this.sendEvent = null;
            this.key = KeyCode.None;
            this.storeResult = null;
        }
    }
}

