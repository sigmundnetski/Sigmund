namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus Audio"), Tooltip("Plays a random AudioClip. An AudioSource for the clip is created automatically based on the parameters.")]
    public class AudioPlayRandomClipAction : FsmStateAction
    {
        public SoundCategory m_Category;
        [CompoundArray("Audio Clips", "Audio Clip", "Weight"), RequiredField]
        public AudioClip[] m_Clips;
        [HasFloatSlider(-3f, 3f)]
        public FsmFloat m_MaxPitch;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat m_MaxVolume;
        [HasFloatSlider(-3f, 3f)]
        public FsmFloat m_MinPitch;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat m_MinVolume;
        [Tooltip("Optional. If specified, the generated Audio Source will be attached to this object.")]
        public FsmOwnerDefault m_ParentObject;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat[] m_Weights;

        private AudioClip ChooseClip()
        {
            if ((this.m_Weights != null) && (this.m_Weights.Length != 0))
            {
                return this.m_Clips[ActionHelpers.GetRandomWeightedIndex(this.m_Weights)];
            }
            return this.m_Clips[0];
        }

        private float ChoosePitch()
        {
            float objA = !this.m_MinPitch.IsNone ? this.m_MinPitch.Value : 1f;
            float objB = !this.m_MaxPitch.IsNone ? this.m_MaxPitch.Value : 1f;
            if (object.Equals(objA, objB))
            {
                return objA;
            }
            return UnityEngine.Random.Range(objA, objB);
        }

        private float ChooseVolume()
        {
            float objA = !this.m_MinVolume.IsNone ? this.m_MinVolume.Value : 1f;
            float objB = !this.m_MaxVolume.IsNone ? this.m_MaxVolume.Value : 1f;
            if (object.Equals(objA, objB))
            {
                return objA;
            }
            return UnityEngine.Random.Range(objA, objB);
        }

        public override void OnEnter()
        {
            if ((this.m_Clips == null) || (this.m_Clips.Length == 0))
            {
                base.Finish();
            }
            else
            {
                AudioClip clip = this.ChooseClip();
                float volume = this.ChooseVolume();
                float pitch = this.ChoosePitch();
                SoundCategory cat = (this.m_Category != SoundCategory.NONE) ? this.m_Category : SoundCategory.FX;
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_ParentObject);
                SoundManager.Get().PlayClip(clip, volume, pitch, cat, ownerDefaultTarget);
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.m_ParentObject = null;
            this.m_Clips = new AudioClip[3];
            this.m_Weights = new FsmFloat[] { 1f, 1f, 1f };
            this.m_MinVolume = 1f;
            this.m_MaxVolume = 1f;
            this.m_MinPitch = 1f;
            this.m_MaxPitch = 1f;
            this.m_Category = SoundCategory.FX;
        }
    }
}

