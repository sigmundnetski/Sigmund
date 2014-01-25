namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets the number of Touches."), ActionCategory(ActionCategory.Device)]
    public class GetTouchCount : FsmStateAction
    {
        public bool everyFrame;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmInt storeCount;

        private void DoGetTouchCount()
        {
            this.storeCount.Value = Input.touchCount;
        }

        public override void OnEnter()
        {
            this.DoGetTouchCount();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetTouchCount();
        }

        public override void Reset()
        {
            this.storeCount = null;
            this.everyFrame = false;
        }
    }
}

