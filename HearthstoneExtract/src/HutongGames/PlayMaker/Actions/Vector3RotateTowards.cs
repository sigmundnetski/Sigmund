namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Rotates a Vector3 direction from Current towards Target."), ActionCategory(ActionCategory.Vector3)]
    public class Vector3RotateTowards : FsmStateAction
    {
        [RequiredField]
        public FsmVector3 currentDirection;
        [Tooltip("Rotation speed in degrees per second"), RequiredField]
        public FsmFloat rotateSpeed;
        [RequiredField]
        public FsmVector3 targetDirection;

        public override void OnUpdate()
        {
            this.currentDirection.Value = Vector3.RotateTowards(this.currentDirection.Value, this.targetDirection.Value, (this.rotateSpeed.Value * 0.01745329f) * Time.deltaTime, 1000f);
        }

        public override void Reset()
        {
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.currentDirection = vector;
            vector = new FsmVector3 {
                UseVariable = true
            };
            this.targetDirection = vector;
            this.rotateSpeed = 360f;
        }
    }
}

