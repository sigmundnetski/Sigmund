namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets looping on the AudioSource on a Game Object."), ActionCategory("Pegasus Audio")]
    public class AudioSetLoopAction : FsmStateAction
    {
        [CheckForComponent(typeof(AudioSource)), RequiredField]
        public FsmOwnerDefault m_GameObject;
        public FsmBool m_Loop;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
            if (ownerDefaultTarget != null)
            {
                AudioSource audio = ownerDefaultTarget.audio;
                if (audio != null)
                {
                    audio.loop = this.m_Loop.Value;
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.m_GameObject = null;
            this.m_Loop = 0;
        }
    }
}

