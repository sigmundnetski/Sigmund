namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Device), Tooltip("Sends events based on Touch Phases. Optionally filter by a fingerID.")]
    public class TouchEvent : FsmStateAction
    {
        public FsmInt fingerId;
        public FsmEvent sendEvent;
        [UIHint(UIHint.Variable)]
        public FsmInt storeFingerId;
        public TouchPhase touchPhase;

        public override void OnUpdate()
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    if ((this.fingerId.IsNone || (touch.fingerId == this.fingerId.Value)) && (touch.phase == this.touchPhase))
                    {
                        this.storeFingerId.Value = touch.fingerId;
                        base.Fsm.Event(this.sendEvent);
                    }
                }
            }
        }

        public override void Reset()
        {
            FsmInt num = new FsmInt {
                UseVariable = true
            };
            this.fingerId = num;
            this.storeFingerId = null;
        }
    }
}

