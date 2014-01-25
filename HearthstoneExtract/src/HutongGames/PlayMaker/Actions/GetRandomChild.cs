namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets a Random Child of a Game Object."), ActionCategory(ActionCategory.GameObject)]
    public class GetRandomChild : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmGameObject storeResult;

        private void DoGetRandomChild()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                int childCount = ownerDefaultTarget.transform.childCount;
                if (childCount != 0)
                {
                    this.storeResult.Value = ownerDefaultTarget.transform.GetChild(UnityEngine.Random.Range(0, childCount)).gameObject;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoGetRandomChild();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.storeResult = null;
        }
    }
}

