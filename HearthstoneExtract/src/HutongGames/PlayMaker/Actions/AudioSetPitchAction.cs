namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the pitch of an AudioSource on a Game Object."), ActionCategory("Pegasus Audio")]
    public class AudioSetPitchAction : FsmStateAction
    {
        public bool m_EveryFrame;
        [CheckForComponent(typeof(AudioSource)), RequiredField]
        public FsmOwnerDefault m_GameObject;
        [HasFloatSlider(-3f, 3f)]
        public FsmFloat m_Pitch;

        public override void OnEnter()
        {
            this.UpdatePitch();
            if (!this.m_EveryFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.UpdatePitch();
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            this.m_Pitch = 1f;
            this.m_EveryFrame = false;
        }

        private void UpdatePitch()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget != null)
            {
                AudioSource audio = ownerDefaultTarget.audio;
                if ((audio != null) && !this.m_Pitch.IsNone)
                {
                    SoundManager.Get().SetPitch(audio, this.m_Pitch.Value);
                }
            }
        }
    }
}

