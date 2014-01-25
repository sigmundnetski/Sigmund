namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Camera), Tooltip("Fade to a fullscreen Color. NOTE: Uses OnGUI so requires a PlayMakerGUI component in the scene.")]
    public class CameraFadeOut : FsmStateAction
    {
        [Tooltip("Color to fade to. E.g., Fade to black."), RequiredField]
        public FsmColor color;
        private Color colorLerp;
        private float currentTime;
        [Tooltip("Event to send when finished.")]
        public FsmEvent finishEvent;
        [Tooltip("Ignore TimeScale. Useful if the game is paused.")]
        public bool realTime;
        private float startTime;
        [RequiredField, Tooltip("Fade out time in seconds."), HasFloatSlider(0f, 10f)]
        public FsmFloat time;

        public override void OnEnter()
        {
            this.startTime = FsmTime.RealtimeSinceStartup;
            this.currentTime = 0f;
            this.colorLerp = Color.clear;
        }

        public override void OnGUI()
        {
            Color color = GUI.color;
            GUI.color = this.colorLerp;
            GUI.DrawTexture(new Rect(0f, 0f, (float) Screen.width, (float) Screen.height), ActionHelpers.WhiteTexture);
            GUI.color = color;
        }

        public override void OnUpdate()
        {
            if (this.realTime)
            {
                this.currentTime = FsmTime.RealtimeSinceStartup - this.startTime;
            }
            else
            {
                this.currentTime += Time.deltaTime;
            }
            this.colorLerp = Color.Lerp(Color.clear, this.color.Value, this.currentTime / this.time.Value);
            if ((this.currentTime > this.time.Value) && (this.finishEvent != null))
            {
                base.Fsm.Event(this.finishEvent);
            }
        }

        public override void Reset()
        {
            this.color = Color.black;
            this.time = 1f;
            this.finishEvent = null;
        }
    }
}

