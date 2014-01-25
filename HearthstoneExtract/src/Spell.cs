using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spell : MonoBehaviour
{
    protected SpellStateType m_activeStateChange;
    protected SpellStateType m_activeStateType;
    public bool m_BlockServerEvents;
    public SpellFacing m_Facing;
    public SpellFacingOptions m_FacingOptions;
    protected bool m_finished;
    private List<FinishedListener> m_finishedListeners = new List<FinishedListener>();
    private PlayMakerFSM m_fsm;
    private bool m_fsmReady;
    private bool m_fsmSkippedFirstFrame;
    private Dictionary<SpellStateType, FsmState> m_fsmStateMap;
    public SpellLocation m_Location = SpellLocation.SOURCE_AUTO;
    public string m_LocationTransformName;
    public GameObject m_ObjectContainer;
    protected bool m_orientationDirty = true;
    protected bool m_positionDirty = true;
    protected bool m_shown = true;
    protected GameObject m_source;
    private Dictionary<SpellStateType, List<SpellState>> m_spellStateMap;
    protected SpellType m_spellType;
    private List<StateFinishedListener> m_stateFinishedListeners = new List<StateFinishedListener>();
    private List<StateStartedListener> m_stateStartedListeners = new List<StateStartedListener>();
    public TARGET_RETICLE_TYPE m_TargetReticle;
    protected List<GameObject> m_targets = new List<GameObject>();
    protected PowerTaskList m_taskList;

    public void Activate()
    {
        SpellStateType stateType = this.GuessNextStateType();
        if (stateType == SpellStateType.NONE)
        {
            this.Deactivate();
        }
        else
        {
            this.ChangeState(stateType);
        }
    }

    public void ActivateObjectContainer(bool enable)
    {
        if (this.m_ObjectContainer != null)
        {
            SceneUtils.EnableRenderers(this.m_ObjectContainer, enable);
        }
    }

    public void ActivateState(SpellStateType stateType)
    {
        if (!this.HasUsableState(stateType))
        {
            this.Deactivate();
        }
        else
        {
            this.ChangeState(stateType);
        }
    }

    public void AddFinishedCallback(FinishedCallback callback)
    {
        this.AddFinishedCallback(callback, null);
    }

    public void AddFinishedCallback(FinishedCallback callback, object userData)
    {
        FinishedListener item = new FinishedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (!this.m_finishedListeners.Contains(item))
        {
            this.m_finishedListeners.Add(item);
        }
    }

    protected bool AddMultiplePowerTargets()
    {
        Card sourceCard = this.GetSourceCard();
        List<PowerTask> taskList = this.m_taskList.GetTaskList();
        if (!this.AddMultiplePowerTargets_FromMetaData(taskList))
        {
            this.AddMultiplePowerTargets_FromAnyPower(sourceCard, taskList);
        }
        return true;
    }

    protected void AddMultiplePowerTargets_FromAnyPower(Card sourceCard, List<PowerTask> tasks)
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            PowerTask task = tasks[i];
            Card targetCardFromPowerTask = this.GetTargetCardFromPowerTask(task);
            if (((targetCardFromPowerTask != null) && (sourceCard != targetCardFromPowerTask)) && !this.IsTarget(targetCardFromPowerTask.gameObject))
            {
                this.AddTarget(targetCardFromPowerTask.gameObject);
            }
        }
    }

    protected bool AddMultiplePowerTargets_FromMetaData(List<PowerTask> tasks)
    {
        int count = this.m_targets.Count;
        GameState state = GameState.Get();
        for (int i = 0; i < tasks.Count; i++)
        {
            Network.PowerHistory power = tasks[i].GetPower();
            if (power.Type == Network.PowerHistory.PowType.META_DATA)
            {
                Network.HistMetaData data = power as Network.HistMetaData;
                if (data.MetaType == Network.HistMetaData.TypeMetaType.META_TARGET)
                {
                    if ((data.Info == null) || (data.Info.Count == 0))
                    {
                        UnityEngine.Debug.LogError(string.Format("{0}.AddMultiplePowerTargets_FromMetaData() - META_DATA at index {1} has no Info", this, i));
                    }
                    else
                    {
                        for (int j = 0; j < data.Info.Count; j++)
                        {
                            Entity entity = state.GetEntity(data.Info[j]);
                            if (entity == null)
                            {
                                UnityEngine.Debug.LogError(string.Format("{0}.AddMultiplePowerTargets_FromMetaData() - Entity is null for META_DATA at index {1} Info index {2}", this, i, j));
                            }
                            else
                            {
                                Card targetCard = entity.GetCard();
                                this.AddTargetFromMetaData(i, targetCard);
                            }
                        }
                    }
                }
            }
        }
        return (this.m_targets.Count != count);
    }

    public virtual bool AddPowerTargets()
    {
        if (!this.CanAddPowerTargets())
        {
            return false;
        }
        return this.AddMultiplePowerTargets();
    }

    protected bool AddSinglePowerTarget()
    {
        Card sourceCard = this.GetSourceCard();
        if (sourceCard == null)
        {
            Log.Power.Print(string.Format("{0}.AddSinglePowerTarget() - WARNING a source card was never added", this));
            return false;
        }
        Network.HistActionStart sourceAction = this.m_taskList.GetSourceAction();
        if (sourceAction == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.AddSinglePowerTarget() - FAILED got a task list with no source action", this));
            return false;
        }
        List<PowerTask> taskList = this.m_taskList.GetTaskList();
        if (this.AddSinglePowerTarget_FromSourceAction(sourceAction))
        {
            return true;
        }
        if (this.AddSinglePowerTarget_FromMetaData(taskList))
        {
            return true;
        }
        if (this.AddSinglePowerTarget_FromAnyPower(sourceCard, taskList))
        {
            return true;
        }
        UnityEngine.Debug.LogError(string.Format("{0}.AddSinglePowerTarget() - FAILED to add a target. sourceCard={1}", this, sourceCard));
        return false;
    }

    protected bool AddSinglePowerTarget_FromAnyPower(Card sourceCard, List<PowerTask> tasks)
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            PowerTask task = tasks[i];
            Card targetCardFromPowerTask = this.GetTargetCardFromPowerTask(task);
            if ((targetCardFromPowerTask != null) && (sourceCard != targetCardFromPowerTask))
            {
                this.AddTarget(targetCardFromPowerTask.gameObject);
                return true;
            }
        }
        return false;
    }

    protected bool AddSinglePowerTarget_FromMetaData(List<PowerTask> tasks)
    {
        GameState state = GameState.Get();
        for (int i = 0; i < tasks.Count; i++)
        {
            Network.PowerHistory power = tasks[i].GetPower();
            if (power.Type == Network.PowerHistory.PowType.META_DATA)
            {
                Network.HistMetaData data = power as Network.HistMetaData;
                if (data.MetaType == Network.HistMetaData.TypeMetaType.META_TARGET)
                {
                    if ((data.Info == null) || (data.Info.Count == 0))
                    {
                        UnityEngine.Debug.LogError(string.Format("{0}.AddSinglePowerTarget_FromMetaData() - META_DATA at index {1} has no Info", this, i));
                    }
                    else
                    {
                        for (int j = 0; j < data.Info.Count; j++)
                        {
                            Entity entity = state.GetEntity(data.Info[j]);
                            if (entity == null)
                            {
                                UnityEngine.Debug.LogError(string.Format("{0}.AddSinglePowerTarget_FromMetaData() - Entity is null for META_DATA at index {1} Info index {2}", this, i, j));
                            }
                            else
                            {
                                Card targetCard = entity.GetCard();
                                this.AddTargetFromMetaData(i, targetCard);
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    protected bool AddSinglePowerTarget_FromSourceAction(Network.HistActionStart sourceAction)
    {
        Entity entity = GameState.Get().GetEntity(sourceAction.Target);
        if (entity == null)
        {
            return false;
        }
        Card card = entity.GetCard();
        if (card == null)
        {
            Log.Power.Print(string.Format("{0}.AddSinglePowerTarget_FromSourceAction() - FAILED Target {1} in sourceAction has no Card", this, sourceAction.Target));
            return false;
        }
        this.AddTarget(card.gameObject);
        return true;
    }

    public void AddStateFinishedCallback(StateFinishedCallback callback)
    {
        this.AddStateFinishedCallback(callback, null);
    }

    public void AddStateFinishedCallback(StateFinishedCallback callback, object userData)
    {
        StateFinishedListener item = new StateFinishedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (!this.m_stateFinishedListeners.Contains(item))
        {
            this.m_stateFinishedListeners.Add(item);
        }
    }

    public void AddStateStartedCallback(StateStartedCallback callback)
    {
        this.AddStateStartedCallback(callback, null);
    }

    public void AddStateStartedCallback(StateStartedCallback callback, object userData)
    {
        StateStartedListener item = new StateStartedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (!this.m_stateStartedListeners.Contains(item))
        {
            this.m_stateStartedListeners.Add(item);
        }
    }

    public virtual void AddTarget(GameObject go)
    {
        this.m_targets.Add(go);
    }

    protected virtual void AddTargetFromMetaData(int metaDataIndex, Card targetCard)
    {
        this.AddTarget(targetCard.gameObject);
    }

    public virtual void AddTargets(List<GameObject> targets)
    {
        this.m_targets.AddRange(targets);
    }

    public virtual void AddVisualTarget(GameObject go)
    {
        this.AddTarget(go);
    }

    public virtual void AddVisualTargets(List<GameObject> targets)
    {
        this.AddTargets(targets);
    }

    public bool AttachPowerTaskList(PowerTaskList taskList)
    {
        this.m_taskList = taskList;
        this.RemoveAllTargets();
        return this.AddPowerTargets();
    }

    protected virtual void Awake()
    {
        this.BuildSpellStateMap();
        this.m_fsm = base.GetComponent<PlayMakerFSM>();
        if (!string.IsNullOrEmpty(this.m_LocationTransformName))
        {
            this.m_LocationTransformName = this.m_LocationTransformName.Trim();
        }
    }

    private void BuildFsmStateMap()
    {
        if (this.m_fsm != null)
        {
            List<FsmState> list = this.GenerateSpellFsmStateList();
            if (list.Count > 0)
            {
                this.m_fsmStateMap = new Dictionary<SpellStateType, FsmState>();
            }
            Dictionary<SpellStateType, int> dictionary = new Dictionary<SpellStateType, int>();
            IEnumerator enumerator = Enum.GetValues(typeof(SpellStateType)).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    SpellStateType current = (SpellStateType) ((int) enumerator.Current);
                    dictionary[current] = 0;
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                }
                disposable.Dispose();
            }
            Dictionary<SpellStateType, int> dictionary2 = new Dictionary<SpellStateType, int>();
            IEnumerator enumerator2 = Enum.GetValues(typeof(SpellStateType)).GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    SpellStateType type2 = (SpellStateType) ((int) enumerator2.Current);
                    dictionary2[type2] = 0;
                }
            }
            finally
            {
                IDisposable disposable2 = enumerator2 as IDisposable;
                if (disposable2 == null)
                {
                }
                disposable2.Dispose();
            }
            foreach (FsmTransition transition in this.m_fsm.FsmGlobalTransitions)
            {
                SpellStateType type3;
                Dictionary<SpellStateType, int> dictionary3;
                SpellStateType type4;
                try
                {
                    type3 = EnumUtils.GetEnum<SpellStateType>(transition.EventName);
                }
                catch (ArgumentException)
                {
                    goto Label_01D6;
                }
                int num2 = dictionary3[type4];
                (dictionary3 = dictionary2)[type4 = type3] = num2 + 1;
                foreach (FsmState state in list)
                {
                    if (transition.ToState.Equals(state.Name))
                    {
                        Dictionary<SpellStateType, int> dictionary4;
                        num2 = dictionary4[type4];
                        (dictionary4 = dictionary)[type4 = type3] = num2 + 1;
                        if (!this.m_fsmStateMap.ContainsKey(type3))
                        {
                            this.m_fsmStateMap.Add(type3, state);
                        }
                    }
                }
            Label_01D6:;
            }
            foreach (KeyValuePair<SpellStateType, int> pair in dictionary)
            {
                if (pair.Value > 1)
                {
                    UnityEngine.Debug.LogWarning(string.Format("{0}.BuildFsmStateMap() - Found {1} states for SpellStateType {2}. There should be 1.", this, pair.Value, pair.Key));
                }
            }
            foreach (KeyValuePair<SpellStateType, int> pair2 in dictionary2)
            {
                if (pair2.Value > 1)
                {
                    UnityEngine.Debug.LogWarning(string.Format("{0}.BuildFsmStateMap() - Found {1} transitions for SpellStateType {2}. There should be 1.", this, pair2.Value, pair2.Key));
                }
                if ((pair2.Value > 0) && (dictionary[pair2.Key] == 0))
                {
                    UnityEngine.Debug.LogWarning(string.Format("{0}.BuildFsmStateMap() - SpellStateType {1} is missing a SpellStateAction.", this, pair2.Key));
                }
            }
            if ((this.m_fsmStateMap != null) && (this.m_fsmStateMap.Values.Count == 0))
            {
                this.m_fsmStateMap = null;
            }
        }
    }

    private void BuildSpellStateMap()
    {
        IEnumerator enumerator = base.transform.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                Transform current = (Transform) enumerator.Current;
                SpellState component = current.gameObject.GetComponent<SpellState>();
                if (component != null)
                {
                    SpellStateType stateType = component.m_StateType;
                    if (stateType != SpellStateType.NONE)
                    {
                        List<SpellState> list;
                        if (this.m_spellStateMap == null)
                        {
                            this.m_spellStateMap = new Dictionary<SpellStateType, List<SpellState>>();
                        }
                        if (!this.m_spellStateMap.TryGetValue(stateType, out list))
                        {
                            list = new List<SpellState>();
                            this.m_spellStateMap.Add(stateType, list);
                        }
                        list.Add(component);
                    }
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }

    protected void CallStateFunction(SpellStateType prevStateType, SpellStateType stateType)
    {
        switch (stateType)
        {
            case SpellStateType.BIRTH:
                this.OnBirth(prevStateType);
                break;

            case SpellStateType.IDLE:
                this.OnIdle(prevStateType);
                break;

            case SpellStateType.ACTION:
                this.OnAction(prevStateType);
                break;

            case SpellStateType.CANCEL:
                this.OnCancel(prevStateType);
                break;

            case SpellStateType.DEATH:
                this.OnDeath(prevStateType);
                break;

            default:
                this.OnNone(prevStateType);
                break;
        }
    }

    protected bool CanAddPowerTargets()
    {
        if (!this.m_taskList.HasMetaDataTasks())
        {
            PowerTaskList list;
            for (list = this.m_taskList.GetPrevious(); list != null; list = list.GetPrevious())
            {
                if (list.HasMetaDataTasks())
                {
                    return false;
                }
            }
            for (list = this.m_taskList.GetNext(); list != null; list = list.GetNext())
            {
                if (list.HasMetaDataTasks())
                {
                    return false;
                }
            }
        }
        return true;
    }

    protected void ChangeFsmState(SpellStateType stateType)
    {
        if (this.m_fsm != null)
        {
            base.StartCoroutine(this.WaitThenChangeFsmState(stateType));
        }
    }

    private void ChangeFsmStateNow(SpellStateType stateType)
    {
        if (this.m_fsmStateMap == null)
        {
            UnityEngine.Debug.LogError(string.Format("Spell.ChangeFsmStateNow() - stateType {0} was requested but the m_fsmStateMap is null", stateType));
        }
        else
        {
            FsmState state = null;
            if (this.m_fsmStateMap.TryGetValue(stateType, out state))
            {
                this.m_fsm.SendEvent(EnumUtils.GetString<SpellStateType>(stateType));
            }
        }
    }

    public virtual void ChangeState(SpellStateType stateType)
    {
        this.ChangeStateImpl(stateType);
        if (this.m_activeStateType == stateType)
        {
            this.ChangeFsmState(stateType);
        }
    }

    protected void ChangeStateImpl(SpellStateType stateType)
    {
        this.m_activeStateChange = stateType;
        SpellStateType activeStateType = this.m_activeStateType;
        this.m_activeStateType = stateType;
        if (stateType == SpellStateType.NONE)
        {
            this.FinishIfNecessary();
        }
        List<SpellState> list = null;
        if (this.m_spellStateMap != null)
        {
            this.m_spellStateMap.TryGetValue(stateType, out list);
        }
        if (activeStateType != SpellStateType.NONE)
        {
            List<SpellState> list2;
            if ((this.m_spellStateMap != null) && this.m_spellStateMap.TryGetValue(activeStateType, out list2))
            {
                foreach (SpellState state in list2)
                {
                    state.Stop(list);
                }
            }
            this.FireStateFinishedCallbacks(activeStateType);
        }
        else if (stateType != SpellStateType.NONE)
        {
            this.m_finished = false;
            this.ActivateObjectContainer(true);
            if (this.DoesBlockServerEvents())
            {
                GameState.Get().AddServerBlockingSpell(this);
            }
        }
        if (list != null)
        {
            foreach (SpellState state2 in list)
            {
                state2.Play();
            }
        }
        this.CallStateFunction(activeStateType, stateType);
        if ((activeStateType != SpellStateType.NONE) && (stateType == SpellStateType.NONE))
        {
            if (this.DoesBlockServerEvents())
            {
                GameState.Get().RemoveServerBlockingSpell(this);
            }
            this.ActivateObjectContainer(false);
        }
    }

    protected bool CompleteMetaDataTasks(int metaDataIndex)
    {
        return this.CompleteMetaDataTasks(metaDataIndex, null, null);
    }

    protected bool CompleteMetaDataTasks(int metaDataIndex, PowerTaskList.CompleteCallback completeCallback)
    {
        return this.CompleteMetaDataTasks(metaDataIndex, completeCallback, null);
    }

    protected bool CompleteMetaDataTasks(int metaDataIndex, PowerTaskList.CompleteCallback completeCallback, object callbackData)
    {
        List<PowerTask> taskList = this.m_taskList.GetTaskList();
        int count = 1;
        for (int i = metaDataIndex + 1; i < taskList.Count; i++)
        {
            PowerTask task = taskList[i];
            if (task.GetPower().Type == Network.PowerHistory.PowType.META_DATA)
            {
                break;
            }
            count++;
        }
        if (count == 0)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.CompleteMetaDataTasks() - there are no tasks to complete for meta data {1}", this, metaDataIndex));
            return false;
        }
        this.m_taskList.DoTasks(metaDataIndex, count, completeCallback, callbackData);
        return true;
    }

    public void Deactivate()
    {
        if (this.m_activeStateType != SpellStateType.NONE)
        {
            this.ForceDeactivate();
        }
    }

    public bool DoesBlockServerEvents()
    {
        if (GameState.Get() == null)
        {
            return false;
        }
        return this.m_BlockServerEvents;
    }

    protected void FinishIfNecessary()
    {
        if (!this.m_finished)
        {
            this.OnSpellFinished();
        }
    }

    protected void FireFinishedCallbacks()
    {
        FinishedListener[] listenerArray = this.m_finishedListeners.ToArray();
        this.m_finishedListeners.Clear();
        foreach (FinishedListener listener in listenerArray)
        {
            listener.Fire(this);
        }
    }

    protected void FireStateFinishedCallbacks(SpellStateType prevStateType)
    {
        StateFinishedListener[] listenerArray = this.m_stateFinishedListeners.ToArray();
        if (this.m_activeStateType == SpellStateType.NONE)
        {
            this.m_stateFinishedListeners.Clear();
        }
        foreach (StateFinishedListener listener in listenerArray)
        {
            listener.Fire(this, prevStateType);
        }
    }

    protected void FireStateStartedCallbacks(SpellStateType prevStateType)
    {
        StateStartedListener[] listenerArray = this.m_stateStartedListeners.ToArray();
        if (this.m_activeStateType == SpellStateType.NONE)
        {
            this.m_stateStartedListeners.Clear();
        }
        foreach (StateStartedListener listener in listenerArray)
        {
            listener.Fire(this, prevStateType);
        }
    }

    public void ForceDeactivate()
    {
        this.ChangeState(SpellStateType.NONE);
    }

    private List<FsmState> GenerateSpellFsmStateList()
    {
        List<FsmState> list = new List<FsmState>();
        foreach (FsmState state in this.m_fsm.FsmStates)
        {
            SpellStateAction action = null;
            int num2 = 0;
            for (int i = 0; i < state.Actions.Length; i++)
            {
                FsmStateAction action2 = state.Actions[i];
                SpellStateAction action3 = action2 as SpellStateAction;
                if (action3 != null)
                {
                    num2++;
                    if (action == null)
                    {
                        action = action3;
                    }
                }
            }
            if (action != null)
            {
                list.Add(state);
            }
            if (num2 > 1)
            {
                UnityEngine.Debug.LogWarning(string.Format("{0}.GenerateSpellFsmStateList() - State \"{1}\" has {2} SpellStateActions. There should be 1.", this, state.Name, num2));
            }
        }
        return list;
    }

    public SpellStateType GetActiveState()
    {
        return this.m_activeStateType;
    }

    public List<SpellState> GetActiveStateList()
    {
        if (this.m_spellStateMap == null)
        {
            return null;
        }
        List<SpellState> list = null;
        if (!this.m_spellStateMap.TryGetValue(this.m_activeStateType, out list))
        {
            return null;
        }
        return list;
    }

    public SpellFacing GetFacing()
    {
        return this.m_Facing;
    }

    public SpellFacingOptions GetFacingOptions()
    {
        return this.m_FacingOptions;
    }

    public SpellState GetFirstSpellState(SpellStateType stateType)
    {
        if (this.m_spellStateMap == null)
        {
            return null;
        }
        List<SpellState> list = null;
        if (!this.m_spellStateMap.TryGetValue(stateType, out list))
        {
            return null;
        }
        if (list.Count == 0)
        {
            return null;
        }
        return list[0];
    }

    public SpellLocation GetLocation()
    {
        return this.m_Location;
    }

    public string GetLocationTransformName()
    {
        return this.m_LocationTransformName;
    }

    public Entity GetPowerSource()
    {
        if (this.m_taskList == null)
        {
            return null;
        }
        return this.m_taskList.GetSourceEntity();
    }

    public Card GetPowerSourceCard()
    {
        Entity powerSource = this.GetPowerSource();
        return ((powerSource != null) ? powerSource.GetCard() : null);
    }

    public Entity GetPowerTarget()
    {
        if (this.m_taskList == null)
        {
            return null;
        }
        return this.m_taskList.GetTargetEntity();
    }

    public Card GetPowerTargetCard()
    {
        Entity powerTarget = this.GetPowerTarget();
        return ((powerTarget != null) ? powerTarget.GetCard() : null);
    }

    public PowerTaskList GetPowerTaskList()
    {
        return this.m_taskList;
    }

    public GameObject GetSource()
    {
        return this.m_source;
    }

    public Card GetSourceCard()
    {
        if (this.m_source == null)
        {
            return null;
        }
        return this.m_source.GetComponent<Card>();
    }

    public SpellType GetSpellType()
    {
        return this.m_spellType;
    }

    protected string GetStateMethodName(SpellStateType stateType)
    {
        switch (stateType)
        {
            case SpellStateType.BIRTH:
                return "OnBirth";

            case SpellStateType.IDLE:
                return "OnIdle";

            case SpellStateType.ACTION:
                return "OnAction";

            case SpellStateType.CANCEL:
                return "OnCancel";

            case SpellStateType.DEATH:
                return "OnDeath";
        }
        return null;
    }

    public SuperSpell GetSuperSpellParent()
    {
        if (base.transform.parent == null)
        {
            return null;
        }
        return base.transform.parent.GetComponent<SuperSpell>();
    }

    public GameObject GetTarget()
    {
        return ((this.m_targets.Count != 0) ? this.m_targets[0] : null);
    }

    public Card GetTargetCard()
    {
        GameObject target = this.GetTarget();
        if (target == null)
        {
            return null;
        }
        return target.GetComponent<Card>();
    }

    protected virtual Card GetTargetCardFromPowerTask(PowerTask task)
    {
        Network.PowerHistory power = task.GetPower();
        if (power.Type != Network.PowerHistory.PowType.TAG_CHANGE)
        {
            return null;
        }
        Network.HistTagChange change = power as Network.HistTagChange;
        Entity entity = GameState.Get().GetEntity(change.Entity);
        if (entity == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("{0}.GetTargetCardFromPowerTask() - WARNING trying to target entity with id {1} but there is no entity with that id", this, change.Entity));
            return null;
        }
        return entity.GetCard();
    }

    public List<GameObject> GetTargets()
    {
        return this.m_targets;
    }

    public virtual GameObject GetVisualTarget()
    {
        return this.GetTarget();
    }

    public virtual Card GetVisualTargetCard()
    {
        return this.GetTargetCard();
    }

    public virtual List<GameObject> GetVisualTargets()
    {
        return this.GetTargets();
    }

    public SpellStateType GuessNextStateType()
    {
        return this.GuessNextStateType(this.m_activeStateType);
    }

    public SpellStateType GuessNextStateType(SpellStateType stateType)
    {
        switch (stateType)
        {
            case SpellStateType.NONE:
                if (!this.HasUsableState(SpellStateType.BIRTH))
                {
                    if (this.HasUsableState(SpellStateType.IDLE))
                    {
                        return SpellStateType.IDLE;
                    }
                    if (this.HasUsableState(SpellStateType.ACTION))
                    {
                        return SpellStateType.ACTION;
                    }
                    if (this.HasUsableState(SpellStateType.DEATH))
                    {
                        return SpellStateType.DEATH;
                    }
                    if (this.HasUsableState(SpellStateType.CANCEL))
                    {
                        return SpellStateType.CANCEL;
                    }
                    break;
                }
                return SpellStateType.BIRTH;

            case SpellStateType.BIRTH:
                if (!this.HasUsableState(SpellStateType.IDLE))
                {
                    break;
                }
                return SpellStateType.IDLE;

            case SpellStateType.IDLE:
                if (!this.HasUsableState(SpellStateType.ACTION))
                {
                    break;
                }
                return SpellStateType.ACTION;

            case SpellStateType.ACTION:
                if (!this.HasUsableState(SpellStateType.DEATH))
                {
                    break;
                }
                return SpellStateType.DEATH;
        }
        return SpellStateType.NONE;
    }

    protected bool HasOverriddenStateMethod(SpellStateType stateType)
    {
        string stateMethodName = this.GetStateMethodName(stateType);
        if (stateMethodName == null)
        {
            return false;
        }
        System.Type type = base.GetType();
        MethodInfo method = typeof(Spell).GetMethod(stateMethodName, BindingFlags.NonPublic | BindingFlags.Instance);
        return GeneralUtils.IsOverriddenMethod(type.GetMethod(stateMethodName, BindingFlags.NonPublic | BindingFlags.Instance), method);
    }

    protected bool HasStateContent(SpellStateType stateType)
    {
        if ((this.m_spellStateMap != null) && this.m_spellStateMap.ContainsKey(stateType))
        {
            return true;
        }
        if (!this.m_fsmReady)
        {
            if ((this.m_fsm != null) && this.m_fsm.Fsm.HasEvent(EnumUtils.GetString<SpellStateType>(stateType)))
            {
                return true;
            }
        }
        else if ((this.m_fsmStateMap != null) && this.m_fsmStateMap.ContainsKey(stateType))
        {
            return true;
        }
        return false;
    }

    public virtual bool HasUsableState(SpellStateType stateType)
    {
        if (stateType == SpellStateType.NONE)
        {
            return false;
        }
        return (this.HasStateContent(stateType) || this.HasOverriddenStateMethod(stateType));
    }

    public void Hide()
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            this.HideImpl();
        }
    }

    protected virtual void HideImpl()
    {
        List<SpellState> activeStateList = this.GetActiveStateList();
        if (activeStateList != null)
        {
            foreach (SpellState state in activeStateList)
            {
                state.HideState();
            }
        }
        if (this.m_activeStateType != SpellStateType.NONE)
        {
            if (this.DoesBlockServerEvents())
            {
                GameState.Get().RemoveServerBlockingSpell(this);
            }
            this.ActivateObjectContainer(false);
        }
    }

    public bool IsActive()
    {
        return (this.m_activeStateType != SpellStateType.NONE);
    }

    public bool IsFinished()
    {
        return this.m_finished;
    }

    public bool IsShown()
    {
        return this.m_shown;
    }

    public bool IsSource(GameObject go)
    {
        return (this.m_source == go);
    }

    public bool IsTarget(GameObject go)
    {
        return this.m_targets.Contains(go);
    }

    public virtual bool IsVisualTarget(GameObject go)
    {
        return this.IsTarget(go);
    }

    protected virtual void OnAction(SpellStateType prevStateType)
    {
        this.UpdateTransform();
        this.FireStateStartedCallbacks(prevStateType);
    }

    protected virtual void OnBirth(SpellStateType prevStateType)
    {
        this.UpdateTransform();
        this.FireStateStartedCallbacks(prevStateType);
    }

    protected virtual void OnCancel(SpellStateType prevStateType)
    {
        this.FireStateStartedCallbacks(prevStateType);
    }

    protected virtual void OnDeath(SpellStateType prevStateType)
    {
        this.FireStateStartedCallbacks(prevStateType);
    }

    public virtual void OnFsmStateStarted(FsmState state, SpellStateType stateType)
    {
        if (this.m_activeStateChange != stateType)
        {
            this.ChangeStateImpl(stateType);
        }
    }

    protected virtual void OnIdle(SpellStateType prevStateType)
    {
        this.FireStateStartedCallbacks(prevStateType);
    }

    public void OnLoad()
    {
        IEnumerator enumerator = base.transform.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                Transform current = (Transform) enumerator.Current;
                SpellState component = current.gameObject.GetComponent<SpellState>();
                if (component != null)
                {
                    component.OnLoad();
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }

    protected virtual void OnNone(SpellStateType prevStateType)
    {
        this.FireStateStartedCallbacks(prevStateType);
    }

    public virtual void OnSpellFinished()
    {
        this.m_finished = true;
        this.m_positionDirty = true;
        this.m_orientationDirty = true;
        if (this.DoesBlockServerEvents())
        {
            GameState.Get().RemoveServerBlockingSpell(this);
        }
        this.FireFinishedCallbacks();
    }

    public virtual void OnStateFinished()
    {
        SpellStateType stateType = this.GuessNextStateType();
        this.ChangeState(stateType);
    }

    public void Reactivate()
    {
        SpellStateType stateType = this.GuessNextStateType(SpellStateType.NONE);
        if (stateType == SpellStateType.NONE)
        {
            this.Deactivate();
        }
        else
        {
            this.ChangeState(stateType);
        }
    }

    public virtual void RemoveAllTargets()
    {
        this.m_targets.Clear();
    }

    public virtual void RemoveAllVisualTargets()
    {
        this.RemoveAllTargets();
    }

    public bool RemoveFinishedCallback(FinishedCallback callback)
    {
        return this.RemoveFinishedCallback(callback, null);
    }

    public bool RemoveFinishedCallback(FinishedCallback callback, object userData)
    {
        FinishedListener item = new FinishedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_finishedListeners.Remove(item);
    }

    public virtual void RemoveSource()
    {
        this.m_source = null;
    }

    public bool RemoveStateFinishedCallback(StateFinishedCallback callback)
    {
        return this.RemoveStateFinishedCallback(callback, null);
    }

    public bool RemoveStateFinishedCallback(StateFinishedCallback callback, object userData)
    {
        StateFinishedListener item = new StateFinishedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_stateFinishedListeners.Remove(item);
    }

    public bool RemoveStateStartedCallback(StateStartedCallback callback)
    {
        return this.RemoveStateStartedCallback(callback, null);
    }

    public bool RemoveStateStartedCallback(StateStartedCallback callback, object userData)
    {
        StateStartedListener item = new StateStartedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_stateStartedListeners.Remove(item);
    }

    public virtual bool RemoveTarget(GameObject go)
    {
        return this.m_targets.Remove(go);
    }

    public virtual bool RemoveVisualTarget(GameObject go)
    {
        return this.RemoveTarget(go);
    }

    public void SafeActivateState(SpellStateType stateType)
    {
        if (!this.HasUsableState(stateType))
        {
            this.ForceDeactivate();
        }
        else
        {
            this.ChangeState(stateType);
        }
    }

    public void SetLocalOrientation(Quaternion orientation)
    {
        base.transform.localRotation = orientation;
        this.m_orientationDirty = false;
    }

    public void SetLocalPosition(Vector3 position)
    {
        base.transform.localPosition = position;
        this.m_positionDirty = false;
    }

    public void SetOrientation(Quaternion orientation)
    {
        base.transform.rotation = orientation;
        this.m_orientationDirty = false;
    }

    public void SetPosition(Vector3 position)
    {
        base.transform.position = position;
        this.m_positionDirty = false;
    }

    public virtual void SetSource(GameObject go)
    {
        this.m_source = go;
    }

    public void SetSpellType(SpellType spellType)
    {
        this.m_spellType = spellType;
    }

    public void Show()
    {
        if (!this.m_shown)
        {
            this.m_shown = true;
            this.ShowImpl();
        }
    }

    protected virtual void ShowImpl()
    {
        if (this.m_activeStateType != SpellStateType.NONE)
        {
            this.ActivateObjectContainer(true);
            if (this.DoesBlockServerEvents())
            {
                GameState.Get().AddServerBlockingSpell(this);
            }
        }
        List<SpellState> activeStateList = this.GetActiveStateList();
        if (activeStateList != null)
        {
            foreach (SpellState state in activeStateList)
            {
                state.ShowState();
            }
        }
    }

    protected virtual void Start()
    {
        if (this.m_activeStateType == SpellStateType.NONE)
        {
            this.ActivateObjectContainer(false);
        }
        else if (this.m_shown)
        {
            this.ShowImpl();
        }
        else
        {
            this.HideImpl();
        }
    }

    private void Update()
    {
        if (!this.m_fsmReady)
        {
            if (this.m_fsm == null)
            {
                this.m_fsmReady = true;
            }
            else if (!this.m_fsmSkippedFirstFrame)
            {
                this.m_fsmSkippedFirstFrame = true;
            }
            else if (this.m_fsm.enabled)
            {
                this.BuildFsmStateMap();
                this.m_fsmReady = true;
            }
        }
    }

    public void UpdateOrientation()
    {
        if (this.m_orientationDirty)
        {
            SpellUtils.SetOrientationFromFacing(this);
            this.m_orientationDirty = false;
        }
    }

    public void UpdatePosition()
    {
        if (this.m_positionDirty)
        {
            SpellUtils.SetPositionFromLocation(this);
            this.m_positionDirty = false;
        }
    }

    public void UpdateTransform()
    {
        this.UpdatePosition();
        this.UpdateOrientation();
    }

    [DebuggerHidden]
    private IEnumerator WaitThenChangeFsmState(SpellStateType stateType)
    {
        return new <WaitThenChangeFsmState>c__IteratorA3 { stateType = stateType, <$>stateType = stateType, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenChangeFsmState>c__IteratorA3 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SpellStateType <$>stateType;
        internal Spell <>f__this;
        internal SpellStateType stateType;

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
                    if (!this.<>f__this.m_fsmReady)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    if (this.<>f__this.m_activeStateType == this.stateType)
                    {
                        this.<>f__this.ChangeFsmStateNow(this.stateType);
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

    public delegate void FinishedCallback(Spell spell, object userData);

    private class FinishedListener : EventListener<Spell.FinishedCallback>
    {
        public void Fire(Spell spell)
        {
            base.m_callback(spell, base.m_userData);
        }
    }

    public delegate void StateFinishedCallback(Spell spell, SpellStateType prevStateType, object userData);

    private class StateFinishedListener : EventListener<Spell.StateFinishedCallback>
    {
        public void Fire(Spell spell, SpellStateType prevStateType)
        {
            base.m_callback(spell, prevStateType, base.m_userData);
        }
    }

    public delegate void StateStartedCallback(Spell spell, SpellStateType prevStateType, object userData);

    private class StateStartedListener : EventListener<Spell.StateStartedCallback>
    {
        public void Fire(Spell spell, SpellStateType prevStateType)
        {
            base.m_callback(spell, prevStateType, base.m_userData);
        }
    }
}

