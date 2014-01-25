namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Physics), Tooltip("Gets the Speed of a Game Object and stores it in a Float Variable. NOTE: The Game Object must have a rigid body.")]
    public class GetSpeed : FsmStateAction
    {
        public bool everyFrame;
        [CheckForComponent(typeof(Rigidbody)), RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmFloat storeResult;

        private void DoGetSpeed()
        {
            if (this.storeResult != null)
            {
                GameObject obj2 = (this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner;
                if ((obj2 != null) && (obj2.rigidbody != null))
                {
                    Vector3 velocity = obj2.rigidbody.velocity;
                    this.storeResult.Value = velocity.magnitude;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoGetSpeed();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetSpeed();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}

