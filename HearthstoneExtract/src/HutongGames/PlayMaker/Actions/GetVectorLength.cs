namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Get Vector3 Length."), ActionCategory(ActionCategory.Vector3)]
    public class GetVectorLength : FsmStateAction
    {
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmFloat storeLength;
        public FsmVector3 vector3;

        private void DoVectorLength()
        {
            if ((this.vector3 != null) && (this.storeLength != null))
            {
                this.storeLength.Value = this.vector3.Value.magnitude;
            }
        }

        public override void OnEnter()
        {
            this.DoVectorLength();
            base.Finish();
        }

        public override void Reset()
        {
            this.vector3 = null;
            this.storeLength = null;
        }
    }
}

