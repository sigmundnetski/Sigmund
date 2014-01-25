namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Mute/unmute the Audio Source on a Game Object."), ActionCategory("Pegasus Audio")]
    public class AudioSetMuteAction : FsmStateAction
    {
        [CheckForComponent(typeof(AudioSource)), RequiredField]
        public FsmOwnerDefault m_GameObject;
        public FsmBool m_Mute;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget != null)
            {
                AudioSource audio = ownerDefaultTarget.audio;
                if (audio != null)
                {
                    audio.mute = this.m_Mute.Value;
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            this.m_Mute = 0;
        }
    }
}

