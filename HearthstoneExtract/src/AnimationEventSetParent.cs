using System;
using UnityEngine;

public class AnimationEventSetParent : MonoBehaviour
{
    public GameObject m_Parent;

    public void SetParent()
    {
        if (this.m_Parent != null)
        {
            base.transform.parent = this.m_Parent.transform;
        }
    }

    private void Start()
    {
        if (this.m_Parent == null)
        {
            Debug.LogError("Animation Event Set Parent is null!");
            base.enabled = false;
        }
    }
}

