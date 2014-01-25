namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    [ActionCategory(ActionCategory.ScriptControl), Tooltip("Sends a Message to a Game Object. See Unity docs for SendMessage.")]
    public class SendMessage : FsmStateAction
    {
        [CompilerGenerated]
        private static Dictionary<string, int> <>f__switch$map5;
        [Tooltip("Where to send the message.\nSee Unity docs.")]
        public MessageType delivery;
        [RequiredField]
        public FunctionCall functionCall;
        [RequiredField, Tooltip("GameObject that sends the message.")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Send options.\nSee Unity docs.")]
        public SendMessageOptions options;

        private void DoSendMessage()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                object obj3 = null;
                string parameterType = this.functionCall.ParameterType;
                if (parameterType != null)
                {
                    int num;
                    if (<>f__switch$map5 == null)
                    {
                        Dictionary<string, int> dictionary = new Dictionary<string, int>(14);
                        dictionary.Add("None", 0);
                        dictionary.Add("bool", 1);
                        dictionary.Add("int", 2);
                        dictionary.Add("float", 3);
                        dictionary.Add("string", 4);
                        dictionary.Add("Vector2", 5);
                        dictionary.Add("Vector3", 6);
                        dictionary.Add("Rect", 7);
                        dictionary.Add("GameObject", 8);
                        dictionary.Add("Material", 9);
                        dictionary.Add("Texture", 10);
                        dictionary.Add("Color", 11);
                        dictionary.Add("Quaternion", 12);
                        dictionary.Add("Object", 13);
                        <>f__switch$map5 = dictionary;
                    }
                    if (<>f__switch$map5.TryGetValue(parameterType, out num))
                    {
                        switch (num)
                        {
                            case 1:
                                obj3 = this.functionCall.BoolParameter.Value;
                                break;

                            case 2:
                                obj3 = this.functionCall.IntParameter.Value;
                                break;

                            case 3:
                                obj3 = this.functionCall.FloatParameter.Value;
                                break;

                            case 4:
                                obj3 = this.functionCall.StringParameter.Value;
                                break;

                            case 5:
                                obj3 = this.functionCall.Vector2Parameter.Value;
                                break;

                            case 6:
                                obj3 = this.functionCall.Vector3Parameter.Value;
                                break;

                            case 7:
                                obj3 = this.functionCall.RectParamater.Value;
                                break;

                            case 8:
                                obj3 = this.functionCall.GameObjectParameter.Value;
                                break;

                            case 9:
                                obj3 = this.functionCall.MaterialParameter.Value;
                                break;

                            case 10:
                                obj3 = this.functionCall.TextureParameter.Value;
                                break;

                            case 11:
                                obj3 = this.functionCall.ColorParameter.Value;
                                break;

                            case 12:
                                obj3 = this.functionCall.QuaternionParameter.Value;
                                break;

                            case 13:
                                obj3 = this.functionCall.ObjectParameter.Value;
                                break;
                        }
                    }
                }
                switch (this.delivery)
                {
                    case MessageType.SendMessage:
                        ownerDefaultTarget.SendMessage(this.functionCall.FunctionName, obj3, this.options);
                        return;

                    case MessageType.SendMessageUpwards:
                        ownerDefaultTarget.SendMessageUpwards(this.functionCall.FunctionName, obj3, this.options);
                        return;

                    case MessageType.BroadcastMessage:
                        ownerDefaultTarget.BroadcastMessage(this.functionCall.FunctionName, obj3, this.options);
                        return;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSendMessage();
            base.Finish();
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.delivery = MessageType.SendMessage;
            this.options = SendMessageOptions.DontRequireReceiver;
            this.functionCall = null;
        }

        public enum MessageType
        {
            SendMessage,
            SendMessageUpwards,
            BroadcastMessage
        }
    }
}

