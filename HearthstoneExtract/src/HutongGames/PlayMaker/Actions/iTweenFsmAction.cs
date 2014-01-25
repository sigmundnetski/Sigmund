namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("iTween base action - don't use!")]
    public abstract class iTweenFsmAction : FsmStateAction
    {
        public FsmEvent finishEvent;
        internal iTweenFSMEvents itweenEvents;
        protected int itweenID = -1;
        protected string itweenType = string.Empty;
        public FsmBool loopDontFinish;
        [Tooltip("Setting this to true will allow the animation to continue independent of the current time which is helpful for animating menus after a game has been paused by setting Time.timeScale=0.")]
        public FsmBool realTime;
        [ActionSection("Events")]
        public FsmEvent startEvent;
        public FsmBool stopOnExit;

        protected iTweenFsmAction()
        {
        }

        protected void IsLoop(bool aValue)
        {
            if (this.itweenEvents != null)
            {
                this.itweenEvents.islooping = aValue;
            }
        }

        protected void OnEnteriTween(FsmOwnerDefault anOwner)
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(anOwner);
            this.itweenEvents = (iTweenFSMEvents) ownerDefaultTarget.AddComponent("iTweenFSMEvents");
            this.itweenEvents.itweenFSMAction = this;
            iTweenFSMEvents.itweenIDCount++;
            this.itweenID = iTweenFSMEvents.itweenIDCount;
            this.itweenEvents.itweenID = iTweenFSMEvents.itweenIDCount;
            this.itweenEvents.donotfinish = !this.loopDontFinish.IsNone ? this.loopDontFinish.Value : false;
        }

        protected void OnExitiTween(FsmOwnerDefault anOwner)
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(anOwner);
            if (ownerDefaultTarget != null)
            {
                if (this.itweenEvents != null)
                {
                    UnityEngine.Object.Destroy(this.itweenEvents);
                }
                if (this.stopOnExit.IsNone)
                {
                    iTween.Stop(ownerDefaultTarget, this.itweenType);
                }
                else if (this.stopOnExit.Value)
                {
                    iTween.Stop(ownerDefaultTarget, this.itweenType);
                }
            }
        }

        public override void Reset()
        {
            this.startEvent = null;
            this.finishEvent = null;
            FsmBool @bool = new FsmBool {
                Value = false
            };
            this.realTime = @bool;
            @bool = new FsmBool {
                Value = true
            };
            this.stopOnExit = @bool;
            @bool = new FsmBool {
                Value = true
            };
            this.loopDontFinish = @bool;
            this.itweenType = string.Empty;
        }

        public enum AxisRestriction
        {
            none,
            x,
            y,
            z,
            xy,
            xz,
            yz
        }
    }
}

