namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Tells the Highlight system when the state is finished."), ActionCategory("Pegasus")]
    public class HighlightFinishAction : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault m_GameObject;
        protected HighlightState m_HighlightState;

        public HighlightState CacheHighlightState()
        {
            if (this.m_HighlightState == null)
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.m_GameObject);
                if (ownerDefaultTarget != null)
                {
                    this.m_HighlightState = SceneUtils.FindComponentInThisOrParents<HighlightState>(ownerDefaultTarget);
                }
            }
            return this.m_HighlightState;
        }

        public override void OnEnter()
        {
            this.CacheHighlightState();
            if (this.m_HighlightState == null)
            {
                Debug.LogError(string.Format("{0}.OnEnter() - FAILED to find {1} in hierarchy", this, typeof(HighlightState)));
                base.Finish();
            }
            else
            {
                this.m_HighlightState.OnActionFinished();
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.m_GameObject = null;
        }
    }
}

