namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Lights), Tooltip("Sets the Flare effect used by a Light.")]
    public class SetLightFlare : FsmStateAction
    {
        [CheckForComponent(typeof(Light)), RequiredField]
        public FsmOwnerDefault gameObject;
        public Flare lightFlare;

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
                    light.flare = this.lightFlare;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetLightRange();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.lightFlare = null;
        }
    }
}

