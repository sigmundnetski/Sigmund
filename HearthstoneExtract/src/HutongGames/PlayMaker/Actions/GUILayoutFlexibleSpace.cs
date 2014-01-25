namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Inserts a flexible space element."), ActionCategory(ActionCategory.GUILayout)]
    public class GUILayoutFlexibleSpace : FsmStateAction
    {
        public override void OnGUI()
        {
            GUILayout.FlexibleSpace();
        }

        public override void Reset()
        {
        }
    }
}

