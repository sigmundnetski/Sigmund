namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Raycast from camera and send events. Mouse Down can have a rendom chance to send event"), ActionCategory("Pegasus")]
    public class MousePickRandomAction : FsmStateAction
    {
        [Tooltip("Click Count")]
        public FsmInt ClickCount = 0;
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        [CheckForComponent(typeof(Collider))]
        public FsmOwnerDefault GameObject;
        [Tooltip("Invert the layer mask")]
        public FsmBool invertMask;
        [UIHint(UIHint.Layer), Tooltip("Pick Layers")]
        public FsmInt[] layerMask;
        private bool m_opened = true;
        private int m_RandomValue;
        [Tooltip("Mouse Down event. Random Gate is closed (false)")]
        public FsmEvent mouseDownGateClosed;
        [Tooltip("Mouse Down event. Random Gate open (true)")]
        public FsmEvent mouseDownGateOpen;
        [Tooltip("Mouse Off event")]
        public FsmEvent mouseOff;
        [Tooltip("Mouse Over event")]
        public FsmEvent mouseOver;
        [Tooltip("Mouse Up event")]
        public FsmEvent mouseUp;
        [Tooltip("Max number of clicks before random gate open")]
        public FsmInt RandomGateClicksMax = 0;
        [Tooltip("Min number of clicks before random gate open")]
        public FsmInt RandomGateClicksMin = 0;
        [Tooltip("Ray to cast distance")]
        public FsmFloat rayDistance = 50f;
        [Tooltip("Resets count to 0 once triggered")]
        public FsmBool ResetOnOpen = 0;

        private void DoMousePickEvent()
        {
            UnityEngine.GameObject obj2 = (this.GameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? this.GameObject.GameObject.Value : base.Owner;
            UniversalInputManager manager = UniversalInputManager.Get();
            if (manager != null)
            {
                if (manager.InputIsOver(obj2.gameObject))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        this.ClickCount.Value++;
                        if (this.ClickCount.Value >= this.m_RandomValue)
                        {
                            this.m_opened = true;
                            if (this.ResetOnOpen.Value)
                            {
                                this.ClickCount.Value = 0;
                            }
                            if (this.mouseDownGateOpen != null)
                            {
                                base.Fsm.Event(this.mouseDownGateOpen);
                            }
                        }
                        else if (this.mouseDownGateClosed != null)
                        {
                            base.Fsm.Event(this.mouseDownGateClosed);
                        }
                    }
                    if (this.mouseOver != null)
                    {
                        base.Fsm.Event(this.mouseOver);
                    }
                    if ((this.mouseUp != null) && Input.GetMouseButtonUp(0))
                    {
                        base.Fsm.Event(this.mouseUp);
                    }
                }
                else if (this.mouseOff != null)
                {
                    base.Fsm.Event(this.mouseOff);
                }
            }
        }

        public override string ErrorCheck()
        {
            return string.Empty;
        }

        public override void OnEnter()
        {
            if (this.RandomGateClicksMin.Value > this.RandomGateClicksMax.Value)
            {
                this.RandomGateClicksMin = this.RandomGateClicksMax;
            }
            if (this.m_opened)
            {
                this.m_RandomValue = UnityEngine.Random.Range(this.RandomGateClicksMin.Value, this.RandomGateClicksMax.Value);
                this.m_opened = false;
            }
            this.DoMousePickEvent();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoMousePickEvent();
        }

        public override void Reset()
        {
            this.GameObject = null;
            this.rayDistance = 50f;
            this.RandomGateClicksMin = 0;
            this.RandomGateClicksMax = 0;
            this.ResetOnOpen = 0;
            this.mouseDownGateOpen = null;
            this.mouseDownGateClosed = null;
            this.mouseOver = null;
            this.mouseUp = null;
            this.mouseOff = null;
            this.layerMask = new FsmInt[0];
            this.invertMask = 0;
            this.everyFrame = true;
            this.ClickCount = 0;
        }
    }
}

