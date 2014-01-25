namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("A Vertical Slider linked to a Float Variable.")]
    public class GUILayoutVerticalSlider : GUILayoutAction
    {
        [RequiredField]
        public FsmFloat bottomValue;
        public FsmEvent changedEvent;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmFloat floatVariable;
        [RequiredField]
        public FsmFloat topValue;

        public override void OnGUI()
        {
            bool changed = GUI.changed;
            GUI.changed = false;
            if (this.floatVariable != null)
            {
                this.floatVariable.Value = GUILayout.VerticalSlider(this.floatVariable.Value, this.topValue.Value, this.bottomValue.Value, base.LayoutOptions);
            }
            if (GUI.changed)
            {
                base.Fsm.Event(this.changedEvent);
                GUIUtility.ExitGUI();
            }
            else
            {
                GUI.changed = changed;
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.floatVariable = null;
            this.topValue = 100f;
            this.bottomValue = 0f;
            this.changedEvent = null;
        }
    }
}

