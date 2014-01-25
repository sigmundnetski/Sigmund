using HutongGames.PlayMaker.Actions;
using System;
using UnityEngine;

public class iTweenFSMEvents : MonoBehaviour
{
    public bool donotfinish;
    public bool islooping;
    public iTweenFsmAction itweenFSMAction;
    public int itweenID;
    public static int itweenIDCount;

    private void iTweenOnComplete(int aniTweenID)
    {
        if (this.itweenID == aniTweenID)
        {
            if (this.islooping)
            {
                if (!this.donotfinish)
                {
                    this.itweenFSMAction.Fsm.Event(this.itweenFSMAction.finishEvent);
                    this.itweenFSMAction.Finish();
                }
            }
            else
            {
                this.itweenFSMAction.Fsm.Event(this.itweenFSMAction.finishEvent);
                this.itweenFSMAction.Finish();
            }
        }
    }

    private void iTweenOnStart(int aniTweenID)
    {
        if (this.itweenID == aniTweenID)
        {
            this.itweenFSMAction.Fsm.Event(this.itweenFSMAction.startEvent);
        }
    }
}

