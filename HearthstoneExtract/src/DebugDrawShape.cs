using HutongGames.PlayMaker;
using System;
using UnityEngine;

[ActionCategory(ActionCategory.Debug), Tooltip("Draw gizmos shape")]
public class DebugDrawShape : FsmStateAction
{
    public FsmColor color;
    [RequiredField]
    public FsmOwnerDefault gameObject;
    [Tooltip("Use this for sphere gizmos")]
    public FsmFloat radius;
    public ShapeType shape;
    [Tooltip("Use this for cube gizmos")]
    public FsmVector3 size;

    public override void OnDrawGizmos()
    {
        Transform transform = base.Fsm.GetOwnerDefaultTarget(this.gameObject).transform;
        if (transform != null)
        {
            Gizmos.color = this.color.Value;
            switch (this.shape)
            {
                case ShapeType.Sphere:
                    Gizmos.DrawSphere(transform.position, this.radius.Value);
                    break;

                case ShapeType.Cube:
                    Gizmos.DrawCube(transform.position, this.size.Value);
                    break;

                case ShapeType.WireSphere:
                    Gizmos.DrawWireSphere(transform.position, this.radius.Value);
                    break;

                case ShapeType.WireCube:
                    Gizmos.DrawWireCube(transform.position, this.size.Value);
                    break;
            }
        }
    }

    public override void Reset()
    {
        this.gameObject = null;
        this.shape = ShapeType.Sphere;
        this.color = Color.grey;
        this.radius = 1f;
        this.size = new Vector3(1f, 1f, 1f);
    }

    public enum ShapeType
    {
        Sphere,
        Cube,
        WireSphere,
        WireCube
    }
}

