namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Show or Hide an Actor without messing up the game.")]
    public class ActorSetVisibility : ActorAction
    {
        public FsmGameObject m_ActorObject;
        [Tooltip("Don't touch the Actor's SpellTable when setting visibility")]
        public FsmBool m_IgnoreSpells;
        protected bool m_initialVisibility;
        [Tooltip("Resets to the initial visibility once\nit leaves the state")]
        public bool m_ResetOnExit;
        [Tooltip("Should the Actor be set to visible or invisible?")]
        public FsmBool m_Visible;

        protected override GameObject GetActorOwner()
        {
            return this.m_ActorObject.Value;
        }

        public void HideActor()
        {
            if (this.m_IgnoreSpells.Value)
            {
                base.m_actor.HideForSpells();
            }
            else
            {
                base.m_actor.Hide();
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (base.m_actor == null)
            {
                base.Finish();
            }
            else
            {
                this.m_initialVisibility = base.m_actor.IsShown();
                if (this.m_Visible.Value)
                {
                    this.ShowActor();
                }
                else
                {
                    this.HideActor();
                }
                base.Finish();
            }
        }

        public override void OnExit()
        {
            if (this.m_ResetOnExit)
            {
                if (this.m_initialVisibility)
                {
                    this.ShowActor();
                }
                else
                {
                    this.HideActor();
                }
            }
        }

        public override void Reset()
        {
            this.m_ActorObject = null;
            this.m_Visible = 0;
            this.m_IgnoreSpells = 0;
            this.m_ResetOnExit = false;
        }

        public void ShowActor()
        {
            if (this.m_IgnoreSpells.Value)
            {
                base.m_actor.ShowForSpells();
            }
            else
            {
                base.m_actor.Show();
            }
        }
    }
}

