using System;
using UnityEngine;

public class GemObject : MonoBehaviour
{
    private bool initialized;
    public float jiggleAmount;
    public Vector3 startingScale;

    private void Awake()
    {
        this.startingScale = base.transform.localScale;
    }

    public void Enlarge(float scaleFactor)
    {
        iTween.Stop(base.gameObject);
        object[] args = new object[] { "scale", new Vector3(this.startingScale.x * scaleFactor, this.startingScale.y * scaleFactor, this.startingScale.z * scaleFactor), "time", 0.5f, "easetype", iTween.EaseType.easeOutElastic };
        iTween.ScaleTo(base.gameObject, iTween.Hash(args));
    }

    public void Hide()
    {
        base.gameObject.SetActive(false);
    }

    public void Initialize()
    {
        this.initialized = true;
    }

    public void Jiggle()
    {
        if (!this.initialized)
        {
            this.initialized = true;
        }
        else
        {
            iTween.Stop(base.gameObject);
            base.transform.localScale = this.startingScale;
            iTween.PunchScale(base.gameObject, new Vector3(this.jiggleAmount, this.jiggleAmount, this.jiggleAmount), 1f);
        }
    }

    public void ScaleToZero()
    {
        iTween.Stop(base.gameObject);
        iTween.ScaleTo(base.gameObject, Vector3.zero, 0.5f);
    }

    public void SetToZeroThenEnlarge()
    {
        base.transform.localScale = Vector3.zero;
        this.Enlarge(1f);
    }

    public void Show()
    {
        base.gameObject.SetActive(true);
    }

    public void Shrink()
    {
        iTween.ScaleTo(base.gameObject, this.startingScale, 0.5f);
    }
}

