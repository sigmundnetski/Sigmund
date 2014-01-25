using System;
using UnityEngine;

public class StageTester : MonoBehaviour
{
    public GameObject entireObj;
    public GameObject flash;
    public GameObject fxEmitterA;
    public GameObject fxEmitterB;
    public GameObject highlightBase;
    public GameObject highlightEdge;
    public GameObject inplayObj;
    public GameObject rays;
    private int stage;

    private void Highlighted()
    {
        this.highlightBase.animation.Play();
        this.highlightEdge.animation.Play();
    }

    private void ManaUsed()
    {
        this.highlightBase.animation.CrossFade("AllyInHandActiveBaseMana", 0.3f);
        this.fxEmitterA.animation.CrossFade("AllyInHandFXUnHighlight", 0.3f);
    }

    private void OnMouseDown()
    {
        switch (this.stage)
        {
            case 0:
                this.Highlighted();
                break;

            case 1:
                this.Selected();
                break;

            case 2:
                this.ManaUsed();
                break;

            case 3:
                this.Released();
                break;
        }
        this.stage++;
    }

    public void PlayEmitterB()
    {
        this.fxEmitterB.particleEmitter.emit = true;
    }

    private void Released()
    {
        this.rays.animation.Play("AllyInHandRaysUp");
        this.flash.animation.Play("AllyInHandGlowOn");
        this.entireObj.animation.Play("AllyInHandDeath");
        this.inplayObj.animation.Play("AllyInPlaySpawn");
    }

    private void Selected()
    {
        this.highlightBase.animation.CrossFade("AllyInHandActiveBaseSelected", 0.3f);
        this.fxEmitterA.animation.Play();
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}

