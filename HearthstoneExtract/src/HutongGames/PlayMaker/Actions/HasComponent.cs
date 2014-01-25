namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Checks if an Object has a Component. Optionally remove the Component on exiting the state.")]
    public class HasComponent : FsmStateAction
    {
        private Component aComponent;
        [RequiredField, UIHint(UIHint.ScriptComponent)]
        public FsmString component;
        public bool everyFrame;
        public FsmEvent falseEvent;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        public FsmBool removeOnExit;
        [UIHint(UIHint.Variable)]
        public FsmBool store;
        public FsmEvent trueEvent;

        private void DoHasComponent(GameObject go)
        {
            this.aComponent = go.GetComponent(this.component.Value);
            base.Fsm.Event((this.aComponent == null) ? this.falseEvent : this.trueEvent);
        }

        public override void OnEnter()
        {
            this.DoHasComponent((this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner);
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnExit()
        {
            if (this.removeOnExit.Value && (this.aComponent != null))
            {
                UnityEngine.Object.Destroy(this.aComponent);
            }
        }

        public override void OnUpdate()
        {
            this.DoHasComponent((this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner);
        }

        public override void Reset()
        {
            this.aComponent = null;
            this.gameObject = null;
            this.trueEvent = null;
            this.falseEvent = null;
            this.component = null;
            this.store = null;
            this.everyFrame = false;
        }
    }
}

