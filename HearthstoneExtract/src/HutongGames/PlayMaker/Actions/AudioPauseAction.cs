namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory("Pegasus Audio"), Tooltip("Pauses the Audio Source of a Game Object.")]
    public class AudioPauseAction : FsmStateAction
    {
        [CheckForComponent(typeof(AudioSource)), RequiredField]
        public FsmOwnerDefault m_GameObject;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget != null)
            {
                AudioSource audio = ownerDefaultTarget.audio;
                if (audio != null)
                {
                    SoundManager.Get().Pause(audio);
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.m_GameObject = null;
        }
    }
}

