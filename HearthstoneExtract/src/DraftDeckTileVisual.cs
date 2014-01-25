using System;

public class DraftDeckTileVisual : DeckTrayDeckTileVisual
{
    protected override void OnOut(PegUIElement.InteractionState oldState)
    {
        DraftDeckTray.Get().GetDeckBigCard().Hide(base.m_actor.GetEntityDef(), base.m_actor.GetCardFlair());
    }

    protected override void OnOver(PegUIElement.InteractionState oldState)
    {
        EntityDef entityDef = base.m_actor.GetEntityDef();
        CardDef cardDef = DefLoader.Get().GetCardDef(entityDef.GetCardId());
        DraftDeckTray.Get().GetDeckBigCard().Show(entityDef, base.m_actor.GetCardFlair(), cardDef, base.gameObject.transform.position);
    }
}

