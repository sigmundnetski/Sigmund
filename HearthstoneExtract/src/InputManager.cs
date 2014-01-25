using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private const float BATTLECRY_Y_OFFSET = 1f;
    private bool cardWasInsideHandLastFrame;
    public DragRotatorInfo dragRotatorInfo;
    public GameObject heldObject;
    private List<Actor> m_battleCryEffectActors;
    private Card m_battlecrySourceCard;
    private int m_battlecrySourceHandPosition;
    private Card m_cancelingBattlecrySourceCard;
    private bool m_checkForInput;
    private Card m_choiceParentCard;
    private int m_choiceParentCardHandPosition;
    private List<Entity> m_currentlyDisplayedSubCards;
    private bool m_dragging;
    private Collider m_handScrollBox;
    private Vector3 m_lastMouseDownPosition;
    private GameObject m_lastObjectMousedDown;
    private GameObject m_lastObjectRightMousedDown;
    private bool m_leftMouseButtonIsDown;
    private Card m_mousedOverCard;
    private HistoryCard m_mousedOverHistoryCard;
    private GameObject m_mousedOverObject;
    private float m_mousedOverTimer;
    private ZoneHand m_myHandZone;
    private ZonePlay m_myPlayZone;
    private ZoneWeapon m_myWeaponZone;
    private const float MIN_GRAB_Y = 80f;
    private const float MOUSE_OVER_DELAY = 0.4f;
    private static InputManager s_instance;
    private const string SUBOPTION_TRANSFORM_NAME = "SubOptionCardPosition";

    public InputManager()
    {
        DragRotatorInfo info = new DragRotatorInfo();
        DragRotatorAxisInfo info2 = new DragRotatorAxisInfo {
            m_ForceMultiplier = 25f,
            m_MinDegrees = -40f,
            m_MaxDegrees = 40f,
            m_RestSeconds = 2f
        };
        info.m_PitchInfo = info2;
        info2 = new DragRotatorAxisInfo {
            m_ForceMultiplier = 25f,
            m_MinDegrees = -45f,
            m_MaxDegrees = 45f,
            m_RestSeconds = 2f
        };
        info.m_RollInfo = info2;
        this.dragRotatorInfo = info;
        this.m_currentlyDisplayedSubCards = new List<Entity>();
        this.m_battleCryEffectActors = new List<Actor>();
    }

    private void ApplyBattlecryEffectToActor(Actor actor)
    {
        SceneUtils.SetLayer(actor.gameObject, GameLayer.IgnoreFullScreenEffects);
        object[] args = new object[] { "y", 1f, "time", 0.4f, "easeType", iTween.EaseType.easeOutQuad, "name", "position" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(actor.gameObject, "position");
        iTween.MoveBy(actor.gameObject, hashtable);
    }

    private void Awake()
    {
        s_instance = this;
    }

    private bool CancelChoiceCardOptions()
    {
        GameState state = GameState.Get();
        if (!state.IsInSubOptionMode())
        {
            return false;
        }
        this.ResetChoiceParentCard();
        this.HideSubOptionCards();
        state.CancelCurrentOptionMode();
        return true;
    }

    private bool CancelOption()
    {
        bool flag = false;
        GameState state = GameState.Get();
        if (state.IsInMainOptionMode())
        {
            state.CancelCurrentOptionMode();
        }
        if (state.IsInTargetMode())
        {
            SoundManager.Get().LoadAndPlay("CancelAttack");
            if (this.m_mousedOverCard != null)
            {
                this.DisableSkullIfNeeded(this.m_mousedOverCard);
            }
            if (TargetReticleManager.Get() != null)
            {
                TargetReticleManager.Get().DestroyFriendlyTargetArrow(true);
            }
            state.GetGameEntity().NotifyOfTargetModeCancelled();
            flag = true;
        }
        if (this.CancelChoiceCardOptions())
        {
            flag = true;
        }
        if (this.DropHeldCard(true))
        {
            flag = true;
        }
        return flag;
    }

    private void ClearBattlecrySourceCard()
    {
        if ((UniversalInputManager.IsTouchDevice != null) && (this.m_battlecrySourceCard != null))
        {
            this.EndBattleCryEffect();
        }
        this.m_battlecrySourceCard = null;
        this.m_battlecrySourceHandPosition = 0;
        EnemyActionHandler.Get().NotifyOpponentOfCardDropped();
    }

    public void DisableInput()
    {
        this.m_checkForInput = false;
    }

    private void DisableSkullIfNeeded(Card mousedOverCard)
    {
        Spell actorSpell = mousedOverCard.GetActorSpell(SpellType.SKULL);
        if (actorSpell != null)
        {
            iTween.Stop(actorSpell.gameObject);
            actorSpell.transform.localScale = Vector3.zero;
            actorSpell.Deactivate();
        }
        Network.Options.Option.SubOption selectedNetworkSubOption = GameState.Get().GetSelectedNetworkSubOption();
        if (selectedNetworkSubOption != null)
        {
            Card card = GameState.Get().GetEntity(selectedNetworkSubOption.ID).GetCard();
            if (card != null)
            {
                actorSpell = card.GetActorSpell(SpellType.SKULL);
                if (actorSpell != null)
                {
                    iTween.Stop(actorSpell.gameObject);
                    actorSpell.transform.localScale = Vector3.zero;
                    actorSpell.Deactivate();
                }
            }
        }
    }

    private void DisplayChoiceCards()
    {
        int count = this.m_currentlyDisplayedSubCards.Count;
        Transform transform = Board.Get().FindBone("SubOptionCardPosition");
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        Vector3 position = transform.position;
        float num5 = (2.85f * count) + (0.75f * (count - 1));
        float num6 = 0.5f * num5;
        float num7 = (position.x - num6) + 1.425f;
        for (int i = 0; i < count; i++)
        {
            Card card = this.m_currentlyDisplayedSubCards[i].GetCard();
            card.ShowCard();
            iTween.RotateTo(card.gameObject, eulerAngles, 0.2f);
            card.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            iTween.ScaleTo(card.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.2f);
            float x = num7;
            float y = position.y;
            float z = position.z;
            iTween.MoveTo(card.gameObject, new Vector3(x, y, z), 0.2f);
            num7 += 3.6f;
        }
    }

    private void DisplaySubOptionCards(Entity parentEntity)
    {
        GameState state = GameState.Get();
        Vector3 position = Board.Get().FindBone("SubOptionCardPosition").position;
        float num4 = 2.85f;
        float x = position.x;
        if (parentEntity.IsMinion())
        {
            Vector3 vector2;
            int selectedOptionPosition = state.GetSelectedOptionPosition();
            if (this.m_myPlayZone.GetPositionForSlot(selectedOptionPosition - 1, out vector2))
            {
                x = vector2.x;
            }
            if (selectedOptionPosition > 5)
            {
                num4 += 0.75f;
                x -= 5.925f;
            }
            else if ((selectedOptionPosition == 1) && (this.m_myPlayZone.GetCards().Count > 6))
            {
                num4 += 0.75f;
                x += 2.325f;
            }
            else
            {
                num4 += 1.8f;
                x -= 2.325f;
            }
        }
        else
        {
            num4 += 0.75f;
            x -= 1.8f;
        }
        List<int> subCardIDs = parentEntity.GetSubCardIDs();
        for (int i = 0; i < subCardIDs.Count; i++)
        {
            int id = subCardIDs[i];
            Entity item = state.GetEntity(id);
            Card card = item.GetCard();
            if (card != null)
            {
                card.ForceActorLoadForSubOptionDisplay();
                this.m_currentlyDisplayedSubCards.Add(item);
                card.transform.position = (Get().heldObject != null) ? Get().heldObject.transform.position : item.GetHeroPowerCard().transform.position;
                card.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                float num9 = x + (i * num4);
                float y = position.y;
                float z = position.z;
                iTween.MoveTo(card.gameObject, new Vector3(num9, y, z), 0.2f);
                iTween.ScaleTo(card.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.2f);
            }
        }
    }

    public void DoEndTurnButton()
    {
        GameState state = GameState.Get();
        if (!state.BlockAccessToOptionsPacket())
        {
            switch (state.GetResponseMode())
            {
                case GameState.ResponseMode.OPTION:
                {
                    Network.Options optionsPacket = state.GetOptionsPacket();
                    for (int i = 0; i < optionsPacket.List.Count; i++)
                    {
                        Network.Options.Option option = optionsPacket.List[i];
                        if ((option.Type == Network.Options.Option.OptionType.END_TURN) || (option.Type == Network.Options.Option.OptionType.PASS))
                        {
                            if (state.GetGameEntity().NotifyOfEndTurnButtonPushed())
                            {
                                state.SetSelectedOption(i);
                                state.SendOption();
                                if (TurnTimer.Get() != null)
                                {
                                    TurnTimer.Get().OnEndTurnRequested();
                                }
                                EndTurnButton.Get().SetStateToWaiting();
                            }
                            break;
                        }
                    }
                    break;
                }
                case GameState.ResponseMode.CHOICE:
                {
                    Network.Choice choicePacket = state.GetChoicePacket();
                    if (state.GetChosenEntities().Count >= choicePacket.CountMin)
                    {
                        state.SendChosenEntities();
                    }
                    break;
                }
            }
        }
    }

    private bool DoNetworkChoice(Entity entity)
    {
        GameState state = GameState.Get();
        if (!state.IsChoosableEntity(entity))
        {
            return false;
        }
        if (!state.RemoveChosenEntity(entity))
        {
            state.AddChosenEntity(entity);
            if (state.GetChoicePacket().CountMax == 1)
            {
                state.SendChosenEntities();
            }
        }
        return true;
    }

    private bool DoNetworkOptions(Entity entity)
    {
        int entityId = entity.GetEntityId();
        GameState state = GameState.Get();
        Network.Options optionsPacket = state.GetOptionsPacket();
        for (int i = 0; i < optionsPacket.List.Count; i++)
        {
            Network.Options.Option option = optionsPacket.List[i];
            if ((option.Type == Network.Options.Option.OptionType.POWER) && (option.Main.ID == entityId))
            {
                state.SetSelectedOption(i);
                if (option.Subs.Count == 0)
                {
                    if ((option.Main.Targets == null) || (option.Main.Targets.Count == 0))
                    {
                        state.SendOption();
                    }
                    else
                    {
                        state.EnterOptionTargetMode();
                    }
                }
                else
                {
                    this.m_choiceParentCardHandPosition = entity.GetZonePosition();
                    this.m_choiceParentCard = entity.GetCard();
                    if (entity.IsSpell())
                    {
                        this.PlayPowerUpSpell(this.m_choiceParentCard);
                    }
                    state.EnterSubOptionMode();
                    base.StartCoroutine(this.WaitThenDisplaySubOptionCards(entity));
                }
                return true;
            }
        }
        PlayErrors.DisplayPlayError(PlayErrors.GetPlayEntityError(entity), entity);
        return false;
    }

    private bool DoNetworkOptionTarget(Entity entity)
    {
        int entityId = entity.GetEntityId();
        GameState state = GameState.Get();
        Network.Options.Option.SubOption selectedNetworkSubOption = state.GetSelectedNetworkSubOption();
        Entity errorSource = state.GetEntity(selectedNetworkSubOption.ID);
        if (!selectedNetworkSubOption.Targets.Contains(entityId))
        {
            Entity target = state.GetEntity(entityId);
            PlayErrors.DisplayPlayError(PlayErrors.GetTargetEntityError(errorSource, target), errorSource);
            return false;
        }
        if (TargetReticleManager.Get() != null)
        {
            TargetReticleManager.Get().DestroyFriendlyTargetArrow(false);
        }
        this.FinishBattlecrySourceCard();
        this.FinishChoiceParentCard();
        if (errorSource.IsHeroPower())
        {
            errorSource.SetTagAndUpdateCard<int>(GAME_TAG.EXHAUSTED, 1);
            this.ForceManaUpdate(errorSource);
        }
        state.SetSelectedOptionTarget(entityId);
        state.SendOption();
        return true;
    }

    public bool DoNetworkResponse(Entity entity)
    {
        if (ThinkEmoteManager.Get() != null)
        {
            ThinkEmoteManager.Get().NotifyOfActivity();
        }
        GameState state = GameState.Get();
        if (state.BlockAccessToOptionsPacket())
        {
            return false;
        }
        if (entity.IsBusy())
        {
            return false;
        }
        GameState.ResponseMode responseMode = state.GetResponseMode();
        bool flag = false;
        switch (responseMode)
        {
            case GameState.ResponseMode.OPTION:
                flag = this.DoNetworkOptions(entity);
                break;

            case GameState.ResponseMode.SUB_OPTION:
                flag = this.DoNetworkSubOptions(entity);
                break;

            case GameState.ResponseMode.OPTION_TARGET:
                flag = this.DoNetworkOptionTarget(entity);
                break;

            case GameState.ResponseMode.CHOICE:
                flag = this.DoNetworkChoice(entity);
                break;
        }
        if (flag)
        {
            entity.GetCard().UpdateActorState();
        }
        return flag;
    }

    private bool DoNetworkSubOptions(Entity entity)
    {
        int entityId = entity.GetEntityId();
        GameState state = GameState.Get();
        Network.Options.Option selectedNetworkOption = state.GetSelectedNetworkOption();
        for (int i = 0; i < selectedNetworkOption.Subs.Count; i++)
        {
            Network.Options.Option.SubOption option2 = selectedNetworkOption.Subs[i];
            if (option2.ID == entityId)
            {
                state.SetSelectedSubOption(i);
                if ((option2.Targets == null) || (option2.Targets.Count == 0))
                {
                    state.SendOption();
                }
                else
                {
                    state.EnterOptionTargetMode();
                }
                return true;
            }
        }
        return false;
    }

    private void DropCanceledHeldCard(Card card)
    {
        this.heldObject = null;
        EnemyActionHandler.Get().NotifyOpponentOfCardDropped();
        this.m_myHandZone.UpdateLayout(-1, true);
        this.m_myPlayZone.SortWithSpotForHeldCard(-1);
    }

    private void DropChoiceParentCard()
    {
        this.m_choiceParentCard = null;
        this.m_choiceParentCardHandPosition = 0;
        EnemyActionHandler.Get().NotifyOpponentOfCardDropped();
    }

    private bool DropHeldCard()
    {
        return this.DropHeldCard(false);
    }

    private bool DropHeldCard(bool wasCancelled)
    {
        PegCursor.Get().SetMode(PegCursor.Mode.STOPDRAG);
        if (this.heldObject == null)
        {
            return false;
        }
        Card component = this.heldObject.GetComponent<Card>();
        component.SetDoNotSort(false);
        iTween.Stop(this.heldObject);
        Entity entity = component.GetEntity();
        component.NotifyLeftPlayfield();
        GameState.Get().GetGameEntity().NotifyOfCardDropped(entity);
        this.m_myPlayZone.UnHighlightBattlefield();
        DragCardSoundEffects effects = component.GetActor().GetComponent<DragCardSoundEffects>();
        if (effects != null)
        {
            effects.Disable();
        }
        UnityEngine.Object.Destroy(this.heldObject.GetComponent<DragRotator>());
        this.heldObject = null;
        ProjectedShadow componentInChildren = component.GetActor().GetComponentInChildren<ProjectedShadow>();
        if (componentInChildren != null)
        {
            componentInChildren.DisableShadow();
        }
        if (wasCancelled)
        {
            this.DropCanceledHeldCard(component);
            return true;
        }
        bool flag = false;
        if ((entity != null) && (entity.GetZone() == TAG_ZONE.HAND))
        {
            bool flag2 = entity.IsMinion();
            bool flag3 = entity.IsWeapon();
            if (flag2 || flag3)
            {
                RaycastHit hit;
                if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.InvisibleHitBox2.LayerBit(), out hit))
                {
                    Zone destinationZone = !flag3 ? ((Zone) this.m_myPlayZone) : ((Zone) this.m_myWeaponZone);
                    if (destinationZone != null)
                    {
                        GameState state = GameState.Get();
                        int position = 0;
                        if (flag2)
                        {
                            position = this.m_myPlayZone.slotMousedOver + 1;
                        }
                        else if (flag3)
                        {
                            position = 1;
                        }
                        state.SetSelectedOptionPosition(position);
                        if (this.DoNetworkResponse(entity))
                        {
                            int zonePosition = entity.GetZonePosition();
                            ZoneMgr.Get().AddLocalZoneChange(component, destinationZone, position);
                            this.ForceManaUpdate(entity);
                            if (flag2 && state.EntityHasTargets(entity))
                            {
                                this.m_battlecrySourceHandPosition = zonePosition;
                                flag = true;
                                bool showArrow = UniversalInputManager.IsTouchDevice == 0;
                                if (TargetReticleManager.Get() != null)
                                {
                                    TargetReticleManager.Get().CreateFriendlyTargetArrow(entity, entity, true, showArrow);
                                }
                                this.m_battlecrySourceCard = component;
                                if (UniversalInputManager.IsTouchDevice != null)
                                {
                                    this.StartBattleCryEffect(entity);
                                }
                            }
                        }
                        else
                        {
                            state.SetSelectedOptionPosition(Network.NoPosition);
                        }
                    }
                }
            }
            else if (entity.IsSpell())
            {
                RaycastHit hit2;
                if (GameState.Get().EntityHasTargets(entity))
                {
                    this.DropCanceledHeldCard(entity.GetCard());
                    return true;
                }
                if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.InvisibleHitBox2.LayerBit(), out hit2))
                {
                    if (!GameState.Get().HasResponse(entity))
                    {
                        PlayErrors.DisplayPlayError(PlayErrors.GetPlayEntityError(entity), entity);
                    }
                    else
                    {
                        ZoneMgr.Get().AddLocalZoneChange(component, TAG_ZONE.PLAY);
                        this.ForceManaUpdate(entity);
                        this.PlayPowerUpSpell(component);
                        this.PlayPlaySpell(component);
                        this.DoNetworkResponse(entity);
                    }
                }
            }
            this.m_myHandZone.UpdateLayout(-1, true);
            this.m_myPlayZone.SortWithSpotForHeldCard(-1);
        }
        if (flag)
        {
            if (EnemyActionHandler.Get() != null)
            {
                EnemyActionHandler.Get().NotifyOpponentOfTargetModeBegin(component);
            }
        }
        else
        {
            EnemyActionHandler.Get().NotifyOpponentOfCardDropped();
        }
        return true;
    }

    public void EnableInput()
    {
        this.m_checkForInput = true;
    }

    private void EndBattleCryEffect()
    {
        foreach (Actor actor in this.m_battleCryEffectActors)
        {
            this.RemoveBattlecryEffectFromActor(actor);
        }
        this.m_battlecrySourceCard.SetBattleCrySource(false);
        FullScreenFXMgr.Get().StopDesaturate(0.4f, iTween.EaseType.easeInOutQuad, null);
    }

    private void FinishBattlecrySourceCard()
    {
        if (this.m_battlecrySourceCard != null)
        {
            this.ClearBattlecrySourceCard();
        }
    }

    private void FinishChoiceParentCard()
    {
        if (this.m_choiceParentCard != null)
        {
            this.DropChoiceParentCard();
        }
    }

    private void ForceManaUpdate(Entity entity)
    {
        Player localPlayer = GameState.Get().GetLocalPlayer();
        localPlayer.NotifyOfSpentMana(entity.GetRealTimeCost());
        localPlayer.UpdateManaCounter();
        ManaCrystalMgr.Get().UpdateSpentMana(entity.GetRealTimeCost());
    }

    public static InputManager Get()
    {
        return s_instance;
    }

    public Card GetBattlecrySourceCard()
    {
        return this.m_battlecrySourceCard;
    }

    public Card GetChoiceParentCard()
    {
        return this.m_choiceParentCard;
    }

    public Card GetMousedOverCard()
    {
        return this.m_mousedOverCard;
    }

    private void GrabCard(GameObject cardToGrab)
    {
        this.heldObject = cardToGrab;
        Card component = this.heldObject.GetComponent<Card>();
        component.SetDoNotSort(true);
        SoundManager.Get().LoadAndPlay("FX_MinionSummon01_DrawFromHand_01", this.heldObject);
        Actor actor = component.GetActor();
        DragCardSoundEffects effects = actor.GetComponent<DragCardSoundEffects>();
        if (effects != null)
        {
            effects.enabled = true;
        }
        else
        {
            effects = actor.gameObject.AddComponent<DragCardSoundEffects>();
        }
        effects.Start();
        this.heldObject.AddComponent<DragRotator>().SetInfo(this.dragRotatorInfo);
        ProjectedShadow componentInChildren = component.GetActor().GetComponentInChildren<ProjectedShadow>();
        if (componentInChildren != null)
        {
            componentInChildren.EnableShadow(0.15f);
        }
        iTween.Stop(this.heldObject);
        float x = 0.7f;
        iTween.ScaleTo(this.heldObject, new Vector3(x, x, x), 0.2f);
        KeywordHelpPanelManager.Get().HideKeywordHelp();
        CardTypeBanner.Hide();
        component.NotifyPickedUp();
        GameState.Get().GetGameEntity().NotifyOfCardGrabbed(component.GetEntity());
        SceneUtils.SetLayer(cardToGrab, GameLayer.Default);
    }

    private void HandleClickOnCard(GameObject upClickedCard)
    {
        if (EmoteHandler.Get() != null)
        {
            if (EmoteHandler.Get().IsMouseOverEmoteOption())
            {
                return;
            }
            EmoteHandler.Get().HideEmotes();
        }
        Card component = upClickedCard.GetComponent<Card>();
        Entity entity = component.GetEntity();
        if (((UniversalInputManager.IsTouchDevice != null) && entity.IsHero()) && (entity.IsControlledByLocalPlayer() && !GameState.Get().IsInTargetMode()))
        {
            if (EmoteHandler.Get() != null)
            {
                EmoteHandler.Get().ShowEmotes();
            }
        }
        else if ((this.m_choiceParentCard != null) && (this.m_choiceParentCard.GetEntity().GetEntityId() == entity.GetEntityId()))
        {
            this.CancelOption();
        }
        else
        {
            GameState.ResponseMode responseMode = GameState.Get().GetResponseMode();
            if (entity.GetZone() == TAG_ZONE.HAND)
            {
                if (GameState.Get().IsMulliganPhase())
                {
                    MulliganManager.Get().ToggleHoldState(component);
                }
                else if ((UniversalInputManager.IsTouchDevice == null) && ((this.m_currentlyDisplayedSubCards.Count == 0) && (this.GetBattlecrySourceCard() == null)))
                {
                    this.GrabCard(upClickedCard);
                }
            }
            else
            {
                switch (responseMode)
                {
                    case GameState.ResponseMode.SUB_OPTION:
                        this.HandleClickOnSubOption(entity);
                        return;

                    case GameState.ResponseMode.CHOICE:
                        this.HandleClickOnChoice(entity);
                        return;
                }
                if (entity.GetZone() == TAG_ZONE.PLAY)
                {
                    this.HandleClickOnCardInBattlefield(entity);
                }
            }
        }
    }

    private void HandleClickOnCardInBattlefield(Entity clickedEntity)
    {
        PegCursor.Get().SetMode(PegCursor.Mode.STOPDRAG);
        GameState state = GameState.Get();
        Card mousedOverCard = clickedEntity.GetCard();
        if ((((UniversalInputManager.IsTouchDevice == null) || !clickedEntity.IsHeroPower()) || (this.m_mousedOverTimer <= 0.4f)) && state.GetGameEntity().NotifyOfBattlefieldCardClicked(clickedEntity, state.IsInTargetMode()))
        {
            if (state.IsInTargetMode())
            {
                this.DisableSkullIfNeeded(mousedOverCard);
                if (state.GetSelectedNetworkSubOption().ID == clickedEntity.GetEntityId())
                {
                    this.CancelOption();
                }
                else if (this.DoNetworkResponse(clickedEntity) && (this.heldObject != null))
                {
                    this.heldObject.GetComponent<Card>().SetDoNotSort(false);
                    this.heldObject = null;
                }
            }
            else if (((UniversalInputManager.IsTouchDevice == null) || !Input.GetMouseButtonUp(0)) || !GameState.Get().EntityHasTargets(clickedEntity))
            {
                if (clickedEntity.IsWeapon() && clickedEntity.IsControlledByLocalPlayer())
                {
                    this.HandleClickOnCardInBattlefield(state.GetLocalPlayer().GetHero());
                }
                else if (this.DoNetworkResponse(clickedEntity))
                {
                    if (!state.IsInTargetMode())
                    {
                        if (clickedEntity.IsHeroPower())
                        {
                            clickedEntity.SetTagAndUpdateCard<int>(GAME_TAG.EXHAUSTED, 1);
                            this.ForceManaUpdate(clickedEntity);
                        }
                    }
                    else
                    {
                        EnemyActionHandler.Get().NotifyOpponentOfTargetModeBegin(mousedOverCard);
                        if (TargetReticleManager.Get() != null)
                        {
                            TargetReticleManager.Get().CreateFriendlyTargetArrow(clickedEntity, clickedEntity, false, true);
                        }
                        if (clickedEntity.IsHeroPower())
                        {
                            this.PlayPlaySpell(mousedOverCard);
                        }
                        else if (clickedEntity.IsCharacter())
                        {
                            Spell attackSpell = mousedOverCard.GetAttackSpell();
                            if (attackSpell != null)
                            {
                                attackSpell.Deactivate();
                                attackSpell.Activate();
                            }
                            GameState.Get().ShowEnemyTauntMinions();
                            if (!mousedOverCard.IsAttacking())
                            {
                                Spell actorAttackSpellForInput = mousedOverCard.GetActorAttackSpellForInput();
                                if (actorAttackSpellForInput != null)
                                {
                                    actorAttackSpellForInput.ActivateState(SpellStateType.BIRTH);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private void HandleClickOnChoice(Entity entity)
    {
        if (this.DoNetworkResponse(entity))
        {
            if (GameState.Get().GetResponseMode() != GameState.ResponseMode.CHOICE)
            {
                this.HideChoiceCards(entity);
            }
        }
        else
        {
            PlayErrors.DisplayPlayError(PlayErrors.GetPlayEntityError(entity), entity);
        }
    }

    private void HandleClickOnSubOption(Entity entity)
    {
        if (GameState.Get().HasResponse(entity))
        {
            bool flag = GameState.Get().SubEntityHasTargets(entity);
            if (flag)
            {
                EnemyActionHandler.Get().NotifyOpponentOfTargetModeBegin(this.m_choiceParentCard);
                Entity hero = entity.GetHero();
                TargetReticleManager.Get().CreateFriendlyTargetArrow(hero, this.m_choiceParentCard.GetEntity(), true, true);
            }
            Card card = entity.GetCard();
            this.PlayPowerUpSpell(card);
            this.PlayPlaySpell(card);
            this.DoNetworkResponse(entity);
            this.HideSubOptionCards(entity.GetEntityId());
            if (!flag)
            {
                this.FinishChoiceParentCard();
            }
        }
        else
        {
            PlayErrors.DisplayPlayError(PlayErrors.GetPlayEntityError(entity), entity);
        }
    }

    private bool HandleGameHotkeys()
    {
        if ((GameState.Get() != null) && GameState.Get().IsMulliganPhase())
        {
            return false;
        }
        return (Input.GetKeyUp(KeyCode.Escape) && this.CancelOption());
    }

    public bool HandleKeyboardInput()
    {
        if (this.HandleUniversalHotkeys())
        {
            return true;
        }
        if ((GameState.Get() != null) && GameState.Get().IsMulliganPhase())
        {
            return this.HandleMulliganHotkeys();
        }
        return this.HandleGameHotkeys();
    }

    private void HandleLeftMouseDown()
    {
        RaycastHit hit;
        if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.CardRaycast.LayerBit(), out hit))
        {
            GameObject gameObject = hit.collider.gameObject;
            if (gameObject.GetComponent<EndTurnButtonReminder>() == null)
            {
                CardStandIn @in = SceneUtils.FindComponentInParents<CardStandIn>(hit.transform);
                if (((@in != null) && (GameState.Get() != null)) && !GameState.Get().IsMulliganPhase())
                {
                    if (@in.linkedCard != this.m_cancelingBattlecrySourceCard)
                    {
                        this.m_lastObjectMousedDown = @in.gameObject;
                        this.m_lastMouseDownPosition = Input.mousePosition;
                        this.m_leftMouseButtonIsDown = true;
                        if (UniversalInputManager.IsTouchDevice != null)
                        {
                            this.m_myHandZone.TouchReceived();
                        }
                    }
                }
                else if (gameObject.GetComponent<EndTurnButton>() != null)
                {
                    EndTurnButton.Get().PlayPushDownAnimation();
                    this.m_lastObjectMousedDown = hit.collider.gameObject;
                }
                else if (gameObject.GetComponent<GameOpenPack>() != null)
                {
                    this.m_lastObjectMousedDown = hit.collider.gameObject;
                }
                else
                {
                    Actor actor = SceneUtils.FindComponentInParents<Actor>(hit.transform);
                    if (actor != null)
                    {
                        Card card = actor.GetCard();
                        if (((UniversalInputManager.IsTouchDevice != null) && (this.m_battlecrySourceCard != null)) && (card == this.m_battlecrySourceCard))
                        {
                            this.m_dragging = true;
                            TargetReticleManager.Get().ShowArrow(true);
                        }
                        else if (card != this.m_cancelingBattlecrySourceCard)
                        {
                            if (card != null)
                            {
                                this.m_lastObjectMousedDown = card.gameObject;
                            }
                            else if (actor.GetHistoryCard() != null)
                            {
                                this.m_lastObjectMousedDown = actor.transform.parent.gameObject;
                            }
                            else
                            {
                                UnityEngine.Debug.LogWarning("You clicked on something that is not being handled by InputManager.  Alert The Brode!");
                            }
                            this.m_lastMouseDownPosition = Input.mousePosition;
                            this.m_leftMouseButtonIsDown = true;
                        }
                    }
                }
            }
        }
    }

    private void HandleLeftMouseUp()
    {
        PegCursor.Get().SetMode(PegCursor.Mode.UP);
        bool dragging = this.m_dragging;
        this.m_dragging = false;
        this.m_leftMouseButtonIsDown = false;
        GameObject lastObjectMousedDown = this.m_lastObjectMousedDown;
        this.m_lastObjectMousedDown = null;
        if ((this.heldObject != null) && ((GameState.Get().GetResponseMode() == GameState.ResponseMode.OPTION) || (GameState.Get().GetResponseMode() == GameState.ResponseMode.NONE)))
        {
            this.DropHeldCard();
        }
        else
        {
            RaycastHit hit;
            bool flag2 = (UniversalInputManager.IsTouchDevice != null) && GameState.Get().IsInTargetMode();
            if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.CardRaycast.LayerBit(), out hit))
            {
                GameObject gameObject = hit.collider.gameObject;
                if (gameObject.GetComponent<EndTurnButtonReminder>() != null)
                {
                    return;
                }
                if ((gameObject.GetComponent<EndTurnButton>() != null) && (gameObject == lastObjectMousedDown))
                {
                    EndTurnButton.Get().PlayButtonUpAnimation();
                    this.DoEndTurnButton();
                }
                else if ((gameObject.GetComponent<GameOpenPack>() != null) && (gameObject == lastObjectMousedDown))
                {
                    gameObject.GetComponent<GameOpenPack>().HandleClick();
                }
                else
                {
                    Actor actor = SceneUtils.FindComponentInParents<Actor>(hit.transform);
                    if (actor != null)
                    {
                        Card card = actor.GetCard();
                        if (card != null)
                        {
                            if (((card.gameObject == lastObjectMousedDown) || dragging) && (card != this.m_cancelingBattlecrySourceCard))
                            {
                                this.HandleClickOnCard(actor.GetCard().gameObject);
                            }
                        }
                        else if (actor.GetHistoryCard() != null)
                        {
                            HistoryManager.Get().HandleClickOnBigCard();
                        }
                    }
                    CardStandIn @in = SceneUtils.FindComponentInParents<CardStandIn>(hit.transform);
                    if (((@in != null) && (GameState.Get() != null)) && (!GameState.Get().IsMulliganPhase() && (@in.linkedCard != this.m_cancelingBattlecrySourceCard)))
                    {
                        @in.Hide();
                        this.HandleClickOnCard(@in.linkedCard.gameObject);
                    }
                }
            }
            if (flag2)
            {
                this.CancelOption();
            }
            this.HandleMemberClick();
        }
    }

    public void HandleMemberClick()
    {
        if (this.m_mousedOverObject == null)
        {
            RaycastHit hit;
            if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.PlayAreaCollision.LayerBit(), out hit))
            {
                RaycastHit hit2;
                if (((GameState.Get() != null) && !GameState.Get().IsMulliganPhase()) && !UniversalInputManager.Get().GetInputHitInfo(GameLayer.CardRaycast.LayerBit(), out hit2))
                {
                    GameObject mouseClickDustEffectPrefab = Board.Get().GetMouseClickDustEffectPrefab();
                    if (mouseClickDustEffectPrefab != null)
                    {
                        GameObject parentObject = (GameObject) UnityEngine.Object.Instantiate(mouseClickDustEffectPrefab);
                        parentObject.transform.position = hit.point;
                        ParticleSystem[] componentsInChildren = parentObject.GetComponentsInChildren<ParticleSystem>();
                        if (componentsInChildren != null)
                        {
                            Vector3 euler = new Vector3(Input.GetAxis("Mouse Y") * 40f, Input.GetAxis("Mouse X") * 40f, 0f);
                            foreach (ParticleSystem system in componentsInChildren)
                            {
                                if (system.name == "Rocks")
                                {
                                    system.transform.localRotation = Quaternion.Euler(euler);
                                }
                                system.Play();
                            }
                            switch (UnityEngine.Random.Range(1, 5))
                            {
                                case 1:
                                    SoundManager.Get().LoadAndPlay("board_common_dirt_poke_1", parentObject);
                                    return;

                                case 2:
                                    SoundManager.Get().LoadAndPlay("board_common_dirt_poke_2", parentObject);
                                    return;

                                case 3:
                                    SoundManager.Get().LoadAndPlay("board_common_dirt_poke_3", parentObject);
                                    return;

                                case 4:
                                    SoundManager.Get().LoadAndPlay("board_common_dirt_poke_4", parentObject);
                                    return;

                                case 5:
                                    SoundManager.Get().LoadAndPlay("board_common_dirt_poke_5", parentObject);
                                    return;
                            }
                        }
                    }
                }
            }
            else if (Gameplay.Get() != null)
            {
                SoundManager.Get().LoadAndPlay("UI_MouseClick_01");
            }
        }
    }

    private void HandleMouseMove(LayerMask layerMask)
    {
        if (GameState.Get().IsInTargetMode())
        {
            this.HandleUpdateWhileNotHoldingCard(layerMask);
        }
    }

    private void HandleMouseOff()
    {
        if (this.m_mousedOverCard != null)
        {
            this.HandleMouseOffCard();
        }
        if (this.m_mousedOverObject != null)
        {
            this.HandleMouseOffLastObject();
        }
    }

    private void HandleMouseOffCard()
    {
        PegCursor.Get().SetMode(PegCursor.Mode.UP);
        Card mousedOverCard = this.m_mousedOverCard;
        this.m_mousedOverCard = null;
        mousedOverCard.HideTooltip();
        mousedOverCard.NotifyMousedOut();
        this.ShowBullseyeIfNeeded();
        this.DisableSkullIfNeeded(mousedOverCard);
    }

    private void HandleMouseOffLastObject()
    {
        if (this.m_mousedOverObject.GetComponent<EndTurnButton>() != null)
        {
            this.m_mousedOverObject.GetComponent<EndTurnButton>().HandleMouseOut();
            this.m_lastObjectMousedDown = null;
        }
        else if (this.m_mousedOverObject.GetComponent<EndTurnButtonReminder>() != null)
        {
            this.m_lastObjectMousedDown = null;
        }
        else if (this.m_mousedOverObject.GetComponent<TooltipZone>() != null)
        {
            this.m_mousedOverObject.GetComponent<TooltipZone>().HideTooltip();
            this.m_lastObjectMousedDown = null;
        }
        else if (this.m_mousedOverObject.GetComponent<HistoryManager>() != null)
        {
            HistoryManager.Get().NotifyOfMouseOff();
        }
        else if (this.m_mousedOverObject.GetComponent<GameOpenPack>() != null)
        {
            this.m_mousedOverObject.GetComponent<GameOpenPack>().NotifyOfMouseOff();
            this.m_lastObjectMousedDown = null;
        }
        this.m_mousedOverObject = null;
    }

    private void HandleMouseOverCard(Card card)
    {
        this.m_mousedOverCard = card;
        if (((GameState.Get().IsMainPhase() && (this.heldObject == null)) && ((this.m_choiceParentCard == null) && (TargetReticleManager.Get() != null))) && !TargetReticleManager.Get().IsActive())
        {
            this.ShouldShowTooltip();
        }
        card.NotifyMousedOver();
        if (GameState.Get().IsMulliganPhase() && card.GetEntity().IsControlledByLocalPlayer())
        {
            KeywordHelpPanelManager.Get().UpdateKeywordHelpForHistoryCard(card.GetEntity(), card.GetActor());
        }
        this.ShowBullseyeIfNeeded();
        this.ShowSkullIfNeeded();
    }

    private void HandleMouseOverFriendlyHand(Vector3 hitPoint)
    {
        float x = this.m_handScrollBox.bounds.size.x;
        if (!this.m_myHandZone.IsHandScrunched())
        {
            x = this.m_myHandZone.GetDefaultCardSpacing() * this.m_myHandZone.GetCards().Count;
        }
        float num2 = x / ((float) this.m_myHandZone.GetCards().Count);
        float num3 = this.m_handScrollBox.transform.position.x - (x / 2f);
        int num4 = (int) Mathf.Ceil((hitPoint.x - num3) / num2);
        if ((num4 - 1) != this.m_myHandZone.GetLastMousedOverCard())
        {
            this.m_myHandZone.UpdateLayout(num4 - 1);
        }
    }

    private void HandleMouseOverObjectWhileNotHoldingCard(RaycastHit hitInfo)
    {
        GameObject gameObject = hitInfo.collider.gameObject;
        if (this.m_mousedOverCard != null)
        {
            this.HandleMouseOffCard();
        }
        if ((UniversalInputManager.IsTouchDevice != null) && !Input.GetMouseButton(0))
        {
            if (this.m_mousedOverObject != null)
            {
                this.HandleMouseOffLastObject();
            }
        }
        else if (gameObject.GetComponent<HistoryManager>() != null)
        {
            this.m_mousedOverObject = gameObject;
            HistoryManager.Get().NotifyOfInput(hitInfo.point.z);
        }
        else if (this.m_mousedOverObject != gameObject)
        {
            if (this.m_mousedOverObject != null)
            {
                this.HandleMouseOffLastObject();
            }
            if (EndTurnButton.Get() != null)
            {
                if (gameObject.GetComponent<EndTurnButton>() != null)
                {
                    this.m_mousedOverObject = gameObject;
                    EndTurnButton.Get().HandleMouseOver();
                }
                else if ((gameObject.GetComponent<EndTurnButtonReminder>() != null) && gameObject.GetComponent<EndTurnButtonReminder>().ShowLocalPlayerTurnReminder())
                {
                    this.m_mousedOverObject = gameObject;
                }
            }
            TooltipZone component = gameObject.GetComponent<TooltipZone>();
            if (component != null)
            {
                this.m_mousedOverObject = gameObject;
                this.ShowTooltipZone(gameObject, component);
            }
            GameOpenPack pack = gameObject.GetComponent<GameOpenPack>();
            if (pack != null)
            {
                this.m_mousedOverObject = gameObject;
                pack.NotifyOfMouseOver();
            }
            if ((this.GetBattlecrySourceCard() == null) && (UniversalInputManager.Get().InputHitAnyObject(GameLayer.InvisibleHitBox1.LayerBit()) && (this.m_choiceParentCard != null)))
            {
                this.CancelChoiceCardOptions();
            }
        }
    }

    private bool HandleMulliganHotkeys()
    {
        if ((MulliganManager.Get() != null) && (ApplicationMgr.IsInternal() && Input.GetKeyUp(KeyCode.Escape)))
        {
            this.DoEndTurnButton();
            TurnStartManager.Get().BeginListeningForTurnEvents();
            MulliganManager.Get().EndMulligan();
            return true;
        }
        return false;
    }

    private void HandleRightClick()
    {
        if (!this.CancelOption() && ((EmoteHandler.Get() != null) && EmoteHandler.Get().AreEmotesActive()))
        {
            EmoteHandler.Get().HideEmotes();
        }
    }

    private void HandleRightClickOnCard(Card card)
    {
        if ((GameState.Get().IsInTargetMode() || GameState.Get().IsInSubOptionMode()) || (this.heldObject != null))
        {
            this.HandleRightClick();
        }
        else if ((card.GetEntity().IsHero() && card.GetEntity().IsControlledByLocalPlayer()) && (EmoteHandler.Get() != null))
        {
            if (EmoteHandler.Get().AreEmotesActive())
            {
                EmoteHandler.Get().HideEmotes();
            }
            else
            {
                EmoteHandler.Get().ShowEmotes();
            }
        }
    }

    private void HandleRightMouseDown()
    {
        RaycastHit hit;
        if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.CardRaycast.LayerBit(), out hit))
        {
            GameObject gameObject = hit.collider.gameObject;
            if ((gameObject.GetComponent<EndTurnButtonReminder>() == null) && (gameObject.GetComponent<EndTurnButton>() == null))
            {
                Actor actor = SceneUtils.FindComponentInParents<Actor>(hit.transform);
                if (actor != null)
                {
                    if (actor.GetCard() != null)
                    {
                        this.m_lastObjectRightMousedDown = actor.GetCard().gameObject;
                    }
                    else if (actor.GetHistoryCard() != null)
                    {
                        this.m_lastObjectRightMousedDown = actor.transform.parent.gameObject;
                    }
                    else
                    {
                        UnityEngine.Debug.LogWarning("You clicked on something that is not being handled by InputManager.  Alert The Brode!");
                    }
                }
            }
        }
    }

    private void HandleRightMouseUp()
    {
        RaycastHit hit;
        PegCursor.Get().SetMode(PegCursor.Mode.UP);
        GameObject lastObjectRightMousedDown = this.m_lastObjectRightMousedDown;
        this.m_lastObjectRightMousedDown = null;
        this.m_lastObjectMousedDown = null;
        this.m_leftMouseButtonIsDown = false;
        this.m_dragging = false;
        if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.CardRaycast.LayerBit(), out hit))
        {
            Actor actor = SceneUtils.FindComponentInParents<Actor>(hit.transform);
            if ((actor == null) || (actor.GetCard() == null))
            {
                this.HandleRightClick();
            }
            else if (actor.GetCard().gameObject == lastObjectRightMousedDown)
            {
                this.HandleRightClickOnCard(actor.GetCard());
            }
            else
            {
                this.HandleRightClick();
            }
        }
        else
        {
            this.HandleRightClick();
        }
    }

    private bool HandleUniversalHotkeys()
    {
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            return true;
        }
        if (Input.GetKeyUp(KeyCode.S) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
        {
            Options.Get().SetBool(Option.SOUND, !Options.Get().GetBool(Option.SOUND));
            return true;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            GameState.Get().GetGameEntity().NotifyOfDebugCommand(1);
            return true;
        }
        return false;
    }

    private void HandleUpdateWhileHoldingCard(bool hitBattlefield)
    {
        PegCursor.Get().SetMode(PegCursor.Mode.DRAG);
        Card component = this.heldObject.GetComponent<Card>();
        if (((UniversalInputManager.IsTouchDevice != null) && (this.heldObject != null)) && ((Input.mousePosition.y - this.m_lastMouseDownPosition.y) < 80f))
        {
            this.ReturnHeldCardToHand();
        }
        else
        {
            Entity entity = component.GetEntity();
            if (((hitBattlefield && (TargetReticleManager.Get() != null)) && (!TargetReticleManager.Get().IsActive() && GameState.Get().EntityHasTargets(entity))) && (entity.GetCardType() != TAG_CARDTYPE.MINION))
            {
                if (!this.DoNetworkResponse(entity))
                {
                    this.PositionHeldCard();
                }
                else
                {
                    DragCardSoundEffects effects = component.GetActor().GetComponent<DragCardSoundEffects>();
                    if (effects != null)
                    {
                        effects.Disable();
                    }
                    EnemyActionHandler.Get().NotifyOpponentOfCardPickedUp(component);
                    EnemyActionHandler.Get().NotifyOpponentOfTargetModeBegin(component);
                    Entity hero = entity.GetHero();
                    TargetReticleManager.Get().CreateFriendlyTargetArrow(hero, entity, true, true);
                    this.PlayPowerUpSpell(component);
                    this.PlayPlaySpell(component);
                }
            }
            else
            {
                if (hitBattlefield && this.cardWasInsideHandLastFrame)
                {
                    EnemyActionHandler.Get().NotifyOpponentOfCardPickedUp(component);
                    this.cardWasInsideHandLastFrame = false;
                }
                else if (!hitBattlefield)
                {
                    this.cardWasInsideHandLastFrame = true;
                }
                this.PositionHeldCard();
                if (GameState.Get().GetResponseMode() == GameState.ResponseMode.SUB_OPTION)
                {
                    GameState.Get().CancelCurrentOptionMode();
                    this.CancelChoiceCardOptions();
                }
            }
        }
    }

    private void HandleUpdateWhileLeftMouseButtonIsDown()
    {
        if ((UniversalInputManager.IsTouchDevice != null) && (this.heldObject == null))
        {
            this.m_myHandZone.HandleInput();
        }
        if (!this.m_dragging && (this.m_lastObjectMousedDown != null))
        {
            if (this.m_lastObjectMousedDown.GetComponent<HistoryCard>() != null)
            {
                this.m_lastObjectMousedDown = null;
                this.m_leftMouseButtonIsDown = false;
            }
            else
            {
                float num = Input.mousePosition.y - this.m_lastMouseDownPosition.y;
                float num2 = Input.mousePosition.x - this.m_lastMouseDownPosition.x;
                if (((num2 <= -20f) || (num2 >= 20f)) || ((num <= -20f) || (num >= 20f)))
                {
                    bool flag = (UniversalInputManager.IsTouchDevice == null) || (num > 80f);
                    CardStandIn component = this.m_lastObjectMousedDown.GetComponent<CardStandIn>();
                    if (((component != null) && (GameState.Get() != null)) && !GameState.Get().IsMulliganPhase())
                    {
                        if (UniversalInputManager.IsTouchDevice != null)
                        {
                            if (!flag)
                            {
                                return;
                            }
                            component = this.m_myHandZone.CurrentStandIn;
                            if (component == null)
                            {
                                return;
                            }
                            Entity entity = component.linkedCard.GetEntity();
                            if (!GameState.Get().HasResponse(entity))
                            {
                                return;
                            }
                        }
                        if ((this.m_currentlyDisplayedSubCards.Count == 0) && (this.GetBattlecrySourceCard() == null))
                        {
                            this.m_dragging = true;
                            component.Hide();
                            this.GrabCard(component.linkedCard.gameObject);
                        }
                    }
                    else
                    {
                        Entity entity2 = this.m_lastObjectMousedDown.GetComponent<Card>().GetEntity();
                        if (!GameState.Get().IsMulliganPhase() && GameState.Get().GetPlayer(entity2.GetControllerId()).IsLocal())
                        {
                            if (entity2.GetZone() == TAG_ZONE.HAND)
                            {
                                if ((flag && ((UniversalInputManager.IsTouchDevice == null) || GameState.Get().HasResponse(entity2))) && ((this.m_currentlyDisplayedSubCards.Count == 0) && (this.GetBattlecrySourceCard() == null)))
                                {
                                    this.m_dragging = true;
                                    this.GrabCard(this.m_lastObjectMousedDown);
                                }
                            }
                            else if ((entity2.GetZone() == TAG_ZONE.PLAY) && GameState.Get().EntityHasTargets(entity2))
                            {
                                this.m_dragging = true;
                                this.HandleClickOnCardInBattlefield(entity2);
                            }
                            else if ((UniversalInputManager.IsTouchDevice != null) && entity2.IsHero())
                            {
                                PlayErrors.DisplayPlayError(PlayErrors.GetPlayEntityError(entity2), entity2);
                            }
                        }
                    }
                }
            }
        }
    }

    private void HandleUpdateWhileNotHoldingCard(LayerMask layerMask)
    {
        RaycastHit hit;
        this.m_myHandZone.HandleInput();
        bool flag = (UniversalInputManager.IsTouchDevice != null) && !Input.GetMouseButton(0);
        bool inputHitInfo = UniversalInputManager.Get().GetInputHitInfo(layerMask, out hit);
        if (!flag && inputHitInfo)
        {
            CardStandIn @in = SceneUtils.FindComponentInParents<CardStandIn>(hit.transform);
            Actor actor = SceneUtils.FindComponentInParents<Actor>(hit.transform);
            if ((actor == null) && (@in == null))
            {
                this.HandleMouseOverObjectWhileNotHoldingCard(hit);
            }
            else
            {
                if (this.m_mousedOverObject != null)
                {
                    this.HandleMouseOffLastObject();
                }
                Card linkedCard = null;
                if (actor != null)
                {
                    linkedCard = actor.GetCard();
                }
                if (linkedCard == null)
                {
                    if (@in == null)
                    {
                        return;
                    }
                    if ((GameState.Get() == null) || GameState.Get().IsMulliganPhase())
                    {
                        return;
                    }
                    linkedCard = @in.linkedCard;
                }
                if (this.m_cancelingBattlecrySourceCard != linkedCard)
                {
                    if ((linkedCard != this.m_mousedOverCard) && ((linkedCard.GetZone() != this.m_myHandZone) || GameState.Get().IsMulliganPhase()))
                    {
                        if (this.m_mousedOverCard != null)
                        {
                            this.HandleMouseOffCard();
                        }
                        this.HandleMouseOverCard(linkedCard);
                    }
                    PegCursor.Get().SetMode(PegCursor.Mode.OVER);
                }
            }
        }
        else
        {
            if (this.m_mousedOverCard != null)
            {
                this.HandleMouseOffCard();
            }
            this.HandleMouseOff();
        }
    }

    private void HideChoiceCards(Entity chosenEntity)
    {
        for (int i = 0; i < this.m_currentlyDisplayedSubCards.Count; i++)
        {
            Entity entity = this.m_currentlyDisplayedSubCards[i];
            if (entity != chosenEntity)
            {
                entity.GetCard().HideCard();
            }
        }
        this.m_currentlyDisplayedSubCards.Clear();
    }

    private void HideSubOptionCards()
    {
        this.HideSubOptionCards(-1);
    }

    private void HideSubOptionCards(int alreadyHiddenEntityID)
    {
        for (int i = 0; i < this.m_currentlyDisplayedSubCards.Count; i++)
        {
            Entity entity = this.m_currentlyDisplayedSubCards[i];
            if (entity.GetEntityId() != alreadyHiddenEntityID)
            {
                entity.GetCard().HideCard();
            }
        }
        this.m_currentlyDisplayedSubCards.Clear();
    }

    [DebuggerHidden]
    private IEnumerator LoadThenDisplayChoiceCards()
    {
        return new <LoadThenDisplayChoiceCards>c__Iterator41 { <>f__this = this };
    }

    public bool MouseIsMoving()
    {
        return this.MouseIsMoving(0f);
    }

    public bool MouseIsMoving(float tolerance)
    {
        if ((Mathf.Abs(Input.GetAxis("Mouse X")) <= tolerance) && (Mathf.Abs(Input.GetAxis("Mouse Y")) <= tolerance))
        {
            return false;
        }
        return true;
    }

    public void NotifyMulliganEnded()
    {
        if (this.m_mousedOverCard != null)
        {
            this.ShouldShowTooltip();
        }
    }

    private void OnChoiceReceived(object userData)
    {
        if (GameState.Get().GetChoicePacket().ChoiceType == 2)
        {
            base.StartCoroutine(this.LoadThenDisplayChoiceCards());
        }
    }

    private void OnTurnTimerUpdate(int turn, float secondsRemaining, float endTimestamp, object userData)
    {
        if (secondsRemaining <= float.Epsilon)
        {
            this.CancelOption();
        }
    }

    private bool PlayPlaySpell(Card card)
    {
        if (card == null)
        {
            return false;
        }
        Spell playSpell = card.GetPlaySpell();
        if (playSpell == null)
        {
            return false;
        }
        playSpell.ActivateState(SpellStateType.BIRTH);
        return true;
    }

    private bool PlayPowerUpSpell(Card card)
    {
        if (card == null)
        {
            return false;
        }
        Spell actorSpell = card.GetActorSpell(SpellType.POWER_UP);
        if (actorSpell == null)
        {
            return false;
        }
        actorSpell.ActivateState(SpellStateType.BIRTH);
        return true;
    }

    private void PositionHeldCard()
    {
        RaycastHit hit;
        RaycastHit hit2;
        Card component = this.heldObject.GetComponent<Card>();
        Entity entity = component.GetEntity();
        if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.InvisibleHitBox2.LayerBit(), out hit))
        {
            if (!this.m_myPlayZone.visuallyActivated)
            {
                if (!GameState.Get().HasResponse(entity))
                {
                    this.m_leftMouseButtonIsDown = false;
                    this.m_lastObjectMousedDown = null;
                    this.m_dragging = false;
                    this.DropHeldCard();
                    return;
                }
                component.NotifyOverPlayfield();
                this.m_myPlayZone.HighlightBattlefield();
            }
            if (entity.IsMinion())
            {
                float num = this.m_myPlayZone.transform.position.x - (((this.m_myPlayZone.GetCards().Count + 1) * this.m_myPlayZone.m_slotWidth) / 2f);
                int slot = (int) Mathf.Ceil(((hit.point.x - num) / this.m_myPlayZone.m_slotWidth) - (this.m_myPlayZone.m_slotWidth / 2f));
                int count = this.m_myPlayZone.GetCards().Count;
                if ((slot < 0) || (slot > count))
                {
                    if (component.transform.position.x < this.m_myPlayZone.transform.position.x)
                    {
                        slot = 0;
                    }
                    else
                    {
                        slot = count;
                    }
                }
                if (slot != this.m_myPlayZone.slotMousedOver)
                {
                    this.m_myPlayZone.SortWithSpotForHeldCard(slot);
                }
            }
        }
        else if (this.m_myPlayZone.visuallyActivated)
        {
            component.NotifyLeftPlayfield();
            this.m_myPlayZone.UnHighlightBattlefield();
            this.m_myPlayZone.SortWithSpotForHeldCard(-1);
        }
        if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.DragPlane.LayerBit(), out hit2))
        {
            this.heldObject.transform.position = hit2.point;
        }
    }

    private void RemoveBattlecryEffectFromActor(Actor actor)
    {
        SceneUtils.SetLayer(actor.gameObject, GameLayer.Default);
        SceneUtils.SetLayer(actor.GetMeshRenderer().gameObject, GameLayer.CardRaycast);
        object[] args = new object[] { "y", -1f, "time", 0.4f, "easeType", iTween.EaseType.easeOutQuad, "name", "position" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(actor.gameObject, "position");
        iTween.MoveBy(actor.gameObject, hashtable);
    }

    public void ResetBattlecrySourceCard()
    {
        if (this.m_battlecrySourceCard != null)
        {
            this.m_cancelingBattlecrySourceCard = this.m_battlecrySourceCard;
            ZoneMgr.ChangeCompleteCallback callback = delegate (object userData) {
                this.m_cancelingBattlecrySourceCard = null;
            };
            ZoneMgr.Get().AddLocalZoneChange(this.m_battlecrySourceCard, this.m_myHandZone, this.m_battlecrySourceHandPosition, callback, null);
            this.ReverseManaUpdate(this.m_battlecrySourceCard.GetEntity());
            Spell actorSpell = this.m_battlecrySourceCard.GetActorSpell(SpellType.BATTLECRY);
            if (actorSpell != null)
            {
                actorSpell.ActivateState(SpellStateType.CANCEL);
            }
            this.ClearBattlecrySourceCard();
        }
    }

    public void ResetChoiceParentCard()
    {
        if (this.m_choiceParentCard != null)
        {
            Spell playSpell = this.m_choiceParentCard.GetPlaySpell();
            if (playSpell != null)
            {
                SpellStateType activeState = playSpell.GetActiveState();
                if ((activeState != SpellStateType.NONE) && (activeState != SpellStateType.CANCEL))
                {
                    playSpell.ActivateState(SpellStateType.CANCEL);
                }
            }
            Spell actorSpell = this.m_choiceParentCard.GetActorSpell(SpellType.POWER_UP);
            if ((actorSpell != null) && (actorSpell.GetActiveState() != SpellStateType.CANCEL))
            {
                actorSpell.ActivateState(SpellStateType.CANCEL);
            }
            if (!this.m_choiceParentCard.GetEntity().IsHeroPower())
            {
                ZoneMgr.Get().AddLocalZoneChange(this.m_choiceParentCard, this.m_myHandZone, this.m_choiceParentCardHandPosition);
            }
            this.ReverseManaUpdate(this.m_choiceParentCard.GetEntity());
            this.DropChoiceParentCard();
        }
    }

    private void ReturnHeldCardToHand()
    {
        if (this.heldObject != null)
        {
            Card component = this.heldObject.GetComponent<Card>();
            component.SetDoNotSort(false);
            iTween.Stop(this.heldObject);
            Entity entity = component.GetEntity();
            component.NotifyLeftPlayfield();
            GameState.Get().GetGameEntity().NotifyOfCardDropped(entity);
            this.m_myPlayZone.UnHighlightBattlefield();
            DragCardSoundEffects effects = component.GetActor().GetComponent<DragCardSoundEffects>();
            if (effects != null)
            {
                effects.Disable();
            }
            UnityEngine.Object.Destroy(this.heldObject.GetComponent<DragRotator>());
            ProjectedShadow componentInChildren = component.GetActor().GetComponentInChildren<ProjectedShadow>();
            if (componentInChildren != null)
            {
                componentInChildren.DisableShadow();
            }
            EnemyActionHandler.Get().NotifyOpponentOfCardDropped();
            this.m_myHandZone.UpdateLayout(this.m_myHandZone.GetLastMousedOverCard(), true);
            this.m_dragging = false;
            this.heldObject = null;
        }
    }

    public void ReverseManaUpdate(Entity entity)
    {
        Player localPlayer = GameState.Get().GetLocalPlayer();
        localPlayer.NotifyOfSpentMana(-entity.GetRealTimeCost());
        localPlayer.UpdateManaCounter();
        ManaCrystalMgr.Get().UpdateSpentMana(-entity.GetRealTimeCost());
    }

    public void SetMousedOverCard(Card card)
    {
        if (this.m_mousedOverCard != card)
        {
            if ((this.m_mousedOverCard != null) && !(this.m_mousedOverCard.GetZone() is ZoneHand))
            {
                this.HandleMouseOffCard();
            }
            this.m_mousedOverCard = card;
        }
    }

    public void ShouldShowTooltip()
    {
        this.m_mousedOverTimer = 0f;
        this.m_mousedOverCard.ShouldShowTooltip();
    }

    private void ShowBullseyeIfNeeded()
    {
        if ((TargetReticleManager.Get() != null) && TargetReticleManager.Get().IsActive())
        {
            bool show = (this.m_mousedOverCard != null) && GameState.Get().IsValidOptionTarget(this.m_mousedOverCard.GetEntity());
            TargetReticleManager.Get().ShowBullseye(show);
        }
    }

    private void ShowSkullIfNeeded()
    {
        if (this.GetBattlecrySourceCard() == null)
        {
            Network.Options.Option.SubOption selectedNetworkSubOption = GameState.Get().GetSelectedNetworkSubOption();
            if (selectedNetworkSubOption != null)
            {
                Entity entity = GameState.Get().GetEntity(selectedNetworkSubOption.ID);
                if (entity.IsMinion() || entity.IsHero())
                {
                    Entity entity2 = this.m_mousedOverCard.GetEntity();
                    if ((entity2.IsMinion() || entity2.IsHero()) && GameState.Get().IsValidOptionTarget(entity2))
                    {
                        if (entity2.CanBeDamaged() && (entity.GetATK() >= entity2.GetRemainingHP()))
                        {
                            Spell spell = this.m_mousedOverCard.ActivateActorSpell(SpellType.SKULL);
                            if (spell != null)
                            {
                                spell.transform.localScale = Vector3.zero;
                                object[] args = new object[] { "scale", Vector3.one, "time", 0.5f, "easetype", iTween.EaseType.easeOutElastic };
                                iTween.ScaleTo(spell.gameObject, iTween.Hash(args));
                            }
                        }
                        if (entity.CanBeDamaged() && (entity2.GetATK() >= entity.GetRemainingHP()))
                        {
                            Spell spell2 = entity.GetCard().ActivateActorSpell(SpellType.SKULL);
                            if (spell2 != null)
                            {
                                spell2.transform.localScale = Vector3.zero;
                                object[] objArray2 = new object[] { "scale", Vector3.one, "time", 0.5f, "easetype", iTween.EaseType.easeOutElastic };
                                iTween.ScaleTo(spell2.gameObject, iTween.Hash(objArray2));
                            }
                        }
                    }
                }
            }
        }
    }

    private void ShowTooltipIfNecessary()
    {
        if ((this.m_mousedOverCard != null) && this.m_mousedOverCard.GetShouldShowTooltip())
        {
            this.m_mousedOverTimer += UnityEngine.Time.deltaTime;
            if (this.m_mousedOverCard.IsActorReady())
            {
                SpellType spellType = this.m_mousedOverCard.GetCardDef().DetermineSummonInSpell_HandToPlay(this.m_mousedOverCard);
                Spell actorSpell = this.m_mousedOverCard.GetActorSpell(spellType);
                if ((actorSpell == null) || !actorSpell.IsActive())
                {
                    if (GameState.Get().GetGameEntity().IsMouseOverDelayOverriden())
                    {
                        this.m_mousedOverCard.ShowTooltip();
                    }
                    else if (this.m_mousedOverCard.GetZone() is ZoneHand)
                    {
                        this.m_mousedOverCard.ShowTooltip();
                    }
                    else if (this.m_mousedOverTimer >= 0.4f)
                    {
                        this.m_mousedOverCard.ShowTooltip();
                    }
                }
            }
        }
    }

    private void ShowTooltipZone(GameObject hitObject, TooltipZone tooltip)
    {
        GameState state = GameState.Get();
        if (!state.IsMulliganPhase())
        {
            GameEntity gameEntity = state.GetGameEntity();
            if (((gameEntity != null) && !gameEntity.AreTooltipsDisabled()) && !gameEntity.NotifyOfTooltipDisplay(tooltip))
            {
                if (tooltip.targetObject.GetComponent<ManaCrystalMgr>() != null)
                {
                    if (ManaCrystalMgr.Get().ShouldShowRecallTooltip())
                    {
                        this.ShowTooltipZone(tooltip, GameStrings.Get("GAMEPLAY_TOOLTIP_MANA_RECALL_HEADLINE"), GameStrings.Get("GAMEPLAY_TOOLTIP_MANA_RECALL_DESCRIPTION"));
                    }
                    else
                    {
                        this.ShowTooltipZone(tooltip, GameStrings.Get("GAMEPLAY_TOOLTIP_MANA_HEADLINE"), GameStrings.Get("GAMEPLAY_TOOLTIP_MANA_DESCRIPTION"));
                    }
                }
                else
                {
                    ZoneDeck component = tooltip.targetObject.GetComponent<ZoneDeck>();
                    if (component != null)
                    {
                        if (component.m_Side == Player.Side.FRIENDLY)
                        {
                            if (component.IsFatigued())
                            {
                                this.ShowTooltipZone(tooltip, GameStrings.Get("GAMEPLAY_TOOLTIP_FATIGUE_DECK_HEADLINE"), GameStrings.Get("GAMEPLAY_TOOLTIP_FATIGUE_DECK_DESCRIPTION"));
                            }
                            else
                            {
                                object[] args = new object[] { component.GetCards().Count };
                                this.ShowTooltipZone(tooltip, GameStrings.Get("GAMEPLAY_TOOLTIP_DECK_HEADLINE"), GameStrings.Format("GAMEPLAY_TOOLTIP_DECK_DESCRIPTION", args));
                            }
                        }
                        else if (component.m_Side == Player.Side.OPPOSING)
                        {
                            if (component.IsFatigued())
                            {
                                this.ShowTooltipZone(tooltip, GameStrings.Get("GAMEPLAY_TOOLTIP_FATIGUE_ENEMYDECK_HEADLINE"), GameStrings.Get("GAMEPLAY_TOOLTIP_FATIGUE_ENEMYDECK_DESCRIPTION"));
                            }
                            else
                            {
                                object[] objArray2 = new object[] { component.GetCards().Count };
                                this.ShowTooltipZone(tooltip, GameStrings.Get("GAMEPLAY_TOOLTIP_ENEMYDECK_HEADLINE"), GameStrings.Format("GAMEPLAY_TOOLTIP_ENEMYDECK_DESC", objArray2));
                            }
                        }
                    }
                    else
                    {
                        ZoneHand hand = tooltip.targetObject.GetComponent<ZoneHand>();
                        if ((hand != null) && (hand.m_Side == Player.Side.OPPOSING))
                        {
                            if (MissionMgr.Get().IsTutorial())
                            {
                                this.ShowTooltipZone(tooltip, GameStrings.Get("GAMEPLAY_TOOLTIP_ENEMYHAND_HEADLINE"), GameStrings.Get("GAMEPLAY_TOOLTIP_ENEMYHAND_DESC_TUT"));
                            }
                            else
                            {
                                int cardCount = hand.GetCardCount();
                                if (cardCount == 1)
                                {
                                    object[] objArray3 = new object[] { cardCount };
                                    this.ShowTooltipZone(tooltip, GameStrings.Get("GAMEPLAY_TOOLTIP_ENEMYHAND_HEADLINE"), GameStrings.Format("GAMEPLAY_TOOLTIP_ENEMYHAND_DESC_SINGLE", objArray3));
                                }
                                else
                                {
                                    object[] objArray4 = new object[] { cardCount };
                                    this.ShowTooltipZone(tooltip, GameStrings.Get("GAMEPLAY_TOOLTIP_ENEMYHAND_HEADLINE"), GameStrings.Format("GAMEPLAY_TOOLTIP_ENEMYHAND_DESC", objArray4));
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private void ShowTooltipZone(TooltipZone tooltip, string headline, string description)
    {
        GameState.Get().GetGameEntity().NotifyOfTooltipZoneMouseOver(tooltip);
        if (UniversalInputManager.IsTouchDevice != null)
        {
            tooltip.ShowGameplayTooltipLarge(headline, description);
        }
        else
        {
            tooltip.ShowGameplayTooltip(headline, description);
        }
    }

    private void Start()
    {
        if (GameState.Get() != null)
        {
            GameState.Get().RegisterChoiceReceivedListener(new GameState.ChoiceReceivedCallback(this.OnChoiceReceived));
            GameState.Get().RegisterTurnTimerUpdateListener(new GameState.TurnTimerUpdateCallback(this.OnTurnTimerUpdate));
        }
    }

    private void StartBattleCryEffect(Entity entity)
    {
        this.m_battleCryEffectActors.Clear();
        Network.Options.Option selectedNetworkOption = GameState.Get().GetSelectedNetworkOption();
        if (selectedNetworkOption == null)
        {
            UnityEngine.Debug.LogError("No targets for BattleCry.");
        }
        else
        {
            foreach (int num in selectedNetworkOption.Main.Targets)
            {
                Entity entity2 = GameState.Get().GetEntity(num);
                if (entity2.GetCard() != null)
                {
                    Actor item = entity2.GetCard().GetActor();
                    this.m_battleCryEffectActors.Add(item);
                    this.ApplyBattlecryEffectToActor(item);
                }
            }
            this.m_battlecrySourceCard.SetBattleCrySource(true);
            FullScreenFXMgr.Get().Desaturate(0.9f, 0.4f, iTween.EaseType.easeInOutQuad, null);
        }
    }

    public void StartingWatchingForInput()
    {
        if (!this.m_checkForInput)
        {
            this.m_checkForInput = true;
            foreach (Zone zone in ZoneMgr.Get().GetZones())
            {
                if (zone.m_Side == Player.Side.FRIENDLY)
                {
                    if (zone is ZoneHand)
                    {
                        this.m_myHandZone = (ZoneHand) zone;
                    }
                    else
                    {
                        if (zone is ZonePlay)
                        {
                            this.m_myPlayZone = (ZonePlay) zone;
                            continue;
                        }
                        if (zone is ZoneWeapon)
                        {
                            this.m_myWeaponZone = (ZoneWeapon) zone;
                        }
                    }
                }
            }
            this.m_handScrollBox = Board.Get().FindCollider("FriendlyHandScrollHitbox");
        }
    }

    private void Update()
    {
        if (this.m_checkForInput)
        {
            int layerMask = GameLayer.CardRaycast.LayerBit();
            if (Input.GetMouseButtonDown(0))
            {
                this.HandleLeftMouseDown();
            }
            if (Input.GetMouseButtonUp(0))
            {
                this.HandleLeftMouseUp();
            }
            if (Input.GetMouseButtonDown(1))
            {
                this.HandleRightMouseDown();
            }
            if (Input.GetMouseButtonUp(1))
            {
                this.HandleRightMouseUp();
            }
            this.HandleMouseMove(GameLayer.CardRaycast.LayerBit());
            if (this.m_leftMouseButtonIsDown && (this.heldObject == null))
            {
                this.HandleUpdateWhileLeftMouseButtonIsDown();
                if (UniversalInputManager.IsTouchDevice != null)
                {
                    this.HandleUpdateWhileNotHoldingCard(layerMask);
                }
            }
            else if (this.heldObject == null)
            {
                this.HandleUpdateWhileNotHoldingCard(layerMask);
            }
            bool hitBattlefield = UniversalInputManager.Get().InputHitAnyObject(GameLayer.InvisibleHitBox2.LayerBit());
            if ((TargetReticleManager.Get() != null) && TargetReticleManager.Get().IsActive())
            {
                if (!hitBattlefield && (this.GetBattlecrySourceCard() == null))
                {
                    TargetReticleManager.Get().DestroyFriendlyTargetArrow(true);
                }
                else
                {
                    TargetReticleManager.Get().UpdateArrowPosition();
                }
            }
            else if (((this.heldObject != null) && (TargetReticleManager.Get() != null)) && !TargetReticleManager.Get().IsArrowLoading())
            {
                this.HandleUpdateWhileHoldingCard(hitBattlefield);
            }
            if ((EmoteHandler.Get() != null) && EmoteHandler.Get().AreEmotesActive())
            {
                EmoteHandler.Get().HandleInput();
            }
            this.ShowTooltipIfNecessary();
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitThenDisplaySubOptionCards(Entity parentEntity)
    {
        return new <WaitThenDisplaySubOptionCards>c__Iterator40 { parentEntity = parentEntity, <$>parentEntity = parentEntity, <>f__this = this };
    }

    public Vector3 LastMouseDownPosition
    {
        get
        {
            return this.m_lastMouseDownPosition;
        }
    }

    public bool LeftMouseButtonDown
    {
        get
        {
            return this.m_leftMouseButtonIsDown;
        }
    }

    [CompilerGenerated]
    private sealed class <LoadThenDisplayChoiceCards>c__Iterator41 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal InputManager <>f__this;
        internal Card <card>__4;
        internal Network.Choice <choice>__0;
        internal Entity <entity>__3;
        internal int <entityId>__2;
        internal int <i>__1;

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
                case 1:
                    if (ZoneMgr.Get().HasActiveServerChange())
                    {
                        this.$current = null;
                        this.$PC = 1;
                        goto Label_01CF;
                    }
                    this.<>f__this.m_currentlyDisplayedSubCards.Clear();
                    this.<choice>__0 = GameState.Get().GetChoicePacket();
                    this.<i>__1 = 0;
                    while (this.<i>__1 < this.<choice>__0.Entities.Count)
                    {
                        this.<entityId>__2 = this.<choice>__0.Entities[this.<i>__1];
                        this.<entity>__3 = GameState.Get().GetEntity(this.<entityId>__2);
                        this.<card>__4 = this.<entity>__3.GetCard();
                        if (this.<card>__4 == null)
                        {
                            UnityEngine.Debug.LogError(string.Format("InputManager.LoadThenDisplayChoiceCards() - Entity {0} (option {1}) has no Card", this.<entity>__3, this.<i>__1));
                            goto Label_0192;
                        }
                        this.<>f__this.m_currentlyDisplayedSubCards.Add(this.<entity>__3);
                    Label_0123:
                        while (((this.<entity>__3.GetZone() != TAG_ZONE.SETASIDE) || !this.<entity>__3.IsCardReady()) || !this.<card>__4.IsActorReady())
                        {
                            this.$current = null;
                            this.$PC = 2;
                            goto Label_01CF;
                        }
                        this.<card>__4.HideCard();
                        this.<card>__4.ForceActorLoadForChoiceDisplay();
                    Label_0182:
                        while (!this.<card>__4.IsActorReady())
                        {
                            this.$current = null;
                            this.$PC = 3;
                            goto Label_01CF;
                        }
                    Label_0192:
                        this.<i>__1++;
                    }
                    this.<>f__this.DisplayChoiceCards();
                    this.$PC = -1;
                    break;

                case 2:
                    goto Label_0123;

                case 3:
                    goto Label_0182;
            }
            return false;
        Label_01CF:
            return true;
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
    private sealed class <WaitThenDisplaySubOptionCards>c__Iterator40 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Entity <$>parentEntity;
        internal InputManager <>f__this;
        internal Entity parentEntity;

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
                    if (!this.parentEntity.IsMinion())
                    {
                        goto Label_005A;
                    }
                    break;

                case 1:
                    break;

                default:
                    goto Label_0072;
            }
            if (this.parentEntity.GetZone() != TAG_ZONE.PLAY)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
        Label_005A:
            this.<>f__this.DisplaySubOptionCards(this.parentEntity);
            this.$PC = -1;
        Label_0072:
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

