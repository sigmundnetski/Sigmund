namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using UnityEngine;

    [Tooltip("Changes a GameObject's alpha over time, if it supports alpha changes."), ActionCategory("iTween")]
    public class iTweenFadeToAction : iTweenFsmAction
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
        [Tooltip("An alpha value the GameObject will animate To.")]
        public FsmFloat m_Alpha;
        [Tooltip("Run this action on all child objects.")]
        public FsmBool m_IncludeChildren;
        [Tooltip("The time in seconds the animation will take to complete.")]
        public FsmFloat time;

        private void DoiTween()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                base.itweenType = "color";
                if (this.m_IncludeChildren.Value)
                {
                    IEnumerator enumerator = ownerDefaultTarget.transform.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Transform current = (Transform) enumerator.Current;
                            this.DoiTweenOnChild(current.gameObject);
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (disposable == null)
                        {
                        }
                        disposable.Dispose();
                    }
                }
                this.DoiTweenOnParent(ownerDefaultTarget);
            }
        }

        private void DoiTweenOnChild(GameObject go)
        {
            Hashtable args = this.InitTweenArgTable();
            if (this.time.Value <= 0f)
            {
                args.Add("time", 0f);
                iTween.FadeUpdate(go, args);
            }
            else
            {
                args["time"] = !this.time.IsNone ? this.time.Value : 1f;
                iTween.FadeTo(go, args);
            }
        }

        private void DoiTweenOnParent(GameObject go)
        {
            Hashtable args = this.InitTweenArgTable();
            if (this.time.Value <= 0f)
            {
                args.Add("time", 0f);
                iTween.FadeUpdate(go, args);
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
                iTween.FadeTo(go, args);
            }
        }

        private Hashtable InitTweenArgTable()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("alpha", this.m_Alpha.Value);
            hashtable.Add("name", !this.id.IsNone ? this.id.Value : string.Empty);
            hashtable.Add("delay", !this.delay.IsNone ? this.delay.Value : 0f);
            hashtable.Add("easetype", this.easeType);
            hashtable.Add("looptype", this.loopType);
            hashtable.Add("ignoretimescale", !base.realTime.IsNone ? ((object) base.realTime.Value) : ((object) 0));
            return hashtable;
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
            this.m_Alpha = 0f;
            this.time = 1f;
            this.delay = 0f;
            this.easeType = iTween.EaseType.linear;
            this.loopType = iTween.LoopType.none;
        }
    }
}

