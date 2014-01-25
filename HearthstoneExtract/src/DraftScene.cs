using System;
using UnityEngine;

public class DraftScene : Scene
{
    private bool m_unloading;

    protected override void Awake()
    {
        base.Awake();
        Network.TrackClient(Network.TrackLevel.LEVEL_INFO, Network.TrackWhat.TRACK_BUTTON_DRAFT);
        AssetLoader.Get().LoadUIScreen("Draft", new AssetLoader.GameObjectCallback(this.OnUIScreenLoaded));
    }

    public override bool IsUnloading()
    {
        return this.m_unloading;
    }

    private void OnUIScreenLoaded(string name, GameObject screen, object callbackData)
    {
        if (screen == null)
        {
            Debug.LogError(string.Format("DraftScene.OnUIScreenLoaded() - failed to load screen {0}", name));
        }
    }

    public override void Unload()
    {
        this.m_unloading = true;
        DraftDisplay.Get().Unload();
        this.m_unloading = false;
    }
}

