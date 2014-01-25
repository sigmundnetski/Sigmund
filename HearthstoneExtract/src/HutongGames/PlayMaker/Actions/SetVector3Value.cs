namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Sets the value of a Vector3 Variable."), ActionCategory(ActionCategory.Vector3)]
    public class SetVector3Value : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmVector3 vector3Value;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmVector3 vector3Variable;

        public override void OnEnter()
        {
            this.vector3Variable.Value = this.vector3Value.Value;
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.vector3Variable.Value = this.vector3Value.Value;
        }

        public override void Reset()
        {
            this.vector3Variable = null;
            this.vector3Value = null;
            this.everyFrame = false;
        }
    }
}

