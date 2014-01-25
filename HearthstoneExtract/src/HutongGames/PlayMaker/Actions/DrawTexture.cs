namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUI), Tooltip("Draws a GUI Texture. NOTE: Uses OnGUI so you need a PlayMakerGUI component in the scene.")]
    public class DrawTexture : FsmStateAction
    {
        [Tooltip("Whether to alpha blend the image on to the display (the default). If false, the picture is drawn on to the display.")]
        public FsmBool alphaBlend;
        [Tooltip("Height of texture on screen.")]
        public FsmFloat height;
        [Tooltip("Aspect ratio to use for the source image. If 0 (the default), the aspect ratio from the image is used. Pass in w/h for the desired aspect ratio. This allows the aspect ratio of the source image to be adjusted without changing the pixel width and height.")]
        public FsmFloat imageAspect;
        [Tooltip("Left screen coordinate.")]
        public FsmFloat left;
        [Tooltip("Use normalized screen coordinates (0-1)")]
        public FsmBool normalized;
        private Rect rect;
        [Tooltip("How to scale the image when the aspect ratio of it doesn't fit the aspect ratio to be drawn within.")]
        public ScaleMode scaleMode;
        [Tooltip("Rectangle on the screen to draw the texture within. Alternatively, set or override individual properties below."), Title("Position"), UIHint(UIHint.Variable)]
        public FsmRect screenRect;
        [Tooltip("Texture to draw."), RequiredField]
        public FsmTexture texture;
        [Tooltip("Top screen coordinate.")]
        public FsmFloat top;
        [Tooltip("Width of texture on screen.")]
        public FsmFloat width;

        public override void OnGUI()
        {
            if (this.texture.Value != null)
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
                GUI.DrawTexture(this.rect, this.texture.Value, this.scaleMode, this.alphaBlend.Value, this.imageAspect.Value);
            }
        }

        public override void Reset()
        {
            this.texture = null;
            this.screenRect = null;
            this.left = 0f;
            this.top = 0f;
            this.width = 1f;
            this.height = 1f;
            this.scaleMode = ScaleMode.StretchToFill;
            this.alphaBlend = 1;
            this.imageAspect = 0f;
            this.normalized = 1;
        }
    }
}

