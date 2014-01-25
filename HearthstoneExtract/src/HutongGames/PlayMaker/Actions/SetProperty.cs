namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Sets the value of any public property or field on the targeted Unity Object. E.g., Drag and drop any component attached to a Game Object to access its properties."), ActionCategory(ActionCategory.UnityObject)]
    public class SetProperty : FsmStateAction
    {
        public bool everyFrame;
        public FsmProperty targetProperty;

        public override void OnEnter()
        {
            this.targetProperty.SetValue();
            if (!this.everyFrame)
            {
                base.Finish();
            }
        }

        public override void OnUpdate()
        {
            this.targetProperty.SetValue();
        }

        public override void Reset()
        {
            FsmProperty property = new FsmProperty {
                setProperty = true
            };
            this.targetProperty = property;
            this.everyFrame = false;
        }
    }
}

