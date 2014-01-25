using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MassDisenchant : MonoBehaviour
{
    [CompilerGenerated]
    private static Predicate<CollectionCardStack.ArtStack> <>f__am$cacheE;
    public UberText m_detailsHeadlineText;
    public UberText m_detailsText;
    public NormalButton m_disenchantButton;
    public List<DisenchantBar> m_doubleDisenchantBars;
    public GameObject m_doubleRoot;
    public UberText m_doubleSubHeadlineText;
    public UberText m_headlineText;
    public GameObject m_root;
    public List<DisenchantBar> m_singleDisenchantBars;
    public GameObject m_singleRoot;
    public UberText m_singleSubHeadlineText;
    private int m_totalAmount;
    public UberText m_totalAmountText;
    private bool m_useSingle = true;

    private void Awake()
    {
        this.m_headlineText.Text = GameStrings.Get("GLUE_MASS_DISENCHANT_HEADLINE");
        this.m_detailsHeadlineText.Text = GameStrings.Get("GLUE_MASS_DISENCHANT_DETAILS_HEADLINE");
        this.m_detailsText.Text = GameStrings.Get("GLUE_MASS_DISENCHANT_DETAILS");
        this.m_disenchantButton.SetText(GameStrings.Get("GLUE_MASS_DISENCHANT_BUTTON_TEXT"));
        this.m_singleSubHeadlineText.Text = GameStrings.Get("GLUE_MASS_DISENCHANT_SUB_HEADLINE_TEXT");
        this.m_doubleSubHeadlineText.Text = GameStrings.Get("GLUE_MASS_DISENCHANT_SUB_HEADLINE_TEXT");
        this.m_disenchantButton.SetUserOverYOffset(-0.04409015f);
        foreach (DisenchantBar bar in this.m_singleDisenchantBars)
        {
            bar.Init();
        }
        foreach (DisenchantBar bar2 in this.m_doubleDisenchantBars)
        {
            bar2.Init();
        }
    }

    public int GetTotalAmount()
    {
        return this.m_totalAmount;
    }

    public void Hide()
    {
        this.m_root.SetActive(false);
    }

    private void OnDisenchantButtonPressed(UIEvent e)
    {
        Options.Get().SetBool(Option.HAS_DISENCHANTED, true);
        this.m_disenchantButton.SetEnabled(false);
        Network.MassDisenchant();
    }

    public void Show()
    {
        this.m_root.SetActive(true);
    }

    private void Start()
    {
        this.m_disenchantButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnDisenchantButtonPressed));
    }

    public void UpdateContents(List<CollectionCardStack.ArtStack> disenchantableArtStacks)
    {
        NetCache.NetCacheCardValues netObject = NetCache.Get().GetNetObject<NetCache.NetCacheCardValues>();
        if (netObject == null)
        {
            Debug.LogWarning("MassDisenchant.UpdateContents(): NetCacheCardValues is null");
        }
        else
        {
            if (<>f__am$cacheE == null)
            {
                <>f__am$cacheE = obj => CardFlair.PremiumType.FOIL == obj.Flair.Premium;
            }
            CollectionCardStack.ArtStack stack = disenchantableArtStacks.Find(<>f__am$cacheE);
            this.m_useSingle = stack == null;
            this.m_singleRoot.SetActive(this.m_useSingle);
            this.m_doubleRoot.SetActive(!this.m_useSingle);
            List<DisenchantBar> list = !this.m_useSingle ? this.m_doubleDisenchantBars : this.m_singleDisenchantBars;
            foreach (DisenchantBar bar in list)
            {
                bar.Reset();
            }
            this.m_totalAmount = 0;
            int totalNumCards = 0;
            <UpdateContents>c__AnonStorey133 storey = new <UpdateContents>c__AnonStorey133();
            using (List<CollectionCardStack.ArtStack>.Enumerator enumerator2 = disenchantableArtStacks.GetEnumerator())
            {
                while (enumerator2.MoveNext())
                {
                    NetCache.CardValue value2;
                    storey.disenchantableArtStack = enumerator2.Current;
                    <UpdateContents>c__AnonStorey134 storey2 = new <UpdateContents>c__AnonStorey134 {
                        <>f__ref$307 = storey
                    };
                    NetCache.CardDefinition definition2 = new NetCache.CardDefinition {
                        Name = storey.disenchantableArtStack.CardID,
                        Premium = storey.disenchantableArtStack.Flair.Premium
                    };
                    NetCache.CardDefinition key = definition2;
                    if (netObject.Values.TryGetValue(key, out value2))
                    {
                        storey2.entityDef = DefLoader.Get().GetEntityDef(storey.disenchantableArtStack.CardID);
                        int sellAmount = value2.Sell * storey.disenchantableArtStack.Count;
                        DisenchantBar bar2 = list.Find(new Predicate<DisenchantBar>(storey2.<>m__24));
                        if (bar2 == null)
                        {
                            object[] objArray1 = new object[] { !this.m_useSingle ? "double" : "single", storey2.entityDef, storey.disenchantableArtStack.Flair, storey.disenchantableArtStack.Count };
                            Debug.LogWarning(string.Format("MassDisenchant.UpdateContents(): Could not find {0} bar to modify for card {1} (flair {2}, disenchant count {3})", objArray1));
                        }
                        else
                        {
                            bar2.AddCards(storey.disenchantableArtStack.Count, sellAmount);
                            totalNumCards += storey.disenchantableArtStack.Count;
                            this.m_totalAmount += sellAmount;
                        }
                    }
                }
            }
            if (this.m_totalAmount > 0)
            {
                this.m_disenchantButton.SetEnabled(true);
            }
            foreach (DisenchantBar bar3 in list)
            {
                bar3.UpdateVisuals(totalNumCards);
            }
            object[] args = new object[] { this.m_totalAmount };
            this.m_totalAmountText.Text = GameStrings.Format("GLUE_MASS_DISENCHANT_TOTAL_AMOUNT", args);
        }
    }

    [CompilerGenerated]
    private sealed class <UpdateContents>c__AnonStorey133
    {
        internal CollectionCardStack.ArtStack disenchantableArtStack;
    }

    [CompilerGenerated]
    private sealed class <UpdateContents>c__AnonStorey134
    {
        internal MassDisenchant.<UpdateContents>c__AnonStorey133 <>f__ref$307;
        internal EntityDef entityDef;

        internal bool <>m__24(DisenchantBar obj)
        {
            return ((obj.m_premiumType == this.<>f__ref$307.disenchantableArtStack.Flair.Premium) && (obj.m_rarity == this.entityDef.GetRarity()));
        }
    }
}

