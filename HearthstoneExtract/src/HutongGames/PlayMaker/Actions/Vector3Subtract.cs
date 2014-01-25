namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Subtracts a Vector3 value from a Vector3 variable."), ActionCategory(ActionCategory.Vector3)]
    public class Vector3Subtract : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmVector3 subtractVector;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmVector3 vector3Variable;

        public override void OnEnter()
        {
            this.vector3Variable.Value -= this.subtractVector.Value;
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.vector3Variable.Value -= this.subtractVector.Value;
        }

        public override void Reset()
        {
            this.vector3Variable = null;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.subtractVector = vector;
            this.everyFrame = false;
        }
    }
}

