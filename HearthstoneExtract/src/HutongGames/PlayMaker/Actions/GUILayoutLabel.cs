namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("GUILayout Label.")]
    public class GUILayoutLabel : GUILayoutAction
    {
        public FsmTexture image;
        public FsmString style;
        public FsmString text;
        public FsmString tooltip;

        public override void OnGUI()
        {
            if (string.IsNullOrEmpty(this.style.Value))
            {
                GUILayout.Label(new GUIContent(this.text.Value, this.image.Value, this.tooltip.Value), base.LayoutOptions);
            }
            else
            {
                GUILayout.Label(new GUIContent(this.text.Value, this.image.Value, this.tooltip.Value), this.style.Value, base.LayoutOptions);
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.text = string.Empty;
            this.image = null;
            this.tooltip = string.Empty;
            this.style = string.Empty;
        }
    }
}

