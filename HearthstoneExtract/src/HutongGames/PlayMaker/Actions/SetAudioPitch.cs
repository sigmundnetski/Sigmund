namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the Pitch of the Audio Clip played by the AudioSource component on a Game Object."), ActionCategory(ActionCategory.Audio)]
    public class SetAudioPitch : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField, CheckForComponent(typeof(AudioSource))]
        public FsmOwnerDefault gameObject;
        public FsmFloat pitch;

        private void DoSetAudioPitch()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                AudioSource audio = ownerDefaultTarget.audio;
                if ((audio != null) && !this.pitch.IsNone)
                {
                    audio.pitch = this.pitch.Value;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSetAudioPitch();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoSetAudioPitch();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.pitch = 1f;
            this.everyFrame = false;
        }
    }
}

