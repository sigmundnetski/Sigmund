using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneHand : Zone
{
    private const float ANGLE_OF_CARDS = 40f;
    private const float BASELINE_ASPECT_RATIO = 1.333333f;
    private static float[] CARD_PIXEL_WIDTHS;
    private const float CARD_WIDTH = 2.049684f;
    private Vector3 centerOfHand;
    private const float DEFAULT_ANIMATE_TIME = 0.35f;
    private bool doNotUpdateLayout = true;
    private const float DRIFT_AMOUNT = 0.08f;
    private bool enemyHand;
    public const float HAND_SCALE = 0.62f;
    public const float HAND_SCALE_OPPONENT = 0.682f;
    public const float HAND_SCALE_OPPONENT_Y = 0.225f;
    public const float HAND_SCALE_Y = 0.225f;
    private int lastMousedOver = -1;
    public int m_MaxSlots = MAX_CARDS;
    private int m_touchedSlot;
    public float m_TransitionSpeed = 1f;
    private static int MAX_CARDS;
    private float MAXIMUM_HAND_WIDTH;
    public const float MOUSE_OVER_SCALE = 1.5f;
    private const float RESISTANCE_BASE = 10f;
    private const float RESISTANCE_Y_FACTOR = 0.8f;
    public static readonly PlatformDependentValue<float> SELECT_CARD_Z_OFFSET;
    private List<CardStandIn> standIns;
    private const float Z_ROTATION_ON_LEFT = 357f;
    private const float Z_ROTATION_ON_RIGHT = 3f;

    static ZoneHand()
    {
        PlatformDependentValue<float> value2 = new PlatformDependentValue<float>(PlatformCategory.Screen) {
            PC = 0.15f,
            Tablet = 0.35f,
            Phone = 1.25f
        };
        SELECT_CARD_Z_OFFSET = value2;
        MAX_CARDS = 10;
        CARD_PIXEL_WIDTHS = new float[] { 0f, 0.08f, 0.08f, 0.08f, 0.08f, 0.074f, 0.069f, 0.064f, 0.06f, 0.056f, 0.054f };
    }

    private void Awake()
    {
        this.centerOfHand = base.collider.bounds.center;
        this.enemyHand = base.m_Side == Player.Side.OPPOSING;
        this.MAXIMUM_HAND_WIDTH = base.collider.bounds.size.x;
    }

    private void BlowUpOldStandins()
    {
        if (this.standIns == null)
        {
            this.standIns = new List<CardStandIn>();
        }
        else
        {
            foreach (CardStandIn @in in this.standIns)
            {
                if (@in != null)
                {
                    UnityEngine.Object.Destroy(@in.gameObject);
                }
            }
            this.standIns = new List<CardStandIn>();
        }
    }

    protected bool CanAnimateCard(Card card)
    {
        if (card.IsDoNotSort())
        {
            return false;
        }
        if (!card.IsActorReady())
        {
            return false;
        }
        if ((base.m_player.IsLocal() && (TurnStartManager.Get() != null)) && TurnStartManager.Get().IsThisCardDrawAlreadyHandledByTurnStartManager(card))
        {
            return false;
        }
        return true;
    }

    private bool CanPlaySpellPowerHint(Card card)
    {
        if (card.IsShown())
        {
            if (!card.GetActor().IsShown())
            {
                return false;
            }
            string stringTag = card.GetEntity().GetStringTag(GAME_TAG.CARDTEXT_INHAND);
            if (stringTag == null)
            {
                return false;
            }
            for (int i = 0; i < stringTag.Length; i++)
            {
                char ch = stringTag[i];
                if (ch == '$')
                {
                    int num2 = ++i;
                    while (num2 < stringTag.Length)
                    {
                        char ch2 = stringTag[num2];
                        if ((ch2 < '0') || (ch2 > '9'))
                        {
                            break;
                        }
                        num2++;
                    }
                    if (num2 != i)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void CardColliderLoadedCallback(string name, GameObject go, object callbackData)
    {
        Card card = (Card) callbackData;
        Actor actor = card.GetActor();
        if (actor != null)
        {
            actor.GetMeshRenderer().gameObject.layer = 0;
        }
        go.transform.localEulerAngles = this.GetCardRotation(card);
        go.transform.position = this.GetCardPosition(card);
        go.transform.localScale = this.GetCardScale(card);
        CardStandIn component = go.GetComponent<CardStandIn>();
        component.slot = card.GetEntity().GetZonePosition();
        component.linkedCard = card;
        component.Hide();
        this.standIns.Add(component);
    }

    private void DuplicateColliderAndStuffItIn(Card card)
    {
        AssetLoader.Get().LoadActor("Card_Collider_Standin", new AssetLoader.GameObjectCallback(this.CardColliderLoadedCallback), card);
    }

    private void FinishVerySlowTransition(Card card)
    {
        card.GetActor().TurnOnCollider();
        card.SetDoNotSort(false);
    }

    public Vector3 GetCardPosition(Card card)
    {
        int num = card.GetEntity().GetZonePosition() - 1;
        if (card.IsDoNotSort())
        {
            num = base.GetCards().Count - 1;
        }
        float num2 = 0f;
        float num3 = 0f;
        float num4 = 0f;
        int count = base.m_cards.Count;
        if (!this.enemyHand)
        {
            count -= TurnStartManager.Get().GetNumCardsToDraw();
        }
        if (this.IsHandScrunched())
        {
            num4 = 1f;
            float num6 = 40f;
            if (!this.enemyHand)
            {
                num6 += count * 2;
            }
            num2 = num6 / ((float) count);
            num3 = -num6 / 2f;
        }
        float f = 0f;
        if (this.enemyHand)
        {
            f = (0f - (num2 * (num + 0.5f))) - num3;
        }
        else
        {
            f += (num2 * num) + num3;
        }
        float num8 = 0f;
        if ((this.enemyHand && (f < 0f)) || (!this.enemyHand && (f > 0f)))
        {
            num8 = (Mathf.Sin((Mathf.Abs(f) * 3.141593f) / 180f) * this.GetCardSpacing()) / 2f;
        }
        float x = this.centerOfHand.x - ((this.GetCardSpacing() / 2f) * ((count - 1) - (num * 2)));
        float y = this.centerOfHand.y;
        float z = this.centerOfHand.z;
        if (count > 1)
        {
            if (this.enemyHand)
            {
                z += ((Mathf.Pow((float) Mathf.Abs((int) (num - (count / 2))), 2f) / ((float) (4 * count))) * num4) + num8;
            }
            else
            {
                z = (this.centerOfHand.z - ((Mathf.Pow((float) Mathf.Abs((int) (num - (count / 2))), 2f) / ((float) (4 * count))) * num4)) - num8;
            }
        }
        return new Vector3(x, y, z);
    }

    public Vector3 GetCardRotation(Card card)
    {
        int num = card.GetEntity().GetZonePosition() - 1;
        if (card.IsDoNotSort())
        {
            num = base.GetCards().Count - 1;
        }
        float num2 = 0f;
        float num3 = 0f;
        int count = base.m_cards.Count;
        if (!this.enemyHand)
        {
            count -= TurnStartManager.Get().GetNumCardsToDraw();
        }
        if (this.IsHandScrunched())
        {
            float num5 = 40f;
            if (!this.enemyHand)
            {
                num5 += count * 2;
            }
            num2 = num5 / ((float) count);
            num3 = -num5 / 2f;
        }
        float y = 0f;
        if (this.enemyHand)
        {
            y = (0f - (num2 * (num + 0.5f))) - num3;
        }
        else
        {
            y += (num2 * num) + num3;
        }
        return new Vector3(0f, y, 357f);
    }

    public Vector3 GetCardScale(Card card)
    {
        if (this.enemyHand)
        {
            return new Vector3(0.682f, 0.225f, 0.682f);
        }
        return new Vector3(0.62f, 0.225f, 0.62f);
    }

    private float GetCardSpacing()
    {
        float defaultCardSpacing = this.GetDefaultCardSpacing();
        int count = base.m_cards.Count;
        if (!this.enemyHand)
        {
            count -= TurnStartManager.Get().GetNumCardsToDraw();
        }
        float num3 = defaultCardSpacing * count;
        if (num3 > this.MAXIMUM_HAND_WIDTH)
        {
            defaultCardSpacing = this.MAXIMUM_HAND_WIDTH / ((float) count);
        }
        return defaultCardSpacing;
    }

    public float GetCardWidth(int nCards)
    {
        if (nCards < 0)
        {
            return 0f;
        }
        if (nCards > MAX_CARDS)
        {
            nCards = MAX_CARDS;
        }
        float num = ((float) Screen.width) / ((float) Screen.height);
        return (((CARD_PIXEL_WIDTHS[nCards] * Screen.width) * 1.333333f) / num);
    }

    public float GetDefaultCardSpacing()
    {
        return 1.270804f;
    }

    public bool GetDoNotUpdateLayout()
    {
        return this.doNotUpdateLayout;
    }

    public int GetLastMousedOverCard()
    {
        return this.lastMousedOver;
    }

    public float GetLength()
    {
        return this.MAXIMUM_HAND_WIDTH;
    }

    private Vector3 GetMouseOverCardPosition(Card card)
    {
        return new Vector3(this.GetCardPosition(card).x, this.centerOfHand.y + 1f, base.transform.FindChild("MouseOverCardHeight").position.z + SELECT_CARD_Z_OFFSET);
    }

    private CardStandIn GetStandIn(Card card)
    {
        if (this.standIns != null)
        {
            foreach (CardStandIn @in in this.standIns)
            {
                if ((@in != null) && (@in.linkedCard == card))
                {
                    return @in;
                }
            }
        }
        return null;
    }

    public void HandleInput()
    {
        if (UniversalInputManager.IsTouchDevice != null)
        {
            if (!InputManager.Get().LeftMouseButtonDown || (this.m_touchedSlot < 0))
            {
                this.m_touchedSlot = -1;
                this.UpdateLayout(-1);
            }
            else
            {
                float num = Input.mousePosition.x - InputManager.Get().LastMouseDownPosition.x;
                float num2 = Mathf.Max((float) 0f, (float) (Input.mousePosition.y - InputManager.Get().LastMouseDownPosition.y));
                float cardWidth = this.GetCardWidth(base.m_cards.Count);
                float a = (this.lastMousedOver - this.m_touchedSlot) * cardWidth;
                float num5 = 10f + (num2 * 0.8f);
                if (num < a)
                {
                    num = Mathf.Min(a, num + num5);
                }
                else
                {
                    num = Mathf.Max(a, num - num5);
                }
                int slotMousedOver = this.m_touchedSlot + ((int) Mathf.Round(num / cardWidth));
                this.UpdateLayout(slotMousedOver);
            }
        }
        else
        {
            RaycastHit hit;
            if (!UniversalInputManager.Get().InputHitAnyObject(GameLayer.InvisibleHitBox1.LayerBit()) || !UniversalInputManager.Get().GetInputHitInfo(GameLayer.CardRaycast.LayerBit(), out hit))
            {
                this.UpdateLayout(-1);
            }
            else
            {
                CardStandIn @in = SceneUtils.FindComponentInParents<CardStandIn>(hit.transform);
                if (@in == null)
                {
                    this.UpdateLayout(-1);
                }
                else
                {
                    int num7 = @in.slot - 1;
                    if (num7 != this.lastMousedOver)
                    {
                        this.UpdateLayout(num7);
                    }
                }
            }
        }
    }

    public bool IsHandScrunched()
    {
        float num = 1.270651f;
        int count = base.m_cards.Count;
        if (!this.enemyHand)
        {
            count -= TurnStartManager.Get().GetNumCardsToDraw();
        }
        float num3 = num * count;
        return (num3 > this.MAXIMUM_HAND_WIDTH);
    }

    public void OnSpellPowerEntityEnteredPlay()
    {
        foreach (Card card in base.m_cards)
        {
            if (this.CanPlaySpellPowerHint(card))
            {
                Spell actorSpell = card.GetActorSpell(SpellType.SPELL_POWER_HINT_BURST);
                if (actorSpell != null)
                {
                    actorSpell.Reactivate();
                }
            }
        }
    }

    public void OnSpellPowerEntityMousedOut()
    {
        foreach (Card card in base.m_cards)
        {
            Spell actorSpell = card.GetActorSpell(SpellType.SPELL_POWER_HINT_IDLE);
            if ((actorSpell != null) && actorSpell.IsActive())
            {
                actorSpell.ActivateState(SpellStateType.DEATH);
            }
        }
    }

    public void OnSpellPowerEntityMousedOver()
    {
        foreach (Card card in base.m_cards)
        {
            if (this.CanPlaySpellPowerHint(card))
            {
                Spell actorSpell = card.GetActorSpell(SpellType.SPELL_POWER_HINT_BURST);
                if (actorSpell != null)
                {
                    actorSpell.Reactivate();
                }
                Spell spell2 = card.GetActorSpell(SpellType.SPELL_POWER_HINT_IDLE);
                if (spell2 != null)
                {
                    spell2.ActivateState(SpellStateType.BIRTH);
                }
            }
        }
    }

    public void SetDoNotUpdateLayout(bool enable)
    {
        this.doNotUpdateLayout = enable;
    }

    public void TouchReceived()
    {
        RaycastHit hit;
        if (!UniversalInputManager.Get().GetInputHitInfo(GameLayer.CardRaycast.LayerBit(), out hit))
        {
            this.m_touchedSlot = -1;
        }
        CardStandIn @in = SceneUtils.FindComponentInParents<CardStandIn>(hit.transform);
        if (@in != null)
        {
            this.m_touchedSlot = @in.slot - 1;
        }
        else
        {
            this.m_touchedSlot = -1;
        }
    }

    public override void UpdateLayout()
    {
        if (!GameState.Get().IsMulliganPhase() && !this.enemyHand)
        {
            this.BlowUpOldStandins();
            for (int i = 0; i < base.m_cards.Count; i++)
            {
                Card card = base.m_cards[i];
                this.DuplicateColliderAndStuffItIn(card);
            }
        }
        this.UpdateLayout(-1, true);
    }

    public void UpdateLayout(int slotMousedOver)
    {
        this.UpdateLayout(slotMousedOver, false);
    }

    public void UpdateLayout(int slotMousedOver, bool forced)
    {
        if (this.enemyHand || (InputManager.Get().heldObject == null))
        {
            base.m_updatingLayout = true;
            for (int i = 0; i < base.m_cards.Count; i++)
            {
                Card card = base.m_cards[i];
                if (!card.IsDoNotSort())
                {
                    card.ShowCard();
                }
            }
            if (this.doNotUpdateLayout)
            {
                base.UpdateLayoutFinished();
            }
            else if (base.m_cards.Count == 0)
            {
                base.UpdateLayoutFinished();
            }
            else if ((slotMousedOver >= base.m_cards.Count) || (slotMousedOver < -1))
            {
                base.UpdateLayoutFinished();
            }
            else if (!forced && (slotMousedOver == this.lastMousedOver))
            {
                base.m_updatingLayout = false;
            }
            else
            {
                base.m_cards.Sort(new Comparison<Card>(this.CardSortComparison));
                this.UpdateLayoutImpl(slotMousedOver);
            }
        }
    }

    private void UpdateLayoutImpl(int slotMousedOver)
    {
        float delaySec = 0.5f;
        if (this.enemyHand)
        {
            delaySec = 1.5f;
        }
        int num2 = 0;
        if ((((this.lastMousedOver != slotMousedOver) && (this.lastMousedOver != -1)) && ((this.lastMousedOver < base.m_cards.Count) && (base.m_cards[this.lastMousedOver] != null))) && this.CanAnimateCard(base.m_cards[this.lastMousedOver]))
        {
            Card card = base.m_cards[this.lastMousedOver];
            iTween.Stop(card.gameObject);
            if (!this.enemyHand)
            {
                Vector3 mouseOverCardPosition = this.GetMouseOverCardPosition(card);
                Vector3 cardPosition = this.GetCardPosition(card);
                card.transform.position = new Vector3(mouseOverCardPosition.x, this.centerOfHand.y, cardPosition.z + 0.5f);
                card.transform.localScale = this.GetCardScale(card);
                card.transform.localEulerAngles = this.GetCardRotation(card);
            }
            card.NotifyMousedOut();
            SceneUtils.SetLayer(card.gameObject, GameLayer.Default);
        }
        for (int i = 0; i < base.m_cards.Count; i++)
        {
            delaySec = 0.5f;
            if (this.enemyHand)
            {
                delaySec = 1.5f;
            }
            Card card2 = base.m_cards[i];
            if (this.CanAnimateCard(card2))
            {
                num2++;
                card2.transform.rotation = Quaternion.Euler(new Vector3(card2.transform.localEulerAngles.x, card2.transform.localEulerAngles.y, 357f));
                string str = "normal";
                iTween.EaseType easeOutExpo = iTween.EaseType.easeOutExpo;
                float num4 = 0.25f;
                if (card2.IsSlowTransition())
                {
                    easeOutExpo = iTween.EaseType.easeInExpo;
                    num4 = delaySec;
                    card2.SetSlowTransition(false);
                    card2.GetActor().TurnOnCollider();
                }
                bool flag = card2.IsVerySlowTransition();
                if (flag)
                {
                    easeOutExpo = iTween.EaseType.easeInOutCubic;
                    num4 = 1f;
                    delaySec = 1f;
                    card2.SetVerySlowTransition(false);
                    card2.SetDoNotSort(true);
                }
                Vector3 vector3 = this.GetCardPosition(card2);
                Vector3 cardRotation = this.GetCardRotation(card2);
                Vector3 cardScale = this.GetCardScale(card2);
                if (i == slotMousedOver)
                {
                    easeOutExpo = iTween.EaseType.easeOutExpo;
                    if (this.enemyHand)
                    {
                        num4 = 0.15f;
                        float num5 = 0.3f;
                        vector3 = new Vector3(vector3.x, vector3.y, vector3.z - num5);
                    }
                    else
                    {
                        float num6 = 0.5f * i;
                        num6 -= (0.5f * base.m_cards.Count) / 2f;
                        float x = 1.5f;
                        float z = 1.5f;
                        cardRotation = new Vector3(0f, 0f, 0f);
                        cardScale = new Vector3(x, cardScale.y, z);
                        card2.transform.localScale = cardScale;
                        delaySec = 4f;
                        float num9 = 0.1f;
                        vector3 = this.GetMouseOverCardPosition(card2);
                        card2.transform.position = new Vector3(card2.transform.position.x, vector3.y, vector3.z - num9);
                        card2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                        iTween.Stop(card2.gameObject);
                        easeOutExpo = iTween.EaseType.easeOutExpo;
                        CardTypeBanner.Show(card2.GetActor());
                        card2.NotifyMousedOver();
                        InputManager.Get().SetMousedOverCard(card2);
                        KeywordHelpPanelManager.Get().UpdateKeywordHelp(card2, card2.GetActor());
                        SceneUtils.SetLayer(card2.gameObject, GameLayer.Tooltip);
                    }
                }
                else if (this.GetStandIn(card2) != null)
                {
                    CardStandIn standIn = this.GetStandIn(card2);
                    standIn.Hide();
                    iTween.Stop(standIn.gameObject);
                    standIn.transform.position = vector3;
                }
                card2.EnableTransitioningZones(true);
                object[] args = new object[] { "scale", cardScale, "time", num4, "easeType", easeOutExpo };
                Hashtable hashtable = iTween.Hash(args);
                if (flag)
                {
                    hashtable.Add("oncomplete", "FinishVerySlowTransition");
                    hashtable.Add("oncompletetarget", base.gameObject);
                    hashtable.Add("oncompleteparams", card2);
                }
                iTween.ScaleTo(card2.gameObject, hashtable);
                object[] objArray2 = new object[] { "rotation", cardRotation, "time", num4, "name", str, "easeType", easeOutExpo };
                Hashtable hashtable2 = iTween.Hash(objArray2);
                iTween.RotateTo(card2.gameObject, hashtable2);
                object[] objArray3 = new object[] { "position", vector3, "time", delaySec, "name", str, "easeType", easeOutExpo };
                Hashtable hashtable3 = iTween.Hash(objArray3);
                iTween.MoveTo(card2.gameObject, hashtable3);
            }
        }
        if (!this.enemyHand && (slotMousedOver == -1))
        {
            CardTypeBanner.Hide();
        }
        this.lastMousedOver = slotMousedOver;
        if (num2 > 0)
        {
            base.StartFinishLayoutTimer(delaySec);
        }
        else
        {
            base.UpdateLayoutFinished();
        }
    }

    public CardStandIn CurrentStandIn
    {
        get
        {
            if ((this.lastMousedOver >= 0) && (this.lastMousedOver < base.m_cards.Count))
            {
                return this.GetStandIn(base.m_cards[this.lastMousedOver]);
            }
            return null;
        }
    }
}

