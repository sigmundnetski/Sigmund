namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Camera), Tooltip("Gets the camera tagged MainCamera from the scene")]
    public class GetMainCamera : FsmStateAction
    {
        [UIHint(UIHint.Variable), RequiredField]
        public FsmGameObject storeGameObject;

        public override void OnEnter()
        {
            this.storeGameObject.Value = (Camera.main == null) ? null : Camera.main.gameObject;
            base.Finish();
        }

        public override void Reset()
        {
            this.storeGameObject = null;
        }
    }
}

