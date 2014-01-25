namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Vector3), Tooltip("Multiplies a Vector3 variable by Time.deltaTime. Useful for frame rate independent motion.")]
    public class Vector3PerSecond : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmVector3 vector3Variable;

        public override void OnEnter()
        {
            this.vector3Variable.Value = (Vector3) (this.vector3Variable.Value * Time.deltaTime);
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.vector3Variable.Value = (Vector3) (this.vector3Variable.Value * Time.deltaTime);
        }

        public override void Reset()
        {
            this.vector3Variable = null;
            this.everyFrame = false;
        }
    }
}

