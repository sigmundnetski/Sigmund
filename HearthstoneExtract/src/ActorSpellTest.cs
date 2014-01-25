using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ActorSpellTest : MonoBehaviour
{
    private Card m_card;
    private Vector3 m_defaultEndTurnScale;
    private ActorStateType m_defaultEndTurnState = ActorStateType.ENDTURN_WAITING;
    public EndTurnButton m_EndTurnButton;
    public Actor m_HandActor;
    private ActorStateType m_handActorState;
    private ZoneHand m_handZone;
    private bool m_initialized;
    public float m_MaxTimeSliderSec = 2f;
    public float m_MinTimeSliderSec = 0.01f;
    private bool m_normalEndTurnScale = true;
    private bool m_normalHandActorPos = true;
    private bool m_normalHandActorScale = true;
    private bool m_normalPlayActorPos = true;
    private bool m_normalPlayActorScale = true;
    public Actor m_PlayActor;
    private ActorStateType m_playActorState;
    private ZonePlay m_playZone;
    private int m_selectedSpellListIndex;
    private bool m_showSpellList;
    private List<GUIContent> m_spellListContent = new List<GUIContent>();
    private GameState m_state = GameState.Initialize();
    private bool m_summoned;

    private void Awake()
    {
        Application.runInBackground = true;
        UnityEngine.Time.timeScale = 1f;
        if (this.m_HandActor == null)
        {
            Debug.LogWarning("ActorSpellTest.Awake() - MISSING Hand Actor");
        }
        else
        {
            this.m_HandActor.Show();
        }
        if (this.m_PlayActor == null)
        {
            Debug.LogWarning("ActorSpellTest.Awake() - MISSING Play Actor");
        }
        else
        {
            this.m_PlayActor.Hide();
        }
    }

    private Spell GetSelectedSpell()
    {
        SpellTable spellTable;
        if (this.m_summoned)
        {
            spellTable = this.m_PlayActor.GetSpellTable();
        }
        else
        {
            spellTable = this.m_HandActor.GetSpellTable();
        }
        int num = 0;
        for (int i = 0; i < spellTable.m_Table.Count; i++)
        {
            SpellTableEntry entry = spellTable.m_Table[i];
            if ((entry.m_Type != SpellType.SUMMON_IN) && (entry.m_Type != SpellType.SUMMON_OUT))
            {
                if (this.m_selectedSpellListIndex == num)
                {
                    return entry.m_Spell;
                }
                num++;
            }
        }
        return null;
    }

    private void InitCard()
    {
        AssetLoader.Get().LoadCardXml("CS1_042", new AssetLoader.ObjectCallback(this.OnCardXmlLoaded));
    }

    private void InitEndTurnButton()
    {
        if (this.m_EndTurnButton != null)
        {
            this.m_defaultEndTurnScale = this.m_EndTurnButton.transform.localScale;
            this.m_EndTurnButton.GetComponentInChildren<ActorStateMgr>().ChangeState(this.m_defaultEndTurnState);
        }
    }

    private void InitZones()
    {
        foreach (Zone zone in ZoneMgr.Get().GetZones())
        {
            if (zone.m_Side == Player.Side.FRIENDLY)
            {
                ZoneHand hand = zone as ZoneHand;
                if (hand != null)
                {
                    this.m_handZone = hand;
                }
                else
                {
                    ZonePlay play = zone as ZonePlay;
                    if (play != null)
                    {
                        this.m_playZone = play;
                    }
                }
            }
        }
        if (this.m_handZone != null)
        {
            this.m_handZone.SetDoNotUpdateLayout(false);
        }
    }

    private void LayoutButtonForActorState(ActorStateMgr stateMgr, Rect rect, ActorStateType stateType, ActorStateType defaultStateType)
    {
        if (stateMgr.GetActiveStateType() == stateType)
        {
            string text = string.Format("Disable {0}", stateType);
            if (GUI.Button(rect, text))
            {
                stateMgr.ChangeState(defaultStateType);
            }
        }
        else
        {
            string str2 = string.Format("Enable {0}", stateType);
            if (GUI.Button(rect, str2))
            {
                stateMgr.ChangeState(stateType);
            }
        }
    }

    private void LayoutButtonForCardState(Actor actor, ref ActorStateType currStateType, Rect rect, ActorStateType stateType)
    {
        if (currStateType == stateType)
        {
            string text = string.Format("Disable {0}", stateType);
            if (GUI.Button(rect, text))
            {
                actor.SetActorState(ActorStateType.CARD_IDLE);
                currStateType = ActorStateType.NONE;
            }
        }
        else
        {
            string str2 = string.Format("Enable {0}", stateType);
            if (GUI.Button(rect, str2))
            {
                actor.SetActorState(stateType);
                currStateType = stateType;
            }
        }
    }

    private void LayoutCardActorStateControls()
    {
        float num = 1.15f;
        Vector2 vector = new Vector2(250f, 30f);
        Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.4f);
        Vector2 vector3 = new Vector2(vector2.x, vector2.y);
        Vector2 vector4 = vector3;
        if (!this.m_summoned)
        {
            string text = string.Format("Card State: {0}", this.m_HandActor.GetActorStateType());
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), text);
            vector4.y += 1.5f * vector.y;
            if (this.m_normalHandActorScale)
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Use Mouse Over Scale"))
                {
                    this.m_normalHandActorScale = false;
                    this.m_card.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
            }
            else if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Use Normal Scale"))
            {
                this.m_normalHandActorScale = true;
                this.m_card.transform.localScale = new Vector3(0.62f, 0.225f, 0.62f);
            }
            vector4.y += num * vector.y;
            if (this.m_normalHandActorPos)
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Use Mouse Over Position"))
                {
                    this.m_normalHandActorPos = false;
                    this.m_card.transform.position = this.m_handZone.transform.position + new Vector3(0f, 1f, 2f);
                }
            }
            else if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Use Normal Position"))
            {
                this.m_normalHandActorPos = true;
                this.m_card.transform.position = this.m_handZone.transform.position;
            }
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_HandActor, ref this.m_handActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_MOUSE_OVER);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_HandActor, ref this.m_handActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_OPPONENT_MOUSE_OVER);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_HandActor, ref this.m_handActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_SELECTABLE);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_HandActor, ref this.m_handActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_SELECTED);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_HandActor, ref this.m_handActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_PLAYABLE);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_HandActor, ref this.m_handActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_PLAYABLE_MOUSE_OVER);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_HandActor, ref this.m_handActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_OVER_PLAYFIELD);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_HandActor, ref this.m_handActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_COMBO);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_HandActor, ref this.m_handActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_COMBO_MOUSE_OVER);
            vector4.y += num * vector.y;
        }
        else
        {
            string str2 = string.Format("Card State: {0}", this.m_PlayActor.GetActorStateType());
            GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), str2);
            vector4.y += 1.5f * vector.y;
            if (this.m_normalPlayActorScale)
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Use Large Scale"))
                {
                    this.m_normalPlayActorScale = false;
                    this.m_card.transform.localScale = (Vector3) (2f * this.m_playZone.transform.localScale);
                }
            }
            else if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Use Normal Scale"))
            {
                this.m_normalPlayActorScale = true;
                this.m_card.transform.localScale = this.m_playZone.transform.localScale;
            }
            vector4.y += num * vector.y;
            if (this.m_normalPlayActorPos)
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Use Closer Position"))
                {
                    this.m_normalPlayActorPos = false;
                    this.m_card.transform.position = this.m_playZone.transform.position + new Vector3(0f, 3f, 0f);
                }
            }
            else if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Use Normal Position"))
            {
                this.m_normalPlayActorPos = true;
                this.m_card.transform.position = this.m_playZone.transform.position;
            }
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_PlayActor, ref this.m_playActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_MOUSE_OVER);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_PlayActor, ref this.m_playActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_OPPONENT_MOUSE_OVER);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_PlayActor, ref this.m_playActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_SELECTABLE);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_PlayActor, ref this.m_playActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_SELECTED);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_PlayActor, ref this.m_playActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_PLAYABLE);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_PlayActor, ref this.m_playActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_PLAYABLE_MOUSE_OVER);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_PlayActor, ref this.m_playActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_TARGETABLE);
            vector4.y += num * vector.y;
            this.LayoutButtonForCardState(this.m_PlayActor, ref this.m_playActorState, new Rect(vector4.x, vector4.y, vector.x, vector.y), ActorStateType.CARD_TARGETABLE_BAD);
            vector4.y += num * vector.y;
        }
    }

    private void LayoutEffectsControls()
    {
        if (this.m_initialized)
        {
            Vector2 vector = new Vector2(200f, 30f);
            Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.05f);
            Vector2 vector3 = new Vector2((Screen.width - vector.x) - vector2.x, vector2.y);
            Vector2 vector4 = new Vector2();
            vector4 = vector3;
            if (this.m_summoned)
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Unsummon Card"))
                {
                    this.m_HandActor.DeactivateSpell(SpellType.SUMMON_OUT);
                    this.m_PlayActor.DeactivateSpell(SpellType.SUMMON_IN);
                    this.m_PlayActor.SetCard(null);
                    this.m_PlayActor.Hide();
                    this.m_card.SetActor(this.m_HandActor);
                    this.m_HandActor.SetCard(this.m_card);
                    this.m_HandActor.Show();
                    this.m_card.UpdateActorState();
                    this.m_playZone.RemoveCard(this.m_card);
                    this.m_card.SetZone(this.m_handZone);
                    this.m_handZone.AddCard(this.m_card);
                    this.m_summoned = false;
                    this.m_normalHandActorPos = true;
                    this.m_normalHandActorScale = true;
                    this.PopulateSpellList();
                }
                vector4.y += 1.5f * vector.y;
            }
            else
            {
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Summon Card"))
                {
                    this.m_HandActor.DeactivateSpell(SpellType.SUMMON_OUT);
                    this.m_PlayActor.DeactivateSpell(SpellType.SUMMON_IN);
                    Spell spell = this.m_HandActor.ActivateSpell(SpellType.SUMMON_OUT);
                    spell.AddFinishedCallback(new Spell.FinishedCallback(this.OnSpellFinished));
                    spell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnSpellStateFinished));
                    this.m_handZone.RemoveCard(this.m_card);
                    this.m_card.SetZone(this.m_playZone);
                    this.m_playZone.AddCard(this.m_card);
                    this.m_summoned = true;
                    this.m_normalPlayActorPos = true;
                    this.m_normalPlayActorScale = true;
                }
                vector4.y += 1.5f * vector.y;
            }
            vector4.y += 1.5f * vector.y;
            if (this.m_spellListContent.Count > 0)
            {
                vector4.y += 1.5f * vector.y;
                Rect position = new Rect(vector4.x, vector4.y, vector.x, vector.y);
                vector4.y += 1f * vector.y;
                if (!this.m_showSpellList)
                {
                    Rect rect2 = new Rect(vector4.x, vector4.y, vector.x, vector.y);
                    vector4.y += 1.5f * vector.y;
                    Spell selectedSpell = this.GetSelectedSpell();
                    if (selectedSpell.GetActiveState() == SpellStateType.NONE)
                    {
                        if (GUI.Button(rect2, "Start Spell"))
                        {
                            selectedSpell.Activate();
                        }
                    }
                    else
                    {
                        SpellStateType type2 = selectedSpell.GuessNextStateType();
                        string str = string.Format("Set Spell to {0} State", type2);
                        if (GUI.Button(rect2, str))
                        {
                            selectedSpell.ChangeState(type2);
                        }
                    }
                }
                string text = string.Format("Test Spell: {0}", this.m_spellListContent[this.m_selectedSpellListIndex].text);
                GUIDropdown.List(position, ref this.m_showSpellList, ref this.m_selectedSpellListIndex, new GUIContent(text), this.m_spellListContent);
            }
        }
    }

    private void LayoutEndTurnButtonStateControls()
    {
        float num = 1.15f;
        Vector2 vector = new Vector2(300f, 30f);
        Vector2 vector2 = new Vector2(Screen.width - vector.x, Screen.height * 0.4f);
        Vector2 vector3 = new Vector2(vector2.x, vector2.y);
        Vector2 vector4 = vector3;
        ActorStateMgr componentInChildren = this.m_EndTurnButton.GetComponentInChildren<ActorStateMgr>();
        string text = string.Format("End Turn State: {0}", componentInChildren.GetActiveStateType());
        GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), text);
        vector4.y += 1.5f * vector.y;
        if (this.m_normalEndTurnScale)
        {
            if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Use Large Scale"))
            {
                this.m_normalEndTurnScale = false;
                this.m_EndTurnButton.transform.localScale = (Vector3) (2f * this.m_defaultEndTurnScale);
            }
        }
        else if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Use Normal Scale"))
        {
            this.m_normalEndTurnScale = true;
            this.m_EndTurnButton.transform.localScale = this.m_defaultEndTurnScale;
        }
        vector4.y += num * vector.y;
        foreach (ActorStateType type in componentInChildren.GetStateMap().Keys)
        {
            if (type != this.m_defaultEndTurnState)
            {
                this.LayoutButtonForActorState(componentInChildren, new Rect(vector4.x, vector4.y, vector.x, vector.y), type, this.m_defaultEndTurnState);
                vector4.y += num * vector.y;
            }
        }
    }

    private void LayoutTimeControls()
    {
        Vector2 vector = new Vector2(200f, 30f);
        Vector2 vector2 = new Vector2(Screen.width * 0.05f, Screen.height * 0.05f);
        Vector2 vector3 = new Vector2(vector2.x, vector2.y);
        Vector2 vector4 = new Vector2();
        vector4 = vector3;
        GUI.Box(new Rect(vector4.x, vector4.y, vector.x, vector.y), string.Format("Time Scale: {0}", UnityEngine.Time.timeScale));
        vector4.y += 1f * vector.y;
        UnityEngine.Time.timeScale = GUI.HorizontalSlider(new Rect(vector4.x, vector4.y, vector.x, vector.y), UnityEngine.Time.timeScale, this.m_MinTimeSliderSec, this.m_MaxTimeSliderSec);
        vector4.y += 1f * vector.y;
        if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Reset Time Scale"))
        {
            UnityEngine.Time.timeScale = 1f;
        }
        vector4.y += 1.5f * vector.y;
    }

    private void OnCardPrefabLoaded(string cardName, GameObject cardObject, object callbackData)
    {
        if (cardObject == null)
        {
            Debug.LogError(string.Format("ActorSpellTest.OnCardPrefabLoaded() - {0} does not have an asset", cardName));
        }
        else
        {
            CardDef component = cardObject.GetComponent<CardDef>();
            if (component == null)
            {
                Debug.LogError(string.Format("ActorSpellTest.OnCardPrefabLoaded() - FAILED to load card {0} from asset", cardName));
            }
            else
            {
                this.m_card.LoadCardDef(component);
                this.m_card.SetActor(this.m_HandActor);
                this.m_HandActor.SetCard(this.m_card);
                this.m_HandActor.Show();
                this.m_card.UpdateActorState();
                this.m_card.SetZone(this.m_handZone);
                this.m_handZone.AddCard(this.m_card);
                this.m_initialized = true;
                this.m_summoned = false;
                this.PopulateSpellList();
            }
        }
    }

    private void OnCardXmlLoaded(string cardId, UnityEngine.Object asset, object callbackData)
    {
        if (asset == null)
        {
            Debug.LogError(string.Format("ActorSpellTest.OnCardXmlLoaded() - {0} does not have an asset!", cardId));
        }
        else
        {
            Entity entity = new Entity();
            entity.InitCard();
            entity.SetTag(GAME_TAG.ENTITY_ID, 1);
            entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, TAG_ZONE.HAND);
            entity.SetTag(GAME_TAG.CONTROLLER, 0);
            this.m_state.AddEntity(entity);
            this.m_card = entity.GetCard();
            XmlElement rootElement = EntityDef.LoadCardXmlFromAsset(cardId, asset);
            if (rootElement != null)
            {
                entity.GetEntityDef().LoadDataFromCardXml(rootElement);
            }
            AssetLoader.Get().LoadCardPrefab(cardId, new AssetLoader.GameObjectCallback(this.OnCardPrefabLoaded));
        }
    }

    private void OnGUI()
    {
        this.LayoutTimeControls();
        this.LayoutEffectsControls();
        this.LayoutCardActorStateControls();
        this.LayoutEndTurnButtonStateControls();
    }

    public void OnSpellFinished(Spell spell, object userData)
    {
        if (spell.GetSpellType() == SpellType.SUMMON_OUT)
        {
            this.m_card.SetActor(this.m_PlayActor);
            this.m_PlayActor.SetCard(this.m_card);
            this.m_PlayActor.Show();
            this.m_card.UpdateActorState();
            this.m_PlayActor.ActivateSpell(SpellType.SUMMON_IN);
            this.PopulateSpellList();
        }
    }

    public void OnSpellStateFinished(Spell spell, SpellStateType stateType, object userData)
    {
        if (spell.GetSpellType() == SpellType.SUMMON_OUT)
        {
            this.m_HandActor.SetCard(null);
            this.m_HandActor.Hide();
        }
    }

    private void PopulateSpellList()
    {
        if (this.m_summoned)
        {
            this.PopulateSpellList(this.m_PlayActor);
        }
        else
        {
            this.PopulateSpellList(this.m_HandActor);
        }
    }

    private void PopulateSpellList(Actor actor)
    {
        this.m_spellListContent.Clear();
        SpellTable spellTable = actor.GetSpellTable();
        if ((spellTable != null) && (spellTable.m_Table.Count != 0))
        {
            for (int i = 0; i < spellTable.m_Table.Count; i++)
            {
                SpellTableEntry entry = spellTable.m_Table[i];
                if ((entry.m_Type != SpellType.SUMMON_IN) && (entry.m_Type != SpellType.SUMMON_OUT))
                {
                    this.m_spellListContent.Add(new GUIContent(entry.m_Type.ToString()));
                }
            }
        }
    }

    private void Start()
    {
        AudioListener component = Camera.main.GetComponent<AudioListener>();
        if (component == null)
        {
            component = Camera.main.gameObject.AddComponent<AudioListener>();
        }
        if (!component.enabled)
        {
            component.enabled = true;
        }
        this.InitZones();
        this.InitCard();
        this.InitEndTurnButton();
    }

    private void Update()
    {
        if (!this.m_summoned)
        {
            if ((this.m_handActorState != ActorStateType.NONE) && (this.m_HandActor.GetActorStateType() == ActorStateType.CARD_IDLE))
            {
                this.m_HandActor.SetActorState(this.m_handActorState);
            }
        }
        else if ((this.m_playActorState != ActorStateType.NONE) && (this.m_PlayActor.GetActorStateType() == ActorStateType.CARD_IDLE))
        {
            this.m_PlayActor.SetActorState(this.m_playActorState);
        }
    }
}

