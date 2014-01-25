namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Randomly flickers a Game Object on/off."), ActionCategory(ActionCategory.Effects)]
    public class Flicker : FsmStateAction
    {
        [Tooltip("Amount of time flicker is On (0-1). E.g. Use 0.95 for an occasional flicker."), HasFloatSlider(0f, 1f)]
        public FsmFloat amountOn;
        [Tooltip("The frequency of the flicker in seconds."), HasFloatSlider(0f, 1f)]
        public FsmFloat frequency;
        [Tooltip("The GameObject to flicker."), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("Ignore time scale. Useful if flickering UI when the game is paused.")]
        public bool realTime;
        [Tooltip("Only effect the renderer, leaving other components active.")]
        public bool rendererOnly;
        private float startTime;
        private float timer;

        public override void OnEnter()
        {
            this.startTime = FsmTime.RealtimeSinceStartup;
            this.timer = 0f;
        }

        public override void OnUpdate()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                if (this.realTime)
                {
                    this.timer = FsmTime.RealtimeSinceStartup - this.startTime;
                }
                else
                {
                    this.timer += Time.deltaTime;
                }
                if (this.timer > this.frequency.Value)
                {
                    bool flag = UnityEngine.Random.Range((float) 0f, (float) 1f) < this.amountOn.Value;
                    if (this.rendererOnly)
                    {
                        if (ownerDefaultTarget.renderer != null)
                        {
                            ownerDefaultTarget.renderer.enabled = flag;
                        }
                    }
                    else
                    {
                        ownerDefaultTarget.SetActive(flag);
                    }
                    this.startTime = this.timer;
                    this.timer = 0f;
                }
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.frequency = 0.1f;
            this.amountOn = 0.5f;
            this.rendererOnly = true;
            this.realTime = false;
        }
    }
}

