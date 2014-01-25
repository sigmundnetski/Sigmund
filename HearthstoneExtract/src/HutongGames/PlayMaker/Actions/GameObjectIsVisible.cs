namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Tests if a Game Object is visible."), ActionCategory(ActionCategory.Logic)]
    public class GameObjectIsVisible : FsmStateAction
    {
        public bool everyFrame;
        [Tooltip("Event to send if the GameObject is NOT visible.")]
        public FsmEvent falseEvent;
        [Tooltip("The GameObject to test."), CheckForComponent(typeof(UnityEngine.Renderer)), RequiredField]
        public FsmOwnerDefault gameObject;
        [UIHint(UIHint.Variable), Tooltip("Store the result in a bool variable.")]
        public FsmBool storeResult;
        [Tooltip("Event to send if the GameObject is visible.")]
        public FsmEvent trueEvent;

        private void DoIsVisible()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.renderer != null))
            {
                bool isVisible = ownerDefaultTarget.renderer.isVisible;
                this.storeResult.Value = isVisible;
                base.Fsm.Event(!isVisible ? this.falseEvent : this.trueEvent);
            }
        }

        public override void OnEnter()
        {
            this.DoIsVisible();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoIsVisible();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.trueEvent = null;
            this.falseEvent = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}

