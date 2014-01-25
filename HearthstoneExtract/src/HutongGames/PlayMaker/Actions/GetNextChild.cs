namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Each time this action is called it gets the next child of a GameObject. This lets you quickly loop through all the children of an object to perform actions on them. NOTE: To find a specific child use Find Child.")]
    public class GetNextChild : FsmStateAction
    {
        [Tooltip("Event to send when there are no more children.")]
        public FsmEvent finishedEvent;
        [Tooltip("The parent GameObject. Note, if GameObject changes, this action will reset and start again at the first child."), RequiredField]
        public FsmOwnerDefault gameObject;
        private GameObject go;
        [Tooltip("Event to send to get the next child.")]
        public FsmEvent loopEvent;
        private int nextChildIndex;
        [RequiredField, Tooltip("Store the next child in a GameObject variable."), UIHint(UIHint.Variable)]
        public FsmGameObject storeNextChild;

        private void DoGetNextChild(GameObject parent)
        {
            if (parent != null)
            {
                if (this.go != parent)
                {
                    this.go = parent;
                    this.nextChildIndex = 0;
                }
                if (this.nextChildIndex >= this.go.transform.childCount)
                {
                    this.nextChildIndex = 0;
                    base.Fsm.Event(this.finishedEvent);
                }
                else
                {
                    this.storeNextChild.Value = parent.transform.GetChild(this.nextChildIndex).gameObject;
                    if (this.nextChildIndex >= this.go.transform.childCount)
                    {
                        this.nextChildIndex = 0;
                        base.Fsm.Event(this.finishedEvent);
                    }
                    else
                    {
                        this.nextChildIndex++;
                        if (this.loopEvent != null)
                        {
                            base.Fsm.Event(this.loopEvent);
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoGetNextChild(base.Fsm.GetOwnerDefaultTarget(this.gameObject));
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.storeNextChild = null;
            this.loopEvent = null;
            this.finishedEvent = null;
        }
    }
}

