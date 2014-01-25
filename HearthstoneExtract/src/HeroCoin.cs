using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeroCoin : PegUIElement
{
    public GameObject m_coin;
    public UberText m_coinLabel;
    public GameObject m_coinX;
    public GameObject m_cracks;
    private Vector2 m_crackTexture;
    private CoinStatus m_currentStatus;
    public GameObject m_explosionPrefab;
    private Vector2 m_goldTexture;
    private Material m_grayMaterial;
    private Vector2 m_grayTexture;
    public GameObject m_highlight;
    public bool m_inputEnabled;
    public GameObject m_leftCap;
    private Vector2 m_lessonCoords;
    private string m_lessonGameObject;
    private Material m_material;
    public GameObject m_middle;
    private MissionMgr.MissionID m_missionID;
    private bool m_nextTutorialStarted;
    private float m_originalMiddleWidth;
    private Vector3 m_originalPosition;
    private Vector3 m_originalXPosition;
    public GameObject m_rightCap;
    public GameObject m_tooltip;
    public UberText m_tooltipText;

    protected override void Awake()
    {
        base.Awake();
        this.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.OnOver));
        this.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.OnOut));
        this.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnPress));
        this.m_originalMiddleWidth = this.m_middle.renderer.bounds.size.x;
        this.m_tooltip.SetActive(false);
    }

    public void EnableInput()
    {
        this.m_inputEnabled = true;
        this.m_highlight.SetActive(true);
    }

    public string GetLessonGameObject()
    {
        return this.m_lessonGameObject;
    }

    public void HideTooltip()
    {
        this.m_tooltip.SetActive(false);
    }

    private void OnOut(UIEvent e)
    {
        if (!this.m_nextTutorialStarted && this.m_inputEnabled)
        {
            this.HideTooltip();
        }
    }

    private void OnOver(UIEvent e)
    {
        if (!this.m_nextTutorialStarted && this.m_inputEnabled)
        {
            this.ShowTooltip();
            SoundManager.Get().LoadAndPlay("tutorial_mission_hero_coin_mouse_over", base.gameObject);
        }
    }

    private void OnPress(UIEvent e)
    {
        if (this.m_inputEnabled && !this.m_nextTutorialStarted)
        {
            this.m_inputEnabled = false;
            SoundManager.Get().LoadAndPlay("tutorial_mission_hero_coin_play_select", base.gameObject);
            this.StartNextTutorial();
        }
    }

    public void OnUpdateAlphaVal(float val)
    {
        this.m_material.SetColor("_Color", new Color(1f, 1f, 1f, val));
    }

    public void SetCoinInfo(Vector2 goldTexture, Vector2 grayTexture, Vector2 crackTexture, MissionMgr.MissionID missionID, string heroName)
    {
        this.m_material = base.renderer.materials[0];
        this.m_grayMaterial = base.renderer.materials[1];
        this.m_goldTexture = goldTexture;
        this.m_material.mainTextureOffset = this.m_goldTexture;
        this.m_grayTexture = grayTexture;
        this.m_grayMaterial.mainTextureOffset = this.m_grayTexture;
        this.m_crackTexture = crackTexture;
        this.m_cracks.renderer.material.mainTextureOffset = this.m_crackTexture;
        this.m_missionID = missionID;
        this.m_tooltipText.Text = heroName;
        this.m_originalPosition = base.transform.localPosition;
        this.m_originalXPosition = this.m_coinX.transform.localPosition;
    }

    public void SetLessonGameObject(string lessonGameObject)
    {
        this.m_lessonGameObject = lessonGameObject;
    }

    public void SetProgress(CoinStatus status)
    {
        base.gameObject.SetActive(true);
        this.m_currentStatus = status;
        if (status == CoinStatus.DEFEATED)
        {
            this.m_material.mainTextureOffset = this.m_grayTexture;
            this.m_cracks.SetActive(true);
            this.m_coinX.SetActive(true);
            this.m_highlight.SetActive(false);
            this.m_inputEnabled = false;
            this.m_coinLabel.gameObject.SetActive(false);
        }
        else if (status == CoinStatus.ACTIVE)
        {
            this.m_cracks.SetActive(false);
            this.m_coinX.SetActive(false);
            this.m_highlight.SetActive(false);
            this.m_inputEnabled = true;
            this.m_coinLabel.Text = GameStrings.Get("GLOBAL_PLAY");
        }
        else if (status == CoinStatus.UNREVEALED_TO_ACTIVE)
        {
            this.OnUpdateAlphaVal(0f);
            object[] args = new object[] { "y", 3f, "z", this.m_originalPosition.z - 0.2f, "time", 0.5f, "isLocal", true, "easetype", iTween.EaseType.easeOutCubic };
            Hashtable hashtable = iTween.Hash(args);
            iTween.MoveTo(base.gameObject, hashtable);
            object[] objArray2 = new object[] { "rotation", new Vector3(0f, 0f, 0f), "time", 1f, "isLocal", true, "delay", 0.5f, "easetype", iTween.EaseType.easeOutElastic };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.RotateTo(base.gameObject, hashtable2);
            object[] objArray3 = new object[] { "y", this.m_originalPosition.y, "z", this.m_originalPosition.z, "time", 0.5f, "isLocal", true, "delay", 1.75f, "easetype", iTween.EaseType.easeOutCubic };
            Hashtable hashtable3 = iTween.Hash(objArray3);
            iTween.MoveTo(base.gameObject, hashtable3);
            object[] objArray4 = new object[] { "from", 0, "to", 1, "time", 0.25f, "delay", 1.5f, "easetype", iTween.EaseType.easeOutCirc, "onupdate", "OnUpdateAlphaVal", "oncomplete", "EnableInput", "oncompletetarget", base.gameObject };
            Hashtable hashtable4 = iTween.Hash(objArray4);
            iTween.ValueTo(base.gameObject, hashtable4);
            SoundManager.Get().LoadAndPlay("tutorial_mission_hero_coin_rises", base.gameObject);
            base.StartCoroutine(this.ShowCoinText());
            this.m_inputEnabled = false;
        }
        else if (status == CoinStatus.ACTIVE_TO_DEFEATED)
        {
            this.m_coinX.transform.localPosition = new Vector3(0f, 10f, -0.23f);
            this.m_cracks.SetActive(true);
            this.m_coinX.SetActive(true);
            this.m_highlight.SetActive(false);
            this.m_inputEnabled = false;
            RenderUtils.SetAlpha(this.m_coinX, 0f);
            RenderUtils.SetAlpha(this.m_cracks, 0f);
            object[] objArray5 = new object[] { "y", this.m_originalXPosition.y, "z", this.m_originalXPosition.z, "time", 0.25f, "isLocal", true, "easetype", iTween.EaseType.easeInCirc };
            Hashtable hashtable5 = iTween.Hash(objArray5);
            iTween.MoveTo(this.m_coinX, hashtable5);
            object[] objArray6 = new object[] { "amount", 1, "delay", 0, "time", 0.25f, "easeType", iTween.EaseType.easeInCirc };
            Hashtable hashtable6 = iTween.Hash(objArray6);
            iTween.FadeTo(this.m_coinX, hashtable6);
            object[] objArray7 = new object[] { "amount", 1, "delay", 0.15f, "time", 0.25f, "easeType", iTween.EaseType.easeInCirc };
            Hashtable hashtable7 = iTween.Hash(objArray7);
            iTween.FadeTo(this.m_cracks, hashtable7);
            SoundManager.Get().LoadAndPlay("tutorial_mission_x_descend", base.gameObject);
            base.StartCoroutine(this.SwitchCoinToGray());
            GameState.Get().GetGameEntity().NotifyOfDefeatCoinAnimation();
        }
        else
        {
            base.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
            this.m_coinLabel.gameObject.SetActive(false);
            this.m_cracks.SetActive(false);
            this.m_coinX.SetActive(false);
            this.m_highlight.SetActive(false);
            this.m_inputEnabled = false;
        }
    }

    [DebuggerHidden]
    public IEnumerator ShowCoinText()
    {
        return new <ShowCoinText>c__IteratorB9 { <>f__this = this };
    }

    public void ShowTooltip()
    {
        if (this.m_currentStatus != CoinStatus.UNREVEALED)
        {
            this.m_tooltip.SetActive(true);
            float num = this.m_tooltipText.GetTextWorldSpaceBounds().size.x + 0.3f;
            float x = num / this.m_originalMiddleWidth;
            TransformUtil.SetLocalScaleX(this.m_middle, x);
            TransformUtil.SetPoint(this.m_leftCap, Anchor.RIGHT, this.m_middle, Anchor.LEFT, new Vector3(0.4f, 0f, 0.008f));
            TransformUtil.SetPoint(this.m_rightCap, Anchor.LEFT, this.m_middle, Anchor.RIGHT, new Vector3(-0.4f, 0f, 0.008f));
        }
    }

    private void StartNextTutorial()
    {
        this.m_nextTutorialStarted = true;
        MissionMgr.Get().StartMission(this.m_missionID);
    }

    [DebuggerHidden]
    public IEnumerator SwitchCoinToGray()
    {
        return new <SwitchCoinToGray>c__IteratorBA { <>f__this = this };
    }

    private void Update()
    {
    }

    [CompilerGenerated]
    private sealed class <ShowCoinText>c__IteratorB9 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HeroCoin <>f__this;

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
                    this.$current = new WaitForSeconds(1.5f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.m_coinLabel.gameObject.SetActive(true);
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

    [CompilerGenerated]
    private sealed class <SwitchCoinToGray>c__IteratorBA : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HeroCoin <>f__this;

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
                    this.$current = new WaitForSeconds(0.25f);
                    this.$PC = 1;
                    return true;

                case 1:
                {
                    this.<>f__this.m_material.SetColor("_Color", new Color(1f, 1f, 1f, 0f));
                    this.<>f__this.m_coinLabel.gameObject.SetActive(false);
                    object[] args = new object[] { "amount", new Vector3(0.2f, 0.2f, 0.2f), "name", "HeroCoin", "time", 0.5f, "delay", 0, "axis", "none" };
                    iTween.ShakePosition(Camera.mainCamera.gameObject, iTween.Hash(args));
                    this.$PC = -1;
                    break;
                }
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

    public enum CoinStatus
    {
        ACTIVE,
        DEFEATED,
        UNREVEALED,
        UNREVEALED_TO_ACTIVE,
        ACTIVE_TO_DEFEATED
    }
}

