using System;
using UnityEngine;

public class EmoteOption : MonoBehaviour
{
    public MeshRenderer backplate;
    public UberText displayText;
    public EmoteType emoteType;
    private Vector3 startingScale;
    private bool textIsGrey;
    public string textToDisplay;

    private void Awake()
    {
        this.displayText.Text = GameStrings.Get(this.textToDisplay);
        this.displayText.gameObject.SetActive(false);
        this.backplate.enabled = false;
        this.startingScale = base.transform.localScale;
        base.transform.localScale = Vector3.zero;
    }

    public void Disable()
    {
        base.collider.enabled = false;
        iTween.Stop(base.gameObject);
        object[] args = new object[] { "scale", Vector3.zero, "time", 0.1f, "easetype", iTween.EaseType.linear, "oncompletetarget", base.gameObject, "oncomplete", "FinishDisable" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(args));
    }

    public void DoClick()
    {
        EmoteHandler.Get().ResetTimeSinceLastEmote();
        GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(this.emoteType);
        Network.Get().SendEmote(this.emoteType);
        EmoteHandler.Get().HideEmotes();
    }

    public void Enable()
    {
        this.backplate.enabled = true;
        this.displayText.gameObject.SetActive(true);
        base.collider.enabled = true;
        iTween.Stop(base.gameObject);
        object[] args = new object[] { "scale", this.startingScale, "time", 0.5f, "easetype", iTween.EaseType.easeOutElastic };
        iTween.ScaleTo(base.gameObject, iTween.Hash(args));
    }

    private void FinishDisable()
    {
        if (!base.collider.enabled)
        {
            this.backplate.enabled = false;
            this.displayText.gameObject.SetActive(false);
        }
    }

    public void HandleMouseOut()
    {
        object[] args = new object[] { "scale", this.startingScale, "time", 0.2f };
        iTween.ScaleTo(base.gameObject, iTween.Hash(args));
    }

    public void HandleMouseOver()
    {
        object[] args = new object[] { "scale", (Vector3) (this.startingScale * 1.1f), "time", 0.2f };
        iTween.ScaleTo(base.gameObject, iTween.Hash(args));
    }

    private void Update()
    {
        if (EmoteHandler.Get().EmoteSpamBlocked())
        {
            if (!this.textIsGrey)
            {
                this.textIsGrey = true;
                this.displayText.TextColor = new Color(0.5372549f, 0.5372549f, 0.5372549f);
            }
        }
        else if (this.textIsGrey)
        {
            this.textIsGrey = false;
            this.displayText.TextColor = new Color(0f, 0f, 0f);
        }
    }
}

