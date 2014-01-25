namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Gets the number of Game Objects in the scene with the specified Tag.")]
    public class GetTagCount : FsmStateAction
    {
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmInt storeResult;
        [UIHint(UIHint.Tag)]
        public FsmString tag;

        public override void OnEnter()
        {
            GameObject[] objArray = GameObject.FindGameObjectsWithTag(this.tag.Value);
            if (this.storeResult != null)
            {
                this.storeResult.Value = (objArray == null) ? 0 : objArray.Length;
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.tag = "Untagged";
            this.storeResult = null;
        }
    }
}

