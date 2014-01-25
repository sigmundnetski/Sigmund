using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EndTurnButtonReminder : MonoBehaviour
{
    private List<Card> m_cardsWaitingToRemind = new List<Card>();
    public float m_MaxDelaySec = 0.3f;

    private List<Card> GenerateCardsToRemindList(GameState state, List<Card> originalList)
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < originalList.Count; i++)
        {
            Card item = originalList[i];
            if (state.HasResponse(item.GetEntity()))
            {
                list.Add(item);
            }
        }
        return list;
    }

    private void PlayReminders(List<Card> cards)
    {
        int num;
        Card card;
        do
        {
            num = UnityEngine.Random.Range(0, cards.Count);
            card = cards[num];
        }
        while (this.m_cardsWaitingToRemind.Contains(card));
        for (int i = 0; i < cards.Count; i++)
        {
            Card item = cards[i];
            Spell actorSpell = item.GetActorSpell(SpellType.WIGGLE);
            if (((actorSpell != null) && (actorSpell.GetActiveState() == SpellStateType.NONE)) && !this.m_cardsWaitingToRemind.Contains(item))
            {
                if (i == num)
                {
                    actorSpell.Activate();
                }
                else
                {
                    float objA = UnityEngine.Random.Range(0f, this.m_MaxDelaySec);
                    if (object.Equals(objA, 0f))
                    {
                        actorSpell.Activate();
                    }
                    else
                    {
                        this.m_cardsWaitingToRemind.Add(item);
                        base.StartCoroutine(this.WaitAndPlayReminder(item, actorSpell, objA));
                    }
                }
            }
        }
    }

    public bool ShowLocalPlayerTurnReminder()
    {
        GameState state = GameState.Get();
        if (state.IsMulliganPhase())
        {
            return false;
        }
        Player localPlayer = state.GetLocalPlayer();
        if (localPlayer == null)
        {
            return false;
        }
        if (!localPlayer.IsCurrentPlayer())
        {
            return false;
        }
        ZoneMgr mgr = ZoneMgr.Get();
        if (mgr == null)
        {
            return false;
        }
        ZonePlay play = mgr.FindZoneOfType<ZonePlay>(TAG_ZONE.PLAY, Player.Side.FRIENDLY);
        if (play == null)
        {
            return false;
        }
        List<Card> cards = this.GenerateCardsToRemindList(state, play.GetCards());
        if (cards.Count != 0)
        {
            this.PlayReminders(cards);
        }
        return true;
    }

    [DebuggerHidden]
    private IEnumerator WaitAndPlayReminder(Card card, Spell reminderSpell, float delay)
    {
        return new <WaitAndPlayReminder>c__Iterator38 { delay = delay, card = card, reminderSpell = reminderSpell, <$>delay = delay, <$>card = card, <$>reminderSpell = reminderSpell, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitAndPlayReminder>c__Iterator38 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <$>card;
        internal float <$>delay;
        internal Spell <$>reminderSpell;
        internal EndTurnButtonReminder <>f__this;
        internal Card card;
        internal float delay;
        internal Spell reminderSpell;

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
                    this.$current = new WaitForSeconds(this.delay);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (GameState.Get().IsLocalPlayerTurn())
                    {
                        if (this.card.GetZone() is ZonePlay)
                        {
                            this.reminderSpell.Activate();
                            this.<>f__this.m_cardsWaitingToRemind.Remove(this.card);
                            this.$PC = -1;
                        }
                        break;
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

