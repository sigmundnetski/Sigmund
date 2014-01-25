using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BrawlSpell : Spell
{
    public float m_HoldTime = 0.1f;
    public float m_JumpInDuration = 1.5f;
    public iTween.EaseType m_JumpInEaseType = iTween.EaseType.linear;
    public float m_JumpOutDuration = 1.5f;
    public iTween.EaseType m_JumpOutEaseType = iTween.EaseType.easeOutBounce;
    private int m_jumpsPending;
    public List<GameObject> m_LeftJumpOutBones;
    public float m_MaxJumpHeight = 2.5f;
    public float m_MaxJumpInDelay = 0.2f;
    public float m_MaxJumpOutDelay = 0.2f;
    public float m_MinJumpHeight = 1.5f;
    public float m_MinJumpInDelay = 0.1f;
    public float m_MinJumpOutDelay = 0.1f;
    public List<GameObject> m_RightJumpOutBones;
    private Card m_survivorCard;
    public float m_SurvivorHoldDuration = 0.5f;

    private Card FindSurvivor()
    {
        foreach (ZonePlay play in ZoneMgr.Get().FindZonesOfType<ZonePlay>())
        {
            List<Card> cards = play.GetCards();
            <FindSurvivor>c__AnonStorey13F storeyf = new <FindSurvivor>c__AnonStorey13F();
            using (List<Card>.Enumerator enumerator2 = cards.GetEnumerator())
            {
                while (enumerator2.MoveNext())
                {
                    storeyf.playCard = enumerator2.Current;
                    if (base.m_targets.Find(new Predicate<GameObject>(storeyf.<>m__45)) == null)
                    {
                        return storeyf.playCard;
                    }
                }
                continue;
            }
        }
        return null;
    }

    private GameObject GetFreeBone(List<GameObject> boneList, List<int> usedBoneIndexes)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < boneList.Count; i++)
        {
            if (!usedBoneIndexes.Contains(i))
            {
                list.Add(i);
            }
        }
        if (list.Count == 0)
        {
            return null;
        }
        int num2 = UnityEngine.Random.Range(0, list.Count - 1);
        int item = list[num2];
        usedBoneIndexes.Add(item);
        return boneList[item];
    }

    protected override Card GetTargetCardFromPowerTask(PowerTask task)
    {
        Network.PowerHistory power = task.GetPower();
        if (power.Type != Network.PowerHistory.PowType.TAG_CHANGE)
        {
            return null;
        }
        Network.HistTagChange change = power as Network.HistTagChange;
        if (change.Tag != 360)
        {
            return null;
        }
        if (change.Value != 1)
        {
            return null;
        }
        Entity entity = GameState.Get().GetEntity(change.Entity);
        if (entity == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("{0}.GetTargetCardFromPowerTask() - WARNING trying to target entity with id {1} but there is no entity with that id", this, change.Entity));
            return null;
        }
        return entity.GetCard();
    }

    [DebuggerHidden]
    private IEnumerator Hold()
    {
        return new <Hold>c__IteratorA5 { <>f__this = this };
    }

    private bool IsSurvivorAlone()
    {
        Zone zone = this.m_survivorCard.GetZone();
        foreach (GameObject obj2 in base.m_targets)
        {
            if (obj2.GetComponent<Card>().GetZone() == zone)
            {
                return false;
            }
        }
        return true;
    }

    [DebuggerHidden]
    private IEnumerator JumpIn(Card card, float delaySec)
    {
        return new <JumpIn>c__IteratorA4 { card = card, delaySec = delaySec, <$>card = card, <$>delaySec = delaySec, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator JumpOut(Card card, float delaySec, Vector3 destPos)
    {
        return new <JumpOut>c__IteratorA6 { delaySec = delaySec, card = card, destPos = destPos, <$>delaySec = delaySec, <$>card = card, <$>destPos = destPos, <>f__this = this };
    }

    protected override void OnAction(SpellStateType prevStateType)
    {
        this.m_survivorCard = this.FindSurvivor();
        this.StartJumpIns();
    }

    private void OnJumpInComplete(Card targetCard)
    {
        targetCard.HideCard();
        this.m_jumpsPending--;
        if (this.m_jumpsPending <= 0)
        {
            base.StartCoroutine(this.Hold());
        }
    }

    private void OnJumpOutComplete(Card targetCard)
    {
        this.m_jumpsPending--;
        if (this.m_jumpsPending <= 0)
        {
            targetCard.SetDoNotSort(false);
            base.ActivateState(SpellStateType.DEATH);
            base.StartCoroutine(this.SurvivorHold());
        }
    }

    private void StartJumpIn(Card card, ref float startSec)
    {
        float num = UnityEngine.Random.Range(this.m_MinJumpInDelay, this.m_MaxJumpInDelay);
        base.StartCoroutine(this.JumpIn(card, startSec + num));
        startSec += num;
    }

    private void StartJumpIns()
    {
        this.m_jumpsPending = base.m_targets.Count + 1;
        float startSec = 0f;
        for (int i = 0; i < base.m_targets.Count; i++)
        {
            Card component = base.m_targets[i].GetComponent<Card>();
            this.StartJumpIn(component, ref startSec);
        }
        this.StartJumpIn(this.m_survivorCard, ref startSec);
    }

    private void StartJumpOuts()
    {
        this.m_jumpsPending = base.m_targets.Count;
        List<int> usedBoneIndexes = new List<int>();
        List<int> list2 = new List<int>();
        float num = 0f;
        bool flag = true;
        for (int i = 0; i < base.m_targets.Count; i++)
        {
            Card component = base.m_targets[i].GetComponent<Card>();
            if (component != this.m_survivorCard)
            {
                GameObject freeBone = null;
                if (flag)
                {
                    freeBone = this.GetFreeBone(this.m_LeftJumpOutBones, usedBoneIndexes);
                    if (freeBone == null)
                    {
                        usedBoneIndexes.Clear();
                        freeBone = this.GetFreeBone(this.m_LeftJumpOutBones, usedBoneIndexes);
                    }
                }
                else
                {
                    freeBone = this.GetFreeBone(this.m_RightJumpOutBones, list2);
                    if (freeBone == null)
                    {
                        list2.Clear();
                        freeBone = this.GetFreeBone(this.m_RightJumpOutBones, list2);
                    }
                }
                float num3 = UnityEngine.Random.Range(this.m_MinJumpOutDelay, this.m_MaxJumpOutDelay);
                base.StartCoroutine(this.JumpOut(component, num + num3, freeBone.transform.position));
                num += num3;
                flag = !flag;
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator SurvivorHold()
    {
        return new <SurvivorHold>c__IteratorA7 { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <FindSurvivor>c__AnonStorey13F
    {
        internal Card playCard;

        internal bool <>m__45(GameObject testObject)
        {
            return (this.playCard == testObject.GetComponent<Card>());
        }
    }

    [CompilerGenerated]
    private sealed class <Hold>c__IteratorA5 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal BrawlSpell <>f__this;

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
                    this.$current = new WaitForSeconds(this.<>f__this.m_HoldTime);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.StartJumpOuts();
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
    private sealed class <JumpIn>c__IteratorA4 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <$>card;
        internal float <$>delaySec;
        internal BrawlSpell <>f__this;
        internal Hashtable <argTable>__2;
        internal float <jumpHeight>__1;
        internal Vector3[] <path>__0;
        internal Card card;
        internal float delaySec;

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
                    this.card.SetDoNotSort(true);
                    this.$current = new WaitForSeconds(this.delaySec);
                    this.$PC = 1;
                    return true;

                case 1:
                {
                    this.<path>__0 = new Vector3[3];
                    this.<path>__0[0] = this.card.transform.position;
                    this.<path>__0[2] = this.<>f__this.transform.position;
                    this.<path>__0[1] = (Vector3) (0.5f * (this.<path>__0[0] + this.<path>__0[2]));
                    this.<jumpHeight>__1 = UnityEngine.Random.Range(this.<>f__this.m_MinJumpHeight, this.<>f__this.m_MaxJumpHeight);
                    this.<path>__0[1].y += this.<jumpHeight>__1;
                    object[] args = new object[] { "path", this.<path>__0, "orienttopath", true, "time", this.<>f__this.m_JumpInDuration, "easetype", this.<>f__this.m_JumpInEaseType, "oncomplete", "OnJumpInComplete", "oncompletetarget", this.<>f__this.gameObject, "oncompleteparams", this.card };
                    this.<argTable>__2 = iTween.Hash(args);
                    iTween.MoveTo(this.card.gameObject, this.<argTable>__2);
                    this.$PC = -1;
                    break;
                }
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
    private sealed class <JumpOut>c__IteratorA6 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <$>card;
        internal float <$>delaySec;
        internal Vector3 <$>destPos;
        internal BrawlSpell <>f__this;
        internal Hashtable <argTable>__2;
        internal float <jumpHeight>__1;
        internal Vector3[] <path>__0;
        internal Card card;
        internal float delaySec;
        internal Vector3 destPos;

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
                    this.$current = new WaitForSeconds(this.delaySec);
                    this.$PC = 1;
                    return true;

                case 1:
                {
                    this.card.transform.rotation = Quaternion.identity;
                    this.card.ShowCard();
                    this.<path>__0 = new Vector3[3];
                    this.<path>__0[0] = this.card.transform.position;
                    this.<path>__0[2] = this.destPos;
                    this.<path>__0[1] = (Vector3) (0.5f * (this.<path>__0[0] + this.<path>__0[2]));
                    this.<jumpHeight>__1 = UnityEngine.Random.Range(this.<>f__this.m_MinJumpHeight, this.<>f__this.m_MaxJumpHeight);
                    this.<path>__0[1].y += this.<jumpHeight>__1;
                    object[] args = new object[] { "path", this.<path>__0, "time", this.<>f__this.m_JumpOutDuration, "easetype", this.<>f__this.m_JumpOutEaseType, "oncomplete", "OnJumpOutComplete", "oncompletetarget", this.<>f__this.gameObject, "oncompleteparams", this.card };
                    this.<argTable>__2 = iTween.Hash(args);
                    iTween.MoveTo(this.card.gameObject, this.<argTable>__2);
                    this.$PC = -1;
                    break;
                }
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
    private sealed class <SurvivorHold>c__IteratorA7 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal BrawlSpell <>f__this;

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
                    this.<>f__this.m_survivorCard.transform.rotation = Quaternion.identity;
                    this.<>f__this.m_survivorCard.ShowCard();
                    this.$current = new WaitForSeconds(this.<>f__this.m_SurvivorHoldDuration);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (this.<>f__this.IsSurvivorAlone())
                    {
                        this.<>f__this.m_survivorCard.GetZone().UpdateLayout();
                    }
                    this.<>f__this.m_survivorCard.SetDoNotSort(false);
                    this.<>f__this.OnSpellFinished();
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

