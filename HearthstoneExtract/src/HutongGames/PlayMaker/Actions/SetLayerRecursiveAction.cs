namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Sets the layer on a game object and its children.")]
    public class SetLayerRecursiveAction : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault gameObject;
        public bool includeChildren;
        [Tooltip("Layer number")]
        public GameLayer layer;
        private Dictionary<GameObject, GameLayer> m_initialLayer = new Dictionary<GameObject, GameLayer>();
        [Tooltip("Resets to the initial layer once\nit leaves the state")]
        public bool resetOnExit;

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
                    Transform[] componentsInChildren = ownerDefaultTarget.GetComponentsInChildren<Transform>();
                    if (componentsInChildren != null)
                    {
                        foreach (Transform transform in componentsInChildren)
                        {
                            this.m_initialLayer[transform.gameObject] = (GameLayer) transform.gameObject.layer;
                            transform.gameObject.layer = (int) this.layer;
                        }
                    }
                }
                else
                {
                    Transform component = ownerDefaultTarget.GetComponent<Transform>();
                    if (component != null)
                    {
                        this.m_initialLayer[component.gameObject] = (GameLayer) component.gameObject.layer;
                        component.gameObject.layer = (int) this.layer;
                    }
                }
                base.Finish();
            }
        }

        public override void OnExit()
        {
            if (this.resetOnExit)
            {
                foreach (KeyValuePair<GameObject, GameLayer> pair in this.m_initialLayer)
                {
                    GameObject key = pair.Key;
                    if (key != null)
                    {
                        key.layer = pair.Value;
                    }
                }
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.layer = GameLayer.Default;
            this.resetOnExit = true;
            this.includeChildren = false;
            this.m_initialLayer.Clear();
        }
    }
}

