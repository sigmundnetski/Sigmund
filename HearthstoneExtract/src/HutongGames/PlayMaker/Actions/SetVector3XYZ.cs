namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Vector3), Tooltip("Sets the XYZ channels of a Vector3 Variable. To leave any channel unchanged, set variable to 'None'.")]
    public class SetVector3XYZ : FsmStateAction
    {
        public bool everyFrame;
        [UIHint(UIHint.Variable)]
        public FsmVector3 vector3Value;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmVector3 vector3Variable;
        public FsmFloat x;
        public FsmFloat y;
        public FsmFloat z;

        private void DoSetVector3XYZ()
        {
            if (this.vector3Variable != null)
            {
                Vector3 vector = this.vector3Variable.Value;
                if (!this.vector3Value.IsNone)
                {
                    vector = this.vector3Value.Value;
                }
                if (!this.x.IsNone)
                {
                    vector.x = this.x.Value;
                }
                if (!this.y.IsNone)
                {
                    vector.y = this.y.Value;
                }
                if (!this.z.IsNone)
                {
                    vector.z = this.z.Value;
                }
                this.vector3Variable.Value = vector;
            }
        }

        public override void OnEnter()
        {
            this.DoSetVector3XYZ();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetVector3XYZ();
        }

        public override void Reset()
        {
            this.vector3Variable = null;
            this.vector3Value = null;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.x = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.y = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.z = num;
            this.everyFrame = false;
        }
    }
}

