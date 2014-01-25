namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Lights), Tooltip("Set Spot, Directional, or Point Light type.")]
    public class SetLightType : FsmStateAction
    {
        [CheckForComponent(typeof(Light)), RequiredField]
        public FsmOwnerDefault gameObject;
        public LightType lightType;

        private void DoSetLightType()
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
                    light.type = this.lightType;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetLightType();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.lightType = LightType.Point;
        }
    }
}

