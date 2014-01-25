namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUIElement), Tooltip("Sets the Color of the GUITexture attached to a Game Object.")]
    public class SetGUITextureColor : FsmStateAction
    {
        [RequiredField]
        public FsmColor color;
        public bool everyFrame;
        [RequiredField, CheckForComponent(typeof(GUITexture))]
        public FsmOwnerDefault gameObject;

        private void DoSetGUITextureColor()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.guiTexture != null))
            {
                ownerDefaultTarget.guiTexture.color = this.color.Value;
            }
        }

        public override void OnEnter()
        {
            this.DoSetGUITextureColor();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetGUITextureColor();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.color = Color.white;
            this.everyFrame = false;
        }
    }
}

