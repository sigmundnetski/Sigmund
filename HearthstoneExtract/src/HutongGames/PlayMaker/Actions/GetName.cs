namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets the name of a Game Object and stores it in a String Variable."), ActionCategory(ActionCategory.GameObject)]
    public class GetName : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmGameObject gameObject;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmString storeName;

        private void DoGetGameObjectName()
        {
            GameObject obj2 = this.gameObject.Value;
            this.storeName.Value = (obj2 == null) ? string.Empty : obj2.name;
        }

        public override void OnEnter()
        {
            this.DoGetGameObjectName();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetGameObjectName();
        }

        public override void Reset()
        {
            FsmGameObject obj2 = new FsmGameObject {
                UseVariable = true
            };
            this.gameObject = obj2;
            this.storeName = null;
            this.everyFrame = false;
        }
    }
}

