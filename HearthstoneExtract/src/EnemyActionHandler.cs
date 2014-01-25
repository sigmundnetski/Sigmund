using System;
using UnityEngine;

public class EnemyActionHandler : MonoBehaviour
{
    private const float DRIFT_TIME = 10f;
    private UserUI enemyActualUI = new UserUI();
    private UserUI enemyWantedUI = new UserUI();
    private readonly TimeSpan HIGH_FREQ = new TimeSpan(0, 0, 0, 0, 100);
    private DateTime lastSendHighPrio = DateTime.Now;
    private DateTime lastSendLowPrio = DateTime.Now;
    private readonly TimeSpan LOW_FREQ = new TimeSpan(0, 0, 0, 0, 350);
    private UserUI myCurrentUI = new UserUI();
    private UserUI myLastUI = new UserUI();
    private static EnemyActionHandler s_instance;

    private void Awake()
    {
        s_instance = this;
    }

    private bool CanSendUI()
    {
        if (MissionMgr.Get().IsPlayingAI())
        {
            return false;
        }
        if (this.WantTargetArrow() && ((DateTime.Now - this.lastSendHighPrio) > this.HIGH_FREQ))
        {
            this.lastSendHighPrio = DateTime.Now;
            return true;
        }
        if ((DateTime.Now - this.lastSendLowPrio) < this.LOW_FREQ)
        {
            return false;
        }
        this.lastSendLowPrio = DateTime.Now;
        return true;
    }

    private void DriftLeftAndRight()
    {
        if (this.enemyActualUI.held.card != null)
        {
            Card card = this.enemyActualUI.held.card;
            Zone zone = card.GetZone();
            if ((zone != null) && (zone.m_ServerTag == TAG_ZONE.HAND))
            {
                card.EnableTransitioningZones(false);
                object[] args = new object[] { "path", iTweenPath.GetPath("driftPath1"), "time", 10f, "easetype", iTween.EaseType.linear, "oncomplete", "DriftLeftAndRight", "oncompletetarget", base.gameObject };
                iTween.MoveTo(card.gameObject, iTween.Hash(args));
            }
        }
    }

    private void DriftRotateLeft()
    {
        if (this.enemyActualUI.held.card != null)
        {
            Card card = this.enemyActualUI.held.card;
            Zone zone = card.GetZone();
            if ((zone != null) && (zone.m_ServerTag == TAG_ZONE.HAND))
            {
                object[] args = new object[] { "rotation", new Vector3(0f, 0f, 10f), "time", 5f, "easetype", iTween.EaseType.easeInOutSine, "oncomplete", "DriftRotateRight", "oncompletetarget", base.gameObject };
                iTween.RotateTo(card.gameObject, iTween.Hash(args));
            }
        }
    }

    private void DriftRotateRight()
    {
        if (this.enemyActualUI.held.card != null)
        {
            Card card = this.enemyActualUI.held.card;
            Zone zone = card.GetZone();
            if ((zone != null) && (zone.m_ServerTag == TAG_ZONE.HAND))
            {
                object[] args = new object[] { "rotation", new Vector3(0f, 0f, -10f), "time", 5f, "easetype", iTween.EaseType.easeInOutSine, "oncomplete", "DriftRotateLeft", "oncompletetarget", base.gameObject };
                iTween.RotateTo(card.gameObject, iTween.Hash(args));
            }
        }
    }

    public static EnemyActionHandler Get()
    {
        return s_instance;
    }

    public void HandleAction(Network.UserUI newData)
    {
        if (newData.mouseInfo != null)
        {
            this.enemyWantedUI.held.ID = newData.mouseInfo.HeldCardID;
            this.enemyWantedUI.over.ID = newData.mouseInfo.OverCardID;
            this.enemyWantedUI.origin.ID = newData.mouseInfo.ArrowOriginID;
            this.UpdateCardOver();
            this.UpdateCardHeld();
            this.MaybeDestroyArrow();
            this.MaybeCreateArrow();
            this.UpdateTargetArrow();
        }
        else if (newData.emoteInfo != null)
        {
            GameState.Get().GetRemotePlayer().GetHeroCard().PlayEmote((EmoteType) newData.emoteInfo.Emote);
        }
    }

    private int HandPosition()
    {
        if (this.enemyActualUI.over.entity == null)
        {
            return -1;
        }
        if (this.enemyActualUI.over.entity.GetZone() != TAG_ZONE.HAND)
        {
            return -1;
        }
        if (this.enemyActualUI.over.entity.GetController().IsLocal())
        {
            return -1;
        }
        return (this.enemyActualUI.over.entity.GetTag(GAME_TAG.ZONE_POSITION) - 1);
    }

    private void MaybeCreateArrow()
    {
        if (((!TargetReticleManager.Get().IsActive() && (this.enemyWantedUI.origin.card != null)) && (this.enemyActualUI.over.card != null)) && (this.enemyActualUI.over.card != this.enemyWantedUI.origin.card))
        {
            this.enemyActualUI.origin.card = this.enemyWantedUI.origin.card;
            TargetReticleManager.Get().CreateEnemyTargetArrow(this.enemyActualUI.origin.entity);
            this.SetArrowTarget();
        }
    }

    private void MaybeDestroyArrow()
    {
        if (TargetReticleManager.Get().IsActive() && (this.enemyWantedUI.origin.card != this.enemyActualUI.origin.card))
        {
            this.enemyActualUI.origin.card = null;
            TargetReticleManager.Get().DestroyEnemyTargetArrow();
        }
    }

    public void NotifyOpponentOfCardDropped()
    {
        this.myCurrentUI.held.card = null;
    }

    public void NotifyOpponentOfCardPickedUp(Card card)
    {
        this.myCurrentUI.held.card = card;
    }

    public void NotifyOpponentOfMouseOut()
    {
        this.myCurrentUI.over.card = null;
    }

    public void NotifyOpponentOfMouseOverEntity(Card card)
    {
        this.myCurrentUI.over.card = card;
    }

    public void NotifyOpponentOfTargetEnd()
    {
        this.myCurrentUI.origin.card = null;
    }

    public void NotifyOpponentOfTargetModeBegin(Card card)
    {
        this.myCurrentUI.origin.card = card;
    }

    private void SetArrowTarget()
    {
        RaycastHit hit;
        Vector3 position = Camera.main.transform.position;
        Vector3 vector2 = this.enemyActualUI.over.card.transform.position;
        Ray ray = new Ray(position, vector2 - position);
        if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane, GameLayer.DragPlane.LayerBit()))
        {
            TargetReticleManager.Get().EnemyArrowPosition = hit.point;
        }
    }

    private void StartDrift()
    {
        this.DriftLeftAndRight();
        this.DriftRotateRight();
    }

    private void Update()
    {
        TargetReticleManager.Get().UpdateArrowPosition();
        if (!this.myCurrentUI.SameAs(this.myLastUI) && this.CanSendUI())
        {
            Network.Get().SendUserUI(this.myCurrentUI.over.ID, this.myCurrentUI.held.ID, this.myCurrentUI.origin.ID, 0, 0);
            this.myLastUI.CopyFrom(this.myCurrentUI);
        }
    }

    private void UpdateCardHeld()
    {
        this.enemyActualUI.held.card = this.enemyWantedUI.held.card;
        if (this.enemyActualUI.held.card != null)
        {
            Card card = this.enemyActualUI.held.card;
            Zone zone = card.GetZone();
            if ((zone != null) && (zone.m_ServerTag == TAG_ZONE.HAND))
            {
                card.EnableTransitioningZones(false);
                object[] args = new object[] { "position", Board.Get().FindBone("EnemyCardPlayingSpot").position, "time", 1f, "oncomplete", "StartDrift", "oncompletetarget", base.gameObject };
                iTween.MoveTo(card.gameObject, iTween.Hash(args));
            }
        }
    }

    private void UpdateCardOver()
    {
        if (this.enemyWantedUI.over.card != this.enemyActualUI.over.card)
        {
            if (this.enemyActualUI.over.card != null)
            {
                this.enemyActualUI.over.card.NotifyOpponentMousedOffThisCard();
            }
            this.enemyActualUI.over.card = this.enemyWantedUI.over.card;
            if (this.enemyActualUI.over.card != null)
            {
                this.enemyActualUI.over.card.NotifyOpponentMousedOverThisCard();
            }
            ZoneMgr.Get().FindZoneOfType<ZoneHand>(TAG_ZONE.HAND, Player.Side.OPPOSING).UpdateLayout(this.HandPosition());
        }
    }

    private void UpdateTargetArrow()
    {
        if (TargetReticleManager.Get().IsActive() && (this.enemyActualUI.over.card != null))
        {
            this.SetArrowTarget();
        }
    }

    private bool WantTargetArrow()
    {
        if (this.myCurrentUI.origin.card == null)
        {
            return false;
        }
        if (this.myCurrentUI.over.card == null)
        {
            return false;
        }
        if (this.myCurrentUI.over.card == this.myCurrentUI.origin.card)
        {
            return false;
        }
        return ((this.myCurrentUI.origin.card != this.myLastUI.origin.card) || (this.myCurrentUI.over.card != this.myLastUI.over.card));
    }

    public Card OpponentHeldCard
    {
        get
        {
            return this.enemyActualUI.held.card;
        }
    }

    private class CardAndID
    {
        private Card m_card;
        private Entity m_entity;
        private int m_ID;

        private void Clear()
        {
            this.m_ID = 0;
            this.m_entity = null;
            this.m_card = null;
        }

        public Card card
        {
            get
            {
                return this.m_card;
            }
            set
            {
                if (value != this.m_card)
                {
                    if (value == null)
                    {
                        this.Clear();
                    }
                    else
                    {
                        this.m_card = value;
                        this.m_entity = value.GetEntity();
                        if (this.m_entity == null)
                        {
                            Debug.LogWarning("EnemyActionHandler--card has no entity");
                            this.Clear();
                        }
                        else
                        {
                            this.m_ID = this.m_entity.GetEntityId();
                            if (this.m_ID < 1)
                            {
                                Debug.LogWarning("EnemyActionHandler--invalid entity ID");
                                this.Clear();
                            }
                        }
                    }
                }
            }
        }

        public Entity entity
        {
            get
            {
                return this.m_entity;
            }
        }

        public int ID
        {
            get
            {
                return this.m_ID;
            }
            set
            {
                if (value != this.m_ID)
                {
                    if (value == 0)
                    {
                        this.Clear();
                    }
                    else
                    {
                        this.m_ID = value;
                        this.m_entity = GameState.Get().GetEntity(value);
                        if (this.m_entity == null)
                        {
                            Debug.LogWarning("EnemyActionHandler--no entity found for ID");
                            this.Clear();
                        }
                        else
                        {
                            this.m_card = this.m_entity.GetCard();
                            if (this.m_card == null)
                            {
                                Debug.LogWarning("EnemyActionHandler--entity has no card");
                                this.Clear();
                            }
                        }
                    }
                }
            }
        }
    }

    private class UserUI
    {
        public EnemyActionHandler.CardAndID held = new EnemyActionHandler.CardAndID();
        public EnemyActionHandler.CardAndID origin = new EnemyActionHandler.CardAndID();
        public EnemyActionHandler.CardAndID over = new EnemyActionHandler.CardAndID();

        public void CopyFrom(EnemyActionHandler.UserUI source)
        {
            this.held.ID = source.held.ID;
            this.over.ID = source.over.ID;
            this.origin.ID = source.origin.ID;
        }

        public bool SameAs(EnemyActionHandler.UserUI compare)
        {
            if (this.held.card != compare.held.card)
            {
                return false;
            }
            if (this.over.card != compare.over.card)
            {
                return false;
            }
            if (this.origin.card != compare.origin.card)
            {
                return false;
            }
            return true;
        }
    }
}

