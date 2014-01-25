using System;
using UnityEngine;

public class CheckBox : PegUIElement
{
    private int m_buttonID;
    public GameObject m_check;
    private bool m_checked;
    public TextMesh m_text;
    public UberText m_uberText;

    public int GetButtonID()
    {
        return this.m_buttonID;
    }

    public bool IsChecked()
    {
        return this.m_checked;
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        if (base.gameObject.activeInHierarchy)
        {
            this.SetState(PegUIElement.InteractionState.Up);
        }
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        if (base.gameObject.activeInHierarchy)
        {
            this.SetState(PegUIElement.InteractionState.Over);
        }
    }

    protected override void OnPress()
    {
        if (base.gameObject.activeInHierarchy)
        {
            this.SetState(PegUIElement.InteractionState.Down);
        }
    }

    protected override void OnRelease()
    {
        if (base.gameObject.activeInHierarchy)
        {
            this.SetState(PegUIElement.InteractionState.Over);
        }
    }

    public void SetButtonID(int id)
    {
        this.m_buttonID = id;
    }

    public void SetButtonText(string s)
    {
        if (this.m_text != null)
        {
            this.m_text.text = s;
        }
        if (this.m_uberText != null)
        {
            this.m_uberText.Text = s;
        }
    }

    public void SetChecked(bool isChecked)
    {
        this.m_checked = isChecked;
        if (this.m_checked)
        {
            this.m_check.SetActive(true);
        }
        else
        {
            this.m_check.SetActive(false);
        }
    }

    public void SetState(PegUIElement.InteractionState state)
    {
        base.SetEnabled(true);
    }

    public bool ToggleChecked()
    {
        this.SetChecked(!this.m_checked);
        return this.m_checked;
    }
}

