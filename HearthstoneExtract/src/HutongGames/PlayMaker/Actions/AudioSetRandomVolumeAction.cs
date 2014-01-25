namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus Audio"), Tooltip("Randomly sets the volume of an AudioSource on a Game Object.")]
    public class AudioSetRandomVolumeAction : FsmStateAction
    {
        public bool m_EveryFrame;
        [CheckForComponent(typeof(AudioSource)), RequiredField]
        public FsmOwnerDefault m_GameObject;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat m_MaxVolume;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat m_MinVolume;
        private float m_volume;

        private void ChooseVolume()
        {
            float min = !this.m_MinVolume.IsNone ? this.m_MinVolume.Value : 1f;
            float max = !this.m_MaxVolume.IsNone ? this.m_MaxVolume.Value : 1f;
            this.m_volume = UnityEngine.Random.Range(min, max);
        }

        public override void OnEnter()
        {
            this.UpdateVolume();
            if (!this.m_EveryFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.UpdateVolume();
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            this.m_MinVolume = 1f;
            this.m_MaxVolume = 1f;
            this.m_EveryFrame = false;
        }

        private void UpdateVolume()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget != null)
            {
                AudioSource audio = ownerDefaultTarget.audio;
                if (audio != null)
                {
                    SoundManager.Get().SetVolume(audio, this.m_volume);
                }
            }
        }
    }
}

