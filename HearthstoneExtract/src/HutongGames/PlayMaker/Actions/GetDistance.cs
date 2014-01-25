namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Measures the Distance betweens 2 Game Objects and stores the result in a Float Variable.")]
    public class GetDistance : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmFloat storeResult;
        [RequiredField]
        public FsmGameObject target;

        private void DoGetDistance()
        {
            GameObject obj2 = (this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner;
            if (((obj2 != null) && (this.target.Value != null)) && (this.storeResult != null))
            {
                this.storeResult.Value = Vector3.Distance(obj2.transform.position, this.target.Value.transform.position);
            }
        }

        public override void OnEnter()
        {
            this.DoGetDistance();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetDistance();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.target = null;
            this.storeResult = null;
            this.everyFrame = true;
        }
    }
}

