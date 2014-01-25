using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class RewardUtils
{
    public static void AcknowledgeAllRewards()
    {
        NetCache.NetCacheProfileNotices netObject = NetCache.Get().GetNetObject<NetCache.NetCacheProfileNotices>();
        if (netObject == null)
        {
            Debug.LogError("RewardUtils.AcknowledgeAllRewards(): netCacheNotices is null");
        }
        else
        {
            List<long> list = new List<long>();
        Label_0087:
            foreach (NetCache.ProfileNotice notice in netObject.Notices)
            {
                switch (notice.Type)
                {
                    case NetCache.ProfileNotice.NoticeType.REWARD_BOOSTER:
                    case NetCache.ProfileNotice.NoticeType.REWARD_CARD:
                    case NetCache.ProfileNotice.NoticeType.PRECON_DECK:
                    case NetCache.ProfileNotice.NoticeType.REWARD_DUST:
                    case NetCache.ProfileNotice.NoticeType.REWARD_MOUNT:
                    case NetCache.ProfileNotice.NoticeType.REWARD_FORGE:
                    case NetCache.ProfileNotice.NoticeType.REWARD_GOLD:
                        list.Add(notice.NoticeID);
                        goto Label_0087;
                }
                goto Label_0087;
            }
            foreach (long num in list)
            {
                Network.AckNotice(num);
            }
        }
    }

    private static void AddRewardDataToList(RewardData newRewardData, List<RewardData> existingRewardDataList)
    {
        CardRewardData duplicateCardDataReward = GetDuplicateCardDataReward(newRewardData, existingRewardDataList);
        if (duplicateCardDataReward == null)
        {
            existingRewardDataList.Add(newRewardData);
        }
        else
        {
            CardRewardData other = newRewardData as CardRewardData;
            duplicateCardDataReward.Merge(other);
        }
    }

    private static CardRewardData GetDuplicateCardDataReward(RewardData newRewardData, List<RewardData> existingRewardData)
    {
        <GetDuplicateCardDataReward>c__AnonStorey13E storeye = new <GetDuplicateCardDataReward>c__AnonStorey13E();
        if (!(newRewardData is CardRewardData))
        {
            return null;
        }
        storeye.newCardRewardData = newRewardData as CardRewardData;
        return (existingRewardData.Find(new Predicate<RewardData>(storeye.<>m__44)) as CardRewardData);
    }

    public static List<RewardData> GetRewards(List<NetCache.ProfileNotice> notices)
    {
        List<RewardData> existingRewardDataList = new List<RewardData>();
        foreach (NetCache.ProfileNotice notice in notices)
        {
            RewardData newRewardData = null;
            switch (notice.Type)
            {
                case NetCache.ProfileNotice.NoticeType.REWARD_BOOSTER:
                {
                    NetCache.ProfileNoticeRewardBooster booster = notice as NetCache.ProfileNoticeRewardBooster;
                    BoosterPackRewardData data2 = new BoosterPackRewardData(booster.BoosterType, booster.Count);
                    newRewardData = data2;
                    break;
                }
                case NetCache.ProfileNotice.NoticeType.REWARD_CARD:
                {
                    NetCache.ProfileNoticeRewardCard card = notice as NetCache.ProfileNoticeRewardCard;
                    CardRewardData data3 = new CardRewardData(card.CardID, card.Premium, 1);
                    newRewardData = data3;
                    break;
                }
                case ((NetCache.ProfileNotice.NoticeType) 4):
                {
                    continue;
                }
                case NetCache.ProfileNotice.NoticeType.PRECON_DECK:
                {
                    NetCache.ProfileNoticePreconDeck deck = notice as NetCache.ProfileNoticePreconDeck;
                    CardRewardData data4 = new CardRewardData(CardManifest.Get().Find(deck.HeroAsset).CardID, CardFlair.PremiumType.STANDARD, 1);
                    newRewardData = data4;
                    break;
                }
                case NetCache.ProfileNotice.NoticeType.REWARD_DUST:
                {
                    NetCache.ProfileNoticeRewardDust dust = notice as NetCache.ProfileNoticeRewardDust;
                    ArcaneDustRewardData data5 = new ArcaneDustRewardData(dust.Amount);
                    newRewardData = data5;
                    break;
                }
                case NetCache.ProfileNotice.NoticeType.REWARD_MOUNT:
                {
                    NetCache.ProfileNoticeRewardMount mount = notice as NetCache.ProfileNoticeRewardMount;
                    MountRewardData data6 = new MountRewardData((MountRewardData.MountType) mount.MountID);
                    newRewardData = data6;
                    break;
                }
                case NetCache.ProfileNotice.NoticeType.REWARD_FORGE:
                {
                    NetCache.ProfileNoticeRewardForge forge = notice as NetCache.ProfileNoticeRewardForge;
                    ForgeTicketRewardData data7 = new ForgeTicketRewardData(forge.Quantity);
                    newRewardData = data7;
                    break;
                }
                case NetCache.ProfileNotice.NoticeType.REWARD_GOLD:
                {
                    NetCache.ProfileNoticeRewardGold gold = notice as NetCache.ProfileNoticeRewardGold;
                    GoldRewardData data8 = new GoldRewardData((long) gold.Amount);
                    newRewardData = data8;
                    break;
                }
                default:
                {
                    continue;
                }
            }
            if (newRewardData != null)
            {
                newRewardData.SetOrigin(notice.Origin, notice.OriginData);
                newRewardData.AddNoticeID(notice.NoticeID);
                AddRewardDataToList(newRewardData, existingRewardDataList);
            }
        }
        return existingRewardDataList;
    }

    public static bool GetWinRewardProgress(out Reward.Type rewardType, out int rewardAmount, out int numWinsForReward, out int rewardProgress, out bool isLastRewardOfType)
    {
        rewardType = Reward.Type.BOOSTER_PACK;
        rewardAmount = 0;
        numWinsForReward = 0;
        rewardProgress = 0;
        isLastRewardOfType = false;
        NetCache.NetCacheRewardProgress netObject = NetCache.Get().GetNetObject<NetCache.NetCacheRewardProgress>();
        if (netObject == null)
        {
            Debug.LogError("RewardUtils.GetNumWinsToNextReward(): netCacheRewardProgress is null");
            return false;
        }
        NetCache.NetCacheMedalInfo info = NetCache.Get().GetNetObject<NetCache.NetCacheMedalInfo>();
        if (info == null)
        {
            Debug.LogError("RewardUtils.GetNumWinsToNextReward(): netCacheMedalInfo is null");
            return false;
        }
        int num = netObject.MaxPackRewards * netObject.WinsPerPack;
        if (info.SeasonWins <= num)
        {
            rewardType = Reward.Type.BOOSTER_PACK;
            rewardAmount = netObject.PacksPerReward;
            numWinsForReward = netObject.WinsPerPack;
            rewardProgress = info.SeasonWins % numWinsForReward;
            if (rewardProgress == 0)
            {
                isLastRewardOfType = info.SeasonWins == num;
                rewardProgress = netObject.WinsPerPack;
            }
            return true;
        }
        int num2 = info.SeasonWins - num;
        if ((netObject.MaxDustRewards != 0) && (num2 > netObject.MaxDustRewards))
        {
            return false;
        }
        rewardType = Reward.Type.ARCANE_DUST;
        rewardAmount = netObject.DustPerReward;
        numWinsForReward = netObject.WinsPerDust;
        rewardProgress = num2 % numWinsForReward;
        if (rewardProgress == 0)
        {
            isLastRewardOfType = (netObject.MaxDustRewards != 0) && (num2 == netObject.MaxDustRewards);
            rewardProgress = netObject.WinsPerDust;
        }
        return true;
    }

    [CompilerGenerated]
    private sealed class <GetDuplicateCardDataReward>c__AnonStorey13E
    {
        internal CardRewardData newCardRewardData;

        internal bool <>m__44(RewardData obj)
        {
            if (!(obj is CardRewardData))
            {
                return false;
            }
            CardRewardData data = obj as CardRewardData;
            if (!data.CardID.Equals(this.newCardRewardData.CardID))
            {
                return false;
            }
            if (!data.Premium.Equals(this.newCardRewardData.Premium))
            {
                return false;
            }
            if (!data.Origin.Equals(this.newCardRewardData.Origin))
            {
                return false;
            }
            return data.OriginData.Equals(this.newCardRewardData.OriginData);
        }
    }
}

