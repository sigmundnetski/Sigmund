namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Stops an Audio Source on a Game Object."), ActionCategory("Pegasus Audio")]
    public class AudioStopAction : FsmStateAction
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
                    SoundManager.Get().Stop(audio);
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

