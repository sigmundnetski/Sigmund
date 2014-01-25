namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("GUILayout Label for simple text.")]
    public class GUILayoutTextLabel : GUILayoutAction
    {
        [Tooltip("Optional GUIStyle in the active GUISkin.")]
        public FsmString style;
        [Tooltip("Text to display.")]
        public FsmString text;

        public override void OnGUI()
        {
            if (string.IsNullOrEmpty(this.style.Value))
            {
                GUILayout.Label(new GUIContent(this.text.Value), base.LayoutOptions);
            }
            else
            {
                GUILayout.Label(new GUIContent(this.text.Value), this.style.Value, base.LayoutOptions);
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.text = string.Empty;
            this.style = string.Empty;
        }
    }
}

