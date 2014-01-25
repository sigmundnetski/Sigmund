namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Clamps the Magnitude of Vector3 Variable."), ActionCategory(ActionCategory.Vector3)]
    public class Vector3ClampMagnitude : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmFloat maxLength;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmVector3 vector3Variable;

        private void DoVector3ClampMagnitude()
        {
            this.vector3Variable.Value = Vector3.ClampMagnitude(this.vector3Variable.Value, this.maxLength.Value);
        }

        public override void OnEnter()
        {
            this.DoVector3ClampMagnitude();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoVector3ClampMagnitude();
        }

        public override void Reset()
        {
            this.vector3Variable = null;
            this.maxLength = null;
            this.everyFrame = false;
        }
    }
}

