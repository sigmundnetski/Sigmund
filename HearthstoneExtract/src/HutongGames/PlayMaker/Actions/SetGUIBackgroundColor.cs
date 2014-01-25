namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Tinting Color for all background elements rendered by the GUI. By default only effects GUI rendered by this FSM, check Apply Globally to effect all GUI controls."), ActionCategory(ActionCategory.GUI)]
    public class SetGUIBackgroundColor : FsmStateAction
    {
        public FsmBool applyGlobally;
        [RequiredField]
        public FsmColor backgroundColor;

        public override void OnGUI()
        {
            GUI.backgroundColor = this.backgroundColor.Value;
            if (this.applyGlobally.Value)
            {
                PlayMakerGUI.GUIBackgroundColor = GUI.backgroundColor;
            }
        }

        public override void Reset()
        {
            this.backgroundColor = Color.white;
        }
    }
}

