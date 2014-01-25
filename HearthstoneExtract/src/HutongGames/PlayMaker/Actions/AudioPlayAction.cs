namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Plays the Audio Source of a Game Object or plays a one shot clip. Waits for the audio to finish."), ActionCategory("Pegasus Audio")]
    public class AudioPlayAction : FsmStateAction
    {
        [Tooltip("Event to send when the AudioSource finishes playing.")]
        public FsmEvent m_FinishedEvent;
        [CheckForComponent(typeof(AudioSource)), Tooltip("The GameObject with the AudioSource component."), RequiredField]
        public FsmOwnerDefault m_GameObject;
        [Tooltip("Optionally play a One Shot AudioClip."), ObjectType(typeof(AudioClip))]
        public FsmObject m_OneShotClip;
        [Tooltip("Scales the volume of the AudioSource just for this Play call."), HasFloatSlider(0f, 1f)]
        public FsmFloat m_VolumeScale;

        private AudioSource GetSource()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget == null)
            {
                return null;
            }
            return ownerDefaultTarget.audio;
        }

        public override void OnEnter()
        {
            AudioSource source = this.GetSource();
            if (source == null)
            {
                base.Fsm.Event(this.m_FinishedEvent);
                base.Finish();
            }
            else
            {
                AudioClip clip = this.m_OneShotClip.Value as AudioClip;
                if (clip == null)
                {
                    if (!this.m_VolumeScale.IsNone)
                    {
                        SoundManager.Get().SetVolume(source, this.m_VolumeScale.Value);
                    }
                    SoundManager.Get().Play(source);
                }
                else if (this.m_VolumeScale.IsNone)
                {
                    SoundManager.Get().PlayOneShot(source, clip);
                }
                else
                {
                    SoundManager.Get().PlayOneShot(source, clip, this.m_VolumeScale.Value);
                }
                if (!SoundManager.Get().IsActive(source))
                {
                    base.Fsm.Event(this.m_FinishedEvent);
                    base.Finish();
                }
            }
        }

        public override void OnUpdate()
        {
            AudioSource source = this.GetSource();
            if (!SoundManager.Get().IsActive(source))
            {
                base.Fsm.Event(this.m_FinishedEvent);
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            this.m_VolumeScale = 1f;
            this.m_OneShotClip = null;
        }
    }
}

