namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Range of a Light."), ActionCategory(ActionCategory.Lights)]
    public class SetLightRange : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField, CheckForComponent(typeof(Light))]
        public FsmOwnerDefault gameObject;
        public FsmFloat lightRange;

        private void DoSetLightRange()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Light light = ownerDefaultTarget.light;
                if (light == null)
                {
                    this.LogError("Missing Light Component!");
                }
                else
                {
                    light.range = this.lightRange.Value;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetLightRange();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetLightRange();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.lightRange = 20f;
            this.everyFrame = false;
        }
    }
}

