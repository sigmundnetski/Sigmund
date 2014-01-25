namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Audio), Tooltip("Plays an Audio Clip at a position defined by a Game Object or Vector3. If a position is defined, it takes priority over the game object. This action doesn't require an Audio Source component, but offers less control than Audio actions.")]
    public class PlaySound : FsmStateAction
    {
        [ObjectType(typeof(AudioClip)), RequiredField, Title("Audio Clip")]
        public FsmObject clip;
        public FsmOwnerDefault gameObject;
        public FsmVector3 position;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat volume = 1f;

        private void DoPlaySound()
        {
            AudioClip clip = this.clip.Value as AudioClip;
            if (clip == null)
            {
                this.LogWarning("Missing Audio Clip!");
            }
            else if (!this.position.IsNone)
            {
                AudioSource.PlayClipAtPoint(clip, this.position.Value, this.volume.Value);
            }
            else
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                if (ownerDefaultTarget != null)
                {
                    AudioSource.PlayClipAtPoint(clip, ownerDefaultTarget.transform.position, this.volume.Value);
                }
            }
        }

        public override void OnEnter()
        {
            this.DoPlaySound();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.position = vector;
            this.clip = null;
            this.volume = 1f;
        }
    }
}

