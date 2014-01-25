namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Effects), Tooltip("Turns a Game Object on/off in a regular repeating pattern.")]
    public class Blink : FsmStateAction
    {
        private bool blinkOn;
        [RequiredField, Tooltip("The GameObject to blink on/off.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Ignore TimeScale. Useful if the game is paused.")]
        public bool realTime;
        [Tooltip("Only effect the renderer, keeping other components active.")]
        public bool rendererOnly;
        [Tooltip("Should the object start in the active/visible state?")]
        public FsmBool startOn;
        private float startTime;
        [Tooltip("Time to stay off in seconds."), HasFloatSlider(0f, 5f)]
        public FsmFloat timeOff;
        [HasFloatSlider(0f, 5f), Tooltip("Time to stay on in seconds.")]
        public FsmFloat timeOn;
        private float timer;

        public override void OnEnter()
        {
            this.startTime = FsmTime.RealtimeSinceStartup;
            this.timer = 0f;
            this.UpdateBlinkState(this.startOn.Value);
        }

        public override void OnUpdate()
        {
            if (this.realTime)
            {
                this.timer = FsmTime.RealtimeSinceStartup - this.startTime;
            }
            else
            {
                this.timer += Time.deltaTime;
            }
            if (this.blinkOn && (this.timer > this.timeOn.Value))
            {
                this.UpdateBlinkState(false);
            }
            if (!this.blinkOn && (this.timer > this.timeOff.Value))
            {
                this.UpdateBlinkState(true);
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.timeOff = 0.5f;
            this.timeOn = 0.5f;
            this.rendererOnly = true;
            this.startOn = 0;
            this.realTime = false;
        }

        private void UpdateBlinkState(bool state)
        {
            GameObject obj2 = (this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner;
            if (obj2 != null)
            {
                if (this.rendererOnly)
                {
                    if (obj2.renderer != null)
                    {
                        obj2.renderer.enabled = state;
                    }
                }
                else
                {
                    obj2.SetActive(state);
                }
                this.blinkOn = state;
                this.startTime = FsmTime.RealtimeSinceStartup;
                this.timer = 0f;
            }
        }
    }
}

