using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpellMoveToTargetAuto : Spell
{
    public float CenterOffsetPercent = 50f;
    public float CenterPointHeightMax;
    public float CenterPointHeightMin;
    public bool DebugForceMax;
    public float DistanceScaleFactor = 8f;
    public float LeftMax;
    public float LeftMin;
    public bool m_DisableContainerAfterAction;
    public iTween.EaseType m_EaseType = iTween.EaseType.linear;
    public float m_MovementDurationSec = 0.5f;
    public bool m_OnlyMoveContainer;
    public bool m_OrientToPath;
    private Vector3[] m_pathNodes;
    private bool m_sourceComputed;
    private bool m_targetComputed;
    private bool m_waitingToAct = true;
    public float RightMax;
    public float RightMin;

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
        this.FixupPathNodes(sourcePlayer, sourceCard, targetCard);
        this.SetStartPosition();
        return true;
    }

    private void DoActionFallback(SpellStateType prevStateType)
    {
        base.OnAction(prevStateType);
        this.ChangeState(SpellStateType.DEATH);
    }

    private void FixupPathNodes(Player sourcePlayer, Card sourceCard, Card targetCard)
    {
        if (!this.m_sourceComputed)
        {
            this.m_pathNodes[0] = base.transform.position;
            this.m_sourceComputed = true;
        }
        if (!this.m_targetComputed && (targetCard != null))
        {
            this.m_pathNodes[this.m_pathNodes.Length - 1] = targetCard.transform.position;
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
        this.MoveCenterPoint();
    }

    private unsafe void MoveCenterPoint()
    {
        if (this.m_pathNodes.Length >= 3)
        {
            int num4;
            float num5;
            Vector3 a = this.m_pathNodes[0];
            Vector3 b = this.m_pathNodes[this.m_pathNodes.Length - 1];
            float num = Vector3.Distance(a, b);
            Vector3 vector3 = b - a;
            vector3 = (Vector3) (vector3 / num);
            Vector3 vector4 = a + ((Vector3) (vector3 * (num * (this.CenterOffsetPercent * 0.01f))));
            float num2 = num / this.DistanceScaleFactor;
            if (this.CenterPointHeightMin == this.CenterPointHeightMax)
            {
                ref Vector3 vectorRef;
                num5 = vectorRef[num4];
                (vectorRef = (Vector3) &vector4)[num4 = 1] = num5 + (this.CenterPointHeightMax * num2);
            }
            else
            {
                ref Vector3 vectorRef2;
                num5 = vectorRef2[num4];
                (vectorRef2 = (Vector3) &vector4)[num4 = 1] = num5 + UnityEngine.Random.Range((float) (this.CenterPointHeightMin * num2), (float) (this.CenterPointHeightMax * num2));
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
            if ((this.RightMin == 0f) && (this.RightMax == 0f))
            {
                flag = false;
            }
            if ((this.LeftMin == 0f) && (this.LeftMax == 0f))
            {
                flag = true;
            }
            if (flag)
            {
                if ((this.RightMin == this.RightMax) || this.DebugForceMax)
                {
                    ref Vector3 vectorRef3;
                    num5 = vectorRef3[num4];
                    (vectorRef3 = (Vector3) &vector4)[num4 = 0] = num5 + ((this.RightMax * num2) * num3);
                }
                else
                {
                    ref Vector3 vectorRef4;
                    num5 = vectorRef4[num4];
                    (vectorRef4 = (Vector3) &vector4)[num4 = 0] = num5 + (UnityEngine.Random.Range((float) (this.RightMin * num2), (float) (this.RightMax * num2)) * num3);
                }
            }
            else if ((this.LeftMin == this.LeftMax) || this.DebugForceMax)
            {
                ref Vector3 vectorRef5;
                num5 = vectorRef5[num4];
                (vectorRef5 = (Vector3) &vector4)[num4 = 0] = num5 - ((this.LeftMax * num2) * num3);
            }
            else
            {
                ref Vector3 vectorRef6;
                num5 = vectorRef6[num4];
                (vectorRef6 = (Vector3) &vector4)[num4 = 0] = num5 - (UnityEngine.Random.Range((float) (this.LeftMin * num2), (float) (this.LeftMax * num2)) * num3);
            }
            this.m_pathNodes[1] = vector4;
        }
    }

    protected override void OnAction(SpellStateType prevStateType)
    {
        base.OnAction(prevStateType);
        if (this.m_pathNodes == null)
        {
            this.ResetPath();
        }
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
        this.m_pathNodes = new Vector3[] { Vector3.zero, Vector3.zero, Vector3.zero };
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
        return new <WaitThenDoAction>c__IteratorE6 { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenDoAction>c__IteratorE6 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal SpellMoveToTargetAuto <>f__this;
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

