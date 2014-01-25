using HutongGames.PlayMaker;
using System;
using UnityEngine;

[Tooltip("Get the material instance from an object with RenderToTexture"), ActionCategory("Pegasus")]
public class GetRenderToTextureMaterial : FsmStateAction
{
    [RequiredField, CheckForComponent(typeof(RenderToTexture))]
    public FsmOwnerDefault gameObject;
    [RequiredField, UIHint(UIHint.Variable)]
    public FsmMaterial material;

    private void DoGetMaterial()
    {
        GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
        if (ownerDefaultTarget != null)
        {
            RenderToTexture component = ownerDefaultTarget.GetComponent<RenderToTexture>();
            if (component == null)
            {
                this.LogError("Missing RenderToTexture component!");
            }
            else
            {
                this.material.Value = component.GetRenderMaterial();
            }
        }
    }

    public override void OnEnter()
    {
        this.DoGetMaterial();
        base.Finish();
    }

    [Tooltip("Get the material instance from an object with RenderToTexture. This is used to get the material of the procedurally generated render plane.")]
    public override void Reset()
    {
        this.gameObject = null;
        this.material = null;
    }
}

