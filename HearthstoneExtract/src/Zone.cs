using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [CompilerGenerated]
    private static Predicate<Card> <>f__am$cache8;
    protected List<Card> m_cards = new List<Card>();
    protected List<UpdateLayoutCompleteListener> m_completeListeners = new List<UpdateLayoutCompleteListener>();
    private uint m_currentFinishLayoutTimerId;
    protected bool m_layoutDirty = true;
    protected Player m_player;
    public TAG_ZONE m_ServerTag;
    public Player.Side m_Side;
    protected bool m_updatingLayout;

    public virtual bool AddCard(Card card)
    {
        this.m_cards.Add(card);
        this.DirtyLayout();
        return true;
    }

    public bool AddUpdateLayoutCompleteCallback(UpdateLayoutCompleteCallback callback)
    {
        return this.AddUpdateLayoutCompleteCallback(callback, null);
    }

    public bool AddUpdateLayoutCompleteCallback(UpdateLayoutCompleteCallback callback, object userData)
    {
        UpdateLayoutCompleteListener item = new UpdateLayoutCompleteListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_completeListeners.Contains(item))
        {
            return false;
        }
        this.m_completeListeners.Add(item);
        return true;
    }

    public virtual bool CanAcceptTags(int controllerId, TAG_ZONE zoneTag, TAG_CARDTYPE cardType)
    {
        if (this.m_ServerTag != zoneTag)
        {
            return false;
        }
        if ((this.m_player != null) && (this.m_player.GetPlayerId() != controllerId))
        {
            return false;
        }
        if (cardType == TAG_CARDTYPE.ENCHANTMENT)
        {
            return false;
        }
        return true;
    }

    protected int CardSortComparison(Card card1, Card card2)
    {
        Entity entity = card1.GetEntity();
        Entity entity2 = card2.GetEntity();
        if ((entity == null) || (entity2 == null))
        {
            return 0;
        }
        int tag = entity.GetTag(GAME_TAG.ZONE_POSITION);
        int num2 = entity2.GetTag(GAME_TAG.ZONE_POSITION);
        return (tag - num2);
    }

    public void DirtyLayout()
    {
        this.m_layoutDirty = true;
    }

    protected void DummyUpdate(float f)
    {
    }

    protected void FireUpdateLayoutCompleteCallbacks()
    {
        if (this.m_completeListeners.Count != 0)
        {
            UpdateLayoutCompleteListener[] listenerArray = this.m_completeListeners.ToArray();
            this.m_completeListeners.Clear();
            for (int i = 0; i < listenerArray.Length; i++)
            {
                listenerArray[i].Fire(this);
            }
        }
    }

    protected string GenerateFinishLayoutTimerAnimName()
    {
        this.m_currentFinishLayoutTimerId++;
        return string.Format("{0}_FinishLayoutTimer_{1}", this, this.m_currentFinishLayoutTimerId);
    }

    public int GetCardCount()
    {
        return this.m_cards.Count;
    }

    public List<Card> GetCards()
    {
        return this.m_cards;
    }

    public Card GetFirstCard()
    {
        return ((this.m_cards.Count <= 0) ? null : this.m_cards[0]);
    }

    public Player GetPlayer()
    {
        return this.m_player;
    }

    public virtual bool InsertCard(int index, Card card)
    {
        this.m_cards.Insert(index, card);
        this.DirtyLayout();
        return true;
    }

    public bool IsLayoutDirty()
    {
        return this.m_layoutDirty;
    }

    public bool IsUpdatingLayout()
    {
        return this.m_updatingLayout;
    }

    public virtual int RemoveCard(Card card)
    {
        for (int i = 0; i < this.m_cards.Count; i++)
        {
            Card card2 = this.m_cards[i];
            if (card2 == card)
            {
                this.m_cards.RemoveAt(i);
                this.DirtyLayout();
                return i;
            }
        }
        Debug.LogWarning(string.Format("{0}.RemoveCard() - FAILED: {1} tried to remove {2}", this, this.m_player, card));
        return -1;
    }

    public bool RemoveUpdateLayoutCompleteCallback(UpdateLayoutCompleteCallback callback)
    {
        return this.RemoveUpdateLayoutCompleteCallback(callback, null);
    }

    public bool RemoveUpdateLayoutCompleteCallback(UpdateLayoutCompleteCallback callback, object userData)
    {
        UpdateLayoutCompleteListener item = new UpdateLayoutCompleteListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_completeListeners.Remove(item);
    }

    public void SetPlayer(Player player)
    {
        this.m_player = player;
    }

    protected void StartFinishLayoutTimer(float delaySec)
    {
        if (delaySec <= float.Epsilon)
        {
            this.UpdateLayoutFinished();
        }
        else
        {
            if (<>f__am$cache8 == null)
            {
                <>f__am$cache8 = card => card.IsTransitioningZones();
            }
            if (this.m_cards.Find(<>f__am$cache8) == null)
            {
                this.UpdateLayoutFinished();
            }
            else
            {
                string str = this.GenerateFinishLayoutTimerAnimName();
                object[] args = new object[] { "name", str, "time", delaySec, "from", 0f, "to", 1f, "onupdate", "DummyUpdate", "oncomplete", "UpdateLayoutFinished", "oncompletetarget", base.gameObject };
                Hashtable hashtable = iTween.Hash(args);
                iTween.ValueTo(base.gameObject, hashtable);
            }
        }
    }

    public override string ToString()
    {
        return string.Format("{1} {0}", this.m_ServerTag, this.m_Side);
    }

    public virtual void UpdateLayout()
    {
        if (this.m_cards.Count == 0)
        {
            this.UpdateLayoutFinished();
        }
        else if (GameState.Get().IsMulliganPhase())
        {
            this.UpdateLayoutFinished();
        }
        else
        {
            this.m_updatingLayout = true;
            for (int i = 0; i < this.m_cards.Count; i++)
            {
                Card card = this.m_cards[i];
                if (!card.IsDoNotSort())
                {
                    card.ShowCard();
                    card.EnableTransitioningZones(true);
                    iTween.MoveTo(card.gameObject, base.transform.position, 1f);
                    iTween.RotateTo(card.gameObject, base.transform.localEulerAngles, 1f);
                    iTween.ScaleTo(card.gameObject, base.transform.localScale, 1f);
                }
            }
            this.StartFinishLayoutTimer(1f);
        }
    }

    protected void UpdateLayoutFinished()
    {
        for (int i = 0; i < this.m_cards.Count; i++)
        {
            this.m_cards[i].EnableTransitioningZones(false);
        }
        this.m_updatingLayout = false;
        this.m_layoutDirty = false;
        this.FireUpdateLayoutCompleteCallbacks();
    }

    public delegate void UpdateLayoutCompleteCallback(Zone zone, object userData);

    protected class UpdateLayoutCompleteListener : EventListener<Zone.UpdateLayoutCompleteCallback>
    {
        public void Fire(Zone zone)
        {
            base.m_callback(zone, base.m_userData);
        }
    }
}

