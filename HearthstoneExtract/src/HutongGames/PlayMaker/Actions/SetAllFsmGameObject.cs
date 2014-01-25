namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Set the value of a Game Object Variable in another All FSM. Accept null reference"), ActionCategory(ActionCategory.StateMachine)]
    public class SetAllFsmGameObject : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmOwnerDefault gameObject;

        private void DoSetFsmGameObject()
        {
        }

        public override void OnEnter()
        {
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void Reset()
        {
        }
    }
}

