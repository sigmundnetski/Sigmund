using System;
using UnityEngine;

public class PlayButton : PegUIElement
{
    public UberText m_newPlayButtonText;
    private HighlightState m_playButtonHighlightState;
    public TextMesh m_playButtonText;

    protected override void Awake()
    {
        base.Awake();
        this.m_playButtonHighlightState = base.gameObject.GetComponentInChildren<HighlightState>();
    }

    public void ChangeHighlightState(ActorStateType stateType)
    {
        if (this.m_playButtonHighlightState != null)
        {
            this.m_playButtonHighlightState.ChangeState(stateType);
        }
    }

    public void Disable()
    {
        base.SetEnabled(false);
        if (this.m_playButtonHighlightState != null)
        {
            base.GetComponent<PlayMakerFSM>().SendEvent("Cancel");
            this.m_playButtonHighlightState.ChangeState(ActorStateType.HIGHLIGHT_OFF);
        }
    }

    public void Enable()
    {
        base.SetEnabled(true);
        this.m_newPlayButtonText.UpdateNow();
        if (this.m_playButtonHighlightState != null)
        {
            base.GetComponent<PlayMakerFSM>().SendEvent("Birth");
            if (this.m_playButtonHighlightState != null)
            {
                this.m_playButtonHighlightState.ChangeState(ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE);
            }
        }
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        object[] args = new object[] { "position", base.GetOriginalLocalPosition(), "isLocal", true, "time", 0.25f };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
        if (this.m_playButtonHighlightState != null)
        {
            this.m_playButtonHighlightState.ChangeState(ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE);
        }
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        base.SetOriginalLocalPosition();
        if (this.m_playButtonHighlightState != null)
        {
            this.m_playButtonHighlightState.ChangeState(ActorStateType.HIGHLIGHT_PRIMARY_MOUSE_OVER);
        }
    }

    protected override void OnPress()
    {
        Vector3 originalLocalPosition = base.GetOriginalLocalPosition();
        Vector3 vector2 = new Vector3(originalLocalPosition.x, originalLocalPosition.y - 0.9f, originalLocalPosition.z);
        object[] args = new object[] { "position", vector2, "isLocal", true, "time", 0.25f };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
        this.ChangeHighlightState(ActorStateType.HIGHLIGHT_OFF);
        SoundManager.Get().LoadAndPlay("collection_manager_select_hero");
    }

    protected override void OnRelease()
    {
        object[] args = new object[] { "position", base.GetOriginalLocalPosition(), "isLocal", true, "time", 0.25f };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
    }

    public void SetText(string newText)
    {
        if (this.m_playButtonText != null)
        {
            this.m_playButtonText.text = newText;
        }
        if (this.m_newPlayButtonText != null)
        {
            this.m_newPlayButtonText.Text = newText;
        }
    }
}

