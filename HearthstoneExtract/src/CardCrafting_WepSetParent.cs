using System;
using UnityEngine;

public class CardCrafting_WepSetParent : MonoBehaviour
{
    public GameObject m_Discription;
    public GameObject m_ManaGem;
    public GameObject m_NameBanner;
    public Transform m_OrgParent;
    public GameObject m_Parent;
    public GameObject m_Portrait;
    public GameObject m_RarityGem;
    public GameObject m_Shield;
    public GameObject m_Swords;

    public void SetBackToOrgParent()
    {
        if (this.m_OrgParent != null)
        {
            this.m_ManaGem.transform.parent = this.m_OrgParent;
        }
        this.m_Portrait.transform.parent = this.m_OrgParent;
        this.m_NameBanner.transform.parent = this.m_OrgParent;
        this.m_RarityGem.transform.parent = this.m_OrgParent;
        this.m_Discription.transform.parent = this.m_OrgParent;
        this.m_Swords.transform.parent = this.m_OrgParent;
        this.m_Shield.transform.parent = this.m_OrgParent;
    }

    public void SetParentDiscription()
    {
        if (this.m_Parent != null)
        {
            this.m_Discription.transform.parent = this.m_Parent.transform;
        }
    }

    public void SetParentManaGem()
    {
        if (this.m_Parent != null)
        {
            this.m_ManaGem.transform.parent = this.m_Parent.transform;
        }
    }

    public void SetParentNameBanner()
    {
        if (this.m_Parent != null)
        {
            this.m_NameBanner.transform.parent = this.m_Parent.transform;
        }
    }

    public void SetParentPortrait()
    {
        if (this.m_Parent != null)
        {
            this.m_Portrait.transform.parent = this.m_Parent.transform;
        }
    }

    public void SetParentRarityGem()
    {
        if (this.m_Parent != null)
        {
            this.m_RarityGem.transform.parent = this.m_Parent.transform;
        }
    }

    public void SetParentShield()
    {
        if (this.m_Parent != null)
        {
            this.m_Shield.transform.parent = this.m_Parent.transform;
        }
    }

    public void SetParentSwords()
    {
        if (this.m_Parent != null)
        {
            this.m_Swords.transform.parent = this.m_Parent.transform;
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

