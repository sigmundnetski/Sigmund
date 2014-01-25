namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUIElement), Tooltip("Sets the Alpha of the GUITexture attached to a Game Object. Useful for fading GUI elements in/out.")]
    public class SetGUITextureAlpha : FsmStateAction
    {
        [RequiredField]
        public FsmFloat alpha;
        public bool everyFrame;
        [RequiredField, CheckForComponent(typeof(GUITexture))]
        public FsmOwnerDefault gameObject;

        private void DoGUITextureAlpha()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.guiTexture != null))
            {
                Color color = ownerDefaultTarget.guiTexture.color;
                ownerDefaultTarget.guiTexture.color = new Color(color.r, color.g, color.b, this.alpha.Value);
            }
        }

        public override void OnEnter()
        {
            this.DoGUITextureAlpha();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGUITextureAlpha();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.alpha = 1f;
            this.everyFrame = false;
        }
    }
}

