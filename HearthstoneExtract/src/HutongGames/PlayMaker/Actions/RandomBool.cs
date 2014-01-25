namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Math), Tooltip("Sets a Bool Variable to True or False randomly.")]
    public class RandomBool : FsmStateAction
    {
        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public override void OnEnter()
        {
            this.storeResult.Value = UnityEngine.Random.Range(0, 100) < 50;
            base.Finish();
        }

        public override void Reset()
        {
            this.storeResult = null;
        }
    }
}

