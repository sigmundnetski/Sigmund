using HutongGames.PlayMaker;
using System;
using UnityEngine;

[Tooltip("Shake Minions"), ActionCategory("Pegasus")]
public class ShakeMinionsAction : FsmStateAction
{
    [RequiredField, Tooltip("Custom Shake Intensity 0-1. Used when Shake Size is Custom")]
    public FsmFloat customShakeIntensity;
    [Tooltip("Impact location"), RequiredField]
    public FsmOwnerDefault gameObject;
    [RequiredField, Tooltip("Minions To Shake")]
    public MinionsToShakeEnum MinionsToShake;
    [Tooltip("Radius - 0 = for all objects"), RequiredField]
    public FsmFloat radius;
    [Tooltip("Shake Intensity"), RequiredField]
    public ShakeMinionIntensity shakeSize = ShakeMinionIntensity.SmallShake;
    [Tooltip("Shake Type"), RequiredField]
    public ShakeMinionType shakeType = ShakeMinionType.RandomDirection;

    private void DoShakeMinions()
    {
        GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
        if (ownerDefaultTarget == null)
        {
            base.Finish();
        }
        else if (this.MinionsToShake == MinionsToShakeEnum.All)
        {
            MinionShake.ShakeAllMinions(ownerDefaultTarget, this.shakeType, ownerDefaultTarget.transform.position, this.shakeSize, this.customShakeIntensity.Value, this.radius.Value, 0f);
        }
        else if (this.MinionsToShake == MinionsToShakeEnum.Target)
        {
            MinionShake.ShakeTargetMinion(ownerDefaultTarget, this.shakeType, ownerDefaultTarget.transform.position, this.shakeSize, this.customShakeIntensity.Value, 0f, 0f);
        }
    }

    public override void OnEnter()
    {
        this.DoShakeMinions();
        base.Finish();
    }

    public override void Reset()
    {
        this.gameObject = null;
        this.MinionsToShake = MinionsToShakeEnum.All;
        this.shakeType = ShakeMinionType.RandomDirection;
        this.shakeSize = ShakeMinionIntensity.SmallShake;
        this.customShakeIntensity = 0.1f;
        this.radius = 0f;
    }

    public enum MinionsToShakeEnum
    {
        All,
        Target
    }
}

