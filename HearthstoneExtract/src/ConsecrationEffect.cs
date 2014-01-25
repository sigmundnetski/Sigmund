using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsecrationEffect : MonoBehaviour
{
    public float m_Bounceness = 0.2f;
    private GameObject m_CameraShaker;
    public GameObject m_EndImpact;
    public float m_HoverTime = 0.8f;
    private List<GameObject> m_ImpactObjects;
    private AudioSource m_ImpactSound;
    public float m_LiftHeightMax = 3f;
    public float m_LiftHeightMin = 2f;
    public float m_LiftRotMax = 15f;
    public float m_LiftRotMin = -15f;
    public float m_LiftTime = 1f;
    public float m_SlamTime = 0.2f;
    public float m_StartDelayMax = 3f;
    public float m_StartDelayMin = 2f;
    public GameObject m_StartImpact;
    private SuperSpell m_SuperSpell;
    public float m_TotalTime;

    private void CameraShakerFinished()
    {
        ShakeResetter.Get().DestroyShaker(this.m_CameraShaker);
    }

    private void Finished()
    {
        SoundManager.Get().Play(this.m_ImpactSound);
        this.m_CameraShaker = ShakeResetter.Get().CreateShaker(Camera.main.gameObject);
        object[] args = new object[] { "amount", new Vector3(0.15f, 0.15f, 0.15f), "name", "ConsecrationShake", "time", 0.9f, "easetype", iTween.EaseType.easeOutQuad, "looptype", iTween.LoopType.none, "oncomplete", "CameraShakerFinished" };
        iTween.ShakePosition(this.m_CameraShaker, iTween.Hash(args));
    }

    private void OnDestroy()
    {
        if (this.m_ImpactObjects.Count > 0)
        {
            foreach (GameObject obj2 in this.m_ImpactObjects)
            {
                UnityEngine.Object.Destroy(obj2);
            }
        }
    }

    private void Start()
    {
        Spell component = base.GetComponent<Spell>();
        if (component == null)
        {
            base.enabled = false;
        }
        this.m_SuperSpell = component.GetSuperSpellParent();
        this.m_ImpactSound = base.GetComponent<AudioSource>();
        this.m_ImpactObjects = new List<GameObject>();
    }

    private void StartAnimation()
    {
        if (this.m_SuperSpell != null)
        {
            int num = 0;
            foreach (GameObject obj2 in this.m_SuperSpell.GetTargets())
            {
                Vector3 position = obj2.transform.position;
                Quaternion rotation = obj2.transform.rotation;
                num++;
                float num2 = UnityEngine.Random.Range(this.m_StartDelayMin, this.m_StartDelayMax);
                GameObject item = (GameObject) UnityEngine.Object.Instantiate(this.m_StartImpact, position, rotation);
                this.m_ImpactObjects.Add(item);
                foreach (ParticleSystem system in item.GetComponentsInChildren<ParticleSystem>())
                {
                    system.startDelay = num2;
                    system.Play();
                }
                num2 += 0.2f;
                float num4 = UnityEngine.Random.Range(this.m_LiftHeightMin, this.m_LiftHeightMax);
                object[] args = new object[] { "time", this.m_LiftTime, "delay", num2, "position", new Vector3(position.x, position.y + num4, position.z), "easetype", iTween.EaseType.easeOutQuad, "onupdatetarget", base.gameObject, "name", string.Format("Lift_{0}_{1}", obj2.name, num) };
                Hashtable hashtable = iTween.Hash(args);
                iTween.MoveTo(obj2, hashtable);
                Vector3 eulerAngles = rotation.eulerAngles;
                eulerAngles.x += UnityEngine.Random.Range(this.m_LiftRotMin, this.m_LiftRotMax);
                eulerAngles.z += UnityEngine.Random.Range(this.m_LiftRotMin, this.m_LiftRotMax);
                object[] objArray2 = new object[] { "time", (this.m_LiftTime + this.m_HoverTime) + (this.m_SlamTime * 0.8f), "delay", num2, "rotation", eulerAngles, "easetype", iTween.EaseType.easeOutQuad, "onupdatetarget", base.gameObject, "name", string.Format("LiftRot_{0}_{1}", obj2.name, num) };
                Hashtable hashtable2 = iTween.Hash(objArray2);
                iTween.RotateTo(obj2, hashtable2);
                float num5 = this.m_StartDelayMax + this.m_LiftTime;
                float num6 = num5 + this.m_HoverTime;
                object[] objArray3 = new object[] { "time", this.m_SlamTime, "delay", num6, "position", position, "easetype", iTween.EaseType.easeInCubic, "onupdatetarget", base.gameObject, "name", string.Format("SlamPos_{0}_{1}", obj2.name, num) };
                Hashtable hashtable3 = iTween.Hash(objArray3);
                iTween.MoveTo(obj2, hashtable3);
                object[] objArray4 = new object[] { "time", this.m_SlamTime * 0.8f, "delay", num6 + (this.m_SlamTime * 0.2f), "rotation", Vector3.zero, "easetype", iTween.EaseType.easeInQuad, "onupdatetarget", base.gameObject, "oncomplete", "Finished", "oncompletetarget", base.gameObject, "name", string.Format("SlamRot_{0}_{1}", obj2.name, num) };
                Hashtable hashtable4 = iTween.Hash(objArray4);
                iTween.RotateTo(obj2, hashtable4);
                this.m_TotalTime = num6 + this.m_SlamTime;
                Bounce component = obj2.GetComponent<Bounce>();
                if (component == null)
                {
                    component = obj2.AddComponent<Bounce>();
                }
                component.m_BounceAmount = num4 * this.m_Bounceness;
                component.m_BounceSpeed = 3.5f * UnityEngine.Random.Range((float) 0.8f, (float) 1.3f);
                component.m_BounceCount = 3;
                component.m_Bounceness = this.m_Bounceness;
                component.m_Delay = num6 + this.m_SlamTime;
                component.StartAnimation();
                GameObject obj4 = (GameObject) UnityEngine.Object.Instantiate(this.m_EndImpact, position, rotation);
                this.m_ImpactObjects.Add(obj4);
                foreach (ParticleSystem system2 in obj4.GetComponentsInChildren<ParticleSystem>())
                {
                    system2.startDelay = num6 + this.m_SlamTime;
                    system2.Play();
                }
            }
        }
    }
}

