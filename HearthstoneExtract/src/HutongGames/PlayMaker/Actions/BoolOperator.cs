namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Math), Tooltip("Performs boolean operations on 2 Bool Variables.")]
    public class BoolOperator : FsmStateAction
    {
        [RequiredField, Tooltip("The first Bool variable.")]
        public FsmBool bool1;
        [Tooltip("The second Bool variable."), RequiredField]
        public FsmBool bool2;
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        [Tooltip("Boolean Operation.")]
        public Operation operation;
        [Tooltip("Store the result in a Bool Variable."), RequiredField, UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        private void DoBoolOperator()
        {
            bool flag = this.bool1.Value;
            bool flag2 = this.bool2.Value;
            switch (this.operation)
            {
                case Operation.AND:
                    this.storeResult.Value = flag && flag2;
                    break;

                case Operation.NAND:
                    this.storeResult.Value = !(flag && flag2);
                    break;

                case Operation.OR:
                    this.storeResult.Value = flag || flag2;
                    break;

                case Operation.XOR:
                    this.storeResult.Value = flag ^ flag2;
                    break;
            }
        }

        public override void OnEnter()
        {
            this.DoBoolOperator();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoBoolOperator();
        }

        public override void Reset()
        {
            this.bool1 = 0;
            this.bool2 = 0;
            this.operation = Operation.AND;
            this.storeResult = null;
            this.everyFrame = false;
        }

        public enum Operation
        {
            AND,
            NAND,
            OR,
            XOR
        }
    }
}

