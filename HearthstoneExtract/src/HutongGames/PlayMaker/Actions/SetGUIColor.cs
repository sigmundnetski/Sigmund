namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Tinting Color for the GUI. By default only effects GUI rendered by this FSM, check Apply Globally to effect all GUI controls."), ActionCategory(ActionCategory.GUI)]
    public class SetGUIColor : FsmStateAction
    {
        public FsmBool applyGlobally;
        [RequiredField]
        public FsmColor color;

        public override void OnGUI()
        {
            GUI.color = this.color.Value;
            if (this.applyGlobally.Value)
            {
                PlayMakerGUI.GUIColor = GUI.color;
            }
        }

        public override void Reset()
        {
            this.color = Color.white;
        }
    }
}

