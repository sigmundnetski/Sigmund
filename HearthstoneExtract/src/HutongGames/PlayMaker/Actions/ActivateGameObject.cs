namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using UnityEngine;

    [Tooltip("Activates/deactivates a Game Object. Use this to hide/show areas, or enable/disable many Behaviours at once."), ActionCategory(ActionCategory.GameObject)]
    public class ActivateGameObject : FsmStateAction
    {
        [Tooltip("Check to activate, uncheck to deactivate Game Object."), RequiredField]
        public FsmBool activate;
        private GameObject activatedGameObject;
        [Tooltip("Repeat this action every frame. Useful if Activate changes over time.")]
        public bool everyFrame;
        [Tooltip("The GameObject to activate/deactivate."), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("Recursively activate/deactivate all children.")]
        public FsmBool recursive;
        [Tooltip("Reset the game objects when exiting this state. Useful if you want an object to be active only while this state is active.\nNote: Only applies to the last Game Object activated/deactivated (won't work if Game Object changes).")]
        public bool resetOnExit;

        private void DoActivateGameObject()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                if (this.recursive.Value)
                {
                    this.SetActiveRecursively(ownerDefaultTarget, this.activate.Value);
                }
                else
                {
                    ownerDefaultTarget.SetActive(this.activate.Value);
                }
                this.activatedGameObject = ownerDefaultTarget;
            }
        }

        public override void OnEnter()
        {
            this.DoActivateGameObject();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnExit()
        {
            if ((this.activatedGameObject != null) && this.resetOnExit)
            {
                if (this.recursive.Value)
                {
                    this.SetActiveRecursively(this.activatedGameObject, this.activate.Value);
                }
                else
                {
                    this.activatedGameObject.SetActive(!this.activate.Value);
                }
            }
        }

        public override void OnUpdate()
        {
            this.DoActivateGameObject();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.activate = 1;
            this.recursive = 1;
            this.resetOnExit = false;
            this.everyFrame = false;
        }

        public void SetActiveRecursively(GameObject go, bool state)
        {
            go.SetActive(state);
            IEnumerator enumerator = go.transform.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Transform current = (Transform) enumerator.Current;
                    this.SetActiveRecursively(current.gameObject, state);
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                }
                disposable.Dispose();
            }
        }
    }
}

