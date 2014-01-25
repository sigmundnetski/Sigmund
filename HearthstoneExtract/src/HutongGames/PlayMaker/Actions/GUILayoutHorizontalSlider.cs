namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("A Horizontal Slider linked to a Float Variable."), ActionCategory(ActionCategory.GUILayout)]
    public class GUILayoutHorizontalSlider : GUILayoutAction
    {
        public FsmEvent changedEvent;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmFloat floatVariable;
        [RequiredField]
        public FsmFloat leftValue;
        [RequiredField]
        public FsmFloat rightValue;

        public override void OnGUI()
        {
            bool changed = GUI.changed;
            GUI.changed = false;
            if (this.floatVariable != null)
            {
                this.floatVariable.Value = GUILayout.HorizontalSlider(this.floatVariable.Value, this.leftValue.Value, this.rightValue.Value, base.LayoutOptions);
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
            this.leftValue = 0f;
            this.rightValue = 100f;
            this.changedEvent = null;
        }
    }
}

