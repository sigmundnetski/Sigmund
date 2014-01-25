namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Modify various character controller settings.\n'None' leaves the setting unchanged."), ActionCategory(ActionCategory.Character)]
    public class ControllerSettings : FsmStateAction
    {
        [Tooltip("The center of the character's capsule relative to the transform's position")]
        public FsmVector3 center;
        private CharacterController controller;
        [Tooltip("Should other rigidbodies or character controllers collide with this character controller (By default always enabled).")]
        public FsmBool detectCollisions;
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        [CheckForComponent(typeof(CharacterController)), Tooltip("The GameObject that owns the CharacterController."), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("The height of the character's capsule.")]
        public FsmFloat height;
        private GameObject previousGo;
        [Tooltip("The radius of the character's capsule.")]
        public FsmFloat radius;
        [Tooltip("The character controllers slope limit in degrees.")]
        public FsmFloat slopeLimit;
        [Tooltip("The character controllers step offset in meters.")]
        public FsmFloat stepOffset;

        private void DoControllerSettings()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                if (ownerDefaultTarget != this.previousGo)
                {
                    this.controller = ownerDefaultTarget.GetComponent<CharacterController>();
                    this.previousGo = ownerDefaultTarget;
                }
                if (this.controller != null)
                {
                    if (!this.height.IsNone)
                    {
                        this.controller.height = this.height.Value;
                    }
                    if (!this.radius.IsNone)
                    {
                        this.controller.radius = this.radius.Value;
                    }
                    if (!this.slopeLimit.IsNone)
                    {
                        this.controller.slopeLimit = this.slopeLimit.Value;
                    }
                    if (!this.stepOffset.IsNone)
                    {
                        this.controller.stepOffset = this.stepOffset.Value;
                    }
                    if (!this.center.IsNone)
                    {
                        this.controller.center = this.center.Value;
                    }
                    if (!this.detectCollisions.IsNone)
                    {
                        this.controller.detectCollisions = this.detectCollisions.Value;
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoControllerSettings();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoControllerSettings();
        }

        public override void Reset()
        {
            this.gameObject = null;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.height = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.radius = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.slopeLimit = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.stepOffset = num;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.center = vector;
            FsmBool @bool = new FsmBool {
                UseVariable = true
            };
            this.detectCollisions = @bool;
            this.everyFrame = false;
        }
    }
}

