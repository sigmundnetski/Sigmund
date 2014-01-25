namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Sets the sorting depth of subsequent GUI elements."), ActionCategory(ActionCategory.GUI)]
    public class SetGUIDepth : FsmStateAction
    {
        [RequiredField]
        public FsmInt depth;

        public override void Awake()
        {
            base.Fsm.HandleOnGUI = true;
        }

        public override void OnGUI()
        {
            GUI.depth = this.depth.Value;
        }

        public override void Reset()
        {
            this.depth = 0;
        }
    }
}

