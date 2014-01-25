namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Vector3), Tooltip("Adds a XYZ values to Vector3 Variable.")]
    public class Vector3AddXYZ : FsmStateAction
    {
        public FsmFloat addX;
        public FsmFloat addY;
        public FsmFloat addZ;
        public bool everyFrame;
        public bool perSecond;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmVector3 vector3Variable;

        private void DoVector3AddXYZ()
        {
            Vector3 vector = new Vector3(this.addX.Value, this.addY.Value, this.addZ.Value);
            if (this.perSecond)
            {
                this.vector3Variable.Value += (Vector3) (vector * Time.deltaTime);
            }
            else
            {
                this.vector3Variable.Value += vector;
            }
        }

        public override void OnEnter()
        {
            this.DoVector3AddXYZ();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoVector3AddXYZ();
        }

        public override void Reset()
        {
            this.vector3Variable = null;
            this.addX = 0f;
            this.addY = 0f;
            this.addZ = 0f;
            this.everyFrame = false;
            this.perSecond = false;
        }
    }
}

