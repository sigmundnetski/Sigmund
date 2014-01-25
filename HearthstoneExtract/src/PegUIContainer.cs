using System;
using UnityEngine;

public class PegUIContainer : MonoBehaviour
{
    public bool isActive = true;

    public void SetActive(bool a)
    {
        if (a != base.gameObject.activeSelf)
        {
            base.gameObject.SetActive(a);
        }
    }
}

