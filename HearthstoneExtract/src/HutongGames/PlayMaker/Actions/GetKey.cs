namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets the pressed state of a Key."), ActionCategory(ActionCategory.Input)]
    public class GetKey : FsmStateAction
    {
        [Tooltip("Repeat every frame. Useful if you're waiting for a key press/release.")]
        public bool everyFrame;
        [RequiredField, Tooltip("The key to test.")]
        public KeyCode key;
        [UIHint(UIHint.Variable), RequiredField, Tooltip("Store if the key is down (True) or up (False).")]
        public FsmBool storeResult;

        private void DoGetKey()
        {
            this.storeResult.Value = Input.GetKey(this.key);
        }

        public override void OnEnter()
        {
            this.DoGetKey();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetKey();
        }

        public override void Reset()
        {
            this.key = KeyCode.None;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}

