namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets the Position of a Game Object and stores it in a Vector3 Variable or each Axis in a Float Variable"), ActionCategory(ActionCategory.Transform)]
    public class GetPosition : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        public Space space;
        [UIHint(UIHint.Variable)]
        public FsmVector3 vector;
        [UIHint(UIHint.Variable)]
        public FsmFloat x;
        [UIHint(UIHint.Variable)]
        public FsmFloat y;
        [UIHint(UIHint.Variable)]
        public FsmFloat z;

        private void DoGetPosition()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Vector3 vector = (this.space != Space.World) ? ownerDefaultTarget.transform.localPosition : ownerDefaultTarget.transform.position;
                this.vector.Value = vector;
                this.x.Value = vector.x;
                this.y.Value = vector.y;
                this.z.Value = vector.z;
            }
        }

        public override void OnEnter()
        {
            this.DoGetPosition();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetPosition();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.vector = null;
            this.x = null;
            this.y = null;
            this.z = null;
            this.space = Space.World;
            this.everyFrame = false;
        }
    }
}

