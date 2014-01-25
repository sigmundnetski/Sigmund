using System;
using UnityEngine;

public class ArcaneDustReward : Reward
{
    public UberText m_dustCount;
    public GameObject m_dustJar;
    public GameObject m_root;

    protected override void HideReward()
    {
        this.m_root.SetActive(false);
    }

    protected override void InitData()
    {
        base.SetData(new ArcaneDustRewardData(), false);
    }

    protected override void OnDataSet(bool updateVisuals)
    {
        if (updateVisuals)
        {
            string headline = GameStrings.Get("GLOBAL_REWARD_ARCANE_DUST_HEADLINE");
            string details = string.Empty;
            string source = string.Empty;
            if (SceneMgr.Get().IsInGame())
            {
                NetCache.NetCacheRewardProgress netObject = NetCache.Get().GetNetObject<NetCache.NetCacheRewardProgress>();
                object[] args = new object[] { netObject.WinsPerPack };
                source = GameStrings.Format("GAMEPLAY_REWARD_BOOSTER_SOURCE_TOURNEY", args);
            }
            base.SetRewardText(headline, details, source);
        }
    }

    protected override void ShowReward()
    {
        ArcaneDustRewardData data = base.Data as ArcaneDustRewardData;
        NetCache.Get().OnArcaneDustBalanceChanged((long) data.Amount);
        if (CraftingManager.Get() != null)
        {
            CraftingManager.Get().AdjustLocalArcaneDustBalance(data.Amount);
            CraftingManager.Get().craftingUI.UpdateBankText();
        }
        this.m_root.SetActive(true);
        ArcaneDustRewardData data2 = base.Data as ArcaneDustRewardData;
        if (data2 == null)
        {
            Debug.LogWarning(string.Format("ArcaneDustReward.ShowReward() - Data {0} is not ArcaneDustRewardData", base.Data));
        }
        else
        {
            this.m_dustCount.Text = data2.Amount.ToString();
            Vector3 localScale = this.m_dustJar.transform.localScale;
            this.m_dustJar.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            object[] args = new object[] { "scale", localScale, "time", 0.5f, "easetype", iTween.EaseType.easeOutElastic };
            iTween.ScaleTo(this.m_dustJar.gameObject, iTween.Hash(args));
        }
    }

    private void Start()
    {
        base.Hide();
    }
}

