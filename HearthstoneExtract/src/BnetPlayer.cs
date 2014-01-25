using System;
using System.Collections.Generic;

public class BnetPlayer
{
    private BnetAccount m_account;
    private BnetAccountId m_accountId;
    private BnetGameAccount m_bestGameAccount;
    private Dictionary<BnetGameAccountId, BnetGameAccount> m_gameAccounts = new Dictionary<BnetGameAccountId, BnetGameAccount>();
    private BnetGameAccount m_hsGameAccount;

    public void AddGameAccount(BnetGameAccount gameAccount)
    {
        BnetGameAccountId key = gameAccount.GetId();
        if (!this.m_gameAccounts.ContainsKey(key))
        {
            this.m_gameAccounts.Add(key, gameAccount);
            this.CacheSpecialGameAccounts();
        }
    }

    private void CacheSpecialGameAccounts()
    {
        this.m_hsGameAccount = null;
        this.m_bestGameAccount = null;
        long lastOnlineMicrosec = 0L;
        foreach (BnetGameAccount account in this.m_gameAccounts.Values)
        {
            BnetProgramId programId = account.GetProgramId();
            if ((programId != null) && account.IsOnline())
            {
                if (programId == BnetProgramId.HEARTHSTONE)
                {
                    this.m_hsGameAccount = account;
                    this.m_bestGameAccount = account;
                    continue;
                }
                if (programId.IsGame())
                {
                    if (this.m_bestGameAccount == null)
                    {
                        this.m_bestGameAccount = account;
                        lastOnlineMicrosec = this.m_bestGameAccount.GetLastOnlineMicrosec();
                    }
                    else if (account.GetProgramId() != BnetProgramId.HEARTHSTONE)
                    {
                        long num2 = account.GetLastOnlineMicrosec();
                        if (num2 > lastOnlineMicrosec)
                        {
                            this.m_bestGameAccount = account;
                            lastOnlineMicrosec = num2;
                        }
                    }
                    continue;
                }
                this.m_bestGameAccount = account;
            }
        }
    }

    public BnetPlayer Clone()
    {
        BnetPlayer player = new BnetPlayer();
        if (this.m_accountId != null)
        {
            player.m_accountId = this.m_accountId.Clone();
        }
        if (this.m_account != null)
        {
            player.m_account = this.m_account.Clone();
        }
        foreach (KeyValuePair<BnetGameAccountId, BnetGameAccount> pair in this.m_gameAccounts)
        {
            BnetGameAccountId key = pair.Key;
            BnetGameAccount account = pair.Value;
            BnetGameAccountId id2 = key.Clone();
            BnetGameAccount account2 = account.Clone();
            player.m_gameAccounts.Add(id2, account2);
            if (account == this.m_hsGameAccount)
            {
                player.m_hsGameAccount = account2;
            }
            if (account == this.m_bestGameAccount)
            {
                player.m_bestGameAccount = account2;
            }
        }
        return player;
    }

    public BnetAccount GetAccount()
    {
        return this.m_account;
    }

    public BnetAccountId GetAccountId()
    {
        if (this.m_accountId != null)
        {
            return this.m_accountId;
        }
        BnetGameAccount firstGameAccount = this.GetFirstGameAccount();
        if (firstGameAccount != null)
        {
            return firstGameAccount.GetOwnerId();
        }
        return null;
    }

    public BnetBattleTag GetBattleTag()
    {
        if (this.m_account != null)
        {
            return this.m_account.GetBattleTag();
        }
        BnetGameAccount firstGameAccount = this.GetFirstGameAccount();
        if (firstGameAccount != null)
        {
            return firstGameAccount.GetBattleTag();
        }
        return null;
    }

    public BnetGameAccount GetBestGameAccount()
    {
        return this.m_bestGameAccount;
    }

    public string GetBestName()
    {
        if (this == BnetPresenceMgr.Get().GetMyPlayer())
        {
            if (this.m_hsGameAccount == null)
            {
                return null;
            }
            return this.m_hsGameAccount.GetBattleTag().GetName();
        }
        if (this.m_account != null)
        {
            string fullName = this.m_account.GetFullName();
            if (fullName != null)
            {
                return fullName;
            }
            return this.m_account.GetBattleTag().GetName();
        }
        if (this.m_bestGameAccount == null)
        {
            return null;
        }
        return this.m_bestGameAccount.GetBattleTag().GetName();
    }

    public BnetProgramId GetBestProgramId()
    {
        if (this.m_bestGameAccount == null)
        {
            return null;
        }
        return this.m_bestGameAccount.GetProgramId();
    }

    public BnetGameAccount GetFirstGameAccount()
    {
        using (Dictionary<BnetGameAccountId, BnetGameAccount>.ValueCollection.Enumerator enumerator = this.m_gameAccounts.Values.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                return enumerator.Current;
            }
        }
        return null;
    }

    public string GetFullName()
    {
        return ((this.m_account != null) ? this.m_account.GetFullName() : null);
    }

    public BnetGameAccount GetGameAccount(BnetGameAccountId id)
    {
        BnetGameAccount account = null;
        this.m_gameAccounts.TryGetValue(id, out account);
        return account;
    }

    public Dictionary<BnetGameAccountId, BnetGameAccount> GetGameAccounts()
    {
        return this.m_gameAccounts;
    }

    public BnetGameAccount GetHearthstoneGameAccount()
    {
        return this.m_hsGameAccount;
    }

    public int GetNumOnlineGameAccounts()
    {
        int num = 0;
        foreach (BnetGameAccount account in this.m_gameAccounts.Values)
        {
            if (account.IsOnline())
            {
                num++;
            }
        }
        return num;
    }

    public List<BnetGameAccount> GetOnlineGameAccounts()
    {
        List<BnetGameAccount> list = new List<BnetGameAccount>();
        foreach (BnetGameAccount account in this.m_gameAccounts.Values)
        {
            if (account.IsOnline())
            {
                list.Add(account);
            }
        }
        return list;
    }

    public long GetPersistentGameId()
    {
        return 0L;
    }

    public bool HasGameAccount(BnetGameAccountId id)
    {
        return this.m_gameAccounts.ContainsKey(id);
    }

    public bool HasMultipleOnlineGameAccounts()
    {
        bool flag = false;
        foreach (BnetGameAccount account in this.m_gameAccounts.Values)
        {
            if (account.IsOnline())
            {
                if (flag)
                {
                    return true;
                }
                flag = true;
            }
        }
        return false;
    }

    public bool IsDisplayable()
    {
        return (this.GetBattleTag() != null);
    }

    public bool IsOnline()
    {
        foreach (BnetGameAccount account in this.m_gameAccounts.Values)
        {
            if (account.IsOnline())
            {
                return true;
            }
        }
        return false;
    }

    public void OnGameAccountChanged(int fieldId)
    {
        if (((fieldId == 3) || (fieldId == 1)) || (fieldId == 4))
        {
            this.CacheSpecialGameAccounts();
        }
    }

    public bool RemoveGameAccount(BnetGameAccountId id)
    {
        if (!this.m_gameAccounts.Remove(id))
        {
            return false;
        }
        this.CacheSpecialGameAccounts();
        return true;
    }

    public void SetAccount(BnetAccount account)
    {
        this.m_account = account;
        this.m_accountId = account.GetId();
    }

    public void SetAccountId(BnetAccountId accountId)
    {
        this.m_accountId = accountId;
    }

    public override string ToString()
    {
        BnetAccountId accountId = this.GetAccountId();
        BnetBattleTag battleTag = this.GetBattleTag();
        if ((accountId == null) && (battleTag == null))
        {
            return "UNKNOWN PLAYER";
        }
        return string.Format("[account={0} battleTag={1} numGameAccounts={2}]", accountId, battleTag, this.m_gameAccounts.Count);
    }
}

