using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameState
{
    private DateTime lastBlockedReport = DateTime.Now;
    private DateTime lastTimeUnblocked = DateTime.Now;
    private Pool<AttackSpellController> m_attackSpellControllerPool;
    private AttackSpellController m_attackSpellControllerPrefab;
    private Network.Choice m_choice;
    private List<ChoiceReceivedListener> m_choiceReceivedListeners = new List<ChoiceReceivedListener>();
    private List<Entity> m_chosenEntities = new List<Entity>();
    private List<CreateGameListener> m_createGameListeners = new List<CreateGameListener>();
    private Pool<DeathSpellController> m_deathSpellControllerPool;
    private Dictionary<int, Entity> m_entityMap = new Dictionary<int, Entity>();
    private Pool<FatigueSpellController> m_fatigueSpellControllerPool;
    private GameEntity m_gameEntity;
    private bool m_gameOver;
    private Network.Options m_lastOptions;
    private SelectedOption m_lastSelectedOption;
    private int m_maxFriendlyMinionsPerPlayer;
    private int m_maxSecretsPerPlayer;
    private List<MulliganTimerUpdateListener> m_mulliganTimerUpdateListeners = new List<MulliganTimerUpdateListener>();
    private Network.Options m_options;
    private List<OptionsReceivedListener> m_optionsReceivedListeners = new List<OptionsReceivedListener>();
    private Dictionary<int, Player> m_playerMap = new Dictionary<int, Player>();
    private PowerProcessor m_powerProcessor = new PowerProcessor();
    private Pool<PowerSpellController> m_powerSpellControllerPool;
    private ResponseMode m_responseMode;
    private Pool<SecretSpellController> m_secretSpellControllerPool;
    private SecretSpellController m_secretSpellControllerPrefab;
    private SelectedOption m_selectedOption = new SelectedOption();
    private List<SpellController> m_serverBlockingSpellControllers = new List<SpellController>();
    private List<Spell> m_serverBlockingSpells = new List<Spell>();
    private Pool<TriggerSpellController> m_triggerSpellControllerPool;
    private List<TurnTimerUpdateListener> m_turnTimerUpdateListeners = new List<TurnTimerUpdateListener>();
    private Dictionary<int, float> m_turnTimerUpdates = new Dictionary<int, float>();
    private bool mulliganManagerActive;
    private bool mulliganPacketBlock;
    private static GameState s_instance;
    private bool turnStartManagerActive;

    private GameState()
    {
    }

    public AttackSpellController AcquireAttackSpellController()
    {
        if (this.m_attackSpellControllerPool == null)
        {
            return null;
        }
        return this.m_attackSpellControllerPool.Acquire();
    }

    public DeathSpellController AcquireDeathSpellController()
    {
        if (this.m_deathSpellControllerPool == null)
        {
            this.CreateSpellControllerPool<DeathSpellController>(ref this.m_deathSpellControllerPool);
        }
        return this.m_deathSpellControllerPool.Acquire();
    }

    public FatigueSpellController AcquireFatigueSpellController()
    {
        if (this.m_fatigueSpellControllerPool == null)
        {
            this.CreateSpellControllerPool<FatigueSpellController>(ref this.m_fatigueSpellControllerPool);
        }
        return this.m_fatigueSpellControllerPool.Acquire();
    }

    public PowerSpellController AcquirePlaySpellController()
    {
        if (this.m_powerSpellControllerPool == null)
        {
            this.CreateSpellControllerPool<PowerSpellController>(ref this.m_powerSpellControllerPool);
        }
        return this.m_powerSpellControllerPool.Acquire();
    }

    public SecretSpellController AcquireSecretSpellController()
    {
        if (this.m_secretSpellControllerPool == null)
        {
            return null;
        }
        return this.m_secretSpellControllerPool.Acquire();
    }

    public TriggerSpellController AcquireTriggerSpellController()
    {
        if (this.m_triggerSpellControllerPool == null)
        {
            this.CreateSpellControllerPool<TriggerSpellController>(ref this.m_triggerSpellControllerPool);
        }
        return this.m_triggerSpellControllerPool.Acquire();
    }

    public bool AddChosenEntity(Entity entity)
    {
        if (this.m_chosenEntities.Contains(entity))
        {
            return false;
        }
        this.m_chosenEntities.Add(entity);
        Card card = entity.GetCard();
        if (card != null)
        {
            card.UpdateActorState();
        }
        return true;
    }

    public void AddEntity(Entity entity)
    {
        this.m_entityMap.Add(entity.GetEntityId(), entity);
        if (entity.IsAttached())
        {
            Entity entity2 = this.GetEntity(entity.GetAttached());
            if (entity2 != null)
            {
                entity2.AddAttachment(entity);
            }
        }
        if (entity.IsHero())
        {
            this.GetPlayer(entity.GetControllerId()).SetHero(entity);
        }
        else if (entity.IsHeroPower())
        {
            this.GetPlayer(entity.GetControllerId()).SetHeroPower(entity);
        }
    }

    public void AddPlayer(Player player)
    {
        this.m_playerMap.Add(player.GetPlayerId(), player);
        this.m_entityMap.Add(player.GetEntityId(), player);
    }

    public void AddServerBlockingSpell(Spell spell)
    {
        if ((spell != null) && !this.m_serverBlockingSpells.Contains(spell))
        {
            this.m_serverBlockingSpells.Add(spell);
        }
    }

    public void AddServerBlockingSpellController(SpellController spellController)
    {
        if ((spellController != null) && !this.m_serverBlockingSpellControllers.Contains(spellController))
        {
            this.m_serverBlockingSpellControllers.Add(spellController);
        }
    }

    public bool BlockAccessToOptionsPacket()
    {
        if (!this.IsMulliganPhase())
        {
            if (!this.IsLocalPlayerTurn())
            {
                return true;
            }
            if (EndTurnButton.Get().IsInWaitingState())
            {
                return true;
            }
            switch (this.m_responseMode)
            {
                case ResponseMode.NONE:
                    return true;

                case ResponseMode.OPTION:
                case ResponseMode.SUB_OPTION:
                case ResponseMode.OPTION_TARGET:
                    if (this.m_options != null)
                    {
                        break;
                    }
                    return true;

                case ResponseMode.CHOICE:
                    if (this.m_choice != null)
                    {
                        break;
                    }
                    return true;

                default:
                    UnityEngine.Debug.LogWarning(string.Format("GameState.BlockAccessToOptionsPacket() - unhandled response mode {0}", this.m_responseMode));
                    break;
            }
        }
        return false;
    }

    public void CancelCurrentOptionMode()
    {
        this.CancelSelectedOptionProposedMana();
        if (this.m_responseMode == ResponseMode.OPTION)
        {
            this.m_selectedOption.Clear();
        }
        if ((this.m_responseMode == ResponseMode.OPTION_TARGET) || (this.m_responseMode == ResponseMode.SUB_OPTION))
        {
            this.EnterMainOptionMode();
            if (this.m_selectedOption.m_sub != Network.NoSubOption)
            {
                Network.Options.Option option = this.m_options.List[this.m_selectedOption.m_main];
                Network.Options.Option.SubOption subOption = option.Subs[this.m_selectedOption.m_sub];
                this.UpdateTargetHighlights(subOption);
                this.m_selectedOption.m_sub = Network.NoSubOption;
            }
        }
    }

    private void CancelSelectedOptionProposedMana()
    {
        Network.Options.Option selectedNetworkOption = this.GetSelectedNetworkOption();
        if (selectedNetworkOption != null)
        {
            this.GetLocalPlayer().CancelAllProposedMana(this.GetEntity(selectedNetworkOption.Main.ID));
        }
    }

    public void Clear()
    {
        this.m_entityMap.Clear();
        this.m_playerMap.Clear();
        this.m_gameEntity = null;
        this.m_maxSecretsPerPlayer = 0;
        this.m_maxFriendlyMinionsPerPlayer = 0;
        this.m_responseMode = ResponseMode.NONE;
        this.m_choice = null;
        this.m_chosenEntities.Clear();
        this.m_options = null;
        this.m_selectedOption.Clear();
        this.m_lastOptions = null;
        this.m_lastSelectedOption = null;
        this.mulliganManagerActive = false;
        this.turnStartManagerActive = false;
        this.mulliganPacketBlock = false;
        this.m_createGameListeners.Clear();
        this.m_optionsReceivedListeners.Clear();
        this.m_choiceReceivedListeners.Clear();
        this.m_serverBlockingSpells.Clear();
        this.m_powerProcessor.Clear();
        this.m_attackSpellControllerPrefab = null;
        this.m_secretSpellControllerPrefab = null;
        this.ClearSpellControllerPool<AttackSpellController>(ref this.m_attackSpellControllerPool);
        this.ClearSpellControllerPool<PowerSpellController>(ref this.m_powerSpellControllerPool);
        this.ClearSpellControllerPool<DeathSpellController>(ref this.m_deathSpellControllerPool);
        this.ClearSpellControllerPool<SecretSpellController>(ref this.m_secretSpellControllerPool);
        this.ClearSpellControllerPool<TriggerSpellController>(ref this.m_triggerSpellControllerPool);
        this.m_turnTimerUpdateListeners.Clear();
        this.m_mulliganTimerUpdateListeners.Clear();
        this.m_turnTimerUpdates.Clear();
    }

    private void ClearLastOptions()
    {
        this.m_lastOptions = null;
        this.m_lastSelectedOption = null;
    }

    private void ClearOptions()
    {
        this.m_options = null;
        this.m_selectedOption.Clear();
    }

    private void ClearResponseMode()
    {
        this.m_responseMode = ResponseMode.NONE;
        for (int i = 0; i < this.m_options.List.Count; i++)
        {
            Network.Options.Option option = this.m_options.List[i];
            if (option.Type == Network.Options.Option.OptionType.POWER)
            {
                Entity entity = this.GetEntity(option.Main.ID);
                if (entity != null)
                {
                    entity.ClearBattlecryFlag();
                }
            }
        }
        this.UpdateHighlightsBasedOnSelection();
    }

    private void ClearSpellControllerPool<T>(ref Pool<T> spellControllerPool) where T: SpellController
    {
        if (spellControllerPool != null)
        {
            spellControllerPool.Clear();
            spellControllerPool = null;
        }
    }

    public PlayErrors.GameStateInfo ConvertToGameStateInfo()
    {
        PlayErrors.GameStateInfo info = new PlayErrors.GameStateInfo();
        GameState state = Get();
        info.currentStep = (TAG_STEP) state.GetGameEntity().GetTag(GAME_TAG.STEP);
        return info;
    }

    private AttackSpellController CreateAttackSpellController(int index)
    {
        GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(this.m_attackSpellControllerPrefab.gameObject);
        obj2.name = string.Format("{0}{1}", typeof(AttackSpellController).ToString(), index);
        return obj2.GetComponent<AttackSpellController>();
    }

    private SecretSpellController CreateSecretSpellController(int index)
    {
        GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(this.m_secretSpellControllerPrefab.gameObject);
        obj2.name = string.Format("{0}{1}", typeof(SecretSpellController).ToString(), index);
        return obj2.GetComponent<SecretSpellController>();
    }

    private T CreateSpellController<T>(int index) where T: SpellController
    {
        GameObject obj2 = new GameObject {
            name = string.Format("{0}{1}", typeof(T).ToString(), index)
        };
        return obj2.AddComponent<T>();
    }

    private void CreateSpellControllerPool<T>(ref Pool<T> spellControllerPool) where T: SpellController
    {
        if (spellControllerPool == null)
        {
            spellControllerPool = new Pool<T>();
            spellControllerPool.SetCreateItemCallback(new Pool<T>.CreateItemCallback(this.CreateSpellController<T>));
            spellControllerPool.SetDestroyItemCallback(new Pool<T>.DestroyItemCallback(this.DestroySpellController<T>));
            spellControllerPool.SetExtensionCount(1);
            spellControllerPool.SetMaxReleasedItemCount(2);
        }
    }

    private void CreateSpellControllerPool<T>(ref Pool<T> spellControllerPool, Pool<T>.CreateItemCallback createItemCallback) where T: SpellController
    {
        if (spellControllerPool == null)
        {
            spellControllerPool = new Pool<T>();
            spellControllerPool.SetCreateItemCallback(createItemCallback);
            spellControllerPool.SetDestroyItemCallback(new Pool<T>.DestroyItemCallback(this.DestroySpellController<T>));
            spellControllerPool.SetExtensionCount(1);
            spellControllerPool.SetMaxReleasedItemCount(2);
        }
    }

    public void DebugNukeServerBlocks()
    {
        while (this.m_serverBlockingSpells.Count > 0)
        {
            this.m_serverBlockingSpells[0].OnSpellFinished();
        }
        while (this.m_serverBlockingSpellControllers.Count > 0)
        {
            this.m_serverBlockingSpellControllers[0].OnFinishedTaskList();
        }
    }

    [Conditional("UNITY_EDITOR")]
    private void DebugPrintChoice()
    {
        object[] args = new object[] { this.m_choice.ID, (CHOICE_TYPE) this.m_choice.ChoiceType, this.m_choice.Cancelable, this.m_choice.CountMin, this.m_choice.CountMax };
        Log.Power.Print("GameState.DebugPrintChoice() - id={0} ChoiceType={1} Cancelable={2} CountMin={3} CountMax={4}", args);
        object printableEntity = this.GetPrintableEntity(this.m_choice.Source);
        object[] objArray2 = new object[] { printableEntity };
        Log.Power.Print("GameState.DebugPrintChoice() -   Source={0}", objArray2);
        for (int i = 0; i < this.m_choice.Entities.Count; i++)
        {
            object obj3 = this.GetPrintableEntity(this.m_choice.Entities[i]);
            object[] objArray3 = new object[] { i, obj3 };
            Log.Power.Print("GameState.DebugPrintChoice() -   Entities[{0}]={1}", objArray3);
        }
    }

    [Conditional("UNITY_EDITOR")]
    private void DebugPrintOptions()
    {
        object[] args = new object[] { this.m_options.ID };
        Log.Power.Print("GameState.DebugPrintOptions() - id={0}", args);
        for (int i = 0; i < this.m_options.List.Count; i++)
        {
            Network.Options.Option option = this.m_options.List[i];
            Entity entity = this.GetEntity(option.Main.ID);
            object[] objArray2 = new object[] { i, option.Type, entity };
            Log.Power.Print("GameState.DebugPrintOptions() -   option {0} type={1} mainEntity={2}", objArray2);
            if (option.Main.Targets != null)
            {
                for (int k = 0; k < option.Main.Targets.Count; k++)
                {
                    int id = option.Main.Targets[k];
                    Entity entity2 = this.GetEntity(id);
                    object[] objArray3 = new object[] { k, entity2 };
                    Log.Power.Print("GameState.DebugPrintOptions() -     target {0} entity={1}", objArray3);
                }
            }
            for (int j = 0; j < option.Subs.Count; j++)
            {
                Network.Options.Option.SubOption option2 = option.Subs[j];
                Entity entity3 = this.GetEntity(option2.ID);
                object[] objArray4 = new object[] { j, entity3 };
                Log.Power.Print("GameState.DebugPrintOptions() -     subOption {0} entity={1}", objArray4);
                if (option2.Targets != null)
                {
                    for (int m = 0; m < option2.Targets.Count; m++)
                    {
                        int num6 = option2.Targets[m];
                        Entity entity4 = this.GetEntity(num6);
                        object[] objArray5 = new object[] { m, entity4 };
                        Log.Power.Print("GameState.DebugPrintOptions() -       target {0} entity={1}", objArray5);
                    }
                }
            }
        }
    }

    [Conditional("UNITY_EDITOR")]
    public void DebugPrintPower(string callerName, Network.PowerHistory netPower, int index, ref string indentation)
    {
        Network.Entity entity2;
        switch (netPower.Type)
        {
            case Network.PowerHistory.PowType.FULL_ENTITY:
            {
                Network.HistFullEntity entity = netPower as Network.HistFullEntity;
                entity2 = entity.Entity;
                Entity entity3 = this.GetEntity(entity2.ID);
                if (entity3 != null)
                {
                    object[] objArray4 = new object[] { callerName, indentation, entity3, entity2.CardID };
                    Log.Power.Print("{0}.DebugPrintPower() - {1}FULL_ENTITY - Updating {2} CardID={3}", objArray4);
                    break;
                }
                object[] args = new object[] { callerName, indentation, entity2.ID, entity2.CardID };
                Log.Power.Print("{0}.DebugPrintPower() - {1}FULL_ENTITY - Creating ID={2} CardID={3}", args);
                break;
            }
            case Network.PowerHistory.PowType.SHOW_ENTITY:
            {
                Network.HistShowEntity entity4 = netPower as Network.HistShowEntity;
                Network.Entity entity5 = entity4.Entity;
                object printableEntity = this.GetPrintableEntity(entity5.ID);
                object[] objArray10 = new object[] { callerName, indentation, printableEntity, entity5.CardID };
                Log.Power.Print("{0}.DebugPrintPower() - {1}SHOW_ENTITY - Updating Entity={2} CardID={3}", objArray10);
                indentation = indentation + "    ";
                indentation = indentation.Remove(indentation.Length - "    ".Length);
                return;
            }
            case Network.PowerHistory.PowType.HIDE_ENTITY:
            {
                Network.HistHideEntity entity6 = netPower as Network.HistHideEntity;
                object obj6 = this.GetPrintableEntity(entity6.Entity);
                object[] objArray11 = new object[] { callerName, indentation, obj6, Tags.DebugTag(0x31, entity6.Zone) };
                Log.Power.Print("{0}.DebugPrintPower() - {1}HIDE_ENTITY - Entity={2} {3}", objArray11);
                return;
            }
            case Network.PowerHistory.PowType.TAG_CHANGE:
            {
                Network.HistTagChange change = netPower as Network.HistTagChange;
                object obj4 = this.GetPrintableEntity(change.Entity);
                object[] objArray6 = new object[] { callerName, indentation, obj4, Tags.DebugTag(change.Tag, change.Value) };
                Log.Power.Print("{0}.DebugPrintPower() - {1}TAG_CHANGE Entity={2} {3}", objArray6);
                return;
            }
            case Network.PowerHistory.PowType.ACTION_START:
            {
                Network.HistActionStart start = netPower as Network.HistActionStart;
                object obj2 = this.GetPrintableEntity(start.Entity);
                object obj3 = this.GetPrintableEntity(start.Target);
                object[] objArray1 = new object[] { callerName, indentation, obj2, start.SubType, start.Index, obj3 };
                Log.Power.Print("{0}.DebugPrintPower() - {1}ACTION_START Entity={2} SubType={3} Index={4} Target={5}", objArray1);
                indentation = indentation + "    ";
                return;
            }
            case Network.PowerHistory.PowType.ACTION_END:
            {
                if (indentation.Length >= "    ".Length)
                {
                    indentation = indentation.Remove(indentation.Length - "    ".Length);
                }
                object[] objArray2 = new object[] { callerName, indentation };
                Log.Power.Print("{0}.DebugPrintPower() - {1}ACTION_END", objArray2);
                return;
            }
            case Network.PowerHistory.PowType.CREATE_GAME:
            {
                Network.HistCreateGame game = netPower as Network.HistCreateGame;
                object[] objArray7 = new object[] { callerName, indentation };
                Log.Power.Print("{0}.DebugPrintPower() - {1}CREATE_GAME", objArray7);
                indentation = indentation + "    ";
                object[] objArray8 = new object[] { callerName, indentation, game.Game.ID };
                Log.Power.Print("{0}.DebugPrintPower() - {1}GameEntity EntityID={2}", objArray8);
                indentation = indentation + "    ";
                indentation = indentation.Remove(indentation.Length - "    ".Length);
                foreach (Network.HistCreateGame.PlayerData data in game.Players)
                {
                    object[] objArray9 = new object[] { callerName, indentation, data.Player.ID, data.ID, data.GameAccountId };
                    Log.Power.Print("{0}.DebugPrintPower() - {1}Player EntityID={2} PlayerID={3} GameAccountId={4}", objArray9);
                    indentation = indentation + "    ";
                    indentation = indentation.Remove(indentation.Length - "    ".Length);
                }
                indentation = indentation.Remove(indentation.Length - "    ".Length);
                return;
            }
            case Network.PowerHistory.PowType.META_DATA:
            {
                Network.HistMetaData data2 = netPower as Network.HistMetaData;
                object[] objArray12 = new object[] { callerName, indentation, data2.MetaType, data2.Data };
                Log.Power.Print("{0}.DebugPrintPower() - {1}META_DATA - Meta={2} Data={3}", objArray12);
                return;
            }
            default:
            {
                object[] objArray13 = new object[] { callerName, index, netPower.Type };
                Log.Power.Print("{0}.DebugPrintPower() - ERROR: index {1} has unhandled PowType {2}", objArray13);
                return;
            }
        }
        indentation = indentation + "    ";
        for (int i = 0; i < entity2.Tags.Count; i++)
        {
            Network.Entity.Tag tag = entity2.Tags[i];
            object[] objArray5 = new object[] { callerName, indentation, Tags.DebugTag(tag.Name, tag.Value) };
            Log.Power.Print("{0}.DebugPrintPower() - {1}{2}", objArray5);
        }
        indentation = indentation.Remove(indentation.Length - "    ".Length);
    }

    [Conditional("UNITY_EDITOR")]
    private void DebugPrintPowerList(List<Network.PowerHistory> netPowerList)
    {
        Log.Power.Print(string.Format("GameState.DebugPrintPowerList() - Count={0}", netPowerList.Count));
        for (int i = 0; i < netPowerList.Count; i++)
        {
            Network.PowerHistory history = netPowerList[i];
        }
    }

    [Conditional("UNITY_EDITOR")]
    private void DebugPrintTags(string callerName, string indentation, Network.Entity netEntity)
    {
        for (int i = 0; i < netEntity.Tags.Count; i++)
        {
            Network.Entity.Tag tag = netEntity.Tags[i];
            object[] args = new object[] { callerName, indentation, Tags.DebugTag(tag.Name, tag.Value) };
            Log.Power.Print("{0}.DebugPrintPower() - {1}{2}", args);
        }
    }

    [Conditional("UNITY_EDITOR")]
    public void DebugSetGameEntity(GameEntity gameEntity)
    {
        this.m_gameEntity = gameEntity;
    }

    private void DestroySpellController<T>(T spellController) where T: SpellController
    {
        UnityEngine.Object.Destroy(spellController.gameObject);
    }

    public void EnterChoiceMode()
    {
        this.m_responseMode = ResponseMode.CHOICE;
        this.UpdateChoiceHighlights();
    }

    public void EnterMainOptionMode()
    {
        ResponseMode responseMode = this.m_responseMode;
        this.m_responseMode = ResponseMode.OPTION;
        switch (responseMode)
        {
            case ResponseMode.SUB_OPTION:
            {
                Network.Options.Option option = this.m_options.List[this.m_selectedOption.m_main];
                this.UpdateSubOptionHighlights(option);
                break;
            }
            case ResponseMode.OPTION_TARGET:
            {
                Network.Options.Option option2 = this.m_options.List[this.m_selectedOption.m_main];
                this.UpdateTargetHighlights(option2.Main);
                break;
            }
        }
        this.UpdateOptionHighlights();
        this.m_selectedOption.Clear();
    }

    public void EnterOptionTargetMode()
    {
        if (this.m_responseMode == ResponseMode.OPTION)
        {
            this.m_responseMode = ResponseMode.OPTION_TARGET;
            this.UpdateOptionHighlights();
            Network.Options.Option option = this.m_options.List[this.m_selectedOption.m_main];
            this.UpdateTargetHighlights(option.Main);
        }
        else if (this.m_responseMode == ResponseMode.SUB_OPTION)
        {
            this.m_responseMode = ResponseMode.OPTION_TARGET;
            Network.Options.Option option2 = this.m_options.List[this.m_selectedOption.m_main];
            this.UpdateSubOptionHighlights(option2);
            Network.Options.Option.SubOption subOption = option2.Subs[this.m_selectedOption.m_sub];
            this.UpdateTargetHighlights(subOption);
        }
    }

    public void EnterSubOptionMode()
    {
        Network.Options.Option option = this.m_options.List[this.m_selectedOption.m_main];
        if (this.m_responseMode == ResponseMode.OPTION)
        {
            this.m_responseMode = ResponseMode.SUB_OPTION;
            this.UpdateOptionHighlights();
        }
        else if (this.m_responseMode == ResponseMode.OPTION_TARGET)
        {
            this.m_responseMode = ResponseMode.SUB_OPTION;
            Network.Options.Option.SubOption subOption = option.Subs[this.m_selectedOption.m_sub];
            this.UpdateTargetHighlights(subOption);
        }
        this.UpdateSubOptionHighlights(option);
    }

    public bool EntityHasSubOptions(Entity entity)
    {
        int entityId = entity.GetEntityId();
        Network.Options optionsPacket = this.GetOptionsPacket();
        if (optionsPacket != null)
        {
            for (int i = 0; i < optionsPacket.List.Count; i++)
            {
                Network.Options.Option option = optionsPacket.List[i];
                if ((option.Type == Network.Options.Option.OptionType.POWER) && (option.Main.ID == entityId))
                {
                    return ((option.Subs != null) && (option.Subs.Count > 0));
                }
            }
        }
        return false;
    }

    public bool EntityHasTargets(Entity entity)
    {
        return this.EntityHasTargets(entity, false);
    }

    private bool EntityHasTargets(Entity entity, bool isSubEntity)
    {
        int entityId = entity.GetEntityId();
        Network.Options optionsPacket = this.GetOptionsPacket();
        if (optionsPacket != null)
        {
            for (int i = 0; i < optionsPacket.List.Count; i++)
            {
                Network.Options.Option option = optionsPacket.List[i];
                if (option.Type == Network.Options.Option.OptionType.POWER)
                {
                    if (isSubEntity)
                    {
                        if (option.Subs != null)
                        {
                            for (int j = 0; j < option.Subs.Count; j++)
                            {
                                Network.Options.Option.SubOption option2 = option.Subs[j];
                                if (option2.ID == entityId)
                                {
                                    return ((option2.Targets != null) && (option2.Targets.Count > 0));
                                }
                            }
                        }
                    }
                    else if (option.Main.ID == entityId)
                    {
                        return ((option.Main.Targets != null) && (option.Main.Targets.Count > 0));
                    }
                }
            }
        }
        return false;
    }

    private void FireChoiceReceivedEvent()
    {
        foreach (ChoiceReceivedListener listener in this.m_choiceReceivedListeners.ToArray())
        {
            listener.Fire();
        }
    }

    private void FireCreateGameEvent()
    {
        foreach (CreateGameListener listener in this.m_createGameListeners.ToArray())
        {
            listener.Fire();
        }
    }

    private void FireOptionsReceivedEvent()
    {
        foreach (OptionsReceivedListener listener in this.m_optionsReceivedListeners.ToArray())
        {
            listener.Fire();
        }
    }

    private void FireTurnTimerUpdateEvent(int turn, float secondsRemaining, float endTimestamp)
    {
        if (this.IsMulliganPhase())
        {
            foreach (MulliganTimerUpdateListener listener in this.m_mulliganTimerUpdateListeners.ToArray())
            {
                listener.Fire(turn, secondsRemaining, endTimestamp);
            }
        }
        else
        {
            foreach (TurnTimerUpdateListener listener2 in this.m_turnTimerUpdateListeners.ToArray())
            {
                listener2.Fire(turn, secondsRemaining, endTimestamp);
            }
        }
    }

    public bool GameHasBegun()
    {
        return (((this.m_gameEntity.GetTag(GAME_TAG.STEP) != 1) && (this.m_gameEntity.GetTag(GAME_TAG.STEP) != 4)) && (!this.IsMulliganPhase() && (this.m_gameEntity.GetTag(GAME_TAG.STEP) != 0)));
    }

    public static GameState Get()
    {
        return s_instance;
    }

    public AttackSpellController GetAttackSpellControllerPrefab()
    {
        return this.m_attackSpellControllerPrefab;
    }

    public Network.Choice GetChoicePacket()
    {
        return this.m_choice;
    }

    public List<Entity> GetChosenEntities()
    {
        return this.m_chosenEntities;
    }

    public Player GetCurrentPlayer()
    {
        foreach (Player player in this.m_playerMap.Values)
        {
            if (player.IsCurrentPlayer())
            {
                return player;
            }
        }
        return null;
    }

    public Entity GetEntity(int id)
    {
        Entity entity;
        this.m_entityMap.TryGetValue(id, out entity);
        return entity;
    }

    public Dictionary<int, Entity> GetEntityMap()
    {
        return this.m_entityMap;
    }

    public Player GetFirstOpponentPlayer(Player player)
    {
        foreach (Player player2 in this.m_playerMap.Values)
        {
            if (player2.GetSide() != player.GetSide())
            {
                return player2;
            }
        }
        return null;
    }

    public GameEntity GetGameEntity()
    {
        return this.m_gameEntity;
    }

    public DateTime GetLatestKillTimeForAllSpellControllers()
    {
        DateTime time = DateTime.FromBinary(0L);
        DateTime latestKillTimeForSpellController = this.GetLatestKillTimeForSpellController<AttackSpellController>(this.m_attackSpellControllerPool);
        if (latestKillTimeForSpellController > time)
        {
            time = latestKillTimeForSpellController;
        }
        latestKillTimeForSpellController = this.GetLatestKillTimeForSpellController<PowerSpellController>(this.m_powerSpellControllerPool);
        if (latestKillTimeForSpellController > time)
        {
            time = latestKillTimeForSpellController;
        }
        latestKillTimeForSpellController = this.GetLatestKillTimeForSpellController<DeathSpellController>(this.m_deathSpellControllerPool);
        if (latestKillTimeForSpellController > time)
        {
            time = latestKillTimeForSpellController;
        }
        latestKillTimeForSpellController = this.GetLatestKillTimeForSpellController<SecretSpellController>(this.m_secretSpellControllerPool);
        if (latestKillTimeForSpellController > time)
        {
            time = latestKillTimeForSpellController;
        }
        latestKillTimeForSpellController = this.GetLatestKillTimeForSpellController<TriggerSpellController>(this.m_triggerSpellControllerPool);
        if (latestKillTimeForSpellController > time)
        {
            time = latestKillTimeForSpellController;
        }
        latestKillTimeForSpellController = this.GetLatestKillTimeForSpellController<FatigueSpellController>(this.m_fatigueSpellControllerPool);
        if (latestKillTimeForSpellController > time)
        {
            time = latestKillTimeForSpellController;
        }
        return time;
    }

    private DateTime GetLatestKillTimeForSpellController<T>(Pool<T> spellControllerPool) where T: SpellController
    {
        DateTime time = DateTime.FromBinary(0L);
        if (spellControllerPool != null)
        {
            foreach (T local in spellControllerPool.GetFreeList())
            {
                DateTime lastWaitKillTime = local.GetLastWaitKillTime();
                if (lastWaitKillTime > time)
                {
                    time = lastWaitKillTime;
                }
            }
            foreach (T local2 in spellControllerPool.GetActiveList())
            {
                DateTime time3 = local2.GetLastWaitKillTime();
                if (time3 > time)
                {
                    time = time3;
                }
            }
        }
        return time;
    }

    public Player GetLocalPlayer()
    {
        foreach (Player player in this.m_playerMap.Values)
        {
            if (player.IsLocal())
            {
                return player;
            }
        }
        return null;
    }

    public int GetMaxFriendlyMinionsPerPlayer()
    {
        return this.m_maxFriendlyMinionsPerPlayer;
    }

    public int GetMaxSecretsPerPlayer()
    {
        return this.m_maxSecretsPerPlayer;
    }

    public Network.Options GetOptionsPacket()
    {
        return this.m_options;
    }

    public Player GetPlayer(int id)
    {
        Player player;
        this.m_playerMap.TryGetValue(id, out player);
        return player;
    }

    public Dictionary<int, Player> GetPlayerMap()
    {
        return this.m_playerMap;
    }

    public PowerProcessor GetPowerProcessor()
    {
        return this.m_powerProcessor;
    }

    private object GetPrintableEntity(int id)
    {
        Entity entity = this.GetEntity(id);
        if (entity == null)
        {
            return id;
        }
        return entity;
    }

    public Player GetRemotePlayer()
    {
        foreach (Player player in this.m_playerMap.Values)
        {
            if (!player.IsLocal())
            {
                return player;
            }
        }
        return null;
    }

    public ResponseMode GetResponseMode()
    {
        return this.m_responseMode;
    }

    public SecretSpellController GetSecretSpellControllerPrefab()
    {
        return this.m_secretSpellControllerPrefab;
    }

    public Network.Options.Option GetSelectedNetworkOption()
    {
        if (this.m_selectedOption.m_main < 0)
        {
            return null;
        }
        return this.m_options.List[this.m_selectedOption.m_main];
    }

    public Network.Options.Option.SubOption GetSelectedNetworkSubOption()
    {
        if (this.m_selectedOption.m_main < 0)
        {
            return null;
        }
        Network.Options.Option option = this.m_options.List[this.m_selectedOption.m_main];
        if (this.m_selectedOption.m_sub == Network.NoSubOption)
        {
            return option.Main;
        }
        return option.Subs[this.m_selectedOption.m_sub];
    }

    public int GetSelectedOption()
    {
        return this.m_selectedOption.m_main;
    }

    public int GetSelectedOptionPosition()
    {
        return this.m_selectedOption.m_position;
    }

    public int GetSelectedOptionTarget()
    {
        return this.m_selectedOption.m_target;
    }

    public int GetSelectedSubOption()
    {
        return this.m_selectedOption.m_sub;
    }

    public bool HasResponse(Entity entity)
    {
        switch (this.GetResponseMode())
        {
            case ResponseMode.OPTION:
                return this.IsOption(entity);

            case ResponseMode.SUB_OPTION:
                return this.IsSubOption(entity);

            case ResponseMode.OPTION_TARGET:
                return this.IsOptionTarget(entity);

            case ResponseMode.CHOICE:
                return this.IsChoice(entity);
        }
        return false;
    }

    public bool HasSubOptions(Entity entity)
    {
        if (!this.BlockAccessToOptionsPacket())
        {
            if (entity.IsBusy())
            {
                return false;
            }
            int entityId = entity.GetEntityId();
            Network.Options optionsPacket = this.GetOptionsPacket();
            for (int i = 0; i < optionsPacket.List.Count; i++)
            {
                Network.Options.Option option = optionsPacket.List[i];
                if ((option.Type == Network.Options.Option.OptionType.POWER) && (option.Main.ID == entityId))
                {
                    return (option.Subs.Count > 0);
                }
            }
        }
        return false;
    }

    public static GameState Initialize()
    {
        if (s_instance == null)
        {
            s_instance = new GameState();
        }
        return s_instance;
    }

    public bool IsBeginPhase()
    {
        if (this.m_gameEntity != null)
        {
            switch (this.m_gameEntity.GetTag<TAG_STEP>(GAME_TAG.STEP))
            {
                case TAG_STEP.BEGIN_FIRST:
                case TAG_STEP.BEGIN_SHUFFLE:
                case TAG_STEP.BEGIN_DRAW:
                case TAG_STEP.BEGIN_MULLIGAN:
                    return true;
            }
        }
        return false;
    }

    public bool IsBlockingServer()
    {
        DateTime now = DateTime.Now;
        if (!this.IsBlockingServer_())
        {
            this.lastTimeUnblocked = now;
            return false;
        }
        TimeSpan span = (TimeSpan) (now - this.lastTimeUnblocked);
        if (span >= new TimeSpan(0, 0, 5))
        {
            TimeSpan span2 = (TimeSpan) (now - this.lastBlockedReport);
            if (span2 < new TimeSpan(0, 0, 3))
            {
                return true;
            }
            this.lastBlockedReport = now;
            UnityEngine.Debug.LogWarning("IsBlockingServer has been true for " + span);
        }
        return true;
    }

    private bool IsBlockingServer_()
    {
        return ((this.m_serverBlockingSpells.Count > 0) || ((this.m_serverBlockingSpellControllers.Count > 0) || this.mulliganPacketBlock));
    }

    public bool IsChoice(Entity entity)
    {
        if (this.BlockAccessToOptionsPacket())
        {
            return false;
        }
        if (entity.IsBusy())
        {
            return false;
        }
        if (!this.IsChoosableEntity(entity))
        {
            return false;
        }
        if (this.IsChosenEntity(entity))
        {
            return false;
        }
        return true;
    }

    public bool IsChoosableEntity(Entity entity)
    {
        if (this.m_choice == null)
        {
            return false;
        }
        return this.m_choice.Entities.Contains(entity.GetEntityId());
    }

    public bool IsChosenEntity(Entity entity)
    {
        if (this.m_choice == null)
        {
            return false;
        }
        return this.m_chosenEntities.Contains(entity);
    }

    public bool IsConcedingAllowed()
    {
        if (MissionMgr.Get().IsTutorial())
        {
            return false;
        }
        return true;
    }

    public bool IsGameOver()
    {
        return this.m_gameOver;
    }

    public bool IsInMainOptionMode()
    {
        return (this.m_responseMode == ResponseMode.OPTION);
    }

    public bool IsInSubOptionMode()
    {
        return (this.m_responseMode == ResponseMode.SUB_OPTION);
    }

    public bool IsInTargetMode()
    {
        return (this.m_responseMode == ResponseMode.OPTION_TARGET);
    }

    public bool IsLocalPlayerTurn()
    {
        Player localPlayer = this.GetLocalPlayer();
        if (localPlayer == null)
        {
            return false;
        }
        return localPlayer.IsCurrentPlayer();
    }

    public bool IsMainPhase()
    {
        if (this.m_gameEntity != null)
        {
            switch (this.m_gameEntity.GetTag<TAG_STEP>(GAME_TAG.STEP))
            {
                case TAG_STEP.MAIN_BEGIN:
                case TAG_STEP.MAIN_READY:
                case TAG_STEP.MAIN_RESOURCE:
                case TAG_STEP.MAIN_DRAW:
                case TAG_STEP.MAIN_START:
                case TAG_STEP.MAIN_ACTION:
                case TAG_STEP.MAIN_COMBAT:
                case TAG_STEP.MAIN_END:
                case TAG_STEP.MAIN_NEXT:
                case TAG_STEP.MAIN_CLEANUP:
                case TAG_STEP.MAIN_START_TRIGGERS:
                    return true;
            }
        }
        return false;
    }

    public bool IsMulliganPhase()
    {
        return this.mulliganManagerActive;
    }

    public bool IsOption(Entity entity)
    {
        if (!this.BlockAccessToOptionsPacket())
        {
            if (entity.IsBusy())
            {
                return false;
            }
            int entityId = entity.GetEntityId();
            Network.Options optionsPacket = this.GetOptionsPacket();
            if (optionsPacket == null)
            {
                return false;
            }
            for (int i = 0; i < optionsPacket.List.Count; i++)
            {
                Network.Options.Option option = optionsPacket.List[i];
                if ((option.Type == Network.Options.Option.OptionType.POWER) && (option.Main.ID == entityId))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsOptionTarget(Entity entity)
    {
        if (!this.BlockAccessToOptionsPacket())
        {
            if (entity.IsBusy())
            {
                return false;
            }
            int entityId = entity.GetEntityId();
            Network.Options.Option.SubOption selectedNetworkSubOption = this.GetSelectedNetworkSubOption();
            if (selectedNetworkSubOption.Targets == null)
            {
                return false;
            }
            for (int i = 0; i < selectedNetworkSubOption.Targets.Count; i++)
            {
                int num3 = selectedNetworkSubOption.Targets[i];
                if (num3 == entityId)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsStartOfTurn()
    {
        return (this.m_gameEntity.GetTag(GAME_TAG.STEP) == 6);
    }

    public bool IsSubOption(Entity entity)
    {
        if (!this.BlockAccessToOptionsPacket())
        {
            if (entity.IsBusy())
            {
                return false;
            }
            int entityId = entity.GetEntityId();
            Network.Options.Option selectedNetworkOption = this.GetSelectedNetworkOption();
            for (int i = 0; i < selectedNetworkOption.Subs.Count; i++)
            {
                Network.Options.Option.SubOption option2 = selectedNetworkOption.Subs[i];
                if (option2.ID == entityId)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsTurnStartManagerActive()
    {
        return this.turnStartManagerActive;
    }

    public bool IsValidOptionTarget(Entity entity)
    {
        Network.Options.Option.SubOption selectedNetworkSubOption = this.GetSelectedNetworkSubOption();
        return (((selectedNetworkSubOption != null) && (selectedNetworkSubOption.Targets != null)) && selectedNetworkSubOption.Targets.Contains(entity.GetEntityId()));
    }

    public void MulliganManagerActivate(bool activate)
    {
        this.mulliganManagerActive = activate;
    }

    public void OnCreateGame(Network.HistCreateGame createGame)
    {
        this.m_gameEntity = MissionMgr.Get().CreateGameEntity();
        this.m_gameEntity.ReplaceTags(createGame.Game.Tags);
        this.AddEntity(this.m_gameEntity);
        foreach (Network.HistCreateGame.PlayerData data in createGame.Players)
        {
            Player player = new Player();
            player.SetPlayerId(data.ID);
            player.SetGameAccountId(data.GameAccountId);
            player.ReplaceTags(data.Player.Tags);
            this.AddPlayer(player);
        }
        this.FireCreateGameEvent();
    }

    public bool OnFullEntity(Network.HistFullEntity fullEntity)
    {
        Network.Entity entity = fullEntity.Entity;
        Entity entity2 = this.GetEntity(entity.ID);
        if (entity2 == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("GameState.OnFullEntity() - WARNING entity {0} DOES NOT EXIST!", entity.ID));
            return false;
        }
        entity2.LoadCard(entity.CardID);
        return true;
    }

    public void OnGameOver(TAG_PLAYSTATE playState)
    {
        this.m_gameOver = true;
        this.m_gameEntity.NotifyOfGameOver(playState);
    }

    public void OnGameSetup(Network.GameSetup setup)
    {
        this.m_maxSecretsPerPlayer = setup.MaxSecretsPerPlayer;
        this.m_maxFriendlyMinionsPerPlayer = setup.MaxFriendlyMinionsPerPlayer;
    }

    public bool OnHideEntity(Network.HistHideEntity hideEntity)
    {
        Entity entity = this.GetEntity(hideEntity.Entity);
        if (entity == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("GameState.OnHideEntity() - WARNING entity {0} DOES NOT EXIST! zone={1}", hideEntity.Entity, hideEntity.Zone));
            return false;
        }
        entity.SetTagAndUpdateCard<int>(GAME_TAG.ZONE, hideEntity.Zone);
        return true;
    }

    public void OnMakeChoice(Network.Choice choice)
    {
        this.m_responseMode = ResponseMode.CHOICE;
        this.m_chosenEntities.Clear();
        this.m_choice = choice;
        this.EnterChoiceMode();
        this.FireChoiceReceivedEvent();
    }

    public void OnOptionRejected(int optionId)
    {
        if (this.m_lastSelectedOption == null)
        {
            UnityEngine.Debug.LogError("GameState.OnOptionRejected() - got an option rejection without a last selected option");
        }
        else if (this.m_lastOptions.ID != optionId)
        {
            UnityEngine.Debug.LogError(string.Format("GameState.OnOptionRejected() - rejected option id ({0}) does not match last option id ({1})", optionId, this.m_lastOptions.ID));
        }
        else
        {
            Network.Options.Option option = this.m_lastOptions.List[this.m_lastSelectedOption.m_main];
            Entity triggerEntity = this.GetEntity(option.Main.ID);
            triggerEntity.GetCard().NotifyTargetingCanceled();
            ZoneMgr.Get().OnLocalZoneChangeRejected(triggerEntity);
            InputManager.Get().ReverseManaUpdate(triggerEntity);
            string message = GameStrings.Get("GAMEPLAY_ERROR_PLAY_REJECTED");
            GameplayErrorManager.Get().DisplayMessage(message);
            this.ClearLastOptions();
        }
    }

    public void OnPickOption(Network.Options options)
    {
        this.m_responseMode = ResponseMode.OPTION;
        this.m_chosenEntities.Clear();
        this.m_options = options;
        foreach (Network.Options.Option option in this.m_options.List)
        {
            if (option.Type == Network.Options.Option.OptionType.POWER)
            {
                Entity entity = this.GetEntity(option.Main.ID);
                if ((entity != null) && ((option.Main.Targets != null) && (option.Main.Targets.Count > 0)))
                {
                    entity.UpdateUseBattlecryFlag(true);
                }
            }
        }
        this.EnterMainOptionMode();
        this.FireOptionsReceivedEvent();
    }

    public void OnPower(List<Network.PowerHistory> netPowerList)
    {
        this.m_powerProcessor.OnPowerList(netPowerList);
    }

    private void OnSelectedOptionsSent()
    {
        this.ClearResponseMode();
        this.m_lastOptions = new Network.Options();
        this.m_lastOptions.CopyFrom(this.m_options);
        this.m_lastSelectedOption = new SelectedOption();
        this.m_lastSelectedOption.CopyFrom(this.m_selectedOption);
        this.ClearOptions();
    }

    public bool OnShowEntity(Network.HistShowEntity showEntity)
    {
        Network.Entity entity = showEntity.Entity;
        Entity entity2 = this.GetEntity(entity.ID);
        if (entity2 == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("GameState.OnShowEntity() - WARNING entity {0} DOES NOT EXIST!", entity.ID));
            return false;
        }
        TagDeltaSet changeSet = entity2.GetTags().CreateDeltas(entity.Tags);
        entity2.UpdateTags(entity.Tags);
        entity2.LoadCard(entity.CardID, changeSet);
        return true;
    }

    public bool OnTagChange(Network.HistTagChange tagChange)
    {
        Entity entity = this.GetEntity(tagChange.Entity);
        if (entity == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("GameState.OnTagChange() - WARNING Entity {0} does not exist", tagChange.Entity));
            return false;
        }
        entity.SetTagAndUpdateCard(tagChange.Tag, tagChange.Value);
        return true;
    }

    private void OnTimeout()
    {
        if (this.m_options != null)
        {
            this.ClearResponseMode();
            this.ClearLastOptions();
            this.ClearOptions();
        }
    }

    public void OnTurnChanged(int oldTurn, int newTurn)
    {
        this.OnTurnChanged_TurnTimer(oldTurn, newTurn);
    }

    public void OnTurnChanged_TurnTimer(int oldTurn, int newTurn)
    {
        float num;
        if ((this.m_turnTimerUpdates.Count != 0) && this.m_turnTimerUpdates.TryGetValue(newTurn, out num))
        {
            float realtimeSinceStartup = UnityEngine.Time.realtimeSinceStartup;
            float secondsRemaining = 0f;
            if (num > realtimeSinceStartup)
            {
                secondsRemaining = num - realtimeSinceStartup;
            }
            this.TriggerTurnTimerUpdate(newTurn, secondsRemaining, num);
            this.m_turnTimerUpdates.Remove(newTurn);
        }
    }

    public void OnTurnTimerUpdate(int turn, float secondsRemaining)
    {
        float endTimestamp = UnityEngine.Time.realtimeSinceStartup + secondsRemaining;
        int num3 = (this.m_gameEntity != null) ? this.m_gameEntity.GetTag(GAME_TAG.TURN) : 0;
        if (turn > num3)
        {
            this.m_turnTimerUpdates[turn] = endTimestamp;
        }
        else
        {
            this.TriggerTurnTimerUpdate(turn, secondsRemaining, endTimestamp);
        }
    }

    public bool RegisterChoiceReceivedListener(ChoiceReceivedCallback callback)
    {
        return this.RegisterChoiceReceivedListener(callback, null);
    }

    public bool RegisterChoiceReceivedListener(ChoiceReceivedCallback callback, object userData)
    {
        ChoiceReceivedListener item = new ChoiceReceivedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_choiceReceivedListeners.Contains(item))
        {
            return false;
        }
        this.m_choiceReceivedListeners.Add(item);
        return true;
    }

    public bool RegisterCreateGameListener(CreateGameCallback callback)
    {
        return this.RegisterCreateGameListener(callback, null);
    }

    public bool RegisterCreateGameListener(CreateGameCallback callback, object userData)
    {
        CreateGameListener item = new CreateGameListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_createGameListeners.Contains(item))
        {
            return false;
        }
        this.m_createGameListeners.Add(item);
        return true;
    }

    public bool RegisterMulliganTimerUpdateListener(MulliganTimerUpdateCallback callback)
    {
        return this.RegisterMulliganTimerUpdateListener(callback, null);
    }

    public bool RegisterMulliganTimerUpdateListener(MulliganTimerUpdateCallback callback, object userData)
    {
        MulliganTimerUpdateListener item = new MulliganTimerUpdateListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_mulliganTimerUpdateListeners.Contains(item))
        {
            return false;
        }
        this.m_mulliganTimerUpdateListeners.Add(item);
        return true;
    }

    public bool RegisterOptionsReceivedListener(OptionsReceivedCallback callback)
    {
        return this.RegisterOptionsReceivedListener(callback, null);
    }

    public bool RegisterOptionsReceivedListener(OptionsReceivedCallback callback, object userData)
    {
        OptionsReceivedListener item = new OptionsReceivedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_optionsReceivedListeners.Contains(item))
        {
            return false;
        }
        this.m_optionsReceivedListeners.Add(item);
        return true;
    }

    public bool RegisterTurnTimerUpdateListener(TurnTimerUpdateCallback callback)
    {
        return this.RegisterTurnTimerUpdateListener(callback, null);
    }

    public bool RegisterTurnTimerUpdateListener(TurnTimerUpdateCallback callback, object userData)
    {
        TurnTimerUpdateListener item = new TurnTimerUpdateListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_turnTimerUpdateListeners.Contains(item))
        {
            return false;
        }
        this.m_turnTimerUpdateListeners.Add(item);
        return true;
    }

    public void ReleaseAttackSpellController(AttackSpellController spell)
    {
        if (this.m_attackSpellControllerPool != null)
        {
            this.m_attackSpellControllerPool.Release(spell);
        }
    }

    public void ReleaseDeathSpellController(DeathSpellController controller)
    {
        if (this.m_deathSpellControllerPool != null)
        {
            this.m_deathSpellControllerPool.Release(controller);
        }
    }

    public void ReleaseFatigueSpellController(FatigueSpellController spell)
    {
        if (this.m_fatigueSpellControllerPool != null)
        {
            this.m_fatigueSpellControllerPool.Release(spell);
        }
    }

    public void ReleasePlaySpellController(PowerSpellController spell)
    {
        if (this.m_powerSpellControllerPool != null)
        {
            this.m_powerSpellControllerPool.Release(spell);
        }
    }

    public void ReleaseSecretSpellController(SecretSpellController spell)
    {
        if (this.m_secretSpellControllerPool != null)
        {
            this.m_secretSpellControllerPool.Release(spell);
        }
    }

    public void ReleaseTriggerSpellController(TriggerSpellController spell)
    {
        if (this.m_triggerSpellControllerPool != null)
        {
            this.m_triggerSpellControllerPool.Release(spell);
        }
    }

    public bool RemoveChosenEntity(Entity entity)
    {
        if (!this.m_chosenEntities.Remove(entity))
        {
            return false;
        }
        Card card = entity.GetCard();
        if (card != null)
        {
            card.UpdateActorState();
        }
        return true;
    }

    public void RemoveEntity(Entity entity)
    {
        if (entity.IsPlayer())
        {
            this.RemovePlayer(entity as Player);
        }
        else if (entity.IsGame())
        {
            this.m_gameEntity = null;
        }
        else
        {
            if (entity.IsAttached())
            {
                Entity entity2 = this.GetEntity(entity.GetAttached());
                if (entity2 != null)
                {
                    entity2.RemoveAttachment(entity);
                }
            }
            if (entity.IsHero())
            {
                Player player = this.GetPlayer(entity.GetControllerId());
                if (player != null)
                {
                    player.SetHero(null);
                }
            }
            else if (entity.IsHeroPower())
            {
                Player player2 = this.GetPlayer(entity.GetControllerId());
                if (player2 != null)
                {
                    player2.SetHeroPower(null);
                }
            }
            entity.Destroy();
        }
    }

    public void RemovePlayer(Player player)
    {
        player.Destroy();
        this.m_playerMap.Remove(player.GetPlayerId());
        this.m_entityMap.Remove(player.GetEntityId());
    }

    public bool RemoveServerBlockingSpell(Spell spell)
    {
        return this.m_serverBlockingSpells.Remove(spell);
    }

    public bool RemoveServerBlockingSpellController(SpellController spellController)
    {
        return this.m_serverBlockingSpellControllers.Remove(spellController);
    }

    public void SendChosenEntities()
    {
        if (this.m_responseMode == ResponseMode.CHOICE)
        {
            List<int> picks = new List<int>();
            foreach (Entity entity in this.m_chosenEntities)
            {
                picks.Add(entity.GetEntityId());
            }
            Network.Get().SendChoices(this.m_choice.ID, picks);
            this.m_responseMode = ResponseMode.NONE;
            this.UpdateChoiceHighlights();
            this.m_chosenEntities.Clear();
            this.m_choice = null;
        }
    }

    public void SendOption()
    {
        Network.Get().SendOption(this.m_options.ID, this.m_selectedOption.m_main, this.m_selectedOption.m_target, this.m_selectedOption.m_sub, this.m_selectedOption.m_position);
        object[] args = new object[] { this.m_selectedOption.m_main, this.m_selectedOption.m_sub, this.m_selectedOption.m_target, this.m_selectedOption.m_position };
        Log.Power.Print("GameState.SendOption() - selectedOption={0} selectedSubOption={1} selectedTarget={2} selectedPosition={3}", args);
        this.CancelSelectedOptionProposedMana();
        this.OnSelectedOptionsSent();
    }

    public void SetAttackSpellControllerPrefab(AttackSpellController spellPrefab)
    {
        this.m_attackSpellControllerPrefab = spellPrefab;
        if (spellPrefab == null)
        {
            this.ClearSpellControllerPool<AttackSpellController>(ref this.m_attackSpellControllerPool);
        }
        else
        {
            this.CreateSpellControllerPool<AttackSpellController>(ref this.m_attackSpellControllerPool, new Pool<AttackSpellController>.CreateItemCallback(this.CreateAttackSpellController));
        }
    }

    public void SetMulliganPacketBlocker(bool bOn)
    {
        this.mulliganPacketBlock = bOn;
    }

    public void SetSecretSpellControllerPrefab(SecretSpellController spellPrefab)
    {
        this.m_secretSpellControllerPrefab = spellPrefab;
        if (spellPrefab == null)
        {
            this.ClearSpellControllerPool<SecretSpellController>(ref this.m_secretSpellControllerPool);
        }
        else
        {
            this.CreateSpellControllerPool<SecretSpellController>(ref this.m_secretSpellControllerPool, new Pool<SecretSpellController>.CreateItemCallback(this.CreateSecretSpellController));
        }
    }

    public void SetSelectedOption(int index)
    {
        this.m_selectedOption.m_main = index;
    }

    public void SetSelectedOptionPosition(int position)
    {
        this.m_selectedOption.m_position = position;
    }

    public void SetSelectedOptionTarget(int target)
    {
        this.m_selectedOption.m_target = target;
    }

    public void SetSelectedSubOption(int index)
    {
        this.m_selectedOption.m_sub = index;
    }

    public void ShowEnemyTauntMinions()
    {
        foreach (Card card in this.GetRemotePlayer().GetBattlefieldZone().GetCards())
        {
            if (card.GetEntity().HasTaunt() && !card.GetEntity().IsStealthed())
            {
                card.DoTauntNotification();
            }
        }
    }

    public static void Shutdown()
    {
        if (s_instance != null)
        {
            s_instance.Clear();
            s_instance = null;
        }
    }

    public bool SubEntityHasTargets(Entity subEntity)
    {
        return this.EntityHasTargets(subEntity, true);
    }

    public void ToggleTurnStartManager(bool activate)
    {
        this.turnStartManagerActive = activate;
    }

    private void TriggerTurnTimerUpdate(int turn, float secondsRemaining, float endTimestamp)
    {
        this.FireTurnTimerUpdateEvent(turn, secondsRemaining, endTimestamp);
        if (secondsRemaining <= float.Epsilon)
        {
            this.OnTimeout();
        }
    }

    public bool UnregisterChoiceReceivedListener(ChoiceReceivedCallback callback)
    {
        return this.UnregisterChoiceReceivedListener(callback, null);
    }

    public bool UnregisterChoiceReceivedListener(ChoiceReceivedCallback callback, object userData)
    {
        ChoiceReceivedListener item = new ChoiceReceivedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_choiceReceivedListeners.Remove(item);
    }

    public bool UnregisterCreateGameListener(CreateGameCallback callback)
    {
        return this.UnregisterCreateGameListener(callback, null);
    }

    public bool UnregisterCreateGameListener(CreateGameCallback callback, object userData)
    {
        CreateGameListener item = new CreateGameListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_createGameListeners.Remove(item);
    }

    public bool UnregisterMulliganTimerUpdateListener(MulliganTimerUpdateCallback callback)
    {
        return this.UnregisterMulliganTimerUpdateListener(callback, null);
    }

    public bool UnregisterMulliganTimerUpdateListener(MulliganTimerUpdateCallback callback, object userData)
    {
        MulliganTimerUpdateListener item = new MulliganTimerUpdateListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_mulliganTimerUpdateListeners.Remove(item);
    }

    public bool UnregisterOptionsReceivedListener(OptionsReceivedCallback callback)
    {
        return this.UnregisterOptionsReceivedListener(callback, null);
    }

    public bool UnregisterOptionsReceivedListener(OptionsReceivedCallback callback, object userData)
    {
        OptionsReceivedListener item = new OptionsReceivedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_optionsReceivedListeners.Remove(item);
    }

    public bool UnregisterTurnTimerUpdateListener(TurnTimerUpdateCallback callback)
    {
        return this.UnregisterTurnTimerUpdateListener(callback, null);
    }

    public bool UnregisterTurnTimerUpdateListener(TurnTimerUpdateCallback callback, object userData)
    {
        TurnTimerUpdateListener item = new TurnTimerUpdateListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_turnTimerUpdateListeners.Remove(item);
    }

    public void Update()
    {
        if (!this.IsBlockingServer())
        {
            this.m_powerProcessor.ProcessPowerQueue();
        }
    }

    private void UpdateChoiceHighlights()
    {
        Entity entity = this.GetEntity(this.m_choice.Source);
        if (entity != null)
        {
            Card card = entity.GetCard();
            if (card != null)
            {
                card.UpdateActorState();
            }
        }
        foreach (int num in this.m_choice.Entities)
        {
            Entity entity2 = this.GetEntity(num);
            if (entity2 != null)
            {
                Card card2 = entity2.GetCard();
                if (card2 != null)
                {
                    card2.UpdateActorState();
                }
            }
        }
        foreach (Entity entity3 in this.m_chosenEntities)
        {
            Card card3 = entity3.GetCard();
            if (card3 != null)
            {
                card3.UpdateActorState();
            }
        }
    }

    private void UpdateHighlightsBasedOnSelection()
    {
        if (this.m_selectedOption.m_target != 0)
        {
            Network.Options.Option.SubOption selectedNetworkSubOption = this.GetSelectedNetworkSubOption();
            this.UpdateTargetHighlights(selectedNetworkSubOption);
        }
        else if (this.m_selectedOption.m_sub >= 0)
        {
            Network.Options.Option selectedNetworkOption = this.GetSelectedNetworkOption();
            this.UpdateSubOptionHighlights(selectedNetworkOption);
        }
        else
        {
            this.UpdateOptionHighlights();
        }
    }

    private void UpdateOptionHighlights()
    {
        if ((this.m_options != null) && (this.m_options.List != null))
        {
            for (int i = 0; i < this.m_options.List.Count; i++)
            {
                Network.Options.Option option = this.m_options.List[i];
                if (option.Type == Network.Options.Option.OptionType.POWER)
                {
                    Entity entity = this.GetEntity(option.Main.ID);
                    if (entity != null)
                    {
                        Card card = entity.GetCard();
                        if (card != null)
                        {
                            card.UpdateActorState();
                        }
                    }
                }
            }
        }
    }

    private void UpdateSubOptionHighlights(Network.Options.Option option)
    {
        Entity entity = this.GetEntity(option.Main.ID);
        if (entity != null)
        {
            Card card = entity.GetCard();
            if (card != null)
            {
                card.UpdateActorState();
            }
        }
        foreach (Network.Options.Option.SubOption option2 in option.Subs)
        {
            Entity entity2 = this.GetEntity(option2.ID);
            if (entity2 != null)
            {
                Card card2 = entity2.GetCard();
                if (card2 != null)
                {
                    card2.UpdateActorState();
                }
            }
        }
    }

    private void UpdateTargetHighlights(Network.Options.Option.SubOption subOption)
    {
        Entity entity = this.GetEntity(subOption.ID);
        if (entity != null)
        {
            Card card = entity.GetCard();
            if (card != null)
            {
                card.UpdateActorState();
            }
        }
        foreach (int num in subOption.Targets)
        {
            Entity entity2 = this.GetEntity(num);
            if (entity2 != null)
            {
                Card card2 = entity2.GetCard();
                if (card2 != null)
                {
                    card2.UpdateActorState();
                }
            }
        }
    }

    public bool WasGameCreated()
    {
        return (this.m_gameEntity != null);
    }

    public delegate void ChoiceReceivedCallback(object userData);

    private class ChoiceReceivedListener : EventListener<GameState.ChoiceReceivedCallback>
    {
        public void Fire()
        {
            base.m_callback(base.m_userData);
        }
    }

    public delegate void CreateGameCallback(object userData);

    private class CreateGameListener : EventListener<GameState.CreateGameCallback>
    {
        public void Fire()
        {
            base.m_callback(base.m_userData);
        }
    }

    public delegate void MulliganTimerUpdateCallback(int turn, float secondsRemaining, float endTimestamp, object userData);

    private class MulliganTimerUpdateListener : EventListener<GameState.MulliganTimerUpdateCallback>
    {
        public void Fire(int turn, float secondsRemaining, float endTimestamp)
        {
            base.m_callback(turn, secondsRemaining, endTimestamp, base.m_userData);
        }
    }

    public delegate void OptionsReceivedCallback(object userData);

    private class OptionsReceivedListener : EventListener<GameState.OptionsReceivedCallback>
    {
        public void Fire()
        {
            base.m_callback(base.m_userData);
        }
    }

    public enum ResponseMode
    {
        NONE,
        OPTION,
        SUB_OPTION,
        OPTION_TARGET,
        CHOICE
    }

    private class SelectedOption
    {
        public int m_main = -1;
        public int m_position = Network.NoPosition;
        public int m_sub = Network.NoSubOption;
        public int m_target;

        public void Clear()
        {
            this.m_main = -1;
            this.m_sub = Network.NoSubOption;
            this.m_target = 0;
            this.m_position = Network.NoPosition;
        }

        public void CopyFrom(GameState.SelectedOption original)
        {
            this.m_main = original.m_main;
            this.m_sub = original.m_sub;
            this.m_target = original.m_target;
            this.m_position = original.m_position;
        }
    }

    public delegate void TurnTimerUpdateCallback(int turn, float secondsRemaining, float endTimestamp, object userData);

    private class TurnTimerUpdateListener : EventListener<GameState.TurnTimerUpdateCallback>
    {
        public void Fire(int turn, float secondsRemaining, float endTimestamp)
        {
            base.m_callback(turn, secondsRemaining, endTimestamp, base.m_userData);
        }
    }
}

