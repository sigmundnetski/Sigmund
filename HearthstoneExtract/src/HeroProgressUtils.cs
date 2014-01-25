using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeroProgressUtils : MonoBehaviour
{
    public static NetCache.HeroLevel GetHeroLevel(TAG_CLASS heroClass)
    {
        <GetHeroLevel>c__AnonStorey147 storey = new <GetHeroLevel>c__AnonStorey147 {
            heroClass = heroClass
        };
        NetCache.NetCacheHeroLevels netObject = NetCache.Get().GetNetObject<NetCache.NetCacheHeroLevels>();
        if (netObject == null)
        {
            Debug.LogError("HeroProgressUtils.GetHeroLevel() - NetCache.NetCacheHeroLevels is null");
        }
        return netObject.Levels.Find(new Predicate<NetCache.HeroLevel>(storey.<>m__5D));
    }

    [CompilerGenerated]
    private sealed class <GetHeroLevel>c__AnonStorey147
    {
        internal TAG_CLASS heroClass;

        internal bool <>m__5D(NetCache.HeroLevel obj)
        {
            return (obj.Class == this.heroClass);
        }
    }
}

