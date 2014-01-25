namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Text used by the GUIText Component attached to a Game Object."), ActionCategory(ActionCategory.GUIElement)]
    public class SetGUIText : FsmStateAction
    {
        public bool everyFrame;
        [CheckForComponent(typeof(GUIText)), RequiredField]
        public FsmOwnerDefault gameObject;
        public FsmString text;

        private void DoSetGUIText()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.guiText != null))
            {
                ownerDefaultTarget.guiText.text = this.text.Value;
            }
        }

        public override void OnEnter()
        {
            this.DoSetGUIText();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetGUIText();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.text = string.Empty;
        }
    }
}

