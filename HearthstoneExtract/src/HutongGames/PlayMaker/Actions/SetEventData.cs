namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [ActionCategory(ActionCategory.StateMachine), Tooltip("Sets Event Data before sending an event. Get the Event Data, along with sender information, using Get Event Info action.")]
    public class SetEventData : FsmStateAction
    {
        public FsmBool setBoolData;
        public FsmColor setColorData;
        public FsmFloat setFloatData;
        public FsmGameObject setGameObjectData;
        public FsmInt setIntData;
        public FsmMaterial setMaterialData;
        public FsmObject setObjectData;
        public FsmQuaternion setQuaternionData;
        public FsmRect setRectData;
        public FsmString setStringData;
        public FsmTexture setTextureData;
        public FsmVector2 setVector2Data;
        public FsmVector3 setVector3Data;

        public override void OnEnter()
        {
            Fsm.EventData.BoolData = this.setBoolData.Value;
            Fsm.EventData.IntData = this.setIntData.Value;
            Fsm.EventData.FloatData = this.setFloatData.Value;
            Fsm.EventData.Vector2Data = this.setVector2Data.Value;
            Fsm.EventData.Vector3Data = this.setVector3Data.Value;
            Fsm.EventData.StringData = this.setStringData.Value;
            Fsm.EventData.GameObjectData = this.setGameObjectData.Value;
            Fsm.EventData.RectData = this.setRectData.Value;
            Fsm.EventData.QuaternionData = this.setQuaternionData.Value;
            Fsm.EventData.ColorData = this.setColorData.Value;
            Fsm.EventData.MaterialData = this.setMaterialData.Value;
            Fsm.EventData.TextureData = this.setTextureData.Value;
            Fsm.EventData.ObjectData = this.setObjectData.Value;
            base.Finish();
        }

        public override void Reset()
        {
            FsmGameObject obj2 = new FsmGameObject {
                UseVariable = true
            };
            this.setGameObjectData = obj2;
            FsmInt num = new FsmInt {
                UseVariable = true
            };
            this.setIntData = num;
            FsmFloat num2 = new FsmFloat {
                UseVariable = true
            };
            this.setFloatData = num2;
            FsmString str = new FsmString {
                UseVariable = true
            };
            this.setStringData = str;
            FsmBool @bool = new FsmBool {
                UseVariable = true
            };
            this.setBoolData = @bool;
            FsmVector2 vector = new FsmVector2 {
                UseVariable = true
            };
            this.setVector2Data = vector;
            FsmVector3 vector2 = new FsmVector3 {
                UseVariable = true
            };
            this.setVector3Data = vector2;
            FsmRect rect = new FsmRect {
                UseVariable = true
            };
            this.setRectData = rect;
            FsmQuaternion quaternion = new FsmQuaternion {
                UseVariable = true
            };
            this.setQuaternionData = quaternion;
            FsmColor color = new FsmColor {
                UseVariable = true
            };
            this.setColorData = color;
            FsmMaterial material = new FsmMaterial {
                UseVariable = true
            };
            this.setMaterialData = material;
            FsmTexture texture = new FsmTexture {
                UseVariable = true
            };
            this.setTextureData = texture;
            FsmObject obj3 = new FsmObject {
                UseVariable = true
            };
            this.setObjectData = obj3;
        }
    }
}

