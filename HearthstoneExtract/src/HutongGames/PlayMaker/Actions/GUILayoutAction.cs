namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("GUILayout base action - don't use!")]
    public abstract class GUILayoutAction : FsmStateAction
    {
        public LayoutOption[] layoutOptions;
        private GUILayoutOption[] options;

        protected GUILayoutAction()
        {
        }

        public override void Reset()
        {
            this.layoutOptions = new LayoutOption[0];
        }

        public GUILayoutOption[] LayoutOptions
        {
            get
            {
                if (this.options == null)
                {
                    this.options = new GUILayoutOption[this.layoutOptions.Length];
                    for (int i = 0; i < this.layoutOptions.Length; i++)
                    {
                        this.options[i] = this.layoutOptions[i].GetGUILayoutOption();
                    }
                }
                return this.options;
            }
        }
    }
}

