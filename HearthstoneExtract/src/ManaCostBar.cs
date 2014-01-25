using System;
using System.Collections;
using UnityEngine;

public class ManaCostBar : MonoBehaviour
{
    public float m_BarIntensity = 1.6f;
    private Material m_barMaterial;
    public float m_coolDownAnimTime = 1f;
    private float m_currentVal;
    private float m_factor;
    public float m_increaseAnimTime = 2f;
    public GameObject m_manaCostBarObject;
    public float m_maxIntensity = 2f;
    public float m_maxValue = 10f;
    public GameObject m_ParticleEnd;
    private Vector3 m_particleEndPoint = Vector3.zero;
    public GameObject m_ParticleImpact;
    public GameObject m_ParticleObject;
    public GameObject m_ParticleStart;
    private Vector3 m_particleStartPoint = Vector3.zero;
    private float m_previousVal;

    public void AnimateBar(float newValue)
    {
        if (newValue == 0f)
        {
            this.SetBarValue(0f);
        }
        else
        {
            this.m_currentVal = newValue / this.m_maxValue;
            if ((this.m_manaCostBarObject != null) && (this.m_currentVal != this.m_previousVal))
            {
                if (this.m_currentVal > this.m_previousVal)
                {
                    this.m_factor = this.m_currentVal - this.m_previousVal;
                }
                else
                {
                    this.m_factor = this.m_previousVal - this.m_currentVal;
                }
                this.m_factor = Mathf.Abs(this.m_factor);
                if (this.m_currentVal > this.m_previousVal)
                {
                    this.IncreaseBar(this.m_currentVal, this.m_previousVal);
                }
                else
                {
                    this.DecreaseBar(this.m_currentVal, this.m_previousVal);
                }
                this.m_previousVal = this.m_currentVal;
            }
        }
    }

    private void BarPercent_OnUpdate(float val)
    {
        this.m_barMaterial.SetFloat("_Percent", val);
    }

    private void CoolDown()
    {
        object[] args = new object[] { 
            "from", this.m_maxIntensity, "to", this.m_BarIntensity, "time", this.m_coolDownAnimTime, "easetype", iTween.EaseType.easeOutQuad, "onupdate", "Intensity_OnUpdate", "onupdatetarget", base.gameObject, "name", "CoolDownIntensity", "oncomplete", "CoolDown_OnComplete", 
            "oncompletetarget", base.gameObject
         };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(this.m_manaCostBarObject.gameObject, "CoolDownIntensity");
        iTween.ValueTo(this.m_manaCostBarObject.gameObject, hashtable);
    }

    private void CoolDown_OnComplete()
    {
        iTween.StopByName(this.m_manaCostBarObject.gameObject, "CoolDownIntensity");
    }

    private void Decrease_OnComplete()
    {
    }

    private void DecreaseBar(float newVal, float prevVal)
    {
        float num = this.m_increaseAnimTime * this.m_factor;
        this.PlayParticles(true);
        iTween.EaseType easeOutQuad = iTween.EaseType.easeOutQuad;
        object[] args = new object[] { "from", prevVal, "to", newVal, "time", num, "easetype", easeOutQuad, "onupdate", "BarPercent_OnUpdate", "oncomplete", "Decrease_OnComplete", "onupdatetarget", base.gameObject, "name", "IncreaseBarPercent" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(this.m_manaCostBarObject.gameObject, "IncreaseBarPercent");
        iTween.ValueTo(this.m_manaCostBarObject.gameObject, hashtable);
        object[] objArray2 = new object[] { "from", prevVal, "to", newVal, "time", num, "easetype", easeOutQuad, "onupdate", "ParticlePosition_OnUpdate", "onupdatetarget", base.gameObject, "name", "ParticlePos" };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.StopByName(this.m_manaCostBarObject.gameObject, "ParticlePos");
        iTween.ValueTo(this.m_manaCostBarObject.gameObject, hashtable2);
    }

    private void Increase_OnComplete()
    {
        if (this.m_ParticleImpact != null)
        {
            this.m_ParticleImpact.particleSystem.Play();
        }
        this.CoolDown();
    }

    private void IncreaseBar(float newVal, float prevVal)
    {
        float num = this.m_increaseAnimTime * this.m_factor;
        this.PlayParticles(true);
        iTween.EaseType easeInQuad = iTween.EaseType.easeInQuad;
        object[] args = new object[] { 
            "from", prevVal, "to", newVal, "time", num, "easetype", easeInQuad, "onupdate", "BarPercent_OnUpdate", "oncomplete", "Increase_OnComplete", "oncompletetarget", base.gameObject, "onupdatetarget", base.gameObject, 
            "name", "IncreaseBarPercent"
         };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(this.m_manaCostBarObject.gameObject, "IncreaseBarPercent");
        iTween.ValueTo(this.m_manaCostBarObject.gameObject, hashtable);
        object[] objArray2 = new object[] { "from", prevVal, "to", newVal, "time", num, "easetype", easeInQuad, "onupdate", "ParticlePosition_OnUpdate", "onupdatetarget", base.gameObject, "name", "ParticlePos" };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.StopByName(this.m_manaCostBarObject.gameObject, "ParticlePos");
        iTween.ValueTo(this.m_manaCostBarObject.gameObject, hashtable2);
        object[] objArray3 = new object[] { "from", this.m_BarIntensity, "to", this.m_maxIntensity, "time", num, "easetype", easeInQuad, "onupdate", "Intensity_OnUpdate", "onupdatetarget", base.gameObject, "name", "Intensity" };
        Hashtable hashtable3 = iTween.Hash(objArray3);
        iTween.StopByName(this.m_manaCostBarObject.gameObject, "Intensity");
        iTween.ValueTo(this.m_manaCostBarObject.gameObject, hashtable3);
    }

    private void Intensity_OnUpdate(float val)
    {
        this.m_barMaterial.SetFloat("_Intensity", val);
    }

    private void ParticlePosition_OnUpdate(float val)
    {
        this.m_ParticleObject.transform.localPosition = Vector3.Lerp(this.m_particleStartPoint, this.m_particleEndPoint, val);
    }

    private void PlayParticles(bool state)
    {
        foreach (ParticleSystem system in this.m_ParticleObject.GetComponentsInChildren<ParticleSystem>())
        {
            if (state && (system != this.m_ParticleImpact.particleSystem))
            {
                system.Play();
            }
            else
            {
                system.Stop();
            }
            system.enableEmission = state;
        }
    }

    public void SetBar(float newValue)
    {
        this.m_currentVal = newValue / this.m_maxValue;
        this.SetBarValue(this.m_currentVal);
        this.m_previousVal = this.m_currentVal;
    }

    private void SetBarValue(float val)
    {
        this.m_currentVal = val / this.m_maxValue;
        if ((this.m_manaCostBarObject != null) && (this.m_currentVal != this.m_previousVal))
        {
            this.BarPercent_OnUpdate(val);
            this.ParticlePosition_OnUpdate(val);
            if (val == 0f)
            {
                this.PlayParticles(false);
            }
            this.m_previousVal = this.m_currentVal;
        }
    }

    private void Start()
    {
        if (this.m_manaCostBarObject == null)
        {
            base.enabled = false;
        }
        if (this.m_ParticleStart != null)
        {
            this.m_particleStartPoint = this.m_ParticleStart.transform.localPosition;
        }
        if (this.m_ParticleEnd != null)
        {
            this.m_particleEndPoint = this.m_ParticleEnd.transform.localPosition;
        }
        this.m_barMaterial = this.m_manaCostBarObject.renderer.material;
        this.m_barMaterial.SetFloat("_Seed", UnityEngine.Random.Range((float) 0f, (float) 1f));
    }

    public void TestDecrease()
    {
        this.AnimateBar(6f);
    }

    public void TestIncrease()
    {
        this.AnimateBar(7f);
    }

    public void TestReset()
    {
        this.SetBar(4f);
    }

    private void Update()
    {
    }
}

