using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReward : Reward
{
    private List<Actor> m_actors = new List<Actor>();
    public CardRewardCount m_cardCount;
    public GameObject m_cardParent;
    public GameObject m_duplicateCardParent;
    private GameObject m_goToRotate;
    public GameObject m_heroCardRoot;
    public GameObject m_nonHeroCardsRoot;
    public GameObject m_root;

    private void Awake()
    {
        base.Hide();
    }

    private void FinishSettingUpActor(Actor actor, CardDef cardDef)
    {
        CardRewardData data = base.Data as CardRewardData;
        actor.SetCardDef(cardDef);
        actor.SetCardFlair(new CardFlair(data.Premium));
        actor.UpdateAllComponents();
    }

    protected override void HideReward()
    {
        this.m_root.SetActive(false);
    }

    protected override void InitData()
    {
        base.SetData(new CardRewardData(), false);
    }

    private void OnActorLoaded(string name, GameObject go, object callbackData)
    {
        EntityDef entityDef = (EntityDef) callbackData;
        Actor component = go.GetComponent<Actor>();
        this.StartSettingUpNonHeroActor(component, entityDef, this.m_cardParent.transform);
        CardRewardData data = base.Data as CardRewardData;
        this.m_cardCount.SetCount(data.Count);
        if (data.Count > 1)
        {
            Actor actor = (Actor) UnityEngine.Object.Instantiate(component);
            this.StartSettingUpNonHeroActor(actor, entityDef, this.m_duplicateCardParent.transform);
        }
        DefLoader.Get().LoadCardDef(entityDef.GetCardId(), new DefLoader.LoadDefCallback<CardDef>(this.OnCardDefLoaded), entityDef);
    }

    private void OnCardDefLoaded(string cardID, CardDef cardDef, object callbackData)
    {
        EntityDef entityDef = DefLoader.Get().GetEntityDef(cardID);
        if (entityDef == null)
        {
            Debug.LogWarning(string.Format("OnCardDefLoaded() - entityDef for CardID {0} is null", cardID));
        }
        else
        {
            foreach (Actor actor in this.m_actors)
            {
                this.FinishSettingUpActor(actor, cardDef);
            }
            if (!entityDef.IsHero())
            {
                string headline = GameStrings.Get("GLOBAL_REWARD_CARD_HEADLINE");
                string details = string.Empty;
                string source = string.Empty;
                TAG_CARD_SET cardSet = entityDef.GetCardSet();
                TAG_CLASS tag = entityDef.GetClass();
                string className = GameStrings.GetClassName(tag);
                if (MissionMgr.Get().IsTutorial())
                {
                    details = MissionMgr.Get().GetTutorialCardRewardDetails();
                }
                else if (cardSet == TAG_CARD_SET.CORE)
                {
                    TAG_RARITY rarity = entityDef.GetRarity();
                    int num = CollectionManager.Get().GetNumAvailableCards(new TAG_CARD_SET?(cardSet), new TAG_CLASS?(tag), new TAG_RARITY?(rarity), null);
                    int num2 = CollectionManager.Get().GetNumCardsIOwn(new TAG_CARD_SET?(cardSet), new TAG_CLASS?(tag), new TAG_RARITY?(rarity), null, null);
                    CardRewardData data = base.Data as CardRewardData;
                    if (data.Premium == CardFlair.PremiumType.FOIL)
                    {
                        details = string.Empty;
                    }
                    else
                    {
                        if (num == num2)
                        {
                            data.InnKeeperLine = CardRewardData.InnKeeperTrigger.CORE_CLASS_SET_COMPLETE;
                        }
                        else if (num2 == 4)
                        {
                            data.InnKeeperLine = CardRewardData.InnKeeperTrigger.SECOND_REWARD_EVER;
                        }
                        object[] args = new object[] { num2, num, className };
                        details = GameStrings.Format("GAMEPLAY_REWARD_CORE_CARD_DETAILS", args);
                    }
                }
                if (base.Data.Origin == NetCache.ProfileNotice.NoticeOrigin.LEVEL_UP)
                {
                    TAG_CLASS heroClass = GameState.Get().GetLocalPlayer().GetHero().GetEntityDef().GetClass();
                    NetCache.HeroLevel heroLevel = HeroProgressUtils.GetHeroLevel(heroClass);
                    object[] objArray2 = new object[] { heroLevel.CurrentLevel.Level.ToString(), GameStrings.GetClassName(heroClass) };
                    source = GameStrings.Format("GAMEPLAY_REWARD_CARD_LEVEL_UP", objArray2);
                }
                else
                {
                    source = string.Empty;
                }
                base.SetRewardText(headline, details, source);
            }
            base.SetReady(true);
        }
    }

    protected override void OnDataSet(bool updateVisuals)
    {
        if (updateVisuals)
        {
            CardRewardData data = base.Data as CardRewardData;
            if (data == null)
            {
                Debug.LogWarning(string.Format("CardReward.SetData() - data {0} is not CardRewardData", base.Data));
            }
            else if (string.IsNullOrEmpty(data.CardID))
            {
                Debug.LogWarning(string.Format("CardReward.SetData() - data {0} has invalid cardID", data));
            }
            else
            {
                base.SetReady(false);
                EntityDef entityDef = DefLoader.Get().GetEntityDef(data.CardID);
                if (entityDef.IsHero())
                {
                    AssetLoader.Get().LoadActor("Card_Play_Hero", new AssetLoader.GameObjectCallback(this.OnHeroActorLoaded), entityDef);
                    this.m_goToRotate = this.m_heroCardRoot;
                    this.m_cardCount.Hide();
                    this.SetupHeroAchieves();
                }
                else
                {
                    string handActor = ActorNames.GetHandActor(entityDef, data.Premium);
                    AssetLoader.Get().LoadActor(handActor, new AssetLoader.GameObjectCallback(this.OnActorLoaded), entityDef);
                    this.m_goToRotate = this.m_nonHeroCardsRoot;
                }
            }
        }
    }

    private void OnHeroActorLoaded(string name, GameObject go, object callbackData)
    {
        EntityDef entityDef = (EntityDef) callbackData;
        Actor component = go.GetComponent<Actor>();
        component.SetEntityDef(entityDef);
        component.transform.parent = this.m_heroCardRoot.transform;
        component.transform.localScale = Vector3.one;
        component.transform.localPosition = Vector3.zero;
        component.transform.localRotation = Quaternion.identity;
        component.TurnOffCollider();
        component.m_healthObject.SetActive(false);
        SceneUtils.SetLayer(component.gameObject, GameLayer.IgnoreFullScreenEffects);
        this.m_actors.Add(component);
        DefLoader.Get().LoadCardDef(entityDef.GetCardId(), new DefLoader.LoadDefCallback<CardDef>(this.OnCardDefLoaded));
    }

    private void SetupHeroAchieves()
    {
        List<Achievement> achievesInGroup = AchieveManager.Get().GetAchievesInGroup(Achievement.Group.UNLOCK_HERO);
        List<Achievement> list2 = AchieveManager.Get().GetAchievesInGroup(Achievement.Group.UNLOCK_HERO, true);
        int count = achievesInGroup.Count;
        int num2 = list2.Count;
        CardRewardData data = base.Data as CardRewardData;
        string className = GameStrings.GetClassName(DefLoader.Get().GetEntityDef(data.CardID).GetClass());
        object[] args = new object[] { className };
        string headline = GameStrings.Format("GAMEPLAY_REWARD_HERO_HEADLINE", args);
        object[] objArray2 = new object[] { num2, count };
        string details = GameStrings.Format("GAMEPLAY_REWARD_HERO_DETAILS", objArray2);
        object[] objArray3 = new object[] { className };
        string source = GameStrings.Format("GAMEPLAY_REWARD_HERO_SOURCE", objArray3);
        base.SetRewardText(headline, details, source);
    }

    protected override void ShowReward()
    {
        this.m_root.SetActive(true);
        this.m_goToRotate.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
        object[] args = new object[] { "amount", new Vector3(0f, 0f, 540f), "time", 1.5f, "easeType", iTween.EaseType.easeOutElastic, "space", Space.Self };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateAdd(this.m_goToRotate.gameObject, hashtable);
    }

    private void StartSettingUpNonHeroActor(Actor actor, EntityDef entityDef, Transform parentTransform)
    {
        actor.SetEntityDef(entityDef);
        actor.transform.parent = parentTransform;
        actor.transform.localScale = Vector3.one;
        actor.transform.localPosition = Vector3.zero;
        actor.transform.localRotation = Quaternion.identity;
        actor.TurnOffCollider();
        if (base.Data.Origin != NetCache.ProfileNotice.NoticeOrigin.ACHIEVEMENT)
        {
            SceneUtils.SetLayer(actor.gameObject, GameLayer.IgnoreFullScreenEffects);
        }
        this.m_actors.Add(actor);
    }
}

