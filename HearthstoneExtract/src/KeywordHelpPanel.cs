using System;
using UnityEngine;

public class KeywordHelpPanel : MonoBehaviour
{
    public const float BOX_SCALE = 8f;
    public const float COLLECTION_MANAGER_SCALE = 4f;
    public const float DECK_HELPER_SCALE = 2.75f;
    public const float FORGE_SCALE = 4f;
    public const float GAMEPLAY_SCALE = 0.75f;
    public const float GAMEPLAY_SCALE_LARGE = 0.9f;
    public const float HAND_SCALE = 0.65f;
    public const float HISTORY_SCALE = 0.4f;
    public GameObject m_background;
    public UberText m_body;
    private float m_initialBackgroundHeight;
    private Vector3 m_initialBackgroundScale;
    public UberText m_name;
    public const float MULLIGAN_SCALE = 0.5f;
    public const float PACK_OPENING_SCALE = 2.5f;
    private float scaleToUse = 0.75f;

    private void Awake()
    {
        this.m_initialBackgroundHeight = this.m_background.renderer.bounds.size.z;
        this.m_initialBackgroundScale = this.m_background.transform.localScale;
        SceneUtils.SetLayer(base.gameObject, GameLayer.Tooltip);
    }

    public float GetHeight()
    {
        return this.m_background.renderer.bounds.size.z;
    }

    public float GetWidth()
    {
        return this.m_background.renderer.bounds.size.x;
    }

    public void Initialize(string keywordName, string keywordText)
    {
        this.SetName(keywordName);
        this.SetBodyText(keywordText);
        base.gameObject.SetActive(true);
        this.m_name.UpdateNow();
        this.m_body.UpdateNow();
        float num = this.m_name.GetTextBounds().size.y / this.scaleToUse;
        float num2 = this.m_body.GetTextBounds().size.y / this.scaleToUse;
        float num3 = 1.8f;
        float num4 = (num + num2) * num3;
        this.m_background.transform.localScale = new Vector3(this.m_initialBackgroundScale.x, (this.m_initialBackgroundScale.y * num4) / this.m_initialBackgroundHeight, this.m_initialBackgroundScale.z);
    }

    public bool IsTextRendered()
    {
        return (this.m_name.IsDone() && this.m_body.IsDone());
    }

    public void Reset()
    {
        base.transform.localScale = new Vector3(this.scaleToUse, this.scaleToUse, this.scaleToUse);
        base.transform.eulerAngles = Vector3.zero;
    }

    public void SetBodyText(string s)
    {
        this.m_body.Text = s;
    }

    public void SetName(string s)
    {
        this.m_name.Text = s;
    }

    public void SetScale(float newScale)
    {
        this.scaleToUse = newScale;
    }
}

