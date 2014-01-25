namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Performs math operation on 2 Integers: Add, Subtract, Multiply, Divide, Min, Max."), ActionCategory(ActionCategory.Math)]
    public class IntOperator : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmInt integer1;
        [RequiredField]
        public FsmInt integer2;
        public Operation operation;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmInt storeResult;

        private void DoIntOperator()
        {
            int a = this.integer1.Value;
            int b = this.integer2.Value;
            switch (this.operation)
            {
                case Operation.Add:
                    this.storeResult.Value = a + b;
                    break;

                case Operation.Subtract:
                    this.storeResult.Value = a - b;
                    break;

                case Operation.Multiply:
                    this.storeResult.Value = a * b;
                    break;

                case Operation.Divide:
                    this.storeResult.Value = a / b;
                    break;

                case Operation.Min:
                    this.storeResult.Value = Mathf.Min(a, b);
                    break;

                case Operation.Max:
                    this.storeResult.Value = Mathf.Max(a, b);
                    break;
            }
        }

        public override void OnEnter()
        {
            this.DoIntOperator();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoIntOperator();
        }

        public override void Reset()
        {
            this.integer1 = null;
            this.integer2 = null;
            this.operation = Operation.Add;
            this.storeResult = null;
            this.everyFrame = false;
        }

        public enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Min,
            Max
        }
    }
}

