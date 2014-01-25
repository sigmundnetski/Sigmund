namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUIElement), Tooltip("Performs a Hit Test on a Game Object with a GUITexture or GUIText component.")]
    public class GUIElementHitTest : FsmStateAction
    {
        [Tooltip("Specify camera or use MainCamera as default.")]
        public Camera camera;
        [Tooltip("Repeat every frame. Useful if you want to wait for the hit test to return true.")]
        public FsmBool everyFrame;
        [RequiredField, CheckForComponent(typeof(GUIElement)), Tooltip("The GameObject that has a GUITexture or GUIText component.")]
        public FsmOwnerDefault gameObject;
        private GameObject gameObjectCached;
        private GUIElement guiElement;
        [Tooltip("Event to send if the Hit Test is true.")]
        public FsmEvent hitEvent;
        [Tooltip("Whether the specified screen coordinates are normalized (0-1).")]
        public FsmBool normalized;
        [Tooltip("A vector position on screen. Usually stored by actions like GetTouchInfo, or World To Screen Point.")]
        public FsmVector3 screenPoint;
        [Tooltip("Specify screen X coordinate.")]
        public FsmFloat screenX;
        [Tooltip("Specify screen Y coordinate.")]
        public FsmFloat screenY;
        [Tooltip("Store the result of the Hit Test in a bool variable (true/false)."), UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        private void DoHitTest()
        {
            // This item is obfuscated and can not be translated.
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                if (ownerDefaultTarget != this.gameObjectCached)
                {
                    if (ownerDefaultTarget.guiTexture != null)
                    {
                        goto Label_0044;
                    }
                    this.guiElement = ownerDefaultTarget.guiText;
                    this.gameObjectCached = ownerDefaultTarget;
                }
                if (this.guiElement == null)
                {
                    base.Finish();
                }
                else
                {
                    Vector3 screenPosition = !this.screenPoint.IsNone ? this.screenPoint.Value : new Vector3(0f, 0f);
                    if (!this.screenX.IsNone)
                    {
                        screenPosition.x = this.screenX.Value;
                    }
                    if (!this.screenY.IsNone)
                    {
                        screenPosition.y = this.screenY.Value;
                    }
                    if (this.normalized.Value)
                    {
                        screenPosition.x *= Screen.width;
                        screenPosition.y *= Screen.height;
                    }
                    if (this.guiElement.HitTest(screenPosition, this.camera))
                    {
                        this.storeResult.Value = true;
                        base.Fsm.Event(this.hitEvent);
                    }
                    else
                    {
                        this.storeResult.Value = false;
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoHitTest();
            if (!this.everyFrame.Value)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoHitTest();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.camera = null;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.screenPoint = vector;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.screenX = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.screenY = num;
            this.normalized = 1;
            this.hitEvent = null;
            this.everyFrame = 1;
        }
    }
}

