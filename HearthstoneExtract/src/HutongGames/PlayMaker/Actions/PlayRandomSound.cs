namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Audio), Tooltip("Plays a Random Audio Clip at a position defined by a Game Object or a Vector3. If a position is defined, it takes priority over the game object. You can set the relative weight of the clips to control how often they are selected.")]
    public class PlayRandomSound : FsmStateAction
    {
        [CompoundArray("Audio Clips", "Audio Clip", "Weight")]
        public AudioClip[] audioClips;
        public FsmOwnerDefault gameObject;
        public FsmVector3 position;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat volume = 1f;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat[] weights;

        private void DoPlayRandomClip()
        {
            if (this.audioClips.Length != 0)
            {
                int randomWeightedIndex = ActionHelpers.GetRandomWeightedIndex(this.weights);
                if (randomWeightedIndex != -1)
                {
                    AudioClip clip = this.audioClips[randomWeightedIndex];
                    if (clip != null)
                    {
                        if (!this.position.IsNone)
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
                }
            }
        }

        public override void OnEnter()
        {
            this.DoPlayRandomClip();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.position = vector;
            this.audioClips = new AudioClip[3];
            this.weights = new FsmFloat[] { 1f, 1f, 1f };
            this.volume = 1f;
        }
    }
}

