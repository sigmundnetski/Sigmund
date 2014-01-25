namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("GUI base action - don't use!")]
    public abstract class GUIContentAction : GUIAction
    {
        internal GUIContent content;
        public FsmTexture image;
        public FsmString style;
        public FsmString text;
        public FsmString tooltip;

        protected GUIContentAction()
        {
        }

        public override void OnGUI()
        {
            base.OnGUI();
            this.content = new GUIContent(this.text.Value, this.image.Value, this.tooltip.Value);
        }

        public override void Reset()
        {
            base.Reset();
            this.image = null;
            this.text = string.Empty;
            this.tooltip = string.Empty;
            this.style = string.Empty;
        }
    }
}

