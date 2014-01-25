namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Tests if a GameObject is a Child of another GameObject."), ActionCategory(ActionCategory.Logic)]
    public class GameObjectIsChildOf : FsmStateAction
    {
        [Tooltip("Event to send if GameObject is NOT a child.")]
        public FsmEvent falseEvent;
        [RequiredField, Tooltip("GameObject to test.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Is it a child of this GameObject?"), RequiredField]
        public FsmGameObject isChildOf;
        [Tooltip("Store result in a bool variable"), RequiredField, UIHint(UIHint.Variable)]
        public FsmBool storeResult;
        [Tooltip("Event to send if GameObject is a child.")]
        public FsmEvent trueEvent;

        private void DoIsChildOf(GameObject go)
        {
            if ((go != null) && (this.isChildOf != null))
            {
                bool flag = go.transform.IsChildOf(this.isChildOf.Value.transform);
                this.storeResult.Value = flag;
                base.Fsm.Event(!flag ? this.falseEvent : this.trueEvent);
            }
        }

        public override void OnEnter()
        {
            this.DoIsChildOf(base.Fsm.GetOwnerDefaultTarget(this.gameObject));
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.isChildOf = null;
            this.trueEvent = null;
            this.falseEvent = null;
            this.storeResult = null;
        }
    }
}

