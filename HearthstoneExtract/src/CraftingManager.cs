using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    private Vector3 CARD_SCALE = new Vector3(5.7f, 5.7f, 5.7f);
    public CraftingUI craftingUI;
    private long m_arcaneDustBalance;
    private bool m_cancellingCraftMode;
    public Transform m_cardCounterBone;
    public CraftCardCountTab m_cardCountTab;
    private CardFlair m_cardFlairOfLastTouchedCard;
    private string m_cardIDOfLastTouchedCard;
    public CardInfoPane m_cardInfoPane;
    public Transform m_cardInfoPaneBone;
    private Actor m_currentBigActor;
    public float m_delayBeforeBackCardMovesUp;
    public PegUIElement m_dustJar;
    public iTween.EaseType m_easeTypeForCardFlip;
    public iTween.EaseType m_easeTypeForCardMoveUp;
    public Transform m_faceDownCardBone;
    public Transform m_floatingCardBone;
    private Actor m_ghostGoldenMinionActor;
    private Actor m_ghostGoldenSpellActor;
    private Actor m_ghostGoldenWeaponActor;
    private Actor m_ghostMinionActor;
    private Actor m_ghostSpellActor;
    private Actor m_ghostWeaponActor;
    private Actor m_hiddenActor;
    private bool m_isCurrentActorAGhost;
    public BoxCollider m_offClickCatcher;
    private Actor m_templateGoldenMinionActor;
    private Actor m_templateGoldenSpellActor;
    private Actor m_templateGoldenWeaponActor;
    private Actor m_templateMinionActor;
    private Actor m_templateSpellActor;
    private Actor m_templateWeaponActor;
    public float m_timeForBackCardToMoveUp;
    public float m_timeForCardToFlipUp;
    private int m_transactions;
    private Actor m_upsideDownActor;
    private static CraftingManager s_instance;

    public void AdjustLocalArcaneDustBalance(int amt)
    {
        this.m_arcaneDustBalance += amt;
    }

    public bool AreGhostActorsLoaded()
    {
        if (this.m_ghostMinionActor == null)
        {
            return false;
        }
        if (this.m_ghostSpellActor == null)
        {
            return false;
        }
        if (this.m_ghostWeaponActor == null)
        {
            return false;
        }
        if (this.m_templateWeaponActor == null)
        {
            return false;
        }
        if (this.m_templateMinionActor == null)
        {
            return false;
        }
        if (this.m_templateSpellActor == null)
        {
            return false;
        }
        if (this.m_templateGoldenMinionActor == null)
        {
            return false;
        }
        if (this.m_templateGoldenSpellActor == null)
        {
            return false;
        }
        if (this.m_templateGoldenWeaponActor == null)
        {
            return false;
        }
        if (this.m_ghostGoldenMinionActor == null)
        {
            return false;
        }
        if (this.m_ghostGoldenSpellActor == null)
        {
            return false;
        }
        if (this.m_ghostGoldenWeaponActor == null)
        {
            return false;
        }
        if (this.m_hiddenActor == null)
        {
            return false;
        }
        return true;
    }

    private void Awake()
    {
        s_instance = this;
        this.m_arcaneDustBalance = NetCache.Get().GetNetObject<NetCache.NetCacheArcaneDustBalance>().Balance;
    }

    public void CancelCraftMode()
    {
        base.StopAllCoroutines();
        this.m_offClickCatcher.enabled = false;
        this.m_cancellingCraftMode = true;
        this.craftingUI.CleanUpEffects();
        float time = 0.2f;
        if (this.m_currentBigActor != null)
        {
            iTween.Stop(this.m_currentBigActor.gameObject);
            iTween.RotateTo(this.m_currentBigActor.gameObject, new Vector3(0f, 0f, 0f), time);
            this.m_currentBigActor.ToggleForceIdle(false);
            if (this.m_upsideDownActor != null)
            {
                iTween.Stop(this.m_upsideDownActor.gameObject);
                this.m_upsideDownActor.transform.parent = this.m_currentBigActor.transform;
            }
        }
        else if (this.m_upsideDownActor != null)
        {
            object[] args = new object[] { "scale", Vector3.zero, "time", time, "oncomplete", "FinishActorMove", "oncompletetarget", base.gameObject, "easetype", iTween.EaseType.easeOutCirc };
            iTween.ScaleTo(this.m_upsideDownActor.gameObject, iTween.Hash(args));
        }
        CollectionCardVisual currentCardVisual = this.GetCurrentCardVisual();
        iTween.Stop(this.m_cardCountTab.gameObject);
        if (currentCardVisual == null)
        {
            if (this.m_currentBigActor != null)
            {
                object[] objArray2 = new object[] { "scale", Vector3.zero, "time", time, "oncomplete", "FinishActorMove", "oncompletetarget", base.gameObject, "easetype", iTween.EaseType.easeOutCirc };
                iTween.ScaleTo(this.m_currentBigActor.gameObject, iTween.Hash(objArray2));
            }
            this.m_cardCountTab.transform.position = new Vector3(0f, 307f, -10f);
        }
        else if (this.m_currentBigActor != null)
        {
            Vector3 vector = currentCardVisual.transform.TransformPoint(CollectionCardVisual.ACTOR_LOCAL_POS);
            object[] objArray3 = new object[] { "position", vector, "time", time, "oncomplete", "FinishActorMove", "oncompletetarget", base.gameObject, "easetype", iTween.EaseType.easeOutCirc };
            iTween.MoveTo(this.m_currentBigActor.gameObject, iTween.Hash(objArray3));
            if (!this.m_isCurrentActorAGhost)
            {
                object[] objArray4 = new object[] { "position", new Vector3(vector.x, vector.y - 2f, vector.z), "time", time, "easetype", iTween.EaseType.easeOutCirc };
                iTween.MoveTo(this.m_cardCountTab.gameObject, iTween.Hash(objArray4));
            }
            object[] objArray5 = new object[] { "scale", new Vector3(6.57f, 6.57f, 6.57f), "time", time, "easetype", iTween.EaseType.easeOutCirc };
            iTween.ScaleTo(this.m_currentBigActor.gameObject, iTween.Hash(objArray5));
            if (this.m_upsideDownActor != null)
            {
                iTween.RotateTo(this.m_upsideDownActor.gameObject, new Vector3(0f, 359f, 180f), time);
                object[] objArray6 = new object[] { "position", new Vector3(0f, -1f, 0f), "time", time, "islocal", true };
                iTween.MoveTo(this.m_upsideDownActor.gameObject, iTween.Hash(objArray6));
                iTween.ScaleTo(this.m_upsideDownActor.gameObject, new Vector3(this.m_upsideDownActor.transform.localScale.x * 0.8f, this.m_upsideDownActor.transform.localScale.y * 0.8f, this.m_upsideDownActor.transform.localScale.z * 0.8f), time);
            }
        }
        this.craftingUI.Disable();
        this.FadeEffectsOut();
        iTween.Stop(this.m_cardInfoPane.gameObject);
        this.m_cardInfoPane.gameObject.SetActive(false);
        this.TellServerAboutWhatUserDid();
    }

    public void EnterCraftMode(CollectionCardVisual cardToDisplay)
    {
        CollectionManagerDisplay.Get().HideAllTips();
        this.m_arcaneDustBalance = NetCache.Get().GetNetObject<NetCache.NetCacheArcaneDustBalance>().Balance;
        this.m_offClickCatcher.enabled = true;
        KeywordHelpPanelManager.Get().HideKeywordHelp();
        this.MoveCardToBigSpot(cardToDisplay, true);
        this.craftingUI.gameObject.SetActive(true);
        this.craftingUI.Enable();
        this.FadeEffectsIn();
        this.UpdateCardInfoPane();
    }

    private void FadeEffectsIn()
    {
        FullScreenFXMgr mgr = FullScreenFXMgr.Get();
        mgr.SetBlurBrightness(1f);
        mgr.SetBlurDesaturation(0f);
        mgr.Vignette(0.4f, 0.4f, iTween.EaseType.easeOutCirc, null);
        mgr.Blur(1f, 0.4f, iTween.EaseType.easeOutCirc, null);
    }

    private void FadeEffectsOut()
    {
        FullScreenFXMgr mgr = FullScreenFXMgr.Get();
        mgr.StopVignette(0.2f, iTween.EaseType.easeOutCirc, new FullScreenFXMgr.EffectListener(this.OnVignetteFinished));
        mgr.StopBlur(0.2f, iTween.EaseType.easeOutCirc, null);
    }

    private void FinishActorMove()
    {
        this.m_cancellingCraftMode = false;
        iTween.Stop(this.m_cardCountTab.gameObject);
        this.m_cardCountTab.transform.position = new Vector3(0f, 307f, -10f);
        if (this.m_upsideDownActor != null)
        {
            UnityEngine.Object.Destroy(this.m_upsideDownActor.gameObject);
        }
        if (this.m_currentBigActor != null)
        {
            UnityEngine.Object.Destroy(this.m_currentBigActor.gameObject);
        }
    }

    public void FinishCreateAnims()
    {
        if (!this.m_cancellingCraftMode)
        {
            iTween.ScaleTo(this.m_cardCountTab.gameObject, new Vector3(1f, 1f, 1f), 0.4f);
            this.m_currentBigActor.GetSpell(SpellType.GHOSTMODE).GetComponent<PlayMakerFSM>().SendEvent("Cancel");
            this.m_isCurrentActorAGhost = false;
            int numOwnedCopies = this.GetNumOwnedCopies(this.m_currentBigActor.GetEntityDef().GetCardId(), this.m_currentBigActor.GetCardFlair().Premium);
            this.m_cardCountTab.UpdateText(numOwnedCopies);
            this.m_cardCountTab.transform.position = this.m_cardCounterBone.position;
        }
    }

    public void FinishFlipCurrentActorEarly()
    {
        base.StopAllCoroutines();
        iTween.Stop(this.m_currentBigActor.gameObject);
        this.m_currentBigActor.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        this.m_currentBigActor.transform.position = this.m_floatingCardBone.position;
        this.m_currentBigActor.Show();
        GameObject hiddenStandIn = this.m_currentBigActor.GetHiddenStandIn();
        if (hiddenStandIn != null)
        {
            hiddenStandIn.SetActive(false);
            UnityEngine.Object.Destroy(hiddenStandIn);
        }
    }

    public void FlipCurrentActor()
    {
        if ((this.m_currentBigActor != null) && !this.m_isCurrentActorAGhost)
        {
            this.m_cardCountTab.transform.localScale = new Vector3(1f, 1f, 0f);
            this.m_upsideDownActor = this.m_currentBigActor;
            this.m_upsideDownActor.name = "UpsideDownActor";
            this.m_upsideDownActor.GetSpell(SpellType.GHOSTMODE).GetComponent<PlayMakerFSM>().SendEvent("Cancel");
            this.m_currentBigActor = null;
            iTween.Stop(this.m_upsideDownActor.gameObject);
            object[] args = new object[] { "rotation", new Vector3(0f, 350f, 180f), "time", 1f };
            iTween.RotateTo(this.m_upsideDownActor.gameObject, iTween.Hash(args));
            object[] objArray2 = new object[] { "position", this.m_faceDownCardBone.position, "time", 1f };
            iTween.MoveTo(this.m_upsideDownActor.gameObject, iTween.Hash(objArray2));
            base.StartCoroutine(this.ReplaceFaceDownActorWithHiddenCard());
        }
    }

    public void FlipUpsideDownCard(Actor oldActor)
    {
        if (!this.m_cancellingCraftMode)
        {
            int numOwnedCopies = this.GetNumOwnedCopies(this.m_currentBigActor.GetEntityDef().GetCardId(), this.m_currentBigActor.GetCardFlair().Premium);
            if (numOwnedCopies > 1)
            {
                this.m_upsideDownActor = this.GetAndPositionNewUpsideDownActor(this.m_currentBigActor, false);
                this.m_upsideDownActor.name = "UpsideDownActor";
                base.StartCoroutine(this.ReplaceFaceDownActorWithHiddenCard());
            }
            if (numOwnedCopies >= 1)
            {
                object[] objArray1 = new object[] { "scale", new Vector3(1f, 1f, 1f), "time", 0.4f, "delay", this.m_timeForCardToFlipUp };
                iTween.ScaleTo(this.m_cardCountTab.gameObject, iTween.Hash(objArray1));
                this.m_cardCountTab.UpdateText(numOwnedCopies);
            }
            object[] args = new object[] { "position", this.m_floatingCardBone.position, "time", this.m_timeForCardToFlipUp, "easetype", this.m_easeTypeForCardFlip };
            iTween.MoveTo(this.m_currentBigActor.gameObject, iTween.Hash(args));
            object[] objArray3 = new object[] { "rotation", new Vector3(0f, 0f, 0f), "time", this.m_timeForCardToFlipUp, "easetype", this.m_easeTypeForCardFlip };
            iTween.RotateTo(this.m_currentBigActor.gameObject, iTween.Hash(objArray3));
            base.StartCoroutine(this.ReplaceHiddenCardwithRealActor(this.m_currentBigActor));
        }
    }

    public void ForceNonGhostFlagOn()
    {
        this.m_isCurrentActorAGhost = false;
    }

    public static CraftingManager Get()
    {
        return s_instance;
    }

    private Actor GetAndPositionNewActor(Actor oldActor, int numCopies)
    {
        Actor ghostActor;
        if (numCopies == 0)
        {
            ghostActor = this.GetGhostActor(oldActor);
        }
        else
        {
            ghostActor = this.GetNonGhostActor(oldActor);
        }
        float x = 6.57f;
        ghostActor.transform.localScale = new Vector3(x, x, x);
        return ghostActor;
    }

    private Actor GetAndPositionNewUpsideDownActor(Actor oldActor, bool fromPage)
    {
        Actor andPositionNewActor = this.GetAndPositionNewActor(oldActor, 1);
        SceneUtils.SetLayer(andPositionNewActor.gameObject, GameLayer.IgnoreFullScreenEffects);
        if (fromPage)
        {
            andPositionNewActor.transform.position = oldActor.transform.position + new Vector3(0f, -2f, 0f);
            andPositionNewActor.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
            iTween.RotateTo(andPositionNewActor.gameObject, new Vector3(0f, 350f, 180f), 0.4f);
            object[] objArray1 = new object[] { "position", this.m_faceDownCardBone.position, "time", 0.4f };
            iTween.MoveTo(andPositionNewActor.gameObject, iTween.Hash(objArray1));
            iTween.ScaleTo(andPositionNewActor.gameObject, this.CARD_SCALE, 0.4f);
            return andPositionNewActor;
        }
        andPositionNewActor.transform.localEulerAngles = new Vector3(0f, 350f, 180f);
        andPositionNewActor.transform.position = this.m_faceDownCardBone.position + new Vector3(0f, -6f, 0f);
        andPositionNewActor.transform.localScale = this.CARD_SCALE;
        object[] args = new object[] { "position", this.m_faceDownCardBone.position, "time", this.m_timeForBackCardToMoveUp, "easetype", this.m_easeTypeForCardMoveUp, "delay", this.m_delayBeforeBackCardMovesUp };
        iTween.MoveTo(andPositionNewActor.gameObject, iTween.Hash(args));
        return andPositionNewActor;
    }

    private CollectionCardVisual GetCurrentCardVisual()
    {
        EntityDef def;
        CardFlair flair;
        if (!this.GetShownCardInfo(out def, out flair))
        {
            return null;
        }
        return CollectionManagerDisplay.Get().m_pageManager.GetCardVisual(def.GetCardId(), flair);
    }

    private Actor GetGhostActor(Actor actor)
    {
        this.m_isCurrentActorAGhost = true;
        bool flag = actor.GetCardFlair().Premium == CardFlair.PremiumType.FOIL;
        Actor ghostMinionActor = this.m_ghostMinionActor;
        switch (actor.GetEntityDef().GetCardType())
        {
            case TAG_CARDTYPE.MINION:
                if (!flag)
                {
                    ghostMinionActor = this.m_ghostMinionActor;
                }
                else
                {
                    ghostMinionActor = this.m_ghostGoldenMinionActor;
                }
                break;

            case TAG_CARDTYPE.ABILITY:
                if (!flag)
                {
                    ghostMinionActor = this.m_ghostSpellActor;
                }
                else
                {
                    ghostMinionActor = this.m_ghostGoldenSpellActor;
                }
                break;

            case TAG_CARDTYPE.WEAPON:
                if (!flag)
                {
                    ghostMinionActor = this.m_ghostWeaponActor;
                }
                else
                {
                    ghostMinionActor = this.m_ghostGoldenWeaponActor;
                }
                break;

            default:
                UnityEngine.Debug.LogError("CraftingManager.GetGhostActor() - tried to get a ghost actor for a cardtype that we haven't anticipated!!");
                break;
        }
        return this.SetUpGhostActor(ghostMinionActor, actor);
    }

    public long GetLocalArcaneDustBalance()
    {
        return this.m_arcaneDustBalance;
    }

    private Actor GetNonGhostActor(Actor actor)
    {
        this.m_isCurrentActorAGhost = false;
        return this.SetUpNonGhostActor(this.GetTemplateActor(actor), actor);
    }

    public int GetNumOwnedCopies(string cardID, CardFlair.PremiumType premium)
    {
        return (CollectionManager.Get().GetNumCopiesInCollection(cardID, premium) + this.m_transactions);
    }

    public int GetNumTransactions()
    {
        return this.m_transactions;
    }

    public Actor GetShownActor()
    {
        return this.m_currentBigActor;
    }

    public bool GetShownCardInfo(out EntityDef entityDef, out CardFlair cardFlair)
    {
        if (this.m_currentBigActor == null)
        {
            entityDef = null;
            cardFlair = null;
            return false;
        }
        entityDef = this.m_currentBigActor.GetEntityDef();
        cardFlair = this.m_currentBigActor.GetCardFlair();
        return ((entityDef != null) && (cardFlair != null));
    }

    private Actor GetTemplateActor(Actor actor)
    {
        bool flag = actor.GetCardFlair().Premium == CardFlair.PremiumType.FOIL;
        switch (actor.GetEntityDef().GetCardType())
        {
            case TAG_CARDTYPE.MINION:
                if (!flag)
                {
                    return this.m_templateMinionActor;
                }
                return this.m_templateGoldenMinionActor;

            case TAG_CARDTYPE.ABILITY:
                if (!flag)
                {
                    return this.m_templateSpellActor;
                }
                return this.m_templateGoldenSpellActor;

            case TAG_CARDTYPE.WEAPON:
                if (!flag)
                {
                    return this.m_templateWeaponActor;
                }
                return this.m_templateGoldenWeaponActor;
        }
        UnityEngine.Debug.LogError("CraftingManager.GetGhostActor() - tried to get a ghost actor for a cardtype that we haven't anticipated!!");
        return this.m_templateMinionActor;
    }

    private void GoldenMinionLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        this.m_ghostGoldenMinionActor = actorObject.GetComponent<Actor>();
        this.m_templateGoldenMinionActor = (Actor) UnityEngine.Object.Instantiate(this.m_ghostGoldenMinionActor);
        this.m_ghostGoldenMinionActor.TurnOffCollider();
        this.m_templateGoldenMinionActor.TurnOffCollider();
    }

    private void GoldenSpellLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        this.m_ghostGoldenSpellActor = actorObject.GetComponent<Actor>();
        this.m_templateGoldenSpellActor = (Actor) UnityEngine.Object.Instantiate(this.m_ghostGoldenSpellActor);
        this.m_ghostGoldenSpellActor.TurnOffCollider();
        this.m_templateGoldenSpellActor.TurnOffCollider();
    }

    private void GoldenWeaponLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        this.m_ghostGoldenWeaponActor = actorObject.GetComponent<Actor>();
        this.m_templateGoldenWeaponActor = (Actor) UnityEngine.Object.Instantiate(this.m_ghostGoldenWeaponActor);
        this.m_ghostGoldenWeaponActor.TurnOffCollider();
        this.m_templateGoldenWeaponActor.TurnOffCollider();
    }

    private void HiddenCardLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        this.m_hiddenActor = actorObject.GetComponent<Actor>();
        this.m_hiddenActor.TurnOffCollider();
        this.m_hiddenActor.GetMeshRenderer().transform.localEulerAngles = new Vector3(0f, 180f, 180f);
        SceneUtils.SetLayer(this.m_hiddenActor.gameObject, GameLayer.IgnoreFullScreenEffects);
    }

    public bool IsCancelling()
    {
        return this.m_cancellingCraftMode;
    }

    public bool IsCardShowing()
    {
        return (this.m_currentBigActor != null);
    }

    public void LoadGhostActorIfNecessary()
    {
        if (!this.m_cancellingCraftMode)
        {
            iTween.ScaleTo(this.m_cardCountTab.gameObject, new Vector3(1f, 1f, 0f), 0.4f);
            if (this.GetNumOwnedCopies(this.m_currentBigActor.GetEntityDef().GetCardId(), this.m_currentBigActor.GetCardFlair().Premium) > 0)
            {
                if (this.m_upsideDownActor == null)
                {
                    this.m_currentBigActor = this.GetAndPositionNewActor(this.m_currentBigActor, 1);
                    this.m_currentBigActor.name = "CurrentBigActor";
                    this.m_currentBigActor.transform.position = this.m_floatingCardBone.position;
                    this.m_currentBigActor.transform.localScale = this.CARD_SCALE;
                    this.m_cardCountTab.transform.position = new Vector3(0f, 307f, -10f);
                    this.SetBigActorLayer(true);
                }
                else
                {
                    this.m_upsideDownActor.transform.parent = null;
                    this.m_currentBigActor = this.m_upsideDownActor;
                    this.m_currentBigActor.name = "CurrentBigActor";
                    this.m_upsideDownActor = null;
                }
            }
            else
            {
                this.m_currentBigActor = this.GetAndPositionNewActor(this.m_currentBigActor, 0);
                this.m_currentBigActor.name = "CurrentBigActor";
                this.m_currentBigActor.transform.position = this.m_floatingCardBone.position;
                this.m_currentBigActor.transform.localScale = this.CARD_SCALE;
                this.m_cardCountTab.transform.position = new Vector3(0f, 307f, -10f);
                this.SetBigActorLayer(true);
            }
        }
    }

    public Actor LoadNewActorAndConstructIt()
    {
        if (this.m_cancellingCraftMode)
        {
            return null;
        }
        if (!this.m_isCurrentActorAGhost)
        {
            Actor currentBigActor = this.m_currentBigActor;
            if (this.m_currentBigActor == null)
            {
                currentBigActor = this.m_upsideDownActor;
            }
            else
            {
                this.m_currentBigActor.name = "Current_Big_Actor_Lost_Refernce";
            }
            this.m_currentBigActor = this.GetAndPositionNewActor(currentBigActor, 0);
            this.m_isCurrentActorAGhost = false;
            this.m_currentBigActor.name = "CurrentBigActor";
            this.m_currentBigActor.transform.position = this.m_floatingCardBone.position;
            this.m_currentBigActor.transform.localScale = this.CARD_SCALE;
            this.SetBigActorLayer(true);
        }
        this.m_currentBigActor.transform.parent = this.m_floatingCardBone;
        this.m_currentBigActor.ActivateSpell(SpellType.CONSTRUCT);
        return this.m_currentBigActor;
    }

    private void MinionGhostLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        this.m_ghostMinionActor = actorObject.GetComponent<Actor>();
        this.m_templateMinionActor = (Actor) UnityEngine.Object.Instantiate(this.m_ghostMinionActor);
        this.m_ghostMinionActor.TurnOffCollider();
        this.m_templateMinionActor.TurnOffCollider();
    }

    private void MoveCardToBigSpot(CollectionCardVisual card, bool animate)
    {
        if (card != null)
        {
            Actor oldActor = card.GetActor();
            int numOwnedCopies = this.GetNumOwnedCopies(oldActor.GetEntityDef().GetCardId(), oldActor.GetCardFlair().Premium);
            this.m_currentBigActor = this.GetAndPositionNewActor(oldActor, numOwnedCopies);
            this.m_currentBigActor.name = "CurrentBigActor";
            this.m_currentBigActor.transform.position = oldActor.transform.position;
            this.SetBigActorLayer(true);
            this.m_currentBigActor.ToggleForceIdle(true);
            this.m_currentBigActor.SetActorState(ActorStateType.CARD_IDLE);
            card.ShowNewCardCallout(false);
            if (numOwnedCopies > 1)
            {
                this.m_upsideDownActor = this.GetAndPositionNewUpsideDownActor(oldActor, true);
                this.m_upsideDownActor.name = "UpsideDownActor";
                base.StartCoroutine(this.ReplaceFaceDownActorWithHiddenCard());
            }
            if (numOwnedCopies > 0)
            {
                this.m_cardCountTab.UpdateText(numOwnedCopies);
                this.m_cardCountTab.transform.position = new Vector3(this.m_currentBigActor.transform.position.x, this.m_currentBigActor.transform.position.y - 2f, this.m_currentBigActor.transform.position.z);
            }
            if (animate)
            {
                object[] args = new object[] { "position", this.m_floatingCardBone.position, "time", 0.4f };
                iTween.MoveTo(this.m_currentBigActor.gameObject, iTween.Hash(args));
                iTween.ScaleTo(this.m_currentBigActor.gameObject, this.CARD_SCALE, 0.4f);
                if (numOwnedCopies > 0)
                {
                    iTween.MoveTo(this.m_cardCountTab.gameObject, this.m_cardCounterBone.position, 0.4f);
                }
            }
            else
            {
                this.m_currentBigActor.transform.position = this.m_floatingCardBone.position;
                this.m_currentBigActor.transform.localScale = this.CARD_SCALE;
                if (numOwnedCopies > 0)
                {
                    this.m_cardCountTab.transform.position = this.m_cardCounterBone.position;
                }
            }
        }
    }

    public void NotifyOfTransaction(int amt)
    {
        this.m_transactions += amt;
    }

    public void OnCardCreated(Network.CardSaleResult sale)
    {
        NetCache.Get().OnArcaneDustBalanceChanged((long) -sale.Amount);
        if (CollectionManager.Get().GetNumCopiesInCollection(sale.AssetName, sale.Premium) > 1)
        {
            this.OnCardCreatedPageTransitioned(sale);
        }
        else
        {
            CollectionManagerDisplay.Get().m_pageManager.RefreshCurrentPageContents(new CollectionPageManager.DelOnPageTransitionComplete(this.OnCardCreatedPageTransitioned), sale);
        }
    }

    private void OnCardCreatedPageTransitioned(object callbackData)
    {
        CollectionManagerDisplay.Get().UpdateCurrentPageCardLocks();
    }

    public void OnCardDisenchanted(Network.CardSaleResult sale)
    {
        NetCache.Get().OnArcaneDustBalanceChanged((long) sale.Amount);
        if (CollectionManager.Get().GetNumCopiesInCollection(sale.AssetName, sale.Premium) > 0)
        {
            this.OnCardDisenchantedPageTransitioned(sale);
        }
        else
        {
            CollectionManagerDisplay.Get().m_pageManager.RefreshCurrentPageContents(new CollectionPageManager.DelOnPageTransitionComplete(this.OnCardDisenchantedPageTransitioned), sale);
        }
    }

    private void OnCardDisenchantedPageTransitioned(object callbackData)
    {
        CollectionManagerDisplay.Get().UpdateCurrentPageCardLocks();
    }

    public void OnMassDisenchant(int amount)
    {
        this.AdjustLocalArcaneDustBalance(amount);
        this.craftingUI.UpdateBankText();
    }

    private void OnVignetteFinished()
    {
        this.SetBigActorLayer(false);
        if (this.GetCurrentCardVisual() != null)
        {
            this.GetCurrentCardVisual().OnDoneCrafting();
        }
        if (this.m_currentBigActor != null)
        {
            this.m_currentBigActor.name = "USED_TO_BE_CurrentBigActor";
        }
        this.m_currentBigActor = null;
        this.craftingUI.gameObject.SetActive(false);
    }

    [DebuggerHidden]
    private IEnumerator ReplaceFaceDownActorWithHiddenCard()
    {
        return new <ReplaceFaceDownActorWithHiddenCard>c__Iterator17 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator ReplaceHiddenCardwithRealActor(Actor actor)
    {
        return new <ReplaceHiddenCardwithRealActor>c__Iterator18 { actor = actor, <$>actor = actor };
    }

    private void SetBigActorLayer(bool inCraftingMode)
    {
        if (this.m_currentBigActor != null)
        {
            GameLayer layer = !inCraftingMode ? GameLayer.CardRaycast : GameLayer.IgnoreFullScreenEffects;
            SceneUtils.SetLayer(this.m_currentBigActor.gameObject, layer);
        }
    }

    private Actor SetUpGhostActor(Actor templateActor, Actor actor)
    {
        Actor actor2 = (Actor) UnityEngine.Object.Instantiate(templateActor);
        actor2.SetEntityDef(actor.GetEntityDef());
        actor2.SetCardFlair(actor.GetCardFlair());
        CardDef cardDef = (CardDef) UnityEngine.Object.Instantiate(actor.GetCardDef());
        actor2.SetCardDef(cardDef);
        actor2.UpdateAllComponents();
        actor2.ActivateSpell(SpellType.GHOSTMODE);
        cardDef.transform.parent = actor2.transform;
        actor2.UpdatePortraitTexture();
        actor2.UpdateCardColor();
        return actor2;
    }

    private Actor SetUpNonGhostActor(Actor templateActor, Actor actor)
    {
        Actor actor2 = (Actor) UnityEngine.Object.Instantiate(templateActor);
        actor2.SetEntityDef(actor.GetEntityDef());
        actor2.SetCardFlair(actor.GetCardFlair());
        CardDef cardDef = (CardDef) UnityEngine.Object.Instantiate(actor.GetCardDef());
        actor2.SetCardDef(cardDef);
        actor2.UpdateAllComponents();
        cardDef.transform.parent = actor2.transform;
        return actor2;
    }

    private void SpellGhostLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        this.m_ghostSpellActor = actorObject.GetComponent<Actor>();
        this.m_templateSpellActor = (Actor) UnityEngine.Object.Instantiate(this.m_ghostSpellActor);
        this.m_ghostSpellActor.TurnOffCollider();
        this.m_templateSpellActor.TurnOffCollider();
    }

    private void Start()
    {
        this.craftingUI.SetStartingActive();
        this.m_cardInfoPane.gameObject.SetActive(false);
        AssetLoader.Get().LoadActor("Card_Hand_Weapon", new AssetLoader.GameObjectCallback(this.WeaponGhostLoadedCallback));
        AssetLoader.Get().LoadActor("Card_Hand_Ally", new AssetLoader.GameObjectCallback(this.MinionGhostLoadedCallback));
        AssetLoader.Get().LoadActor("Card_Hand_Ability", new AssetLoader.GameObjectCallback(this.SpellGhostLoadedCallback));
        AssetLoader.Get().LoadActor("Card_Hidden", new AssetLoader.GameObjectCallback(this.HiddenCardLoadedCallback));
        AssetLoader.Get().LoadActor(ActorNames.GetHandActor(TAG_CARDTYPE.MINION, CardFlair.PremiumType.FOIL), new AssetLoader.GameObjectCallback(this.GoldenMinionLoadedCallback));
        AssetLoader.Get().LoadActor(ActorNames.GetHandActor(TAG_CARDTYPE.WEAPON, CardFlair.PremiumType.FOIL), new AssetLoader.GameObjectCallback(this.GoldenWeaponLoadedCallback));
        AssetLoader.Get().LoadActor(ActorNames.GetHandActor(TAG_CARDTYPE.ABILITY, CardFlair.PremiumType.FOIL), new AssetLoader.GameObjectCallback(this.GoldenSpellLoadedCallback));
    }

    private void TellServerAboutWhatUserDid()
    {
        Actor currentBigActor = this.m_currentBigActor;
        if (this.m_currentBigActor == null)
        {
            currentBigActor = this.m_upsideDownActor;
        }
        CardFlair cardFlair = currentBigActor.GetCardFlair();
        CardManifest.Card card = CardManifest.Get().Find(currentBigActor.GetEntityDef().GetCardId());
        Log.Ben.Print("Final Transaction Amount = " + this.m_transactions);
        for (int i = 0; i < Mathf.Abs(this.m_transactions); i++)
        {
            if (this.m_transactions < 0)
            {
                Network.SellCard(card.DatabaseAssetID, cardFlair);
            }
            else
            {
                Network.BuyCard(card.DatabaseAssetID, cardFlair);
            }
        }
        this.m_transactions = 0;
    }

    private void UpdateCardInfoPane()
    {
        this.m_cardInfoPane.gameObject.SetActive(true);
        this.m_cardInfoPane.UpdateText();
        this.m_cardInfoPane.transform.position = this.m_currentBigActor.transform.position - new Vector3(0f, 1f, 0f);
        iTween.MoveTo(this.m_cardInfoPane.gameObject, this.m_cardInfoPaneBone.position, 0.5f);
    }

    private void WeaponGhostLoadedCallback(string actorName, GameObject actorObject, object callbackData)
    {
        this.m_ghostWeaponActor = actorObject.GetComponent<Actor>();
        this.m_templateWeaponActor = (Actor) UnityEngine.Object.Instantiate(this.m_ghostWeaponActor);
        this.m_ghostWeaponActor.TurnOffCollider();
        this.m_templateWeaponActor.TurnOffCollider();
    }

    [CompilerGenerated]
    private sealed class <ReplaceFaceDownActorWithHiddenCard>c__Iterator17 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal CraftingManager <>f__this;
        internal GameObject <hiddenBuddy>__0;

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
                case 1:
                    if ((this.<>f__this.m_upsideDownActor != null) && (this.<>f__this.m_upsideDownActor.transform.localEulerAngles.z < 90f))
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    if (this.<>f__this.m_upsideDownActor != null)
                    {
                        this.<hiddenBuddy>__0 = (GameObject) UnityEngine.Object.Instantiate(this.<>f__this.m_hiddenActor.gameObject);
                        this.<>f__this.m_upsideDownActor.Hide();
                        this.<hiddenBuddy>__0.transform.parent = this.<>f__this.m_upsideDownActor.transform;
                        this.<>f__this.m_upsideDownActor.SetHiddenStandIn(this.<hiddenBuddy>__0);
                        this.<hiddenBuddy>__0.transform.localScale = new Vector3(1f, 1f, 1f);
                        this.<hiddenBuddy>__0.transform.localPosition = new Vector3(0f, 0f, 0f);
                        this.<hiddenBuddy>__0.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                        this.$PC = -1;
                    }
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
    private sealed class <ReplaceHiddenCardwithRealActor>c__Iterator18 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Actor <$>actor;
        internal GameObject <standIn>__0;
        internal Actor actor;

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
                case 1:
                    if (((this.actor != null) && (this.actor.transform.localEulerAngles.z > 90f)) && (this.actor.transform.localEulerAngles.z < 270f))
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    if (this.actor != null)
                    {
                        this.actor.Show();
                        this.<standIn>__0 = this.actor.GetHiddenStandIn();
                        if (this.<standIn>__0 != null)
                        {
                            this.<standIn>__0.SetActive(false);
                            UnityEngine.Object.Destroy(this.<standIn>__0);
                            this.$PC = -1;
                        }
                    }
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

