using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayErrors
{
    private static DelGetPlayEntityError DLL_GetPlayEntityError;
    private static DelGetRequirementsMap DLL_GetRequirementsMap;
    private static DelGetTargetEntityError DLL_GetTargetEntityError;
    private static DelPlayErrorsInit DLL_PlayErrorsInit;
    public const string PLAYERRORS_DLL_FILENAME = "PlayErrors32";
    private static bool PLAYERRORS_ENABLED = true;
    private static IntPtr s_DLL = IntPtr.Zero;
    private static bool s_playErrorsInitialized = false;
    private static Dictionary<ErrorType, string> s_playErrorsMessages;
    private static bool USE_DLL_UTILS = true;

    static PlayErrors()
    {
        Dictionary<ErrorType, string> dictionary = new Dictionary<ErrorType, string>();
        dictionary.Add(ErrorType.REQ_MINION_TARGET, "GAMEPLAY_PlayErrors_REQ_MINION_TARGET");
        dictionary.Add(ErrorType.REQ_FRIENDLY_TARGET, "GAMEPLAY_PlayErrors_REQ_FRIENDLY_TARGET");
        dictionary.Add(ErrorType.REQ_ENEMY_TARGET, "GAMEPLAY_PlayErrors_REQ_ENEMY_TARGET");
        dictionary.Add(ErrorType.REQ_DAMAGED_TARGET, "GAMEPLAY_PlayErrors_REQ_DAMAGED_TARGET");
        dictionary.Add(ErrorType.REQ_ENCHANTED_TARGET, "GAMEPLAY_PlayErrors_REQ_ENCHANTED_TARGET");
        dictionary.Add(ErrorType.REQ_FROZEN_TARGET, "GAMEPLAY_PlayErrors_REQ_FROZEN_TARGET");
        dictionary.Add(ErrorType.REQ_CHARGE_TARGET, "GAMEPLAY_PlayErrors_REQ_CHARGE_TARGET");
        dictionary.Add(ErrorType.REQ_TARGET_MAX_ATTACK, "GAMEPLAY_PlayErrors_REQ_TARGET_MAX_ATTACK");
        dictionary.Add(ErrorType.REQ_NONSELF_TARGET, "GAMEPLAY_PlayErrors_REQ_NONSELF_TARGET");
        dictionary.Add(ErrorType.REQ_TARGET_WITH_RACE, "GAMEPLAY_PlayErrors_REQ_TARGET_WITH_RACE");
        dictionary.Add(ErrorType.REQ_TARGET_TO_PLAY, "GAMEPLAY_PlayErrors_REQ_TARGET_TO_PLAY");
        dictionary.Add(ErrorType.REQ_NUM_MINION_SLOTS, "GAMEPLAY_PlayErrors_REQ_NUM_MINION_SLOTS");
        dictionary.Add(ErrorType.REQ_WEAPON_EQUIPPED, "GAMEPLAY_PlayErrors_REQ_WEAPON_EQUIPPED");
        dictionary.Add(ErrorType.REQ_ENOUGH_MANA, "GAMEPLAY_PlayErrors_REQ_ENOUGH_MANA");
        dictionary.Add(ErrorType.REQ_YOUR_TURN, "GAMEPLAY_PlayErrors_REQ_YOUR_TURN");
        dictionary.Add(ErrorType.REQ_NONSTEALTH_ENEMY_TARGET, "GAMEPLAY_PlayErrors_REQ_NONSTEALTH_ENEMY_TARGET");
        dictionary.Add(ErrorType.REQ_HERO_TARGET, "GAMEPLAY_PlayErrors_REQ_HERO_TARGET");
        dictionary.Add(ErrorType.REQ_SECRET_CAP, "GAMEPLAY_PlayErrors_REQ_SECRET_CAP");
        dictionary.Add(ErrorType.REQ_MINION_CAP_IF_TARGET_AVAILABLE, "GAMEPLAY_PlayErrors_REQ_MINION_CAP_IF_TARGET_AVAILABLE");
        dictionary.Add(ErrorType.REQ_MINION_CAP, "GAMEPLAY_PlayErrors_REQ_MINION_CAP");
        dictionary.Add(ErrorType.REQ_TARGET_ATTACKED_THIS_TURN, "GAMEPLAY_PlayErrors_REQ_TARGET_ATTACKED_THIS_TURN");
        dictionary.Add(ErrorType.REQ_TARGET_IF_AVAILABLE, "GAMEPLAY_PlayErrors_REQ_TARGET_IF_AVAILABLE");
        dictionary.Add(ErrorType.REQ_MINIMUM_ENEMY_MINIONS, "GAMEPLAY_PlayErrors_REQ_MINIMUM_ENEMY_MINIONS");
        dictionary.Add(ErrorType.REQ_TARGET_FOR_COMBO, "GAMEPLAY_PlayErrors_REQ_TARGET_FOR_COMBO");
        dictionary.Add(ErrorType.REQ_NOT_EXHAUSTED_ACTIVATE, "GAMEPLAY_PlayErrors_REQ_NOT_EXHAUSTED_ACTIVATE");
        dictionary.Add(ErrorType.REQ_UNIQUE_SECRET, "GAMEPLAY_PlayErrors_REQ_UNIQUE_SECRET");
        dictionary.Add(ErrorType.REQ_TARGET_TAUNTER, "GAMEPLAY_PlayErrors_REQ_TARGET_TAUNTER");
        dictionary.Add(ErrorType.REQ_CAN_BE_ATTACKED, "GAMEPLAY_PlayErrors_REQ_CAN_BE_ATTACKED");
        dictionary.Add(ErrorType.REQ_TARGET_MAGNET, "GAMEPLAY_PlayErrors_REQ_TARGET_MAGNET");
        dictionary.Add(ErrorType.REQ_ATTACK_GREATER_THAN_0, "GAMEPLAY_PlayErrors_REQ_ATTACK_GREATER_THAN_0");
        dictionary.Add(ErrorType.REQ_ATTACKER_NOT_FROZEN, "GAMEPLAY_PlayErrors_REQ_ATTACKER_NOT_FROZEN");
        dictionary.Add(ErrorType.REQ_HERO_OR_MINION_TARGET, "GAMEPLAY_PlayErrors_REQ_HERO_OR_MINION_TARGET");
        dictionary.Add(ErrorType.REQ_CAN_BE_TARGETED_BY_SPELLS, "GAMEPLAY_PlayErrors_REQ_CAN_BE_TARGETED_BY_SPELLS");
        dictionary.Add(ErrorType.REQ_SUBCARD_IS_PLAYABLE, "GAMEPLAY_PlayErrors_REQ_SUBCARD_IS_PLAYABLE");
        dictionary.Add(ErrorType.REQ_TARGET_FOR_NO_COMBO, "GAMEPLAY_PlayErrors_REQ_TARGET_FOR_NO_COMBO");
        dictionary.Add(ErrorType.REQ_NOT_MINION_JUST_PLAYED, "GAMEPLAY_PlayErrors_REQ_NOT_MINION_JUST_PLAYED");
        dictionary.Add(ErrorType.REQ_NOT_EXHAUSTED_HERO_POWER, "GAMEPLAY_PlayErrors_REQ_NOT_EXHAUSTED_HERO_POWER");
        dictionary.Add(ErrorType.REQ_CAN_BE_TARGETED_BY_OPPONENTS, "GAMEPLAY_PlayErrors_REQ_CAN_BE_TARGETED_BY_OPPONENTS");
        dictionary.Add(ErrorType.REQ_ATTACKER_CAN_ATTACK, "GAMEPLAY_PlayErrors_REQ_ATTACKER_CAN_ATTACK");
        dictionary.Add(ErrorType.REQ_TARGET_MIN_ATTACK, "GAMEPLAY_PlayErrors_REQ_TARGET_MIN_ATTACK");
        dictionary.Add(ErrorType.REQ_CAN_BE_TARGETED_BY_HERO_POWERS, "GAMEPLAY_PlayErrors_REQ_CAN_BE_TARGETED_BY_HERO_POWERS");
        dictionary.Add(ErrorType.REQ_ENEMY_TARGET_NOT_IMMUNE, "GAMEPLAY_PlayErrors_REQ_ENEMY_TARGET_NOT_IMMUNE");
        dictionary.Add(ErrorType.REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY, "GAMEPLAY_PlayErrors_REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY");
        dictionary.Add(ErrorType.REQ_MINIMUM_TOTAL_MINIONS, "GAMEPLAY_PlayErrors_REQ_MINIMUM_TOTAL_MINIONS");
        dictionary.Add(ErrorType.REQ_MUST_TARGET_TAUNTER, "GAMEPLAY_PlayErrors_REQ_MUST_TARGET_TAUNTER");
        s_playErrorsMessages = dictionary;
    }

    public static void AppQuit()
    {
        if ((PLAYERRORS_ENABLED && USE_DLL_UTILS) && (s_DLL != IntPtr.Zero))
        {
            if (!DLLUtils.FreeLibrary(s_DLL))
            {
                Debug.LogError(string.Format("error unloading {0}", "PlayErrors32"));
            }
            s_DLL = IntPtr.Zero;
        }
    }

    public static void DisplayNotification(Network.Notification notification)
    {
        string notificationDescription = GetNotificationDescription(notification);
        if (notification.NotificationType == Network.Notification.Type.IN_HAND_CARD_CAP)
        {
            GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_HAND_FULL);
        }
        if (!string.IsNullOrEmpty(notificationDescription))
        {
            GameplayErrorManager.Get().DisplayMessage(notificationDescription);
        }
    }

    public static void DisplayPlayError(ErrorType error, Entity errorSource)
    {
        if (!GameState.Get().GetGameEntity().NotifyOfPlayError(error, errorSource))
        {
            switch (error)
            {
                case ErrorType.REQ_MINION_TARGET:
                case ErrorType.REQ_FRIENDLY_TARGET:
                case ErrorType.REQ_ENEMY_TARGET:
                case ErrorType.REQ_DAMAGED_TARGET:
                case ErrorType.REQ_FROZEN_TARGET:
                case ErrorType.REQ_TARGET_MAX_ATTACK:
                case ErrorType.REQ_TARGET_WITH_RACE:
                case ErrorType.REQ_HERO_TARGET:
                case ErrorType.REQ_HERO_OR_MINION_TARGET:
                case ErrorType.REQ_CAN_BE_TARGETED_BY_SPELLS:
                case ErrorType.REQ_CAN_BE_TARGETED_BY_OPPONENTS:
                case ErrorType.REQ_TARGET_MIN_ATTACK:
                case ErrorType.REQ_CAN_BE_TARGETED_BY_HERO_POWERS:
                case ErrorType.REQ_ENEMY_TARGET_NOT_IMMUNE:
                    GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_TARGET);
                    break;

                case ErrorType.REQ_TARGET_TO_PLAY:
                case ErrorType.REQ_TARGET_IF_AVAILABLE:
                case ErrorType.REQ_TARGET_FOR_COMBO:
                case ErrorType.REQ_TARGET_FOR_NO_COMBO:
                    GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_PLAY);
                    break;

                case ErrorType.REQ_NUM_MINION_SLOTS:
                case ErrorType.REQ_MINION_CAP_IF_TARGET_AVAILABLE:
                case ErrorType.REQ_MINION_CAP:
                    GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_FULL_MINIONS);
                    break;

                case ErrorType.REQ_WEAPON_EQUIPPED:
                    GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_NEED_WEAPON);
                    break;

                case ErrorType.REQ_ENOUGH_MANA:
                    GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_NEED_MANA);
                    break;

                case ErrorType.REQ_NONSTEALTH_ENEMY_TARGET:
                    GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_STEALTH);
                    break;

                case ErrorType.REQ_NOT_EXHAUSTED_ACTIVATE:
                    if (!errorSource.IsHero())
                    {
                        GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_MINION_ATTACKED);
                    }
                    else
                    {
                        GameState.Get().GetCurrentPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_I_ATTACKED);
                    }
                    break;

                case ErrorType.REQ_TARGET_TAUNTER:
                    GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_TAUNT);
                    break;

                case ErrorType.REQ_NOT_MINION_JUST_PLAYED:
                    GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_JUST_PLAYED);
                    break;

                default:
                    GameState.Get().GetLocalPlayer().GetHeroCard().PlayEmote(EmoteType.ERROR_GENERIC);
                    break;
            }
            PlayRequirementInfo playRequirementInfo = GetPlayRequirementInfo(errorSource);
            string errorDescription = GetErrorDescription(error, playRequirementInfo);
            if (!string.IsNullOrEmpty(errorDescription))
            {
                GameplayErrorManager.Get().DisplayMessage(errorDescription);
            }
        }
    }

    private static string ErrorInEditorOnly(string format, params object[] args)
    {
        return string.Empty;
    }

    private static string GetErrorDescription(ErrorType type, PlayRequirementInfo requirementInfo)
    {
        ErrorType type2 = type;
        switch (type2)
        {
            case ErrorType.REQ_YOUR_TURN:
                return string.Empty;

            case ErrorType.REQ_SECRET_CAP:
            {
                object[] args = new object[] { GameState.Get().GetMaxSecretsPerPlayer() };
                return GameStrings.Format("GAMEPLAY_PlayErrors_REQ_SECRET_CAP", args);
            }
            case ErrorType.REQ_TARGET_MAX_ATTACK:
            {
                object[] objArray1 = new object[] { requirementInfo.paramMaxAtk };
                return GameStrings.Format("GAMEPLAY_PlayErrors_REQ_TARGET_MAX_ATTACK", objArray1);
            }
            case ErrorType.REQ_TARGET_WITH_RACE:
            {
                object[] objArray2 = new object[] { GameStrings.GetRaceName((TAG_RACE) requirementInfo.paramRace) };
                return GameStrings.Format("GAMEPLAY_PlayErrors_REQ_TARGET_WITH_RACE", objArray2);
            }
        }
        if (type2 != ErrorType.NONE)
        {
            if (type2 == ErrorType.REQ_MINIMUM_ENEMY_MINIONS)
            {
                object[] objArray4 = new object[] { requirementInfo.paramMinNumEnemyMinions };
                return GameStrings.Format("GAMEPLAY_PlayErrors_REQ_MINIMUM_ENEMY_MINIONS", objArray4);
            }
            if (type2 == ErrorType.REQ_ACTION_PWR_IS_MASTER_PWR)
            {
                return ErrorInEditorOnly("[Unity Editor] Action power must be master power", new object[0]);
            }
            if (type2 == ErrorType.REQ_TARGET_MIN_ATTACK)
            {
                object[] objArray5 = new object[] { requirementInfo.paramMinAtk };
                return GameStrings.Format("GAMEPLAY_PlayErrors_REQ_TARGET_MIN_ATTACK", objArray5);
            }
            if (type2 == ErrorType.REQ_MINIMUM_TOTAL_MINIONS)
            {
                object[] objArray6 = new object[] { requirementInfo.paramMinNumTotalMinions };
                return GameStrings.Format("GAMEPLAY_PlayErrors_REQ_MINIMUM_TOTAL_MINIONS", objArray6);
            }
            string str = null;
            if (s_playErrorsMessages.TryGetValue(type, out str))
            {
                return GameStrings.Get(str);
            }
            object[] objArray7 = new object[] { type };
            return ErrorInEditorOnly("[Unity Editor] Unknown play error ({0})", objArray7);
        }
        Debug.LogWarning("PlayErrors.GetErrorDescription() - Action is not valid, but no error string found.");
        return string.Empty;
    }

    private static IntPtr GetFunction(string name)
    {
        IntPtr procAddress = DLLUtils.GetProcAddress(s_DLL, name);
        if (procAddress == IntPtr.Zero)
        {
            Debug.LogError("Could not load PlayErrors." + name + "()");
            AppQuit();
        }
        return procAddress;
    }

    private static List<Marshaled_TargetEntityInfo> GetMarshaledEntitiesInPlay()
    {
        int entityId = -1;
        Card battlecrySourceCard = InputManager.Get().GetBattlecrySourceCard();
        if (battlecrySourceCard != null)
        {
            entityId = battlecrySourceCard.GetEntity().GetEntityId();
        }
        int num2 = -1;
        Card choiceParentCard = InputManager.Get().GetChoiceParentCard();
        if (choiceParentCard != null)
        {
            num2 = choiceParentCard.GetEntity().GetEntityId();
        }
        List<Marshaled_TargetEntityInfo> list = new List<Marshaled_TargetEntityInfo>();
        foreach (Zone zone in ZoneMgr.Get().GetZones())
        {
            if (zone.m_ServerTag == TAG_ZONE.PLAY)
            {
                foreach (Card card3 in zone.GetCards())
                {
                    Entity entity = card3.GetEntity();
                    if ((entity.GetEntityId() != entityId) && (entity.GetEntityId() != num2))
                    {
                        list.Add(Marshaled_TargetEntityInfo.ConvertFromTargetEntityInfo(entity.ConvertToTargetInfo()));
                    }
                }
                continue;
            }
        }
        return list;
    }

    private static List<Marshaled_SourceEntityInfo> GetMarshaledSubCards(Entity source)
    {
        List<Marshaled_SourceEntityInfo> list = new List<Marshaled_SourceEntityInfo>();
        foreach (int num in source.GetSubCardIDs())
        {
            Entity entity = GameState.Get().GetEntity(num);
            if (entity == null)
            {
                Log.Rachelle.Print(string.Format("Subcard of {0} is null in GetMarshaledSubCards()!", source.GetName()));
            }
            else
            {
                SourceEntityInfo sourceInfo = entity.ConvertToSourceInfo(Power.GetDefaultMasterPower().GetPlayRequirementInfo());
                list.Add(Marshaled_SourceEntityInfo.ConvertFromSourceEntityInfo(sourceInfo));
            }
        }
        return list;
    }

    private static string GetNotificationDescription(Network.Notification notification)
    {
        Network.Notification.Type notificationType = notification.NotificationType;
        if (notificationType != Network.Notification.Type.IN_HAND_CARD_CAP)
        {
            if (notificationType == Network.Notification.Type.MANA_CAP)
            {
                int num2 = GameState.Get().GetLocalPlayer().GetTag(GAME_TAG.MAXRESOURCES);
                object[] objArray2 = new object[] { num2 };
                return GameStrings.Format("GAMEPLAY_NOTIFICATION_MAX_MANA", objArray2);
            }
            object[] objArray3 = new object[] { notification.NotificationType };
            return ErrorInEditorOnly("[Unity Editor] Unknown notification ({0})!!!", objArray3);
        }
        int tag = GameState.Get().GetLocalPlayer().GetTag(GAME_TAG.MAXHANDSIZE);
        object[] args = new object[] { tag };
        return GameStrings.Format("GAMEPLAY_NOTIFICATION_MAX_HAND_SIZE", args);
    }

    private static Player GetOwningPlayer(Entity entity)
    {
        Player player = GameState.Get().GetPlayer(entity.GetControllerId());
        if (player == null)
        {
            Log.Rachelle.Print(string.Format("Error retrieving controlling player of entity {0} in PlayErrors.GetOwningPlayer()!", entity.GetName()));
        }
        return player;
    }

    public static ErrorType GetPlayEntityError(Entity source)
    {
        if (!PLAYERRORS_ENABLED)
        {
            return ErrorType.NONE;
        }
        Player owningPlayer = GetOwningPlayer(source);
        if (owningPlayer == null)
        {
            return ErrorType.NONE;
        }
        SourceEntityInfo sourceInfo = source.ConvertToSourceInfo(GetPlayRequirementInfo(source));
        PlayerInfo playerInfo = owningPlayer.ConvertToPlayerInfo();
        GameStateInfo gameInfo = GameState.Get().ConvertToGameStateInfo();
        Marshaled_PlayErrorsParams playErrorsParams = new Marshaled_PlayErrorsParams(sourceInfo, playerInfo, gameInfo);
        List<Marshaled_TargetEntityInfo> marshaledEntitiesInPlay = GetMarshaledEntitiesInPlay();
        List<Marshaled_SourceEntityInfo> marshaledSubCards = GetMarshaledSubCards(source);
        if (DLL_GetPlayEntityError == null)
        {
            return ErrorType.NONE;
        }
        return DLL_GetPlayEntityError(playErrorsParams, marshaledSubCards.ToArray(), marshaledSubCards.Count, marshaledEntitiesInPlay.ToArray(), marshaledEntitiesInPlay.Count);
    }

    [DllImport("__Internal")]
    private static extern ErrorType GetPlayEntityError(Marshaled_PlayErrorsParams playErrorsParams, Marshaled_SourceEntityInfo[] subCards, int numSubCards, Marshaled_TargetEntityInfo[] enititiesInPlay, int numEntitiesInPlay);
    private static PlayRequirementInfo GetPlayRequirementInfo(Entity entity)
    {
        if (entity.GetZone() == TAG_ZONE.HAND)
        {
            return entity.GetMasterPower().GetPlayRequirementInfo();
        }
        if (entity.GetZone() == TAG_ZONE.SETASIDE)
        {
            return entity.GetMasterPower().GetPlayRequirementInfo();
        }
        if (entity.IsHeroPower())
        {
            return entity.GetMasterPower().GetPlayRequirementInfo();
        }
        if (entity.ShouldUseBattlecryPower())
        {
            return entity.GetMasterPower().GetPlayRequirementInfo();
        }
        return entity.GetAttackPower().GetPlayRequirementInfo();
    }

    public static ulong GetRequirementsMap(List<ErrorType> requirements)
    {
        if (!PLAYERRORS_ENABLED)
        {
            return 0L;
        }
        if (DLL_GetRequirementsMap == null)
        {
            return 0L;
        }
        return DLL_GetRequirementsMap(requirements.ToArray(), requirements.Count);
    }

    [DllImport("__Internal")]
    private static extern ulong GetRequirementsMap(ErrorType[] requirements, int numRequirements);
    public static ErrorType GetTargetEntityError(Entity source, Entity target)
    {
        if (!PLAYERRORS_ENABLED)
        {
            return ErrorType.NONE;
        }
        Player owningPlayer = GetOwningPlayer(source);
        if (owningPlayer == null)
        {
            return ErrorType.NONE;
        }
        SourceEntityInfo sourceInfo = source.ConvertToSourceInfo(GetPlayRequirementInfo(source));
        PlayerInfo playerInfo = owningPlayer.ConvertToPlayerInfo();
        GameStateInfo gameInfo = GameState.Get().ConvertToGameStateInfo();
        Marshaled_PlayErrorsParams playErrorsParams = new Marshaled_PlayErrorsParams(sourceInfo, playerInfo, gameInfo);
        Marshaled_TargetEntityInfo info4 = Marshaled_TargetEntityInfo.ConvertFromTargetEntityInfo(target.ConvertToTargetInfo());
        List<Marshaled_TargetEntityInfo> marshaledEntitiesInPlay = GetMarshaledEntitiesInPlay();
        return DLL_GetTargetEntityError(playErrorsParams, info4, marshaledEntitiesInPlay.ToArray(), marshaledEntitiesInPlay.Count);
    }

    [DllImport("__Internal")]
    private static extern ErrorType GetTargetEntityError(Marshaled_PlayErrorsParams playErrorsParams, Marshaled_TargetEntityInfo target, Marshaled_TargetEntityInfo[] entitiesInPlay, int numEntitiesInPlay);
    public static bool Init()
    {
        if (!PLAYERRORS_ENABLED)
        {
            return true;
        }
        if (s_playErrorsInitialized)
        {
            return true;
        }
        if ((s_DLL == IntPtr.Zero) && !LoadPlayErrorsDLL())
        {
            return false;
        }
        s_playErrorsInitialized = DLL_PlayErrorsInit();
        Log.Rachelle.Print("PlayErrorsInit " + s_playErrorsInitialized);
        return s_playErrorsInitialized;
    }

    private static bool LoadPlayErrorsDLL()
    {
        if (USE_DLL_UTILS)
        {
            s_DLL = FileUtils.LoadPlugin("PlayErrors32");
            if (s_DLL == IntPtr.Zero)
            {
                return false;
            }
            DLL_PlayErrorsInit = (DelPlayErrorsInit) Marshal.GetDelegateForFunctionPointer(GetFunction("PlayErrorsInit"), typeof(DelPlayErrorsInit));
            DLL_GetRequirementsMap = (DelGetRequirementsMap) Marshal.GetDelegateForFunctionPointer(GetFunction("GetRequirementsMap"), typeof(DelGetRequirementsMap));
            DLL_GetPlayEntityError = (DelGetPlayEntityError) Marshal.GetDelegateForFunctionPointer(GetFunction("GetPlayEntityError"), typeof(DelGetPlayEntityError));
            DLL_GetTargetEntityError = (DelGetTargetEntityError) Marshal.GetDelegateForFunctionPointer(GetFunction("GetTargetEntityError"), typeof(DelGetTargetEntityError));
            return (s_DLL != IntPtr.Zero);
        }
        DLL_PlayErrorsInit = new DelPlayErrorsInit(PlayErrors.PlayErrorsInit);
        DLL_GetRequirementsMap = new DelGetRequirementsMap(PlayErrors.GetRequirementsMap);
        DLL_GetPlayEntityError = new DelGetPlayEntityError(PlayErrors.GetPlayEntityError);
        DLL_GetTargetEntityError = new DelGetTargetEntityError(PlayErrors.GetTargetEntityError);
        return true;
    }

    [DllImport("__Internal")]
    private static extern bool PlayErrorsInit();
    public static bool PlayErrorsInitialized()
    {
        return (!PLAYERRORS_ENABLED || s_playErrorsInitialized);
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate PlayErrors.ErrorType DelGetPlayEntityError(PlayErrors.Marshaled_PlayErrorsParams playErrorsParams, PlayErrors.Marshaled_SourceEntityInfo[] subCards, int numSubCards, PlayErrors.Marshaled_TargetEntityInfo[] enititiesInPlay, int numEntitiesInPlay);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate ulong DelGetRequirementsMap(PlayErrors.ErrorType[] requirements, int numRequirements);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate PlayErrors.ErrorType DelGetTargetEntityError(PlayErrors.Marshaled_PlayErrorsParams playErrorsParams, PlayErrors.Marshaled_TargetEntityInfo target, PlayErrors.Marshaled_TargetEntityInfo[] entitiesInPlay, int numEntitiesInPlay);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate bool DelPlayErrorsInit();

    public enum ErrorType
    {
        NONE,
        REQ_MINION_TARGET,
        REQ_FRIENDLY_TARGET,
        REQ_ENEMY_TARGET,
        REQ_DAMAGED_TARGET,
        REQ_ENCHANTED_TARGET,
        REQ_FROZEN_TARGET,
        REQ_CHARGE_TARGET,
        REQ_TARGET_MAX_ATTACK,
        REQ_NONSELF_TARGET,
        REQ_TARGET_WITH_RACE,
        REQ_TARGET_TO_PLAY,
        REQ_NUM_MINION_SLOTS,
        REQ_WEAPON_EQUIPPED,
        REQ_ENOUGH_MANA,
        REQ_YOUR_TURN,
        REQ_NONSTEALTH_ENEMY_TARGET,
        REQ_HERO_TARGET,
        REQ_SECRET_CAP,
        REQ_MINION_CAP_IF_TARGET_AVAILABLE,
        REQ_MINION_CAP,
        REQ_TARGET_ATTACKED_THIS_TURN,
        REQ_TARGET_IF_AVAILABLE,
        REQ_MINIMUM_ENEMY_MINIONS,
        REQ_TARGET_FOR_COMBO,
        REQ_NOT_EXHAUSTED_ACTIVATE,
        REQ_UNIQUE_SECRET,
        REQ_TARGET_TAUNTER,
        REQ_CAN_BE_ATTACKED,
        REQ_ACTION_PWR_IS_MASTER_PWR,
        REQ_TARGET_MAGNET,
        REQ_ATTACK_GREATER_THAN_0,
        REQ_ATTACKER_NOT_FROZEN,
        REQ_HERO_OR_MINION_TARGET,
        REQ_CAN_BE_TARGETED_BY_SPELLS,
        REQ_SUBCARD_IS_PLAYABLE,
        REQ_TARGET_FOR_NO_COMBO,
        REQ_NOT_MINION_JUST_PLAYED,
        REQ_NOT_EXHAUSTED_HERO_POWER,
        REQ_CAN_BE_TARGETED_BY_OPPONENTS,
        REQ_ATTACKER_CAN_ATTACK,
        REQ_TARGET_MIN_ATTACK,
        REQ_CAN_BE_TARGETED_BY_HERO_POWERS,
        REQ_ENEMY_TARGET_NOT_IMMUNE,
        REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY,
        REQ_MINIMUM_TOTAL_MINIONS,
        REQ_MUST_TARGET_TAUNTER
    }

    public class GameStateInfo
    {
        public TAG_STEP currentStep = TAG_STEP.MAIN_BEGIN;
    }

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    private struct Marshaled_GameStateInfo
    {
        [MarshalAs(UnmanagedType.U4)]
        public TAG_STEP currentStep;
        public static PlayErrors.Marshaled_GameStateInfo ConvertFromGameStateInfo(PlayErrors.GameStateInfo gameInfo)
        {
            return new PlayErrors.Marshaled_GameStateInfo { currentStep = gameInfo.currentStep };
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    private struct Marshaled_PlayerInfo
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool isCurrentPlayer;
        public int id;
        public int numResources;
        [MarshalAs(UnmanagedType.U1)]
        public bool weaponEquipped;
        [MarshalAs(UnmanagedType.U1)]
        public bool comboActive;
        public int numTotalMinionsInPlay;
        public int numEnemyMinionsInPlay;
        public int numOpenFriendlyMinionSlots;
        public int numOpenSecretSlots;
        public static PlayErrors.Marshaled_PlayerInfo ConvertFromPlayerInfo(PlayErrors.PlayerInfo playerInfo)
        {
            return new PlayErrors.Marshaled_PlayerInfo { isCurrentPlayer = playerInfo.isCurrentPlayer, id = playerInfo.id, numResources = playerInfo.numResources, weaponEquipped = playerInfo.weaponEquipped, comboActive = playerInfo.comboActive, numTotalMinionsInPlay = playerInfo.numTotalMinionsInPlay, numEnemyMinionsInPlay = playerInfo.numEnemyMinionsInPlay, numOpenFriendlyMinionSlots = playerInfo.numOpenFriendlyMinionSlots, numOpenSecretSlots = playerInfo.numOpenSecretSlots };
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    private struct Marshaled_PlayErrorsParams
    {
        [MarshalAs(UnmanagedType.Struct)]
        public PlayErrors.Marshaled_SourceEntityInfo source;
        [MarshalAs(UnmanagedType.Struct)]
        public PlayErrors.Marshaled_PlayerInfo player;
        [MarshalAs(UnmanagedType.U4)]
        public PlayErrors.Marshaled_GameStateInfo game;
        public Marshaled_PlayErrorsParams(PlayErrors.SourceEntityInfo sourceInfo, PlayErrors.PlayerInfo playerInfo, PlayErrors.GameStateInfo gameInfo)
        {
            this.source = PlayErrors.Marshaled_SourceEntityInfo.ConvertFromSourceEntityInfo(sourceInfo);
            this.player = PlayErrors.Marshaled_PlayerInfo.ConvertFromPlayerInfo(playerInfo);
            this.game = PlayErrors.Marshaled_GameStateInfo.ConvertFromGameStateInfo(gameInfo);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    private struct Marshaled_SourceEntityInfo
    {
        public int id;
        public int cost;
        public int attack;
        public int minAttackRequirement;
        public int maxAttackRequirement;
        public int raceRequirement;
        public int numMinionSlotsRequirement;
        public int numMinionSlotsWithTargetRequirement;
        public int minTotalMinionsRequirement;
        public int minEnemyMinionsRequirement;
        public int numTurnsInPlay;
        public int numAttacksThisTurn;
        [MarshalAs(UnmanagedType.U4)]
        public TAG_CARDTYPE cardType;
        [MarshalAs(UnmanagedType.U4)]
        public TAG_ZONE zone;
        [MarshalAs(UnmanagedType.U1)]
        public bool isSecret;
        [MarshalAs(UnmanagedType.U1)]
        public bool isDuplicateSecret;
        [MarshalAs(UnmanagedType.U1)]
        public bool isExhausted;
        [MarshalAs(UnmanagedType.U1)]
        public bool isMasterPower;
        [MarshalAs(UnmanagedType.U1)]
        public bool isActionPower;
        [MarshalAs(UnmanagedType.U1)]
        public bool isActivatePower;
        [MarshalAs(UnmanagedType.U1)]
        public bool isAttackPower;
        [MarshalAs(UnmanagedType.U1)]
        public bool isFrozen;
        [MarshalAs(UnmanagedType.U1)]
        public bool canAttack;
        [MarshalAs(UnmanagedType.U1)]
        public bool entireEntourageInPlay;
        [MarshalAs(UnmanagedType.U1)]
        public bool hasCharge;
        [MarshalAs(UnmanagedType.U1)]
        public bool hasWindfury;
        public ulong requirementsMap;
        public static PlayErrors.Marshaled_SourceEntityInfo ConvertFromSourceEntityInfo(PlayErrors.SourceEntityInfo sourceInfo)
        {
            return new PlayErrors.Marshaled_SourceEntityInfo { 
                id = sourceInfo.id, cost = sourceInfo.cost, attack = sourceInfo.attack, minAttackRequirement = sourceInfo.minAttackRequirement, maxAttackRequirement = sourceInfo.maxAttackRequirement, raceRequirement = sourceInfo.raceRequirement, numMinionSlotsRequirement = sourceInfo.numMinionSlotsRequirement, numMinionSlotsWithTargetRequirement = sourceInfo.numMinionSlotsWithTargetRequirement, minTotalMinionsRequirement = sourceInfo.minTotalMinionsRequirement, minEnemyMinionsRequirement = sourceInfo.minEnemyMinionsRequirement, numTurnsInPlay = sourceInfo.numTurnsInPlay, numAttacksThisTurn = sourceInfo.numAttacksThisTurn, cardType = sourceInfo.cardType, zone = sourceInfo.zone, isSecret = sourceInfo.isSecret, isDuplicateSecret = sourceInfo.isDuplicateSecret, 
                isExhausted = sourceInfo.isExhausted, isMasterPower = sourceInfo.isMasterPower, isActionPower = sourceInfo.isActionPower, isActivatePower = sourceInfo.isActivatePower, isAttackPower = sourceInfo.isAttackPower, isFrozen = sourceInfo.isFrozen, canAttack = sourceInfo.canAttack, entireEntourageInPlay = sourceInfo.entireEntourageInPlay, hasCharge = sourceInfo.hasCharge, hasWindfury = sourceInfo.hasWindfury, requirementsMap = sourceInfo.requirementsMap
             };
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    private struct Marshaled_TargetEntityInfo
    {
        public int id;
        public int owningPlayerID;
        public int damage;
        public int attack;
        public int race;
        [MarshalAs(UnmanagedType.U4)]
        public TAG_CARDTYPE cardType;
        [MarshalAs(UnmanagedType.U1)]
        public bool isImmune;
        [MarshalAs(UnmanagedType.U1)]
        public bool canBeAttacked;
        [MarshalAs(UnmanagedType.U1)]
        public bool canBeTargetedByOpponents;
        [MarshalAs(UnmanagedType.U1)]
        public bool canBeTargetedBySpells;
        [MarshalAs(UnmanagedType.U1)]
        public bool canBeTargetedByHeroPowers;
        [MarshalAs(UnmanagedType.U1)]
        public bool isFrozen;
        [MarshalAs(UnmanagedType.U1)]
        public bool isEnchanted;
        [MarshalAs(UnmanagedType.U1)]
        public bool isStealthed;
        [MarshalAs(UnmanagedType.U1)]
        public bool isTaunter;
        [MarshalAs(UnmanagedType.U1)]
        public bool isMagnet;
        [MarshalAs(UnmanagedType.U1)]
        public bool hasCharge;
        [MarshalAs(UnmanagedType.U1)]
        public bool hasAttackedThisTurn;
        public static PlayErrors.Marshaled_TargetEntityInfo ConvertFromTargetEntityInfo(PlayErrors.TargetEntityInfo targetInfo)
        {
            return new PlayErrors.Marshaled_TargetEntityInfo { 
                id = targetInfo.id, owningPlayerID = targetInfo.owningPlayerID, damage = targetInfo.damage, attack = targetInfo.attack, cardType = targetInfo.cardType, race = targetInfo.race, isImmune = targetInfo.isImmune, canBeAttacked = targetInfo.canBeAttacked, canBeTargetedByOpponents = targetInfo.canBeTargetedByOpponents, canBeTargetedBySpells = targetInfo.canBeTargetedBySpells, canBeTargetedByHeroPowers = targetInfo.canBeTargetedByHeroPowers, isFrozen = targetInfo.isFrozen, isEnchanted = targetInfo.isEnchanted, isStealthed = targetInfo.isStealthed, isTaunter = targetInfo.isTaunter, isMagnet = targetInfo.isMagnet, 
                hasCharge = targetInfo.hasCharge, hasAttackedThisTurn = targetInfo.hasAttackedThisTurn
             };
        }
    }

    public class PlayerInfo
    {
        public bool comboActive = false;
        public int id = 0;
        public bool isCurrentPlayer = false;
        public int numEnemyMinionsInPlay = 0;
        public int numOpenFriendlyMinionSlots = 0;
        public int numOpenSecretSlots = 0;
        public int numResources = 0;
        public int numTotalMinionsInPlay = 0;
        public bool weaponEquipped = false;
    }

    public class PlayRequirementInfo
    {
        public int paramMaxAtk = 0;
        public int paramMinAtk = 0;
        public int paramMinNumEnemyMinions = 0;
        public int paramMinNumTotalMinions = 0;
        public int paramNumMinionSlots = 0;
        public int paramNumMinionSlotsWithTarget = 0;
        public int paramRace = 0;
        public ulong requirementsMap = 0L;
    }

    public class SourceEntityInfo
    {
        public int attack = 0;
        public bool canAttack = true;
        public TAG_CARDTYPE cardType = TAG_CARDTYPE.MINION;
        public int cost = 0;
        public bool entireEntourageInPlay = false;
        public bool hasCharge = false;
        public bool hasWindfury = false;
        public int id = 0;
        public bool isActionPower = false;
        public bool isActivatePower = false;
        public bool isAttackPower = false;
        public bool isDuplicateSecret = false;
        public bool isExhausted = false;
        public bool isFrozen = false;
        public bool isMasterPower = false;
        public bool isSecret = false;
        public int maxAttackRequirement = 0;
        public int minAttackRequirement = 0;
        public int minEnemyMinionsRequirement = 0;
        public int minTotalMinionsRequirement = 0;
        public int numAttacksThisTurn = 0;
        public int numMinionSlotsRequirement = 0;
        public int numMinionSlotsWithTargetRequirement = 0;
        public int numTurnsInPlay = 0;
        public int raceRequirement = 0;
        public ulong requirementsMap = 0L;
        public TAG_ZONE zone = TAG_ZONE.SETASIDE;
    }

    public class TargetEntityInfo
    {
        public int attack = 0;
        public bool canBeAttacked = true;
        public bool canBeTargetedByHeroPowers = true;
        public bool canBeTargetedByOpponents = true;
        public bool canBeTargetedBySpells = true;
        public TAG_CARDTYPE cardType = TAG_CARDTYPE.MINION;
        public int damage = 0;
        public bool hasAttackedThisTurn = false;
        public bool hasCharge = false;
        public int id = 0;
        public bool isEnchanted = false;
        public bool isFrozen = false;
        public bool isImmune = false;
        public bool isMagnet = false;
        public bool isStealthed = false;
        public bool isTaunter = false;
        public int owningPlayerID = 0;
        public int race = 0;
    }
}

