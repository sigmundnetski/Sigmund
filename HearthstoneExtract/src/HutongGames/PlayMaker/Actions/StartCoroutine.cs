namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    [ActionCategory(ActionCategory.ScriptControl), Tooltip("Start a Coroutine in a Behaviour on a Game Object. See Unity StartCoroutine docs.")]
    public class StartCoroutine : FsmStateAction
    {
        [CompilerGenerated]
        private static Dictionary<string, int> <>f__switch$map6;
        [RequiredField, UIHint(UIHint.Behaviour), Tooltip("The Behaviour that contains the method to start as a coroutine.")]
        public FsmString behaviour;
        private MonoBehaviour component;
        [Tooltip("The name of the coroutine method."), UIHint(UIHint.Coroutine), RequiredField]
        public FunctionCall functionCall;
        [Tooltip("The game object that owns the Behaviour."), RequiredField]
        public FsmOwnerDefault gameObject;
        [Tooltip("Stop the coroutine when the state is exited.")]
        public bool stopOnExit;

        private void DoStartCoroutine()
        {
            GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(this.gameObject);
            if (ownerDefaultTarget != null)
            {
                this.component = ownerDefaultTarget.GetComponent(this.behaviour.Value) as MonoBehaviour;
                if (this.component == null)
                {
                    this.LogWarning("StartCoroutine: " + ownerDefaultTarget.name + " missing behaviour: " + this.behaviour.Value);
                }
                else
                {
                    string parameterType = this.functionCall.ParameterType;
                    if (parameterType != null)
                    {
                        int num;
                        if (<>f__switch$map6 == null)
                        {
                            Dictionary<string, int> dictionary = new Dictionary<string, int>(13);
                            dictionary.Add("None", 0);
                            dictionary.Add("int", 1);
                            dictionary.Add("float", 2);
                            dictionary.Add("string", 3);
                            dictionary.Add("bool", 4);
                            dictionary.Add("Vector2", 5);
                            dictionary.Add("Vector3", 6);
                            dictionary.Add("Rect", 7);
                            dictionary.Add("GameObject", 8);
                            dictionary.Add("Material", 9);
                            dictionary.Add("Texture", 10);
                            dictionary.Add("Quaternion", 11);
                            dictionary.Add("Object", 12);
                            <>f__switch$map6 = dictionary;
                        }
                        if (<>f__switch$map6.TryGetValue(parameterType, out num))
                        {
                            switch (num)
                            {
                                case 0:
                                    this.component.StartCoroutine(this.functionCall.FunctionName);
                                    return;

                                case 1:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.IntParameter.Value);
                                    return;

                                case 2:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.FloatParameter.Value);
                                    return;

                                case 3:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.StringParameter.Value);
                                    return;

                                case 4:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.BoolParameter.Value);
                                    return;

                                case 5:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.Vector2Parameter.Value);
                                    return;

                                case 6:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.Vector3Parameter.Value);
                                    return;

                                case 7:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.RectParamater.Value);
                                    return;

                                case 8:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.GameObjectParameter.Value);
                                    return;

                                case 9:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.MaterialParameter.Value);
                                    break;

                                case 10:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.TextureParameter.Value);
                                    break;

                                case 11:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.QuaternionParameter.Value);
                                    break;

                                case 12:
                                    this.component.StartCoroutine(this.functionCall.FunctionName, this.functionCall.ObjectParameter.Value);
                                    return;
                            }
                        }
                    }
                }
            }
        }

        public override void OnEnter()
        {
            this.DoStartCoroutine();
            base.Finish();
        }

        public override void OnExit()
        {
            if ((this.component != null) && this.stopOnExit)
            {
                this.component.StopCoroutine(this.functionCall.FunctionName);
            }
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.behaviour = null;
            this.functionCall = null;
            this.stopOnExit = false;
        }
    }
}

