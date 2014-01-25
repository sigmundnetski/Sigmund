namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections;
    using UnityEngine;

    [Tooltip("Captures the current pose of a hierarchy as an animation clip.\n\nUseful to blend from an arbitrary pose (e.g. a ragdoll death) back to a known animation (e.g. idle)."), ActionCategory(ActionCategory.Animation)]
    public class CapturePoseAsAnimationClip : FsmStateAction
    {
        [CheckForComponent(typeof(Animation)), RequiredField, Tooltip("The GameObject root of the hierarchy to capture.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Capture position keys.")]
        public FsmBool position;
        [Tooltip("Capture rotation keys.")]
        public FsmBool rotation;
        [Tooltip("Capture scale keys.")]
        public FsmBool scale;
        [Tooltip("Store the result in an Object variable of type AnimationClip."), RequiredField, UIHint(UIHint.Variable), ObjectType(typeof(AnimationClip))]
        public FsmObject storeAnimationClip;

        private void CapturePosition(Transform transform, string path, AnimationClip clip)
        {
            this.SetConstantCurve(clip, path, "localPosition.x", transform.localPosition.x);
            this.SetConstantCurve(clip, path, "localPosition.y", transform.localPosition.y);
            this.SetConstantCurve(clip, path, "localPosition.z", transform.localPosition.z);
        }

        private void CaptureRotation(Transform transform, string path, AnimationClip clip)
        {
            this.SetConstantCurve(clip, path, "localRotation.x", transform.localRotation.x);
            this.SetConstantCurve(clip, path, "localRotation.y", transform.localRotation.y);
            this.SetConstantCurve(clip, path, "localRotation.z", transform.localRotation.z);
            this.SetConstantCurve(clip, path, "localRotation.w", transform.localRotation.w);
        }

        private void CaptureScale(Transform transform, string path, AnimationClip clip)
        {
            this.SetConstantCurve(clip, path, "localScale.x", transform.localScale.x);
            this.SetConstantCurve(clip, path, "localScale.y", transform.localScale.y);
            this.SetConstantCurve(clip, path, "localScale.z", transform.localScale.z);
        }

        private void CaptureTransform(Transform transform, string path, AnimationClip clip)
        {
            path = path + transform.name;
            if (this.position.Value)
            {
                this.CapturePosition(transform, path, clip);
            }
            if (this.rotation.Value)
            {
                this.CaptureRotation(transform, path, clip);
            }
            if (this.scale.Value)
            {
                this.CaptureScale(transform, path, clip);
            }
            IEnumerator enumerator = transform.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Transform current = (Transform) enumerator.Current;
                    this.CaptureTransform(current, path + "/", clip);
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

        private void DoCaptureAnimationClip()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (ownerDefaultTarget.animation != null))
            {
                AnimationClip clip = new AnimationClip();
                IEnumerator enumerator = ownerDefaultTarget.transform.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Transform current = (Transform) enumerator.Current;
                        this.CaptureTransform(current, string.Empty, clip);
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
                this.storeAnimationClip.Value = clip;
            }
        }

        public override void OnEnter()
        {
            this.DoCaptureAnimationClip();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.position = 0;
            this.rotation = 1;
            this.scale = 0;
            this.storeAnimationClip = null;
        }

        private void SetConstantCurve(AnimationClip clip, string childPath, string propertyPath, float value)
        {
            AnimationCurve curve = AnimationCurve.Linear(0f, value, 100f, value);
            curve.postWrapMode = WrapMode.Loop;
            clip.SetCurve(childPath, typeof(Transform), propertyPath, curve);
        }
    }
}

