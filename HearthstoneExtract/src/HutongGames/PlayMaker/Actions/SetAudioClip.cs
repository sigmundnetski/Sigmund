namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Audio Clip played by the AudioSource component on a Game Object."), ActionCategory(ActionCategory.Audio)]
    public class SetAudioClip : FsmStateAction
    {
        [Tooltip("The AudioClip to set."), ObjectType(typeof(AudioClip))]
        public FsmObject audioClip;
        [RequiredField, CheckForComponent(typeof(AudioSource)), Tooltip("The GameObject with the AudioSource component.")]
        public FsmOwnerDefault gameObject;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                AudioSource audio = ownerDefaultTarget.audio;
                if (audio != null)
                {
                    audio.clip = this.audioClip.Value as AudioClip;
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.audioClip = null;
        }
    }
}

