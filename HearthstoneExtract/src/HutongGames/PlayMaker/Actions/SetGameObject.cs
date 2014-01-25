namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Sets the value of a Game Object Variable.")]
    public class SetGameObject : FsmStateAction
    {
        public bool everyFrame;
        public FsmGameObject gameObject;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmGameObject variable;

        public override void OnEnter()
        {
            this.variable.Value = this.gameObject.Value;
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.variable.Value = this.gameObject.Value;
        }

        public override void Reset()
        {
            this.variable = null;
            this.gameObject = null;
            this.everyFrame = false;
        }
    }
}

