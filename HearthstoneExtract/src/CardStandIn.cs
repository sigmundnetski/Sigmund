using System;
using UnityEngine;

public class CardStandIn : MonoBehaviour
{
    public Card linkedCard;
    public MeshRenderer meshRenderer;
    public int slot;

    public void Hide()
    {
        this.meshRenderer.enabled = false;
    }

    public void Show()
    {
        this.meshRenderer.enabled = true;
    }
}

