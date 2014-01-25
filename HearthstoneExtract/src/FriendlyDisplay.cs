using System;
using UnityEngine;

public class FriendlyDisplay : MonoBehaviour
{
    private static readonly Vector3 DECK_PICKER_POSITION = new Vector3(27.051f, 1.7f, -22.4f);
    private DeckPickerTrayDisplay m_deckPickerTray;
    private bool m_deckPickerTrayLoaded;
    private bool m_netCacheReady;
    private static FriendlyDisplay s_instance;

    private void Awake()
    {
        s_instance = this;
        this.DisableOtherModeStuff();
        NetCache.Get().RegisterScreenFriendly(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        AssetLoader.Get().LoadActor("DeckPickerTray", new AssetLoader.GameObjectCallback(this.OnDeckPickerTrayLoaded));
    }

    private void DisableOtherModeStuff()
    {
        Camera camera = CameraUtils.FindFullScreenEffectsCamera(true);
        if (camera != null)
        {
            camera.GetComponent<FullScreenEffects>().Disable();
        }
    }

    public static FriendlyDisplay Get()
    {
        return s_instance;
    }

    private void InitDeckPickerTrayIfPossible()
    {
        if (this.m_netCacheReady && this.m_deckPickerTrayLoaded)
        {
            this.m_deckPickerTray.Init();
        }
    }

    private void OnDeckPickerTrayLoaded(string name, GameObject go, object callbackData)
    {
        if (go != null)
        {
            this.m_deckPickerTrayLoaded = true;
            this.m_deckPickerTray = go.GetComponent<DeckPickerTrayDisplay>();
            this.m_deckPickerTray.SetHeaderText(GameStrings.Get("GLOBAL_FRIEND_CHALLENGE_TITLE"));
            this.m_deckPickerTray.transform.parent = base.transform;
            this.m_deckPickerTray.transform.localPosition = DECK_PICKER_POSITION;
            this.InitDeckPickerTrayIfPossible();
        }
    }

    private void OnNetCacheReady()
    {
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.OnNetCacheReady));
        this.m_netCacheReady = true;
        this.InitDeckPickerTrayIfPossible();
    }

    public void Unload()
    {
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.OnNetCacheReady));
    }
}

