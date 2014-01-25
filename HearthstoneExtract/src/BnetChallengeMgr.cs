using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class BnetChallengeMgr
{
    private List<ChallengeListener> m_challengeListeners = new List<ChallengeListener>();
    private static BnetChallengeMgr s_instance;

    private BnetChallengeMgr()
    {
    }

    public bool AddChallengeListener(ChallengeCallback callback)
    {
        return this.AddChallengeListener(callback, null);
    }

    public bool AddChallengeListener(ChallengeCallback callback, object userData)
    {
        ChallengeListener item = new ChallengeListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_challengeListeners.Contains(item))
        {
            return false;
        }
        this.m_challengeListeners.Add(item);
        return true;
    }

    private void FireChallengeEvent(ChallengeInfo info)
    {
        foreach (ChallengeListener listener in this.m_challengeListeners.ToArray())
        {
            listener.Fire(info);
        }
    }

    public static BnetChallengeMgr Get()
    {
        if (s_instance == null)
        {
            s_instance = new BnetChallengeMgr();
        }
        return s_instance;
    }

    public void Initialize()
    {
        Network.Get().SetChallengeHandler(new Network.ChallengeHandler(this.OnChallengeUpdate));
        Network.Get().AddBnetErrorListener(BnetFeature.Challenge, new Network.BnetErrorCallback(this.OnBnetError));
    }

    private bool OnBnetError(BnetErrorInfo info, object userData)
    {
        object[] args = new object[] { info.GetFeatureEvent(), info.GetError() };
        Log.Rachelle.Print("BnetChallengeMgr.OnBnetError() - event={0} error={1}", args);
        return true;
    }

    private void OnChallengeUpdate(BattleNet.DllChallengeInfo[] challenges)
    {
        foreach (BattleNet.DllChallengeInfo info in challenges)
        {
            this.FireChallengeEvent(new ChallengeInfo(info.challengeId, info.isRetry));
        }
    }

    public bool RemoveChallengeListener(ChallengeCallback callback)
    {
        return this.RemoveChallengeListener(callback, null);
    }

    public bool RemoveChallengeListener(ChallengeCallback callback, object userData)
    {
        ChallengeListener item = new ChallengeListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_challengeListeners.Remove(item);
    }

    public void Shutdown()
    {
        Network.Get().RemoveBnetErrorListener(BnetFeature.Challenge, new Network.BnetErrorCallback(this.OnBnetError));
        Network.Get().SetChallengeHandler(null);
    }

    public delegate void ChallengeCallback(BnetChallengeMgr.ChallengeInfo challengeInfo, object userData);

    public class ChallengeInfo
    {
        private ulong m_id;
        private bool m_isRetry;

        public ChallengeInfo(ulong id, bool isRetry)
        {
            this.m_id = id;
            this.m_isRetry = isRetry;
        }

        public ulong ID
        {
            get
            {
                return this.m_id;
            }
        }

        public bool IsRetry
        {
            get
            {
                return this.m_isRetry;
            }
        }
    }

    private class ChallengeListener : EventListener<BnetChallengeMgr.ChallengeCallback>
    {
        public void Fire(BnetChallengeMgr.ChallengeInfo info)
        {
            base.m_callback(info, base.m_userData);
        }
    }
}

