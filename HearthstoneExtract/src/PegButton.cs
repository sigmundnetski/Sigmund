using System;
using UnityEngine;

public class PegButton : PegUIElement
{
    private Vector3 originalTextPosition;
    private PegButtonText stateStyles;

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        base.transform.localPosition = new Vector3();
    }

    protected override void OnPress()
    {
    }

    protected override void OnRelease()
    {
    }
}

