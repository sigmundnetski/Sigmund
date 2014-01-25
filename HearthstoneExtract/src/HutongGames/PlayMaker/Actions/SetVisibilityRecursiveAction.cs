namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Tooltip("Sets the visibility on a game object and its children."), ActionCategory(ActionCategory.Material)]
    public class SetVisibilityRecursiveAction : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault gameObject;
        public bool includeChildren;
        private Dictionary<UnityEngine.Renderer, bool> m_initialVisibility = new Dictionary<UnityEngine.Renderer, bool>();
        [Tooltip("Resets to the initial visibility once\nit leaves the state")]
        public bool resetOnExit;
        [Tooltip("Should the objects be set to visible or invisible?")]
        public FsmBool visible;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget == null)
            {
                base.Finish();
            }
            else
            {
                if (this.includeChildren)
                {
                    UnityEngine.Renderer[] componentsInChildren = ownerDefaultTarget.GetComponentsInChildren<UnityEngine.Renderer>();
                    if (componentsInChildren != null)
                    {
                        foreach (UnityEngine.Renderer renderer in componentsInChildren)
                        {
                            this.m_initialVisibility[renderer] = renderer.enabled;
                            renderer.enabled = this.visible.Value;
                        }
                    }
                }
                else
                {
                    UnityEngine.Renderer component = ownerDefaultTarget.GetComponent<UnityEngine.Renderer>();
                    if (component != null)
                    {
                        this.m_initialVisibility[component] = component.enabled;
                        component.enabled = this.visible.Value;
                    }
                }
                base.Finish();
            }
        }

        public override void OnExit()
        {
            if (this.resetOnExit)
            {
                foreach (KeyValuePair<UnityEngine.Renderer, bool> pair in this.m_initialVisibility)
                {
                    UnityEngine.Renderer key = pair.Key;
                    if (key != null)
                    {
                        key.enabled = pair.Value;
                    }
                }
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.visible = 0;
            this.resetOnExit = true;
            this.includeChildren = false;
            this.m_initialVisibility.Clear();
        }
    }
}

