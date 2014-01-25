namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Mass of a Game Object's Rigid Body."), ActionCategory(ActionCategory.Physics)]
    public class SetMass : FsmStateAction
    {
        [RequiredField, CheckForComponent(typeof(Rigidbody))]
        public FsmOwnerDefault gameObject;
        [RequiredField, HasFloatSlider(0.1f, 10f)]
        public FsmFloat mass;

        private void DoSetMass()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.rigidbody != null))
            {
                ownerDefaultTarget.rigidbody.mass = this.mass.Value;
            }
        }

        public override void OnEnter()
        {
            this.DoSetMass();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.mass = 1f;
        }
    }
}

