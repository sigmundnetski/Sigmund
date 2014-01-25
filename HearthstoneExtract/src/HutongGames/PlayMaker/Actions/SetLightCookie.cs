namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Texture projected by a Light."), ActionCategory(ActionCategory.Lights)]
    public class SetLightCookie : FsmStateAction
    {
        [CheckForComponent(typeof(Light)), RequiredField]
        public FsmOwnerDefault gameObject;
        public FsmTexture lightCookie;

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
                    light.cookie = this.lightCookie.Value;
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
            this.lightCookie = null;
        }
    }
}

