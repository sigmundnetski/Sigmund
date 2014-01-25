namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Normalizes a Vector3 Variable."), ActionCategory(ActionCategory.Vector3)]
    public class Vector3Normalize : FsmStateAction
    {
        public bool everyFrame;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmVector3 vector3Variable;

        public override void OnEnter()
        {
            this.vector3Variable.Value = this.vector3Variable.Value.normalized;
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.vector3Variable.Value = this.vector3Variable.Value.normalized;
        }

        public override void Reset()
        {
            this.vector3Variable = null;
            this.everyFrame = false;
        }
    }
}

