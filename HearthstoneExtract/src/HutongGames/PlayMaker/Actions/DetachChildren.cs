namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Unparents all children from the Game Object."), ActionCategory(ActionCategory.GameObject)]
    public class DetachChildren : FsmStateAction
    {
        [Tooltip("GameObject to unparent children from."), RequiredField]
        public FsmOwnerDefault gameObject;

        private static void DoDetachChildren(GameObject go)
        {
            if (go != null)
            {
                go.transform.DetachChildren();
            }
        }

        public override void OnEnter()
        {
            DoDetachChildren(base.Fsm.GetOwnerDefaultTarget(this.gameObject));
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
        }
    }
}

