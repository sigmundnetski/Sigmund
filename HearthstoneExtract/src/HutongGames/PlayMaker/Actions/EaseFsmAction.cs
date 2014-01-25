namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    [Tooltip("Ease base action - don't use!")]
    public abstract class EaseFsmAction : FsmStateAction
    {
        public FsmFloat delay;
        protected float delayTime;
        protected float deltaTime;
        protected EasingFunction ease;
        public EaseType easeType = EaseType.linear;
        protected bool finishAction;
        protected bool finished;
        [Tooltip("Optionally send an Event when the animation finishes.")]
        public FsmEvent finishEvent;
        protected float[] fromFloats = new float[0];
        protected bool isRunning;
        protected float lastTime;
        protected float percentage;
        [Tooltip("Ignore TimeScale. Useful if the game is paused.")]
        public bool realTime;
        protected float[] resultFloats = new float[0];
        public FsmBool reverse;
        protected float runningTime;
        public FsmFloat speed;
        protected bool start;
        protected float startTime;
        [RequiredField]
        public FsmFloat time;
        protected float[] toFloats = new float[0];

        protected EaseFsmAction()
        {
        }

        protected float bounce(float start, float end, float value)
        {
            value /= 1f;
            end -= start;
            if (value < 0.3636364f)
            {
                return ((end * ((7.5625f * value) * value)) + start);
            }
            if (value < 0.7272727f)
            {
                value -= 0.5454546f;
                return ((end * (((7.5625f * value) * value) + 0.75f)) + start);
            }
            if (value < 0.90909090909090906)
            {
                value -= 0.8181818f;
                return ((end * (((7.5625f * value) * value) + 0.9375f)) + start);
            }
            value -= 0.9545454f;
            return ((end * (((7.5625f * value) * value) + 0.984375f)) + start);
        }

        protected float clerp(float start, float end, float value)
        {
            float num = 0f;
            float num2 = 360f;
            float num3 = Mathf.Abs((float) ((num2 - num) / 2f));
            float num5 = 0f;
            if ((end - start) < -num3)
            {
                num5 = ((num2 - start) + end) * value;
                return (start + num5);
            }
            if ((end - start) > num3)
            {
                num5 = -((num2 - end) + start) * value;
                return (start + num5);
            }
            return (start + ((end - start) * value));
        }

        protected float easeInBack(float start, float end, float value)
        {
            end -= start;
            value /= 1f;
            float num = 1.70158f;
            return ((((end * value) * value) * (((num + 1f) * value) - num)) + start);
        }

        protected float easeInCirc(float start, float end, float value)
        {
            end -= start;
            return ((-end * (Mathf.Sqrt(1f - (value * value)) - 1f)) + start);
        }

        protected float easeInCubic(float start, float end, float value)
        {
            end -= start;
            return ((((end * value) * value) * value) + start);
        }

        protected float easeInExpo(float start, float end, float value)
        {
            end -= start;
            return ((end * Mathf.Pow(2f, 10f * ((value / 1f) - 1f))) + start);
        }

        protected float easeInOutBack(float start, float end, float value)
        {
            float num = 1.70158f;
            end -= start;
            value /= 0.5f;
            if (value < 1f)
            {
                num *= 1.525f;
                return (((end / 2f) * ((value * value) * (((num + 1f) * value) - num))) + start);
            }
            value -= 2f;
            num *= 1.525f;
            return (((end / 2f) * (((value * value) * (((num + 1f) * value) + num)) + 2f)) + start);
        }

        protected float easeInOutCirc(float start, float end, float value)
        {
            value /= 0.5f;
            end -= start;
            if (value < 1f)
            {
                return (((-end / 2f) * (Mathf.Sqrt(1f - (value * value)) - 1f)) + start);
            }
            value -= 2f;
            return (((end / 2f) * (Mathf.Sqrt(1f - (value * value)) + 1f)) + start);
        }

        protected float easeInOutCubic(float start, float end, float value)
        {
            value /= 0.5f;
            end -= start;
            if (value < 1f)
            {
                return (((((end / 2f) * value) * value) * value) + start);
            }
            value -= 2f;
            return (((end / 2f) * (((value * value) * value) + 2f)) + start);
        }

        protected float easeInOutExpo(float start, float end, float value)
        {
            value /= 0.5f;
            end -= start;
            if (value < 1f)
            {
                return (((end / 2f) * Mathf.Pow(2f, 10f * (value - 1f))) + start);
            }
            value--;
            return (((end / 2f) * (-Mathf.Pow(2f, -10f * value) + 2f)) + start);
        }

        protected float easeInOutQuad(float start, float end, float value)
        {
            value /= 0.5f;
            end -= start;
            if (value < 1f)
            {
                return ((((end / 2f) * value) * value) + start);
            }
            value--;
            return (((-end / 2f) * ((value * (value - 2f)) - 1f)) + start);
        }

        protected float easeInOutQuart(float start, float end, float value)
        {
            value /= 0.5f;
            end -= start;
            if (value < 1f)
            {
                return ((((((end / 2f) * value) * value) * value) * value) + start);
            }
            value -= 2f;
            return (((-end / 2f) * ((((value * value) * value) * value) - 2f)) + start);
        }

        protected float easeInOutQuint(float start, float end, float value)
        {
            value /= 0.5f;
            end -= start;
            if (value < 1f)
            {
                return (((((((end / 2f) * value) * value) * value) * value) * value) + start);
            }
            value -= 2f;
            return (((end / 2f) * (((((value * value) * value) * value) * value) + 2f)) + start);
        }

        protected float easeInOutSine(float start, float end, float value)
        {
            end -= start;
            return (((-end / 2f) * (Mathf.Cos((3.141593f * value) / 1f) - 1f)) + start);
        }

        protected float easeInQuad(float start, float end, float value)
        {
            end -= start;
            return (((end * value) * value) + start);
        }

        protected float easeInQuart(float start, float end, float value)
        {
            end -= start;
            return (((((end * value) * value) * value) * value) + start);
        }

        protected float easeInQuint(float start, float end, float value)
        {
            end -= start;
            return ((((((end * value) * value) * value) * value) * value) + start);
        }

        protected float easeInSine(float start, float end, float value)
        {
            end -= start;
            return (((-end * Mathf.Cos((value / 1f) * 1.570796f)) + end) + start);
        }

        protected float easeOutBack(float start, float end, float value)
        {
            float num = 1.70158f;
            end -= start;
            value = (value / 1f) - 1f;
            return ((end * (((value * value) * (((num + 1f) * value) + num)) + 1f)) + start);
        }

        protected float easeOutCirc(float start, float end, float value)
        {
            value--;
            end -= start;
            return ((end * Mathf.Sqrt(1f - (value * value))) + start);
        }

        protected float easeOutCubic(float start, float end, float value)
        {
            value--;
            end -= start;
            return ((end * (((value * value) * value) + 1f)) + start);
        }

        protected float easeOutExpo(float start, float end, float value)
        {
            end -= start;
            return ((end * (-Mathf.Pow(2f, (-10f * value) / 1f) + 1f)) + start);
        }

        protected float easeOutQuad(float start, float end, float value)
        {
            end -= start;
            return (((-end * value) * (value - 2f)) + start);
        }

        protected float easeOutQuart(float start, float end, float value)
        {
            value--;
            end -= start;
            return ((-end * ((((value * value) * value) * value) - 1f)) + start);
        }

        protected float easeOutQuint(float start, float end, float value)
        {
            value--;
            end -= start;
            return ((end * (((((value * value) * value) * value) * value) + 1f)) + start);
        }

        protected float easeOutSine(float start, float end, float value)
        {
            end -= start;
            return ((end * Mathf.Sin((value / 1f) * 1.570796f)) + start);
        }

        protected float elastic(float start, float end, float value)
        {
            end -= start;
            float num = 1f;
            float num2 = num * 0.3f;
            float num3 = 0f;
            float num4 = 0f;
            if (value == 0f)
            {
                return start;
            }
            if ((value /= num) == 1f)
            {
                return (start + end);
            }
            if ((num4 == 0f) || (num4 < Mathf.Abs(end)))
            {
                num4 = end;
                num3 = num2 / 4f;
            }
            else
            {
                num3 = (num2 / 6.283185f) * Mathf.Asin(end / num4);
            }
            return ((((num4 * Mathf.Pow(2f, -10f * value)) * Mathf.Sin((((value * num) - num3) * 6.283185f) / num2)) + end) + start);
        }

        protected float linear(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, value);
        }

        public override void OnEnter()
        {
            this.finished = false;
            this.isRunning = false;
            this.SetEasingFunction();
            this.runningTime = 0f;
            this.percentage = !this.reverse.IsNone ? (!this.reverse.Value ? 0f : 1f) : 0f;
            this.finishAction = false;
            this.startTime = FsmTime.RealtimeSinceStartup;
            this.lastTime = FsmTime.RealtimeSinceStartup - this.startTime;
            this.delayTime = !this.delay.IsNone ? (this.delayTime = this.delay.Value) : 0f;
            this.start = true;
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            if (this.start && !this.isRunning)
            {
                if (this.delayTime >= 0f)
                {
                    if (this.realTime)
                    {
                        this.deltaTime = (FsmTime.RealtimeSinceStartup - this.startTime) - this.lastTime;
                        this.lastTime = FsmTime.RealtimeSinceStartup - this.startTime;
                        this.delayTime -= this.deltaTime;
                    }
                    else
                    {
                        this.delayTime -= Time.deltaTime;
                    }
                }
                else
                {
                    this.isRunning = true;
                    this.start = false;
                    this.startTime = FsmTime.RealtimeSinceStartup;
                    this.lastTime = FsmTime.RealtimeSinceStartup - this.startTime;
                }
            }
            if (this.isRunning && !this.finished)
            {
                if (!(!this.reverse.IsNone ? this.reverse.Value : false))
                {
                    this.UpdatePercentage();
                    if (this.percentage < 1f)
                    {
                        for (int i = 0; i < this.fromFloats.Length; i++)
                        {
                            this.resultFloats[i] = this.ease(this.fromFloats[i], this.toFloats[i], this.percentage);
                        }
                    }
                    else
                    {
                        this.finishAction = true;
                        this.finished = true;
                        this.isRunning = false;
                    }
                }
                else
                {
                    this.UpdatePercentage();
                    if (this.percentage > 0f)
                    {
                        for (int j = 0; j < this.fromFloats.Length; j++)
                        {
                            this.resultFloats[j] = this.ease(this.fromFloats[j], this.toFloats[j], this.percentage);
                        }
                    }
                    else
                    {
                        this.finishAction = true;
                        this.finished = true;
                        this.isRunning = false;
                    }
                }
            }
        }

        protected float punch(float amplitude, float value)
        {
            float num = 9f;
            if (value == 0f)
            {
                return 0f;
            }
            if (value == 1f)
            {
                return 0f;
            }
            float num2 = 0.3f;
            num = (num2 / 6.283185f) * Mathf.Asin(0f);
            return ((amplitude * Mathf.Pow(2f, -10f * value)) * Mathf.Sin((((value * 1f) - num) * 6.283185f) / num2));
        }

        public override void Reset()
        {
            this.easeType = EaseType.linear;
            FsmFloat num = new FsmFloat {
                Value = 1f
            };
            this.time = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.delay = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.speed = num;
            FsmBool @bool = new FsmBool {
                Value = false
            };
            this.reverse = @bool;
            this.realTime = false;
            this.finishEvent = null;
            this.ease = null;
            this.runningTime = 0f;
            this.lastTime = 0f;
            this.percentage = 0f;
            this.fromFloats = new float[0];
            this.toFloats = new float[0];
            this.resultFloats = new float[0];
            this.finishAction = false;
            this.start = false;
            this.finished = false;
            this.isRunning = false;
        }

        protected void SetEasingFunction()
        {
            switch (this.easeType)
            {
                case EaseType.easeInQuad:
                    this.ease = new EasingFunction(this.easeInQuad);
                    break;

                case EaseType.easeOutQuad:
                    this.ease = new EasingFunction(this.easeOutQuad);
                    break;

                case EaseType.easeInOutQuad:
                    this.ease = new EasingFunction(this.easeInOutQuad);
                    break;

                case EaseType.easeInCubic:
                    this.ease = new EasingFunction(this.easeInCubic);
                    break;

                case EaseType.easeOutCubic:
                    this.ease = new EasingFunction(this.easeOutCubic);
                    break;

                case EaseType.easeInOutCubic:
                    this.ease = new EasingFunction(this.easeInOutCubic);
                    break;

                case EaseType.easeInQuart:
                    this.ease = new EasingFunction(this.easeInQuart);
                    break;

                case EaseType.easeOutQuart:
                    this.ease = new EasingFunction(this.easeOutQuart);
                    break;

                case EaseType.easeInOutQuart:
                    this.ease = new EasingFunction(this.easeInOutQuart);
                    break;

                case EaseType.easeInQuint:
                    this.ease = new EasingFunction(this.easeInQuint);
                    break;

                case EaseType.easeOutQuint:
                    this.ease = new EasingFunction(this.easeOutQuint);
                    break;

                case EaseType.easeInOutQuint:
                    this.ease = new EasingFunction(this.easeInOutQuint);
                    break;

                case EaseType.easeInSine:
                    this.ease = new EasingFunction(this.easeInSine);
                    break;

                case EaseType.easeOutSine:
                    this.ease = new EasingFunction(this.easeOutSine);
                    break;

                case EaseType.easeInOutSine:
                    this.ease = new EasingFunction(this.easeInOutSine);
                    break;

                case EaseType.easeInExpo:
                    this.ease = new EasingFunction(this.easeInExpo);
                    break;

                case EaseType.easeOutExpo:
                    this.ease = new EasingFunction(this.easeOutExpo);
                    break;

                case EaseType.easeInOutExpo:
                    this.ease = new EasingFunction(this.easeInOutExpo);
                    break;

                case EaseType.easeInCirc:
                    this.ease = new EasingFunction(this.easeInCirc);
                    break;

                case EaseType.easeOutCirc:
                    this.ease = new EasingFunction(this.easeOutCirc);
                    break;

                case EaseType.easeInOutCirc:
                    this.ease = new EasingFunction(this.easeInOutCirc);
                    break;

                case EaseType.linear:
                    this.ease = new EasingFunction(this.linear);
                    break;

                case EaseType.spring:
                    this.ease = new EasingFunction(this.spring);
                    break;

                case EaseType.bounce:
                    this.ease = new EasingFunction(this.bounce);
                    break;

                case EaseType.easeInBack:
                    this.ease = new EasingFunction(this.easeInBack);
                    break;

                case EaseType.easeOutBack:
                    this.ease = new EasingFunction(this.easeOutBack);
                    break;

                case EaseType.easeInOutBack:
                    this.ease = new EasingFunction(this.easeInOutBack);
                    break;

                case EaseType.elastic:
                    this.ease = new EasingFunction(this.elastic);
                    break;
            }
        }

        protected float spring(float start, float end, float value)
        {
            value = Mathf.Clamp01(value);
            value = ((Mathf.Sin((value * 3.141593f) * (0.2f + (((2.5f * value) * value) * value))) * Mathf.Pow(1f - value, 2.2f)) + value) * (1f + (1.2f * (1f - value)));
            return (start + ((end - start) * value));
        }

        protected void UpdatePercentage()
        {
            if (this.realTime)
            {
                this.deltaTime = (FsmTime.RealtimeSinceStartup - this.startTime) - this.lastTime;
                this.lastTime = FsmTime.RealtimeSinceStartup - this.startTime;
                if (!this.speed.IsNone)
                {
                    this.runningTime += this.deltaTime * this.speed.Value;
                }
                else
                {
                    this.runningTime += this.deltaTime;
                }
            }
            else if (!this.speed.IsNone)
            {
                this.runningTime += Time.deltaTime * this.speed.Value;
            }
            else
            {
                this.runningTime += Time.deltaTime;
            }
            if (!this.reverse.IsNone ? this.reverse.Value : false)
            {
                this.percentage = 1f - (this.runningTime / this.time.Value);
            }
            else
            {
                this.percentage = this.runningTime / this.time.Value;
            }
        }

        public enum EaseType
        {
            easeInQuad,
            easeOutQuad,
            easeInOutQuad,
            easeInCubic,
            easeOutCubic,
            easeInOutCubic,
            easeInQuart,
            easeOutQuart,
            easeInOutQuart,
            easeInQuint,
            easeOutQuint,
            easeInOutQuint,
            easeInSine,
            easeOutSine,
            easeInOutSine,
            easeInExpo,
            easeOutExpo,
            easeInOutExpo,
            easeInCirc,
            easeOutCirc,
            easeInOutCirc,
            linear,
            spring,
            bounce,
            easeInBack,
            easeOutBack,
            easeInOutBack,
            elastic,
            punch
        }

        protected delegate float EasingFunction(float start, float end, float value);
    }
}

