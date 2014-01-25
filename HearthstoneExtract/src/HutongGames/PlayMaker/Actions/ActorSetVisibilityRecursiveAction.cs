namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Sets the visibility on a game object and its children. Will properly Show/Hide Actors in the hierarchy.")]
    public class ActorSetVisibilityRecursiveAction : FsmStateAction
    {
        public FsmOwnerDefault m_GameObject;
        [Tooltip("Don't touch the Actor's SpellTable when setting visibility")]
        public FsmBool m_IgnoreSpells;
        [Tooltip("Should children of the Game Object be affected?")]
        public bool m_IncludeChildren;
        private Dictionary<GameObject, bool> m_initialVisibility = new Dictionary<GameObject, bool>();
        [Tooltip("Resets to the initial visibility once it leaves the state")]
        public bool m_ResetOnExit;
        [Tooltip("Should objects be set to visible or invisible?")]
        public FsmBool m_Visible;

        private void HideActor(Actor actor)
        {
            if (this.m_IgnoreSpells.Value)
            {
                actor.HideForSpells();
            }
            else
            {
                actor.Hide();
            }
        }

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget != null)
            {
                if (this.m_ResetOnExit)
                {
                    this.SaveInitialVisibility(ownerDefaultTarget);
                }
                this.SetVisibility(ownerDefaultTarget);
            }
            base.Finish();
        }

        public override void OnExit()
        {
            if (this.m_ResetOnExit)
            {
                this.RestoreInitialVisibility();
            }
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            this.m_Visible = 0;
            this.m_IgnoreSpells = 0;
            this.m_ResetOnExit = false;
            this.m_IncludeChildren = true;
            this.m_initialVisibility.Clear();
        }

        private void RestoreInitialVisibility()
        {
            foreach (KeyValuePair<GameObject, bool> pair in this.m_initialVisibility)
            {
                GameObject key = pair.Key;
                bool flag = pair.Value;
                Actor component = key.GetComponent<Actor>();
                if (component != null)
                {
                    if (flag)
                    {
                        this.ShowActor(component);
                    }
                    else
                    {
                        this.HideActor(component);
                    }
                    continue;
                }
                key.renderer.enabled = flag;
            }
        }

        private void SaveInitialVisibility(GameObject go)
        {
            Actor component = go.GetComponent<Actor>();
            if (component != null)
            {
                this.m_initialVisibility[go] = component.IsShown();
            }
            else
            {
                UnityEngine.Renderer renderer = go.renderer;
                if (renderer != null)
                {
                    this.m_initialVisibility[go] = renderer.enabled;
                }
                if (this.m_IncludeChildren)
                {
                    IEnumerator enumerator = go.transform.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Transform current = (Transform) enumerator.Current;
                            this.SaveInitialVisibility(current.gameObject);
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

        private void SetVisibility(GameObject go)
        {
            Actor component = go.GetComponent<Actor>();
            if (component != null)
            {
                if (this.m_Visible.Value)
                {
                    this.ShowActor(component);
                }
                else
                {
                    this.HideActor(component);
                }
            }
            else
            {
                UnityEngine.Renderer renderer = go.renderer;
                if (renderer != null)
                {
                    renderer.enabled = this.m_Visible.Value;
                }
                if (this.m_IncludeChildren)
                {
                    IEnumerator enumerator = go.transform.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Transform current = (Transform) enumerator.Current;
                            this.SetVisibility(current.gameObject);
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

        private void ShowActor(Actor actor)
        {
            if (this.m_IgnoreSpells.Value)
            {
                actor.ShowForSpells();
            }
            else
            {
                actor.Show();
            }
        }
    }
}

