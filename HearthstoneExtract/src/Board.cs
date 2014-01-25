using System;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Transform m_BoneParent;
    public Transform m_ColliderParent;
    public GameObject m_MouseClickDustEffect;
    public Color m_ShadowColor = new Color(0.098f, 0.098f, 0.235f, 0.45f);
    private static Board s_instance;

    private void Awake()
    {
        s_instance = this;
        if (LoadingScreen.Get() != null)
        {
            LoadingScreen.Get().NotifyMainSceneObjectAwoke(base.gameObject);
        }
    }

    public void DimTheLights()
    {
        base.animation[base.animation.clip.name].normalizedTime = 1f;
        base.animation[base.animation.clip.name].speed = -5f;
        base.animation.Play(base.animation.clip.name);
    }

    public Transform FindBone(string name)
    {
        if (this.m_BoneParent != null)
        {
            Transform transform = this.m_BoneParent.Find(name);
            if (transform != null)
            {
                return transform;
            }
        }
        return BoardStandardGame.Get().FindBone(name);
    }

    public Collider FindCollider(string name)
    {
        if (this.m_ColliderParent != null)
        {
            Transform transform = this.m_ColliderParent.Find(name);
            if (transform != null)
            {
                return ((transform != null) ? transform.collider : null);
            }
        }
        return BoardStandardGame.Get().FindCollider(name);
    }

    public static Board Get()
    {
        return s_instance;
    }

    public GameObject GetMouseClickDustEffectPrefab()
    {
        return this.m_MouseClickDustEffect;
    }

    public void RaiseTheLights()
    {
        base.animation[base.animation.clip.name].normalizedTime = 0f;
        base.animation[base.animation.clip.name].speed = 1f;
        base.animation.Play(base.animation.clip.name);
    }

    private void Start()
    {
        ProjectedShadow.SetShadowColor(this.m_ShadowColor);
        if (base.animation != null)
        {
            base.animation[base.animation.clip.name].normalizedTime = 0.25f;
            base.animation[base.animation.clip.name].speed = -3f;
            base.animation.Play(base.animation.clip.name);
        }
    }

    public void StopDimmingTheLights()
    {
        base.animation.Stop();
    }
}

