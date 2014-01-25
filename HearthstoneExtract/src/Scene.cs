using System;
using UnityEngine;

public class Scene : MonoBehaviour
{
    protected virtual void Awake()
    {
        SceneMgr.Get().SetScene(this);
    }

    public virtual bool IsUnloading()
    {
        return false;
    }

    public virtual void Unload()
    {
    }
}

