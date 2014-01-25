namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Get Vector3 Length."), ActionCategory(ActionCategory.Vector3)]
    public class SetHandsPosition : FsmStateAction
    {
        public FsmOwnerDefault gameObject;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmGameObject Hand01Obj;
        public FsmGameObject Hand02Obj;
        public FsmFloat HandsAngle;
        [RequiredField]
        public FsmFloat HandsDist;
        [RequiredField]
        public FsmVector3 SelectedPoint;

        private void DoCalc()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if ((ownerDefaultTarget != null) && (this.SelectedPoint != null))
            {
                float num = this.HandsDist.Value;
                if (Input.GetMouseButton(0))
                {
                    num /= 2f;
                }
                num *= 0.25f + (0.75f * Mathf.Abs(Mathf.Cos((this.HandsAngle.Value * 3.141593f) / 18f)));
                Transform transform = ownerDefaultTarget.transform;
                Vector3 position = transform.position;
                Vector3 vector2 = transform.InverseTransformPoint(this.SelectedPoint.Value);
                vector2.x = vector2.z = 0f;
                position = transform.TransformPoint(vector2);
                Vector3 eulerAngles = transform.eulerAngles;
                if (this.Hand01Obj != null)
                {
                    Vector3 vector4;
                    RaycastHit hit;
                    vector4.x = num;
                    vector4.y = 0f;
                    vector4.z = 0f;
                    transform.Rotate((float) 0f, 0f, (float) (this.HandsAngle.Value * 10f));
                    vector4 = transform.TransformDirection(vector4);
                    transform.eulerAngles = eulerAngles;
                    vector4 += this.SelectedPoint.Value;
                    vector4 -= position;
                    vector4.Normalize();
                    Vector3 origin = vector4 + position;
                    vector4 = (Vector3) (vector4 * -1f);
                    Ray ray = new Ray(origin, vector4);
                    if (ownerDefaultTarget.transform.collider.Raycast(ray, out hit, 100f))
                    {
                        this.Hand01Obj.Value.transform.position = hit.point;
                        this.Hand01Obj.Value.transform.forward = hit.normal;
                    }
                }
                if (this.Hand02Obj != null)
                {
                    Vector3 vector6;
                    RaycastHit hit2;
                    vector6.x = -num;
                    vector6.y = 0f;
                    vector6.z = 0f;
                    transform.Rotate((float) 0f, 0f, (float) (this.HandsAngle.Value * 10f));
                    vector6 = transform.TransformDirection(vector6);
                    transform.eulerAngles = eulerAngles;
                    vector6 += this.SelectedPoint.Value;
                    vector6 -= position;
                    vector6.Normalize();
                    Vector3 vector7 = vector6 + position;
                    vector6 = (Vector3) (vector6 * -1f);
                    Ray ray2 = new Ray(vector7, vector6);
                    if (ownerDefaultTarget.transform.collider.Raycast(ray2, out hit2, 100f))
                    {
                        this.Hand02Obj.Value.transform.position = hit2.point;
                        this.Hand02Obj.Value.transform.forward = hit2.normal;
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoCalc();
            base.Finish();
        }

        public override void Reset()
        {
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.HandsDist = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.HandsAngle = num;
            this.HandsDist.Value = 1f;
            this.gameObject = null;
            this.SelectedPoint = null;
            this.Hand01Obj = null;
            this.Hand02Obj = null;
        }
    }
}

