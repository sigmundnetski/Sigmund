namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Gets a Random Game Object from the scene.\nOptionally filter by Tag.")]
    public class GetRandomObject : FsmStateAction
    {
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmGameObject storeResult;
        [UIHint(UIHint.Tag)]
        public FsmString withTag;

        private void DoGetRandomObject()
        {
            GameObject[] objArray;
            if (this.withTag.Value != "Untagged")
            {
                objArray = GameObject.FindGameObjectsWithTag(this.withTag.Value);
            }
            else
            {
                objArray = (GameObject[]) UnityEngine.Object.FindSceneObjectsOfType(typeof(GameObject));
            }
            if (objArray.Length > 0)
            {
                this.storeResult.Value = objArray[UnityEngine.Random.Range(0, objArray.Length)];
            }
            else
            {
                this.storeResult.Value = null;
            }
        }

        public override void OnEnter()
        {
            this.DoGetRandomObject();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetRandomObject();
        }

        public override void Reset()
        {
            this.withTag = "Untagged";
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}

