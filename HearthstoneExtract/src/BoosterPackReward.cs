using System;
using UnityEngine;

public class BoosterPackReward : Reward
{
    public GameObject m_booster;
    public UnopenedPackStack m_MultipleStack;
    public GameObject m_root;
    public UnopenedPackStack m_SingleStack;

    protected override void HideReward()
    {
        this.m_root.SetActive(false);
    }

    protected override void InitData()
    {
        base.SetData(new BoosterPackRewardData(), false);
    }

    protected override void OnDataSet(bool updateVisuals)
    {
        if (updateVisuals)
        {
            this.UpdatePackStacks();
            string headline = GameStrings.Get("GAMEPLAY_REWARD_BOOSTER_HEADLINE");
            string details = string.Empty;
            string source = string.Empty;
            switch (base.Data.Origin)
            {
                case NetCache.ProfileNotice.NoticeOrigin.FORGE:
                {
                    int num = DraftManager.Get().GetWins() + 1;
                    object[] args = new object[] { num };
                    source = GameStrings.Format("GAMEPLAY_REWARD_BOOSTER_SOURCE_FORGE", args);
                    break;
                }
                case NetCache.ProfileNotice.NoticeOrigin.TOURNEY:
                {
                    NetCache.NetCacheRewardProgress netObject = NetCache.Get().GetNetObject<NetCache.NetCacheRewardProgress>();
                    object[] objArray2 = new object[] { netObject.WinsPerPack };
                    source = GameStrings.Format("GAMEPLAY_REWARD_BOOSTER_SOURCE_TOURNEY", objArray2);
                    break;
                }
                default:
                    source = string.Empty;
                    break;
            }
            base.SetRewardText(headline, details, source);
        }
    }

    protected override void ShowReward()
    {
        this.m_root.SetActive(true);
        this.UpdatePackStacks();
        Vector3 localScale = this.m_booster.transform.localScale;
        this.m_booster.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        object[] args = new object[] { "scale", localScale, "time", 0.5f, "easetype", iTween.EaseType.easeOutElastic };
        iTween.ScaleTo(this.m_booster.gameObject, iTween.Hash(args));
    }

    private void Start()
    {
        base.Hide();
    }

    private void UpdatePackStacks()
    {
        BoosterPackRewardData data = base.Data as BoosterPackRewardData;
        if (data == null)
        {
            Debug.LogWarning(string.Format("BoosterPackReward.UpdatePackStacks() - Data {0} is not CardRewardData", base.Data));
        }
        else
        {
            bool flag = data.Count > 1;
            this.m_SingleStack.m_RootObject.SetActive(!flag);
            this.m_MultipleStack.m_RootObject.SetActive(flag);
            if (flag)
            {
                this.m_MultipleStack.m_AmountText.text = data.Count.ToString();
            }
        }
    }
}

