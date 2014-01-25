namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Activates a Camera in the scene."), ActionCategory(ActionCategory.Camera)]
    public class CutToCamera : FsmStateAction
    {
        [RequiredField]
        public Camera camera;
        public bool cutBackOnExit;
        public bool makeMainCamera;
        private Camera oldCamera;

        public override void OnEnter()
        {
            if (this.camera == null)
            {
                this.LogError("Missing camera!");
            }
            else
            {
                this.oldCamera = Camera.mainCamera;
                SwitchCamera(Camera.mainCamera, this.camera);
                if (this.makeMainCamera)
                {
                    this.camera.tag = "MainCamera";
                }
                base.Finish();
            }
        }

        public override void OnExit()
        {
            if (this.cutBackOnExit)
            {
                SwitchCamera(this.camera, this.oldCamera);
            }
        }

        public override void Reset()
        {
            this.camera = null;
            this.makeMainCamera = true;
            this.cutBackOnExit = false;
        }

        private static void SwitchCamera(Camera camera1, Camera camera2)
        {
            if (camera1 != null)
            {
                camera1.enabled = false;
            }
            if (camera2 != null)
            {
                camera2.enabled = true;
            }
        }
    }
}

