namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("End a centered GUILayout block started with GUILayoutBeginCentered."), ActionCategory(ActionCategory.GUILayout)]
    public class GUILayoutEndCentered : FsmStateAction
    {
        public override void OnGUI()
        {
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
        }

        public override void Reset()
        {
        }
    }
}

