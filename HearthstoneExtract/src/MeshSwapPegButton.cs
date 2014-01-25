using System;
using UnityEngine;

public class MeshSwapPegButton : PegUIElement
{
    public TextMesh buttonText;
    public GameObject disabledState;
    public Vector3 downOffset;
    public GameObject downState;
    private int m_buttonID;
    private Vector3 originalPosition;
    private Vector3 originalScale;
    public GameObject overState;
    public GameObject upState;

    protected override void Awake()
    {
        this.originalPosition = this.upState.transform.localPosition;
        base.Awake();
        this.SetState(PegUIElement.InteractionState.Up);
        Bounds boundsOfChildren = TransformUtil.GetBoundsOfChildren(base.gameObject);
        if (base.GetComponent<MeshRenderer>() != null)
        {
            base.GetComponent<MeshRenderer>().bounds.SetMinMax(boundsOfChildren.min, boundsOfChildren.max);
        }
    }

    public int GetButtonID()
    {
        return this.m_buttonID;
    }

    public void Hide()
    {
        base.gameObject.SetActive(false);
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        if (base.gameObject.activeSelf)
        {
            this.SetState(PegUIElement.InteractionState.Up);
        }
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        if (base.gameObject.activeSelf)
        {
            this.SetState(PegUIElement.InteractionState.Over);
        }
    }

    protected override void OnPress()
    {
        if (base.gameObject.activeSelf)
        {
            this.SetState(PegUIElement.InteractionState.Down);
        }
    }

    protected override void OnRelease()
    {
        if (base.gameObject.activeSelf)
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
        this.buttonText.text = s;
    }

    public void SetState(PegUIElement.InteractionState state)
    {
        if (this.overState != null)
        {
            this.overState.SetActive(false);
        }
        if (this.disabledState != null)
        {
            this.disabledState.SetActive(false);
        }
        if (this.upState != null)
        {
            this.upState.SetActive(false);
        }
        if (this.downState != null)
        {
            this.downState.SetActive(false);
        }
        base.SetEnabled(true);
        switch (state)
        {
            case PegUIElement.InteractionState.Over:
                this.overState.SetActive(true);
                break;

            case PegUIElement.InteractionState.Down:
                this.downState.transform.localPosition = this.originalPosition + this.downOffset;
                this.downState.SetActive(true);
                break;

            case PegUIElement.InteractionState.Up:
                this.upState.SetActive(true);
                this.downState.transform.localPosition = this.originalPosition;
                break;

            case PegUIElement.InteractionState.Disabled:
                this.disabledState.SetActive(true);
                base.SetEnabled(false);
                break;
        }
    }

    public void Show()
    {
        base.gameObject.SetActive(true);
        this.SetState(PegUIElement.InteractionState.Up);
    }
}

