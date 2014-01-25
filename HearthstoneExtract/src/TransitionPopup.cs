using System;
using System.Collections;
using UnityEngine;

public class TransitionPopup : MonoBehaviour
{
    private float AFTER_PUNCH_SCALE_VAL = 60f;
    private Vector3 END_POSITION;
    private float END_SCALE_VAL = 62f;
    protected bool m_blockingLoadingScreen;
    protected bool m_shown;
    private Vector3 START_POSITION = new Vector3(-0.05f, 8.2f, -1.8f);
    private float START_SCALE_VAL = 1f;

    protected void AnimateBlurBlendOff()
    {
        object[] args = new object[] { "from", 1, "to", 0, "time", 0.5f, "easetype", iTween.EaseType.easeOutCirc, "onupdate", "OnUpdateBlurVal", "oncomplete", "DeactivatePopup", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(base.gameObject, hashtable);
    }

    private void AnimateBlurBlendOn()
    {
        object[] args = new object[] { "from", 0, "to", 1, "time", 0.5f, "easetype", iTween.EaseType.easeOutCirc, "onupdate", "OnUpdateBlurVal" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(base.gameObject, hashtable);
    }

    protected void AnimateHide()
    {
        iTween.FadeTo(base.gameObject, 0f, 0.25f);
        object[] args = new object[] { "scale", new Vector3(this.START_SCALE_VAL, this.START_SCALE_VAL, this.START_SCALE_VAL), "time", 0.25f };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ScaleTo(base.gameObject, hashtable);
        this.AnimateBlurBlendOff();
    }

    protected void AnimateShow()
    {
        this.m_shown = true;
        base.gameObject.SetActive(true);
        SceneUtils.EnableRenderers(base.gameObject, false);
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        component.BlurAmount = 0.3f;
        component.BlurDesaturation = 0.5f;
        component.BlurBrightness = 0.4f;
        component.BlurBlend = 0f;
        this.ShowPopup();
        this.AnimateBlurBlendOn();
    }

    public void Cancel()
    {
        if (this.m_shown && (Camera.main != null))
        {
            FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
            component.BlurBlend = 0f;
            component.Disable();
        }
    }

    protected void DeactivatePopup()
    {
        base.gameObject.SetActive(false);
        Camera.main.GetComponent<FullScreenEffects>().Disable();
        this.m_shown = false;
        this.StopBlockingTransition();
    }

    public void Hide()
    {
        if (this.m_shown)
        {
            this.AnimateHide();
        }
    }

    public bool IsShown()
    {
        return this.m_shown;
    }

    protected virtual void OnAnimateShowFinished()
    {
    }

    public void OnGameDenied()
    {
        this.Hide();
    }

    public void OnGameStarting()
    {
        this.StartBlockingTransition();
        SceneMgr.Get().RegisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
    }

    protected virtual void OnSceneLoaded(SceneMgr.Mode mode, Scene scene, object userData)
    {
    }

    private void OnUpdateBlurVal(float val)
    {
        if (Camera.main != null)
        {
            Camera.main.GetComponent<FullScreenEffects>().BlurBlend = val;
        }
    }

    private void PunchPopup()
    {
        iTween.ScaleTo(base.gameObject, new Vector3(this.AFTER_PUNCH_SCALE_VAL, this.AFTER_PUNCH_SCALE_VAL, this.AFTER_PUNCH_SCALE_VAL), 0.15f);
        this.OnAnimateShowFinished();
    }

    protected void SetPosition(Vector3 position)
    {
        this.START_POSITION = position;
    }

    protected void SetPunchScale(float endScale, float afterPunchScale)
    {
        this.END_SCALE_VAL = endScale;
        this.AFTER_PUNCH_SCALE_VAL = afterPunchScale;
    }

    public void Show()
    {
        if (!this.m_shown)
        {
            this.AnimateShow();
        }
    }

    protected virtual void ShowPopup()
    {
        SceneUtils.EnableRenderers(base.gameObject, true);
        iTween.FadeTo(base.gameObject, 1f, 0.25f);
        base.gameObject.transform.localScale = new Vector3(this.START_SCALE_VAL, this.START_SCALE_VAL, this.START_SCALE_VAL);
        object[] args = new object[] { "scale", new Vector3(this.END_SCALE_VAL, this.END_SCALE_VAL, this.END_SCALE_VAL), "time", 0.25f, "oncomplete", "PunchPopup", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ScaleTo(base.gameObject, hashtable);
        object[] objArray2 = new object[] { "position", base.gameObject.transform.localPosition + new Vector3(0.02f, 0.02f, 0.02f), "time", 1.5f, "islocal", true };
        iTween.MoveTo(base.gameObject, iTween.Hash(objArray2));
    }

    private void Start()
    {
        iTween.FadeTo(base.gameObject, 0f, 0f);
        base.gameObject.transform.localPosition = this.START_POSITION;
        base.gameObject.SetActive(false);
    }

    protected void StartBlockingTransition()
    {
        this.m_blockingLoadingScreen = true;
        LoadingScreen.Get().AddTransitionBlocker();
        LoadingScreen.Get().AddTransitionObject(base.gameObject);
    }

    protected void StopBlockingTransition()
    {
        if (this.m_blockingLoadingScreen)
        {
            this.m_blockingLoadingScreen = false;
            LoadingScreen.Get().NotifyTransitionBlockerComplete();
        }
    }
}

