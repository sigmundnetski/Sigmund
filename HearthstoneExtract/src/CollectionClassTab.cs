using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionClassTab : PegUIElement
{
    private static readonly string CLASS_ICONS_TEXTURE_NAME = "ClassIcons";
    private TAG_CLASS m_classTag;
    public GameObject m_glowMesh;
    private bool m_isVisible = true;
    public GameObject m_newCardCount;
    public UberText m_newCardCountText;
    private int m_numNewCards;
    private bool m_selected;
    private bool m_shouldBeVisible = true;
    private Vector3 m_targetLocalPos;
    private static readonly Dictionary<TAG_CLASS, Vector2> s_classTextureOffsets;

    static CollectionClassTab()
    {
        Dictionary<TAG_CLASS, Vector2> dictionary = new Dictionary<TAG_CLASS, Vector2>();
        dictionary.Add(TAG_CLASS.MAGE, new Vector2(0f, 0f));
        dictionary.Add(TAG_CLASS.PALADIN, new Vector2(0.205f, 0f));
        dictionary.Add(TAG_CLASS.PRIEST, new Vector2(0.392f, 0f));
        dictionary.Add(TAG_CLASS.ROGUE, new Vector2(0.58f, 0f));
        dictionary.Add(TAG_CLASS.SHAMAN, new Vector2(0.774f, 0f));
        dictionary.Add(TAG_CLASS.WARLOCK, new Vector2(0f, -0.2f));
        dictionary.Add(TAG_CLASS.WARRIOR, new Vector2(0.205f, -0.2f));
        dictionary.Add(TAG_CLASS.DRUID, new Vector2(0.392f, -0.2f));
        dictionary.Add(TAG_CLASS.HUNTER, new Vector2(0.58f, -0.2f));
        dictionary.Add(TAG_CLASS.NONE, new Vector2(0.774f, -0.2f));
        s_classTextureOffsets = dictionary;
    }

    public void AnimateToTargetPosition(float animationTime, iTween.EaseType easeType)
    {
        object[] args = new object[] { "position", this.m_targetLocalPos, "isLocal", true, "time", animationTime, "easetype", easeType, "name", "position" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(base.gameObject, "position");
        iTween.MoveTo(base.gameObject, hashtable);
    }

    public TAG_CLASS GetClass()
    {
        return this.m_classTag;
    }

    private static Vector2 GetTextureOffset(TAG_CLASS classTag)
    {
        if (s_classTextureOffsets.ContainsKey(classTag))
        {
            return s_classTextureOffsets[classTag];
        }
        Debug.LogWarning(string.Format("CollectionClassTab.GetTextureOffset(): No class texture offsets exist for class {0}", classTag));
        if (s_classTextureOffsets.ContainsKey(TAG_CLASS.NONE))
        {
            return s_classTextureOffsets[TAG_CLASS.NONE];
        }
        return Vector2.zero;
    }

    public void Init(TAG_CLASS classTag)
    {
        this.m_classTag = classTag;
        this.SetClassIconsTextureOffset(base.gameObject.renderer);
        this.SetClassIconsTextureOffset(this.m_glowMesh.renderer);
        this.m_glowMesh.SetActive(false);
        this.UpdateNewCardCount(0);
    }

    public bool IsVisible()
    {
        return this.m_isVisible;
    }

    private void SetClassIconsTextureOffset(UnityEngine.Renderer renderer)
    {
        if (renderer != null)
        {
            Vector2 textureOffset = GetTextureOffset(this.m_classTag);
            foreach (Material material in renderer.materials)
            {
                if ((material.mainTexture != null) && material.mainTexture.name.Contains(CLASS_ICONS_TEXTURE_NAME))
                {
                    material.mainTextureOffset = textureOffset;
                }
            }
        }
    }

    public void SetIsVisible(bool isVisible)
    {
        this.m_isVisible = isVisible;
        base.SetEnabled(this.m_isVisible);
    }

    public void SetSelected(bool selected)
    {
        if (this.m_selected != selected)
        {
            this.m_selected = selected;
            this.m_glowMesh.SetActive(this.m_selected);
        }
    }

    public void SetTargetLocalPosition(Vector3 targetLocalPos)
    {
        this.m_targetLocalPos = targetLocalPos;
    }

    public void SetTargetVisibility(bool visible)
    {
        this.m_shouldBeVisible = visible;
    }

    public bool ShouldBeVisible()
    {
        return this.m_shouldBeVisible;
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void UpdateNewCardCount(int numNewCards)
    {
        this.m_numNewCards = numNewCards;
        this.UpdateNewCardCountVisuals();
    }

    private void UpdateNewCardCountVisuals()
    {
        object[] args = new object[] { this.m_numNewCards };
        this.m_newCardCountText.Text = GameStrings.Format("GLUE_COLLECTION_NEW_CARD_CALLOUT", args);
        bool flag = this.m_numNewCards > 0;
        this.m_newCardCount.SetActive(flag);
    }
}

