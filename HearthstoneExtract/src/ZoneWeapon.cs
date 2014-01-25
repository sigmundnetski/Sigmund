using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ZoneWeapon : Zone
{
    private readonly string LAYOUT_WEAPONS_COROUTINE = "LayoutWeapons";
    private List<Card> m_weaponsToDestroy = new List<Card>();
    private Card m_weaponToEquip;
    private readonly float WEAPON_EQUIP_DROP_IN_SOCKET_TIME = 0.1f;
    private readonly float WEAPON_EQUIP_MOVE_TO_SOCKET_TIME = 0.9f;

    public override bool AddCard(Card card)
    {
        bool flag = base.AddCard(card);
        if (flag)
        {
            this.SaveNewWeapon(card);
        }
        return flag;
    }

    private void Awake()
    {
    }

    public override bool CanAcceptTags(int controllerId, TAG_ZONE zoneTag, TAG_CARDTYPE cardType)
    {
        if (!base.CanAcceptTags(controllerId, zoneTag, cardType))
        {
            return false;
        }
        if (cardType != TAG_CARDTYPE.WEAPON)
        {
            return false;
        }
        return true;
    }

    public override bool InsertCard(int index, Card card)
    {
        bool flag = base.InsertCard(index, card);
        if (flag)
        {
            this.SaveNewWeapon(card);
        }
        return flag;
    }

    [DebuggerHidden]
    private IEnumerator LayoutWeapons()
    {
        return new <LayoutWeapons>c__Iterator6A { <>f__this = this };
    }

    public override int RemoveCard(Card card)
    {
        int num = base.RemoveCard(card);
        if (num >= 0)
        {
            if (!this.m_weaponsToDestroy.Contains(card))
            {
                this.m_weaponsToDestroy.Add(card);
            }
            if ((this.m_weaponToEquip != null) && this.m_weaponToEquip.Equals(card))
            {
                this.m_weaponToEquip = null;
            }
        }
        return num;
    }

    private void SaveNewWeapon(Card newWeaponCard)
    {
        if (newWeaponCard == null)
        {
            UnityEngine.Debug.LogError("ZoneWeapon.SaveNewWeapon() - newWeaponCard is NULL");
        }
        else
        {
            foreach (Card card in base.m_cards)
            {
                if (!card.Equals(newWeaponCard))
                {
                    this.m_weaponsToDestroy.Add(card);
                }
            }
            this.m_weaponToEquip = newWeaponCard;
        }
    }

    public override string ToString()
    {
        return string.Format("{0} (Weapon)", base.ToString());
    }

    public override void UpdateLayout()
    {
        if ((this.m_weaponsToDestroy.Count <= 0) && (this.m_weaponToEquip == null))
        {
            if (base.m_cards.Count > 0)
            {
                Log.Rachelle.Print(string.Format("ZoneWeapon.UpdateLayout() - WARNING there are {0} cards in this zone but it doesn't think it needs to update its layout", base.m_cards.Count));
            }
            base.UpdateLayoutFinished();
        }
        else if (GameState.Get().IsMulliganPhase())
        {
            base.UpdateLayoutFinished();
        }
        else
        {
            base.StopCoroutine(this.LAYOUT_WEAPONS_COROUTINE);
            base.StartCoroutine(this.LAYOUT_WEAPONS_COROUTINE);
        }
    }

    [CompilerGenerated]
    private sealed class <LayoutWeapons>c__Iterator6A : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ZoneWeapon <>f__this;
        internal Vector3 <intermediatePosition>__1;
        internal Hashtable <moveArgs>__2;
        internal Card <newWeaponCard>__0;

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
                    this.<>f__this.m_updatingLayout = true;
                    if (this.<>f__this.m_weaponsToDestroy.Count <= 0)
                    {
                        break;
                    }
                    this.<>f__this.m_weaponsToDestroy.Clear();
                    this.$current = new WaitForSeconds(1.75f);
                    this.$PC = 1;
                    goto Label_0275;

                case 1:
                    break;

                case 2:
                    if (this.<newWeaponCard>__0.Equals(this.<>f__this.m_weaponToEquip))
                    {
                        this.<>f__this.m_weaponToEquip = null;
                        object[] args = new object[] { "position", this.<>f__this.transform.position, "time", this.<>f__this.WEAPON_EQUIP_DROP_IN_SOCKET_TIME, "easetype", iTween.EaseType.easeOutCubic };
                        this.<moveArgs>__2 = iTween.Hash(args);
                        iTween.MoveTo(this.<newWeaponCard>__0.gameObject, this.<moveArgs>__2);
                        this.<>f__this.StartFinishLayoutTimer(this.<>f__this.WEAPON_EQUIP_DROP_IN_SOCKET_TIME);
                        this.$PC = -1;
                    }
                    else
                    {
                        this.<>f__this.UpdateLayoutFinished();
                    }
                    goto Label_0273;

                default:
                    goto Label_0273;
            }
            if (this.<>f__this.m_weaponToEquip == null)
            {
                this.<>f__this.UpdateLayoutFinished();
            }
            else
            {
                this.<newWeaponCard>__0 = this.<>f__this.m_weaponToEquip;
                if (this.<newWeaponCard>__0.IsDoNotSort())
                {
                    UnityEngine.Debug.LogWarning(string.Format("ZoneWeapon.LayoutWeapons(): m_weaponToEquip ({0}) is do not sort; going to show it anyway", this.<newWeaponCard>__0));
                }
                this.<newWeaponCard>__0.ShowCard();
                this.<newWeaponCard>__0.EnableTransitioningZones(true);
                this.<intermediatePosition>__1 = this.<>f__this.transform.position;
                this.<intermediatePosition>__1.y += 1.5f;
                iTween.MoveTo(this.<newWeaponCard>__0.gameObject, this.<intermediatePosition>__1, this.<>f__this.WEAPON_EQUIP_MOVE_TO_SOCKET_TIME);
                iTween.RotateTo(this.<newWeaponCard>__0.gameObject, this.<>f__this.transform.localEulerAngles, this.<>f__this.WEAPON_EQUIP_MOVE_TO_SOCKET_TIME);
                iTween.ScaleTo(this.<newWeaponCard>__0.gameObject, this.<>f__this.transform.localScale, this.<>f__this.WEAPON_EQUIP_MOVE_TO_SOCKET_TIME);
                this.$current = new WaitForSeconds(this.<>f__this.WEAPON_EQUIP_MOVE_TO_SOCKET_TIME);
                this.$PC = 2;
                goto Label_0275;
            }
        Label_0273:
            return false;
        Label_0275:
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
}

