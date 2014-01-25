namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GUILayout), Tooltip("GUILayout Toolbar. NOTE: Arrays must be the same length as NumButtons or empty.")]
    public class GUILayoutToolbar : GUILayoutAction
    {
        public FsmEvent[] buttonEventsArray;
        private GUIContent[] contents;
        public FsmTexture[] imagesArray;
        public FsmInt numButtons;
        [UIHint(UIHint.Variable)]
        public FsmInt selectedButton;
        public FsmString style;
        public FsmString[] textsArray;
        public FsmString[] tooltipsArray;

        public override string ErrorCheck()
        {
            string str = string.Empty;
            if ((this.imagesArray.Length > 0) && (this.imagesArray.Length != this.numButtons.Value))
            {
                str = str + "Images array doesn't match NumButtons.\n";
            }
            if ((this.textsArray.Length > 0) && (this.textsArray.Length != this.numButtons.Value))
            {
                str = str + "Texts array doesn't match NumButtons.\n";
            }
            if ((this.tooltipsArray.Length > 0) && (this.tooltipsArray.Length != this.numButtons.Value))
            {
                str = str + "Tooltips array doesn't match NumButtons.\n";
            }
            return str;
        }

        public override void OnEnter()
        {
            string str = this.ErrorCheck();
            if (!string.IsNullOrEmpty(str))
            {
                this.LogError(str);
                base.Finish();
            }
        }

        public override void OnGUI()
        {
            bool changed = GUI.changed;
            GUI.changed = false;
            this.selectedButton.Value = GUILayout.Toolbar(this.selectedButton.Value, this.Contents, this.style.Value, base.LayoutOptions);
            if (GUI.changed)
            {
                if (this.selectedButton.Value < this.buttonEventsArray.Length)
                {
                    base.Fsm.Event(this.buttonEventsArray[this.selectedButton.Value]);
                    GUIUtility.ExitGUI();
                }
            }
            else
            {
                GUI.changed = changed;
            }
        }

        public override void Reset()
        {
            base.Reset();
            this.numButtons = 0;
            this.selectedButton = null;
            this.buttonEventsArray = new FsmEvent[0];
            this.imagesArray = new FsmTexture[0];
            this.tooltipsArray = new FsmString[0];
            this.style = "Button";
        }

        public GUIContent[] Contents
        {
            get
            {
                if (this.contents == null)
                {
                    this.contents = new GUIContent[this.numButtons.Value];
                    for (int i = 0; i < this.numButtons.Value; i++)
                    {
                        this.contents[i] = new GUIContent();
                    }
                    for (int j = 0; j < this.imagesArray.Length; j++)
                    {
                        this.contents[j].image = this.imagesArray[j].Value;
                    }
                    for (int k = 0; k < this.textsArray.Length; k++)
                    {
                        this.contents[k].text = this.textsArray[k].Value;
                    }
                    for (int m = 0; m < this.tooltipsArray.Length; m++)
                    {
                        this.contents[m].tooltip = this.tooltipsArray[m].Value;
                    }
                }
                return this.contents;
            }
        }
    }
}

