using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class BnetWhisperMgr
{
    private int m_firstPendingWhisperIndex = -1;
    private List<WhisperListener> m_whisperListeners = new List<WhisperListener>();
    private Dictionary<BnetGameAccountId, List<BnetWhisper>> m_whisperMap = new Dictionary<BnetGameAccountId, List<BnetWhisper>>();
    private List<BnetWhisper> m_whispers = new List<BnetWhisper>();
    private const int MAX_WHISPERS_PER_PLAYER = 100;
    private static BnetWhisperMgr s_instance;

    public bool AddWhisperListener(WhisperCallback callback)
    {
        return this.AddWhisperListener(callback, null);
    }

    public bool AddWhisperListener(WhisperCallback callback, object userData)
    {
        WhisperListener item = new WhisperListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_whisperListeners.Contains(item))
        {
            return false;
        }
        this.m_whisperListeners.Add(item);
        return true;
    }

    private void CleanWhisperList(List<BnetWhisper> whispers)
    {
        if (whispers.Count > 100)
        {
            BnetWhisper item = whispers[0];
            whispers.RemoveAt(0);
            if (((this.m_firstPendingWhisperIndex >= 0) && (item == this.m_whispers[this.m_firstPendingWhisperIndex])) && (this.m_firstPendingWhisperIndex == (this.m_whispers.Count - 1)))
            {
                BnetPresenceMgr.Get().RemovePlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
                this.m_firstPendingWhisperIndex = -1;
            }
            this.m_whispers.Remove(item);
        }
    }

    private void FireWhisperEvent(BnetWhisper whisper)
    {
        foreach (WhisperListener listener in this.m_whisperListeners.ToArray())
        {
            listener.Fire(whisper);
        }
    }

    public static BnetWhisperMgr Get()
    {
        if (s_instance == null)
        {
            s_instance = new BnetWhisperMgr();
        }
        return s_instance;
    }

    public List<BnetWhisper> GetWhispersWithPlayer(BnetPlayer player)
    {
        if (player == null)
        {
            return null;
        }
        List<BnetWhisper> list = new List<BnetWhisper>();
        foreach (BnetGameAccountId id in player.GetGameAccounts().Keys)
        {
            List<BnetWhisper> list2;
            if (this.m_whisperMap.TryGetValue(id, out list2))
            {
                list.AddRange(list2);
            }
        }
        if (list.Count == 0)
        {
            return null;
        }
        return list;
    }

    public void Initialize()
    {
        Network.Get().SetWhisperHandler(new Network.WhisperHandler(this.OnWhispers));
        Network.Get().AddBnetErrorListener(BnetFeature.Whisper, new Network.BnetErrorCallback(this.OnBnetError));
    }

    private bool OnBnetError(BnetErrorInfo info, object userData)
    {
        object[] args = new object[] { info.GetFeatureEvent(), info.GetError() };
        Log.Mike.Print("BnetWhisperMgr.OnBnetError() - event={0} error={1}", args);
        return true;
    }

    private void OnPlayersChanged(BnetPlayerChangelist changelist, object userData)
    {
        for (int i = 0; i < this.m_whispers.Count; i++)
        {
            BnetWhisper whisper = this.m_whispers[i];
            if (!whisper.IsDisplayable())
            {
                return;
            }
        }
        BnetPresenceMgr.Get().RemovePlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
        for (int j = this.m_firstPendingWhisperIndex; j < this.m_whispers.Count; j++)
        {
            this.FireWhisperEvent(this.m_whispers[j]);
        }
        this.m_firstPendingWhisperIndex = -1;
    }

    private void OnWhispers(BattleNet.DllWhisper[] dllWhispers)
    {
        BnetPlayer myPlayer = BnetPresenceMgr.Get().GetMyPlayer();
        for (int i = 0; i < dllWhispers.Length; i++)
        {
            BnetWhisper item = BnetWhisper.CreateFromDll(dllWhispers[i]);
            BnetGameAccountId theirGameAccountId = item.GetTheirGameAccountId();
            if (BnetFriendMgr.Get().IsFriend(theirGameAccountId) || myPlayer.HasGameAccount(theirGameAccountId))
            {
                List<BnetWhisper> list;
                if (!this.m_whisperMap.TryGetValue(theirGameAccountId, out list))
                {
                    list = new List<BnetWhisper>();
                    this.m_whisperMap.Add(theirGameAccountId, list);
                }
                else
                {
                    this.CleanWhisperList(list);
                }
                list.Add(item);
                this.m_whispers.Add(item);
                if (!item.IsDisplayable())
                {
                    if (this.m_firstPendingWhisperIndex < 0)
                    {
                        this.m_firstPendingWhisperIndex = this.m_whispers.Count - 1;
                        BnetPresenceMgr.Get().AddPlayersChangedListener(new BnetPresenceMgr.PlayersChangedCallback(this.OnPlayersChanged));
                    }
                }
                else
                {
                    this.FireWhisperEvent(item);
                }
            }
        }
    }

    public bool RemoveWhisperListener(WhisperCallback callback)
    {
        return this.RemoveWhisperListener(callback, null);
    }

    public bool RemoveWhisperListener(WhisperCallback callback, object userData)
    {
        WhisperListener item = new WhisperListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_whisperListeners.Remove(item);
    }

    public bool SendWhisper(BnetPlayer player, string message)
    {
        if (player == null)
        {
            return false;
        }
        BnetGameAccount bestGameAccount = player.GetBestGameAccount();
        if (bestGameAccount == null)
        {
            return false;
        }
        Network.SendWhisper(bestGameAccount.GetId(), message);
        return true;
    }

    public void Shutdown()
    {
        Network.Get().RemoveBnetErrorListener(BnetFeature.Whisper, new Network.BnetErrorCallback(this.OnBnetError));
        Network.Get().SetWhisperHandler(null);
    }

    public delegate void WhisperCallback(BnetWhisper whisper, object userData);

    private class WhisperListener : EventListener<BnetWhisperMgr.WhisperCallback>
    {
        public void Fire(BnetWhisper whisper)
        {
            base.m_callback(whisper, base.m_userData);
        }
    }
}

