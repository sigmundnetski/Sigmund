namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets the X Position of the mouse and stores it in a Float Variable."), ActionCategory(ActionCategory.Input)]
    public class GetMouseX : FsmStateAction
    {
        public bool normalize;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmFloat storeResult;

        private void DoGetMouseX()
        {
            if (this.storeResult != null)
            {
                float x = Input.mousePosition.x;
                if (this.normalize)
                {
                    x /= (float) Screen.width;
                }
                this.storeResult.Value = x;
            }
        }

        public override void OnEnter()
        {
            this.DoGetMouseX();
        }

        public override void OnUpdate()
        {
            this.DoGetMouseX();
        }

        public override void Reset()
        {
            this.storeResult = null;
            this.normalize = true;
        }
    }
}

