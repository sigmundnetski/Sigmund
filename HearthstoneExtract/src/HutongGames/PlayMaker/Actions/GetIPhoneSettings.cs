namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.Device), Tooltip("Get various iPhone settings.")]
    public class GetIPhoneSettings : FsmStateAction
    {
        [Tooltip("The generation of the device (Read Only)."), UIHint(UIHint.Variable)]
        public FsmString getGeneration;
        [UIHint(UIHint.Variable), Tooltip("The model of the device (Read Only).")]
        public FsmString getModel;
        [Tooltip("The user defined name of the device (Read Only)."), UIHint(UIHint.Variable)]
        public FsmString getName;
        [Tooltip("Allows device to fall into 'sleep' state with screen being dim if no touches occurred. Default value is true."), UIHint(UIHint.Variable)]
        public FsmBool getScreenCanDarken;
        [Tooltip("The name of the operating system running on the device (Read Only)."), UIHint(UIHint.Variable)]
        public FsmString getSystemName;
        [UIHint(UIHint.Variable), Tooltip("A unique device identifier string. It is guaranteed to be unique for every device (Read Only).")]
        public FsmString getUniqueIdentifier;

        public override void OnEnter()
        {
            base.Finish();
        }

        public override void Reset()
        {
            this.getScreenCanDarken = null;
            this.getUniqueIdentifier = null;
            this.getName = null;
            this.getModel = null;
            this.getSystemName = null;
            this.getGeneration = null;
        }
    }
}

