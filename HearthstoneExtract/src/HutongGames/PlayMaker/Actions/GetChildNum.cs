namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets the Child of a GameObject by Index.\nE.g., O to get the first child. HINT: Use this with an integer variable to iterate through children."), ActionCategory(ActionCategory.GameObject)]
    public class GetChildNum : FsmStateAction
    {
        [Tooltip("The index of the child to find."), RequiredField]
        public FsmInt childIndex;
        [RequiredField, Tooltip("The GameObject to search.")]
        public FsmOwnerDefault gameObject;
        [RequiredField, Tooltip("Store the child in a GameObject variable."), UIHint(UIHint.Variable)]
        public FsmGameObject store;

        private GameObject DoGetChildNum(GameObject go)
        {
            return ((go != null) ? go.transform.GetChild(this.childIndex.Value % go.transform.childCount).gameObject : null);
        }

        public override void OnEnter()
        {
            this.store.Value = this.DoGetChildNum(base.Fsm.GetOwnerDefaultTarget(this.gameObject));
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.childIndex = 0;
            this.store = null;
        }
    }
}

