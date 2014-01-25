namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Adds a Script to a Game Object. Use this to change the behaviour of objects on the fly. Optionally remove the Script on exiting the state."), ActionCategory(ActionCategory.ScriptControl)]
    public class AddScript : FsmStateAction
    {
        private Component addedComponent;
        [Tooltip("The GameObject to add the script to."), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("Remove the script from the GameObject when this State is exited.")]
        public FsmBool removeOnExit;
        [Tooltip("The Script to add to the GameObject."), RequiredField, UIHint(UIHint.ScriptComponent)]
        public FsmString script;

        private void DoAddComponent(GameObject go)
        {
            this.addedComponent = go.AddComponent(this.script.Value);
            if (this.addedComponent == null)
            {
                this.LogError("Can't add script: " + this.script.Value);
            }
        }

        public override void OnEnter()
        {
            this.DoAddComponent((this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner);
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
            this.script = null;
        }
    }
}

