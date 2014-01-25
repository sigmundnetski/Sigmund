using System;
using System.Collections.Generic;
using UnityEngine;

public class DisenchantButton : CraftingButton
{
    private void DoDisenchant()
    {
        CraftingManager.Get().craftingUI.DoDisenchant();
        base.animation.Play("CardExchange_ButtonPress1");
    }

    public override void EnableButton()
    {
        if (CraftingManager.Get().GetNumTransactions() > 0)
        {
            base.EnterUndoMode();
        }
        else
        {
            base.labelText.Text = GameStrings.Get("GLUE_CRAFTING_DISENCHANT");
            base.EnableButton();
        }
    }

    private List<string> GetPostDisenchantInvalidDeckNames()
    {
        Actor shownActor = CraftingManager.Get().GetShownActor();
        string cardId = shownActor.GetEntityDef().GetCardId();
        CardFlair cardFlair = shownActor.GetCardFlair();
        CollectionCardStack.ArtStack collectionArtStack = CollectionManager.Get().GetCollectionArtStack(cardId, cardFlair);
        int num = Mathf.Max(0, collectionArtStack.Count - 1);
        Dictionary<long, CollectionDeck> decks = CollectionManager.Get().GetDecks();
        List<string> list = new List<string>();
        foreach (CollectionDeck deck in decks.Values)
        {
            if (deck.GetCardCount(cardId, cardFlair) > num)
            {
                list.Add(deck.Name);
                Log.Rachelle.Print(string.Format("Disenchanting will invalidate deck '{0}'", deck.Name));
            }
        }
        return list;
    }

    private void OnConfirmDisenchantResponse(AlertPopup.Response response, object userData)
    {
        if (response != AlertPopup.Response.CANCEL)
        {
            this.DoDisenchant();
        }
    }

    private void OnReadyToStartDisenchant()
    {
        List<string> postDisenchantInvalidDeckNames = this.GetPostDisenchantInvalidDeckNames();
        if (postDisenchantInvalidDeckNames.Count == 0)
        {
            this.DoDisenchant();
        }
        else
        {
            string str = GameStrings.Get("GLUE_CRAFTING_DISENCHANT_CONFIRM_DESC");
            foreach (string str2 in postDisenchantInvalidDeckNames)
            {
                str = str + "\n" + str2;
            }
            AlertPopup.PopupInfo info = new AlertPopup.PopupInfo {
                m_headerText = GameStrings.Get("GLUE_CRAFTING_DISENCHANT_CONFIRM_HEADER"),
                m_text = str,
                m_showAlertIcon = false,
                m_responseDisplay = AlertPopup.ResponseDisplay.CONFIRM_CANCEL,
                m_responseCallback = new AlertPopup.ResponseCallback(this.OnConfirmDisenchantResponse)
            };
            DialogManager.Get().ShowPopup(info);
        }
    }

    protected override void OnRelease()
    {
        CollectionManager.Get().LoadAllDeckContents(new CollectionManager.DelOnAllDeckContents(this.OnReadyToStartDisenchant));
    }
}

