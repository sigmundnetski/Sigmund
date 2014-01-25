using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectionSearch : MonoBehaviour
{
    public PegUIElement m_background;
    public PegUIElement m_clearButton;
    private List<DeactivatedListener> m_deactivatedListeners = new List<DeactivatedListener>();
    public UberText m_defaultText;
    private bool m_isActive;
    public GameObject m_root;
    private List<SearchClearedListener> m_searchClearedListeners = new List<SearchClearedListener>();
    public TextMesh m_searchText;
    private static int MAX_SEARCH_LENGTH = 11;

    public void Activate()
    {
        this.m_isActive = true;
    }

    public void Deactivate()
    {
        this.m_isActive = false;
        string searchText = this.GetSearchText();
        foreach (DeactivatedListener listener in this.m_deactivatedListeners)
        {
            listener(searchText);
        }
    }

    private string GetSearchText()
    {
        return this.m_searchText.text;
    }

    public bool HandleKeyboardInput()
    {
        bool flag;
        if (!this.m_isActive)
        {
            return false;
        }
        string searchText = this.GetSearchText();
        string keyboardInput = UniversalInputManager.Get().GetKeyboardInput(searchText, out flag);
        if (keyboardInput.Length > MAX_SEARCH_LENGTH)
        {
            keyboardInput = keyboardInput.Substring(0, MAX_SEARCH_LENGTH);
        }
        this.SetText(keyboardInput);
        if (flag)
        {
            this.Deactivate();
        }
        return true;
    }

    public bool IsActive()
    {
        return this.m_isActive;
    }

    private void OnClearPressed(UIEvent e)
    {
        this.SetText(string.Empty);
        foreach (SearchClearedListener listener in this.m_searchClearedListeners)
        {
            listener();
        }
    }

    public void RegisterDeactivatedListener(DeactivatedListener listener)
    {
        if (!this.m_deactivatedListeners.Contains(listener))
        {
            this.m_deactivatedListeners.Add(listener);
        }
    }

    public void RegisterSearchClearedListener(SearchClearedListener listener)
    {
        if (!this.m_searchClearedListeners.Contains(listener))
        {
            this.m_searchClearedListeners.Add(listener);
        }
    }

    public void RemoveDeactivatedListener(DeactivatedListener listener)
    {
        this.m_deactivatedListeners.Remove(listener);
    }

    public void RemoveSearchClearedListener(SearchClearedListener listener)
    {
        this.m_searchClearedListeners.Remove(listener);
    }

    private void SetText(string text)
    {
        this.m_searchText.text = text;
        bool flag = string.IsNullOrEmpty(text);
        this.m_defaultText.gameObject.SetActive(flag);
        this.m_clearButton.gameObject.SetActive(!flag);
    }

    private void Start()
    {
        this.m_defaultText.Text = GameStrings.Get("GLUE_COLLECTION_SEARCH");
        this.m_clearButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnClearPressed));
        this.m_clearButton.gameObject.SetActive(false);
    }

    public delegate void DeactivatedListener(string searchText);

    public delegate void SearchClearedListener();
}

