namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets an Integer Variable to a random value between Min/Max."), ActionCategory(ActionCategory.Math)]
    public class RandomInt : FsmStateAction
    {
        [Tooltip("Should the Max value be included in the possible results?")]
        public bool inclusiveMax;
        [RequiredField]
        public FsmInt max;
        [RequiredField]
        public FsmInt min;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmInt storeResult;

        public override void OnEnter()
        {
            this.storeResult.Value = !this.inclusiveMax ? UnityEngine.Random.Range(this.min.Value, this.max.Value) : UnityEngine.Random.Range(this.min.Value, this.max.Value + 1);
            base.Finish();
        }

        public override void Reset()
        {
            this.min = 0;
            this.max = 100;
            this.storeResult = null;
            this.inclusiveMax = false;
        }
    }
}

