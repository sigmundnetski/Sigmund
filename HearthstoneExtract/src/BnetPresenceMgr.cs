using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class BnetPresenceMgr
{
    private Dictionary<BnetAccountId, BnetAccount> m_accounts = new Dictionary<BnetAccountId, BnetAccount>();
    private Dictionary<BnetGameAccountId, BnetGameAccount> m_gameAccounts = new Dictionary<BnetGameAccountId, BnetGameAccount>();
    private BnetGameAccountId m_myGameAccountId;
    private BnetPlayer m_myPlayer;
    private Dictionary<BnetAccountId, BnetPlayer> m_players = new Dictionary<BnetAccountId, BnetPlayer>();
    private List<PlayersChangedListener> m_playersChangedListeners = new List<PlayersChangedListener>();
    private static BnetPresenceMgr s_instance;

    private void AddChangedPlayer(BnetPlayer player, BnetPlayerChangelist changelist)
    {
        BnetPlayerChange change;
        if (player == null)
        {
            change = new BnetPlayerChange();
        }
        else
        {
            if (changelist.HasChange(player))
            {
                return;
            }
            change = new BnetPlayerChange();
            change.SetOldPlayer(player.Clone());
        }
        change.SetNewPlayer(player);
        changelist.AddChange(change);
    }

    public bool AddPlayersChangedListener(PlayersChangedCallback callback)
    {
        return this.AddPlayersChangedListener(callback, null);
    }

    public bool AddPlayersChangedListener(PlayersChangedCallback callback, object userData)
    {
        PlayersChangedListener item = new PlayersChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_playersChangedListeners.Contains(item))
        {
            return false;
        }
        this.m_playersChangedListeners.Add(item);
        return true;
    }

    private void CacheMyself(BnetGameAccount gameAccount, BnetPlayer player)
    {
        if ((player != this.m_myPlayer) && (gameAccount.GetId() == this.m_myGameAccountId))
        {
            this.m_myPlayer = player;
        }
    }

    private void CreateAccount(BnetAccountId id, BattleNet.PresenceUpdate update, BnetPlayerChangelist changelist)
    {
        BnetAccount account = new BnetAccount();
        this.m_accounts.Add(id, account);
        account.SetId(id);
        BnetPlayer player = null;
        if (!this.m_players.TryGetValue(id, out player))
        {
            player = new BnetPlayer();
            this.m_players.Add(id, player);
            BnetPlayerChange change = new BnetPlayerChange();
            change.SetNewPlayer(player);
            changelist.AddChange(change);
        }
        player.SetAccount(account);
        this.UpdateAccount(account, update, changelist);
    }

    private void CreateGameAccount(BnetGameAccountId id, BattleNet.PresenceUpdate update, BnetPlayerChangelist changelist)
    {
        BnetGameAccount account = new BnetGameAccount();
        this.m_gameAccounts.Add(id, account);
        account.SetId(id);
        this.UpdateGameAccount(account, update, changelist);
    }

    private BnetPlayerChangelist CreateGameFieldChangelist(BnetGameAccount hsGameAccount, int fieldId, object val)
    {
        if (hsGameAccount == null)
        {
            return null;
        }
        BnetPlayerChange change = new BnetPlayerChange();
        change.SetOldPlayer(this.m_myPlayer.Clone());
        change.SetNewPlayer(this.m_myPlayer);
        hsGameAccount.SetGameField(fieldId, val);
        BnetPlayerChangelist changelist = new BnetPlayerChangelist();
        changelist.AddChange(change);
        return changelist;
    }

    private void CreateGameInfo(BnetGameAccountId id, BattleNet.PresenceUpdate update, BnetPlayerChangelist changelist)
    {
        BnetGameAccount account = new BnetGameAccount();
        this.m_gameAccounts.Add(id, account);
        account.SetId(id);
        this.UpdateGameInfo(account, update, changelist);
    }

    private void FirePlayersChangedEvent(BnetPlayerChangelist changelist)
    {
        if ((changelist != null) && (changelist.GetChanges().Count != 0))
        {
            PlayersChangedListener[] listenerArray = this.m_playersChangedListeners.ToArray();
            for (int i = 0; i < listenerArray.Length; i++)
            {
                listenerArray[i].Fire(changelist);
            }
        }
    }

    public static BnetPresenceMgr Get()
    {
        if (s_instance == null)
        {
            s_instance = new BnetPresenceMgr();
        }
        return s_instance;
    }

    public BnetAccount GetAccount(BnetAccountId id)
    {
        if (id == null)
        {
            return null;
        }
        BnetAccount account = null;
        this.m_accounts.TryGetValue(id, out account);
        return account;
    }

    public BnetGameAccount GetGameAccount(BnetGameAccountId id)
    {
        if (id == null)
        {
            return null;
        }
        BnetGameAccount account = null;
        this.m_gameAccounts.TryGetValue(id, out account);
        return account;
    }

    public BnetGameAccountId GetMyGameAccountId()
    {
        return this.m_myGameAccountId;
    }

    public BnetPlayer GetMyPlayer()
    {
        return this.m_myPlayer;
    }

    public BnetPlayer GetPlayer(BnetAccountId id)
    {
        if (id == null)
        {
            return null;
        }
        BnetPlayer player = null;
        this.m_players.TryGetValue(id, out player);
        return player;
    }

    public BnetPlayer GetPlayer(BnetGameAccountId id)
    {
        BnetGameAccount gameAccount = this.GetGameAccount(id);
        if (gameAccount == null)
        {
            return null;
        }
        return this.GetPlayer(gameAccount.GetOwnerId());
    }

    private void HandleGameAccountChange(BnetPlayer player, BattleNet.PresenceUpdate update)
    {
        if (player != null)
        {
            player.OnGameAccountChanged(update.fieldId);
        }
    }

    public void Initialize()
    {
        Network.Get().SetPresenceHandler(new Network.PresenceHandler(this.OnPresenceUpdate));
        BattleNet.DllEntityId myGameAccountId = BattleNet.GetMyGameAccountId();
        this.m_myGameAccountId = BnetGameAccountId.CreateFromDll(myGameAccountId);
    }

    private void OnAccountUpdate(BattleNet.PresenceUpdate update, BnetPlayerChangelist changelist)
    {
        BnetAccountId key = BnetAccountId.CreateFromDll(update.entityId);
        BnetAccount account = null;
        if (!this.m_accounts.TryGetValue(key, out account))
        {
            this.CreateAccount(key, update, changelist);
        }
        else
        {
            this.UpdateAccount(account, update, changelist);
        }
    }

    private void OnGameAccountUpdate(BattleNet.PresenceUpdate update, BnetPlayerChangelist changelist)
    {
        BnetGameAccountId key = BnetGameAccountId.CreateFromDll(update.entityId);
        BnetGameAccount account = null;
        if (!this.m_gameAccounts.TryGetValue(key, out account))
        {
            this.CreateGameAccount(key, update, changelist);
        }
        else
        {
            this.UpdateGameAccount(account, update, changelist);
        }
    }

    private void OnGameUpdate(BattleNet.PresenceUpdate update, BnetPlayerChangelist changelist)
    {
        BnetGameAccountId key = BnetGameAccountId.CreateFromDll(update.entityId);
        BnetGameAccount account = null;
        if (!this.m_gameAccounts.TryGetValue(key, out account))
        {
            this.CreateGameInfo(key, update, changelist);
        }
        else
        {
            this.UpdateGameInfo(account, update, changelist);
        }
    }

    private void OnPresenceUpdate(BattleNet.PresenceUpdate[] updates)
    {
        BnetPlayerChangelist changelist = new BnetPlayerChangelist();
        foreach (BattleNet.PresenceUpdate update in updates)
        {
            if (update.programId == BnetProgramId.BNET)
            {
                if (update.groupId == 1)
                {
                    this.OnAccountUpdate(update, changelist);
                }
                else if (update.groupId == 2)
                {
                    this.OnGameAccountUpdate(update, changelist);
                }
            }
            else if (update.programId == BnetProgramId.HEARTHSTONE)
            {
                this.OnGameUpdate(update, changelist);
            }
        }
        this.FirePlayersChangedEvent(changelist);
    }

    public BnetPlayer RegisterPlayer(BnetAccountId id)
    {
        BnetPlayer player = this.GetPlayer(id);
        if (player == null)
        {
            player = new BnetPlayer();
            player.SetAccountId(id);
            this.m_players[id] = player;
            BnetPlayerChange change = new BnetPlayerChange();
            change.SetNewPlayer(player);
            BnetPlayerChangelist changelist = new BnetPlayerChangelist();
            changelist.AddChange(change);
            this.FirePlayersChangedEvent(changelist);
        }
        return player;
    }

    public bool RemovePlayersChangedListener(PlayersChangedCallback callback)
    {
        return this.RemovePlayersChangedListener(callback, null);
    }

    public bool RemovePlayersChangedListener(PlayersChangedCallback callback, object userData)
    {
        PlayersChangedListener item = new PlayersChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_playersChangedListeners.Remove(item);
    }

    public bool SetGameField(int fieldId, bool val)
    {
        BnetGameAccount account;
        if (!this.ShouldUpdateGameAccountGameField(fieldId, val, out account))
        {
            return false;
        }
        BnetPlayerChangelist changelist = this.CreateGameFieldChangelist(account, fieldId, val);
        BattleNet.SetPresenceBool(fieldId, val);
        this.FirePlayersChangedEvent(changelist);
        return true;
    }

    public bool SetGameField(int fieldId, int val)
    {
        BnetGameAccount account;
        if (!this.ShouldUpdateGameAccountGameField(fieldId, val, out account))
        {
            return false;
        }
        BnetPlayerChangelist changelist = this.CreateGameFieldChangelist(account, fieldId, val);
        BattleNet.SetPresenceInt(fieldId, (long) val);
        this.FirePlayersChangedEvent(changelist);
        return true;
    }

    private bool ShouldUpdateGameAccountGameField(int fieldId, object val, out BnetGameAccount hsGameAccount)
    {
        hsGameAccount = null;
        if (this.m_myPlayer != null)
        {
            hsGameAccount = this.m_myPlayer.GetHearthstoneGameAccount();
            if (hsGameAccount == null)
            {
                return true;
            }
            if (hsGameAccount.HasGameField(fieldId) && (val == hsGameAccount.GetGameField(fieldId)))
            {
                return false;
            }
        }
        return true;
    }

    public void Shutdown()
    {
        Network.Get().SetPresenceHandler(null);
    }

    private void UpdateAccount(BnetAccount account, BattleNet.PresenceUpdate update, BnetPlayerChangelist changelist)
    {
        BnetPlayer player = this.m_players[account.GetId()];
        if (update.fieldId == 4)
        {
            BnetBattleTag battleTag = BnetBattleTag.CreateFromString(update.newString);
            if (battleTag != account.GetBattleTag())
            {
                this.AddChangedPlayer(player, changelist);
                account.SetBattleTag(battleTag);
            }
        }
        else if (update.fieldId == 1)
        {
            string newString = update.newString;
            if (newString == null)
            {
                object[] messageArgs = new object[] { account };
                Error.AddDevFatal("Bnet Error", "BnetPresenceMgr.OnAccountUpdate() - Failed to convert full name to native string for {0}.", messageArgs);
            }
            else if (newString != account.GetFullName())
            {
                this.AddChangedPlayer(player, changelist);
                account.SetFullName(newString);
            }
        }
        else if (update.fieldId == 6)
        {
            if (update.newInt != account.GetLastOnlineMicrosec())
            {
                this.AddChangedPlayer(player, changelist);
                account.SetLastOnlineMicrosec((ulong) update.newInt);
            }
        }
        else if (update.fieldId == 3)
        {
        }
    }

    private void UpdateGameAccount(BnetGameAccount gameAccount, BattleNet.PresenceUpdate update, BnetPlayerChangelist changelist)
    {
        BnetPlayer player = null;
        BnetAccountId ownerId = gameAccount.GetOwnerId();
        if (ownerId != null)
        {
            this.m_players.TryGetValue(ownerId, out player);
        }
        if (update.fieldId == 5)
        {
            BnetBattleTag battleTag = BnetBattleTag.CreateFromString(update.newString);
            if (battleTag != gameAccount.GetBattleTag())
            {
                this.AddChangedPlayer(player, changelist);
                gameAccount.SetBattleTag(battleTag);
                this.HandleGameAccountChange(player, update);
            }
        }
        else if (update.fieldId == 1)
        {
            if (update.newBool != gameAccount.IsOnline())
            {
                this.AddChangedPlayer(player, changelist);
                gameAccount.SetOnline(update.newBool);
                this.HandleGameAccountChange(player, update);
            }
        }
        else if (update.fieldId == 3)
        {
            BnetProgramId programId = new BnetProgramId(update.newString);
            if (programId != gameAccount.GetProgramId())
            {
                this.AddChangedPlayer(player, changelist);
                gameAccount.SetProgramId(programId);
                this.HandleGameAccountChange(player, update);
            }
        }
        else if (update.fieldId == 4)
        {
            if (update.newInt != gameAccount.GetLastOnlineMicrosec())
            {
                this.AddChangedPlayer(player, changelist);
                gameAccount.SetLastOnlineMicrosec(update.newInt);
                this.HandleGameAccountChange(player, update);
            }
        }
        else if (update.fieldId == 7)
        {
            BnetAccountId id3 = BnetAccountId.CreateFromDll(update.newEntity);
            if (id3 != gameAccount.GetOwnerId())
            {
                this.UpdateGameAccountOwner(id3, gameAccount, changelist);
            }
        }
    }

    private void UpdateGameAccountOwner(BnetAccountId ownerId, BnetGameAccount gameAccount, BnetPlayerChangelist changelist)
    {
        BnetPlayer player = null;
        BnetAccountId key = gameAccount.GetOwnerId();
        if ((key != null) && this.m_players.TryGetValue(key, out player))
        {
            player.RemoveGameAccount(gameAccount.GetId());
            this.AddChangedPlayer(player, changelist);
        }
        BnetPlayer player2 = null;
        if (this.m_players.TryGetValue(ownerId, out player2))
        {
            this.AddChangedPlayer(player2, changelist);
        }
        else
        {
            player2 = new BnetPlayer();
            this.m_players.Add(ownerId, player2);
            BnetPlayerChange change = new BnetPlayerChange();
            change.SetNewPlayer(player2);
            changelist.AddChange(change);
        }
        gameAccount.SetOwnerId(ownerId);
        player2.AddGameAccount(gameAccount);
        this.CacheMyself(gameAccount, player2);
    }

    private void UpdateGameInfo(BnetGameAccount gameAccount, BattleNet.PresenceUpdate update, BnetPlayerChangelist changelist)
    {
        BnetPlayer player = null;
        BnetAccountId ownerId = gameAccount.GetOwnerId();
        if (ownerId != null)
        {
            this.m_players.TryGetValue(ownerId, out player);
        }
        if (update.fieldId == 1)
        {
            if (update.newBool != gameAccount.CanBeInvitedToGame())
            {
                this.AddChangedPlayer(player, changelist);
                gameAccount.SetCanBeInvitedToGame(update.newBool);
                this.HandleGameAccountChange(player, update);
            }
        }
        else if (update.fieldId == 2)
        {
            if (update.newInt != gameAccount.GetPlayingClass())
            {
                this.AddChangedPlayer(player, changelist);
                gameAccount.SetPlayingClass((int) update.newInt);
                this.HandleGameAccountChange(player, update);
            }
        }
        else if ((update.fieldId == 3) && (update.newInt != gameAccount.GetPlayMode()))
        {
            this.AddChangedPlayer(player, changelist);
            gameAccount.SetPlayMode((int) update.newInt);
            this.HandleGameAccountChange(player, update);
        }
    }

    public delegate void PlayersChangedCallback(BnetPlayerChangelist changelist, object userData);

    private class PlayersChangedListener : EventListener<BnetPresenceMgr.PlayersChangedCallback>
    {
        public void Fire(BnetPlayerChangelist changelist)
        {
            base.m_callback(changelist, base.m_userData);
        }
    }
}

