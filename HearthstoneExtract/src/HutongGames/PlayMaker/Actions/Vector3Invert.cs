namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Vector3), Tooltip("Reverses the direction of a Vector3 Variable. Same as multiplying by -1.")]
    public class Vector3Invert : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmVector3 vector3Variable;

        public override void OnEnter()
        {
            this.vector3Variable.Value = (Vector3) (this.vector3Variable.Value * -1f);
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.vector3Variable.Value = (Vector3) (this.vector3Variable.Value * -1f);
        }

        public override void Reset()
        {
            this.vector3Variable = null;
            this.everyFrame = false;
        }
    }
}

