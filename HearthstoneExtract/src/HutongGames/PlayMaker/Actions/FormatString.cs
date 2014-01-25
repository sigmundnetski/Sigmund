namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Replaces each format item in a specified string with the text equivalent of variable's value. Stores the result in a string variable."), ActionCategory(ActionCategory.String)]
    public class FormatString : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField, Tooltip("E.g. Hello {0} and {1}\nWith 2 variables that replace {0} and {1}\nSee C# string.Format docs.")]
        public FsmString format;
        private object[] objectArray;
        [Tooltip("Store the formatted result in a string variable."), UIHint(UIHint.Variable)]
        public FsmString storeResult;
        [Tooltip("Variables to use for each formatting item.")]
        public FsmVar[] variables;

        private void DoFormatString()
        {
            for (int i = 0; i < this.variables.Length; i++)
            {
                this.objectArray[i] = this.variables[i];
            }
            try
            {
                this.storeResult.Value = string.Format(this.format.Value, this.objectArray);
            }
            catch (FormatException exception)
            {
                this.LogError(exception.Message);
                base.Finish();
            }
        }

        public override void OnEnter()
        {
            this.objectArray = new object[this.variables.Length];
            this.DoFormatString();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoFormatString();
        }

        public override void Reset()
        {
            this.format = null;
            this.variables = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}

