namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Debug), Tooltip("Adds a text area to the action list. NOTE: Doesn't do anything, just for notes...")]
    public class Comment : FsmStateAction
    {
        [UIHint(UIHint.Comment)]
        public string comment;

        public override void OnEnter()
        {
            base.Finish();
        }

        public override void Reset()
        {
            this.comment = string.Empty;
        }
    }
}

