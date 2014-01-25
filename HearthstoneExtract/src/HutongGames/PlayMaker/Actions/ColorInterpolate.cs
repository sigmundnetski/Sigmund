namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Interpolate through an array of Colors over a specified amount of Time."), ActionCategory(ActionCategory.Color)]
    public class ColorInterpolate : FsmStateAction
    {
        [Tooltip("Array of colors to interpolate through."), RequiredField]
        public FsmColor[] colors;
        private float currentTime;
        [Tooltip("Event to send when the interpolation finishes.")]
        public FsmEvent finishEvent;
        [Tooltip("Ignore TimeScale")]
        public bool realTime;
        private float startTime;
        [RequiredField, UIHint(UIHint.Variable), Tooltip("Store the interpolated color in a Color variable.")]
        public FsmColor storeColor;
        [Tooltip("Interpolation time."), RequiredField]
        public FsmFloat time;

        public override string ErrorCheck()
        {
            return ((this.colors.Length >= 2) ? null : "Define at least 2 colors to make a gradient.");
        }

        public override void OnEnter()
        {
            this.startTime = FsmTime.RealtimeSinceStartup;
            this.currentTime = 0f;
            if (this.colors.Length < 2)
            {
                if (this.colors.Length == 1)
                {
                    this.storeColor.Value = this.colors[0].Value;
                }
                base.Finish();
            }
            else
            {
                this.storeColor.Value = this.colors[0].Value;
            }
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
            if (this.currentTime > this.time.Value)
            {
                base.Finish();
                this.storeColor.Value = this.colors[this.colors.Length - 1].Value;
                if (this.finishEvent != null)
                {
                    base.Fsm.Event(this.finishEvent);
                }
            }
            else
            {
                Color color;
                float f = ((this.colors.Length - 1) * this.currentTime) / this.time.Value;
                if (f.Equals((float) 0f))
                {
                    color = this.colors[0].Value;
                }
                else if (f.Equals((float) (this.colors.Length - 1)))
                {
                    color = this.colors[this.colors.Length - 1].Value;
                }
                else
                {
                    Color a = this.colors[Mathf.FloorToInt(f)].Value;
                    Color b = this.colors[Mathf.CeilToInt(f)].Value;
                    f -= Mathf.Floor(f);
                    color = Color.Lerp(a, b, f);
                }
                this.storeColor.Value = color;
            }
        }

        public override void Reset()
        {
            this.colors = new FsmColor[3];
            this.time = 1f;
            this.storeColor = null;
            this.finishEvent = null;
            this.realTime = false;
        }
    }
}

