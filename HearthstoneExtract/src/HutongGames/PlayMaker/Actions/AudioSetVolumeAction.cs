namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus Audio"), Tooltip("Sets the volume of an AudioSource on a Game Object.")]
    public class AudioSetVolumeAction : FsmStateAction
    {
        public bool m_EveryFrame;
        [RequiredField, CheckForComponent(typeof(AudioSource))]
        public FsmOwnerDefault m_GameObject;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat m_Volume;

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
            this.m_Volume = 1f;
            this.m_EveryFrame = false;
        }

        private void UpdateVolume()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget != null)
            {
                AudioSource audio = ownerDefaultTarget.audio;
                if ((audio != null) && !this.m_Volume.IsNone)
                {
                    SoundManager.Get().SetVolume(audio, this.m_Volume.Value);
                }
            }
        }
    }
}

