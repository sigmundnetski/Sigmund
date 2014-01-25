namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("Begin a GUILayout area that follows the specified game object. Useful for overlays (e.g., playerName). NOTE: Block must end with a corresponding GUILayoutEndArea.")]
    public class GUILayoutBeginAreaFollowObject : FsmStateAction
    {
        [Tooltip("The GameObject to follow."), RequiredField]
        public FsmGameObject gameObject;
        [RequiredField]
        public FsmFloat height;
        [Tooltip("Use normalized screen coordinates (0-1).")]
        public FsmBool normalized;
        [RequiredField]
        public FsmFloat offsetLeft;
        [RequiredField]
        public FsmFloat offsetTop;
        [Tooltip("Optional named style in the current GUISkin")]
        public FsmString style;
        [RequiredField]
        public FsmFloat width;

        private static void DummyBeginArea()
        {
            GUILayout.BeginArea(new Rect());
        }

        public override void OnGUI()
        {
            GameObject obj2 = this.gameObject.Value;
            if ((obj2 == null) || (Camera.main == null))
            {
                DummyBeginArea();
            }
            else
            {
                Vector3 position = obj2.transform.position;
                if (Camera.main.transform.InverseTransformPoint(position).z < 0f)
                {
                    DummyBeginArea();
                }
                else
                {
                    Vector2 vector3 = Camera.main.WorldToScreenPoint(position);
                    float left = vector3.x + (!this.normalized.Value ? this.offsetLeft.Value : (this.offsetLeft.Value * Screen.width));
                    float top = vector3.y + (!this.normalized.Value ? this.offsetTop.Value : (this.offsetTop.Value * Screen.width));
                    Rect screenRect = new Rect(left, top, this.width.Value, this.height.Value);
                    if (this.normalized.Value)
                    {
                        screenRect.width *= Screen.width;
                        screenRect.height *= Screen.height;
                    }
                    screenRect.y = Screen.height - screenRect.y;
                    GUILayout.BeginArea(screenRect, this.style.Value);
                }
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.offsetLeft = 0f;
            this.offsetTop = 0f;
            this.width = 1f;
            this.height = 1f;
            this.normalized = 1;
            this.style = string.Empty;
        }
    }
}

