using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpellMoveToTarget : Spell
{
    [CompilerGenerated]
    private static Predicate<SpellPath> <>f__am$cacheB;
    [CompilerGenerated]
    private static Predicate<SpellPath> <>f__am$cacheC;
    [CompilerGenerated]
    private static Predicate<SpellPath> <>f__am$cacheD;
    public bool m_DisableContainerAfterAction;
    public iTween.EaseType m_EaseType = iTween.EaseType.easeInOutSine;
    public float m_MovementDurationSec = 1f;
    public bool m_OnlyMoveContainer;
    public bool m_OrientToPath;
    private Vector3[] m_pathNodes;
    public List<SpellPath> m_Paths;
    private bool m_sourceComputed;
    private SpellPath m_spellPath;
    private bool m_targetComputed;
    private bool m_waitingToAct = true;

    public override bool AddPowerTargets()
    {
        if (!base.CanAddPowerTargets())
        {
            return false;
        }
        return base.AddSinglePowerTarget();
    }

    public override void AddTarget(GameObject go)
    {
        if (base.GetTarget() != go)
        {
            this.m_targetComputed = false;
        }
        base.AddTarget(go);
    }

    private bool DeterminePath(Player sourcePlayer, Card sourceCard, Card targetCard)
    {
        if (this.m_pathNodes == null)
        {
            iTweenPath path;
            SpellPath path2;
            if ((this.m_Paths == null) || (this.m_Paths.Count == 0))
            {
                UnityEngine.Debug.LogError(string.Format("SpellMoveToTarget.DeterminePath() - no SpellPaths available", new object[0]));
                return false;
            }
            iTweenPath[] components = base.GetComponents<iTweenPath>();
            if ((components == null) || (components.Length == 0))
            {
                UnityEngine.Debug.LogError(string.Format("SpellMoveToTarget.DeterminePath() - no iTweenPaths available", new object[0]));
                return false;
            }
            if (!this.FindBestPath(sourcePlayer, sourceCard, components, out path, out path2) && !this.FindFallbackPath(components, out path, out path2))
            {
                return false;
            }
            this.m_spellPath = path2;
            this.m_pathNodes = path.nodes.ToArray();
        }
        this.FixupPathNodes(sourcePlayer, sourceCard, targetCard);
        this.SetStartPosition();
        return true;
    }

    private void DoActionFallback(SpellStateType prevStateType)
    {
        base.OnAction(prevStateType);
        this.ChangeState(SpellStateType.DEATH);
    }

    private bool FindBestPath(Player sourcePlayer, Card sourceCard, iTweenPath[] pathComponents, out iTweenPath tweenPath, out SpellPath spellPath)
    {
        tweenPath = null;
        spellPath = null;
        if (sourcePlayer == null)
        {
            return false;
        }
        if (sourcePlayer.GetSide() == Player.Side.FRIENDLY)
        {
            if (<>f__am$cacheB == null)
            {
                <>f__am$cacheB = currSpellPath => currSpellPath.m_Type == SpellPathType.FRIENDLY;
            }
            Predicate<SpellPath> predicate = <>f__am$cacheB;
            return this.FindPath(pathComponents, out tweenPath, out spellPath, predicate);
        }
        if (sourcePlayer.GetSide() != Player.Side.OPPOSING)
        {
            return false;
        }
        if (<>f__am$cacheC == null)
        {
            <>f__am$cacheC = currSpellPath => currSpellPath.m_Type == SpellPathType.OPPOSING;
        }
        Predicate<SpellPath> match = <>f__am$cacheC;
        return this.FindPath(pathComponents, out tweenPath, out spellPath, match);
    }

    private bool FindFallbackPath(iTweenPath[] pathComponents, out iTweenPath tweenPath, out SpellPath spellPath)
    {
        if (<>f__am$cacheD == null)
        {
            <>f__am$cacheD = currSpellPath => currSpellPath != null;
        }
        Predicate<SpellPath> match = <>f__am$cacheD;
        return this.FindPath(pathComponents, out tweenPath, out spellPath, match);
    }

    private bool FindPath(iTweenPath[] pathComponents, out iTweenPath tweenPath, out SpellPath spellPath, Predicate<SpellPath> match)
    {
        <FindPath>c__AnonStorey146 storey = new <FindPath>c__AnonStorey146();
        tweenPath = null;
        spellPath = null;
        SpellPath path = this.m_Paths.Find(match);
        if (path == null)
        {
            return false;
        }
        storey.desiredSpellPathName = path.m_PathName.ToLower().Trim();
        iTweenPath path2 = Array.Find<iTweenPath>(pathComponents, new Predicate<iTweenPath>(storey.<>m__5C));
        if (path2 == null)
        {
            return false;
        }
        if ((path2.nodes == null) || (path2.nodes.Count == 0))
        {
            return false;
        }
        tweenPath = path2;
        spellPath = path;
        return true;
    }

    private void FixupPathNodes(Player sourcePlayer, Card sourceCard, Card targetCard)
    {
        if (!this.m_sourceComputed)
        {
            this.m_pathNodes[0] = base.transform.position + this.m_spellPath.m_FirstNodeOffset;
            this.m_sourceComputed = true;
        }
        if (!this.m_targetComputed && (targetCard != null))
        {
            this.m_pathNodes[this.m_pathNodes.Length - 1] = targetCard.transform.position + this.m_spellPath.m_LastNodeOffset;
            float f = targetCard.transform.position.x - base.transform.position.x;
            float objA = f / Mathf.Abs(f);
            for (int i = 1; i < (this.m_pathNodes.Length - 1); i++)
            {
                Vector3 vector = this.m_pathNodes[i];
                float num4 = vector.x - base.transform.position.x;
                float objB = num4 / Mathf.Sqrt(num4 * num4);
                if (object.Equals(objA, objB))
                {
                    this.m_pathNodes[i].x = base.transform.position.x - num4;
                }
            }
            this.m_targetComputed = true;
        }
    }

    protected override void OnAction(SpellStateType prevStateType)
    {
        base.OnAction(prevStateType);
        Card sourceCard = base.GetSourceCard();
        if (sourceCard == null)
        {
            UnityEngine.Debug.LogError(string.Format("SpellMoveToTarget.OnAction() - no source card", new object[0]));
            this.DoActionFallback(prevStateType);
        }
        else
        {
            Card targetCard = base.GetTargetCard();
            if (targetCard == null)
            {
                UnityEngine.Debug.LogError(string.Format("SpellMoveToTarget.OnAction() - no target card", new object[0]));
                this.DoActionFallback(prevStateType);
            }
            else
            {
                Player controller = sourceCard.GetEntity().GetController();
                if (!this.DeterminePath(controller, sourceCard, targetCard))
                {
                    UnityEngine.Debug.LogError(string.Format("SpellMoveToTarget.DoAction() - no paths available, going to DEATH state", new object[0]));
                    this.DoActionFallback(prevStateType);
                }
                else
                {
                    base.StartCoroutine(this.WaitThenDoAction(prevStateType));
                }
            }
        }
    }

    protected override void OnBirth(SpellStateType prevStateType)
    {
        base.OnBirth(prevStateType);
        this.ResetPath();
        this.m_waitingToAct = true;
        Card sourceCard = base.GetSourceCard();
        if (sourceCard == null)
        {
            UnityEngine.Debug.LogError(string.Format("{0}.OnBirth() - sourceCard is null", this));
            base.OnBirth(prevStateType);
        }
        else
        {
            Player controller = sourceCard.GetEntity().GetController();
            if (!this.DeterminePath(controller, sourceCard, null))
            {
                UnityEngine.Debug.LogError(string.Format("{0}.OnBirth() - no paths available", this));
                base.OnBirth(prevStateType);
            }
        }
    }

    private void OnMoveToTargetComplete()
    {
        if (this.m_DisableContainerAfterAction)
        {
            base.ActivateObjectContainer(false);
        }
        this.ChangeState(SpellStateType.DEATH);
    }

    public override void RemoveAllTargets()
    {
        bool flag = base.m_targets.Count > 0;
        base.RemoveAllTargets();
        if (flag)
        {
            this.m_targetComputed = false;
        }
    }

    public override void RemoveSource()
    {
        base.RemoveSource();
        this.m_sourceComputed = false;
    }

    public override bool RemoveTarget(GameObject go)
    {
        GameObject target = base.GetTarget();
        if (!base.RemoveTarget(go))
        {
            return false;
        }
        if (target == go)
        {
            this.m_targetComputed = false;
        }
        return true;
    }

    private void ResetPath()
    {
        this.m_spellPath = null;
        this.m_pathNodes = null;
        this.m_sourceComputed = false;
        this.m_targetComputed = false;
    }

    public override void SetSource(GameObject go)
    {
        if (base.GetSource() != go)
        {
            this.m_sourceComputed = false;
        }
        base.SetSource(go);
    }

    private void SetStartPosition()
    {
        base.transform.position = this.m_pathNodes[0];
        if (this.m_OnlyMoveContainer)
        {
            base.m_ObjectContainer.transform.position = base.transform.position;
        }
    }

    private void StopWaitingToAct()
    {
        this.m_waitingToAct = false;
    }

    [DebuggerHidden]
    protected IEnumerator WaitThenDoAction(SpellStateType prevStateType)
    {
        return new <WaitThenDoAction>c__IteratorE5 { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <FindPath>c__AnonStorey146
    {
        internal string desiredSpellPathName;

        internal bool <>m__5C(iTweenPath currTweenPath)
        {
            return (currTweenPath.pathName.ToLower().Trim() == this.desiredSpellPathName);
        }
    }

    [CompilerGenerated]
    private sealed class <WaitThenDoAction>c__IteratorE5 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SpellMoveToTarget <>f__this;
        internal Hashtable <argTable>__0;
        internal GameObject <go>__1;

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
                {
                    if (this.<>f__this.m_waitingToAct)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    object[] args = new object[] { "path", this.<>f__this.m_pathNodes, "time", this.<>f__this.m_MovementDurationSec, "easetype", this.<>f__this.m_EaseType, "oncomplete", "OnMoveToTargetComplete", "oncompletetarget", this.<>f__this.gameObject, "orienttopath", this.<>f__this.m_OrientToPath };
                    this.<argTable>__0 = iTween.Hash(args);
                    this.<go>__1 = !this.<>f__this.m_OnlyMoveContainer ? this.<>f__this.gameObject : this.<>f__this.m_ObjectContainer;
                    iTween.MoveTo(this.<go>__1, this.<argTable>__0);
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
}

