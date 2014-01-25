using System;
using System.Collections;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    private float m_animationTime;
    public float m_audioFadeInOut = 0.2f;
    public float m_barIntensity = 1.2f;
    public float m_barIntensityIncreaseMax = 3f;
    private Material m_barMaterial;
    public float m_coolDownAnimTime = 1f;
    private float m_currVal;
    public float m_decreaseAnimTime = 1f;
    public float m_decreasePitchEnd = 0.8f;
    public float m_decreasePitchStart = 1f;
    private float m_factor;
    public float m_increaseAnimTime = 2f;
    public float m_increasePitchEnd = 1.2f;
    public float m_increasePitchStart = 1f;
    public TextMesh m_label;
    private float m_maxIntensity;
    private float m_prevVal;
    private float m_Uadd;
    public UberText m_uberLabel;

    public void AnimateProgress(float prevVal, float currVal)
    {
        this.m_prevVal = prevVal;
        this.m_currVal = currVal;
        if (this.m_currVal > this.m_prevVal)
        {
            this.m_factor = this.m_currVal - this.m_prevVal;
        }
        else
        {
            this.m_factor = this.m_prevVal - this.m_currVal;
        }
        this.m_factor = Mathf.Abs(this.m_factor);
        if (this.m_currVal > this.m_prevVal)
        {
            this.IncreaseProgress(this.m_currVal, this.m_prevVal);
        }
        else
        {
            this.DecreaseProgress(this.m_currVal, this.m_prevVal);
        }
    }

    private void AudioPitch_OnUpdate(float val)
    {
        if (base.audio != null)
        {
            SoundManager.Get().SetPitch(base.audio, val);
        }
    }

    private void AudioVolume_OnComplete()
    {
        if (base.audio != null)
        {
            SoundManager.Get().Stop(base.audio);
        }
    }

    private void AudioVolume_OnUpdate(float val)
    {
        if (base.audio != null)
        {
            SoundManager.Get().SetVolume(base.audio, val);
        }
    }

    public void Awake()
    {
        this.m_barMaterial = base.renderer.material;
    }

    private void DecreaseProgress(float currProgress, float prevProgress)
    {
        float num = this.m_decreaseAnimTime * this.m_factor;
        this.m_animationTime = num;
        iTween.EaseType easeInOutCubic = iTween.EaseType.easeInOutCubic;
        object[] args = new object[] { "from", prevProgress, "to", currProgress, "time", num, "easetype", easeInOutCubic, "onupdate", "Progress_OnUpdate", "onupdatetarget", base.gameObject, "name", "Decrease" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(base.gameObject, "Decrease");
        iTween.ValueTo(base.gameObject, hashtable);
        if (base.audio != null)
        {
            SoundManager.Get().SetVolume(base.audio, 0f);
            SoundManager.Get().SetPitch(base.audio, this.m_decreasePitchStart);
            SoundManager.Get().Play(base.audio);
        }
        object[] objArray2 = new object[] { "from", 0, "to", 1, "time", num * this.m_audioFadeInOut, "delay", 0, "easetype", easeInOutCubic, "onupdate", "AudioVolume_OnUpdate", "onupdatetarget", base.gameObject, "name", "barVolumeStart" };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.StopByName(base.gameObject, "barVolumeStart");
        iTween.ValueTo(base.gameObject, hashtable2);
        object[] objArray3 = new object[] { 
            "from", 1, "to", 0, "time", num * this.m_audioFadeInOut, "delay", num * (1f - this.m_audioFadeInOut), "easetype", easeInOutCubic, "onupdate", "AudioVolume_OnUpdate", "onupdatetarget", base.gameObject, "oncomplete", "AudioVolume_OnComplete", 
            "name", "barVolumeEnd"
         };
        Hashtable hashtable3 = iTween.Hash(objArray3);
        iTween.StopByName(base.gameObject, "barVolumeEnd");
        iTween.ValueTo(base.gameObject, hashtable3);
        object[] objArray4 = new object[] { "from", this.m_decreasePitchStart, "to", this.m_decreasePitchEnd, "time", num, "delay", 0, "easetype", easeInOutCubic, "onupdate", "AudioPitch_OnUpdate", "onupdatetarget", base.gameObject, "name", "barPitch" };
        Hashtable hashtable4 = iTween.Hash(objArray4);
        iTween.StopByName(base.gameObject, "barPitch");
        iTween.ValueTo(base.gameObject, hashtable4);
    }

    public float GetAnimationTime()
    {
        return this.m_animationTime;
    }

    private void IncreaseProgress(float currProgress, float prevProgress)
    {
        float num = this.m_increaseAnimTime * this.m_factor;
        this.m_animationTime = num;
        iTween.EaseType easeOutQuad = iTween.EaseType.easeOutQuad;
        object[] args = new object[] { "from", prevProgress, "to", currProgress, "time", num, "easetype", easeOutQuad, "onupdate", "Progress_OnUpdate", "onupdatetarget", base.gameObject, "name", "IncreaseProgress" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(base.gameObject, "IncreaseProgress");
        iTween.ValueTo(base.gameObject, hashtable);
        object[] objArray2 = new object[] { "from", 0f, "to", 0.005f, "time", num, "easetype", iTween.EaseType.easeOutQuad, "onupdate", "ScrollSpeed_OnUpdate", "onupdatetarget", base.gameObject, "name", "UVSpeed" };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.StopByName(base.gameObject, "UVSpeed");
        iTween.ValueTo(base.gameObject, hashtable2);
        this.m_maxIntensity = this.m_barIntensity + ((this.m_barIntensityIncreaseMax - this.m_barIntensity) * this.m_factor);
        object[] objArray3 = new object[] { 
            "from", this.m_barIntensity, "to", this.m_maxIntensity, "time", num, "easetype", easeOutQuad, "onupdate", "Intensity_OnUpdate", "onupdatetarget", base.gameObject, "name", "Intensity", "oncomplete", "Intensity_OnComplete", 
            "oncompletetarget", base.gameObject
         };
        Hashtable hashtable3 = iTween.Hash(objArray3);
        iTween.StopByName(base.gameObject, "Intensity");
        iTween.ValueTo(base.gameObject, hashtable3);
        if (base.audio != null)
        {
            SoundManager.Get().SetVolume(base.audio, 0f);
            SoundManager.Get().SetPitch(base.audio, this.m_increasePitchStart);
            SoundManager.Get().Play(base.audio);
        }
        object[] objArray4 = new object[] { "from", 0, "to", 1, "time", num * this.m_audioFadeInOut, "delay", 0, "easetype", easeOutQuad, "onupdate", "AudioVolume_OnUpdate", "onupdatetarget", base.gameObject, "name", "barVolumeStart" };
        Hashtable hashtable4 = iTween.Hash(objArray4);
        iTween.StopByName(base.gameObject, "barVolumeStart");
        iTween.ValueTo(base.gameObject, hashtable4);
        object[] objArray5 = new object[] { 
            "from", 1, "to", 0, "time", num * this.m_audioFadeInOut, "delay", num * (1f - this.m_audioFadeInOut), "easetype", easeOutQuad, "onupdate", "AudioVolume_OnUpdate", "onupdatetarget", base.gameObject, "oncomplete", "AudioVolume_OnComplete", 
            "name", "barVolumeEnd"
         };
        Hashtable hashtable5 = iTween.Hash(objArray5);
        iTween.StopByName(base.gameObject, "barVolumeEnd");
        iTween.ValueTo(base.gameObject, hashtable5);
        object[] objArray6 = new object[] { "from", this.m_increasePitchStart, "to", this.m_increasePitchEnd, "time", num, "delay", 0, "easetype", easeOutQuad, "onupdate", "AudioPitch_OnUpdate", "onupdatetarget", base.gameObject, "name", "barPitch" };
        Hashtable hashtable6 = iTween.Hash(objArray6);
        iTween.StopByName(base.gameObject, "barPitch");
        iTween.ValueTo(base.gameObject, hashtable6);
    }

    private void Intensity_OnComplete()
    {
        iTween.StopByName(base.gameObject, "Increase");
        iTween.StopByName(base.gameObject, "Intensity");
        iTween.StopByName(base.gameObject, "UVSpeed");
        object[] args = new object[] { "from", this.m_maxIntensity, "to", this.m_barIntensity, "time", this.m_coolDownAnimTime, "easetype", iTween.EaseType.easeOutQuad, "onupdate", "Intensity_OnUpdate", "onupdatetarget", base.gameObject, "name", "Intensity" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(base.gameObject, hashtable);
        object[] objArray2 = new object[] { "from", 0.005f, "to", 0f, "time", this.m_coolDownAnimTime, "easetype", iTween.EaseType.easeOutQuad, "onupdate", "ScrollSpeed_OnUpdate", "onupdatetarget", base.gameObject, "name", "UVSpeed" };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.ValueTo(base.gameObject, hashtable2);
    }

    private void Intensity_OnUpdate(float val)
    {
        this.m_barMaterial.SetFloat("_Intensity", val);
    }

    private void Progress_OnUpdate(float val)
    {
        this.m_barMaterial.SetFloat("_Percent", val);
    }

    private void ScrollSpeed_OnUpdate(float val)
    {
        this.m_Uadd += val;
        this.m_barMaterial.SetFloat("_Uadd", this.m_Uadd);
    }

    public void SetLabel(string text)
    {
        if (this.m_uberLabel != null)
        {
            this.m_uberLabel.Text = text;
        }
        if (this.m_label != null)
        {
            this.m_label.text = text;
        }
    }

    public void SetProgressBar(float progress)
    {
        this.m_barMaterial.SetFloat("_Intensity", this.m_barIntensity);
        this.m_barMaterial.SetFloat("_Percent", progress);
    }
}

