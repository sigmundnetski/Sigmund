namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Easing Animation - Vector3"), ActionCategory(ActionCategory.AnimateVariables)]
    public class EaseVector3 : EaseFsmAction
    {
        private bool finishInNextStep;
        [RequiredField]
        public FsmVector3 fromValue;
        [RequiredField]
        public FsmVector3 toValue;
        [UIHint(UIHint.Variable)]
        public FsmVector3 vector3Variable;

        public override void OnEnter()
        {
            base.OnEnter();
            base.fromFloats = new float[] { this.fromValue.Value.x, this.fromValue.Value.y, this.fromValue.Value.z };
            base.toFloats = new float[] { this.toValue.Value.x, this.toValue.Value.y, this.toValue.Value.z };
            base.resultFloats = new float[3];
            this.finishInNextStep = false;
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!this.vector3Variable.IsNone && base.isRunning)
            {
                this.vector3Variable.Value = new Vector3(base.resultFloats[0], base.resultFloats[1], base.resultFloats[2]);
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
                if (!this.vector3Variable.IsNone)
                {
                    this.vector3Variable.Value = new Vector3(!base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value.x : this.fromValue.Value.x) : this.toValue.Value.x, !base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value.y : this.fromValue.Value.y) : this.toValue.Value.y, !base.reverse.IsNone ? (!base.reverse.Value ? this.toValue.Value.z : this.fromValue.Value.z) : this.toValue.Value.z);
                }
                this.finishInNextStep = true;
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.vector3Variable = null;
            this.fromValue = null;
            this.toValue = null;
            this.finishInNextStep = false;
        }
    }
}

