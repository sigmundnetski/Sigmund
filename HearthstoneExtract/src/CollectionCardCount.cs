using System;
using UnityEngine;

public class CollectionCardCount : MonoBehaviour
{
    public GameObject m_border;
    private int m_count = 1;
    public TextMesh m_countText;
    public GameObject m_wideBorder;

    private void Awake()
    {
        this.m_countText.renderer.material.color = CollectionPageDisplay.TAUPE_COLOR;
    }

    public int GetCount()
    {
        return this.m_count;
    }

    public void Hide()
    {
        base.gameObject.SetActive(false);
    }

    public void SetCount(int cardCount)
    {
        this.m_count = cardCount;
        this.UpdateVisibility();
    }

    public void Show()
    {
        this.UpdateVisibility();
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void UpdateVisibility()
    {
        if (this.m_count <= 1)
        {
            this.Hide();
        }
        else
        {
            GameObject border;
            GameObject wideBorder;
            base.gameObject.SetActive(true);
            if (this.m_count < 10)
            {
                border = this.m_border;
                wideBorder = this.m_wideBorder;
                this.m_countText.text = string.Format(GameStrings.Get("GLUE_COLLECTION_CARD_COUNT"), this.m_count);
            }
            else
            {
                border = this.m_wideBorder;
                wideBorder = this.m_border;
                this.m_countText.text = GameStrings.Get("GLUE_COLLECTION_CARD_COUNT_LARGE");
            }
            border.SetActive(true);
            wideBorder.SetActive(false);
        }
    }
}

