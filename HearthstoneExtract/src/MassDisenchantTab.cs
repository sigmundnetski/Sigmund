using System;
using System.Collections;
using UnityEngine;

public class MassDisenchantTab : PegUIElement
{
    public UberText m_amount;
    public GameObject m_highlight;
    private bool m_isSelected;
    private bool m_isVisible;
    private Vector3 m_originalLocalPos;
    private Vector3 m_originalScale;
    public GameObject m_root;
    private static readonly float SELECTED_LOCAL_Y_OFFSET = 0.3822131f;
    private static readonly Vector3 SELECTED_SCALE = new Vector3(0.6f, 0.6f, 0.6f);

    protected override void Awake()
    {
        base.Awake();
        this.m_highlight.SetActive(false);
        this.m_originalLocalPos = base.transform.localPosition;
        this.m_originalScale = base.transform.localScale;
    }

    public void Deselect()
    {
        if (this.m_isSelected)
        {
            this.m_isSelected = false;
            object[] args = new object[] { "scale", this.m_originalScale, "time", CollectionPageManager.SELECT_TAB_ANIM_TIME, "name", "scale" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(base.gameObject, "scale");
            iTween.ScaleTo(base.gameObject, hashtable);
            object[] objArray2 = new object[] { "position", this.m_originalLocalPos, "isLocal", true, "time", CollectionPageManager.SELECT_TAB_ANIM_TIME, "name", "position" };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.StopByName(base.gameObject, "position");
            iTween.MoveTo(base.gameObject, hashtable2);
        }
    }

    public void Hide()
    {
        this.m_isVisible = false;
        this.m_root.SetActive(false);
        base.SetEnabled(false);
    }

    public bool IsVisible()
    {
        return this.m_isVisible;
    }

    private void OnRollout(UIEvent e)
    {
        this.m_highlight.SetActive(false);
    }

    private void OnRollover(UIEvent e)
    {
        this.m_highlight.SetActive(true);
    }

    public void Select()
    {
        if (!this.m_isSelected)
        {
            this.m_isSelected = true;
            object[] args = new object[] { "scale", SELECTED_SCALE, "time", CollectionPageManager.SELECT_TAB_ANIM_TIME, "name", "scale" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(base.gameObject, "scale");
            iTween.ScaleTo(base.gameObject, hashtable);
            Vector3 originalLocalPos = this.m_originalLocalPos;
            originalLocalPos.y += SELECTED_LOCAL_Y_OFFSET;
            object[] objArray2 = new object[] { "position", originalLocalPos, "isLocal", true, "time", CollectionPageManager.SELECT_TAB_ANIM_TIME, "name", "position" };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.StopByName(base.gameObject, "position");
            iTween.MoveTo(base.gameObject, hashtable2);
        }
    }

    public void SetAmount(int amount)
    {
        this.m_amount.Text = amount.ToString();
    }

    public void Show()
    {
        this.m_isVisible = true;
        this.m_root.SetActive(true);
        base.SetEnabled(true);
    }

    private void Start()
    {
        this.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.OnRollover));
        this.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.OnRollout));
    }
}

