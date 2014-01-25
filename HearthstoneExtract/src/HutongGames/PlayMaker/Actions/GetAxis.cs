namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets the value of the specified Input Axis and stores it in a Float Variable. See Unity Input Manager docs."), ActionCategory(ActionCategory.Input)]
    public class GetAxis : FsmStateAction
    {
        [Tooltip("The name of the axis. Set in the Unity Input Manager."), RequiredField]
        public FsmString axisName;
        [Tooltip("Repeat every frame. Typically this would be set to True.")]
        public bool everyFrame;
        [Tooltip("Axis values are in the range -1 to 1. Use the multiplier to set a larger range.")]
        public FsmFloat multiplier;
        [Tooltip("Store the result in a float variable."), RequiredField, UIHint(UIHint.Variable)]
        public FsmFloat store;

        private void DoGetAxis()
        {
            float axis = Input.GetAxis(this.axisName.Value);
            if (!this.multiplier.IsNone)
            {
                axis *= this.multiplier.Value;
            }
            this.store.Value = axis;
        }

        public override void OnEnter()
        {
            this.DoGetAxis();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetAxis();
        }

        public override void Reset()
        {
            this.axisName = string.Empty;
            this.multiplier = 1f;
            this.store = null;
            this.everyFrame = true;
        }
    }
}

