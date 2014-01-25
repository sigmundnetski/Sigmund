using System;
using UnityEngine;

public class SetRenderSettings : MonoBehaviour
{
    public Color m_ambient;
    private bool m_ambient_shouldUpdate;
    private Color m_lastSavedAmbient;

    private void disableAmbientUpdates()
    {
        this.m_ambient_shouldUpdate = false;
    }

    private void enableAmbientUpdates()
    {
        this.m_ambient_shouldUpdate = true;
        if ((LoadingScreen.Get() != null) && LoadingScreen.Get().IsPreviousSceneActive())
        {
            this.m_lastSavedAmbient = this.m_ambient;
            LoadingScreen.Get().RegisterPreviousSceneDestroyedListener(new LoadingScreen.PreviousSceneDestroyedCallback(this.OnPreviousSceneDestroyed));
        }
        else
        {
            RenderSettings.ambientLight = this.m_ambient;
        }
    }

    private void OnPreviousSceneDestroyed(object userData)
    {
        LoadingScreen.Get().UnregisterPreviousSceneDestroyedListener(new LoadingScreen.PreviousSceneDestroyedCallback(this.OnPreviousSceneDestroyed));
        RenderSettings.ambientLight = this.m_lastSavedAmbient;
    }

    private void Update()
    {
        if (this.m_ambient_shouldUpdate)
        {
            this.m_lastSavedAmbient = this.m_ambient;
            if ((LoadingScreen.Get() == null) || !LoadingScreen.Get().IsPreviousSceneActive())
            {
                RenderSettings.ambientLight = this.m_ambient;
            }
        }
    }
}

