namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Drag a Rigid body with the mouse. If draggingPlaneTransform is defined, it will use the UP axis of this gameObject as the dragging plane normal \nThat is select the ground Plane, if you want to drag object on the ground instead of from the camera point of view."), ActionCategory(ActionCategory.Physics)]
    public class DragRigidBody : FsmStateAction
    {
        private Camera _cam;
        private Vector3 _dragStartPos;
        private GameObject _goPlane;
        [Tooltip("the angular drag during dragging")]
        public FsmFloat angularDrag;
        [Tooltip("If TRUE, dragging will have close to no effect on the Rigidbody rotation ( except if it hits other bodies as you drag it)")]
        public FsmBool attachToCenterOfMass;
        [Tooltip("the damping of the drag")]
        public FsmFloat damper;
        [Tooltip("The Max Distance between the dragging target and the RigidBody being dragged")]
        public FsmFloat distance;
        [Tooltip("the drag during dragging")]
        public FsmFloat drag;
        private float dragDistance;
        [Tooltip("If Defined. Use this transform Up axis as the dragging plane normal. Typically, set it to the ground plane if you want to drag objects around on the floor..")]
        public FsmOwnerDefault draggingPlaneTransform;
        private bool isDragging;
        [Tooltip("Move th object forward and back or up and down")]
        public FsmBool moveUp;
        private float oldAngularDrag;
        private float oldDrag;
        [Tooltip("the springness of the drag")]
        public FsmFloat spring;
        private SpringJoint springJoint;

        private void Drag()
        {
            if (!Input.GetMouseButton(0))
            {
                this.StopDragging();
            }
            else
            {
                Ray ray = this._cam.ScreenPointToRay(Input.mousePosition);
                if (this._goPlane != null)
                {
                    float num;
                    Plane plane = new Plane();
                    if (this.moveUp.Value)
                    {
                        plane = new Plane(this._goPlane.transform.forward, this._dragStartPos);
                    }
                    else
                    {
                        plane = new Plane(this._goPlane.transform.up, this._dragStartPos);
                    }
                    if (plane.Raycast(ray, out num))
                    {
                        this.springJoint.transform.position = ray.GetPoint(num);
                    }
                }
                else
                {
                    this.springJoint.transform.position = ray.GetPoint(this.dragDistance);
                }
            }
        }

        public override void OnEnter()
        {
            this._cam = Camera.main;
            this._goPlane = base.Fsm.GetOwnerDefaultTarget(this.draggingPlaneTransform);
        }

        public override void OnExit()
        {
            this.StopDragging();
        }

        public override void OnUpdate()
        {
            if (!this.isDragging && Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (!Physics.Raycast(this._cam.ScreenPointToRay(Input.mousePosition), out hit, 100f))
                {
                    return;
                }
                if ((hit.rigidbody == null) || hit.rigidbody.isKinematic)
                {
                    return;
                }
                this.StartDragging(hit);
            }
            if (this.isDragging)
            {
                this.Drag();
            }
        }

        public override void Reset()
        {
            this.spring = 50f;
            this.damper = 5f;
            this.drag = 10f;
            this.angularDrag = 5f;
            this.distance = 0.2f;
            this.attachToCenterOfMass = 0;
            this.draggingPlaneTransform = null;
            this.moveUp = 1;
        }

        private void StartDragging(RaycastHit hit)
        {
            this.isDragging = true;
            if (this.springJoint == null)
            {
                GameObject obj2 = new GameObject("__Rigidbody dragger__");
                Rigidbody rigidbody = obj2.AddComponent<Rigidbody>();
                this.springJoint = obj2.AddComponent<SpringJoint>();
                rigidbody.isKinematic = true;
            }
            this.springJoint.transform.position = hit.point;
            if (this.attachToCenterOfMass.Value)
            {
                Vector3 position = this._cam.transform.TransformDirection(hit.rigidbody.centerOfMass) + hit.rigidbody.transform.position;
                position = this.springJoint.transform.InverseTransformPoint(position);
                this.springJoint.anchor = position;
            }
            else
            {
                this.springJoint.anchor = Vector3.zero;
            }
            this._dragStartPos = hit.point;
            this.springJoint.spring = this.spring.Value;
            this.springJoint.damper = this.damper.Value;
            this.springJoint.maxDistance = this.distance.Value;
            this.springJoint.connectedBody = hit.rigidbody;
            this.oldDrag = this.springJoint.connectedBody.drag;
            this.oldAngularDrag = this.springJoint.connectedBody.angularDrag;
            this.springJoint.connectedBody.drag = this.drag.Value;
            this.springJoint.connectedBody.angularDrag = this.angularDrag.Value;
            this.dragDistance = hit.distance;
        }

        private void StopDragging()
        {
            this.isDragging = false;
            if ((this.springJoint != null) && (this.springJoint.connectedBody != null))
            {
                this.springJoint.connectedBody.drag = this.oldDrag;
                this.springJoint.connectedBody.angularDrag = this.oldAngularDrag;
                this.springJoint.connectedBody = null;
            }
        }
    }
}

