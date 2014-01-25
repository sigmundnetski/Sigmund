using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LoadingPopupDisplay : TransitionPopup
{
    public static readonly Vector3 END_POS = new Vector3(-0.0152f, 0.0368f, 0.0226f);
    private const float LOWER_TIME = 0.25f;
    private bool m_animationStopped;
    public GameObject m_loadingTile;
    public ProgressBar m_progressBar;
    private bool m_stopAnimating;
    private List<string> m_tasks = new List<string>();
    public UberText m_tipOfTheDay;
    public UberText m_title;
    public static readonly Vector3 MID_POS = new Vector3(-0.0152f, -0.0894f, 0.0226f);
    public static readonly Vector3 OFFSCREEN_POS = new Vector3(-0.0152f, -0.0894f, 0.13f);
    private const float RAISE_TIME = 0.5f;
    private const float ROTATION_DELAY = 0.5f;
    private const float ROTATION_DURATION = 0.5f;
    private const float SLIDE_IN_TIME = 0.5f;
    private const float SLIDE_OUT_TIME = 0.25f;
    public static readonly Vector3 START_POS = new Vector3(-0.0152f, -0.0894f, -0.0837f);
    private const int TASK_DURATION_VARIATION = 2;

    [DebuggerHidden]
    private IEnumerator AnimateBar(float timeToAnimate)
    {
        return new <AnimateBar>c__Iterator6C { timeToAnimate = timeToAnimate, <$>timeToAnimate = timeToAnimate, <>f__this = this };
    }

    private void AnimateInLoadingTile()
    {
        if (this.m_stopAnimating)
        {
            this.m_animationStopped = true;
        }
        else
        {
            this.m_loadingTile.transform.localEulerAngles = new Vector3(180f, 0f, 0f);
            this.m_loadingTile.transform.localPosition = START_POS;
            this.m_progressBar.SetProgressBar(0f);
            object[] args = new object[] { "position", MID_POS, "isLocal", true, "time", 0.5f, "easetype", iTween.EaseType.easeOutBounce };
            Hashtable hashtable = iTween.Hash(args);
            iTween.MoveTo(this.m_loadingTile, hashtable);
            object[] objArray2 = new object[] { "position", END_POS, "isLocal", true, "time", 0.5f, "delay", 0.5f, "easetype", iTween.EaseType.easeOutCubic };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.MoveTo(this.m_loadingTile, hashtable2);
            object[] objArray3 = new object[] { "amount", new Vector3(180f, 0f, 0f), "time", 0.5f, "delay", 0.8f, "easeType", iTween.EaseType.easeOutElastic, "space", Space.Self, "name", "flip" };
            Hashtable hashtable3 = iTween.Hash(objArray3);
            iTween.RotateAdd(this.m_loadingTile, hashtable3);
            this.m_progressBar.SetLabel(this.GetRandomTaskName());
            base.StartCoroutine(this.AnimateBar(this.GetRandomTaskDuration()));
        }
    }

    private void AnimateOutLoadingTile()
    {
        object[] args = new object[] { "position", MID_POS, "isLocal", true, "time", 0.25f, "easetype", iTween.EaseType.easeOutBounce };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(this.m_loadingTile, hashtable);
        object[] objArray2 = new object[] { "position", OFFSCREEN_POS, "isLocal", true, "time", 0.25f, "delay", 0.25f, "easetype", iTween.EaseType.easeOutCubic, "oncomplete", "AnimateInLoadingTile", "oncompletetarget", base.gameObject };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.MoveTo(this.m_loadingTile, hashtable2);
    }

    private void Awake()
    {
        this.m_title.Text = GameStrings.Get("GLUE_STARTING_GAME");
        if (SceneMgr.Get().GetMode() == SceneMgr.Mode.PRACTICE)
        {
            this.m_tipOfTheDay.Text = GameStrings.GetTip(TipCategory.PRACTICE, Options.Get().GetInt(Option.TIP_PRACTICE_PROGRESS, 0), TipCategory.DEFAULT);
        }
        else
        {
            this.m_tipOfTheDay.Text = GameStrings.GetRandomTip(TipCategory.DEFAULT);
        }
        int num = 1;
        this.m_tasks = new List<string>();
        while (true)
        {
            string item = GameStrings.Get("GLUE_LOADING_BAR_TASK_" + num);
            if (item == ("GLUE_LOADING_BAR_TASK_" + num))
            {
                break;
            }
            this.m_tasks.Add(item);
            num++;
        }
        base.SetPunchScale(47f, 45f);
        base.SetPosition(new Vector3(-0.05f, 8.2f, 3.908f));
    }

    private float GetRandomTaskDuration()
    {
        return (1f + (UnityEngine.Random.value * 2f));
    }

    private string GetRandomTaskName()
    {
        if (this.m_tasks.Count == 0)
        {
            return "ERROR - OUT OF TASK NAMES!!!";
        }
        int num = Mathf.FloorToInt(UnityEngine.Random.value * this.m_tasks.Count);
        return this.m_tasks[num];
    }

    protected override void OnAnimateShowFinished()
    {
        this.AnimateInLoadingTile();
    }

    private void OnDestroy()
    {
        SceneMgr.Get().UnregisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
    }

    protected override void OnSceneLoaded(SceneMgr.Mode mode, Scene scene, object userData)
    {
        if (base.m_shown)
        {
            SceneMgr.Get().UnregisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
            base.StartCoroutine(this.StopLoading());
        }
    }

    [DebuggerHidden]
    private IEnumerator StopLoading()
    {
        return new <StopLoading>c__Iterator6D { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <AnimateBar>c__Iterator6C : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal float <$>timeToAnimate;
        internal LoadingPopupDisplay <>f__this;
        internal float timeToAnimate;

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
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 1;
                    goto Label_00A2;

                case 1:
                    this.<>f__this.m_progressBar.m_increaseAnimTime = this.timeToAnimate;
                    this.<>f__this.m_progressBar.AnimateProgress(0f, 1f);
                    this.$current = new WaitForSeconds(this.timeToAnimate);
                    this.$PC = 2;
                    goto Label_00A2;

                case 2:
                    this.<>f__this.AnimateOutLoadingTile();
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_00A2:
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
    private sealed class <StopLoading>c__Iterator6D : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal LoadingPopupDisplay <>f__this;
        internal int <practiceProgress>__0;

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
                    this.<>f__this.m_stopAnimating = true;
                    break;

                case 1:
                    break;

                default:
                    goto Label_009F;
            }
            if (!this.<>f__this.m_animationStopped)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            if (SceneMgr.Get().GetPrevMode() == SceneMgr.Mode.PRACTICE)
            {
                this.<practiceProgress>__0 = Options.Get().GetInt(Option.TIP_PRACTICE_PROGRESS, 0);
                Options.Get().SetInt(Option.TIP_PRACTICE_PROGRESS, this.<practiceProgress>__0 + 1);
            }
            this.<>f__this.AnimateHide();
            this.$PC = -1;
        Label_009F:
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

