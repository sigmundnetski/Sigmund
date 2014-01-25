using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class FullScreenFXMgr : MonoBehaviour
{
    private EffectListener m_blurListener;
    private EffectListener m_desatListener;
    private EffectListener m_vignetteListener;
    private static FullScreenFXMgr s_instance;

    private void Awake()
    {
        s_instance = this;
    }

    private void BeginEffect(string name, string onUpdate, string onComplete, float start, float end, float time, iTween.EaseType easeType)
    {
        Hashtable args = new Hashtable();
        args["name"] = name;
        args["onupdate"] = onUpdate;
        args["onupdatetarget"] = base.gameObject;
        args["from"] = start;
        if (!string.IsNullOrEmpty(onComplete))
        {
            args["oncomplete"] = onComplete;
            args["oncompletetarget"] = base.gameObject;
        }
        args["to"] = end;
        args["time"] = time;
        args["easetype"] = easeType;
        iTween.StopByName(base.gameObject, name);
        iTween.ValueTo(base.gameObject, args);
    }

    public void Blur(float blurVal, float time, iTween.EaseType easeType, EffectListener listener = new EffectListener())
    {
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        component.BlurEnabled = true;
        this.m_blurListener = listener;
        this.BeginEffect("blur", "OnBlur", "OnBlurComplete", component.BlurBlend, blurVal, time, easeType);
    }

    public void Desaturate(float endVal, float time, iTween.EaseType easeType, EffectListener listener = new EffectListener())
    {
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        component.DesaturationEnabled = true;
        this.m_desatListener = listener;
        this.BeginEffect("desat", "OnDesat", "OnDesatComplete", component.Desaturation, endVal, time, easeType);
    }

    public static FullScreenFXMgr Get()
    {
        return s_instance;
    }

    public void OnBlur(float val)
    {
        Camera.main.GetComponent<FullScreenEffects>().BlurBlend = val;
    }

    public void OnBlurClear()
    {
        Camera.main.GetComponent<FullScreenEffects>().BlurEnabled = false;
        this.OnBlurComplete();
    }

    public void OnBlurComplete()
    {
        if (this.m_blurListener != null)
        {
            this.m_blurListener();
        }
    }

    public void OnDesat(float val)
    {
        Camera.main.GetComponent<FullScreenEffects>().Desaturation = val;
    }

    public void OnDesatClear()
    {
        Camera.main.GetComponent<FullScreenEffects>().DesaturationEnabled = false;
        this.OnDesatComplete();
    }

    public void OnDesatComplete()
    {
        if (this.m_desatListener != null)
        {
            this.m_desatListener();
        }
    }

    public void OnVignette(float val)
    {
        Camera.main.GetComponent<FullScreenEffects>().VignettingIntensity = val;
    }

    public void OnVignetteClear()
    {
        Camera.main.GetComponent<FullScreenEffects>().VignettingEnable = false;
        this.OnVignetteComplete();
    }

    public void OnVignetteComplete()
    {
        if (this.m_vignetteListener != null)
        {
            this.m_vignetteListener();
        }
    }

    public void SetBlurAmount(float val)
    {
        Camera.main.GetComponent<FullScreenEffects>().BlurAmount = val;
    }

    public void SetBlurBrightness(float val)
    {
        Camera.main.GetComponent<FullScreenEffects>().BlurBrightness = val;
    }

    public void SetBlurDesaturation(float val)
    {
        Camera.main.GetComponent<FullScreenEffects>().BlurDesaturation = val;
    }

    public void StopBlur(float time, iTween.EaseType easeType, EffectListener listener = new EffectListener())
    {
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        component.BlurEnabled = true;
        this.m_blurListener = listener;
        this.BeginEffect("blur", "OnBlur", "OnBlurClear", component.BlurBlend, 0f, time, easeType);
    }

    public void StopDesaturate(float time, iTween.EaseType easeType, EffectListener listener = new EffectListener())
    {
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        component.DesaturationEnabled = true;
        this.m_desatListener = listener;
        this.BeginEffect("desat", "OnDesat", "OnDesatClear", component.Desaturation, 0f, time, easeType);
    }

    public void StopVignette(float time, iTween.EaseType easeType, EffectListener listener = new EffectListener())
    {
        FullScreenEffects component = Camera.main.GetComponent<FullScreenEffects>();
        component.VignettingEnable = true;
        this.m_vignetteListener = listener;
        this.BeginEffect("vignette", "OnVignette", "OnVignetteClear", component.VignettingIntensity, 0f, time, easeType);
    }

    public void Vignette(float endVal, float time, iTween.EaseType easeType, EffectListener listener = new EffectListener())
    {
        Camera.main.GetComponent<FullScreenEffects>().VignettingEnable = true;
        this.m_vignetteListener = listener;
        this.BeginEffect("vignette", "OnVignette", "OnVignetteComplete", 0f, endVal, time, easeType);
    }

    public delegate void EffectListener();
}

