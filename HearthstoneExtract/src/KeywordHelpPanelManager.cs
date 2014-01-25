using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KeywordHelpPanelManager : MonoBehaviour
{
    private const float DELAY_BEFORE_FADE_IN = 0.4f;
    private const float FADE_IN_TIME = 0.125f;
    private Actor m_actor;
    private Card m_card;
    private Pool<KeywordHelpPanel> m_keywordPanelPool = new Pool<KeywordHelpPanel>();
    public KeywordHelpPanel m_keywordPanelPrefab;
    private List<KeywordHelpPanel> m_keywordPanels = new List<KeywordHelpPanel>();
    private static KeywordHelpPanelManager s_instance;
    private float scaleToUse = 0.75f;

    private void Awake()
    {
        s_instance = this;
        this.m_keywordPanelPool.SetCreateItemCallback(new Pool<KeywordHelpPanel>.CreateItemCallback(this.CreateKeywordPanel));
        this.m_keywordPanelPool.SetDestroyItemCallback(new Pool<KeywordHelpPanel>.DestroyItemCallback(this.DestroyKeywordPanel));
        this.m_keywordPanelPool.SetExtensionCount(1);
        if (SceneMgr.Get() != null)
        {
            SceneMgr.Get().RegisterSceneUnloadedEvent(new SceneMgr.SceneUnloadedCallback(this.OnSceneUnloaded));
        }
    }

    private void CleanTweensOnPanel(KeywordHelpPanel helpPanel)
    {
        iTween.Stop(helpPanel.m_background);
        iTween.Stop(base.gameObject);
        RenderUtils.SetAlpha(helpPanel.gameObject, 0f, true);
    }

    public KeywordHelpPanel CreateKeywordPanel(int i)
    {
        return (KeywordHelpPanel) UnityEngine.Object.Instantiate(this.m_keywordPanelPrefab);
    }

    private void DestroyKeywordPanel(KeywordHelpPanel panel)
    {
        UnityEngine.Object.Destroy(panel.gameObject);
    }

    private string DoesStringNeedAdditionalMarkup(GAME_TAG tag, string text)
    {
        string str = text;
        if (tag != GAME_TAG.SPELLPOWER)
        {
            return str;
        }
        int spellPower = 1;
        if (((this.m_actor != null) && (this.m_actor.GetEntityDef() != null)) && (this.m_actor.GetEntityDef().GetCardId() == "EX1_563"))
        {
            spellPower = 5;
        }
        if (this.m_card != null)
        {
            spellPower = this.m_card.GetEntity().GetSpellPower();
        }
        if (spellPower <= 0)
        {
            spellPower = 1;
        }
        return string.Format(text, spellPower.ToString());
    }

    private void FadeInPanel(KeywordHelpPanel helpPanel)
    {
        this.CleanTweensOnPanel(helpPanel);
        float num = 0.4f;
        if ((GameState.Get() != null) && GameState.Get().GetGameEntity().IsKeywordHelpDelayOverridden())
        {
            num = 0f;
        }
        object[] args = new object[] { "alpha", 1f, "time", 0.125f, "delay", num };
        iTween.FadeTo(helpPanel.m_background, iTween.Hash(args));
        object[] objArray2 = new object[] { "onupdatetarget", base.gameObject, "onupdate", "OnUberTextFadeUpdate", "time", 0.125f, "delay", num, "to", 1f, "from", 0f };
        iTween.ValueTo(base.gameObject, iTween.Hash(objArray2));
    }

    public static KeywordHelpPanelManager Get()
    {
        return s_instance;
    }

    public Card GetCard()
    {
        return this.m_card;
    }

    private Vector3 GetPanelPosition(KeywordHelpPanel panel)
    {
        Vector3 vector = new Vector3(0f, 0f, 0f);
        KeywordHelpPanel panel2 = null;
        float num = 0f;
        float num2 = 0f;
        for (int i = 0; i < this.m_keywordPanels.Count; i++)
        {
            KeywordHelpPanel panel3 = this.m_keywordPanels[i];
            if (this.m_card.GetEntity().IsHero())
            {
                num = 1.2f;
            }
            else if (this.m_card.GetEntity().GetZone() == TAG_ZONE.PLAY)
            {
                num = 1.05f;
            }
            else
            {
                num = 0.85f;
            }
            if (this.m_actor.GetMeshRenderer() == null)
            {
                return vector;
            }
            num2 = -0.2f * this.m_actor.GetMeshRenderer().bounds.size.z;
            if (panel3 == panel)
            {
                if (i == 0)
                {
                    vector = this.m_actor.transform.position + new Vector3(this.m_actor.GetMeshRenderer().bounds.size.x * num, 0f, this.m_actor.GetMeshRenderer().bounds.extents.z + num2);
                }
                else
                {
                    vector = panel2.transform.position - new Vector3(0f, 0f, (panel2.GetHeight() * 0.35f) + (panel3.GetHeight() * 0.35f));
                }
            }
            panel2 = panel3;
        }
        return vector;
    }

    public Vector3 GetPositionOfTopPanel()
    {
        if (this.m_keywordPanels.Count == 0)
        {
            return new Vector3(0f, 0f, 0f);
        }
        return this.m_keywordPanels[0].transform.position;
    }

    public void HideKeywordHelp()
    {
        GameState state = GameState.Get();
        if (((state != null) && state.GetGameEntity().ShouldShowCrazyKeywordTooltip()) && (TutorialKeywordManager.Get() != null))
        {
            TutorialKeywordManager.Get().HideKeywordHelp();
        }
        foreach (KeywordHelpPanel panel in this.m_keywordPanels)
        {
            if (panel != null)
            {
                this.CleanTweensOnPanel(panel);
                panel.gameObject.SetActive(false);
                this.m_keywordPanelPool.Release(panel);
            }
        }
    }

    private void OnSceneUnloaded(SceneMgr.Mode prevMode, Scene prevScene, object userData)
    {
        this.m_keywordPanels.Clear();
        this.m_keywordPanelPool.Clear();
    }

    private void OnUberTextFadeUpdate(float newValue)
    {
        foreach (KeywordHelpPanel panel in this.m_keywordPanels)
        {
            RenderUtils.SetAlpha(panel.gameObject, newValue, true);
        }
    }

    [DebuggerHidden]
    private IEnumerator PositionPanelsForCM(GameObject actorObject, bool showOnRight)
    {
        return new <PositionPanelsForCM>c__Iterator44 { showOnRight = showOnRight, actorObject = actorObject, <$>showOnRight = showOnRight, <$>actorObject = actorObject, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator PositionPanelsForForge(GameObject actorObject)
    {
        return new <PositionPanelsForForge>c__Iterator45 { actorObject = actorObject, <$>actorObject = actorObject, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator PositionPanelsForGame(GameObject actorObject, bool showOnRight, bool inHand)
    {
        return new <PositionPanelsForGame>c__Iterator42 { inHand = inHand, showOnRight = showOnRight, actorObject = actorObject, <$>inHand = inHand, <$>showOnRight = showOnRight, <$>actorObject = actorObject, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator PositionPanelsForHistory(GameObject actorObject)
    {
        return new <PositionPanelsForHistory>c__Iterator43 { actorObject = actorObject, <$>actorObject = actorObject, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator PositionPanelsForPackOpening(GameObject actorObject)
    {
        return new <PositionPanelsForPackOpening>c__Iterator46 { actorObject = actorObject, <$>actorObject = actorObject, <>f__this = this };
    }

    private void PrepareToUpdateKeywordHelp(Actor actor)
    {
        this.HideKeywordHelp();
        this.m_actor = actor;
        this.m_keywordPanels.Clear();
    }

    private void SetupKeywordPanel(GAME_TAG tag)
    {
        string keywordName = GameStrings.GetKeywordName(tag);
        string description = this.DoesStringNeedAdditionalMarkup(tag, GameStrings.GetKeywordText(tag));
        this.SetupKeywordPanel(keywordName, description);
    }

    private void SetupKeywordPanel(string headline, string description)
    {
        KeywordHelpPanel item = this.m_keywordPanelPool.Acquire();
        if (item != null)
        {
            item.SetScale(this.scaleToUse);
            item.Reset();
            item.Initialize(headline, description);
            this.m_keywordPanels.Add(item);
            this.FadeInPanel(item);
        }
    }

    private bool SetupKeywordPanelIfNecessary(EntityBase entityInfo, GAME_TAG tag)
    {
        if (entityInfo.HasTag(tag))
        {
            this.SetupKeywordPanel(tag);
            return true;
        }
        if (entityInfo.HasReferencedTag(tag))
        {
            this.SetupKeywordRefPanel(tag);
            return true;
        }
        return false;
    }

    private void SetupKeywordRefPanel(GAME_TAG tag)
    {
        string keywordName = GameStrings.GetKeywordName(tag);
        string description = this.DoesStringNeedAdditionalMarkup(tag, GameStrings.GetRefKeywordText(tag));
        this.SetupKeywordPanel(keywordName, description);
    }

    private void SetUpPanels(EntityBase entityInfo)
    {
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.TAUNT);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.STEALTH);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.DIVINE_SHIELD);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.SPELLPOWER);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.ENRAGED);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.CHARGE);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.BATTLECRY);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.FROZEN);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.FREEZE);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.WINDFURY);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.SECRET);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.DEATH_RATTLE);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.RECALL);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.COMBO);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.SILENCE);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.COUNTER);
        this.SetupKeywordPanelIfNecessary(entityInfo, GAME_TAG.CANT_BE_DAMAGED);
    }

    public void ShowKeywordHelp()
    {
        foreach (KeywordHelpPanel panel in this.m_keywordPanels)
        {
            panel.gameObject.SetActive(true);
        }
    }

    public void UpdateKeywordHelp(Card c, Actor a)
    {
        this.UpdateKeywordHelp(c, a, true);
    }

    public void UpdateKeywordHelp(Card card, Actor actor, bool showOnRight)
    {
        this.m_card = card;
        this.UpdateKeywordHelp(card.GetEntity(), actor, showOnRight);
    }

    public void UpdateKeywordHelp(Entity entity, Actor actor, bool showOnRight)
    {
        this.m_card = entity.GetCard();
        if (GameState.Get().GetGameEntity().ShouldShowCrazyKeywordTooltip())
        {
            if (TutorialKeywordManager.Get() != null)
            {
                TutorialKeywordManager.Get().UpdateKeywordHelp(entity, actor, showOnRight);
            }
        }
        else
        {
            bool inHand = this.m_card.GetZone() is ZoneHand;
            if (inHand)
            {
                this.scaleToUse = 0.65f;
            }
            else
            {
                this.scaleToUse = 0.75f;
            }
            this.PrepareToUpdateKeywordHelp(actor);
            string[] strArray = GameState.Get().GetGameEntity().NotifyOfKeywordHelpPanelDisplay(entity);
            if (strArray != null)
            {
                this.SetupKeywordPanel(strArray[0], strArray[1]);
            }
            this.SetUpPanels(entity);
            base.StartCoroutine(this.PositionPanelsForGame(actor.GetMeshRenderer().gameObject, showOnRight, inHand));
            GameState.Get().GetGameEntity().NotifyOfHelpPanelDisplay(this.m_keywordPanels.Count);
        }
    }

    public void UpdateKeywordHelpForCollectionManager(EntityDef entityDef, Actor actor)
    {
        this.scaleToUse = 4f;
        this.PrepareToUpdateKeywordHelp(actor);
        this.SetUpPanels(entityDef);
        base.StartCoroutine(this.PositionPanelsForCM(actor.GetMeshRenderer().gameObject, true));
    }

    public void UpdateKeywordHelpForDeckHelper(EntityDef entityDef, Actor actor)
    {
        this.scaleToUse = 2.75f;
        this.PrepareToUpdateKeywordHelp(actor);
        this.SetUpPanels(entityDef);
        base.StartCoroutine(this.PositionPanelsForForge(actor.GetMeshRenderer().gameObject));
    }

    public void UpdateKeywordHelpForForge(EntityDef entityDef, Actor actor)
    {
        this.scaleToUse = 4f;
        this.PrepareToUpdateKeywordHelp(actor);
        this.SetUpPanels(entityDef);
        base.StartCoroutine(this.PositionPanelsForForge(actor.GetMeshRenderer().gameObject));
    }

    public void UpdateKeywordHelpForHistoryCard(Entity entity, Actor actor)
    {
        this.m_card = entity.GetCard();
        if (GameState.Get().IsMulliganPhase())
        {
            this.scaleToUse = 0.5f;
        }
        else
        {
            this.scaleToUse = 0.4f;
        }
        this.PrepareToUpdateKeywordHelp(actor);
        string[] strArray = GameState.Get().GetGameEntity().NotifyOfKeywordHelpPanelDisplay(entity);
        if (strArray != null)
        {
            this.SetupKeywordPanel(strArray[0], strArray[1]);
        }
        this.SetUpPanels(entity);
        base.StartCoroutine(this.PositionPanelsForHistory(actor.GetMeshRenderer().gameObject));
    }

    public void UpdateKeywordHelpForPackOpening(EntityDef entityDef, Actor actor)
    {
        this.scaleToUse = 2.5f;
        this.PrepareToUpdateKeywordHelp(actor);
        this.SetUpPanels(entityDef);
        base.StartCoroutine(this.PositionPanelsForPackOpening(actor.GetMeshRenderer().gameObject));
    }

    [CompilerGenerated]
    private sealed class <PositionPanelsForCM>c__Iterator44 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal GameObject <$>actorObject;
        internal bool <$>showOnRight;
        internal KeywordHelpPanelManager <>f__this;
        internal int <i>__1;
        internal KeywordHelpPanel <panel>__2;
        internal KeywordHelpPanel <prevPanel>__0;
        internal GameObject actorObject;
        internal bool showOnRight;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<prevPanel>__0 = null;
                    this.<i>__1 = 0;
                    goto Label_0180;

                case 1:
                    goto Label_0068;

                default:
                    goto Label_01A2;
            }
        Label_0068:
            while (!this.<panel>__2.IsTextRendered())
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            if (this.<i>__1 == 0)
            {
                if (this.showOnRight)
                {
                    TransformUtil.SetPoint(this.<panel>__2.gameObject, new Vector3(0f, 0f, 1f), this.actorObject, new Vector3(1f, 0f, 1f), Vector3.zero);
                }
                else
                {
                    TransformUtil.SetPoint(this.<panel>__2.gameObject, new Vector3(1f, 0f, 1f), this.actorObject, new Vector3(0f, 0f, 1f), Vector3.zero);
                }
            }
            else
            {
                TransformUtil.SetPoint(this.<panel>__2.gameObject, new Vector3(0f, 0f, 1f), this.<prevPanel>__0.gameObject, new Vector3(0f, 0f, 0f), Vector3.zero);
            }
            this.<prevPanel>__0 = this.<panel>__2;
            this.<i>__1++;
        Label_0180:
            if (this.<i>__1 < this.<>f__this.m_keywordPanels.Count)
            {
                this.<panel>__2 = this.<>f__this.m_keywordPanels[this.<i>__1];
                goto Label_0068;
            }
            this.$PC = -1;
        Label_01A2:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <PositionPanelsForForge>c__Iterator45 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal GameObject <$>actorObject;
        internal KeywordHelpPanelManager <>f__this;
        internal int <i>__1;
        internal KeywordHelpPanel <panel>__2;
        internal KeywordHelpPanel <prevPanel>__0;
        internal GameObject actorObject;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<prevPanel>__0 = null;
                    this.<i>__1 = 0;
                    goto Label_012D;

                case 1:
                    goto Label_0068;

                default:
                    goto Label_014F;
            }
        Label_0068:
            while (!this.<panel>__2.IsTextRendered())
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            if (this.<i>__1 == 0)
            {
                TransformUtil.SetPoint(this.<panel>__2.gameObject, new Vector3(0f, 0f, 1f), this.actorObject, new Vector3(1f, 0f, 1f), Vector3.zero);
            }
            else
            {
                TransformUtil.SetPoint(this.<panel>__2.gameObject, new Vector3(0f, 0f, 1f), this.<prevPanel>__0.gameObject, new Vector3(0f, 0f, 0f), Vector3.zero);
            }
            this.<prevPanel>__0 = this.<panel>__2;
            this.<i>__1++;
        Label_012D:
            if (this.<i>__1 < this.<>f__this.m_keywordPanels.Count)
            {
                this.<panel>__2 = this.<>f__this.m_keywordPanels[this.<i>__1];
                goto Label_0068;
            }
            this.$PC = -1;
        Label_014F:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <PositionPanelsForGame>c__Iterator42 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal GameObject <$>actorObject;
        internal bool <$>inHand;
        internal bool <$>showOnRight;
        internal KeywordHelpPanelManager <>f__this;
        internal KeywordHelpPanel <curPanel>__2;
        internal int <i>__1;
        internal KeywordHelpPanel <prevPanel>__0;
        internal GameObject actorObject;
        internal bool inHand;
        internal bool showOnRight;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<prevPanel>__0 = null;
                    this.<i>__1 = 0;
                    goto Label_0253;

                case 1:
                    goto Label_0068;

                default:
                    goto Label_0275;
            }
        Label_0068:
            while (!this.<curPanel>__2.IsTextRendered())
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            if (this.<i>__1 == 0)
            {
                if (this.inHand)
                {
                    if (this.showOnRight)
                    {
                        TransformUtil.SetPoint(this.<curPanel>__2.gameObject, new Vector3(0f, 0f, 1f), this.actorObject, new Vector3(1f, 0f, 1f), Vector3.zero);
                    }
                    else
                    {
                        TransformUtil.SetPoint(this.<curPanel>__2.gameObject, new Vector3(1f, 0f, 1f), this.actorObject, new Vector3(0f, 0f, 1f), Vector3.zero);
                    }
                }
                else if (this.showOnRight)
                {
                    TransformUtil.SetPoint(this.<curPanel>__2.gameObject, new Vector3(0f, 0f, 1f), this.actorObject, new Vector3(1f, 0f, 1f), new Vector3(0.5f, 0f, 0.8f));
                }
                else
                {
                    TransformUtil.SetPoint(this.<curPanel>__2.gameObject, new Vector3(1f, 0f, 1f), this.actorObject, new Vector3(0f, 0f, 1f), new Vector3(-0.78f, 0f, 0.8f));
                }
            }
            else
            {
                TransformUtil.SetPoint(this.<curPanel>__2.gameObject, new Vector3(0f, 0f, 1f), this.<prevPanel>__0.gameObject, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0.17f));
            }
            this.<prevPanel>__0 = this.<curPanel>__2;
            this.<i>__1++;
        Label_0253:
            if (this.<i>__1 < this.<>f__this.m_keywordPanels.Count)
            {
                this.<curPanel>__2 = this.<>f__this.m_keywordPanels[this.<i>__1];
                goto Label_0068;
            }
            this.$PC = -1;
        Label_0275:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <PositionPanelsForHistory>c__Iterator43 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal GameObject <$>actorObject;
        internal KeywordHelpPanelManager <>f__this;
        internal KeywordHelpPanel <curPanel>__3;
        internal int <i>__2;
        internal float <newZ>__4;
        internal KeywordHelpPanel <prevPanel>__0;
        internal bool <showHorizontally>__1;
        internal GameObject actorObject;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<prevPanel>__0 = null;
                    this.<showHorizontally>__1 = false;
                    this.<i>__2 = 0;
                    goto Label_01E5;

                case 1:
                    goto Label_006F;

                default:
                    goto Label_0207;
            }
        Label_006F:
            while (!this.<curPanel>__3.IsTextRendered())
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            if (this.<i>__2 == 0)
            {
                TransformUtil.SetPoint(this.<curPanel>__3.gameObject, new Vector3(0.5f, 0f, 1f), this.actorObject, new Vector3(0.5f, 0f, 0f), Vector3.zero);
            }
            else
            {
                this.<newZ>__4 = (this.<prevPanel>__0.GetHeight() * 0.35f) + (this.<curPanel>__3.GetHeight() * 0.35f);
                if ((this.<prevPanel>__0.transform.position.z - this.<newZ>__4) < -8.3f)
                {
                    this.<showHorizontally>__1 = true;
                }
                if (this.<showHorizontally>__1)
                {
                    TransformUtil.SetPoint(this.<curPanel>__3.gameObject, new Vector3(0f, 0f, 1f), this.<prevPanel>__0.gameObject, new Vector3(1f, 0f, 1f), Vector3.zero);
                }
                else
                {
                    TransformUtil.SetPoint(this.<curPanel>__3.gameObject, new Vector3(0.5f, 0f, 1f), this.<prevPanel>__0.gameObject, new Vector3(0.5f, 0f, 0f), Vector3.zero);
                }
            }
            this.<prevPanel>__0 = this.<curPanel>__3;
            this.<i>__2++;
        Label_01E5:
            if (this.<i>__2 < this.<>f__this.m_keywordPanels.Count)
            {
                this.<curPanel>__3 = this.<>f__this.m_keywordPanels[this.<i>__2];
                goto Label_006F;
            }
            this.$PC = -1;
        Label_0207:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <PositionPanelsForPackOpening>c__Iterator46 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal GameObject <$>actorObject;
        internal KeywordHelpPanelManager <>f__this;
        internal int <i>__1;
        internal KeywordHelpPanel <panel>__2;
        internal KeywordHelpPanel <prevPanel>__0;
        internal GameObject actorObject;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<prevPanel>__0 = null;
                    this.<i>__1 = 0;
                    goto Label_0166;

                case 1:
                    goto Label_0068;

                default:
                    goto Label_0188;
            }
        Label_0068:
            while (!this.<panel>__2.IsTextRendered())
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            if (this.<i>__1 == 0)
            {
                TransformUtil.SetPoint(this.<panel>__2.gameObject, new Vector3(1f, 0f, 1f), this.actorObject, new Vector3(0f, 0f, 1f), Vector3.zero);
                this.<panel>__2.transform.position -= new Vector3(1.2f, 0f, 0f);
            }
            else
            {
                TransformUtil.SetPoint(this.<panel>__2.gameObject, new Vector3(0f, 0f, 1f), this.<prevPanel>__0.gameObject, new Vector3(0f, 0f, 0f), Vector3.zero);
            }
            this.<prevPanel>__0 = this.<panel>__2;
            this.<i>__1++;
        Label_0166:
            if (this.<i>__1 < this.<>f__this.m_keywordPanels.Count)
            {
                this.<panel>__2 = this.<>f__this.m_keywordPanels[this.<i>__1];
                goto Label_0068;
            }
            this.$PC = -1;
        Label_0188:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }
}

