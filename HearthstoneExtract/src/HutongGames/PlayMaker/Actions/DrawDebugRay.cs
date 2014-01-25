namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Debug), Tooltip("Draws a line from a Start point in a direction. Specify the start point as Game Objects or Vector3 world positions. If both are specified, position is used as a local offset from the Object's position.")]
    public class DrawDebugRay : FsmStateAction
    {
        [Tooltip("The color of the ray.")]
        public FsmColor color;
        [Tooltip("Direction vector of ray.")]
        public FsmVector3 direction;
        [Tooltip("Draw ray from a GameObject.")]
        public FsmGameObject fromObject;
        [Tooltip("Draw ray from a world position, or local offset from GameObject if provided.")]
        public FsmVector3 fromPosition;

        public override void OnUpdate()
        {
            Debug.DrawRay(ActionHelpers.GetPosition(this.fromObject, this.fromPosition), this.direction.Value, this.color.Value);
        }

        public override void Reset()
        {
            FsmGameObject obj2 = new FsmGameObject {
                UseVariable = true
            };
            this.fromObject = obj2;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.fromPosition = vector;
            vector = new FsmVector3 {
                UseVariable = true
            };
            this.direction = vector;
            this.color = Color.white;
        }
    }
}

