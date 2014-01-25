namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("GUILayout BeginHorizontal.")]
    public class GUILayoutBeginHorizontal : GUILayoutAction
    {
        public FsmTexture image;
        public FsmString style;
        public FsmString text;
        public FsmString tooltip;

        public override void OnGUI()
        {
            GUILayout.BeginHorizontal(new GUIContent(this.text.Value, this.image.Value, this.tooltip.Value), this.style.Value, base.LayoutOptions);
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

