namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus Audio"), Tooltip("Randomly sets the pitch of an AudioSource on a Game Object.")]
    public class AudioSetRandomPitchAction : FsmStateAction
    {
        public bool m_EveryFrame;
        [RequiredField, CheckForComponent(typeof(AudioSource))]
        public FsmOwnerDefault m_GameObject;
        [HasFloatSlider(-3f, 3f)]
        public FsmFloat m_MaxPitch;
        [HasFloatSlider(-3f, 3f)]
        public FsmFloat m_MinPitch;
        private float m_pitch;

        private void ChoosePitch()
        {
            float min = !this.m_MinPitch.IsNone ? this.m_MinPitch.Value : 1f;
            float max = !this.m_MaxPitch.IsNone ? this.m_MaxPitch.Value : 1f;
            this.m_pitch = UnityEngine.Random.Range(min, max);
        }

        public override void OnEnter()
        {
            this.ChoosePitch();
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
            this.m_MinPitch = 1f;
            this.m_MaxPitch = 1f;
            this.m_EveryFrame = false;
        }

        private void UpdatePitch()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget != null)
            {
                AudioSource audio = ownerDefaultTarget.audio;
                if (audio != null)
                {
                    SoundManager.Get().SetPitch(audio, this.m_pitch);
                }
            }
        }
    }
}

