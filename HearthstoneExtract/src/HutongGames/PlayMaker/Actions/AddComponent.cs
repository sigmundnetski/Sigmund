namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Adds a Component to a Game Object. Use this to change the behaviour of objects on the fly. Optionally remove the Component on exiting the state."), ActionCategory(ActionCategory.GameObject)]
    public class AddComponent : FsmStateAction
    {
        private Component addedComponent;
        [RequiredField, Title("Component Type"), Tooltip("The type of Component to add to the Game Object."), UIHint(UIHint.ScriptComponent)]
        public FsmString component;
        [Tooltip("The GameObject to add the Component to."), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("Remove the Component when this State is exited.")]
        public FsmBool removeOnExit;
        [ObjectType(typeof(Component)), Tooltip("Store the component in an Object variable. E.g., to use with Set Property."), UIHint(UIHint.Variable)]
        public FsmObject storeComponent;

        private void DoAddComponent()
        {
            this.addedComponent = base.Fsm.GetOwnerDefaultTarget(this.gameObject).AddComponent(this.component.Value);
            this.storeComponent.Value = this.addedComponent;
            if (this.addedComponent == null)
            {
                this.LogError("Can't add component: " + this.component.Value);
            }
        }

        public override void OnEnter()
        {
            this.DoAddComponent();
            base.Finish();
        }

        public override void OnExit()
        {
            if (this.removeOnExit.Value && (this.addedComponent != null))
            {
                UnityEngine.Object.Destroy(this.addedComponent);
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.component = null;
            this.storeComponent = null;
        }
    }
}

