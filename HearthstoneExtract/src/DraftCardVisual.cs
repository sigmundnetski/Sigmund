using System;

public class DraftCardVisual : PegUIElement
{
    private Actor m_actor;
    private EmoteEntry m_battlecryEmote;
    private int m_cardChoice = -1;
    private bool m_chosen;

    public void ChooseThisCard()
    {
        this.m_chosen = true;
        DraftManager.Get().MakeChoice(this.m_cardChoice);
        if (this.m_actor.GetEntityDef().IsHero())
        {
            SoundManager.Get().LoadAndPlay("tournament_screen_select_hero");
        }
    }

    public Actor GetActor()
    {
        return this.m_actor;
    }

    public int GetChoiceNum()
    {
        return this.m_cardChoice;
    }

    public bool IsChosen()
    {
        return this.m_chosen;
    }

    private void OnEmoteLoaded()
    {
        this.m_battlecryEmote = new EmoteEntry();
        this.m_battlecryEmote.m_emoteType = EmoteType.PICKED;
    }

    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        this.m_actor.SetActorState(ActorStateType.CARD_IDLE);
        KeywordHelpPanelManager.Get().HideKeywordHelp();
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        if (this.m_actor.GetEntityDef().IsHero())
        {
            SoundManager.Get().LoadAndPlay("collection_manager_hero_mouse_over");
        }
        else
        {
            SoundManager.Get().LoadAndPlay("collection_manager_card_mouse_over");
        }
        this.m_actor.SetActorState(ActorStateType.CARD_MOUSE_OVER);
        KeywordHelpPanelManager.Get().UpdateKeywordHelpForForge(this.m_actor.GetEntityDef(), this.m_actor);
    }

    protected override void OnRelease()
    {
        this.ChooseThisCard();
    }

    public void SetActor(Actor actor)
    {
        this.m_actor = actor;
    }

    public void SetChoiceNum(int num)
    {
        this.m_cardChoice = num;
    }
}

