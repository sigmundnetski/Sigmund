using System;
using System.Collections.Generic;
using UnityEngine;

public class DraftManager
{
    private int m_currentSlot;
    private CollectionDeck m_draftDeck;
    private int m_losses;
    private PreviousDraftInfo m_previousdraftInfo = new PreviousDraftInfo();
    private bool m_shouldShowPostScreen;
    private int m_validSlot;
    private int m_wins;
    private static DraftManager s_instance;

    public void ClearDeckInfo()
    {
        this.m_draftDeck = null;
        this.m_previousdraftInfo = new PreviousDraftInfo();
        this.m_losses = 0;
        this.m_wins = 0;
    }

    public static DraftManager Get()
    {
        if (s_instance == null)
        {
            s_instance = new DraftManager();
        }
        return s_instance;
    }

    private string GetCardID(int assetID)
    {
        return ((assetID != 0) ? CardManifest.Get().Find(assetID).CardID : string.Empty);
    }

    public CollectionDeck GetDraftDeck()
    {
        return this.m_draftDeck;
    }

    public int GetLosses()
    {
        return this.m_losses;
    }

    public List<string> GetPreviousCards()
    {
        return this.m_previousdraftInfo.cardIDs;
    }

    public int GetPreviousLosses()
    {
        return this.m_previousdraftInfo.losses;
    }

    public int GetPreviousWins()
    {
        return this.m_previousdraftInfo.wins;
    }

    public int GetSlot()
    {
        return this.m_currentSlot;
    }

    public int GetWins()
    {
        return this.m_wins;
    }

    private void InformDraftDisplayOfChoices(List<int> choices)
    {
        DraftDisplay display = DraftDisplay.Get();
        if (display != null)
        {
            if (choices.Count == 0)
            {
                display.SetDraftMode(DraftDisplay.DraftMode.ACTIVE_DRAFT_DECK);
            }
            else
            {
                display.SetDraftMode(DraftDisplay.DraftMode.DRAFTING);
                List<string> cardIDs = new List<string>();
                for (int i = 0; i < choices.Count; i++)
                {
                    int assetID = choices[i];
                    string cardID = this.GetCardID(assetID);
                    cardIDs.Add(cardID);
                }
                display.AcceptNewChoices(cardIDs);
            }
        }
    }

    public void MakeChoice(int choiceNum)
    {
        if (this.m_draftDeck == null)
        {
            Debug.LogError("DraftManager.MakeChoice(): Trying to make a draft choice while the draft deck is null");
        }
        else if (this.m_validSlot != this.m_currentSlot)
        {
            Debug.LogError("DraftManager.MakeChoice() - Tried to choose two cards from the same slot!!!");
        }
        else
        {
            this.m_validSlot++;
            Network.MakeDraftChoice(this.m_draftDeck.ID, this.m_currentSlot, choiceNum);
        }
    }

    public void NotifyOfFinalGame(bool wonFinalGame)
    {
        if (wonFinalGame)
        {
            this.m_previousdraftInfo.wins++;
        }
        else
        {
            this.m_previousdraftInfo.losses++;
        }
        this.m_shouldShowPostScreen = true;
        CollectionManager.Get().OnDraftDeckRetired(this.m_draftDeck);
    }

    public void NotifyOfPostScreenShown()
    {
        this.m_shouldShowPostScreen = false;
    }

    private void OnBegin()
    {
        Network.BeginDraft newDraftDeckID = Network.GetNewDraftDeckID();
        CollectionDeck deck = new CollectionDeck {
            ID = newDraftDeckID.DeckID
        };
        this.m_draftDeck = deck;
        this.m_draftDeck.MarkAsDraftDeck();
        this.m_currentSlot = 0;
        this.m_validSlot = 0;
        Log.Ben.Print(string.Format("DraftManager.OnBegin - Got new draft deck with ID: {0}", this.m_draftDeck.ID));
        this.InformDraftDisplayOfChoices(newDraftDeckID.Heroes);
    }

    private bool OnBnetError(BnetErrorInfo info, object userData)
    {
        if (info.GetFeature() == BnetFeature.Games)
        {
            switch (info.GetError())
            {
                case BnetError.GAME_MASTER_INVALID_FACTORY:
                case BnetError.GAME_MASTER_NO_GAME_SERVER:
                case BnetError.GAME_MASTER_NO_FACTORY:
                    this.OnGameDenied();
                    return true;
            }
        }
        return false;
    }

    private void OnChoicesAndContents()
    {
        Network.DraftChoicesAndContents draftChoicesAndContents = Network.GetDraftChoicesAndContents();
        this.m_previousdraftInfo = new PreviousDraftInfo();
        this.m_previousdraftInfo.wins = draftChoicesAndContents.Wins;
        this.m_previousdraftInfo.losses = draftChoicesAndContents.Losses;
        this.m_previousdraftInfo.cardIDs = new List<string>();
        foreach (Network.CardUserData data in draftChoicesAndContents.DeckInfo.Cards)
        {
            this.m_previousdraftInfo.cardIDs.Add(this.GetCardID(data.AssetID));
        }
        this.m_currentSlot = draftChoicesAndContents.Slot;
        this.m_validSlot = draftChoicesAndContents.Slot;
        CollectionDeck deck = new CollectionDeck {
            ID = draftChoicesAndContents.DeckInfo.Deck,
            HeroCardID = this.GetCardID(draftChoicesAndContents.HeroAssetID)
        };
        this.m_draftDeck = deck;
        this.m_draftDeck.MarkAsDraftDeck();
        foreach (Network.CardUserData data2 in draftChoicesAndContents.DeckInfo.Cards)
        {
            string cardID = this.GetCardID(data2.AssetID);
            if (!this.m_draftDeck.AddCard(cardID, data2.Premium))
            {
                Debug.LogWarning(string.Format("DraftManager.OnChoicesAndContents() - Card {0} could not be added to draft deck", cardID));
            }
        }
        this.m_losses = draftChoicesAndContents.Losses;
        this.m_wins = draftChoicesAndContents.Wins;
        this.InformDraftDisplayOfChoices(draftChoicesAndContents.Choices);
    }

    private void OnChosen()
    {
        Network.DraftChosen chosenAndNext = Network.GetChosenAndNext();
        string cardID = this.GetCardID(chosenAndNext.AssetID);
        if (this.m_currentSlot == 0)
        {
            Log.Rachelle.Print(string.Format("DraftManager.OnChosen(): hero = {0}", cardID));
            this.m_draftDeck.HeroCardID = cardID;
        }
        else
        {
            this.m_previousdraftInfo.cardIDs.Add(cardID);
            this.m_draftDeck.AddCard(cardID, CardFlair.PremiumType.STANDARD);
            if (DraftDeckTray.Get() != null)
            {
                DraftDeckTray.Get().OnCardAdded(cardID);
            }
        }
        this.m_currentSlot++;
        if ((this.m_currentSlot > 30) && (DraftDisplay.Get() != null))
        {
            DraftDisplay.Get().DoDeckCompleteAnims();
        }
        this.InformDraftDisplayOfChoices(chosenAndNext.NextChoices);
    }

    private void OnDraftPurchase(bool boughtWithGold)
    {
        this.RequestDraftStart();
    }

    private void OnError()
    {
        if (SceneMgr.Get().IsModeRequested(SceneMgr.Mode.DRAFT))
        {
            Network.DraftError draftError = Network.GetDraftError();
            DraftDisplay display = DraftDisplay.Get();
            switch (draftError)
            {
                case Network.DraftError.DE_UNKNOWN:
                    Debug.LogError("DraftManager.OnError - UNKNOWN EXCEPTION - Talk to Brode or Fitch.");
                    return;

                case Network.DraftError.DE_NO_LICENSE:
                    Debug.LogWarning("DraftManager.OnError - No License.  What does this mean???");
                    return;

                case Network.DraftError.DE_RETIRE_FIRST:
                    Debug.LogError("DraftManager.OnError - You cannot start a new draft while one is in progress.");
                    return;

                case Network.DraftError.DE_NOT_IN_DRAFT:
                    if (display != null)
                    {
                        display.SetDraftMode(DraftDisplay.DraftMode.NO_ACTIVE_DRAFT);
                    }
                    return;

                case Network.DraftError.DE_NOT_IN_DRAFT_BUT_COULD_BE:
                    this.RequestDraftStart();
                    return;

                case Network.DraftError.DE_FEATURE_DISABLED:
                    Debug.LogError("DraftManager.OnError - The Forge is currently disabled.");
                    return;
            }
            Debug.LogError("DraftManager.onError - UNHANDLED ERROR - please send this to Brode. ERROR: " + draftError.ToString());
        }
    }

    private void OnGameCanceled()
    {
        Network.GameCancelInfo gameCancelInfo = Network.GetGameCancelInfo();
        DraftDisplay.Get().OnGameCanceled(gameCancelInfo);
    }

    private void OnGameDenied()
    {
        DraftDisplay.Get().OnGameDenied();
    }

    private void OnGameStarting()
    {
        ConnectAPI.NoGameReply();
        SceneMgr.Get().SetNextMode(SceneMgr.Mode.GAMEPLAY);
        LoadingScreen.Get().SetFreezeFrameCamera(Box.Get().GetCamera());
        DraftDisplay.Get().OnGotoGameServer();
    }

    private void OnGotoGameServer(BattleNet.GameServerInfo info)
    {
        Network.Get().GotoGameServer(info);
        Version.bobNetAddress = info.Address;
        Version.serverChangelist = info.Version;
        DraftDisplay.Get().OnGotoGameServer();
    }

    private void OnQueueEvent(BattleNet.QueueEvent queueEvent)
    {
        switch (queueEvent.EventType)
        {
            case BattleNet.QueueEvent.Type.QUEUE_ENTER:
            case BattleNet.QueueEvent.Type.QUEUE_DELAY:
                DraftDisplay.Get().ShowMatchingPopup();
                break;

            case BattleNet.QueueEvent.Type.QUEUE_DELAY_ERROR:
            case BattleNet.QueueEvent.Type.QUEUE_AMM_ERROR:
                this.OnGameDenied();
                break;

            case BattleNet.QueueEvent.Type.QUEUE_GAME_STARTED:
                this.OnGotoGameServer(queueEvent.GameServer);
                break;
        }
    }

    private void OnRetire()
    {
        Log.Ben.Print("DraftManager.OnRetire");
        Network.GetRetiredDraftDeckID();
        this.ClearDeckInfo();
    }

    public void RegisterMatchmakerHandlers()
    {
        Network network = Network.Get();
        network.RegisterNetHandler(Network.PacketID.GAME_STARTING, new Network.NetHandler(this.OnGameStarting));
        network.RegisterNetHandler(Network.PacketID.GAME_CANCELED, new Network.NetHandler(this.OnGameCanceled));
        network.RegisterGameQueueHandler(new Network.GameQueueHandler(this.OnQueueEvent));
        network.AddBnetErrorListener(BnetFeature.Games, new Network.BnetErrorCallback(this.OnBnetError));
    }

    public void RegisterNetHandlers()
    {
        Network network = Network.Get();
        network.RegisterNetHandler(Network.PacketID.DRAFT_BEGIN, new Network.NetHandler(this.OnBegin));
        network.RegisterNetHandler(Network.PacketID.DRAFT_RETIRE, new Network.NetHandler(this.OnRetire));
        network.RegisterNetHandler(Network.PacketID.DRAFT_CHOICES_AND_CONTENTS, new Network.NetHandler(this.OnChoicesAndContents));
        network.RegisterNetHandler(Network.PacketID.DRAFT_CHOSEN, new Network.NetHandler(this.OnChosen));
        network.RegisterNetHandler(Network.PacketID.DRAFT_ERROR, new Network.NetHandler(this.OnError));
    }

    public void RegisterStoreHandlers()
    {
        StoreManager.Get().RegisterSuccessfulPurchaseListener(new StoreManager.SuccessfulPurchaseListener(this.OnDraftPurchase));
    }

    public void RemoveMatchmakerHandlers()
    {
        Network network = Network.Get();
        network.RemoveNetHandler(Network.PacketID.GAME_STARTING);
        network.RemoveNetHandler(Network.PacketID.GAME_CANCELED);
        network.RemoveGameQueueHandler(new Network.GameQueueHandler(this.OnQueueEvent));
        network.RemoveBnetErrorListener(BnetFeature.Games, new Network.BnetErrorCallback(this.OnBnetError));
    }

    public void RemoveNetHandlers()
    {
        Network network = Network.Get();
        network.RemoveNetHandler(Network.PacketID.DRAFT_BEGIN);
        network.RemoveNetHandler(Network.PacketID.DRAFT_RETIRE);
        network.RemoveNetHandler(Network.PacketID.DRAFT_CHOICES_AND_CONTENTS);
        network.RemoveNetHandler(Network.PacketID.DRAFT_CHOSEN);
        network.RemoveNetHandler(Network.PacketID.DRAFT_ERROR);
    }

    public void RemoveStoreHandlers()
    {
        StoreManager.Get().RemoveSuccessfulPurchaseListener(new StoreManager.SuccessfulPurchaseListener(this.OnDraftPurchase));
    }

    private void RequestDraftStart()
    {
        Network.StartANewDraft();
    }

    public bool ShouldShowPostScreen()
    {
        return this.m_shouldShowPostScreen;
    }

    private class PreviousDraftInfo
    {
        public List<string> cardIDs = new List<string>();
        public int losses;
        public int wins;
    }
}

