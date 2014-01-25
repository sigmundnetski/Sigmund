namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets the pressed state of the specified Button and stores it in a Bool Variable. See Unity Input Manager docs."), ActionCategory(ActionCategory.Input)]
    public class GetButton : FsmStateAction
    {
        [Tooltip("The name of the button. Set in the Unity Input Manager."), RequiredField]
        public FsmString buttonName;
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        [RequiredField, Tooltip("Store the result in a bool variable."), UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        private void DoGetButton()
        {
            this.storeResult.Value = Input.GetButton(this.buttonName.Value);
        }

        public override void OnEnter()
        {
            this.DoGetButton();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetButton();
        }

        public override void Reset()
        {
            this.buttonName = "Fire1";
            this.storeResult = null;
            this.everyFrame = true;
        }
    }
}

