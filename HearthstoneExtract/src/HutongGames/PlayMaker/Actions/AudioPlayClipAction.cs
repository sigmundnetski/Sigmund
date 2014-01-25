namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Plays an AudioClip. An AudioSource for the clip is created automatically based on the parameters."), ActionCategory("Pegasus Audio")]
    public class AudioPlayClipAction : FsmStateAction
    {
        public SoundCategory m_Category;
        [RequiredField, ObjectType(typeof(AudioClip))]
        public FsmObject m_Clip;
        [Tooltip("Optional. If specified, the generated Audio Source will be attached to this object.")]
        public FsmOwnerDefault m_ParentObject;
        [HasFloatSlider(-3f, 3f)]
        public FsmFloat m_Pitch;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat m_Volume;

        public override void OnEnter()
        {
            if (this.m_Clip == null)
            {
                base.Finish();
            }
            else
            {
                AudioClip clip = this.m_Clip.Value as AudioClip;
                float volume = !this.m_Volume.IsNone ? this.m_Volume.Value : 1f;
                float pitch = !this.m_Pitch.IsNone ? this.m_Pitch.Value : 1f;
                SoundCategory cat = (this.m_Category != SoundCategory.NONE) ? this.m_Category : SoundCategory.FX;
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_ParentObject);
                SoundManager.Get().PlayClip(clip, volume, pitch, cat, ownerDefaultTarget);
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.m_ParentObject = null;
            this.m_Clip = null;
            this.m_Volume = 1f;
            this.m_Pitch = 1f;
            this.m_Category = SoundCategory.FX;
        }
    }
}

