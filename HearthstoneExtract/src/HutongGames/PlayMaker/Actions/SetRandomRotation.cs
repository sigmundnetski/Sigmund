namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Transform), Tooltip("Sets Random Rotation for a Game Object. Uncheck an axis to keep its current value.")]
    public class SetRandomRotation : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault gameObject;
        [RequiredField]
        public FsmBool x;
        [RequiredField]
        public FsmBool y;
        [RequiredField]
        public FsmBool z;

        private void DoRandomRotation()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                Vector3 localEulerAngles = ownerDefaultTarget.transform.localEulerAngles;
                float x = localEulerAngles.x;
                float y = localEulerAngles.y;
                float z = localEulerAngles.z;
                if (this.x.Value)
                {
                    x = UnityEngine.Random.Range(0, 360);
                }
                if (this.y.Value)
                {
                    y = UnityEngine.Random.Range(0, 360);
                }
                if (this.z.Value)
                {
                    z = UnityEngine.Random.Range(0, 360);
                }
                ownerDefaultTarget.transform.localEulerAngles = new Vector3(x, y, z);
            }
        }

        public override void OnEnter()
        {
            this.DoRandomRotation();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.x = 1;
            this.y = 1;
            this.z = 1;
        }
    }
}

