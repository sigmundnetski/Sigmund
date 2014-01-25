namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Gets the Game Object that owns the FSM and stores it in a game object variable."), ActionCategory(ActionCategory.GameObject)]
    public class GetOwner : FsmStateAction
    {
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmGameObject storeGameObject;

        public override void OnEnter()
        {
            this.storeGameObject.Value = base.Owner;
            base.Finish();
        }

        public override void Reset()
        {
            this.storeGameObject = null;
        }
    }
}

