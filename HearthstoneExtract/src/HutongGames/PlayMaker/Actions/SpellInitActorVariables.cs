namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Initialize a spell state, setting variables that reference the parent actor and its contents."), ActionCategory("Pegasus")]
    public class SpellInitActorVariables : FsmStateAction
    {
        public FsmGameObject m_actorObject;
        public FsmGameObject m_rootObject;
        public FsmGameObject m_rootObjectMesh;

        public override void OnEnter()
        {
            Actor actor = SceneUtils.FindComponentInThisOrParents<Actor>(base.Owner);
            if (actor == null)
            {
                base.Finish();
            }
            else
            {
                GameObject gameObject = actor.gameObject;
                if (!this.m_actorObject.IsNone)
                {
                    this.m_actorObject.Value = gameObject;
                }
                if (!this.m_rootObject.IsNone)
                {
                    this.m_rootObject.Value = actor.GetRootObject();
                }
                if (!this.m_rootObjectMesh.IsNone)
                {
                    this.m_rootObjectMesh.Value = actor.GetMeshRenderer().gameObject;
                }
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
        }

        public override void Reset()
        {
        }
    }
}

