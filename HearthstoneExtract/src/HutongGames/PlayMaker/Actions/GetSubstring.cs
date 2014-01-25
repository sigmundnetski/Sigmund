namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.String), Tooltip("Gets a sub-string from a String Variable.")]
    public class GetSubstring : FsmStateAction
    {
        public bool everyFrame;
        [RequiredField]
        public FsmInt length;
        [RequiredField]
        public FsmInt startIndex;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmString storeResult;
        [RequiredField, UIHint(UIHint.Variable)]
        public FsmString stringVariable;

        private void DoGetSubstring()
        {
            if ((this.stringVariable != null) && (this.storeResult != null))
            {
                this.storeResult.Value = this.stringVariable.Value.Substring(this.startIndex.Value, this.length.Value);
            }
        }

        public override void OnEnter()
        {
            this.DoGetSubstring();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.DoGetSubstring();
        }

        public override void Reset()
        {
            this.stringVariable = null;
            this.startIndex = 0;
            this.length = 1;
            this.storeResult = null;
            this.everyFrame = false;
        }
    }
}

