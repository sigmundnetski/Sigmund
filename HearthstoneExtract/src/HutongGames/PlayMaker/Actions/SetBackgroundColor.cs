namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Camera), Tooltip("Sets the Background Color used by the Camera.")]
    public class SetBackgroundColor : FsmStateAction
    {
        [RequiredField]
        public FsmColor backgroundColor;
        public bool everyFrame;
        [CheckForComponent(typeof(Camera)), RequiredField]
        public FsmOwnerDefault gameObject;

        private void DoSetBackgroundColor()
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
                    camera.backgroundColor = this.backgroundColor.Value;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetBackgroundColor();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetBackgroundColor();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.backgroundColor = Color.black;
            this.everyFrame = false;
        }
    }
}

