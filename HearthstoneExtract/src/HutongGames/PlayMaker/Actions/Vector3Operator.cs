namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Vector3), Tooltip("Performs most possible operations on 2 Vector3: Dot product, Cross product, Distance, Angle, Project, Reflect, Add, Subtract, Multiply, Divide, Min, Max")]
    public class Vector3Operator : FsmStateAction
    {
        public bool everyFrame;
        public Vector3Operation operation = Vector3Operation.Add;
        [UIHint(UIHint.Variable)]
        public FsmFloat storeFloatResult;
        [UIHint(UIHint.Variable)]
        public FsmVector3 storeVector3Result;
        [RequiredField]
        public FsmVector3 vector1;
        [RequiredField]
        public FsmVector3 vector2;

        private void DoVector3Operator()
        {
            Vector3 lhs = this.vector1.Value;
            Vector3 rhs = this.vector2.Value;
            switch (this.operation)
            {
                case Vector3Operation.DotProduct:
                    this.storeFloatResult.Value = Vector3.Dot(lhs, rhs);
                    break;

                case Vector3Operation.CrossProduct:
                    this.storeVector3Result.Value = Vector3.Cross(lhs, rhs);
                    break;

                case Vector3Operation.Distance:
                    this.storeFloatResult.Value = Vector3.Distance(lhs, rhs);
                    break;

                case Vector3Operation.Angle:
                    this.storeFloatResult.Value = Vector3.Angle(lhs, rhs);
                    break;

                case Vector3Operation.Project:
                    this.storeVector3Result.Value = Vector3.Project(lhs, rhs);
                    break;

                case Vector3Operation.Reflect:
                    this.storeVector3Result.Value = Vector3.Reflect(lhs, rhs);
                    break;

                case Vector3Operation.Add:
                    this.storeVector3Result.Value = lhs + rhs;
                    break;

                case Vector3Operation.Subtract:
                    this.storeVector3Result.Value = lhs - rhs;
                    break;

                case Vector3Operation.Multiply:
                {
                    Vector3 zero = Vector3.zero;
                    zero.x = lhs.x * rhs.x;
                    zero.y = lhs.y * rhs.y;
                    zero.z = lhs.z * rhs.z;
                    this.storeVector3Result.Value = zero;
                    break;
                }
                case Vector3Operation.Divide:
                {
                    Vector3 vector4 = Vector3.zero;
                    vector4.x = lhs.x / rhs.x;
                    vector4.y = lhs.y / rhs.y;
                    vector4.z = lhs.z / rhs.z;
                    this.storeVector3Result.Value = vector4;
                    break;
                }
                case Vector3Operation.Min:
                    this.storeVector3Result.Value = Vector3.Min(lhs, rhs);
                    break;

                case Vector3Operation.Max:
                    this.storeVector3Result.Value = Vector3.Max(lhs, rhs);
                    break;
            }
        }

        public override void OnEnter()
        {
            this.DoVector3Operator();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoVector3Operator();
        }

        public override void Reset()
        {
            this.vector1 = null;
            this.vector2 = null;
            this.operation = Vector3Operation.Add;
            this.storeVector3Result = null;
            this.storeFloatResult = null;
            this.everyFrame = false;
        }

        public enum Vector3Operation
        {
            DotProduct,
            CrossProduct,
            Distance,
            Angle,
            Project,
            Reflect,
            Add,
            Subtract,
            Multiply,
            Divide,
            Min,
            Max
        }
    }
}

