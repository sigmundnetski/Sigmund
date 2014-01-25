using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerTaskList
{
    private Network.HistActionEnd m_endAction;
    private int m_id;
    private PowerTaskList m_next;
    private PowerTaskList m_parent;
    private PowerTaskList m_previous;
    private Network.HistActionStart m_sourceAction;
    private List<PowerTask> m_tasks = new List<PowerTask>();
    private bool spawnedHistoryToken;

    public void CreateNewEntities()
    {
        GameState state = GameState.Get();
        for (int i = 0; i < this.m_tasks.Count; i++)
        {
            PowerTask task = this.m_tasks[i];
            Network.PowerHistory power = task.GetPower();
            switch (power.Type)
            {
                case Network.PowerHistory.PowType.CREATE_GAME:
                    task.DoTask();
                    break;

                case Network.PowerHistory.PowType.FULL_ENTITY:
                {
                    Network.HistFullEntity entity = power as Network.HistFullEntity;
                    Network.Entity entity2 = entity.Entity;
                    Entity entity3 = new Entity();
                    entity3.ReplaceTags(entity2.Tags);
                    state.AddEntity(entity3);
                    if ((!entity3.IsGame() && !entity3.IsPlayer()) && !entity3.IsEnchantment())
                    {
                        entity3.InitCard();
                    }
                    break;
                }
            }
        }
    }

    public void CreateTask(Network.PowerHistory netPower)
    {
        PowerTask item = new PowerTask();
        item.SetPower(netPower);
        if (item.GetPower().Type == Network.PowerHistory.PowType.TAG_CHANGE)
        {
            Network.HistTagChange power = item.GetPower() as Network.HistTagChange;
            if (power.Tag == 0x30)
            {
                Entity entity = GameState.Get().GetEntity(power.Entity);
                if (entity != null)
                {
                    entity.SetRealTimeCost(power.Value);
                }
            }
        }
        this.m_tasks.Add(item);
    }

    [Conditional("UNITY_EDITOR")]
    public void DebugDump()
    {
        GameState state = GameState.Get();
        string str2 = string.Empty;
        int num = (this.m_parent != null) ? this.m_parent.GetId() : 0;
        int num2 = (this.m_previous != null) ? this.m_previous.GetId() : 0;
        object[] args = new object[] { this.m_id, num, num2, this.m_tasks.Count };
        Log.Power.Print(string.Format("PowerTaskList.DebugDump() - ID={0} ParentID={1} PreviousID={2} TaskCount={3}", args));
        if (this.m_sourceAction == null)
        {
            Log.Power.Print(string.Format("PowerTaskList.DebugDump() - {0}Source Action=(null)", str2));
            str2 = str2 + "    ";
        }
        for (int i = 0; i < this.m_tasks.Count; i++)
        {
            Network.PowerHistory power = this.m_tasks[i].GetPower();
        }
        if (this.m_endAction == null)
        {
            if (str2.Length >= "    ".Length)
            {
                str2 = str2.Remove(str2.Length - "    ".Length);
            }
            Log.Power.Print(string.Format("PowerTaskList.DebugDump() - {0}End Action=(null)", str2));
        }
    }

    public bool DidSpawnHistoryToken()
    {
        return this.spawnedHistoryToken;
    }

    public void DoAllTasks()
    {
        this.DoTasks(0, this.m_tasks.Count, null, null);
    }

    public void DoAllTasks(CompleteCallback callback)
    {
        this.DoTasks(0, this.m_tasks.Count, callback, null);
    }

    public void DoAllTasks(CompleteCallback callback, object userData)
    {
        this.DoTasks(0, this.m_tasks.Count, callback, userData);
    }

    public bool DoesBlockEnd()
    {
        return (this.DoesBlockHaveSourceAction() && !this.DoesBlockHaveEndAction());
    }

    public bool DoesBlockHaveEndAction()
    {
        PowerTaskList next = this;
        while (next.m_next != null)
        {
            next = next.m_next;
        }
        return (next.m_endAction != null);
    }

    public bool DoesBlockHaveSourceAction()
    {
        return (this.GetOrigin().m_sourceAction != null);
    }

    public void DoTasks(int startIndex, int count, CompleteCallback callback)
    {
        this.DoTasks(startIndex, count, callback, null);
    }

    public void DoTasks(int startIndex, int count, CompleteCallback callback, object userData)
    {
        bool flag = false;
        int taskStartIndex = -1;
        int taskEndIndex = Mathf.Min((int) ((startIndex + count) - 1), (int) (this.m_tasks.Count - 1));
        for (int i = startIndex; i <= taskEndIndex; i++)
        {
            PowerTask task = this.m_tasks[i];
            if (!task.IsCompleted())
            {
                if (taskStartIndex < 0)
                {
                    taskStartIndex = i;
                }
                if (ZoneMgr.IsHandledPower(task.GetPower()))
                {
                    flag = true;
                    break;
                }
            }
        }
        if (taskStartIndex < 0)
        {
            taskStartIndex = startIndex;
        }
        if (flag)
        {
            ZoneChangeCallbackData data = new ZoneChangeCallbackData {
                m_startIndex = startIndex,
                m_count = count,
                m_taskListCallback = callback,
                m_taskListUserData = userData
            };
            if (ZoneMgr.Get().AddServerZoneChanges(this, taskStartIndex, taskEndIndex, new ZoneMgr.ChangeCompleteCallback(this.OnZoneChangeComplete), data))
            {
                return;
            }
        }
        if (Gameplay.Get() != null)
        {
            Gameplay.Get().StartCoroutine(this.WaitForMissionMgrAndDoTasks(taskStartIndex, taskEndIndex, startIndex, count, callback, userData));
        }
        else
        {
            this.DoTasks(taskStartIndex, taskEndIndex, startIndex, count, callback, userData);
        }
    }

    private void DoTasks(int incompleteStartIndex, int endIndex, int startIndex, int count, CompleteCallback callback, object userData)
    {
        for (int i = incompleteStartIndex; i <= endIndex; i++)
        {
            this.m_tasks[i].DoTask();
        }
        if (callback != null)
        {
            callback(this, startIndex, count, userData);
        }
    }

    public void FindOutIfAnyDamageWasDealtAndNotifyHistory()
    {
        List<int> list = new List<int>();
        foreach (PowerTask task in this.GetTaskList())
        {
            Network.PowerHistory power = task.GetPower();
            if (power.Type == Network.PowerHistory.PowType.TAG_CHANGE)
            {
                Network.HistTagChange tagChange = power as Network.HistTagChange;
                Entity entity = GameState.Get().GetEntity(tagChange.Entity);
                if ((tagChange.Tag == 0x2c) && !list.Contains(tagChange.Entity))
                {
                    HistoryManager.Get().NotifyAboutDamageChanged(entity, tagChange.Value);
                }
                if ((tagChange.Tag == 0x124) && !list.Contains(tagChange.Entity))
                {
                    HistoryManager.Get().NotifyAboutArmorChanged(entity, tagChange.Value);
                }
                if (tagChange.Tag == 0x13e)
                {
                    HistoryManager.Get().NotifyAboutPreDamage(entity);
                }
                if (IsDeathTagChange(tagChange))
                {
                    HistoryManager.Get().NotifyAboutCardDeath(entity);
                    list.Add(tagChange.Entity);
                }
            }
        }
    }

    public AttackInfo GetAttackInfo()
    {
        GameState state = GameState.Get();
        AttackInfo info = new AttackInfo();
        bool flag = false;
        foreach (PowerTask task in this.GetTaskList())
        {
            Network.PowerHistory power = task.GetPower();
            if (power.Type == Network.PowerHistory.PowType.TAG_CHANGE)
            {
                Network.HistTagChange change = power as Network.HistTagChange;
                if (change.Tag == 0x24)
                {
                    if (change.Value == 1)
                    {
                        info.m_defender = state.GetEntity(change.Entity);
                    }
                    flag = true;
                    continue;
                }
                if (change.Tag == 0x26)
                {
                    if (change.Value == 1)
                    {
                        info.m_attacker = state.GetEntity(change.Entity);
                    }
                    flag = true;
                    continue;
                }
                if (change.Tag == 0x27)
                {
                    if (change.Value != 0)
                    {
                        info.m_proposedAttacker = state.GetEntity(change.Value);
                    }
                    flag = true;
                    continue;
                }
                if (change.Tag == 0x25)
                {
                    if (change.Value != 0)
                    {
                        info.m_proposedDefender = state.GetEntity(change.Value);
                    }
                    flag = true;
                }
            }
        }
        if (flag)
        {
            return info;
        }
        return null;
    }

    public DamageInfo GetDamageInfo(Entity entity)
    {
        if (entity != null)
        {
            int entityId = entity.GetEntityId();
            foreach (PowerTask task in this.m_tasks)
            {
                Network.PowerHistory power = task.GetPower();
                if (power.Type == Network.PowerHistory.PowType.TAG_CHANGE)
                {
                    Network.HistTagChange change = power as Network.HistTagChange;
                    if ((change.Tag == 0x2c) && (change.Entity == entityId))
                    {
                        DamageInfo info;
                        return new DamageInfo { m_entity = GameState.Get().GetEntity(change.Entity), m_damage = change.Value - info.m_entity.GetDamage() };
                    }
                }
            }
        }
        return null;
    }

    public Network.HistActionEnd GetEndAction()
    {
        return this.m_endAction;
    }

    public int GetId()
    {
        return this.m_id;
    }

    public PowerTaskList GetNext()
    {
        return this.m_next;
    }

    public PowerTaskList GetOrigin()
    {
        PowerTaskList previous = this;
        while (previous.m_previous != null)
        {
            previous = previous.m_previous;
        }
        return previous;
    }

    public PowerTaskList GetParent()
    {
        return this.GetOrigin().m_parent;
    }

    public PowerTaskList GetPrevious()
    {
        return this.m_previous;
    }

    public Network.HistActionStart GetSourceAction()
    {
        return this.GetOrigin().m_sourceAction;
    }

    public Entity GetSourceEntity()
    {
        Network.HistActionStart sourceAction = this.GetSourceAction();
        if (sourceAction == null)
        {
            return null;
        }
        int id = sourceAction.Entity;
        Entity entity = GameState.Get().GetEntity(id);
        if (entity == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("PowerProcessor.GetSourceEntity() - task list {0} has a source entity with id {1} but there is no entity with that id", this.m_id, id));
            return null;
        }
        return entity;
    }

    public Entity GetTargetEntity()
    {
        Network.HistActionStart sourceAction = this.GetSourceAction();
        if (sourceAction == null)
        {
            return null;
        }
        int target = sourceAction.Target;
        Entity entity = GameState.Get().GetEntity(target);
        if (entity == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("PowerProcessor.GetSourceEntity() - task list {0} has a target entity with id {1} but there is no entity with that id", this.m_id, target));
            return null;
        }
        return entity;
    }

    public List<PowerTask> GetTaskList()
    {
        return this.m_tasks;
    }

    public bool HasMetaDataTasks()
    {
        foreach (PowerTask task in this.m_tasks)
        {
            if (task.GetPower().Type == Network.PowerHistory.PowType.META_DATA)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasTasksOfType(Network.PowerHistory.PowType powType)
    {
        foreach (PowerTask task in this.m_tasks)
        {
            if (task.GetPower().Type == powType)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsCompleted()
    {
        foreach (PowerTask task in this.m_tasks)
        {
            if (!task.IsCompleted())
            {
                return false;
            }
        }
        return true;
    }

    public static bool IsDeathTagChange(Network.HistTagChange tagChange)
    {
        if (tagChange.Tag != 0x31)
        {
            return false;
        }
        if (tagChange.Value != 4)
        {
            return false;
        }
        return true;
    }

    public bool IsDescendantOfBlock(PowerTaskList taskList)
    {
        if (taskList != null)
        {
            if (this.IsListInBlock(taskList))
            {
                return true;
            }
            PowerTaskList origin = taskList.GetOrigin();
            for (PowerTaskList list2 = this.GetParent(); list2 != null; list2 = list2.m_parent)
            {
                if (list2 == origin)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsEarlierInBlockThan(PowerTaskList taskList)
    {
        for (PowerTaskList list = taskList; list != null; list = list.m_previous)
        {
            if (this == list)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsEmpty()
    {
        PowerTaskList origin = this.GetOrigin();
        if (origin.m_sourceAction != null)
        {
            return false;
        }
        if (origin.m_endAction != null)
        {
            return false;
        }
        if (origin.m_tasks.Count > 0)
        {
            return false;
        }
        return true;
    }

    public bool IsLaterInBlockThan(PowerTaskList taskList)
    {
        for (PowerTaskList list = taskList; list != null; list = list.m_next)
        {
            if (this == list)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsListInBlock(PowerTaskList taskList)
    {
        return ((this == taskList) || (this.IsEarlierInBlockThan(taskList) || this.IsLaterInBlockThan(taskList)));
    }

    public bool IsOrigin()
    {
        return (this.m_previous == null);
    }

    public bool IsSourceActionOrigin()
    {
        return (this.m_sourceAction != null);
    }

    public void NotifyOfSpawnedHistoryToken()
    {
        this.spawnedHistoryToken = true;
    }

    private void OnZoneChangeComplete(object userData)
    {
        ZoneChangeCallbackData data = (ZoneChangeCallbackData) userData;
        if (data.m_taskListCallback != null)
        {
            data.m_taskListCallback(this, data.m_startIndex, data.m_count, data.m_taskListUserData);
        }
    }

    public void SetEndAction(Network.HistActionEnd endAction)
    {
        this.m_endAction = endAction;
    }

    public void SetId(int id)
    {
        this.m_id = id;
    }

    public void SetParent(PowerTaskList parent)
    {
        this.m_parent = parent;
    }

    public void SetPrevious(PowerTaskList taskList)
    {
        this.m_previous = taskList;
        taskList.m_next = this;
    }

    public void SetSourceAction(Network.HistActionStart startAction)
    {
        this.m_sourceAction = startAction;
    }

    [DebuggerHidden]
    private IEnumerator WaitForMissionMgrAndDoTasks(int incompleteStartIndex, int endIndex, int startIndex, int count, CompleteCallback callback, object userData)
    {
        return new <WaitForMissionMgrAndDoTasks>c__Iterator5F { incompleteStartIndex = incompleteStartIndex, endIndex = endIndex, callback = callback, startIndex = startIndex, count = count, userData = userData, <$>incompleteStartIndex = incompleteStartIndex, <$>endIndex = endIndex, <$>callback = callback, <$>startIndex = startIndex, <$>count = count, <$>userData = userData, <>f__this = this };
    }

    public bool WasThePlayedSpellCountered(Entity entity)
    {
        foreach (PowerTask task in this.GetTaskList())
        {
            Network.PowerHistory power = task.GetPower();
            if (power.Type == Network.PowerHistory.PowType.TAG_CHANGE)
            {
                Network.HistTagChange change = power as Network.HistTagChange;
                if (((change.Tag == 0xe7) && (change.Entity == entity.GetEntityId())) && (change.Value == 1))
                {
                    return true;
                }
            }
        }
        foreach (PowerTaskList list2 in GameState.Get().GetPowerProcessor().GetPowerQueue().GetList())
        {
            foreach (PowerTask task2 in list2.GetTaskList())
            {
                Network.PowerHistory history2 = task2.GetPower();
                if (history2.Type == Network.PowerHistory.PowType.TAG_CHANGE)
                {
                    Network.HistTagChange change2 = history2 as Network.HistTagChange;
                    if (((change2.Tag == 0xe7) && (change2.Entity == entity.GetEntityId())) && (change2.Value == 1))
                    {
                        return true;
                    }
                }
            }
            if ((list2.GetEndAction() != null) && (list2.GetSourceAction().SubType == Network.PowerHistoryAction.PowSubType.PLAY))
            {
                return false;
            }
        }
        return false;
    }

    [CompilerGenerated]
    private sealed class <WaitForMissionMgrAndDoTasks>c__Iterator5F : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal PowerTaskList.CompleteCallback <$>callback;
        internal int <$>count;
        internal int <$>endIndex;
        internal int <$>incompleteStartIndex;
        internal int <$>startIndex;
        internal object <$>userData;
        internal PowerTaskList <>f__this;
        internal int <i>__0;
        internal PowerTask <task>__1;
        internal PowerTaskList.CompleteCallback callback;
        internal int count;
        internal int endIndex;
        internal int incompleteStartIndex;
        internal int startIndex;
        internal object userData;

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
                    this.<i>__0 = this.incompleteStartIndex;
                    goto Label_0093;

                case 1:
                    goto Label_0076;

                default:
                    goto Label_00D9;
            }
        Label_0076:
            while (MissionMgr.Get().IsBusy())
            {
                this.$current = 0;
                this.$PC = 1;
                return true;
            }
            this.<i>__0++;
        Label_0093:
            if (this.<i>__0 <= this.endIndex)
            {
                this.<task>__1 = this.<>f__this.m_tasks[this.<i>__0];
                this.<task>__1.DoTask();
                goto Label_0076;
            }
            if (this.callback != null)
            {
                this.callback(this.<>f__this, this.startIndex, this.count, this.userData);
            }
            this.$PC = -1;
        Label_00D9:
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

    public class AttackInfo
    {
        public Entity m_attacker;
        public Entity m_defender;
        public Entity m_proposedAttacker;
        public Entity m_proposedDefender;
    }

    public delegate void CompleteCallback(PowerTaskList taskList, int startIndex, int count, object userData);

    public class DamageInfo
    {
        public int m_damage;
        public Entity m_entity;
    }

    private class ZoneChangeCallbackData
    {
        public int m_count;
        public int m_startIndex;
        public PowerTaskList.CompleteCallback m_taskListCallback;
        public object m_taskListUserData;
    }
}

