namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Spot Angle of a Light."), ActionCategory(ActionCategory.Lights)]
    public class SetLightSpotAngle : FsmStateAction
    {
        public bool everyFrame;
        [CheckForComponent(typeof(Light)), RequiredField]
        public FsmOwnerDefault gameObject;
        public FsmFloat lightSpotAngle;

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
                    light.spotAngle = this.lightSpotAngle.Value;
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
            this.lightSpotAngle = 20f;
            this.everyFrame = false;
        }
    }
}

