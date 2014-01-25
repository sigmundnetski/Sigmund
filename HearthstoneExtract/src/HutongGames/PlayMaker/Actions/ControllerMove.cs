namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Character), Tooltip("Moves a Game Object with a Character Controller. See also Controller Simple Move. NOTE: It is recommended that you make only one call to Move or SimpleMove per frame.")]
    public class ControllerMove : FsmStateAction
    {
        private CharacterController controller;
        [CheckForComponent(typeof(CharacterController)), Tooltip("The GameObject to move."), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("The movement vector."), RequiredField]
        public FsmVector3 moveVector;
        [Tooltip("Movement vector is defined in units per second. Makes movement frame rate independent.")]
        public FsmBool perSecond;
        private GameObject previousGo;
        [Tooltip("Move in local or word space.")]
        public Space space;

        public override void OnUpdate()
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
                    Vector3 motion = (this.space != Space.World) ? ownerDefaultTarget.transform.TransformDirection(this.moveVector.Value) : this.moveVector.Value;
                    if (this.perSecond.Value)
                    {
                        this.controller.Move((Vector3) (motion * Time.deltaTime));
                    }
                    else
                    {
                        this.controller.Move(motion);
                    }
                }
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.moveVector = vector;
            this.space = Space.World;
            this.perSecond = 1;
        }
    }
}

