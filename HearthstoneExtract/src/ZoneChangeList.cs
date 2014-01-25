using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ZoneChangeList
{
    [CompilerGenerated]
    private static Predicate<ZoneChange> <>f__am$cache7;
    private List<ZoneChange> m_changes = new List<ZoneChange>();
    private bool m_complete;
    private ZoneMgr.ChangeCompleteCallback m_completeCallback;
    private object m_completeCallbackUserData;
    private HashSet<Zone> m_dirtyZones = new HashSet<Zone>();
    private int m_id;
    private PowerTaskList m_taskList;

    public void AddChange(ZoneChange change)
    {
        this.m_changes.Add(change);
    }

    private void ApplyLocalChanges(Entity entity, int srcPos, int dstPos, bool zonePosChanged, Zone srcZone, TAG_ZONE srcZoneTag, Zone dstZone, TAG_ZONE dstZoneTag, bool zoneChanged, int srcControllerId, int dstControllerId, bool controllerChanged)
    {
        TagDeltaSet changeSet = new TagDeltaSet();
        if (zonePosChanged)
        {
            changeSet.Add<int>(GAME_TAG.ZONE_POSITION, srcPos, dstPos);
            entity.SetTag(GAME_TAG.ZONE_POSITION, dstPos);
        }
        if (zoneChanged)
        {
            changeSet.Add<TAG_ZONE>(GAME_TAG.ZONE, srcZoneTag, dstZoneTag);
            entity.SetTag<TAG_ZONE>(GAME_TAG.ZONE, dstZoneTag);
        }
        if (controllerChanged)
        {
            changeSet.Add<int>(GAME_TAG.CONTROLLER, srcControllerId, dstControllerId);
            entity.SetTag(GAME_TAG.CONTROLLER, dstControllerId);
        }
        if (changeSet.Size() > 1)
        {
            entity.OnTagsChanged(changeSet);
        }
        else if (changeSet.Size() > 0)
        {
            entity.OnTagChanged(changeSet[0]);
        }
    }

    private void CheckAndFinishChanges()
    {
        if (this.m_dirtyZones.Count <= 0)
        {
            this.m_complete = true;
        }
    }

    public void ClearChanges()
    {
        this.m_changes.Clear();
    }

    [Conditional("ZONE_CHANGE_DEBUG")]
    private void DebugPrint(string format, params object[] args)
    {
        string str = string.Format(format, args);
        Log.Zone.ScreenPrint(str, new object[0]);
    }

    public ZoneChange FindFirstZoneChange()
    {
        if (<>f__am$cache7 == null)
        {
            <>f__am$cache7 = change => change.GetDestinationZoneTag() != TAG_ZONE.NONE;
        }
        return this.m_changes.Find(<>f__am$cache7);
    }

    public void FireCompleteCallback()
    {
        object[] args = new object[] { this.m_id, (this.m_taskList != null) ? this.m_taskList.GetId().ToString() : "(null)", this.m_changes.Count, this.m_complete, (this.m_completeCallback != null) ? "(not null)" : "(null)" };
        this.DebugPrint("ZoneChangeList.FireCompleteCallback() - m_id={0} m_taskList={1} m_changes.Count={2} m_complete={3} m_completeCallback={4}", args);
        if (this.m_completeCallback != null)
        {
            this.m_completeCallback(this.m_completeCallbackUserData);
        }
    }

    public ZoneChange GetChange(int index)
    {
        return this.m_changes[index];
    }

    public List<ZoneChange> GetChanges()
    {
        return this.m_changes;
    }

    public ZoneMgr.ChangeCompleteCallback GetCompleteCallback()
    {
        return this.m_completeCallback;
    }

    public object GetCompleteCallbackUserData()
    {
        return this.m_completeCallbackUserData;
    }

    public int GetId()
    {
        return this.m_id;
    }

    public PowerTaskList GetTaskList()
    {
        return this.m_taskList;
    }

    public bool IsComplete()
    {
        return this.m_complete;
    }

    private bool IsEntityLoading(Entity entity)
    {
        return !entity.IsCardReady();
    }

    private bool IsEntityLoading(Entity entity, Card card)
    {
        return (!entity.IsCardReady() || card.IsActorLoading());
    }

    public bool IsLocal()
    {
        return (this.m_taskList == null);
    }

    private void OnUpdateLayoutComplete(Zone zone, object userData)
    {
        object[] args = new object[] { this.m_id, zone };
        this.DebugPrint("ZoneChangeList.OnUpdateLayoutComplete() - m_id={0} END waiting for zone {1}", args);
        this.m_dirtyZones.Remove(zone);
        this.CheckAndFinishChanges();
    }

    [DebuggerHidden]
    public IEnumerator ProcessChanges()
    {
        return new <ProcessChanges>c__Iterator63 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator ProcessZoneUpdates(MonoBehaviour coroutineHost, HashSet<Entity> loadingEntities)
    {
        return new <ProcessZoneUpdates>c__Iterator67 { loadingEntities = loadingEntities, coroutineHost = coroutineHost, <$>loadingEntities = loadingEntities, <$>coroutineHost = coroutineHost, <>f__this = this };
    }

    public void SetCompleteCallback(ZoneMgr.ChangeCompleteCallback callback)
    {
        this.m_completeCallback = callback;
    }

    public void SetCompleteCallbackUserData(object userData)
    {
        this.m_completeCallbackUserData = userData;
    }

    public void SetId(int id)
    {
        this.m_id = id;
    }

    public void SetTaskList(PowerTaskList taskList)
    {
        this.m_taskList = taskList;
    }

    [DebuggerHidden]
    private IEnumerator WaitForAndRemoveLoadingEntity(HashSet<Entity> loadingEntities, Entity entity)
    {
        return new <WaitForAndRemoveLoadingEntity>c__Iterator64 { entity = entity, loadingEntities = loadingEntities, <$>entity = entity, <$>loadingEntities = loadingEntities, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitForAndRemoveLoadingEntity(HashSet<Entity> loadingEntities, Entity entity, Card card)
    {
        return new <WaitForAndRemoveLoadingEntity>c__Iterator65 { entity = entity, card = card, loadingEntities = loadingEntities, <$>entity = entity, <$>card = card, <$>loadingEntities = loadingEntities, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitForSingleCardTransition(Card card, Zone oldZone, Zone newZone)
    {
        return new <WaitForSingleCardTransition>c__Iterator66 { oldZone = oldZone, newZone = newZone, card = card, <$>oldZone = oldZone, <$>newZone = newZone, <$>card = card };
    }

    [DebuggerHidden]
    private IEnumerator ZoneHand_UpdateLayout(ZoneHand zoneHand)
    {
        return new <ZoneHand_UpdateLayout>c__Iterator68 { zoneHand = zoneHand, <$>zoneHand = zoneHand, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <ProcessChanges>c__Iterator63 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ZoneChangeList <>f__this;
        internal Card <card>__6;
        internal ZoneChange <change>__4;
        internal bool <controllerChanged>__17;
        internal MonoBehaviour <coroutineHost>__0;
        internal int <dstControllerId>__14;
        internal int <dstPos>__9;
        internal Zone <dstZone>__11;
        internal TAG_ZONE <dstZoneTag>__12;
        internal Entity <entity>__5;
        internal int <i>__3;
        internal HashSet<Entity> <loadingEntities>__1;
        internal Zone <newZone>__19;
        internal Zone <oldZone>__18;
        internal PowerTask <powerTask>__7;
        internal Dictionary<Card, Zone> <previousZones>__2;
        internal int <srcControllerId>__13;
        internal int <srcPos>__8;
        internal Zone <srcZone>__10;
        internal bool <zoneChanged>__16;
        internal bool <zonePosChanged>__15;

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
                {
                    object[] objArray1 = new object[] { this.<>f__this.m_id, (this.<>f__this.m_taskList != null) ? this.<>f__this.m_taskList.GetId().ToString() : "(null)", this.<>f__this.m_changes.Count };
                    this.<>f__this.DebugPrint("ZoneChangeList.ProcessChanges() - m_id={0} m_taskList={1} m_changes.Count={2}", objArray1);
                    this.<coroutineHost>__0 = ZoneMgr.Get();
                    this.<loadingEntities>__1 = new HashSet<Entity>();
                    this.<previousZones>__2 = new Dictionary<Card, Zone>();
                    this.<i>__3 = 0;
                    goto Label_0718;
                }
                case 1:
                {
                    object[] objArray4 = new object[] { this.<entity>__5 };
                    this.<>f__this.DebugPrint("ZoneChangeList.ProcessChanges() - END waiting for {0} to load (card=(null) powerTask=(not null))", objArray4);
                    goto Label_0210;
                }
                case 2:
                {
                    object[] objArray6 = new object[] { this.<card>__6 };
                    this.<>f__this.DebugPrint("ZoneChangeList.ProcessChanges() - END waiting for {0} to load (powerTask=(not null))", objArray6);
                    goto Label_041E;
                }
                case 3:
                {
                    object[] objArray9 = new object[] { this.<card>__6, this.<zoneChanged>__16, this.<controllerChanged>__17 };
                    this.<>f__this.DebugPrint("ZoneChangeList.ProcessChanges() - END waiting for {0} to load (zoneChanged={1} controllerChanged={2} powerTask=(not null))", objArray9);
                    goto Label_059F;
                }
                case 4:
                {
                    object[] objArray11 = new object[] { this.<card>__6, this.<zoneChanged>__16, this.<controllerChanged>__17 };
                    this.<>f__this.DebugPrint("ZoneChangeList.ProcessChanges() - END waiting for {0} to transition (zoneChanged={1} controllerChanged={2} powerTask=(not null))", objArray11);
                    goto Label_0688;
                }
                default:
                    goto Label_075D;
            }
        Label_0210:
            this.<powerTask>__7.DoTask();
            if (this.<entity>__5.IsEntityDefLoading())
            {
                this.<loadingEntities>__1.Add(this.<entity>__5);
            }
            goto Label_070A;
        Label_041E:
            this.<powerTask>__7.DoTask();
            if (!this.<entity>__5.IsCardReady())
            {
                this.<loadingEntities>__1.Add(this.<entity>__5);
            }
        Label_044B:
            if (!this.<zoneChanged>__16 && !this.<controllerChanged>__17)
            {
                if (this.<zonePosChanged>__15 && (this.<srcZone>__10 != null))
                {
                    this.<>f__this.m_dirtyZones.Add(this.<srcZone>__10);
                }
                goto Label_070A;
            }
            if (this.<srcZone>__10 != null)
            {
                this.<>f__this.m_dirtyZones.Add(this.<srcZone>__10);
            }
            if (this.<dstZone>__11 != null)
            {
                this.<>f__this.m_dirtyZones.Add(this.<dstZone>__11);
            }
            object[] args = new object[] { this.<card>__6, this.<dstZone>__11 };
            this.<>f__this.DebugPrint("ZoneChangeList.ProcessChanges() - TRANSITIONING card {0} to {1}", args);
            if (this.<loadingEntities>__1.Contains(this.<entity>__5))
            {
                object[] objArray8 = new object[] { this.<card>__6, this.<zoneChanged>__16, this.<controllerChanged>__17 };
                this.<>f__this.DebugPrint("ZoneChangeList.ProcessChanges() - START waiting for {0} to load (zoneChanged={1} controllerChanged={2} powerTask=(not null))", objArray8);
                this.$current = this.<coroutineHost>__0.StartCoroutine(this.<>f__this.WaitForAndRemoveLoadingEntity(this.<loadingEntities>__1, this.<entity>__5, this.<card>__6));
                this.$PC = 3;
                goto Label_075F;
            }
        Label_059F:
            if (!this.<card>__6.IsActorReady())
            {
                this.<previousZones>__2.TryGetValue(this.<card>__6, out this.<oldZone>__18);
                this.<newZone>__19 = this.<card>__6.GetZone();
                object[] objArray10 = new object[] { this.<card>__6, this.<zoneChanged>__16, this.<controllerChanged>__17 };
                this.<>f__this.DebugPrint("ZoneChangeList.ProcessChanges() - START waiting for {0} to transition (zoneChanged={1} controllerChanged={2} powerTask=(not null))", objArray10);
                this.$current = this.<coroutineHost>__0.StartCoroutine(this.<>f__this.WaitForSingleCardTransition(this.<card>__6, this.<oldZone>__18, this.<newZone>__19));
                this.$PC = 4;
                goto Label_075F;
            }
        Label_0688:
            this.<card>__6.TransitionToZone(this.<dstZone>__11);
            if (this.<card>__6.IsActorLoading())
            {
                this.<loadingEntities>__1.Add(this.<entity>__5);
            }
            this.<previousZones>__2[this.<card>__6] = this.<srcZone>__10;
        Label_070A:
            this.<i>__3++;
        Label_0718:
            if (this.<i>__3 < this.<>f__this.m_changes.Count)
            {
                this.<change>__4 = this.<>f__this.m_changes[this.<i>__3];
                object[] objArray2 = new object[] { this.<i>__3, this.<change>__4 };
                this.<>f__this.DebugPrint("ZoneChangeList.ProcessChanges() - processing index={0} change={1}", objArray2);
                this.<entity>__5 = this.<change>__4.GetEntity();
                this.<card>__6 = this.<entity>__5.GetCard();
                this.<powerTask>__7 = this.<change>__4.GetPowerTask();
                if ((this.<powerTask>__7 != null) && this.<powerTask>__7.IsCompleted())
                {
                    goto Label_070A;
                }
                if (this.<card>__6 != null)
                {
                    this.<srcPos>__8 = this.<entity>__5.GetZonePosition();
                    this.<dstPos>__9 = this.<change>__4.GetDestinationPosition();
                    this.<srcZone>__10 = this.<card>__6.GetZone();
                    this.<dstZone>__11 = this.<change>__4.GetDestinationZone();
                    this.<dstZoneTag>__12 = this.<change>__4.GetDestinationZoneTag();
                    this.<srcControllerId>__13 = this.<entity>__5.GetControllerId();
                    this.<dstControllerId>__14 = this.<change>__4.GetDestinationControllerId();
                    this.<zonePosChanged>__15 = (this.<dstPos>__9 != 0) && (this.<srcPos>__8 != this.<dstPos>__9);
                    this.<zoneChanged>__16 = (this.<dstZoneTag>__12 != TAG_ZONE.NONE) && (this.<srcZone>__10 != this.<dstZone>__11);
                    this.<controllerChanged>__17 = (this.<dstControllerId>__14 != 0) && (this.<srcControllerId>__13 != this.<dstControllerId>__14);
                    if (this.<powerTask>__7 == null)
                    {
                        this.<>f__this.ApplyLocalChanges(this.<entity>__5, this.<srcPos>__8, this.<dstPos>__9, this.<zonePosChanged>__15, this.<srcZone>__10, this.<entity>__5.GetZone(), this.<dstZone>__11, this.<dstZoneTag>__12, this.<zoneChanged>__16, this.<srcControllerId>__13, this.<dstControllerId>__14, this.<controllerChanged>__17);
                        goto Label_044B;
                    }
                    if (!this.<loadingEntities>__1.Contains(this.<entity>__5))
                    {
                        goto Label_041E;
                    }
                    object[] objArray5 = new object[] { this.<card>__6 };
                    this.<>f__this.DebugPrint("ZoneChangeList.ProcessChanges() - START waiting for {0} to load (powerTask=(not null))", objArray5);
                    this.$current = this.<coroutineHost>__0.StartCoroutine(this.<>f__this.WaitForAndRemoveLoadingEntity(this.<loadingEntities>__1, this.<entity>__5, this.<card>__6));
                    this.$PC = 2;
                }
                else
                {
                    if (this.<powerTask>__7 == null)
                    {
                        goto Label_070A;
                    }
                    if (!this.<loadingEntities>__1.Contains(this.<entity>__5))
                    {
                        goto Label_0210;
                    }
                    object[] objArray3 = new object[] { this.<entity>__5 };
                    this.<>f__this.DebugPrint("ZoneChangeList.ProcessChanges() - START waiting for {0} to load (card=(null) powerTask=(not null))", objArray3);
                    this.$current = this.<coroutineHost>__0.StartCoroutine(this.<>f__this.WaitForAndRemoveLoadingEntity(this.<loadingEntities>__1, this.<entity>__5));
                    this.$PC = 1;
                }
                goto Label_075F;
            }
            this.<coroutineHost>__0.StartCoroutine(this.<>f__this.ProcessZoneUpdates(this.<coroutineHost>__0, this.<loadingEntities>__1));
            this.$PC = -1;
        Label_075D:
            return false;
        Label_075F:
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
    private sealed class <ProcessZoneUpdates>c__Iterator67 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MonoBehaviour <$>coroutineHost;
        internal HashSet<Entity> <$>loadingEntities;
        internal HashSet<Entity>.Enumerator <$s_321>__0;
        internal Zone[] <$s_322>__4;
        internal int <$s_323>__5;
        internal ZoneChangeList <>f__this;
        internal Card <card>__2;
        internal Zone <dirtyZone>__6;
        internal Zone[] <dirtyZones>__3;
        internal Entity <entity>__1;
        internal MonoBehaviour coroutineHost;
        internal HashSet<Entity> loadingEntities;

        [DebuggerHidden]
        public void Dispose()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 1:
                    try
                    {
                    }
                    finally
                    {
                        this.<$s_321>__0.Dispose();
                    }
                    break;
            }
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            bool flag = false;
            switch (num)
            {
                case 0:
                {
                    object[] args = new object[] { this.<>f__this.m_id, this.loadingEntities.Count, this.<>f__this.m_dirtyZones.Count };
                    this.<>f__this.DebugPrint("ZoneChangeList.ProcessZoneUpdates() - m_id={0} loadingEntities.Count={1} m_dirtyZones.Count={2}", args);
                    this.<$s_321>__0 = this.loadingEntities.GetEnumerator();
                    num = 0xfffffffd;
                    break;
                }
                case 1:
                    break;

                default:
                    goto Label_02B4;
            }
            try
            {
                switch (num)
                {
                    case 1:
                        goto Label_0113;
                }
                while (this.<$s_321>__0.MoveNext())
                {
                    this.<entity>__1 = this.<$s_321>__0.Current;
                    this.<card>__2 = this.<entity>__1.GetCard();
                    object[] objArray2 = new object[] { this.<>f__this.m_id, this.<entity>__1, this.<card>__2 };
                    this.<>f__this.DebugPrint("ZoneChangeList.ProcessZoneUpdates() - m_id={0} START waiting for {1} to load (card={2})", objArray2);
                Label_0113:
                    while (this.<>f__this.IsEntityLoading(this.<entity>__1, this.<card>__2))
                    {
                        this.$current = null;
                        this.$PC = 1;
                        flag = true;
                        return true;
                    }
                    object[] objArray3 = new object[] { this.<>f__this.m_id, this.<entity>__1, this.<card>__2 };
                    this.<>f__this.DebugPrint("ZoneChangeList.ProcessZoneUpdates() - m_id={0} END waiting for {1} to load (card={2})", objArray3);
                }
            }
            finally
            {
                if (!flag)
                {
                }
                this.<$s_321>__0.Dispose();
            }
            this.<dirtyZones>__3 = new Zone[this.<>f__this.m_dirtyZones.Count];
            this.<>f__this.m_dirtyZones.CopyTo(this.<dirtyZones>__3);
            this.<$s_322>__4 = this.<dirtyZones>__3;
            this.<$s_323>__5 = 0;
            while (this.<$s_323>__5 < this.<$s_322>__4.Length)
            {
                this.<dirtyZone>__6 = this.<$s_322>__4[this.<$s_323>__5];
                object[] objArray4 = new object[] { this.<>f__this.m_id, this.<dirtyZone>__6 };
                this.<>f__this.DebugPrint("ZoneChangeList.ProcessZoneUpdates() - m_id={0} START waiting for zone {1}", objArray4);
                if (this.<dirtyZone>__6 is ZoneHand)
                {
                    this.coroutineHost.StartCoroutine(this.<>f__this.ZoneHand_UpdateLayout((ZoneHand) this.<dirtyZone>__6));
                }
                else
                {
                    this.<dirtyZone>__6.AddUpdateLayoutCompleteCallback(new Zone.UpdateLayoutCompleteCallback(this.<>f__this.OnUpdateLayoutComplete));
                    this.<dirtyZone>__6.UpdateLayout();
                }
                this.<$s_323>__5++;
            }
            this.<>f__this.CheckAndFinishChanges();
            this.$PC = -1;
        Label_02B4:
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
    private sealed class <WaitForAndRemoveLoadingEntity>c__Iterator64 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Entity <$>entity;
        internal HashSet<Entity> <$>loadingEntities;
        internal ZoneChangeList <>f__this;
        internal Entity entity;
        internal HashSet<Entity> loadingEntities;

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
                    if (this.<>f__this.IsEntityLoading(this.entity))
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.loadingEntities.Remove(this.entity);
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
    private sealed class <WaitForAndRemoveLoadingEntity>c__Iterator65 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <$>card;
        internal Entity <$>entity;
        internal HashSet<Entity> <$>loadingEntities;
        internal ZoneChangeList <>f__this;
        internal Card card;
        internal Entity entity;
        internal HashSet<Entity> loadingEntities;

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
                    if (this.<>f__this.IsEntityLoading(this.entity, this.card))
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.loadingEntities.Remove(this.entity);
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
    private sealed class <WaitForSingleCardTransition>c__Iterator66 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Card <$>card;
        internal Zone <$>newZone;
        internal Zone <$>oldZone;
        internal bool <waitingForNewZone>__1;
        internal bool <waitingForOldZone>__0;
        internal Card card;
        internal Zone newZone;
        internal Zone oldZone;

        internal void <>m__33(Zone zone, object userData)
        {
            this.<waitingForOldZone>__0 = false;
        }

        internal void <>m__34(Zone zone, object userData)
        {
            this.<waitingForNewZone>__1 = false;
        }

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
                    this.<waitingForOldZone>__0 = false;
                    if ((this.oldZone != null) && (this.oldZone != this.newZone))
                    {
                        this.<waitingForOldZone>__0 = true;
                        this.oldZone.AddUpdateLayoutCompleteCallback(new Zone.UpdateLayoutCompleteCallback(this.<>m__33));
                        this.oldZone.UpdateLayout();
                    }
                    this.<waitingForNewZone>__1 = true;
                    this.newZone.AddUpdateLayoutCompleteCallback(new Zone.UpdateLayoutCompleteCallback(this.<>m__34));
                    this.newZone.UpdateLayout();
                    break;

                case 1:
                    break;

                default:
                    goto Label_00E8;
            }
            while ((this.<waitingForOldZone>__0 || this.<waitingForNewZone>__1) || !this.card.IsActorReady())
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            this.$PC = -1;
        Label_00E8:
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
    private sealed class <ZoneHand_UpdateLayout>c__Iterator68 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ZoneHand <$>zoneHand;
        private static Predicate<Card> <>f__am$cache6;
        internal ZoneChangeList <>f__this;
        internal Card <busyCard>__0;
        internal ZoneHand zoneHand;

        private static bool <>m__35(Card card)
        {
            if ((TurnStartManager.Get() != null) && TurnStartManager.Get().IsThisCardDrawAlreadyHandledByTurnStartManager(card))
            {
                return false;
            }
            return !card.IsActorReady();
        }

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
                    if (<>f__am$cache6 == null)
                    {
                        <>f__am$cache6 = new Predicate<Card>(ZoneChangeList.<ZoneHand_UpdateLayout>c__Iterator68.<>m__35);
                    }
                    this.<busyCard>__0 = this.zoneHand.GetCards().Find(<>f__am$cache6);
                    if (this.<busyCard>__0 == null)
                    {
                        this.zoneHand.AddUpdateLayoutCompleteCallback(new Zone.UpdateLayoutCompleteCallback(this.<>f__this.OnUpdateLayoutComplete));
                        this.zoneHand.UpdateLayout();
                        this.$PC = -1;
                        break;
                    }
                    this.$current = null;
                    this.$PC = 1;
                    return true;
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

