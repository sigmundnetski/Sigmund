namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Device), Tooltip("Sends events when an object is touched. Optionally filter by a fingerID. NOTE: Uses the MainCamera!")]
    public class TouchObjectEvent : FsmStateAction
    {
        [Tooltip("Only detect touches that match this fingerID, or set to None.")]
        public FsmInt fingerId;
        [CheckForComponent(typeof(Collider)), Tooltip("The Game Object to detect touches on."), RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField, Tooltip("How far from the camera is the Game Object pickable.")]
        public FsmFloat pickDistance;
        [ActionSection("Store Results"), UIHint(UIHint.Variable), Tooltip("Store the fingerId of the touch.")]
        public FsmInt storeFingerId;
        [Tooltip("Store the surface normal vector where the object was touched."), UIHint(UIHint.Variable)]
        public FsmVector3 storeHitNormal;
        [Tooltip("Store the world position where the object was touched."), UIHint(UIHint.Variable)]
        public FsmVector3 storeHitPoint;
        [Tooltip("Event to send on touch began."), ActionSection("Events")]
        public FsmEvent touchBegan;
        [Tooltip("Event to send on touch cancel.")]
        public FsmEvent touchCanceled;
        [Tooltip("Event to send on touch ended.")]
        public FsmEvent touchEnded;
        [Tooltip("Event to send on touch moved.")]
        public FsmEvent touchMoved;
        [Tooltip("Event to send on stationary touch.")]
        public FsmEvent touchStationary;

        public override void OnUpdate()
        {
            if (Camera.main == null)
            {
                this.LogError("No MainCamera defined!");
                base.Finish();
            }
            else if (Input.touchCount > 0)
            {
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
                if (ownerDefaultTarget != null)
                {
                    foreach (Touch touch in Input.touches)
                    {
                        if (this.fingerId.IsNone || (touch.fingerId == this.fingerId.Value))
                        {
                            RaycastHit hit;
                            Vector2 position = touch.position;
                            Physics.Raycast(Camera.main.ScreenPointToRay((Vector3) position), out hit, this.pickDistance.Value);
                            base.Fsm.RaycastHitInfo = hit;
                            if ((hit.transform != null) && (hit.transform.gameObject == ownerDefaultTarget))
                            {
                                this.storeFingerId.Value = touch.fingerId;
                                this.storeHitPoint.Value = hit.point;
                                this.storeHitNormal.Value = hit.normal;
                                switch (touch.phase)
                                {
                                    case TouchPhase.Began:
                                        base.Fsm.Event(this.touchBegan);
                                        return;

                                    case TouchPhase.Moved:
                                        base.Fsm.Event(this.touchMoved);
                                        return;

                                    case TouchPhase.Stationary:
                                        base.Fsm.Event(this.touchStationary);
                                        return;

                                    case TouchPhase.Ended:
                                        base.Fsm.Event(this.touchEnded);
                                        return;

                                    case TouchPhase.Canceled:
                                        base.Fsm.Event(this.touchCanceled);
                                        return;
                                }
                            }
                        }
                    }
                }
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.pickDistance = 100f;
            FsmInt num = new FsmInt {
                UseVariable = true
            };
            this.fingerId = num;
            this.touchBegan = null;
            this.touchMoved = null;
            this.touchStationary = null;
            this.touchEnded = null;
            this.touchCanceled = null;
            this.storeFingerId = null;
            this.storeHitPoint = null;
            this.storeHitNormal = null;
        }
    }
}

