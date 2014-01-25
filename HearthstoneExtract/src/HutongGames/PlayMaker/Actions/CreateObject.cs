namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Creates a Game Object, usually from a Prefab."), ActionCategory(ActionCategory.GameObject)]
    public class CreateObject : FsmStateAction
    {
        [Tooltip("GameObject to create. Usually a Prefab."), RequiredField]
        public FsmGameObject gameObject;
        [Tooltip("Usually 0. The group number allows you to group together network messages which allows you to filter them if so desired.")]
        public FsmInt networkGroup;
        [Tooltip("Use Network.Instantiate to create a Game Object on all clients in a networked game.")]
        public FsmBool networkInstantiate;
        [Tooltip("Position. If a Spawn Point is defined, this is used as a local offset from the Spawn Point position.")]
        public FsmVector3 position;
        [Tooltip("Rotation. NOTE: Overrides the rotation of the Spawn Point.")]
        public FsmVector3 rotation;
        [Tooltip("Optional Spawn Point.")]
        public FsmGameObject spawnPoint;
        [Tooltip("Optionally store the created object."), UIHint(UIHint.Variable)]
        public FsmGameObject storeObject;

        public override void OnEnter()
        {
            GameObject original = this.gameObject.Value;
            if (original != null)
            {
                GameObject obj3;
                Vector3 zero = Vector3.zero;
                Vector3 up = Vector3.up;
                if (this.spawnPoint.Value != null)
                {
                    zero = this.spawnPoint.Value.transform.position;
                    if (!this.position.IsNone)
                    {
                        zero += this.position.Value;
                    }
                    up = this.rotation.IsNone ? this.spawnPoint.Value.transform.eulerAngles : this.rotation.Value;
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
                if (!this.networkInstantiate.Value)
                {
                    obj3 = (GameObject) UnityEngine.Object.Instantiate(original, zero, Quaternion.Euler(up));
                }
                else
                {
                    obj3 = null;
                }
                this.storeObject.Value = obj3;
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
            this.networkInstantiate = 0;
            this.networkGroup = 0;
        }
    }
}

