namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets Field of View used by the Camera."), ActionCategory(ActionCategory.Camera)]
    public class SetCameraFOV : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmFloat fieldOfView;
        [CheckForComponent(typeof(Camera)), RequiredField]
        public FsmOwnerDefault gameObject;

        private void DoSetCameraFOV()
        {
            GameObject obj2 = (this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner;
            if (obj2 != null)
            {
                Camera camera = obj2.camera;
                if (camera == null)
                {
                    this.LogError("Missing Camera Component!");
                }
                else
                {
                    camera.fieldOfView = this.fieldOfView.Value;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetCameraFOV();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetCameraFOV();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.fieldOfView = 50f;
            this.everyFrame = false;
        }
    }
}

