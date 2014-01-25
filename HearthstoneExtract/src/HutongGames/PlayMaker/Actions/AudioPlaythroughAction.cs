namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus Audio"), Tooltip("Plays the Audio Clip in the Audio Source on a Game Object or plays a one shot clip. Does not wait for the audio to finish.")]
    public class AudioPlaythroughAction : FsmStateAction
    {
        [Tooltip("Event to send when the AudioClip finished playing.")]
        public FsmEvent m_FinishedEvent;
        [CheckForComponent(typeof(AudioSource)), Tooltip("The GameObject with the AudioSource component."), RequiredField]
        public FsmOwnerDefault m_GameObject;
        [ObjectType(typeof(AudioClip)), Tooltip("Optionally play a one shot AudioClip.")]
        public FsmObject m_OneShotClip;
        [HasFloatSlider(0f, 1f), Tooltip("Scales the volume of the AudioSource just for this Play call.")]
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

