using System;
using System.Collections.Generic;
using UnityEngine;

public class PowerProcessor
{
    private PowerTaskList m_currentTaskList;
    private bool m_historyBlocking;
    private PowerTaskList m_historyBlockingTaskList;
    private PowerTaskList m_lastOriginTaskList;
    private int m_nextTaskListId = 1;
    private PowerQueue m_powerQueue = new PowerQueue();
    private Stack<PowerTaskList> m_previousStack = new Stack<PowerTaskList>();

    private void BeginCurrentTaskList()
    {
        object[] args = new object[] { this.m_currentTaskList.GetId() };
        Log.Power.Print("PowerProcessor.BeginCurrentTaskList() - m_currentTaskList={0}", args);
        if (ThinkEmoteManager.Get() != null)
        {
            ThinkEmoteManager.Get().NotifyOfActivity();
        }
        if (this.m_currentTaskList.IsSourceActionOrigin())
        {
            this.m_lastOriginTaskList = this.m_currentTaskList;
            Network.HistActionStart sourceAction = this.m_currentTaskList.GetSourceAction();
            if (sourceAction.SubType == Network.PowerHistoryAction.PowSubType.ATTACK)
            {
                PowerTaskList.AttackInfo attackInfo = this.m_currentTaskList.GetAttackInfo();
                if (((attackInfo != null) && (attackInfo.m_attacker != null)) && (attackInfo.m_defender != null))
                {
                    this.m_currentTaskList.NotifyOfSpawnedHistoryToken();
                    this.CreateHistoryAttackTile(attackInfo.m_attacker, attackInfo.m_defender);
                }
            }
            else if (sourceAction.SubType == Network.PowerHistoryAction.PowSubType.PLAY)
            {
                Entity playedCard = GameState.Get().GetEntity(sourceAction.Entity);
                if (playedCard == null)
                {
                    return;
                }
                this.CreateHistoryPlayTile(playedCard, GameState.Get().GetEntity(sourceAction.Target));
                if (!playedCard.GetController().IsLocal())
                {
                    bool wasCountered = this.m_currentTaskList.WasThePlayedSpellCountered(playedCard);
                    this.m_historyBlocking = true;
                    this.m_historyBlockingTaskList = this.m_currentTaskList;
                    HistoryManager.Get().CreatePlayedBigCard(playedCard, new HistoryManager.FinishedCallback(this.OnBigCardFinished), wasCountered);
                }
            }
            else if (sourceAction.SubType == Network.PowerHistoryAction.PowSubType.TRIGGER)
            {
                Entity entity = GameState.Get().GetEntity(sourceAction.Entity);
                if (entity != null)
                {
                    this.CreateTriggerTileIfNecessary(sourceAction);
                    if (entity.IsSecret())
                    {
                        HistoryManager.Get().CreateTriggeredBigCard(entity, null, new HistoryManager.FinishedCallback(this.OnBigCardFinished), true);
                        this.m_historyBlocking = true;
                        this.m_historyBlockingTaskList = this.m_currentTaskList;
                    }
                    if (this.m_currentTaskList.DidSpawnHistoryToken())
                    {
                        this.m_currentTaskList.FindOutIfAnyDamageWasDealtAndNotifyHistory();
                    }
                }
                return;
            }
        }
        if (this.m_currentTaskList.DidSpawnHistoryToken() || ((this.m_currentTaskList.GetParent() != null) && this.m_currentTaskList.GetParent().DidSpawnHistoryToken()))
        {
            this.m_currentTaskList.FindOutIfAnyDamageWasDealtAndNotifyHistory();
        }
    }

    private void BuildTaskList(List<Network.PowerHistory> powerList, ref int index, PowerTaskList taskList)
    {
        while (index < powerList.Count)
        {
            Network.PowerHistory netPower = powerList[index];
            if (netPower.Type == Network.PowerHistory.PowType.ACTION_START)
            {
                if (!taskList.IsEmpty())
                {
                    taskList.SetId(this.GetNextTaskListId());
                    this.m_powerQueue.Enqueue(taskList);
                }
                PowerTaskList item = new PowerTaskList();
                item.SetSourceAction(netPower as Network.HistActionStart);
                PowerTaskList origin = taskList.GetOrigin();
                if (origin.GetSourceAction() != null)
                {
                    item.SetParent(origin);
                }
                this.m_previousStack.Push(item);
                index++;
                this.BuildTaskList(powerList, ref index, item);
                return;
            }
            if (netPower.Type == Network.PowerHistory.PowType.ACTION_END)
            {
                if (this.m_previousStack.Count > 0)
                {
                    taskList.SetEndAction(netPower as Network.HistActionEnd);
                    this.m_previousStack.Pop();
                }
                else
                {
                    PowerTaskList list3 = this.FindLatestUnendedTaskList();
                    if (list3 != null)
                    {
                        taskList.SetEndAction(netPower as Network.HistActionEnd);
                        taskList.SetPrevious(list3);
                    }
                }
                break;
            }
            taskList.CreateTask(netPower);
            index++;
        }
        if (!taskList.IsEmpty())
        {
            taskList.SetId(this.GetNextTaskListId());
            this.m_powerQueue.Enqueue(taskList);
        }
    }

    public void Clear()
    {
        this.m_powerQueue.Clear();
        this.m_currentTaskList = null;
    }

    private void CreateHistoryAttackTile(Entity attacker, Entity defender)
    {
        this.m_currentTaskList.GetOrigin().NotifyOfSpawnedHistoryToken();
        HistoryManager.Get().CreateAttackTile(attacker, defender);
    }

    private void CreateHistoryPlayTile(Entity playedCard, Entity targetedCard)
    {
        this.m_currentTaskList.GetOrigin().NotifyOfSpawnedHistoryToken();
        HistoryManager.Get().CreateCardPlayedTile(playedCard, targetedCard);
    }

    private void CreateTriggerTileIfNecessary(Network.HistActionStart sourceAction)
    {
        Entity triggeringEntity = GameState.Get().GetEntity(sourceAction.Entity);
        if (triggeringEntity.IsSecret())
        {
            this.m_currentTaskList.GetOrigin().NotifyOfSpawnedHistoryToken();
            HistoryManager.Get().CreateTriggerTile(triggeringEntity, null);
        }
        else
        {
            PowerHistoryInfo powerHistoryInfo = triggeringEntity.GetPowerHistoryInfo(sourceAction.Index);
            if ((powerHistoryInfo != null) && powerHistoryInfo.ShouldShowInHistory())
            {
                this.m_currentTaskList.GetOrigin().NotifyOfSpawnedHistoryToken();
                HistoryManager.Get().CreateTriggerTile(triggeringEntity, powerHistoryInfo.GetHistoryText());
            }
        }
    }

    private void DoCurrentTaskList()
    {
        this.m_currentTaskList.DoAllTasks(delegate (PowerTaskList taskList, int startIndex, int count, object userData) {
            this.EndCurrentTaskList();
        });
    }

    private bool DoTaskListForEntity(GameState state, PowerTaskList powerTaskList, Entity sourceEntity)
    {
        Network.HistActionStart sourceAction = powerTaskList.GetSourceAction();
        switch (sourceAction.SubType)
        {
            case Network.PowerHistoryAction.PowSubType.ATTACK:
            {
                AttackSpellController spellController = state.AcquireAttackSpellController();
                if (!this.DoTaskListUsingController(spellController, powerTaskList, new SpellController.FinishedCallback(this.OnAttackSpellControllerFinished)))
                {
                    state.ReleaseAttackSpellController(spellController);
                    return false;
                }
                return true;
            }
            case Network.PowerHistoryAction.PowSubType.POWER:
            {
                PowerSpellController controller2 = state.AcquirePlaySpellController();
                if (!this.DoTaskListUsingController(controller2, powerTaskList, new SpellController.FinishedCallback(this.OnPowerSpellControllerFinished)))
                {
                    state.ReleasePlaySpellController(controller2);
                    return false;
                }
                return true;
            }
            case Network.PowerHistoryAction.PowSubType.TRIGGER:
                if (sourceEntity.IsSecret())
                {
                    SecretSpellController controller3 = state.AcquireSecretSpellController();
                    if (!this.DoTaskListUsingController(controller3, powerTaskList, new SpellController.FinishedCallback(this.OnSecretSpellControllerFinished)))
                    {
                        state.ReleaseSecretSpellController(controller3);
                        return false;
                    }
                }
                else
                {
                    TriggerSpellController controller4 = state.AcquireTriggerSpellController();
                    if (!this.DoTaskListUsingController(controller4, powerTaskList, new SpellController.FinishedCallback(this.OnTriggerSpellControllerFinished)))
                    {
                        state.ReleaseTriggerSpellController(controller4);
                        return false;
                    }
                }
                return true;

            case Network.PowerHistoryAction.PowSubType.DEATHS:
            {
                DeathSpellController controller5 = state.AcquireDeathSpellController();
                if (!this.DoTaskListUsingController(controller5, powerTaskList, new SpellController.FinishedCallback(this.OnDeathSpellControllerFinished)))
                {
                    state.ReleaseDeathSpellController(controller5);
                    return false;
                }
                return true;
            }
            case Network.PowerHistoryAction.PowSubType.FATIGUE:
            {
                FatigueSpellController spell = state.AcquireFatigueSpellController();
                if (!spell.AttachPowerTaskList(powerTaskList))
                {
                    state.ReleaseFatigueSpellController(spell);
                    return false;
                }
                spell.AddFinishedTaskListCallback(new SpellController.FinishedTaskListCallback(this.OnSpellControllerFinishedTaskList));
                spell.AddFinishedCallback(new SpellController.FinishedCallback(this.OnFatigueSpellControllerFinished));
                if (state.IsTurnStartManagerActive())
                {
                    TurnStartManager.Get().NotifyOfFatigueEvent(spell);
                }
                else
                {
                    spell.DoPowerTaskList();
                }
                return true;
            }
        }
        Log.Power.Print(string.Format("PowerProcessor.DoTaskListForCard() - actionStart has unhandled SubType {0} for sourceEntity {1}", sourceAction.SubType, sourceEntity));
        return false;
    }

    private bool DoTaskListUsingController(SpellController spellController, PowerTaskList powerTaskList, SpellController.FinishedCallback callback)
    {
        if (spellController == null)
        {
            Log.Power.Print("PowerProcessor.DoTaskListUsingController() - spellController=null");
            return false;
        }
        if (!spellController.AttachPowerTaskList(powerTaskList))
        {
            return false;
        }
        spellController.AddFinishedTaskListCallback(new SpellController.FinishedTaskListCallback(this.OnSpellControllerFinishedTaskList));
        spellController.AddFinishedCallback(callback);
        spellController.DoPowerTaskList();
        return true;
    }

    private void EndCurrentTaskList()
    {
        object[] args = new object[] { (this.m_currentTaskList != null) ? this.m_currentTaskList.GetId().ToString() : "null" };
        Log.Power.Print("PowerProcessor.EndCurrentTaskList() - m_currentTaskList={0}", args);
        if (this.m_currentTaskList == null)
        {
            Log.Ben.Print("PowerProcessor - EndCurrentTaskList() - m_currentTaskList is NULL");
        }
        else
        {
            PowerTaskList origin = this.m_currentTaskList.GetOrigin();
            if ((origin != null) && (this.m_currentTaskList.GetEndAction() != null))
            {
                PowerTaskList parent = this.m_currentTaskList.GetParent();
                this.m_lastOriginTaskList = (parent != null) ? parent.GetOrigin() : null;
                if (this.m_currentTaskList.GetOrigin() == this.m_historyBlockingTaskList)
                {
                    this.m_historyBlockingTaskList = null;
                }
                if (origin.DidSpawnHistoryToken())
                {
                    HistoryManager.Get().MarkCurrentHistoryEntryAsCompleted();
                }
            }
            this.m_currentTaskList = null;
        }
    }

    private PowerTaskList FindLatestUnendedTaskList()
    {
        int count = this.m_powerQueue.Count;
        while (count-- > 0)
        {
            PowerTaskList list = this.m_powerQueue[count];
            if (list.DoesBlockEnd())
            {
                return list;
            }
        }
        if (!this.m_lastOriginTaskList.DoesBlockHaveEndAction())
        {
            return this.m_lastOriginTaskList;
        }
        return null;
    }

    private int GetNextTaskListId()
    {
        int nextTaskListId = this.m_nextTaskListId;
        this.m_nextTaskListId = (this.m_nextTaskListId + 1) & 0x7fffffff;
        return nextTaskListId;
    }

    public PowerQueue GetPowerQueue()
    {
        return this.m_powerQueue;
    }

    public bool IsBusy()
    {
        return ((this.m_currentTaskList != null) || this.m_historyBlocking);
    }

    private void OnAttackSpellControllerFinished(SpellController spellController)
    {
        AttackSpellController spell = (AttackSpellController) spellController;
        GameState.Get().ReleaseAttackSpellController(spell);
    }

    private void OnBigCardFinished()
    {
        this.m_historyBlocking = false;
    }

    private void OnDeathSpellControllerFinished(SpellController spellController)
    {
        DeathSpellController controller = (DeathSpellController) spellController;
        GameState.Get().ReleaseDeathSpellController(controller);
    }

    private void OnFatigueSpellControllerFinished(SpellController spellController)
    {
        FatigueSpellController spell = (FatigueSpellController) spellController;
        GameState.Get().ReleaseFatigueSpellController(spell);
    }

    public void OnPowerList(List<Network.PowerHistory> powerList)
    {
        for (int i = 0; i < powerList.Count; i++)
        {
            PowerTaskList item = new PowerTaskList();
            if (this.m_previousStack.Count > 0)
            {
                item.SetPrevious(this.m_previousStack.Pop());
                this.m_previousStack.Push(item);
            }
            this.BuildTaskList(powerList, ref i, item);
        }
        this.m_previousStack.Clear();
    }

    private void OnPowerSpellControllerFinished(SpellController spellController)
    {
        PowerSpellController spell = (PowerSpellController) spellController;
        GameState.Get().ReleasePlaySpellController(spell);
    }

    private void OnSecretSpellControllerFinished(SpellController spellController)
    {
        SecretSpellController spell = (SecretSpellController) spellController;
        GameState.Get().ReleaseSecretSpellController(spell);
    }

    private void OnSpellControllerFinishedTaskList(SpellController spellController)
    {
        if ((this.m_currentTaskList != null) && (spellController.DetachPowerTaskList() == this.m_currentTaskList))
        {
            this.DoCurrentTaskList();
        }
    }

    private void OnTriggerSpellControllerFinished(SpellController spellController)
    {
        TriggerSpellController spell = (TriggerSpellController) spellController;
        GameState.Get().ReleaseTriggerSpellController(spell);
    }

    private void ProcessCurrentTaskList()
    {
        GameState state = GameState.Get();
        if (this.m_currentTaskList == null)
        {
            Debug.LogError("Tried to ProcessCurrentTaskList, but none exist.");
        }
        else
        {
            this.m_currentTaskList.CreateNewEntities();
            Network.HistActionStart sourceAction = this.m_currentTaskList.GetSourceAction();
            if (sourceAction == null)
            {
                this.DoCurrentTaskList();
            }
            else
            {
                int id = sourceAction.Entity;
                Entity sourceEntity = state.GetEntity(id);
                if (sourceEntity == null)
                {
                    Debug.LogError(string.Format("PowerProcessor.ProcessPowerQueue() - WARNING got a power with a null source entity.", id));
                    this.DoCurrentTaskList();
                }
                else if (!this.DoTaskListForEntity(state, this.m_currentTaskList, sourceEntity))
                {
                    this.DoCurrentTaskList();
                }
                else if ((this.m_currentTaskList != null) && this.m_currentTaskList.IsCompleted())
                {
                    this.EndCurrentTaskList();
                }
            }
        }
    }

    public void ProcessPowerQueue()
    {
        while ((this.m_powerQueue.GetCount() > 0) && !this.IsBusy())
        {
            PowerTaskList list = this.m_powerQueue.Peek();
            if (this.m_historyBlockingTaskList != null)
            {
                if (!list.IsDescendantOfBlock(this.m_historyBlockingTaskList))
                {
                    break;
                }
            }
            else if ((HistoryManager.Get() != null) && (HistoryManager.Get().GetCurrentBigCard() != null))
            {
                break;
            }
            this.m_currentTaskList = this.m_powerQueue.Dequeue();
            this.BeginCurrentTaskList();
            this.ProcessCurrentTaskList();
        }
    }
}

