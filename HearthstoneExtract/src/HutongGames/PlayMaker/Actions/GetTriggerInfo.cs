namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Gets info on the last Trigger event and store in variables."), ActionCategory(ActionCategory.Physics)]
    public class GetTriggerInfo : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        public FsmGameObject gameObjectHit;
        [Tooltip("Useful for triggering different effects. Audio, particles..."), UIHint(UIHint.Variable)]
        public FsmString physicsMaterialName;

        public override void OnEnter()
        {
            this.StoreTriggerInfo();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObjectHit = null;
            this.physicsMaterialName = null;
        }

        private void StoreTriggerInfo()
        {
            if (base.Fsm.TriggerCollider != null)
            {
                this.gameObjectHit.Value = base.Fsm.TriggerCollider.gameObject;
                this.physicsMaterialName.Value = base.Fsm.TriggerCollider.material.name;
            }
        }
    }
}

