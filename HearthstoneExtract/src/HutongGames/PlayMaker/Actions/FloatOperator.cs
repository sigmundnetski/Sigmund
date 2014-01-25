namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Performs math operations on 2 Floats: Add, Subtract, Multiply, Divide, Min, Max."), ActionCategory(ActionCategory.Math)]
    public class FloatOperator : FsmStateAction
    {
        [Tooltip("Repeat every frame. Useful if the variables are changing.")]
        public bool everyFrame;
        [Tooltip("The first float."), RequiredField]
        public FsmFloat float1;
        [RequiredField, Tooltip("The second float.")]
        public FsmFloat float2;
        [Tooltip("The math operation to perform on the floats.")]
        public Operation operation;
        [Tooltip("Store the result of the operation in a float variable."), UIHint(UIHint.Variable), RequiredField]
        public FsmFloat storeResult;

        private void DoFloatOperator()
        {
            float a = this.float1.Value;
            float b = this.float2.Value;
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
            this.DoFloatOperator();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoFloatOperator();
        }

        public override void Reset()
        {
            this.float1 = null;
            this.float2 = null;
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

