namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Applies an explosion Force to all Game Objects with a Rigid Body inside a Radius."), ActionCategory(ActionCategory.Physics)]
    public class Explosion : FsmStateAction
    {
        [RequiredField, Tooltip("The world position of the center of the explosion.")]
        public FsmVector3 center;
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        [RequiredField, Tooltip("The strength of the explosion.")]
        public FsmFloat force;
        [Tooltip("The type of force to apply.")]
        public ForceMode forceMode;
        [Tooltip("Invert the mask, so you effect all layers except those defined above.")]
        public FsmBool invertMask;
        [UIHint(UIHint.Layer)]
        public FsmInt layer;
        [UIHint(UIHint.Layer), Tooltip("Layers to effect.")]
        public FsmInt[] layerMask;
        [Tooltip("The radius of the explosion. Force falls of linearly with distance."), RequiredField]
        public FsmFloat radius;
        [Tooltip("Applies the force as if it was applied from beneath the object. This is useful since explosions that throw things up instead of pushing things to the side look cooler. A value of 2 will apply a force as if it is applied from 2 meters below while not changing the actual explosion position.")]
        public FsmFloat upwardsModifier;

        private void DoExplosion()
        {
            foreach (Collider collider in Physics.OverlapSphere(this.center.Value, this.radius.Value))
            {
                if ((collider.rigidbody != null) && this.ShouldApplyForce(collider.gameObject))
                {
                    collider.rigidbody.AddExplosionForce(this.force.Value, this.center.Value, this.radius.Value, this.upwardsModifier.Value, this.forceMode);
                }
            }
        }

        public override void OnEnter()
        {
            this.DoExplosion();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnFixedUpdate()
        {
            this.DoExplosion();
        }

        public override void Reset()
        {
            this.center = null;
            this.upwardsModifier = 0f;
            this.forceMode = ForceMode.Force;
            this.everyFrame = false;
        }

        private bool ShouldApplyForce(GameObject go)
        {
            int num = ActionHelpers.LayerArrayToLayerMask(this.layerMask, this.invertMask.Value);
            return (((((int) 1) << go.layer) & num) > 0);
        }
    }
}

