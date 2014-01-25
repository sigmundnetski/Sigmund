namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Pauses playing the Audio Clip played by an Audio Source component on a Game Object."), ActionCategory(ActionCategory.Audio)]
    public class AudioPause : FsmStateAction
    {
        [RequiredField, CheckForComponent(typeof(AudioSource)), Tooltip("The GameObject with an Audio Source component.")]
        public FsmOwnerDefault gameObject;

        public override void OnEnter()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                AudioSource audio = ownerDefaultTarget.audio;
                if (audio != null)
                {
                    audio.Pause();
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
        }
    }
}

