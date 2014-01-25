namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Texture used by the GUITexture attached to a Game Object."), ActionCategory(ActionCategory.GUIElement)]
    public class SetGUITexture : FsmStateAction
    {
        [CheckForComponent(typeof(GUITexture)), RequiredField]
        public FsmOwnerDefault gameObject;
        public FsmTexture texture;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.guiTexture != null))
            {
                ownerDefaultTarget.guiTexture.texture = this.texture.Value;
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.texture = null;
        }
    }
}

