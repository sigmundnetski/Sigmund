namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Easing Animation - Rect."), ActionCategory("AnimateVariables")]
    public class EaseRect : EaseFsmAction
    {
        private bool finishInNextStep;
        [RequiredField]
        public FsmRect fromValue;
        [UIHint(UIHint.Variable)]
        public FsmRect rectVariable;
        [RequiredField]
        public FsmRect toValue;

        public override void OnEnter()
        {
            base.OnEnter();
            base.fromFloats = new float[] { this.fromValue.Value.x, this.fromValue.Value.y, this.fromValue.Value.width, this.fromValue.Value.height };
            base.toFloats = new float[] { this.toValue.Value.x, this.toValue.Value.y, this.toValue.Value.width, this.toValue.Value.height };
            base.resultFloats = new float[4];
            this.finishInNextStep = false;
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!this.rectVariable.IsNone && base.isRunning)
            {
                this.rectVariable.Value = new Rect(base.resultFloats[0], base.resultFloats[1], base.resultFloats[2], base.resultFloats[3]);
            }
            if (this.finishInNextStep)
            {
                base.Finish();
                if (base.finishEvent != null)
                {
                    base.Fsm.Event(base.finishEvent);
                }
            }
            if (base.finishAction && !this.finishInNextStep)
            {
                if (!this.rectVariable.IsNone)
                {
                    this.rectVariable.Value = new Rect(!base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value.x : this.fromValue.Value.x) : this.toValue.Value.x, !base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value.y : this.fromValue.Value.y) : this.toValue.Value.y, !base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value.width : this.fromValue.Value.width) : this.toValue.Value.width, !base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value.height : this.fromValue.Value.height) : this.toValue.Value.height);
                }
                this.finishInNextStep = true;
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.rectVariable = null;
            this.fromValue = null;
            this.toValue = null;
            this.finishInNextStep = false;
        }
    }
}

