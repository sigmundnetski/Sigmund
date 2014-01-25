using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Reward : MonoBehaviour
{
    private RewardData m_data;
    private bool m_ready = true;
    public RewardBanner m_rewardBanner;
    private bool m_shown = true;
    private Type m_type;

    protected Reward()
    {
        this.InitData();
    }

    public void Hide()
    {
        this.m_shown = false;
        this.HideReward();
    }

    protected virtual void HideReward()
    {
    }

    protected abstract void InitData();
    public void NotifyLoadedWhenReady(LoadRewardCallbackData loadRewardCallbackData)
    {
        base.StartCoroutine(this.WaitThenNotifyLoaded(loadRewardCallbackData));
    }

    protected virtual void OnDataSet(bool updateVisuals)
    {
    }

    public void SetData(RewardData data, bool updateVisuals)
    {
        this.m_data = data;
        this.OnDataSet(updateVisuals);
    }

    protected void SetReady(bool ready)
    {
        this.m_ready = ready;
    }

    protected void SetRewardText(string headline, string details, string source)
    {
        this.m_rewardBanner.SetText(headline, details, source);
    }

    public void Show()
    {
        this.m_shown = true;
        this.Data.AcknowledgeNotices();
        this.ShowReward();
    }

    protected virtual void ShowReward()
    {
    }

    [DebuggerHidden]
    private IEnumerator WaitThenNotifyLoaded(LoadRewardCallbackData loadRewardCallbackData)
    {
        return new <WaitThenNotifyLoaded>c__Iterator9D { loadRewardCallbackData = loadRewardCallbackData, <$>loadRewardCallbackData = loadRewardCallbackData, <>f__this = this };
    }

    public RewardData Data
    {
        get
        {
            return this.m_data;
        }
    }

    public bool IsShown
    {
        get
        {
            return this.m_shown;
        }
    }

    public Type RewardType
    {
        get
        {
            return this.Data.RewardType;
        }
    }

    [CompilerGenerated]
    private sealed class <WaitThenNotifyLoaded>c__Iterator9D : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Reward.LoadRewardCallbackData <$>loadRewardCallbackData;
        internal Reward <>f__this;
        internal Reward.LoadRewardCallbackData loadRewardCallbackData;

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
                    if (this.loadRewardCallbackData.m_callback != null)
                    {
                        break;
                    }
                    goto Label_0086;

                case 1:
                    break;

                default:
                    goto Label_0086;
            }
            while (!this.<>f__this.m_ready)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.loadRewardCallbackData.m_callback(this.<>f__this, this.loadRewardCallbackData.m_callbackData);
            this.$PC = -1;
        Label_0086:
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

    public delegate void DelOnRewardLoaded(Reward reward, object callbackData);

    public class LoadRewardCallbackData
    {
        public Reward.DelOnRewardLoaded m_callback;
        public object m_callbackData;
    }

    public enum Type
    {
        ARCANE_DUST,
        BOOSTER_PACK,
        CARD,
        FORGE_TICKET,
        GOLD,
        MOUNT
    }
}

