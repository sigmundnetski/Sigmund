namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Stop an iTween action."), ActionCategory("iTween")]
    public class iTweenStop : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault gameObject;
        public FsmString id;
        public bool includeChildren;
        public bool inScene;
        public iTweenFSMType iTweenType;

        private void DoiTween()
        {
            if (this.id.IsNone)
            {
                if (this.iTweenType == iTweenFSMType.all)
                {
                    iTween.Stop();
                }
                else if (this.inScene)
                {
                    iTween.Stop(Enum.GetName(typeof(iTweenFSMType), this.iTweenType));
                }
                else
                {
                    GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                    if (ownerDefaultTarget != null)
                    {
                        iTween.Stop(ownerDefaultTarget, Enum.GetName(typeof(iTweenFSMType), this.iTweenType), this.includeChildren);
                    }
                }
            }
            else
            {
                iTween.StopByName(this.id.Value);
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
            FsmString str = new FsmString {
                UseVariable = true
            };
            this.id = str;
            this.iTweenType = iTweenFSMType.all;
            this.includeChildren = false;
            this.inScene = false;
        }
    }
}

