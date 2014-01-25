using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    private GameObject m_activeObject;
    public UberText m_bankAmountText;
    public CreateButton m_buttonCreate;
    public DisenchantButton m_buttonDisenchant;
    private Actor m_constructingActor;
    public float m_craftDelayBeforeConstructSpell;
    public float m_craftDelayBeforeGhostDeath;
    private Notification m_craftNotification;
    public UberText m_craftValue;
    public float m_disenchantDelayBeforeBallsComeOut;
    public float m_disenchantDelayBeforeCardExplodes;
    public float m_disenchantDelayBeforeCardFlips;
    private Notification m_disenchantNotification;
    public UberText m_disenchantValue;
    private bool m_enabled;
    private Actor m_explodingActor;
    public GameObject m_glowballs;
    private bool m_isAnimating;
    private bool m_mousedOver;
    public Collider m_mouseOverCollider;
    public UberText m_soulboundDesc;
    public GameObject m_soulboundNotification;
    public UberText m_soulboundTitle;
    private Vector3 m_startingPosition;
    private List<GameObject> m_thingsToDestroy = new List<GameObject>();

    private void Awake()
    {
        this.m_startingPosition = base.transform.position;
        base.transform.position = new Vector3(this.m_startingPosition.x, this.m_startingPosition.y, this.m_startingPosition.z - 10f);
        this.m_soulboundNotification.transform.position = base.transform.position;
        this.m_soulboundTitle.Text = GameStrings.Get("GLUE_CRAFTING_SOULBOUND");
        this.m_soulboundDesc.Text = GameStrings.Get("GLUE_CRAFTING_SOULBOUND_DESC");
        this.m_activeObject = base.gameObject;
    }

    public void CleanUpEffects()
    {
        if (this.m_explodingActor != null)
        {
            if (this.m_explodingActor.GetSpell(SpellType.DECONSTRUCT) != null)
            {
                this.m_explodingActor.GetSpell(SpellType.DECONSTRUCT).GetComponent<PlayMakerFSM>().SendEvent("Cancel");
            }
            this.m_explodingActor.Hide();
        }
        if (this.m_constructingActor != null)
        {
            if (this.m_constructingActor.GetSpell(SpellType.CONSTRUCT) != null)
            {
                this.m_constructingActor.GetSpell(SpellType.CONSTRUCT).GetComponent<PlayMakerFSM>().SendEvent("Cancel");
            }
            this.m_constructingActor.Hide();
        }
        base.GetComponent<PlayMakerFSM>().SendEvent("Cancel");
    }

    private void CreateCraftNotification()
    {
        if (this.m_buttonCreate.IsButtonEnabled())
        {
            float x = 0.2297155f;
            Vector3 scale = new Vector3(x, x, x);
            this.m_craftNotification = NotificationManager.Get().CreatePopupText(this.m_buttonCreate.transform.position, scale, GameStrings.Get("GLUE_COLLECTION_TUTORIAL06"));
            this.m_craftNotification.transform.parent = this.m_activeObject.transform;
            this.m_craftNotification.transform.localPosition = new Vector3(-0.9812905f, 0.07250023f, -0.04246894f);
            this.m_craftNotification.ShowPopUpArrow(Notification.PopUpArrowDirection.Left);
        }
    }

    private void CreateDisenchantNotification()
    {
        if (this.m_buttonDisenchant.IsButtonEnabled())
        {
            float x = 0.2297155f;
            Vector3 scale = new Vector3(x, x, x);
            this.m_disenchantNotification = NotificationManager.Get().CreatePopupText(this.m_buttonDisenchant.transform.position, scale, GameStrings.Get("GLUE_COLLECTION_TUTORIAL05"));
            this.m_disenchantNotification.transform.parent = this.m_activeObject.transform;
            this.m_disenchantNotification.transform.localPosition = new Vector3(0.9622304f, 0.07250023f, -0.04246894f);
            this.m_disenchantNotification.ShowPopUpArrow(Notification.PopUpArrowDirection.Right);
        }
    }

    public void Disable()
    {
        this.m_enabled = false;
        object[] args = new object[] { "time", 0.4f, "position", new Vector3(this.m_startingPosition.x, this.m_startingPosition.y, this.m_startingPosition.z - 10f) };
        iTween.MoveTo(this.m_activeObject, iTween.Hash(args));
        this.HideTips();
    }

    public void DoCreate()
    {
        this.UpdateTips();
        if (!Options.Get().GetBool(Option.HAS_CRAFTED))
        {
            Options.Get().SetBool(Option.HAS_CRAFTED, true);
        }
        string cardId = CraftingManager.Get().GetShownActor().GetEntityDef().GetCardId();
        CardFlair.PremiumType premium = CraftingManager.Get().GetShownActor().GetCardFlair().Premium;
        CraftingManager.Get().AdjustLocalArcaneDustBalance(-this.GetCardBuyValue(cardId, premium));
        CraftingManager.Get().NotifyOfTransaction(1);
        if (CraftingManager.Get().GetNumOwnedCopies(cardId, premium) > 1)
        {
            CraftingManager.Get().ForceNonGhostFlagOn();
        }
        this.UpdateText();
        this.StopCurrentAnim();
        base.StartCoroutine(this.DoCreateAnims());
        CraftingManager.Get().StartCoroutine(this.StartDisenchantCooldown());
    }

    [DebuggerHidden]
    private IEnumerator DoCreateAnims()
    {
        return new <DoCreateAnims>c__Iterator1A { <>f__this = this };
    }

    public void DoDisenchant()
    {
        this.UpdateTips();
        Options.Get().SetBool(Option.HAS_DISENCHANTED, true);
        CraftingManager.Get().AdjustLocalArcaneDustBalance(this.GetCardSellValue(CraftingManager.Get().GetShownActor().GetEntityDef().GetCardId(), CraftingManager.Get().GetShownActor().GetCardFlair().Premium));
        CraftingManager.Get().NotifyOfTransaction(-1);
        this.UpdateText();
        if (this.m_isAnimating)
        {
            CraftingManager.Get().FinishFlipCurrentActorEarly();
        }
        this.StopCurrentAnim();
        base.StartCoroutine(this.DoDisenchantAnims());
        CraftingManager.Get().StartCoroutine(this.StartCraftCooldown());
    }

    [DebuggerHidden]
    private IEnumerator DoDisenchantAnims()
    {
        return new <DoDisenchantAnims>c__Iterator19 { <>f__this = this };
    }

    public void Enable()
    {
        this.m_enabled = true;
        this.UpdateText();
        this.m_activeObject.SetActive(true);
        object[] args = new object[] { "time", 0.5f, "position", this.m_startingPosition };
        iTween.MoveTo(this.m_activeObject, iTween.Hash(args));
        this.ShowFirstTimeTips();
    }

    private int GetCardBuyValue(string cardID, CardFlair.PremiumType premium)
    {
        NetCache.CardValue cardValue = this.GetCardValue(cardID, premium);
        if (CraftingManager.Get().GetNumTransactions() >= 0)
        {
            return cardValue.Buy;
        }
        return cardValue.Sell;
    }

    private int GetCardSellValue(string cardID, CardFlair.PremiumType premium)
    {
        NetCache.CardValue cardValue = this.GetCardValue(cardID, premium);
        if (CraftingManager.Get().GetNumTransactions() <= 0)
        {
            return cardValue.Sell;
        }
        return cardValue.Buy;
    }

    private NetCache.CardValue GetCardValue(string cardID, CardFlair.PremiumType premium)
    {
        NetCache.CardValue value2;
        NetCache.NetCacheCardValues netObject = NetCache.Get().GetNetObject<NetCache.NetCacheCardValues>();
        NetCache.CardDefinition definition2 = new NetCache.CardDefinition {
            Name = cardID,
            Premium = premium
        };
        NetCache.CardDefinition key = definition2;
        if (!netObject.Values.TryGetValue(key, out value2))
        {
            return null;
        }
        return value2;
    }

    private void HideTips()
    {
        if (this.m_disenchantNotification != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.m_disenchantNotification);
        }
        if (this.m_craftNotification != null)
        {
            NotificationManager.Get().DestroyNotificationNowWithNoAnim(this.m_craftNotification);
        }
    }

    private void NotifyOfMouseOut()
    {
        if (this.m_mousedOver)
        {
            this.m_mousedOver = false;
            base.GetComponent<PlayMakerFSM>().SendEvent("IdleCancel");
        }
    }

    private void NotifyOfMouseOver()
    {
        if (!this.m_mousedOver)
        {
            this.m_mousedOver = true;
            base.GetComponent<PlayMakerFSM>().SendEvent("Idle");
        }
    }

    public void SetStartingActive()
    {
        this.m_soulboundNotification.SetActive(false);
        base.gameObject.SetActive(false);
    }

    private void ShowFirstTimeTips()
    {
        if ((this.m_activeObject != this.m_soulboundNotification) && !Options.Get().GetBool(Option.HAS_CRAFTED))
        {
            this.CreateDisenchantNotification();
            this.CreateCraftNotification();
        }
    }

    [DebuggerHidden]
    private IEnumerator StartCraftCooldown()
    {
        return new <StartCraftCooldown>c__Iterator1C { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator StartDisenchantCooldown()
    {
        return new <StartDisenchantCooldown>c__Iterator1B { <>f__this = this };
    }

    private void StopCurrentAnim()
    {
        if (this.m_isAnimating)
        {
            base.StopAllCoroutines();
            this.CleanUpEffects();
            foreach (GameObject obj2 in this.m_thingsToDestroy)
            {
                if (obj2 != null)
                {
                    UnityEngine.Object.Destroy(obj2);
                }
            }
            this.m_isAnimating = false;
        }
    }

    private void Update()
    {
        if (this.m_enabled)
        {
            if (this.m_isAnimating)
            {
                this.m_mousedOver = false;
            }
            else
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                LayerMask mask = 0x200;
                if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane, (int) mask))
                {
                    if (hit.collider == this.m_mouseOverCollider)
                    {
                        this.NotifyOfMouseOver();
                    }
                    else
                    {
                        this.NotifyOfMouseOut();
                    }
                }
            }
        }
    }

    public void UpdateBankText()
    {
        this.m_bankAmountText.Text = CraftingManager.Get().GetLocalArcaneDustBalance().ToString();
        BnetBar.Get().m_currencyFrame.RefreshContents();
    }

    private bool UpdateCardValueText(NetCache.CardDefinition cardDef)
    {
        NetCache.CardValue value2;
        if (!NetCache.Get().GetNetObject<NetCache.NetCacheCardValues>().Values.TryGetValue(cardDef, out value2))
        {
            return false;
        }
        int numTransactions = CraftingManager.Get().GetNumTransactions();
        int buy = value2.Buy;
        if (numTransactions < 0)
        {
            buy = value2.Sell;
        }
        int sell = value2.Sell;
        if (numTransactions > 0)
        {
            sell = value2.Buy;
        }
        this.m_disenchantValue.Text = "+" + sell.ToString();
        this.m_craftValue.Text = "-" + buy.ToString();
        return true;
    }

    public void UpdateText()
    {
        EntityDef def;
        CardFlair flair;
        this.UpdateBankText();
        if (!CraftingManager.Get().GetShownCardInfo(out def, out flair))
        {
            this.m_buttonDisenchant.DisableButton();
            this.m_buttonCreate.DisableButton();
        }
        else
        {
            NetCache.CardDefinition definition2 = new NetCache.CardDefinition {
                Name = def.GetCardId(),
                Premium = flair.Premium
            };
            NetCache.CardDefinition cardDef = definition2;
            if (!this.UpdateCardValueText(cardDef))
            {
                this.m_buttonDisenchant.DisableButton();
                this.m_buttonCreate.DisableButton();
                this.m_soulboundNotification.SetActive(true);
                this.m_activeObject = this.m_soulboundNotification;
                if (def.GetCardSet() == TAG_CARD_SET.CORE)
                {
                    this.m_soulboundDesc.Text = GameStrings.Get("GLUE_CRAFTING_SOULBOUND_BASIC_DESC");
                }
                else if (def.GetCardSet() == TAG_CARD_SET.REWARD)
                {
                    this.m_soulboundDesc.Text = GameStrings.Get("GLUE_CRAFTING_SOULBOUND_REWARD_DESC");
                }
                else
                {
                    this.m_soulboundDesc.Text = GameStrings.Get("GLUE_CRAFTING_SOULBOUND_DESC");
                }
            }
            else
            {
                this.m_soulboundNotification.SetActive(false);
                this.m_activeObject = base.gameObject;
                int numOwnedCopies = CraftingManager.Get().GetNumOwnedCopies(cardDef.Name, cardDef.Premium);
                if (numOwnedCopies <= 0)
                {
                    this.m_buttonDisenchant.DisableButton();
                }
                else
                {
                    this.m_buttonDisenchant.EnableButton();
                }
                int num2 = !def.IsElite() ? 2 : 1;
                long localArcaneDustBalance = CraftingManager.Get().GetLocalArcaneDustBalance();
                if ((numOwnedCopies >= num2) || (localArcaneDustBalance < this.GetCardBuyValue(cardDef.Name, cardDef.Premium)))
                {
                    this.m_buttonCreate.DisableButton();
                }
                else
                {
                    this.m_buttonCreate.EnableButton();
                }
            }
        }
    }

    private void UpdateTips()
    {
        if (Options.Get().GetBool(Option.HAS_CRAFTED))
        {
            this.HideTips();
        }
        else
        {
            if (this.m_disenchantNotification == null)
            {
                this.CreateDisenchantNotification();
            }
            else if (!this.m_buttonDisenchant.IsButtonEnabled())
            {
                NotificationManager.Get().DestroyNotification(this.m_disenchantNotification, 0f);
            }
            if (this.m_craftNotification == null)
            {
                this.CreateCraftNotification();
            }
            else if (!this.m_buttonCreate.IsButtonEnabled())
            {
                NotificationManager.Get().DestroyNotification(this.m_craftNotification, 0f);
            }
        }
    }

    [CompilerGenerated]
    private sealed class <DoCreateAnims>c__Iterator1A : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CraftingUI <>f__this;
        internal PlayMakerFSM <playmaker>__0;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    SoundManager.Get().LoadAndPlay("crafting_create_card_start");
                    this.<>f__this.m_isAnimating = true;
                    CraftingManager.Get().FlipCurrentActor();
                    this.<playmaker>__0 = this.<>f__this.GetComponent<PlayMakerFSM>();
                    this.<playmaker>__0.SendEvent("Birth");
                    this.$current = new WaitForSeconds(this.<>f__this.m_craftDelayBeforeConstructSpell);
                    this.$PC = 1;
                    goto Label_0136;

                case 1:
                    if (!CraftingManager.Get().IsCancelling())
                    {
                        this.<>f__this.m_constructingActor = CraftingManager.Get().LoadNewActorAndConstructIt();
                        this.<>f__this.UpdateBankText();
                        this.$current = new WaitForSeconds(this.<>f__this.m_craftDelayBeforeGhostDeath);
                        this.$PC = 2;
                        goto Label_0136;
                    }
                    break;

                case 2:
                    if (!CraftingManager.Get().IsCancelling())
                    {
                        CraftingManager.Get().FinishCreateAnims();
                        this.$current = new WaitForSeconds(1f);
                        this.$PC = 3;
                        goto Label_0136;
                    }
                    break;

                case 3:
                    this.<>f__this.m_isAnimating = false;
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_0136:
            return true;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <DoDisenchantAnims>c__Iterator19 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CraftingUI <>f__this;
        internal Actor <oldActor>__1;
        internal PlayMakerFSM <playmaker>__0;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    SoundManager.Get().LoadAndPlay("crafting_disenchant_card_start");
                    this.<>f__this.m_isAnimating = true;
                    this.<playmaker>__0 = this.<>f__this.GetComponent<PlayMakerFSM>();
                    this.<playmaker>__0.SendEvent("Birth");
                    this.$current = new WaitForSeconds(this.<>f__this.m_disenchantDelayBeforeCardExplodes);
                    this.$PC = 1;
                    goto Label_0241;

                case 1:
                case 2:
                    if (CraftingManager.Get().GetShownActor() == null)
                    {
                        this.$current = null;
                        this.$PC = 2;
                    }
                    else
                    {
                        this.<>f__this.m_explodingActor = CraftingManager.Get().GetShownActor();
                        this.<>f__this.UpdateBankText();
                        if (CraftingManager.Get().IsCancelling())
                        {
                            break;
                        }
                        CraftingManager.Get().LoadGhostActorIfNecessary();
                        this.<>f__this.m_explodingActor.ActivateSpell(SpellType.DECONSTRUCT);
                        this.$current = new WaitForSeconds(this.<>f__this.m_disenchantDelayBeforeCardFlips);
                        this.$PC = 3;
                    }
                    goto Label_0241;

                case 3:
                    if (!CraftingManager.Get().IsCancelling())
                    {
                        CraftingManager.Get().FlipUpsideDownCard(this.<>f__this.m_explodingActor);
                        this.<oldActor>__1 = this.<>f__this.m_explodingActor;
                        this.<>f__this.m_thingsToDestroy.Add(this.<>f__this.m_explodingActor.gameObject);
                        this.$current = new WaitForSeconds(this.<>f__this.m_disenchantDelayBeforeBallsComeOut);
                        this.$PC = 4;
                        goto Label_0241;
                    }
                    break;

                case 4:
                    if (!CraftingManager.Get().IsCancelling())
                    {
                        this.<playmaker>__0.SendEvent("Action");
                        this.$current = new WaitForSeconds(1f);
                        this.$PC = 5;
                        goto Label_0241;
                    }
                    break;

                case 5:
                    this.<>f__this.m_isAnimating = false;
                    this.$current = new WaitForSeconds(10f);
                    this.$PC = 6;
                    goto Label_0241;

                case 6:
                    if (this.<oldActor>__1 != null)
                    {
                        UnityEngine.Object.Destroy(this.<oldActor>__1.gameObject);
                    }
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_0241:
            return true;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <StartCraftCooldown>c__Iterator1C : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CraftingUI <>f__this;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<>f__this.m_buttonCreate.collider.enabled = false;
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.m_buttonCreate.collider.enabled = true;
                    this.$PC = -1;
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <StartDisenchantCooldown>c__Iterator1B : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CraftingUI <>f__this;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.<>f__this.m_buttonDisenchant.collider.enabled = false;
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.m_buttonDisenchant.collider.enabled = true;
                    this.$PC = -1;
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }
}

