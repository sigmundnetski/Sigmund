namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUI), Tooltip("GUI Box.")]
    public class GUIBox : GUIContentAction
    {
        public override void OnGUI()
        {
            base.OnGUI();
            if (string.IsNullOrEmpty(base.style.Value))
            {
                GUI.Box(base.rect, base.content);
            }
            else
            {
                GUI.Box(base.rect, base.content, base.style.Value);
            }
        }
    }
}

