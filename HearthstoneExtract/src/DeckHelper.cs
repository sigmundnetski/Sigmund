using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeckHelper : MonoBehaviour
{
    private readonly Vector3 CHOICE_ACTOR_LOCAL_SCALE = new Vector3(5.75f, 5.75f, 5.75f);
    private List<Actor> m_actors = new List<Actor>();
    private List<string> m_cardIdChoices = new List<string>();
    public StandardPegButtonNew m_endButton;
    public PegUIElement m_inputBlocker;
    public UberText m_instructionText;
    private List<DelStateChangedListener> m_listeners = new List<DelStateChangedListener>();
    public Collider m_pickArea;
    public GameObject m_rootObject;
    private bool m_shown;
    private static DeckHelper s_instance;

    private void Awake()
    {
        s_instance = this;
        this.m_endButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.EndButtonClick));
        this.m_endButton.SetText(GameStrings.Get("GLOBAL_DONE"));
        this.m_inputBlocker.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.EndButtonClick));
    }

    private void CleanOldChoices()
    {
        this.m_cardIdChoices.Clear();
        foreach (Actor actor in this.m_actors)
        {
            UnityEngine.Object.Destroy(actor.gameObject);
        }
        this.m_actors.Clear();
    }

    private void EndButtonClick(UIEvent e)
    {
        this.Hide();
    }

    public void FinishDeckTileMove(CollectionDeckTileVisual tile)
    {
        tile.Show();
        tile.GetActor().GetSpell(SpellType.SUMMON_IN).ActivateState(SpellStateType.BIRTH);
        tile.GetMovingActor().Hide();
        UnityEngine.Object.Destroy(tile.GetMovingActor().gameObject);
    }

    private void FireStateChangedEvent()
    {
        foreach (DelStateChangedListener listener in this.m_listeners)
        {
            listener(this.m_shown);
        }
    }

    public static DeckHelper Get()
    {
        return s_instance;
    }

    public List<string> GetCardIDChoices()
    {
        return this.m_cardIdChoices;
    }

    private bool HaveActorsForAllChoices()
    {
        return (this.m_actors.Count == this.m_cardIdChoices.Count);
    }

    public void Hide()
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            this.CleanOldChoices();
            this.m_rootObject.SetActive(false);
            this.FireStateChangedEvent();
        }
    }

    public bool IsActive()
    {
        return this.m_shown;
    }

    private void OnActorLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogWarning(string.Format("DeckHelper.OnActorLoaded() - FAILED to load actor \"{0}\"", name));
        }
        else
        {
            Actor component = go.GetComponent<Actor>();
            if (component == null)
            {
                Debug.LogWarning(string.Format("DeckHelper.OnActorLoaded() - ERROR actor \"{0}\" has no Actor component", name));
            }
            else
            {
                component.transform.parent = base.transform;
                ActorLoadCallback callback = (ActorLoadCallback) callbackData;
                RDMDeckEntry choice = callback.choice;
                EntityDef entityDef = choice.EntityDef;
                CardDef cardDef = callback.cardDef;
                CardFlair cardFlair = choice.Flair;
                component.SetEntityDef(entityDef);
                component.SetCardDef(cardDef);
                component.SetCardFlair(cardFlair);
                component.UpdateAllComponents();
                component.gameObject.name = cardDef.name + "_actor";
                component.GetCollider().gameObject.AddComponent<DeckHelperVisual>().SetActor(component);
                this.m_actors.Add(component);
                if (this.HaveActorsForAllChoices())
                {
                    this.PositionAndShowChoices();
                }
                else
                {
                    component.Hide();
                }
            }
        }
    }

    private void OnCardDefLoaded(string cardID, CardDef cardDef, object userData)
    {
        RDMDeckEntry entry = (RDMDeckEntry) userData;
        ActorLoadCallback callbackData = new ActorLoadCallback {
            choice = entry,
            cardDef = cardDef
        };
        AssetLoader.Get().LoadActor(ActorNames.GetHandActor(entry.EntityDef, entry.Flair), new AssetLoader.GameObjectCallback(this.OnActorLoaded), callbackData);
    }

    private void PositionAndShowChoices()
    {
        this.m_pickArea.enabled = true;
        float num = this.m_pickArea.bounds.center.x - this.m_pickArea.bounds.extents.x;
        float num3 = this.m_pickArea.bounds.size.x / 3f;
        float num4 = (this.m_actors.Count != 2) ? (-num3 / 2f) : 0f;
        for (int i = 0; i < this.m_actors.Count; i++)
        {
            Actor actor = this.m_actors[i];
            actor.transform.position = new Vector3((num + ((i + 1) * num3)) + num4, this.m_pickArea.transform.position.y, this.m_pickArea.transform.position.z);
            actor.Show();
            actor.ActivateSpell(SpellType.SUMMON_IN_FORGE);
            actor.transform.localScale = this.CHOICE_ACTOR_LOCAL_SCALE;
        }
        this.m_pickArea.enabled = false;
    }

    public void RegisterStateChangedListener(DelStateChangedListener listener)
    {
        if (!this.m_listeners.Contains(listener))
        {
            this.m_listeners.Add(listener);
        }
    }

    public void RemoveStateChangedListener(DelStateChangedListener listener)
    {
        this.m_listeners.Remove(listener);
    }

    public void Show()
    {
        if (!this.m_shown)
        {
            SoundManager.Get().LoadAndPlay("bar_button_A_press", base.gameObject);
            this.m_shown = true;
            this.m_rootObject.SetActive(true);
            if (!Options.Get().GetBool(Option.HAS_SEEN_DECK_HELPER, false))
            {
                NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_ANNOUNCER_CM_HELP_DECK_50"), "VO_ANNOUNCER_CM_HELP_DECK_50");
                Options.Get().SetBool(Option.HAS_SEEN_DECK_HELPER, true);
            }
            this.FireStateChangedEvent();
            this.UpdateChoices();
        }
    }

    public void UpdateChoices()
    {
        this.CleanOldChoices();
        if (this.IsActive())
        {
            RandomDeckChoices choices = RandomDeckMaker.GetChoices(CollectionManagerDisplay.Get().GetRDMDeck(), 3);
            if (choices == null)
            {
                Debug.LogError("DeckHelper.GetChoices() - Can't find choices!!!!");
            }
            else
            {
                foreach (RDMDeckEntry entry in choices.choices)
                {
                    this.m_cardIdChoices.Add(entry.EntityDef.GetCardId());
                }
                this.m_instructionText.Text = choices.displayString;
                foreach (RDMDeckEntry entry2 in choices.choices)
                {
                    Log.Ben.Print(entry2.EntityDef.GetDebugName());
                    CollectionCardCache.Get().LoadCardDef(entry2.EntityDef.GetCardId(), new CollectionCardCache.LoadCardDefCallback(this.OnCardDefLoaded), entry2);
                }
            }
        }
    }

    private class ActorLoadCallback
    {
        public CardDef cardDef;
        public RDMDeckEntry choice;
    }

    public delegate void DelStateChangedListener(bool isActive);
}

