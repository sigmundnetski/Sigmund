namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Vector3), Tooltip("Adds a value to Vector3 Variable.")]
    public class Vector3Add : FsmStateAction
    {
        [RequiredField]
        public FsmVector3 addVector;
        public bool everyFrame;
        public bool perSecond;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmVector3 vector3Variable;

        private void DoVector3Add()
        {
            if (this.perSecond)
            {
                this.vector3Variable.Value += (Vector3) (this.addVector.Value * Time.deltaTime);
            }
            else
            {
                this.vector3Variable.Value += this.addVector.Value;
            }
        }

        public override void OnEnter()
        {
            this.DoVector3Add();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoVector3Add();
        }

        public override void Reset()
        {
            this.vector3Variable = null;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.addVector = vector;
            this.everyFrame = false;
            this.perSecond = false;
        }
    }
}

