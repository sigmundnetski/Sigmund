namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Finds the closest object to the specified Game Object.\nOptionally filter by Tag and Visibility.")]
    public class FindClosest : FsmStateAction
    {
        [Tooltip("Repeat every frame")]
        public bool everyFrame;
        [RequiredField, Tooltip("The GameObject to measure from.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("If checked, ignores the object that owns this FSM.")]
        public FsmBool ignoreOwner;
        [Tooltip("Only consider objects visible to the camera.")]
        public FsmBool mustBeVisible;
        [UIHint(UIHint.Variable), Tooltip("Store the distance to the closest object.")]
        public FsmFloat storeDistance;
        [UIHint(UIHint.Variable), Tooltip("Store the closest object.")]
        public FsmGameObject storeObject;
        [RequiredField, Tooltip("Only consider objects with this Tag. NOTE: It's generally a lot quicker to find objects with a Tag!"), UIHint(UIHint.Tag)]
        public FsmString withTag;

        private void DoFindClosest()
        {
            GameObject[] objArray;
            GameObject obj2 = (this.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.gameObject.GameObject.Value : base.Owner;
            if (string.IsNullOrEmpty(this.withTag.Value) || (this.withTag.Value == "Untagged"))
            {
                objArray = (GameObject[]) UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
            }
            else
            {
                objArray = GameObject.FindGameObjectsWithTag(this.withTag.Value);
            }
            GameObject obj3 = null;
            float positiveInfinity = float.PositiveInfinity;
            foreach (GameObject obj4 in objArray)
            {
                if ((!this.ignoreOwner.Value || (obj4 != base.Owner)) && (!this.mustBeVisible.Value || ActionHelpers.IsVisible(obj4)))
                {
                    Vector3 vector = obj2.transform.position - obj4.transform.position;
                    float sqrMagnitude = vector.sqrMagnitude;
                    if (sqrMagnitude < positiveInfinity)
                    {
                        positiveInfinity = sqrMagnitude;
                        obj3 = obj4;
                    }
                }
            }
            this.storeObject.Value = obj3;
            if (!this.storeDistance.IsNone)
            {
                this.storeDistance.Value = Mathf.Sqrt(positiveInfinity);
            }
        }

        public override void OnEnter()
        {
            this.DoFindClosest();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoFindClosest();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.withTag = "Untagged";
            this.ignoreOwner = 1;
            this.mustBeVisible = 0;
            this.storeObject = null;
            this.storeDistance = null;
            this.everyFrame = false;
        }
    }
}

