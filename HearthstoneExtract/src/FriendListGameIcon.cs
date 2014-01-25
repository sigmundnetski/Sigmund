using System;
using UnityEngine;

public class FriendListGameIcon : MonoBehaviour
{
    private string m_currentIcon;
    public GameObject m_Icon;
    private string m_loadingIcon;
    private BnetProgramId m_programId;

    public BnetProgramId GetProgramId()
    {
        return this.m_programId;
    }

    public bool IsIconLoading()
    {
        return (this.m_loadingIcon != null);
    }

    public bool IsIconReady()
    {
        return ((this.m_loadingIcon == null) && (this.m_currentIcon != null));
    }

    private void OnIconLoaded(string name, UnityEngine.Object obj, object callbackData)
    {
        if (name == this.m_loadingIcon)
        {
            Texture texture = obj as Texture;
            if (texture == null)
            {
                object[] messageArgs = new object[] { name, this.m_programId };
                Error.AddDevFatal("Friend List", "FriendListGameIcon.OnIconLoaded() - Failed to load {0}. ProgramId={1}", messageArgs);
                this.m_currentIcon = null;
                this.m_loadingIcon = null;
            }
            else
            {
                this.m_currentIcon = this.m_loadingIcon;
                this.m_loadingIcon = null;
                this.m_Icon.renderer.material.mainTexture = texture;
            }
        }
    }

    public void SetProgramId(BnetProgramId programId)
    {
        if (this.m_programId != programId)
        {
            this.m_programId = programId;
            this.UpdateIcon();
        }
    }

    private void UpdateIcon()
    {
        if (this.m_programId == null)
        {
            this.m_currentIcon = null;
            this.m_loadingIcon = null;
            this.m_Icon.renderer.material.mainTexture = null;
        }
        else
        {
            string textureName = BnetProgramId.GetTextureName(this.m_programId);
            if ((this.m_currentIcon != textureName) && (this.m_loadingIcon != textureName))
            {
                this.m_loadingIcon = textureName;
                AssetLoader.Get().LoadTexture(this.m_loadingIcon, new AssetLoader.ObjectCallback(this.OnIconLoaded));
            }
        }
    }
}

