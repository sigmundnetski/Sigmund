namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Gets a Game Object's Layer and stores it in an Int Variable."), ActionCategory(ActionCategory.GameObject)]
    public class GetLayer : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmGameObject gameObject;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmInt storeResult;

        private void DoGetLayer()
        {
            if (this.gameObject.Value != null)
            {
                this.storeResult.Value = this.gameObject.Value.layer;
            }
        }

        public override void OnEnter()
        {
            this.DoGetLayer();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetLayer();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}

