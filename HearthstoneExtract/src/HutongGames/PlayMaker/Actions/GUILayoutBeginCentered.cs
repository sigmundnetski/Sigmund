namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("Begin a centered GUILayout block. The block is centered inside a parent GUILayout Area. So to place the block in the center of the screen, first use a GULayout Area the size of the whole screen (the default setting). NOTE: Block must end with a corresponding GUILayoutEndCentered.")]
    public class GUILayoutBeginCentered : FsmStateAction
    {
        public override void OnGUI()
        {
            GUILayout.BeginVertical(new GUILayoutOption[0]);
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal(new GUILayoutOption[0]);
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical(new GUILayoutOption[0]);
        }

        public override void Reset()
        {
        }
    }
}

