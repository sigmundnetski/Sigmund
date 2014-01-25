namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Culling Mask used by the Camera."), ActionCategory(ActionCategory.Camera)]
    public class SetCameraCullingMask : FsmStateAction
    {
        [UIHint(UIHint.Layer), Tooltip("Cull these layers.")]
        public FsmInt[] cullingMask;
        public bool everyFrame;
        [CheckForComponent(typeof(Camera)), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("Invert the mask, so you cull all layers except those defined above.")]
        public FsmBool invertMask;

        private void DoSetCameraCullingMask()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Camera camera = ownerDefaultTarget.camera;
                if (camera == null)
                {
                    this.LogError("Missing Camera Component!");
                }
                else
                {
                    camera.cullingMask = ActionHelpers.LayerArrayToLayerMask(this.cullingMask, this.invertMask.Value);
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetCameraCullingMask();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetCameraCullingMask();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.cullingMask = new FsmInt[0];
            this.invertMask = 0;
            this.everyFrame = false;
        }
    }
}

