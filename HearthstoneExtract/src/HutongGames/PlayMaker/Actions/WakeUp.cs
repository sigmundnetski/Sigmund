namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Forces a Game Object's Rigid Body to wake up."), ActionCategory(ActionCategory.Physics)]
    public class WakeUp : FsmStateAction
    {
        [CheckForComponent(typeof(Rigidbody)), RequiredField]
        public FsmOwnerDefault gameObject;

        private void DoWakeUp()
        {
            GameObject obj2 = (this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner;
            if ((obj2 != null) && (obj2.rigidbody != null))
            {
                obj2.rigidbody.WakeUp();
            }
        }

        public override void OnEnter()
        {
            this.DoWakeUp();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
        }
    }
}

