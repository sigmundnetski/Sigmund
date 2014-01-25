using System;
using UnityEngine;

public class CardCrafting_WepPartSetParent : MonoBehaviour
{
    public GameObject m_Parent;
    public GameObject m_WepParts;

    public void SetParentWepParts()
    {
        if (this.m_Parent != null)
        {
            this.m_WepParts.transform.parent = this.m_Parent.transform;
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

