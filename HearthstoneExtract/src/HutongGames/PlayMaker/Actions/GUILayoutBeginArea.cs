namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Begin a GUILayout block of GUI controls in a fixed screen area. NOTE: Block must end with a corresponding GUILayoutEndArea."), ActionCategory(ActionCategory.GUILayout)]
    public class GUILayoutBeginArea : FsmStateAction
    {
        public FsmFloat height;
        public FsmFloat left;
        public FsmBool normalized;
        private Rect rect;
        [UIHint(UIHint.Variable)]
        public FsmRect screenRect;
        public FsmString style;
        public FsmFloat top;
        public FsmFloat width;

        public override void OnGUI()
        {
            this.rect = this.screenRect.IsNone ? new Rect() : this.screenRect.Value;
            if (!this.left.IsNone)
            {
                this.rect.x = this.left.Value;
            }
            if (!this.top.IsNone)
            {
                this.rect.y = this.top.Value;
            }
            if (!this.width.IsNone)
            {
                this.rect.width = this.width.Value;
            }
            if (!this.height.IsNone)
            {
                this.rect.height = this.height.Value;
            }
            if (this.normalized.Value)
            {
                this.rect.x *= Screen.width;
                this.rect.width *= Screen.width;
                this.rect.y *= Screen.height;
                this.rect.height *= Screen.height;
            }
            GUILayout.BeginArea(this.rect, GUIContent.none, this.style.Value);
        }

        public override void Reset()
        {
            this.screenRect = null;
            this.left = 0f;
            this.top = 0f;
            this.width = 1f;
            this.height = 1f;
            this.normalized = 1;
            this.style = string.Empty;
        }
    }
}

