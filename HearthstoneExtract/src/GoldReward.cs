using System;
using System.Collections;
using UnityEngine;

public class GoldReward : Reward
{
    public GameObject m_coin;
    public GameObject m_root;

    protected override void HideReward()
    {
        this.m_root.SetActive(false);
    }

    protected override void InitData()
    {
        base.SetData(new GoldRewardData(), false);
    }

    protected override void OnDataSet(bool updateVisuals)
    {
        if (updateVisuals)
        {
            GoldRewardData data = base.Data as GoldRewardData;
            if (data == null)
            {
                Debug.LogWarning(string.Format("goldRewardData.SetData() - data {0} is not GoldRewardData", base.Data));
            }
            else
            {
                string headline = GameStrings.Get("GLOBAL_REWARD_GOLD_HEADLINE");
                string details = data.Amount.ToString();
                string source = string.Empty;
                base.SetRewardText(headline, details, source);
            }
        }
    }

    protected override void ShowReward()
    {
        GoldRewardData data = base.Data as GoldRewardData;
        NetCache.Get().OnGoldBalanceChanged(data.Amount);
        this.m_root.SetActive(true);
        Vector3 localScale = this.m_coin.transform.localScale;
        this.m_coin.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        object[] args = new object[] { "scale", localScale, "time", 0.5f, "easetype", iTween.EaseType.easeOutElastic };
        iTween.ScaleTo(this.m_coin.gameObject, iTween.Hash(args));
        this.m_coin.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
        object[] objArray2 = new object[] { "amount", new Vector3(0f, 0f, 540f), "time", 1.5f, "easeType", iTween.EaseType.easeOutElastic, "space", Space.Self };
        Hashtable hashtable = iTween.Hash(objArray2);
        iTween.RotateAdd(this.m_coin.gameObject, hashtable);
    }

    private void Start()
    {
        base.Hide();
    }
}

