namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Tests if a Game Object's Rigid Body is sleeping."), ActionCategory(ActionCategory.Physics)]
    public class IsSleeping : FsmStateAction
    {
        public bool everyFrame;
        public FsmEvent falseEvent;
        [CheckForComponent(typeof(Rigidbody)), RequiredField]
        public FsmOwnerDefault gameObject;
        [UIHint(UIHint.Variable)]
        public FsmBool store;
        public FsmEvent trueEvent;

        private void DoIsSleeping()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.rigidbody != null))
            {
                bool flag = ownerDefaultTarget.rigidbody.IsSleeping();
                this.store.Value = flag;
                base.Fsm.Event(!flag ? this.falseEvent : this.trueEvent);
            }
        }

        public override void OnEnter()
        {
            this.DoIsSleeping();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoIsSleeping();
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

