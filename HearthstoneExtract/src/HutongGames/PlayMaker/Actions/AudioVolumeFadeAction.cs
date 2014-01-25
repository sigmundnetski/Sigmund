namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus Audio"), Tooltip("Fades an Audio Source component's volume towards a target value.")]
    public class AudioVolumeFadeAction : FsmStateAction
    {
        private AudioSource m_audio;
        private float m_currentTime;
        private float m_endTime;
        [RequiredField]
        public FsmFloat m_FadeTime;
        [CheckForComponent(typeof(AudioSource)), RequiredField]
        public FsmOwnerDefault m_GameObject;
        [Tooltip("Use real seconds to hit the target volume. Useful if the game speed is scaled.")]
        public FsmBool m_RealTime;
        private float m_startTime;
        private float m_startVolume;
        [Tooltip("Stop the audio source when the target volume is reached.")]
        public FsmBool m_StopWhenDone;
        [RequiredField]
        public FsmFloat m_TargetVolume;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget == null)
            {
                base.Finish();
            }
            else
            {
                this.m_audio = ownerDefaultTarget.audio;
                if (this.m_audio == null)
                {
                    base.Finish();
                }
                else if (this.m_FadeTime.Value <= float.Epsilon)
                {
                    base.Finish();
                }
                else
                {
                    this.m_startVolume = SoundManager.Get().GetVolume(this.m_audio);
                    this.m_startTime = FsmTime.RealtimeSinceStartup;
                    this.m_currentTime = this.m_startTime;
                    this.m_endTime = this.m_startTime + this.m_FadeTime.Value;
                    SoundManager.Get().SetVolume(this.m_audio, this.m_startVolume);
                }
            }
        }

        public override void OnUpdate()
        {
            if (this.m_RealTime.Value)
            {
                this.m_currentTime = FsmTime.RealtimeSinceStartup - this.m_startTime;
            }
            else
            {
                this.m_currentTime += UnityEngine.Time.deltaTime;
            }
            if (this.m_currentTime < this.m_endTime)
            {
                float t = (this.m_currentTime - this.m_startTime) / this.m_FadeTime.Value;
                float volume = Mathf.Lerp(this.m_startVolume, this.m_TargetVolume.Value, t);
                SoundManager.Get().SetVolume(this.m_audio, volume);
            }
            else
            {
                SoundManager.Get().SetVolume(this.m_audio, this.m_TargetVolume.Value);
                if (this.m_StopWhenDone.Value)
                {
                    SoundManager.Get().Stop(this.m_audio);
                }
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            this.m_FadeTime = 1f;
            this.m_TargetVolume = 0f;
            this.m_StopWhenDone = 1;
            this.m_RealTime = 0;
        }
    }
}

