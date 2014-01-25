using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TournamentMedal : PegUIElement
{
    public float m_coolDownTime = 2f;
    private Material m_glowMat;
    public GameObject m_glowPlane;
    private Medal m_medal;
    private List<Vector2> m_medalOffsets = new List<Vector2>();
    public GameObject m_star1;
    public GameObject m_star2;
    public GameObject m_star3;

    public void AnimateRank(Medal currMedal, Medal prevMedal)
    {
        this.SetMedal(currMedal);
        if (this.m_glowPlane == null)
        {
            Debug.LogWarning("Medals glow plane not defined. Level up animation will not play");
        }
        else
        {
            int num2;
            SoundManager.Get().LoadAndPlay("level_up");
            ParticleSystem[] componentsInChildren = base.GetComponentsInChildren<ParticleSystem>();
            if (componentsInChildren != null)
            {
                foreach (ParticleSystem system in componentsInChildren)
                {
                    if (system.gameObject.activeInHierarchy)
                    {
                        system.Play();
                    }
                }
            }
            this.m_glowMat = this.m_glowPlane.renderer.material;
            this.GetMedalOffset(currMedal, out num2);
            this.m_glowMat.SetTextureOffset("_MainTex", this.m_medalOffsets[num2]);
            this.m_glowPlane.renderer.enabled = true;
            object[] args = new object[] { "amount", new Vector3(0.15f, 0.15f, 0.15f), "name", "MedalLevelUpShake", "time", 0.15f, "delay", 0, "axis", "none" };
            iTween.ShakePosition(Camera.mainCamera.gameObject, iTween.Hash(args));
            object[] objArray2 = new object[] { 
                "from", 1.5f, "to", 0f, "time", this.m_coolDownTime, "easetype", iTween.EaseType.easeOutCubic, "onupdate", "AnimateRank_OnUpdate", "onupdatetarget", base.gameObject, "name", "metalIntensity", "oncomplete", "AnimateRank_Complete", 
                "oncompletetarget", base.gameObject
             };
            Hashtable hashtable = iTween.Hash(objArray2);
            iTween.StopByName(base.gameObject, "metalIntensity");
            iTween.ValueTo(base.gameObject, hashtable);
        }
    }

    private void AnimateRank_Complete()
    {
        this.m_glowPlane.renderer.enabled = false;
        if (!Options.Get().GetBool(Option.HAS_SEEN_NEW_MEDAL, false))
        {
            Options.Get().SetBool(Option.HAS_SEEN_NEW_MEDAL, true);
        }
    }

    private void AnimateRank_OnUpdate(float val)
    {
        this.m_glowMat.SetFloat("_Intensity", val);
    }

    protected override void Awake()
    {
        base.Awake();
        this.m_medalOffsets.Add(new Vector2(0f, 0f));
        this.m_medalOffsets.Add(new Vector2(0.5f, 0f));
        this.m_medalOffsets.Add(new Vector2(0.75f, 0f));
        this.m_medalOffsets.Add(new Vector2(0.75f, 0f));
        this.m_medalOffsets.Add(new Vector2(0.75f, 0f));
        this.m_medalOffsets.Add(new Vector2(0f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0.25f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0.25f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0.25f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0.5f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0.5f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0.5f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0.75f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0.75f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0.75f, -0.25f));
        this.m_medalOffsets.Add(new Vector2(0f, -0.5f));
        this.m_medalOffsets.Add(new Vector2(0f, -0.5f));
        this.m_medalOffsets.Add(new Vector2(0f, -0.5f));
        this.m_medalOffsets.Add(new Vector2(0.25f, -0.5f));
        this.m_star1.SetActive(false);
        this.m_star2.SetActive(false);
        this.m_star3.SetActive(false);
        this.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.MedalOver));
        this.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.MedalOut));
    }

    private bool GetMedalOffset(Medal medal, out int offset)
    {
        offset = !medal.IsGrandMaster() ? ((int) medal.MedalType) : (this.m_medalOffsets.Count - 1);
        if (offset >= this.m_medalOffsets.Count)
        {
            Debug.LogWarning(string.Format("TournamentMedal.GetMedalOffset: {0} that doesn't have a texture offset", medal));
            return false;
        }
        return true;
    }

    private void MedalOut(UIEvent e)
    {
        base.gameObject.GetComponent<TooltipZone>().HideTooltip();
    }

    private void MedalOver(UIEvent e)
    {
        float num;
        object[] args = new object[] { this.m_medal.GetMedalName() };
        string headline = GameStrings.Format("GLOBAL_MEDAL_TOOLTIP_HEADER", args);
        object[] objArray2 = new object[] { this.m_medal.GetNextMedalName() };
        string bodytext = GameStrings.Format("GLOBAL_MEDAL_TOOLTIP_BODY", objArray2);
        if (SceneMgr.Get().IsInGame())
        {
            num = 0.3f;
        }
        else if (SceneMgr.Get().IsModeRequested(SceneMgr.Mode.HUB))
        {
            num = 6f;
        }
        else
        {
            num = 3f;
        }
        base.gameObject.GetComponent<TooltipZone>().ShowTooltip(headline, bodytext, num);
    }

    public void SetMedal(Medal medal)
    {
        int num;
        if (!this.GetMedalOffset(medal, out num))
        {
            Debug.LogWarning(string.Format("Trying to assign a medal {0} that doesn't have a texture offset", medal));
        }
        else
        {
            this.m_medal = medal;
            base.renderer.material.SetTextureOffset("_MainTex", this.m_medalOffsets[num]);
            int numStars = medal.GetNumStars();
            bool flag = 1 <= numStars;
            bool flag2 = 2 <= numStars;
            bool flag3 = 3 <= numStars;
            this.m_star1.SetActive(flag);
            this.m_star2.SetActive(flag2);
            this.m_star3.SetActive(flag3);
        }
    }
}

