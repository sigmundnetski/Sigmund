namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets the Tooltip of the control the mouse is currently over and store it in a String Variable."), ActionCategory(ActionCategory.GUI)]
    public class GUITooltip : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        public FsmString storeTooltip;

        public override void OnGUI()
        {
            this.storeTooltip.Value = GUI.tooltip;
        }

        public override void Reset()
        {
            this.storeTooltip = null;
        }
    }
}

