using System;
using System.Collections;
using UnityEngine;

public class MedalProgressBar : MonoBehaviour
{
    public float m_audioFadeInOut = 0.2f;
    public float m_coolDownXPAnimTime = 1f;
    public float m_decreaseXPAnimTime = 1f;
    public float m_increaseXPAnimTime = 2f;
    private int m_levelingUp;
    private float m_maxIntensity;
    public float m_maxProgressValue;
    public TournamentMedal m_medal;
    private NetCache.NetCacheMedalInfo m_medalInfo;
    public float m_minProgressValue;
    public GameObject m_ParticleEndPoint;
    private Vector3 m_particleEndPos;
    public GameObject m_ParticleLevelUpBurstObject;
    private float m_particleMag;
    public GameObject m_ParticleObject;
    private Vector3 m_particleOffset;
    public GameObject m_ParticleStartPoint;
    private Vector3 m_particleStartPos;
    private ParticleSystem m_particleSystem;
    private Vector3 m_particleVec;
    public GameObject m_progressBar;
    private float m_Uadd;
    public float m_xpBarIntensity = 1.2f;
    public float m_xpBarIntensityIncreaseMax = 3f;
    private Material m_xpBarMaterial;
    private float m_xpCurrVal;
    public float m_xpDecreasePitchEnd = 0.8f;
    public float m_xpDecreasePitchStart = 1f;
    private float m_xpFactor;
    public float m_xpIncreasePitchEnd = 1.2f;
    public float m_xpIncreasePitchStart = 1f;
    private float m_xpPrevVal;

    public void AnimateMedalProgress(NetCache.NetCacheMedalInfo medalInfo)
    {
        this.m_medalInfo = medalInfo;
        this.m_levelingUp = 0;
        if (this.m_progressBar != null)
        {
            this.m_xpPrevVal = medalInfo.PrevXP;
            this.m_xpCurrVal = medalInfo.CurrXP;
            object[] args = new object[] { this.m_xpPrevVal };
            Log.Kyle.Print("PrevXP = {0}", args);
            object[] objArray2 = new object[] { this.m_xpCurrVal };
            Log.Kyle.Print("CurrXP = {0}", objArray2);
            if (medalInfo.CurrMedal.MedalType > medalInfo.PrevMedal.MedalType)
            {
                this.LevelUp(medalInfo);
            }
            else
            {
                if (this.m_xpCurrVal > this.m_xpPrevVal)
                {
                    this.m_xpFactor = this.m_xpCurrVal - this.m_xpPrevVal;
                }
                else
                {
                    this.m_xpFactor = this.m_xpPrevVal - this.m_xpCurrVal;
                }
                this.m_xpFactor = Mathf.Abs(this.m_xpFactor);
                object[] objArray3 = new object[] { this.m_xpFactor };
                Log.Kyle.Print("xpFactor = {0}", objArray3);
                if (this.m_xpCurrVal > this.m_xpPrevVal)
                {
                    this.IncreaseXP(this.m_xpCurrVal, this.m_xpPrevVal);
                }
                else
                {
                    this.DecreaseXP(this.m_xpCurrVal, this.m_xpPrevVal);
                }
                if (this.m_medal != null)
                {
                    this.m_medal.SetMedal(medalInfo.CurrMedal);
                }
            }
        }
    }

    private void AudioPitch_OnUpdate(float val)
    {
        SoundManager.Get().SetPitch(base.audio, val);
    }

    private void AudioVolume_OnComplete(float val)
    {
        SoundManager.Get().Stop(base.audio);
    }

    private void AudioVolume_OnUpdate(float val)
    {
        SoundManager.Get().SetVolume(base.audio, val);
    }

    public void Awake()
    {
        this.m_xpBarMaterial = this.m_progressBar.renderer.material;
    }

    private void DecreaseXP(float currXP, float prevXP)
    {
        float num = this.m_decreaseXPAnimTime * this.m_xpFactor;
        iTween.EaseType easeInOutCubic = iTween.EaseType.easeInOutCubic;
        object[] args = new object[] { "from", prevXP, "to", currXP, "time", num, "easetype", easeInOutCubic, "onupdate", "XP_OnUpdate", "onupdatetarget", base.gameObject, "name", "DecreaseXP" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(this.m_progressBar.gameObject, "DecreaseXP");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable);
        SoundManager.Get().SetVolume(base.audio, 0f);
        SoundManager.Get().SetPitch(base.audio, this.m_xpDecreasePitchStart);
        SoundManager.Get().Play(base.audio);
        object[] objArray2 = new object[] { "from", 0, "to", 1, "time", num * this.m_audioFadeInOut, "delay", 0, "easetype", easeInOutCubic, "onupdate", "AudioVolume_OnUpdate", "onupdatetarget", base.gameObject, "name", "xpBarVolumeStart" };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.StopByName(this.m_progressBar.gameObject, "xpBarVolumeStart");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable2);
        object[] objArray3 = new object[] { 
            "from", 1, "to", 0, "time", num * this.m_audioFadeInOut, "delay", num * (1f - this.m_audioFadeInOut), "easetype", easeInOutCubic, "onupdate", "AudioVolume_OnUpdate", "onupdatetarget", base.gameObject, "oncomplete", "AudioVolume_OnComplete", 
            "name", "xpBarVolumeEnd"
         };
        Hashtable hashtable3 = iTween.Hash(objArray3);
        iTween.StopByName(this.m_progressBar.gameObject, "xpBarVolumeEnd");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable3);
        object[] objArray4 = new object[] { "from", this.m_xpDecreasePitchStart, "to", this.m_xpDecreasePitchEnd, "time", num, "delay", 0, "easetype", easeInOutCubic, "onupdate", "AudioPitch_OnUpdate", "onupdatetarget", base.gameObject, "name", "xpBarPitch" };
        Hashtable hashtable4 = iTween.Hash(objArray4);
        iTween.StopByName(this.m_progressBar.gameObject, "xpBarPitch");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable4);
    }

    private void IncreaseXP(float currXP, float prevXP)
    {
        this.m_particleStartPos = this.m_ParticleStartPoint.transform.localPosition;
        this.m_particleEndPos = this.m_ParticleEndPoint.transform.localPosition;
        this.m_particleSystem = this.m_ParticleObject.GetComponent<ParticleSystem>();
        if ((this.m_particleSystem != null) && this.m_particleSystem.gameObject.activeInHierarchy)
        {
            this.m_particleSystem.Play();
            this.m_particleSystem.enableEmission = true;
        }
        float num = this.m_increaseXPAnimTime * this.m_xpFactor;
        if (this.m_levelingUp == 2)
        {
            num = (this.m_increaseXPAnimTime * this.m_xpFactor) * 1.2f;
            this.m_levelingUp = 0;
        }
        iTween.EaseType easeOutQuad = iTween.EaseType.easeOutQuad;
        if (this.m_levelingUp == 1)
        {
            easeOutQuad = iTween.EaseType.linear;
        }
        object[] args = new object[] { "from", prevXP, "to", currXP, "time", num, "easetype", easeOutQuad, "onupdate", "XP_OnUpdate", "onupdatetarget", base.gameObject, "name", "IncreaseXP" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(this.m_progressBar.gameObject, "IncreaseXP");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable);
        object[] objArray2 = new object[] { "from", 0f, "to", 0.005f, "time", num, "easetype", iTween.EaseType.easeOutQuad, "onupdate", "XPScrollSpeed_OnUpdate", "onupdatetarget", base.gameObject, "name", "UVSpeedXP" };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.StopByName(this.m_progressBar.gameObject, "UVSpeedXP");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable2);
        object[] objArray3 = new object[] { "from", prevXP, "to", currXP, "time", num, "easetype", easeOutQuad, "onupdate", "ParticlePosition_OnUpdate", "onupdatetarget", base.gameObject, "name", "xpParticlePos" };
        Hashtable hashtable3 = iTween.Hash(objArray3);
        iTween.StopByName(this.m_progressBar.gameObject, "xpParticlePos");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable3);
        object[] objArray4 = new object[] { "from", 50, "to", 500, "time", num * 0.3f, "easetype", easeOutQuad, "onupdate", "ParticleEmission_OnUpdate", "onupdatetarget", base.gameObject, "name", "xpParticleEmission" };
        Hashtable hashtable4 = iTween.Hash(objArray4);
        iTween.StopByName(this.m_progressBar.gameObject, "xpParticleEmission");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable4);
        object[] objArray5 = new object[] { "from", 500, "to", 0, "time", num * 0.2f, "delay", num * 0.7f, "easetype", easeOutQuad, "onupdate", "ParticleEmission_OnUpdate", "onupdatetarget", base.gameObject, "name", "xpParticleEmissionEnd" };
        Hashtable hashtable5 = iTween.Hash(objArray5);
        iTween.StopByName(this.m_progressBar.gameObject, "xpParticleEmissionEnd");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable5);
        if (this.m_levelingUp == 1)
        {
            this.m_maxIntensity = this.m_xpBarIntensityIncreaseMax + 1f;
        }
        else
        {
            this.m_maxIntensity = this.m_xpBarIntensity + ((this.m_xpBarIntensityIncreaseMax - this.m_xpBarIntensity) * this.m_xpFactor);
        }
        object[] objArray6 = new object[] { 
            "from", this.m_xpBarIntensity, "to", this.m_maxIntensity, "time", num, "easetype", easeOutQuad, "onupdate", "XPIntensity_OnUpdate", "onupdatetarget", base.gameObject, "name", "XPIntensity", "oncomplete", "XPIntensity_OnComplete", 
            "oncompletetarget", base.gameObject
         };
        Hashtable hashtable6 = iTween.Hash(objArray6);
        iTween.StopByName(this.m_progressBar.gameObject, "XPIntensity");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable6);
        SoundManager.Get().SetVolume(base.audio, 0f);
        SoundManager.Get().SetPitch(base.audio, this.m_xpIncreasePitchStart);
        SoundManager.Get().Play(base.audio);
        object[] objArray7 = new object[] { "from", 0, "to", 1, "time", num * this.m_audioFadeInOut, "delay", 0, "easetype", easeOutQuad, "onupdate", "AudioVolume_OnUpdate", "onupdatetarget", base.gameObject, "name", "xpBarVolumeStart" };
        Hashtable hashtable7 = iTween.Hash(objArray7);
        iTween.StopByName(this.m_progressBar.gameObject, "xpBarVolumeStart");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable7);
        object[] objArray8 = new object[] { 
            "from", 1, "to", 0, "time", num * this.m_audioFadeInOut, "delay", num * (1f - this.m_audioFadeInOut), "easetype", easeOutQuad, "onupdate", "AudioVolume_OnUpdate", "onupdatetarget", base.gameObject, "oncomplete", "AudioVolume_OnComplete", 
            "name", "xpBarVolumeEnd"
         };
        Hashtable hashtable8 = iTween.Hash(objArray8);
        iTween.StopByName(this.m_progressBar.gameObject, "xpBarVolumeEnd");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable8);
        object[] objArray9 = new object[] { "from", this.m_xpIncreasePitchStart, "to", this.m_xpIncreasePitchEnd, "time", num, "delay", 0, "easetype", easeOutQuad, "onupdate", "AudioPitch_OnUpdate", "onupdatetarget", base.gameObject, "name", "xpBarPitch" };
        Hashtable hashtable9 = iTween.Hash(objArray9);
        iTween.StopByName(this.m_progressBar.gameObject, "xpBarPitch");
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable9);
    }

    private void LevelUp(NetCache.NetCacheMedalInfo medalInfo)
    {
        this.m_medal.SetMedal(this.m_medalInfo.PrevMedal);
        this.m_medal.AnimateRank(this.m_medalInfo.CurrMedal, this.m_medalInfo.PrevMedal);
    }

    private void LevelUpPart2()
    {
        this.m_levelingUp = 2;
        if (this.m_ParticleLevelUpBurstObject != null)
        {
            this.m_ParticleLevelUpBurstObject.transform.localPosition = this.m_particleEndPos;
            this.m_ParticleLevelUpBurstObject.GetComponent<ParticleSystem>().Play();
        }
        this.m_medal.AnimateRank(this.m_medalInfo.CurrMedal, this.m_medalInfo.PrevMedal);
        object[] args = new object[] { 
            "from", this.m_maxIntensity, "to", 0f, "time", this.m_coolDownXPAnimTime * 2f, "easetype", iTween.EaseType.easeOutQuad, "onupdate", "XPIntensity_OnUpdate", "onupdatetarget", base.gameObject, "oncomplete", "LevelUpPart3", "oncompletetarget", base.gameObject, 
            "name", "XPIntensity"
         };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable);
        object[] objArray2 = new object[] { "from", 0.005f, "to", 0f, "time", this.m_coolDownXPAnimTime * 2f, "easetype", iTween.EaseType.easeOutQuad, "onupdate", "XPScrollSpeed_OnUpdate", "onupdatetarget", base.gameObject, "name", "UVSpeedXP" };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.ValueTo(this.m_progressBar.gameObject, hashtable2);
    }

    private void LevelUpPart3()
    {
        this.m_levelingUp = 2;
        this.m_xpFactor = this.m_xpCurrVal;
        this.IncreaseXP(this.m_medalInfo.CurrXP, 0f);
    }

    private void ParticleEmission_OnUpdate(float val)
    {
        this.m_particleSystem.emissionRate = val;
    }

    private void ParticlePosition_OnUpdate(float val)
    {
        this.m_ParticleObject.transform.localPosition = Vector3.Lerp(this.m_particleStartPos, this.m_particleEndPos, val);
    }

    public void SetMedalProgress(NetCache.NetCacheMedalInfo medalInfo)
    {
        this.m_medalInfo = medalInfo;
        this.SetProgressBar(medalInfo.CurrXP);
        this.m_medal.SetMedal(medalInfo.CurrMedal);
    }

    private void SetProgressBar(float xp)
    {
    }

    public void TestLevelUp()
    {
        NetCache.NetCacheMedalInfo medalInfo = new NetCache.NetCacheMedalInfo {
            CurrMedal = new Medal(Medal.Type.MEDAL_PLATINUM_A),
            PrevMedal = new Medal(Medal.Type.MEDAL_GOLD_C),
            CurrXP = 0.3f,
            PrevXP = 0.7f
        };
        this.AnimateMedalProgress(medalInfo);
    }

    public void TestXPdecrease()
    {
        NetCache.NetCacheMedalInfo medalInfo = new NetCache.NetCacheMedalInfo {
            CurrMedal = new Medal(Medal.Type.MEDAL_COPPER_C),
            PrevMedal = new Medal(Medal.Type.MEDAL_COPPER_C),
            CurrXP = 0.2f,
            PrevXP = 0.9f
        };
        this.AnimateMedalProgress(medalInfo);
    }

    public void TestXPincrease()
    {
        NetCache.NetCacheMedalInfo medalInfo = new NetCache.NetCacheMedalInfo {
            CurrMedal = new Medal(Medal.Type.MEDAL_GOLD_A),
            PrevMedal = new Medal(Medal.Type.MEDAL_GOLD_A),
            CurrXP = 0.9f,
            PrevXP = 0.4f
        };
        this.AnimateMedalProgress(medalInfo);
    }

    private void XP_OnUpdate(float val)
    {
        this.m_xpBarMaterial.SetFloat("_Percent", val);
    }

    private void XPIntensity_OnComplete()
    {
        iTween.StopByName(this.m_progressBar.gameObject, "IncreaseXP");
        iTween.StopByName(this.m_progressBar.gameObject, "XPIntensity");
        iTween.StopByName(this.m_progressBar.gameObject, "UVSpeedXP");
        iTween.StopByName(this.m_progressBar.gameObject, "xpParticlePos");
        iTween.StopByName(this.m_progressBar.gameObject, "xpParticleEmission");
        iTween.StopByName(this.m_progressBar.gameObject, "xpParticleEmissionEnd");
        if (this.m_particleSystem != null)
        {
            this.m_particleSystem.Stop();
            this.m_particleSystem.enableEmission = false;
            this.m_ParticleObject.transform.position = Vector3.zero;
        }
        if (this.m_levelingUp == 1)
        {
            this.LevelUpPart2();
        }
        else
        {
            object[] args = new object[] { "from", this.m_maxIntensity, "to", this.m_xpBarIntensity, "time", this.m_coolDownXPAnimTime, "easetype", iTween.EaseType.easeOutQuad, "onupdate", "XPIntensity_OnUpdate", "onupdatetarget", base.gameObject, "name", "XPIntensity" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.ValueTo(this.m_progressBar.gameObject, hashtable);
            object[] objArray2 = new object[] { "from", 0.005f, "to", 0f, "time", this.m_coolDownXPAnimTime, "easetype", iTween.EaseType.easeOutQuad, "onupdate", "XPScrollSpeed_OnUpdate", "onupdatetarget", base.gameObject, "name", "UVSpeedXP" };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.ValueTo(this.m_progressBar.gameObject, hashtable2);
        }
    }

    private void XPIntensity_OnUpdate(float val)
    {
        this.m_xpBarMaterial.SetFloat("_Intensity", val);
    }

    private void XPScrollSpeed_OnUpdate(float val)
    {
        this.m_Uadd += val;
        this.m_xpBarMaterial.SetFloat("_Uadd", this.m_Uadd);
    }
}

