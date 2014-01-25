namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Casts a Ray against all Colliders in the scene. Use either a Game Object or Vector3 world position as the origin of the ray. Use GetRaycastInfo to get more detailed info."), ActionCategory(ActionCategory.Physics)]
    public class Raycast : FsmStateAction
    {
        [Tooltip("Draw a debug line. Note: Check Gizmos in the Game View to see it in game.")]
        public FsmBool debug;
        [ActionSection("Debug"), Tooltip("The color to use for the debug line.")]
        public FsmColor debugColor;
        [Tooltip("A vector3 direction vector")]
        public FsmVector3 direction;
        [Tooltip("The length of the ray. Set to -1 for infinity.")]
        public FsmFloat distance;
        [Tooltip("Start ray at game object position. \nOr use From Position parameter.")]
        public FsmOwnerDefault fromGameObject;
        [Tooltip("Start ray at a vector3 world position. \nOr use Game Object parameter.")]
        public FsmVector3 fromPosition;
        [ActionSection("Result"), UIHint(UIHint.Variable), Tooltip("Event to send if the ray hits an object.")]
        public FsmEvent hitEvent;
        [Tooltip("Invert the mask, so you pick from all layers except those defined above.")]
        public FsmBool invertMask;
        [UIHint(UIHint.Layer), Tooltip("Pick only from these layers.")]
        public FsmInt[] layerMask;
        private int repeat;
        [ActionSection("Filter"), Tooltip("Set how often to cast a ray. 0 = once, don't repeat; 1 = everyFrame; 2 = every other frame... \nSince raycasts can get expensive use the highest repeat interval you can get away with.")]
        public FsmInt repeatInterval;
        [Tooltip("Cast the ray in world or local space. Note if no Game Object is specfied, the direction is in world space.")]
        public Space space;
        [Tooltip("Set a bool variable to true if hit something, otherwise false."), UIHint(UIHint.Variable)]
        public FsmBool storeDidHit;
        [Tooltip("Get the distance along the ray to the hit point and store it in a variable."), UIHint(UIHint.Variable)]
        public FsmFloat storeHitDistance;
        [Tooltip("Get the normal at the hit point and store it in a variable."), UIHint(UIHint.Variable)]
        public FsmVector3 storeHitNormal;
        [Tooltip("Store the game object hit in a variable."), UIHint(UIHint.Variable)]
        public FsmGameObject storeHitObject;
        [Tooltip("Get the world position of the ray hit point and store it in a variable."), UIHint(UIHint.Variable)]
        public FsmVector3 storeHitPoint;

        private void DoRaycast()
        {
            this.repeat = this.repeatInterval.Value;
            if (this.distance.Value != 0f)
            {
                RaycastHit hit;
                GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.fromGameObject);
                Vector3 origin = (ownerDefaultTarget == null) ? this.fromPosition.Value : ownerDefaultTarget.transform.position;
                float positiveInfinity = float.PositiveInfinity;
                if (this.distance.Value > 0f)
                {
                    positiveInfinity = this.distance.Value;
                }
                Vector3 direction = this.direction.Value;
                if ((ownerDefaultTarget != null) && (this.space == Space.Self))
                {
                    direction = ownerDefaultTarget.transform.TransformDirection(this.direction.Value);
                }
                Physics.Raycast(origin, direction, out hit, positiveInfinity, ActionHelpers.LayerArrayToLayerMask(this.layerMask, this.invertMask.Value));
                base.Fsm.RaycastHitInfo = hit;
                bool flag = hit.collider != null;
                this.storeDidHit.Value = flag;
                if (flag)
                {
                    this.storeHitObject.Value = hit.collider.collider.gameObject;
                    this.storeHitPoint.Value = base.Fsm.RaycastHitInfo.point;
                    this.storeHitNormal.Value = base.Fsm.RaycastHitInfo.normal;
                    this.storeHitDistance.Value = base.Fsm.RaycastHitInfo.distance;
                    base.Fsm.Event(this.hitEvent);
                }
                if (this.debug.Value)
                {
                    float num2 = Mathf.Min(positiveInfinity, 1000f);
                    Debug.DrawLine(origin, origin + ((Vector3) (direction * num2)), this.debugColor.Value);
                }
            }
        }

        public override void OnEnter()
        {
            this.DoRaycast();
            if (this.repeatInterval.Value == 0)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.repeat--;
            if (this.repeat == 0)
            {
                this.DoRaycast();
            }
        }

        public override void Reset()
        {
            this.fromGameObject = null;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.fromPosition = vector;
            vector = new FsmVector3 {
                UseVariable = true
            };
            this.direction = vector;
            this.space = Space.Self;
            this.distance = 100f;
            this.hitEvent = null;
            this.storeDidHit = null;
            this.storeHitObject = null;
            this.storeHitPoint = null;
            this.storeHitNormal = null;
            this.storeHitDistance = null;
            this.repeatInterval = 1;
            this.layerMask = new FsmInt[0];
            this.invertMask = 0;
            this.debugColor = Color.yellow;
            this.debug = 0;
        }
    }
}

