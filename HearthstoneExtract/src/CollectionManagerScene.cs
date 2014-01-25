using System;
using UnityEngine;

public class CollectionManagerScene : Scene
{
    private bool m_unloading;

    protected override void Awake()
    {
        base.Awake();
        AssetLoader.Get().LoadUIScreen("CollectionManager", new AssetLoader.GameObjectCallback(this.OnUIScreenLoaded));
    }

    public override bool IsUnloading()
    {
        return this.m_unloading;
    }

    private void OnUIScreenLoaded(string name, GameObject screen, object callbackData)
    {
        if (screen == null)
        {
            Debug.LogError(string.Format("CollectionManagerScene.OnUIScreenLoaded() - failed to load screen {0}", name));
        }
    }

    public override void Unload()
    {
        this.m_unloading = true;
        CollectionManagerDisplay.Get().Unload();
        this.m_unloading = false;
    }
}

