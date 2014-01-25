namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("Inserts a space in the current layout group.")]
    public class GUILayoutSpace : FsmStateAction
    {
        public FsmFloat space;

        public override void OnGUI()
        {
            GUILayout.Space(this.space.Value);
        }

        public override void Reset()
        {
            this.space = 10f;
        }
    }
}

