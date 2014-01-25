using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SuperSpell : Spell
{
    public SpellActionInfo m_ActionInfo;
    public SpellChainInfo m_ChainInfo;
    protected int m_currentTargetIndex;
    protected int m_effectsPendingFinish;
    public SpellAreaEffectInfo m_FriendlyAreaEffectInfo;
    public SpellImpactInfo m_ImpactInfo;
    public bool m_MakeClones = true;
    public SpellMissileInfo m_MissileInfo;
    public SpellAreaEffectInfo m_OpponentAreaEffectInfo;
    protected bool m_pendingNoneStateChange;
    protected bool m_pendingSpellFinish;
    protected bool m_settingUpAction;
    public SpellStartInfo m_StartInfo;
    protected Spell m_startSpell;
    public SpellTargetInfo m_TargetInfo = new SpellTargetInfo();
    protected Dictionary<int, int> m_targetToMetaDataMap = new Dictionary<int, int>();
    protected List<GameObject> m_visualTargets = new List<GameObject>();
    protected Dictionary<int, int> m_visualToTargetIndexMap = new Dictionary<int, int>();

    private void AddAllTargetsAsVisualTargets()
    {
        for (int i = 0; i < base.m_targets.Count; i++)
        {
            int count = this.m_visualTargets.Count;
            this.m_visualToTargetIndexMap[count] = i;
            this.AddVisualTarget(base.m_targets[i]);
        }
    }

    private void AddChosenTargetAsVisualTarget()
    {
        Card powerTargetCard = base.GetPowerTargetCard();
        if (powerTargetCard == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("{0}.AddChosenTargetAsVisualTarget() - there is no chosen target", this));
        }
        else
        {
            this.AddVisualTarget(powerTargetCard.gameObject);
        }
    }

    public override bool AddPowerTargets()
    {
        this.m_visualToTargetIndexMap.Clear();
        this.m_targetToMetaDataMap.Clear();
        if (!base.CanAddPowerTargets())
        {
            return false;
        }
        if (this.HasChain() && !this.AddPrimaryChainTarget())
        {
            return false;
        }
        if (!base.AddMultiplePowerTargets())
        {
            return false;
        }
        if (base.m_targets.Count <= 0)
        {
            Network.HistActionStart sourceAction = base.m_taskList.GetSourceAction();
            if ((sourceAction != null) && (sourceAction.Target != 0))
            {
                return base.AddSinglePowerTarget_FromSourceAction(sourceAction);
            }
        }
        return true;
    }

    private bool AddPrimaryChainTarget()
    {
        Network.HistActionStart sourceAction = base.m_taskList.GetSourceAction();
        if (sourceAction == null)
        {
            return false;
        }
        return base.AddSinglePowerTarget_FromSourceAction(sourceAction);
    }

    protected override void AddTargetFromMetaData(int metaDataIndex, Card targetCard)
    {
        int count = base.m_targets.Count;
        this.m_targetToMetaDataMap[count] = metaDataIndex;
        this.AddTarget(targetCard.gameObject);
    }

    public override void AddVisualTarget(GameObject go)
    {
        this.m_visualTargets.Add(go);
    }

    public override void AddVisualTargets(List<GameObject> targets)
    {
        this.m_visualTargets.AddRange(targets);
    }

    private bool AreEffectsActive()
    {
        return (this.m_effectsPendingFinish > 0);
    }

    private bool CheckAndWaitForGameEventsThenDoAction()
    {
        if (base.m_taskList == null)
        {
            return false;
        }
        if (this.HasMetaDataTargets())
        {
            return false;
        }
        if (this.m_ActionInfo.m_ShowSpellVisuals == SpellVisualShowTime.DURING_GAME_EVENTS)
        {
            base.m_taskList.DoAllTasks();
        }
        if (this.m_ActionInfo.m_ShowSpellVisuals != SpellVisualShowTime.AFTER_GAME_EVENTS)
        {
            return false;
        }
        this.m_effectsPendingFinish++;
        PowerTaskList.CompleteCallback callback = delegate (PowerTaskList taskList, int startIndex, int count, object userData) {
            this.m_effectsPendingFinish--;
            if (!this.CheckAndWaitForStartDelayThenDoAction())
            {
                this.DoActionNow();
            }
        };
        base.m_taskList.DoAllTasks(callback);
        return true;
    }

    private bool CheckAndWaitForStartDelayThenDoAction()
    {
        if (Mathf.Min(this.m_ActionInfo.m_StartDelayMax, this.m_ActionInfo.m_StartDelayMin) <= float.Epsilon)
        {
            return false;
        }
        this.m_effectsPendingFinish++;
        base.StartCoroutine(this.WaitForDelayThenDoAction());
        return true;
    }

    protected virtual void CleanUp()
    {
        foreach (GameObject obj2 in this.m_visualTargets)
        {
            if (obj2.GetComponent<SpellGeneratedTarget>() != null)
            {
                UnityEngine.Object.Destroy(obj2);
            }
        }
        this.m_visualTargets.Clear();
    }

    private Spell CloneSpell(Spell prefab)
    {
        Spell spell;
        if (this.IsMakingClones())
        {
            spell = (Spell) UnityEngine.Object.Instantiate(prefab);
            spell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnCloneSpellStateFinished));
            spell.transform.parent = base.transform;
        }
        else
        {
            spell = prefab;
            spell.RemoveAllTargets();
        }
        spell.AddFinishedCallback(new Spell.FinishedCallback(this.OnCloneSpellFinished));
        return spell;
    }

    [DebuggerHidden]
    private IEnumerator CompleteMetaDataTasks_FromTarget(int visualTargetIndex, float delaySec)
    {
        return new <CompleteMetaDataTasks_FromTarget>c__IteratorC8 { visualTargetIndex = visualTargetIndex, delaySec = delaySec, <$>visualTargetIndex = visualTargetIndex, <$>delaySec = delaySec, <>f__this = this };
    }

    private float ComputeBoxPickChance(int[] boxUsageCounts, int index)
    {
        int num = boxUsageCounts[index];
        float num3 = boxUsageCounts.Length * 0.25f;
        float num4 = ((float) num) / num3;
        return (1f - num4);
    }

    private SpellAreaEffectInfo DetermineAreaEffectInfo()
    {
        Card sourceCard = base.GetSourceCard();
        if (sourceCard != null)
        {
            Player controller = sourceCard.GetController();
            if (controller != null)
            {
                if (controller.IsLocal() && this.HasFriendlyAreaEffect())
                {
                    return this.m_FriendlyAreaEffectInfo;
                }
                if (!controller.IsLocal() && this.HasOpponentAreaEffect())
                {
                    return this.m_OpponentAreaEffectInfo;
                }
            }
        }
        if (this.HasFriendlyAreaEffect())
        {
            return this.m_FriendlyAreaEffectInfo;
        }
        if (this.HasOpponentAreaEffect())
        {
            return this.m_OpponentAreaEffectInfo;
        }
        return null;
    }

    private Spell DetermineImpactPrefab(GameObject targetObject)
    {
        if (this.m_ImpactInfo.m_DamageAmountImpacts.Length == 0)
        {
            return this.m_ImpactInfo.m_Prefab;
        }
        Spell prefab = this.m_ImpactInfo.m_DamageAmountImpacts[0].m_Prefab;
        if (base.m_taskList != null)
        {
            Card component = targetObject.GetComponent<Card>();
            if (component == null)
            {
                return prefab;
            }
            PowerTaskList.DamageInfo damageInfo = base.m_taskList.GetDamageInfo(component.GetEntity());
            if (damageInfo == null)
            {
                return prefab;
            }
            foreach (SpellImpactPrefabs prefabs in this.m_ImpactInfo.m_DamageAmountImpacts)
            {
                if ((damageInfo.m_damage >= prefabs.m_MinDamage) && (damageInfo.m_damage <= prefabs.m_MaxDamage))
                {
                    prefab = prefabs.m_Prefab;
                }
            }
        }
        return prefab;
    }

    private void DoAction()
    {
        if (!this.CheckAndWaitForGameEventsThenDoAction() && !this.CheckAndWaitForStartDelayThenDoAction())
        {
            this.DoActionNow();
        }
    }

    private void DoActionNow()
    {
        SpellAreaEffectInfo info = this.DetermineAreaEffectInfo();
        if (info != null)
        {
            this.SpawnAreaEffect(info);
        }
        bool flag = this.HasMissile();
        bool flag2 = this.HasImpact();
        bool flag3 = this.HasChain();
        if ((this.GetVisualTargetCount() > 0) && ((flag || flag2) || flag3))
        {
            if (flag)
            {
                if (flag3)
                {
                    this.SpawnChainMissile();
                }
                else if (this.m_MissileInfo.m_SpawnInSequence)
                {
                    this.SpawnMissileInSequence();
                }
                else
                {
                    this.SpawnAllMissiles();
                }
            }
            else
            {
                if (this.HasStart() && (this.m_startSpell == null))
                {
                    this.SpawnStart();
                }
                if (this.m_startSpell != null)
                {
                    this.DoStartSpellAction();
                }
                if (flag2)
                {
                    if (flag3)
                    {
                        this.SpawnImpact(this.m_currentTargetIndex);
                    }
                    else
                    {
                        this.SpawnAllImpacts();
                    }
                }
                if (flag3)
                {
                    this.SpawnChain();
                }
            }
        }
        else
        {
            if (this.HasStart() && (this.m_startSpell == null))
            {
                this.SpawnStart();
            }
            if (this.m_startSpell != null)
            {
                this.DoStartSpellAction();
            }
        }
    }

    private void DoStartSpellAction()
    {
        if (!this.m_startSpell.HasUsableState(SpellStateType.ACTION))
        {
            this.m_startSpell.ActivateState(SpellStateType.DEATH);
        }
        else
        {
            this.m_startSpell.AddFinishedCallback(new Spell.FinishedCallback(this.OnActionStartSpellFinished));
            this.m_startSpell.ActivateState(SpellStateType.ACTION);
        }
        this.m_startSpell = null;
    }

    protected void FinishIfPossible()
    {
        if (!this.m_settingUpAction && !this.AreEffectsActive())
        {
            if (this.m_pendingSpellFinish)
            {
                this.OnSpellFinished();
                this.m_pendingSpellFinish = false;
            }
            if (this.m_pendingNoneStateChange)
            {
                this.OnStateFinished();
                this.m_pendingNoneStateChange = false;
            }
            this.CleanUp();
        }
    }

    private void FireMissileOnPath(Spell missile, int targetIndex)
    {
        Vector3[] vectorArray = this.GenerateMissilePath(missile);
        float num = UnityEngine.Random.Range(this.m_MissileInfo.m_PathDurationMin, this.m_MissileInfo.m_PathDurationMax);
        object[] args = new object[] { "missile", missile, "targetIndex", targetIndex };
        Hashtable hashtable = iTween.Hash(args);
        object[] objArray2 = new object[] { "path", vectorArray, "time", num, "easetype", this.m_MissileInfo.m_PathEaseType, "oncomplete", "OnMissileTargetReached", "oncompletetarget", base.gameObject, "oncompleteparams", hashtable, "orienttopath", this.m_MissileInfo.m_OrientToPath };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        if (this.m_MissileInfo.m_TargetJoint.Length > 0)
        {
            GameObject target = SceneUtils.FindChildBySubstring(missile.gameObject, this.m_MissileInfo.m_TargetJoint);
            if (target != null)
            {
                missile.transform.LookAt(missile.GetTarget().transform, this.m_MissileInfo.m_JointUpVector);
                vectorArray[2].y += this.m_MissileInfo.m_TargetHeightOffset;
                iTween.MoveTo(target, hashtable2);
                return;
            }
        }
        iTween.MoveTo(missile.gameObject, hashtable2);
    }

    private Vector3[] GenerateMissilePath(Spell missile)
    {
        Vector3[] path = new Vector3[3];
        path[0] = missile.transform.position;
        path[2] = missile.GetTarget().transform.position;
        path[1] = this.GenerateMissilePathCenterPoint(path);
        return path;
    }

    private unsafe Vector3 GenerateMissilePathCenterPoint(Vector3[] path)
    {
        int num4;
        float num5;
        ref Vector3 vectorRef6;
        Vector3 a = path[0];
        Vector3 b = path[2];
        float num = Vector3.Distance(a, b);
        Vector3 vector3 = b - a;
        vector3 = (Vector3) (vector3 / num);
        Vector3 vector4 = a + ((Vector3) (vector3 * (num * (this.m_MissileInfo.m_CenterOffsetPercent * 0.01f))));
        float num2 = num / this.m_MissileInfo.m_DistanceScaleFactor;
        if (this.m_MissileInfo.m_CenterPointHeightMin == this.m_MissileInfo.m_CenterPointHeightMax)
        {
            ref Vector3 vectorRef;
            num5 = vectorRef[num4];
            (vectorRef = (Vector3) &vector4)[num4 = 1] = num5 + (this.m_MissileInfo.m_CenterPointHeightMax * num2);
        }
        else
        {
            ref Vector3 vectorRef2;
            num5 = vectorRef2[num4];
            (vectorRef2 = (Vector3) &vector4)[num4 = 1] = num5 + UnityEngine.Random.Range((float) (this.m_MissileInfo.m_CenterPointHeightMin * num2), (float) (this.m_MissileInfo.m_CenterPointHeightMax * num2));
        }
        float num3 = 1f;
        if (a[2] > b[2])
        {
            num3 = -1f;
        }
        bool flag = false;
        if (UnityEngine.Random.value > 0.5f)
        {
            flag = true;
        }
        if ((this.m_MissileInfo.m_RightMin == 0f) && (this.m_MissileInfo.m_RightMax == 0f))
        {
            flag = false;
        }
        if ((this.m_MissileInfo.m_LeftMin == 0f) && (this.m_MissileInfo.m_LeftMax == 0f))
        {
            flag = true;
        }
        if (flag)
        {
            ref Vector3 vectorRef4;
            if ((this.m_MissileInfo.m_RightMin == this.m_MissileInfo.m_RightMax) || this.m_MissileInfo.m_DebugForceMax)
            {
                ref Vector3 vectorRef3;
                num5 = vectorRef3[num4];
                (vectorRef3 = (Vector3) &vector4)[num4 = 0] = num5 + ((this.m_MissileInfo.m_RightMax * num2) * num3);
                return vector4;
            }
            num5 = vectorRef4[num4];
            (vectorRef4 = (Vector3) &vector4)[num4 = 0] = num5 + (UnityEngine.Random.Range((float) (this.m_MissileInfo.m_RightMin * num2), (float) (this.m_MissileInfo.m_RightMax * num2)) * num3);
            return vector4;
        }
        if ((this.m_MissileInfo.m_LeftMin == this.m_MissileInfo.m_LeftMax) || this.m_MissileInfo.m_DebugForceMax)
        {
            ref Vector3 vectorRef5;
            num5 = vectorRef5[num4];
            (vectorRef5 = (Vector3) &vector4)[num4 = 0] = num5 - ((this.m_MissileInfo.m_LeftMax * num2) * num3);
            return vector4;
        }
        num5 = vectorRef6[num4];
        (vectorRef6 = (Vector3) &vector4)[num4 = 0] = num5 - (UnityEngine.Random.Range((float) (this.m_MissileInfo.m_LeftMin * num2), (float) (this.m_MissileInfo.m_LeftMax * num2)) * num3);
        return vector4;
    }

    private void GenerateRandomBoardVisualTargets()
    {
        ZonePlay play = SpellUtils.FindFriendlyPlayZone(this);
        ZonePlay play2 = SpellUtils.FindOpponentPlayZone(this);
        Bounds bounds = play.collider.bounds;
        Bounds bounds2 = play2.collider.bounds;
        Vector3 vector = Vector3.Min(bounds.min, bounds2.min);
        Vector3 vector2 = Vector3.Max(bounds.max, bounds2.max);
        Vector3 center = (Vector3) (0.5f * (vector2 + vector));
        Vector3 vector4 = vector2 - vector;
        Vector3 size = new Vector3(Mathf.Abs(vector4.x), Mathf.Abs(vector4.y), Mathf.Abs(vector4.z));
        Bounds bounds3 = new Bounds(center, size);
        this.GenerateRandomVisualTargets(bounds3);
    }

    private void GenerateRandomPlayZoneVisualTargets(ZonePlay zonePlay)
    {
        this.GenerateRandomVisualTargets(zonePlay.collider.bounds);
    }

    private void GenerateRandomVisualTargets(Bounds bounds)
    {
        int num = UnityEngine.Random.Range(this.m_TargetInfo.m_RandomTargetCountMin, this.m_TargetInfo.m_RandomTargetCountMax + 1);
        if (num != 0)
        {
            float x = bounds.min.x;
            float z = bounds.max.z;
            float min = bounds.min.z;
            float num5 = bounds.size.x / ((float) num);
            int[] boxUsageCounts = new int[num];
            int[] numArray2 = new int[num];
            for (int i = 0; i < num; i++)
            {
                boxUsageCounts[i] = 0;
                numArray2[i] = -1;
            }
            for (int j = 0; j < num; j++)
            {
                float num8 = UnityEngine.Random.Range((float) 0f, (float) 1f);
                int max = 0;
                for (int k = 0; k < num; k++)
                {
                    if (this.ComputeBoxPickChance(boxUsageCounts, k) >= num8)
                    {
                        numArray2[max++] = k;
                    }
                }
                int index = numArray2[UnityEngine.Random.Range(0, max)];
                boxUsageCounts[index]++;
                float num13 = x + (index * num5);
                float num14 = num13 + num5;
                Vector3 position = new Vector3 {
                    x = UnityEngine.Random.Range(num13, num14),
                    y = bounds.center.y,
                    z = UnityEngine.Random.Range(min, z)
                };
                this.GenerateVisualTarget(position, j, index);
            }
        }
    }

    private void GenerateVisualTarget(Vector3 position, int index, int boxIndex)
    {
        GameObject go = new GameObject {
            name = string.Format("{0} Target {1} (box {2})", this, index, boxIndex)
        };
        go.transform.position = position;
        go.AddComponent<SpellGeneratedTarget>();
        this.AddVisualTarget(go);
    }

    private GameObject GetPrimaryTarget()
    {
        return this.m_visualTargets[this.GetPrimaryTargetIndex()];
    }

    private int GetPrimaryTargetIndex()
    {
        return 0;
    }

    public override GameObject GetVisualTarget()
    {
        return ((this.m_visualTargets.Count != 0) ? this.m_visualTargets[0] : null);
    }

    public override Card GetVisualTargetCard()
    {
        GameObject visualTarget = this.GetVisualTarget();
        if (visualTarget == null)
        {
            return null;
        }
        return visualTarget.GetComponent<Card>();
    }

    private int GetVisualTargetCount()
    {
        if (this.IsMakingClones())
        {
            return this.m_visualTargets.Count;
        }
        return Mathf.Min(1, this.m_visualTargets.Count);
    }

    public override List<GameObject> GetVisualTargets()
    {
        return this.m_visualTargets;
    }

    private bool HasAreaEffect()
    {
        return (this.HasFriendlyAreaEffect() || this.HasOpponentAreaEffect());
    }

    private bool HasChain()
    {
        return (((this.m_ChainInfo != null) && this.m_ChainInfo.m_Enabled) && (this.m_ChainInfo.m_Prefab != null));
    }

    private bool HasFriendlyAreaEffect()
    {
        return (((this.m_FriendlyAreaEffectInfo != null) && this.m_FriendlyAreaEffectInfo.m_Enabled) && (this.m_FriendlyAreaEffectInfo.m_Prefab != null));
    }

    private bool HasImpact()
    {
        return (((this.m_ImpactInfo != null) && this.m_ImpactInfo.m_Enabled) && ((this.m_ImpactInfo.m_Prefab != null) || (this.m_ImpactInfo.m_DamageAmountImpacts.Length > 0)));
    }

    private bool HasMetaDataTargets()
    {
        return (this.m_targetToMetaDataMap.Count > 0);
    }

    private bool HasMissile()
    {
        return (((this.m_MissileInfo != null) && this.m_MissileInfo.m_Enabled) && (this.m_MissileInfo.m_Prefab != null));
    }

    private bool HasOpponentAreaEffect()
    {
        return (((this.m_OpponentAreaEffectInfo != null) && this.m_OpponentAreaEffectInfo.m_Enabled) && (this.m_OpponentAreaEffectInfo.m_Prefab != null));
    }

    private bool HasStart()
    {
        return (((this.m_StartInfo != null) && this.m_StartInfo.m_Enabled) && (this.m_StartInfo.m_Prefab != null));
    }

    private bool IsMakingClones()
    {
        return true;
    }

    public override bool IsVisualTarget(GameObject go)
    {
        return this.m_visualTargets.Contains(go);
    }

    protected override void OnAction(SpellStateType prevStateType)
    {
        this.m_settingUpAction = true;
        this.UpdateTargets();
        base.UpdatePosition();
        base.UpdateOrientation();
        this.m_currentTargetIndex = this.GetPrimaryTargetIndex();
        this.UpdatePendingStateChangeFlags(SpellStateType.ACTION);
        this.DoAction();
        base.OnAction(prevStateType);
        this.m_settingUpAction = false;
        this.FinishIfPossible();
    }

    private void OnActionStartSpellFinished(Spell spell, object userData)
    {
        spell.ActivateState(SpellStateType.DEATH);
    }

    protected override void OnBirth(SpellStateType prevStateType)
    {
        base.UpdatePosition();
        base.UpdateOrientation();
        this.m_currentTargetIndex = 0;
        if (this.HasStart())
        {
            this.SpawnStart();
            this.m_startSpell.ActivateState(SpellStateType.BIRTH);
        }
        base.OnBirth(prevStateType);
    }

    protected override void OnCancel(SpellStateType prevStateType)
    {
        this.UpdatePendingStateChangeFlags(SpellStateType.CANCEL);
        if ((this.m_startSpell != null) && (this.m_startSpell.GetActiveState() != SpellStateType.NONE))
        {
            this.m_startSpell.ActivateState(SpellStateType.CANCEL);
        }
        base.OnCancel(prevStateType);
        this.FinishIfPossible();
    }

    private void OnCanceledStartSpellFinished(Spell spell, object userData)
    {
        this.m_startSpell = null;
        this.FinishIfPossible();
    }

    private void OnCloneSpellFinished(Spell spell, object userData)
    {
        this.m_effectsPendingFinish--;
        this.FinishIfPossible();
    }

    private void OnCloneSpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            UnityEngine.Object.Destroy(spell.gameObject);
        }
    }

    public override void OnFsmStateStarted(FsmState state, SpellStateType stateType)
    {
        if (base.m_activeStateChange != stateType)
        {
            if ((stateType == SpellStateType.NONE) && this.AreEffectsActive())
            {
                this.m_pendingSpellFinish = true;
                this.m_pendingNoneStateChange = true;
            }
            else
            {
                base.OnFsmStateStarted(state, stateType);
            }
        }
    }

    private void OnMetaDataTasksComplete(PowerTaskList taskList, int startIndex, int count, object userData)
    {
        this.m_effectsPendingFinish--;
        this.FinishIfPossible();
    }

    private void OnMissileSpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (prevStateType == SpellStateType.BIRTH)
        {
            spell.RemoveStateFinishedCallback(new Spell.StateFinishedCallback(this.OnMissileSpellStateFinished), userData);
            int targetIndex = (int) userData;
            this.FireMissileOnPath(spell, targetIndex);
        }
    }

    private void OnMissileTargetReached(Hashtable args)
    {
        Spell spell = (Spell) args["missile"];
        int targetIndex = (int) args["targetIndex"];
        if (this.HasImpact())
        {
            this.SpawnImpact(targetIndex);
        }
        if (this.HasChain())
        {
            this.SpawnChain();
        }
        else if (this.m_MissileInfo.m_SpawnInSequence)
        {
            this.SpawnMissileInSequence();
        }
        spell.ActivateState(SpellStateType.DEATH);
    }

    public override void OnSpellFinished()
    {
        if (this.AreEffectsActive())
        {
            this.m_pendingSpellFinish = true;
        }
        else
        {
            base.OnSpellFinished();
        }
    }

    public override void OnStateFinished()
    {
        if ((base.GuessNextStateType() == SpellStateType.NONE) && this.AreEffectsActive())
        {
            this.m_pendingNoneStateChange = true;
        }
        else
        {
            base.OnStateFinished();
        }
    }

    public override void RemoveAllVisualTargets()
    {
        this.m_visualTargets.Clear();
    }

    public override bool RemoveVisualTarget(GameObject go)
    {
        return this.m_visualTargets.Remove(go);
    }

    private void SpawnAllImpacts()
    {
        for (int i = 0; i < this.GetVisualTargetCount(); i++)
        {
            this.SpawnImpact(i);
        }
    }

    private void SpawnAllMissiles()
    {
        for (int i = 0; i < this.GetVisualTargetCount(); i++)
        {
            this.SpawnMissile(i);
        }
        if (this.m_startSpell != null)
        {
            this.DoStartSpellAction();
        }
    }

    private void SpawnAreaEffect(SpellAreaEffectInfo info)
    {
        this.m_effectsPendingFinish++;
        base.StartCoroutine(this.WaitAndSpawnAreaEffect(info));
    }

    private void SpawnChain()
    {
        if (this.GetVisualTargetCount() > 1)
        {
            this.m_effectsPendingFinish++;
            base.StartCoroutine(this.WaitAndSpawnChain());
        }
    }

    private void SpawnChainMissile()
    {
        this.SpawnMissile(this.GetPrimaryTargetIndex());
        if (this.m_startSpell != null)
        {
            this.DoStartSpellAction();
        }
    }

    private void SpawnImpact(int targetIndex)
    {
        this.m_effectsPendingFinish++;
        base.StartCoroutine(this.WaitAndSpawnImpact(targetIndex));
    }

    private void SpawnMissile(int targetIndex)
    {
        this.m_effectsPendingFinish++;
        GameObject source = base.GetSource();
        GameObject go = this.m_visualTargets[targetIndex];
        Spell spell = this.CloneSpell(this.m_MissileInfo.m_Prefab);
        spell.SetSource(source);
        spell.AddTarget(go);
        spell.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnMissileSpellStateFinished), targetIndex);
        spell.ActivateState(SpellStateType.BIRTH);
        if (this.m_MissileInfo.m_UseSuperSpellLocation)
        {
            spell.SetPosition(base.transform.position);
        }
    }

    private void SpawnMissileInSequence()
    {
        if (this.m_currentTargetIndex < this.GetVisualTargetCount())
        {
            this.SpawnMissile(this.m_currentTargetIndex);
            this.m_currentTargetIndex++;
            if (this.m_startSpell != null)
            {
                if (this.m_StartInfo.m_DeathAfterAllMissilesFire)
                {
                    if (this.m_currentTargetIndex < this.GetVisualTargetCount())
                    {
                        if (this.m_startSpell.HasUsableState(SpellStateType.ACTION))
                        {
                            this.m_startSpell.ActivateState(SpellStateType.ACTION);
                        }
                    }
                    else
                    {
                        this.DoStartSpellAction();
                    }
                }
                else
                {
                    this.DoStartSpellAction();
                }
            }
        }
    }

    private void SpawnStart()
    {
        this.m_effectsPendingFinish++;
        this.m_startSpell = this.CloneSpell(this.m_StartInfo.m_Prefab);
        this.m_startSpell.SetSource(base.GetSource());
        this.m_startSpell.AddTargets(base.GetTargets());
        if (this.m_StartInfo.m_UseSuperSpellLocation)
        {
            this.m_startSpell.SetPosition(base.transform.position);
        }
    }

    private void UpdatePendingStateChangeFlags(SpellStateType stateType)
    {
        if (!base.HasStateContent(stateType))
        {
            this.m_pendingNoneStateChange = true;
            this.m_pendingSpellFinish = true;
        }
        else
        {
            this.m_pendingNoneStateChange = false;
            this.m_pendingSpellFinish = false;
        }
    }

    private void UpdateTargets()
    {
        switch (this.m_TargetInfo.m_Behavior)
        {
            case SpellTargetBehavior.FRIENDLY_PLAY_ZONE_CENTER:
            {
                ZonePlay play = SpellUtils.FindFriendlyPlayZone(this);
                this.AddVisualTarget(play.gameObject);
                break;
            }
            case SpellTargetBehavior.FRIENDLY_PLAY_ZONE_RANDOM:
            {
                ZonePlay zonePlay = SpellUtils.FindFriendlyPlayZone(this);
                this.GenerateRandomPlayZoneVisualTargets(zonePlay);
                break;
            }
            case SpellTargetBehavior.OPPONENT_PLAY_ZONE_CENTER:
            {
                ZonePlay play3 = SpellUtils.FindOpponentPlayZone(this);
                this.AddVisualTarget(play3.gameObject);
                break;
            }
            case SpellTargetBehavior.OPPONENT_PLAY_ZONE_RANDOM:
            {
                ZonePlay play4 = SpellUtils.FindOpponentPlayZone(this);
                this.GenerateRandomPlayZoneVisualTargets(play4);
                break;
            }
            case SpellTargetBehavior.BOARD_CENTER:
            {
                Board board = Board.Get();
                this.AddVisualTarget(board.FindBone("CenterPointBone").gameObject);
                break;
            }
            case SpellTargetBehavior.UNTARGETED:
                this.AddVisualTarget(base.GetSource());
                break;

            case SpellTargetBehavior.CHOSEN_TARGET_ONLY:
                this.AddChosenTargetAsVisualTarget();
                break;

            case SpellTargetBehavior.BOARD_RANDOM:
                this.GenerateRandomBoardVisualTargets();
                break;

            default:
                this.AddAllTargetsAsVisualTargets();
                break;
        }
    }

    [DebuggerHidden]
    private IEnumerator WaitAndSpawnAreaEffect(SpellAreaEffectInfo info)
    {
        return new <WaitAndSpawnAreaEffect>c__IteratorC7 { info = info, <$>info = info, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitAndSpawnChain()
    {
        return new <WaitAndSpawnChain>c__IteratorC6 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitAndSpawnImpact(int targetIndex)
    {
        return new <WaitAndSpawnImpact>c__IteratorC5 { targetIndex = targetIndex, <$>targetIndex = targetIndex, <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitForDelayThenDoAction()
    {
        return new <WaitForDelayThenDoAction>c__IteratorC4 { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <CompleteMetaDataTasks_FromTarget>c__IteratorC8 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal float <$>delaySec;
        internal int <$>visualTargetIndex;
        internal SuperSpell <>f__this;
        internal int <metaDataIndex>__1;
        internal int <targetIndex>__0;
        internal float delaySec;
        internal int visualTargetIndex;

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
                    if (this.<>f__this.m_visualToTargetIndexMap.TryGetValue(this.visualTargetIndex, out this.<targetIndex>__0))
                    {
                        if (this.<>f__this.m_targetToMetaDataMap.TryGetValue(this.<targetIndex>__0, out this.<metaDataIndex>__1))
                        {
                            this.<>f__this.m_effectsPendingFinish++;
                            this.$current = new WaitForSeconds(this.delaySec);
                            this.$PC = 1;
                            return true;
                        }
                        break;
                    }
                    break;

                case 1:
                    this.<>f__this.CompleteMetaDataTasks(this.<metaDataIndex>__1, new PowerTaskList.CompleteCallback(this.<>f__this.OnMetaDataTasksComplete));
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
    private sealed class <WaitAndSpawnAreaEffect>c__IteratorC7 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SpellAreaEffectInfo <$>info;
        internal SuperSpell <>f__this;
        internal Spell <areaEffect>__1;
        internal float <spawnDelaySec>__0;
        internal SpellAreaEffectInfo info;

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
                    this.<spawnDelaySec>__0 = UnityEngine.Random.Range(this.info.m_SpawnDelaySecMin, this.info.m_SpawnDelaySecMax);
                    this.$current = new WaitForSeconds(this.<spawnDelaySec>__0);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<areaEffect>__1 = this.<>f__this.CloneSpell(this.info.m_Prefab);
                    this.<areaEffect>__1.SetSource(this.<>f__this.GetSource());
                    this.<areaEffect>__1.AttachPowerTaskList(this.<>f__this.m_taskList);
                    if (this.info.m_UseSuperSpellLocation)
                    {
                        this.<areaEffect>__1.SetPosition(this.<>f__this.transform.position);
                    }
                    this.<areaEffect>__1.m_Facing = this.info.m_Facing;
                    this.<areaEffect>__1.m_FacingOptions = this.info.m_FacingOptions;
                    this.<areaEffect>__1.UpdateOrientation();
                    this.<areaEffect>__1.Activate();
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
    private sealed class <WaitAndSpawnChain>c__IteratorC6 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal List<GameObject>.Enumerator <$s_943>__3;
        internal SuperSpell <>f__this;
        internal Spell <chain>__1;
        internal GameObject <sourceObject>__2;
        internal float <spawnDelaySec>__0;
        internal GameObject <targetObject>__4;

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
                    this.<spawnDelaySec>__0 = UnityEngine.Random.Range(this.<>f__this.m_ChainInfo.m_SpawnDelayMin, this.<>f__this.m_ChainInfo.m_SpawnDelayMax);
                    this.$current = new WaitForSeconds(this.<spawnDelaySec>__0);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<chain>__1 = this.<>f__this.CloneSpell(this.<>f__this.m_ChainInfo.m_Prefab);
                    this.<sourceObject>__2 = this.<>f__this.GetPrimaryTarget();
                    this.<chain>__1.SetSource(this.<sourceObject>__2);
                    this.<$s_943>__3 = this.<>f__this.m_visualTargets.GetEnumerator();
                    try
                    {
                        while (this.<$s_943>__3.MoveNext())
                        {
                            this.<targetObject>__4 = this.<$s_943>__3.Current;
                            if (this.<targetObject>__4 != this.<sourceObject>__2)
                            {
                                this.<chain>__1.AddTarget(this.<targetObject>__4);
                            }
                        }
                    }
                    finally
                    {
                        this.<$s_943>__3.Dispose();
                    }
                    this.<chain>__1.ActivateState(SpellStateType.ACTION);
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
    private sealed class <WaitAndSpawnImpact>c__IteratorC5 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal int <$>targetIndex;
        internal SuperSpell <>f__this;
        internal float <delaySec>__3;
        internal Spell <impact>__5;
        internal Spell <impactPrefab>__4;
        internal Transform <parent>__6;
        internal GameObject <sourceObject>__1;
        internal float <spawnDelaySec>__0;
        internal GameObject <targetObject>__2;
        internal int targetIndex;

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
                    this.<spawnDelaySec>__0 = UnityEngine.Random.Range(this.<>f__this.m_ImpactInfo.m_SpawnDelaySecMin, this.<>f__this.m_ImpactInfo.m_SpawnDelaySecMax);
                    this.$current = new WaitForSeconds(this.<spawnDelaySec>__0);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<sourceObject>__1 = this.<>f__this.GetSource();
                    this.<targetObject>__2 = this.<>f__this.m_visualTargets[this.targetIndex];
                    this.<delaySec>__3 = UnityEngine.Random.Range(this.<>f__this.m_ImpactInfo.m_GameDelaySecMin, this.<>f__this.m_ImpactInfo.m_GameDelaySecMax);
                    this.<>f__this.StartCoroutine(this.<>f__this.CompleteMetaDataTasks_FromTarget(this.targetIndex, this.<delaySec>__3));
                    this.<impactPrefab>__4 = this.<>f__this.DetermineImpactPrefab(this.<targetObject>__2);
                    this.<impact>__5 = this.<>f__this.CloneSpell(this.<impactPrefab>__4);
                    this.<impact>__5.SetSource(this.<sourceObject>__1);
                    this.<impact>__5.AddTarget(this.<targetObject>__2);
                    if (!this.<>f__this.m_ImpactInfo.m_UseSuperSpellLocation)
                    {
                        this.<impact>__5.m_Location = this.<>f__this.m_ImpactInfo.m_Location;
                        if (this.<>f__this.m_ImpactInfo.m_SetParentToLocation)
                        {
                            this.<parent>__6 = SpellUtils.GetLocationTransform(this.<impact>__5);
                            if (this.<>f__this.IsMakingClones())
                            {
                                this.<impact>__5.transform.parent = this.<parent>__6;
                            }
                            this.<impact>__5.SetPosition(this.<parent>__6.position);
                        }
                        else
                        {
                            this.<impact>__5.UpdatePosition();
                        }
                        break;
                    }
                    this.<impact>__5.SetPosition(this.<>f__this.transform.position);
                    break;

                default:
                    goto Label_0213;
            }
            this.<impact>__5.UpdateOrientation();
            this.<impact>__5.Activate();
            this.$PC = -1;
        Label_0213:
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
    private sealed class <WaitForDelayThenDoAction>c__IteratorC4 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SuperSpell <>f__this;
        internal float <delaySec>__0;

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
                    this.<delaySec>__0 = UnityEngine.Random.Range(this.<>f__this.m_ActionInfo.m_StartDelayMin, this.<>f__this.m_ActionInfo.m_StartDelayMax);
                    this.$current = new WaitForSeconds(this.<delaySec>__0);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.m_effectsPendingFinish--;
                    this.<>f__this.DoActionNow();
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

