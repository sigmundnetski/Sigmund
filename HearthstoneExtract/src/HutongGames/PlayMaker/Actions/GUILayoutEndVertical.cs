namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("Close a group started with BeginVertical.")]
    public class GUILayoutEndVertical : FsmStateAction
    {
        public override void OnGUI()
        {
            GUILayout.EndVertical();
        }

        public override void Reset()
        {
        }
    }
}

