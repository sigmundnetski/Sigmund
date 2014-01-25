using System;
using UnityEngine;

public class BoardStandardGame : MonoBehaviour
{
    public Transform m_BoneParent;
    public Transform m_ColliderParent;
    private static BoardStandardGame s_instance;

    private void Awake()
    {
        s_instance = this;
        if (LoadingScreen.Get() != null)
        {
            LoadingScreen.Get().NotifyMainSceneObjectAwoke(base.gameObject);
        }
    }

    public Transform FindBone(string name)
    {
        return this.m_BoneParent.Find(name);
    }

    public Collider FindCollider(string name)
    {
        Transform transform = this.m_ColliderParent.Find(name);
        return ((transform != null) ? transform.collider : null);
    }

    public static BoardStandardGame Get()
    {
        return s_instance;
    }
}

