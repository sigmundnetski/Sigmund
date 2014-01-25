namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Time), Tooltip("Scales time: 1 = normal, 0.5 = half speed, 2 = double speed.")]
    public class ScaleTime : FsmStateAction
    {
        [Tooltip("Adjust the fixed physics time step to match the time scale.")]
        public FsmBool adjustFixedDeltaTime;
        [Tooltip("Repeat every frame. Useful when animating the value.")]
        public bool everyFrame;
        [HasFloatSlider(0f, 4f), RequiredField, Tooltip("Scales time: 1 = normal, 0.5 = half speed, 2 = double speed.")]
        public FsmFloat timeScale;

        private void DoTimeScale()
        {
            Time.timeScale = this.timeScale.Value;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        public override void OnEnter()
        {
            this.DoTimeScale();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoTimeScale();
        }

        public override void Reset()
        {
            this.timeScale = 1f;
            this.adjustFixedDeltaTime = 1;
            this.everyFrame = false;
        }
    }
}

