namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Audio), Tooltip("Mute/unmute the Audio Clip played by an Audio Source component on a Game Object.")]
    public class AudioMute : FsmStateAction
    {
        [CheckForComponent(typeof(AudioSource)), RequiredField, Tooltip("The GameObject with an Audio Source component.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Check to mute, uncheck to unmute."), RequiredField]
        public FsmBool mute;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                AudioSource audio = ownerDefaultTarget.audio;
                if (audio != null)
                {
                    audio.mute = this.mute.Value;
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.mute = 0;
        }
    }
}

