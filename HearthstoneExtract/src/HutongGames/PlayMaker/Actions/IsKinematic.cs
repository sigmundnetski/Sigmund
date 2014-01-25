namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Tests if a Game Object's Rigid Body is Kinematic."), ActionCategory(ActionCategory.Physics)]
    public class IsKinematic : FsmStateAction
    {
        public bool everyFrame;
        public FsmEvent falseEvent;
        [CheckForComponent(typeof(Rigidbody)), RequiredField]
        public FsmOwnerDefault gameObject;
        [UIHint(UIHint.Variable)]
        public FsmBool store;
        public FsmEvent trueEvent;

        private void DoIsKinematic()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.rigidbody != null))
            {
                bool isKinematic = ownerDefaultTarget.rigidbody.isKinematic;
                this.store.Value = isKinematic;
                base.Fsm.Event(!isKinematic ? this.falseEvent : this.trueEvent);
            }
        }

        public override void OnEnter()
        {
            this.DoIsKinematic();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoIsKinematic();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.trueEvent = null;
            this.falseEvent = null;
            this.store = null;
            this.everyFrame = false;
        }
    }
}

