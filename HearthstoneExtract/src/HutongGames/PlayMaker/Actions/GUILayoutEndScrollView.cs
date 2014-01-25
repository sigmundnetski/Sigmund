namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("Close a group started with GUILayout Begin ScrollView.")]
    public class GUILayoutEndScrollView : FsmStateAction
    {
        public override void OnGUI()
        {
            GUILayout.EndScrollView();
        }
    }
}

