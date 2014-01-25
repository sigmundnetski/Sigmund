using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MatchingPopupDisplay : TransitionPopup
{
    private const float AFTER_PUNCH_SCALE_VAL = 60f;
    private const float END_SCALE_VAL = 62f;
    public BeveledButton m_cancelButton;
    private SceneMgr.Mode m_gameMode;
    private List<MatchCanceledEvent> m_matchCanceledListeners = new List<MatchCanceledEvent>();
    public GameObject m_nameContainer;
    private List<GameObject> m_spinnerTexts = new List<GameObject>();
    public UberText m_tipOfTheDay;
    public UberText m_title;
    private const int NUM_SPINNER_ENTRIES = 10;
    private const float START_SCALE_VAL = 1f;

    private void Awake()
    {
        this.SetupSpinnerText();
        this.UpdateTipOfTheDay();
        this.GenerateRandomSpinnerTexts();
        this.m_title.Text = GameStrings.Get("GLUE_MATCHMAKER_FINDING_OPPONENT");
        this.m_cancelButton.SetText(GameStrings.Get("GLOBAL_CANCEL"));
        this.m_cancelButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.CancelButtonPressed));
        this.m_cancelButton.GetUberText().gameObject.SetActive(false);
        this.m_cancelButton.SetEnabled(false);
        this.m_nameContainer.SetActive(false);
        this.m_title.gameObject.SetActive(false);
        this.m_tipOfTheDay.gameObject.SetActive(false);
    }

    private void CancelButtonPressed(UIEvent e)
    {
        base.AnimateHide();
        foreach (MatchCanceledEvent event2 in this.m_matchCanceledListeners)
        {
            event2();
        }
    }

    private void GenerateRandomSpinnerTexts()
    {
        int num = 1;
        List<string> list = new List<string>();
        while (true)
        {
            string item = GameStrings.Get("GLUE_SPINNER_" + num);
            if (item == ("GLUE_SPINNER_" + num))
            {
                break;
            }
            list.Add(item);
            num++;
        }
        SceneUtils.FindChild(base.gameObject, "NAME_PerfectOpponent").gameObject.GetComponent<UberText>().Text = GameStrings.Get("GLUE_MATCHMAKER_PERFECT_OPPONENT");
        for (num = 0; num < 10; num++)
        {
            int index = Mathf.FloorToInt(UnityEngine.Random.value * list.Count);
            this.m_spinnerTexts[num].GetComponent<UberText>().Text = list[index];
            list.RemoveAt(index);
        }
    }

    private void IncreaseTooltipProgress()
    {
        if (this.m_gameMode == SceneMgr.Mode.TOURNAMENT)
        {
            Options.Get().SetInt(Option.TIP_PLAY_PROGRESS, Options.Get().GetInt(Option.TIP_PLAY_PROGRESS, 0) + 1);
        }
        else if (this.m_gameMode == SceneMgr.Mode.DRAFT)
        {
            Options.Get().SetInt(Option.TIP_FORGE_PROGRESS, Options.Get().GetInt(Option.TIP_FORGE_PROGRESS, 0) + 1);
        }
    }

    protected override void OnAnimateShowFinished()
    {
        this.m_cancelButton.SetEnabled(true);
    }

    public void OnGotoGameServer()
    {
        this.m_cancelButton.SetEnabled(false);
        this.IncreaseTooltipProgress();
    }

    protected override void OnSceneLoaded(SceneMgr.Mode mode, Scene scene, object userData)
    {
        if (base.m_shown)
        {
            SceneMgr.Get().UnregisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
            this.m_nameContainer.SetActive(true);
            base.GetComponent<PlayMakerFSM>().SendEvent("Death");
            base.StartCoroutine(this.StopSpinnerDelay());
        }
    }

    public void RegisterMatchCanceledEvent(MatchCanceledEvent callback)
    {
        this.m_matchCanceledListeners.Add(callback);
    }

    private void SetupSpinnerText()
    {
        for (int i = 1; i <= 10; i++)
        {
            GameObject gameObject = SceneUtils.FindChild(base.gameObject, "NAME_" + i).gameObject;
            this.m_spinnerTexts.Add(gameObject);
        }
    }

    protected override void ShowPopup()
    {
        base.ShowPopup();
        base.GetComponent<PlayMakerFSM>().SendEvent("Birth");
        this.m_cancelButton.SetEnabled(false);
        SceneUtils.EnableRenderers(this.m_nameContainer, false);
        this.m_title.gameObject.SetActive(true);
        this.m_tipOfTheDay.gameObject.SetActive(true);
        this.m_cancelButton.GetUberText().gameObject.SetActive(true);
    }

    [DebuggerHidden]
    private IEnumerator StopSpinnerDelay()
    {
        return new <StopSpinnerDelay>c__Iterator6F { <>f__this = this };
    }

    public bool UnregisterMatchCanceledEvent(MatchCanceledEvent callback)
    {
        return this.m_matchCanceledListeners.Remove(callback);
    }

    private void UpdateTipOfTheDay()
    {
        this.m_gameMode = SceneMgr.Get().GetMode();
        if (this.m_gameMode == SceneMgr.Mode.TOURNAMENT)
        {
            this.m_tipOfTheDay.Text = GameStrings.GetTip(TipCategory.PLAY, Options.Get().GetInt(Option.TIP_PLAY_PROGRESS, 0), TipCategory.DEFAULT);
        }
        else if (this.m_gameMode == SceneMgr.Mode.DRAFT)
        {
            this.m_tipOfTheDay.Text = GameStrings.GetTip(TipCategory.FORGE, Options.Get().GetInt(Option.TIP_FORGE_PROGRESS, 0), TipCategory.DEFAULT);
        }
        else
        {
            this.m_tipOfTheDay.Text = GameStrings.GetRandomTip(TipCategory.DEFAULT);
        }
    }

    [CompilerGenerated]
    private sealed class <StopSpinnerDelay>c__Iterator6F : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MatchingPopupDisplay <>f__this;

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
                    this.$current = new WaitForSeconds(3.5f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.AnimateHide();
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

    public delegate void MatchCanceledEvent();
}

