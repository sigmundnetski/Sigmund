using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeroXPBar : MonoBehaviour
{
    public UberText m_barText;
    public float m_delay;
    public GameObject m_heroFrame;
    public NetCache.HeroLevel m_heroLevel;
    public UberText m_heroLevelText;
    public bool m_isAnimated;
    public bool m_isOnDeck;
    public bool m_isPractice;
    public ProgressBar m_progressBar;
    public GameObject m_simpleFrame;
    public int m_soloLevelLimit;

    public void AnimateBar(NetCache.HeroLevel.LevelInfo previousLevelInfo, NetCache.HeroLevel.LevelInfo currentLevelInfo)
    {
        this.m_heroLevelText.Text = previousLevelInfo.Level.ToString();
        if (previousLevelInfo.Level < currentLevelInfo.Level)
        {
            float prevVal = ((float) previousLevelInfo.XP) / ((float) previousLevelInfo.MaxXP);
            float currVal = 1f;
            this.m_progressBar.AnimateProgress(prevVal, currVal);
            float animationTime = this.m_progressBar.GetAnimationTime();
            base.StartCoroutine(this.AnimatePostLevelUpXp(animationTime, currentLevelInfo));
        }
        else
        {
            float num4 = ((float) previousLevelInfo.XP) / ((float) previousLevelInfo.MaxXP);
            float num5 = ((float) currentLevelInfo.XP) / ((float) currentLevelInfo.MaxXP);
            this.m_progressBar.AnimateProgress(num4, num5);
        }
    }

    [DebuggerHidden]
    private IEnumerator AnimatePostLevelUpXp(float delayTime, NetCache.HeroLevel.LevelInfo currentLevelInfo)
    {
        return new <AnimatePostLevelUpXp>c__IteratorDB { delayTime = delayTime, currentLevelInfo = currentLevelInfo, <$>delayTime = delayTime, <$>currentLevelInfo = currentLevelInfo, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator DelayBarAnimation(NetCache.HeroLevel.LevelInfo prevInfo, NetCache.HeroLevel.LevelInfo currInfo)
    {
        return new <DelayBarAnimation>c__IteratorDC { prevInfo = prevInfo, currInfo = currInfo, <$>prevInfo = prevInfo, <$>currInfo = currInfo, <>f__this = this };
    }

    public void SetBarText(string barText)
    {
        this.m_barText.Text = barText;
    }

    public void SetBarValue(float barValue)
    {
        this.m_progressBar.SetProgressBar(barValue);
    }

    private void SetPracticeMaxLevel()
    {
        this.m_heroLevelText.Text = this.m_soloLevelLimit.ToString();
        this.SetBarValue(0f);
        this.SetBarText(GameStrings.Get("GLOBAL_PRACTICE_MAX_LEVEL_REACHED"));
    }

    public void UpdateDisplay()
    {
        if (this.m_isOnDeck)
        {
            this.m_simpleFrame.SetActive(true);
            this.m_heroFrame.SetActive(false);
        }
        else
        {
            this.m_simpleFrame.SetActive(false);
            this.m_heroFrame.SetActive(true);
        }
        if (this.m_isPractice)
        {
            if (this.m_isAnimated)
            {
                if (this.m_heroLevel.PrevLevel.Level >= this.m_soloLevelLimit)
                {
                    this.SetPracticeMaxLevel();
                    return;
                }
                if (this.m_heroLevel.CurrentLevel.Level >= this.m_soloLevelLimit)
                {
                    this.SetPracticeMaxLevel();
                    base.StartCoroutine(this.DelayBarAnimation(this.m_heroLevel.PrevLevel, this.m_heroLevel.CurrentLevel));
                    return;
                }
            }
            else if (this.m_heroLevel.CurrentLevel.Level >= this.m_soloLevelLimit)
            {
                this.SetPracticeMaxLevel();
                return;
            }
        }
        this.SetBarText(string.Empty);
        if (this.m_isAnimated)
        {
            this.m_heroLevelText.Text = this.m_heroLevel.PrevLevel.Level.ToString();
            this.SetBarValue(((float) this.m_heroLevel.PrevLevel.XP) / ((float) this.m_heroLevel.PrevLevel.MaxXP));
            base.StartCoroutine(this.DelayBarAnimation(this.m_heroLevel.PrevLevel, this.m_heroLevel.CurrentLevel));
        }
        else
        {
            this.m_heroLevelText.Text = this.m_heroLevel.CurrentLevel.Level.ToString();
            this.SetBarValue(((float) this.m_heroLevel.CurrentLevel.XP) / ((float) this.m_heroLevel.CurrentLevel.MaxXP));
        }
    }

    [CompilerGenerated]
    private sealed class <AnimatePostLevelUpXp>c__IteratorDB : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal NetCache.HeroLevel.LevelInfo <$>currentLevelInfo;
        internal float <$>delayTime;
        internal HeroXPBar <>f__this;
        internal float <targetXP>__0;
        internal NetCache.HeroLevel.LevelInfo currentLevelInfo;
        internal float delayTime;

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
                    this.$current = new WaitForSeconds(this.delayTime);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (!this.<>f__this.m_isPractice || (this.currentLevelInfo.Level < this.<>f__this.m_soloLevelLimit))
                    {
                        this.<>f__this.m_heroLevelText.Text = this.currentLevelInfo.Level.ToString();
                        this.<targetXP>__0 = ((float) this.currentLevelInfo.XP) / ((float) this.currentLevelInfo.MaxXP);
                        this.<>f__this.m_progressBar.AnimateProgress(0f, this.<targetXP>__0);
                        break;
                    }
                    this.<>f__this.SetPracticeMaxLevel();
                    break;

                default:
                    goto Label_00DD;
            }
            this.$PC = -1;
        Label_00DD:
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
    private sealed class <DelayBarAnimation>c__IteratorDC : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal NetCache.HeroLevel.LevelInfo <$>currInfo;
        internal NetCache.HeroLevel.LevelInfo <$>prevInfo;
        internal HeroXPBar <>f__this;
        internal NetCache.HeroLevel.LevelInfo currInfo;
        internal NetCache.HeroLevel.LevelInfo prevInfo;

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
                    this.$current = new WaitForSeconds(this.<>f__this.m_delay);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.AnimateBar(this.prevInfo, this.currInfo);
                    this.$PC = -1;
                    break;
            }
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

