namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Loads and Plays a Sound Prefab."), ActionCategory("Pegasus Audio")]
    public class AudioLoadAndPlayAction : FsmStateAction
    {
        [Tooltip("Optional. If specified, the generated Audio Source will be attached to this object.")]
        public FsmOwnerDefault m_ParentObject;
        [RequiredField]
        public FsmString m_PrefabName;
        [Tooltip("Optional. Scales the volume of the loaded sound."), HasFloatSlider(0f, 1f)]
        public FsmFloat m_VolumeScale;

        public override void OnEnter()
        {
            if (this.m_PrefabName == null)
            {
                base.Finish();
            }
            else
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_ParentObject);
                string soundName = this.m_PrefabName.Value;
                if (this.m_VolumeScale.IsNone)
                {
                    SoundManager.Get().LoadAndPlay(soundName, ownerDefaultTarget);
                }
                else
                {
                    SoundManager.Get().LoadAndPlay(soundName, ownerDefaultTarget, this.m_VolumeScale.Value);
                }
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.m_ParentObject = null;
            this.m_PrefabName = null;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.m_VolumeScale = num;
        }
    }
}

