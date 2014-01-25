namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Builds a String from other Strings."), ActionCategory(ActionCategory.String)]
    public class BuildString : FsmStateAction
    {
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame;
        private string result;
        [Tooltip("Separator to insert between each String. E.g. space character.")]
        public FsmString separator;
        [RequiredField, UIHint(UIHint.Variable), Tooltip("Store the final String in a variable.")]
        public FsmString storeResult;
        [RequiredField, Tooltip("Array of Strings to combine.")]
        public FsmString[] stringParts;

        private void DoBuildString()
        {
            if (this.storeResult != null)
            {
                this.result = string.Empty;
                foreach (FsmString str in this.stringParts)
                {
                    this.result = this.result + str;
                    this.result = this.result + this.separator.Value;
                }
                this.storeResult.Value = this.result;
            }
        }

        public override void OnEnter()
        {
            this.DoBuildString();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoBuildString();
        }

        public override void Reset()
        {
            this.stringParts = new FsmString[3];
            this.separator = null;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}

