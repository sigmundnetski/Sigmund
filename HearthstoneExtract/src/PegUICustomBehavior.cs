using System;
using UnityEngine;

public abstract class PegUICustomBehavior : MonoBehaviour
{
    protected PegUICustomBehavior()
    {
    }

    public void Awake()
    {
        PegUI.Get().RegisterCustomBehavior(this);
    }

    public void OnDestroy()
    {
        PegUI.Get().UnregisterCustomBehavior(this);
    }

    public abstract bool UpdateUI();
}

