namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Pause an iTween action."), ActionCategory("iTween")]
    public class iTweenPause : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault gameObject;
        public bool includeChildren;
        public bool inScene;
        public iTweenFSMType iTweenType;

        private void DoiTween()
        {
            if (this.iTweenType == iTweenFSMType.all)
            {
                iTween.Pause();
            }
            else if (this.inScene)
            {
                iTween.Pause(Enum.GetName(typeof(iTweenFSMType), this.iTweenType));
            }
            else
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                if (ownerDefaultTarget != null)
                {
                    iTween.Pause(ownerDefaultTarget, Enum.GetName(typeof(iTweenFSMType), this.iTweenType), this.includeChildren);
                }
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            this.DoiTween();
            base.Finish();
        }

        public override void Reset()
        {
            this.iTweenType = iTweenFSMType.all;
            this.includeChildren = false;
            this.inScene = false;
        }
    }
}

