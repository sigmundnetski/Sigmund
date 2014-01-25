using System;
using UnityEngine;

public class BoxErrorHeader : MonoBehaviour
{
    private Box m_parent;
    private State m_state;
    public TextMesh m_TextMesh;

    public bool ChangeState(State state)
    {
        if (this.m_state == state)
        {
            return false;
        }
        this.m_state = state;
        if (state == State.SHOWN)
        {
            base.gameObject.SetActive(true);
        }
        else if (state == State.HIDDEN)
        {
            base.gameObject.SetActive(false);
        }
        return true;
    }

    public Box GetParent()
    {
        return this.m_parent;
    }

    public string GetText()
    {
        return this.m_TextMesh.text;
    }

    public void SetParent(Box parent)
    {
        this.m_parent = parent;
    }

    public void SetText(string text)
    {
        this.m_TextMesh.text = text;
        TextUtils.HackAssignOutlineText(this.m_TextMesh, text);
    }

    public void UpdateState(State state)
    {
        this.m_state = state;
        if (state == State.SHOWN)
        {
            base.gameObject.SetActive(true);
        }
        else if (state == State.HIDDEN)
        {
            base.gameObject.SetActive(false);
        }
    }

    public enum State
    {
        SHOWN,
        HIDDEN
    }
}

