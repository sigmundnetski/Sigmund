namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Sets how subsequent events sent in this state are handled."), ActionCategory(ActionCategory.StateMachine)]
    public class FsmEventOptions : FsmStateAction
    {
        public FsmBool broadcastToAll;
        public FsmString fsmName;
        public FsmBool sendToChildren;
        public PlayMakerFSM sendToFsmComponent;
        public FsmGameObject sendToGameObject;

        public override void OnUpdate()
        {
        }

        public override void Reset()
        {
            this.sendToFsmComponent = null;
            this.sendToGameObject = null;
            this.fsmName = string.Empty;
            this.sendToChildren = 0;
            this.broadcastToAll = 0;
        }
    }
}

