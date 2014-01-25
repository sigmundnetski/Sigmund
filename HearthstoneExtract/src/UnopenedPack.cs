using System;
using UnityEngine;

public class UnopenedPack : PegUIElement
{
    public Spell m_AlertEvent;
    private NetCache.BoosterStack m_boosterStack;
    private UnopenedPack m_creatorPack;
    private UnopenedPack m_draggedPack;
    public DragRotatorInfo m_DragRotatorInfo;
    public Spell m_DragStartEvent;
    public Spell m_DragStopEvent;
    public UnopenedPackStack m_MultipleStack;
    public UnopenedPackStack m_SingleStack;

    public UnopenedPack()
    {
        DragRotatorInfo info = new DragRotatorInfo();
        DragRotatorAxisInfo info2 = new DragRotatorAxisInfo {
            m_ForceMultiplier = 3f,
            m_MinDegrees = -55f,
            m_MaxDegrees = 55f,
            m_RestSeconds = 2f
        };
        info.m_PitchInfo = info2;
        info2 = new DragRotatorAxisInfo {
            m_ForceMultiplier = 4.5f,
            m_MinDegrees = -60f,
            m_MaxDegrees = 60f,
            m_RestSeconds = 2f
        };
        info.m_RollInfo = info2;
        this.m_DragRotatorInfo = info;
        NetCache.BoosterStack stack = new NetCache.BoosterStack {
            Type = BoosterType.UNKNOWN,
            Count = 0
        };
        this.m_boosterStack = stack;
    }

    public UnopenedPack AcquireDraggedPack()
    {
        if (this.m_draggedPack == null)
        {
            this.m_draggedPack = (UnopenedPack) UnityEngine.Object.Instantiate(this, base.transform.position, base.transform.rotation);
            this.m_draggedPack.transform.parent = base.transform.parent;
            this.m_draggedPack.m_creatorPack = this;
            this.m_draggedPack.gameObject.AddComponent<DragRotator>().SetInfo(this.m_DragRotatorInfo);
            this.m_draggedPack.m_DragStartEvent.Activate();
        }
        return this.m_draggedPack;
    }

    public void AddBooster()
    {
        this.AddBoosters(1);
    }

    public void AddBoosters(int numNewBoosters)
    {
        this.m_boosterStack.Count += numNewBoosters;
        this.UpdateState();
    }

    protected override void Awake()
    {
        base.Awake();
        this.UpdateState();
    }

    public NetCache.BoosterStack GetBoosterStack()
    {
        return this.m_boosterStack;
    }

    public UnopenedPack GetCreatorPack()
    {
        return this.m_creatorPack;
    }

    public UnopenedPack GetDraggedPack()
    {
        return this.m_draggedPack;
    }

    private void OnDragStopSpellStateFinished(Spell spell, SpellStateType prevStateType, object userData)
    {
        if (spell.GetActiveState() == SpellStateType.NONE)
        {
            UnopenedPack pack = (UnopenedPack) userData;
            UnityEngine.Object.Destroy(pack.gameObject);
        }
    }

    public void PlayAlert()
    {
        this.m_AlertEvent.ActivateState(SpellStateType.BIRTH);
    }

    public void ReleaseDraggedPack()
    {
        if (this.m_draggedPack != null)
        {
            UnopenedPack draggedPack = this.m_draggedPack;
            this.m_draggedPack = null;
            draggedPack.m_DragStopEvent.AddStateFinishedCallback(new Spell.StateFinishedCallback(this.OnDragStopSpellStateFinished), draggedPack);
            draggedPack.m_DragStopEvent.Activate();
            this.UpdateState();
        }
    }

    public void RemoveBooster()
    {
        this.m_boosterStack.Count--;
        if (this.m_boosterStack.Count < 0)
        {
            Debug.LogWarning("UnopenedPack.RemoveBooster(): Removed a booster pack from a stack with no boosters");
            this.m_boosterStack.Count = 0;
        }
        this.UpdateState();
    }

    public void SetBoosterStack(NetCache.BoosterStack boosterStack)
    {
        this.m_boosterStack = boosterStack;
        this.UpdateState();
    }

    public void StopAlert()
    {
        this.m_AlertEvent.ActivateState(SpellStateType.DEATH);
    }

    private void UpdateStack()
    {
        SceneUtils.EnableRenderers(this.m_SingleStack.m_RootObject, false);
        SceneUtils.EnableRenderers(this.m_MultipleStack.m_RootObject, false);
        if (this.m_boosterStack.Count < 2)
        {
            SceneUtils.EnableRenderers(this.m_SingleStack.m_RootObject, true);
        }
        else
        {
            SceneUtils.EnableRenderers(this.m_MultipleStack.m_RootObject, true);
            this.m_MultipleStack.m_AmountText.text = this.m_boosterStack.Count.ToString();
        }
    }

    private void UpdateState()
    {
        if (this.m_boosterStack.Count < 1)
        {
            SceneUtils.EnableRenderers(base.gameObject, false);
        }
        else
        {
            this.UpdateStack();
        }
    }
}

