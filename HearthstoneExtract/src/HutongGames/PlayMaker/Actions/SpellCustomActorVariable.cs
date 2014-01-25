namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Initialize a spell state, setting a variable that references one of the Actor's game objects by name."), ActionCategory("Pegasus")]
    public class SpellCustomActorVariable : FsmStateAction
    {
        public FsmGameObject m_actorObject;
        public FsmString m_objectName;

        public override void OnEnter()
        {
            if (!this.m_actorObject.IsNone)
            {
                Actor actor = SceneUtils.FindComponentInThisOrParents<Actor>(base.Owner);
                if (actor != null)
                {
                    GameObject obj3 = SceneUtils.FindChildBySubstring(actor.gameObject, this.m_objectName.Value);
                    if (obj3 == null)
                    {
                        Debug.LogError("Could not find object of name " + this.m_objectName + " in actor");
                    }
                    else
                    {
                        this.m_actorObject.Value = obj3;
                    }
                }
            }
            base.Finish();
        }

        public override void OnUpdate()
        {
        }

        public override void Reset()
        {
            this.m_objectName = string.Empty;
            this.m_actorObject = null;
        }
    }
}

