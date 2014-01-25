namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Scales the GUI around a pivot point. By default only effects GUI rendered by this FSM, check Apply Globally to effect all GUI controls."), ActionCategory(ActionCategory.GUI)]
    public class ScaleGUI : FsmStateAction
    {
        private bool applied;
        public bool applyGlobally;
        [Tooltip("Pivot point uses normalized coordinates. E.g. 0.5 is the center of the screen.")]
        public bool normalized;
        [RequiredField]
        public FsmFloat pivotX;
        [RequiredField]
        public FsmFloat pivotY;
        [RequiredField]
        public FsmFloat scaleX;
        [RequiredField]
        public FsmFloat scaleY;

        public override void OnGUI()
        {
            if (!this.applied)
            {
                Vector2 scale = new Vector2(this.scaleX.Value, this.scaleY.Value);
                if (object.Equals(scale.x, 0))
                {
                    scale.x = 0.0001f;
                }
                if (object.Equals(scale.y, 0))
                {
                    scale.x = 0.0001f;
                }
                Vector2 pivotPoint = new Vector2(this.pivotX.Value, this.pivotY.Value);
                if (this.normalized)
                {
                    pivotPoint.x *= Screen.width;
                    pivotPoint.y *= Screen.height;
                }
                GUIUtility.ScaleAroundPivot(scale, pivotPoint);
                if (this.applyGlobally)
                {
                    PlayMakerGUI.GUIMatrix = GUI.matrix;
                    this.applied = true;
                }
            }
        }

        public override void OnUpdate()
        {
            this.applied = false;
        }

        public override void Reset()
        {
            this.scaleX = 1f;
            this.scaleY = 1f;
            this.pivotX = 0.5f;
            this.pivotY = 0.5f;
            this.normalized = true;
            this.applyGlobally = false;
        }
    }
}

