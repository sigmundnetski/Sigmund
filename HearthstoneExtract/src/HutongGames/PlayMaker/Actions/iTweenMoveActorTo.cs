namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using UnityEngine;

    [ActionCategory("Pegasus"), Tooltip("Move an object's actor.  Used for spells that are dynamically loaded.")]
    public class iTweenMoveActorTo : iTweenFsmAction
    {
        [Tooltip("The time in seconds the animation will wait before beginning.")]
        public FsmFloat delay;
        [Tooltip("The shape of the easing curve applied to the animation.")]
        public iTween.EaseType easeType = iTween.EaseType.linear;
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("iTween ID. If set you can use iTween Stop action to stop it by its id.")]
        public FsmString id;
        [Tooltip("The type of loop to apply once the animation has completed.")]
        public iTween.LoopType loopType;
        [Tooltip("The time in seconds the animation will take to complete.")]
        public FsmFloat time;
        [Tooltip("Position the GameObject will animate to.")]
        public FsmVector3 vectorPosition;

        private void DoiTween()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Actor actor = SceneUtils.FindComponentInParents<Actor>(ownerDefaultTarget);
                if (actor != null)
                {
                    GameObject gameObject = actor.gameObject;
                    if (gameObject != null)
                    {
                        base.itweenType = "move";
                        Hashtable args = new Hashtable();
                        args.Add("position", this.vectorPosition);
                        args.Add("name", !this.id.IsNone ? this.id.Value : string.Empty);
                        args.Add("delay", !this.delay.IsNone ? this.delay.Value : 0f);
                        args.Add("easetype", this.easeType);
                        args.Add("looptype", this.loopType);
                        args.Add("ignoretimescale", !base.realTime.IsNone ? ((object) base.realTime.Value) : ((object) 0));
                        if (this.time.Value <= 0f)
                        {
                            args.Add("time", 0f);
                            iTween.FadeUpdate(gameObject, args);
                            base.Fsm.Event(base.startEvent);
                            base.Fsm.Event(base.finishEvent);
                            base.Finish();
                        }
                        else
                        {
                            args["time"] = !this.time.IsNone ? this.time.Value : 1f;
                            args.Add("oncomplete", "iTweenOnComplete");
                            args.Add("oncompleteparams", base.itweenID);
                            args.Add("onstart", "iTweenOnStart");
                            args.Add("onstartparams", base.itweenID);
                            args.Add("oncompletetarget", ownerDefaultTarget);
                            iTween.MoveTo(gameObject, args);
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            base.OnEnteriTween(this.gameObject);
            if (this.loopType != iTween.LoopType.none)
            {
                base.IsLoop(true);
            }
            this.DoiTween();
        }

        public override void OnExit()
        {
            base.OnExitiTween(this.gameObject);
        }

        public override void Reset()
        {
            base.Reset();
            FsmString str = new FsmString {
                UseVariable = true
            };
            this.id = str;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.vectorPosition = vector;
            this.time = 1f;
            this.delay = 0f;
            this.easeType = iTween.EaseType.linear;
            this.loopType = iTween.LoopType.none;
        }
    }
}

