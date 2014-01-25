using System;
using UnityEngine;

public class FatalErrorScene : Scene
{
    protected override void Awake()
    {
        base.Awake();
        Network.AppAbort();
        if (Box.Get() != null)
        {
            Log.Mike.Print("FatalErrorScene.Awake() - destroying Box.Get().GetEventMgr().gameObject");
            UnityEngine.Object.DestroyImmediate(Box.Get().GetEventMgr().gameObject);
        }
        if (DialogManager.Get() != null)
        {
            Log.Mike.Print("FatalErrorScene.Awake() - calling DialogManager.Get().Suppress()");
            DialogManager.Get().Suppress(true);
        }
        foreach (Camera camera in Camera.allCameras)
        {
            FullScreenEffects component = camera.GetComponent<FullScreenEffects>();
            if (component != null)
            {
                object[] args = new object[] { component };
                Log.Mike.Print("FatalErrorScene.Awake() - calling FullScreenEffects.Disable() on {0}", args);
                component.Disable();
            }
        }
    }

    private void Start()
    {
        SceneMgr.Get().NotifySceneLoaded();
    }
}

