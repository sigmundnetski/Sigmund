namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Plays the Audio Clip set with Set Audio Clip or in the Audio Source inspector on a Game Object. Optionally plays a one shot Audio Clip."), ActionCategory(ActionCategory.Audio)]
    public class AudioPlay : FsmStateAction
    {
        private AudioSource audio;
        [Tooltip("Event to send when the AudioClip finishes playing.")]
        public FsmEvent finishedEvent;
        [Tooltip("The GameObject with an AudioSource component."), RequiredField, CheckForComponent(typeof(AudioSource))]
        public FsmOwnerDefault gameObject;
        [ObjectType(typeof(AudioClip)), Tooltip("Optionally play a 'one shot' AudioClip. NOTE: Volume cannot be adjusted while playing a 'one shot' AudioClip.")]
        public FsmObject oneShotClip;
        [HasFloatSlider(0f, 1f), Tooltip("Set the volume.")]
        public FsmFloat volume;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                this.audio = ownerDefaultTarget.audio;
                if (this.audio != null)
                {
                    AudioClip clip = this.oneShotClip.Value as AudioClip;
                    if (clip == null)
                    {
                        this.audio.Play();
                        if (!this.volume.IsNone)
                        {
                            this.audio.volume = this.volume.Value;
                        }
                        return;
                    }
                    if (!this.volume.IsNone)
                    {
                        this.audio.PlayOneShot(clip, this.volume.Value);
                    }
                    else
                    {
                        this.audio.PlayOneShot(clip);
                    }
                    return;
                }
            }
            base.Finish();
        }

        public override void OnUpdate()
        {
            if (this.audio == null)
            {
                base.Finish();
            }
            else if (!this.audio.isPlaying)
            {
                base.Fsm.Event(this.finishedEvent);
                base.Finish();
            }
            else if (this.volume.Value != this.audio.volume)
            {
                this.audio.volume = this.volume.Value;
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.volume = 1f;
            this.oneShotClip = null;
            this.finishedEvent = null;
        }
    }
}

