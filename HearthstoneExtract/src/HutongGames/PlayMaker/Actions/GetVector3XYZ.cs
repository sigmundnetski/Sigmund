namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Get the XYZ channels of a Vector3 Variable and storew them in Float Variables."), ActionCategory(ActionCategory.Vector3)]
    public class GetVector3XYZ : FsmStateAction
    {
        public bool everyFrame;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeX;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeY;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeZ;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmVector3 vector3Variable;

        private void DoGetVector3XYZ()
        {
            if (this.vector3Variable != null)
            {
                if (this.storeX != null)
                {
                    this.storeX.Value = this.vector3Variable.Value.x;
                }
                if (this.storeY != null)
                {
                    this.storeY.Value = this.vector3Variable.Value.y;
                }
                if (this.storeZ != null)
                {
                    this.storeZ.Value = this.vector3Variable.Value.z;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoGetVector3XYZ();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetVector3XYZ();
        }

        public override void Reset()
        {
            this.vector3Variable = null;
            this.storeX = null;
            this.storeY = null;
            this.storeZ = null;
            this.everyFrame = false;
        }
    }
}

