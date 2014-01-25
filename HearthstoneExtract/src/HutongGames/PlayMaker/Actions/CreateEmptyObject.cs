namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Creates a Game Object at a spawn point.\nUse a Game Object and/or Position/Rotation for the Spawn Point. If you specify a Game Object, Position is used as a local offset, and Rotation will override the object's rotation.")]
    public class CreateEmptyObject : FsmStateAction
    {
        public FsmGameObject gameObject;
        public FsmVector3 position;
        public FsmVector3 rotation;
        public FsmGameObject spawnPoint;
        [UIHint(UIHint.Variable), Tooltip("Optionally store the created object.")]
        public FsmGameObject storeObject;

        public override void OnEnter()
        {
            GameObject original = this.gameObject.Value;
            Vector3 zero = Vector3.zero;
            Vector3 up = Vector3.up;
            if (this.spawnPoint.Value != null)
            {
                zero = this.spawnPoint.Value.transform.position;
                if (!this.position.IsNone)
                {
                    zero += this.position.Value;
                }
                if (!this.rotation.IsNone)
                {
                    up = this.rotation.Value;
                }
                else
                {
                    up = this.spawnPoint.Value.transform.eulerAngles;
                }
            }
            else
            {
                if (!this.position.IsNone)
                {
                    zero = this.position.Value;
                }
                if (!this.rotation.IsNone)
                {
                    up = this.rotation.Value;
                }
            }
            GameObject obj3 = this.storeObject.Value;
            if (original != null)
            {
                obj3 = (GameObject) UnityEngine.Object.Instantiate(original);
                this.storeObject.Value = obj3;
            }
            else
            {
                obj3 = new GameObject("EmptyObjectFromNull");
                this.storeObject.Value = obj3;
            }
            if (obj3 != null)
            {
                obj3.transform.position = zero;
                obj3.transform.eulerAngles = up;
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.spawnPoint = null;
            FsmVector3 vector = new FsmVector3 {
                UseVariable = true
            };
            this.position = vector;
            vector = new FsmVector3 {
                UseVariable = true
            };
            this.rotation = vector;
            this.storeObject = null;
        }
    }
}

