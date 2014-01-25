namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Animate base action - DON'T USE IT!")]
    public abstract class CurveFsmAction : FsmStateAction
    {
        protected Calculation[] calculations;
        private float currentTime;
        protected AnimationCurve[] curves;
        [Tooltip("Delayed animimation start.")]
        public FsmFloat delay;
        private float delayTime;
        private float deltaTime;
        private float[] distances;
        private float[] endTimes;
        protected bool finishAction;
        [Tooltip("Optionally send an Event when the animation finishes.")]
        public FsmEvent finishEvent;
        protected float[] fromFloats;
        [Tooltip("Animation curve start from any time. If IgnoreCurveOffset is true the animation starts right after the state become entered.")]
        public FsmBool ignoreCurveOffset;
        protected bool isRunning;
        private float[] keyOffsets;
        private float largestEndTime;
        private float lastTime;
        protected bool looping;
        [Tooltip("Ignore TimeScale. Useful if the game is paused.")]
        public bool realTime;
        protected float[] resultFloats;
        [Tooltip("If you define speed, your animation will be speeded up or slowed down.")]
        public FsmFloat speed;
        private bool start;
        private float startTime;
        [Tooltip("Define time to use your curve scaled to be stretched or shrinked.")]
        public FsmFloat time;
        protected float[] toFloats;

        protected CurveFsmAction()
        {
        }

        protected void Init()
        {
            this.endTimes = new float[this.curves.Length];
            this.keyOffsets = new float[this.curves.Length];
            this.largestEndTime = 0f;
            for (int i = 0; i < this.curves.Length; i++)
            {
                if ((this.curves[i] != null) && (this.curves[i].keys.Length > 0))
                {
                    this.keyOffsets[i] = (this.curves[i].keys.Length <= 0) ? 0f : (!this.time.IsNone ? ((this.time.Value / this.curves[i].keys[this.curves[i].length - 1].time) * this.curves[i].keys[0].time) : this.curves[i].keys[0].time);
                    this.currentTime = !this.ignoreCurveOffset.IsNone ? (!this.ignoreCurveOffset.Value ? 0f : this.keyOffsets[i]) : 0f;
                    if (!this.time.IsNone)
                    {
                        this.endTimes[i] = this.time.Value;
                    }
                    else
                    {
                        this.endTimes[i] = this.curves[i].keys[this.curves[i].length - 1].time;
                    }
                    if (this.largestEndTime < this.endTimes[i])
                    {
                        this.largestEndTime = this.endTimes[i];
                    }
                    if (!this.looping)
                    {
                        this.looping = ActionHelpers.IsLoopingWrapMode(this.curves[i].postWrapMode);
                    }
                }
                else
                {
                    this.endTimes[i] = -1f;
                }
            }
            for (int j = 0; j < this.curves.Length; j++)
            {
                if ((this.largestEndTime > 0f) && (this.endTimes[j] == -1f))
                {
                    this.endTimes[j] = this.largestEndTime;
                }
                else if ((this.largestEndTime == 0f) && (this.endTimes[j] == -1f))
                {
                    if (this.time.IsNone)
                    {
                        this.endTimes[j] = 1f;
                    }
                    else
                    {
                        this.endTimes[j] = this.time.Value;
                    }
                }
            }
            this.distances = new float[this.fromFloats.Length];
            for (int k = 0; k < this.fromFloats.Length; k++)
            {
                this.distances[k] = Mathf.Sqrt(Mathf.Pow(this.fromFloats[k] - this.toFloats[k], 2f));
            }
        }

        public override void OnEnter()
        {
            this.startTime = FsmTime.RealtimeSinceStartup;
            this.lastTime = FsmTime.RealtimeSinceStartup - this.startTime;
            this.deltaTime = 0f;
            this.currentTime = 0f;
            this.isRunning = false;
            this.finishAction = false;
            this.looping = false;
            this.delayTime = !this.delay.IsNone ? (this.delayTime = this.delay.Value) : 0f;
            this.start = true;
        }

        public override void OnUpdate()
        {
            if (!this.isRunning && this.start)
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
            if (this.isRunning && !this.finishAction)
            {
                if (this.realTime)
                {
                    this.deltaTime = (FsmTime.RealtimeSinceStartup - this.startTime) - this.lastTime;
                    this.lastTime = FsmTime.RealtimeSinceStartup - this.startTime;
                    if (!this.speed.IsNone)
                    {
                        this.currentTime += this.deltaTime * this.speed.Value;
                    }
                    else
                    {
                        this.currentTime += this.deltaTime;
                    }
                }
                else if (!this.speed.IsNone)
                {
                    this.currentTime += Time.deltaTime * this.speed.Value;
                }
                else
                {
                    this.currentTime += Time.deltaTime;
                }
                for (int i = 0; i < this.curves.Length; i++)
                {
                    if ((this.curves[i] == null) || (this.curves[i].keys.Length <= 0))
                    {
                        goto Label_07E0;
                    }
                    switch (this.calculations[i])
                    {
                        case Calculation.AddToValue:
                        {
                            if (this.time.IsNone)
                            {
                                break;
                            }
                            this.resultFloats[i] = this.fromFloats[i] + ((this.distances[i] * (this.currentTime / this.time.Value)) + this.curves[i].Evaluate((this.currentTime / this.time.Value) * this.curves[i].keys[this.curves[i].length - 1].time));
                            continue;
                        }
                        case Calculation.SubtractFromValue:
                        {
                            if (this.time.IsNone)
                            {
                                goto Label_0349;
                            }
                            this.resultFloats[i] = this.fromFloats[i] + ((this.distances[i] * (this.currentTime / this.time.Value)) - this.curves[i].Evaluate((this.currentTime / this.time.Value) * this.curves[i].keys[this.curves[i].length - 1].time));
                            continue;
                        }
                        case Calculation.SubtractValueFromCurve:
                        {
                            if (this.time.IsNone)
                            {
                                goto Label_0413;
                            }
                            this.resultFloats[i] = (this.curves[i].Evaluate((this.currentTime / this.time.Value) * this.curves[i].keys[this.curves[i].length - 1].time) - (this.distances[i] * (this.currentTime / this.time.Value))) + this.fromFloats[i];
                            continue;
                        }
                        case Calculation.MultiplyValue:
                        {
                            if (this.time.IsNone)
                            {
                                goto Label_04DD;
                            }
                            this.resultFloats[i] = ((this.curves[i].Evaluate((this.currentTime / this.time.Value) * this.curves[i].keys[this.curves[i].length - 1].time) * this.distances[i]) * (this.currentTime / this.time.Value)) + this.fromFloats[i];
                            continue;
                        }
                        case Calculation.DivideValue:
                        {
                            if (this.time.IsNone)
                            {
                                goto Label_0601;
                            }
                            this.resultFloats[i] = (this.curves[i].Evaluate((this.currentTime / this.time.Value) * this.curves[i].keys[this.curves[i].length - 1].time) == 0f) ? float.MaxValue : (this.fromFloats[i] + ((this.distances[i] * (this.currentTime / this.time.Value)) / this.curves[i].Evaluate((this.currentTime / this.time.Value) * this.curves[i].keys[this.curves[i].length - 1].time)));
                            continue;
                        }
                        case Calculation.DivideCurveByValue:
                        {
                            if (this.time.IsNone)
                            {
                                goto Label_070E;
                            }
                            this.resultFloats[i] = (this.fromFloats[i] == 0f) ? float.MaxValue : ((this.curves[i].Evaluate((this.currentTime / this.time.Value) * this.curves[i].keys[this.curves[i].length - 1].time) / (this.distances[i] * (this.currentTime / this.time.Value))) + this.fromFloats[i]);
                            continue;
                        }
                        case Calculation.None:
                        {
                            if (!this.time.IsNone)
                            {
                                this.resultFloats[i] = this.fromFloats[i] + (this.distances[i] * (this.currentTime / this.time.Value));
                            }
                            else
                            {
                                this.resultFloats[i] = this.fromFloats[i] + (this.distances[i] * (this.currentTime / this.endTimes[i]));
                            }
                            continue;
                        }
                        default:
                        {
                            continue;
                        }
                    }
                    this.resultFloats[i] = this.fromFloats[i] + ((this.distances[i] * (this.currentTime / this.endTimes[i])) + this.curves[i].Evaluate(this.currentTime));
                    continue;
                Label_0349:
                    this.resultFloats[i] = this.fromFloats[i] + ((this.distances[i] * (this.currentTime / this.endTimes[i])) - this.curves[i].Evaluate(this.currentTime));
                    continue;
                Label_0413:
                    this.resultFloats[i] = (this.curves[i].Evaluate(this.currentTime) - (this.distances[i] * (this.currentTime / this.endTimes[i]))) + this.fromFloats[i];
                    continue;
                Label_04DD:
                    this.resultFloats[i] = ((this.curves[i].Evaluate(this.currentTime) * this.distances[i]) * (this.currentTime / this.endTimes[i])) + this.fromFloats[i];
                    continue;
                Label_0601:
                    this.resultFloats[i] = (this.curves[i].Evaluate(this.currentTime) == 0f) ? float.MaxValue : (this.fromFloats[i] + ((this.distances[i] * (this.currentTime / this.endTimes[i])) / this.curves[i].Evaluate(this.currentTime)));
                    continue;
                Label_070E:
                    this.resultFloats[i] = (this.fromFloats[i] == 0f) ? float.MaxValue : ((this.curves[i].Evaluate(this.currentTime) / (this.distances[i] * (this.currentTime / this.endTimes[i]))) + this.fromFloats[i]);
                    continue;
                Label_07E0:
                    if (!this.time.IsNone)
                    {
                        this.resultFloats[i] = this.fromFloats[i] + (this.distances[i] * (this.currentTime / this.time.Value));
                    }
                    else if (this.largestEndTime == 0f)
                    {
                        this.resultFloats[i] = this.fromFloats[i] + (this.distances[i] * (this.currentTime / 1f));
                    }
                    else
                    {
                        this.resultFloats[i] = this.fromFloats[i] + (this.distances[i] * (this.currentTime / this.largestEndTime));
                    }
                }
                if (this.isRunning)
                {
                    this.finishAction = true;
                    for (int j = 0; j < this.endTimes.Length; j++)
                    {
                        if (this.currentTime < this.endTimes[j])
                        {
                            this.finishAction = false;
                        }
                    }
                    this.isRunning = !this.finishAction;
                }
            }
        }

        public override void Reset()
        {
            this.finishEvent = null;
            this.realTime = false;
            FsmFloat num = new FsmFloat {
                UseVariable = true
            };
            this.time = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.speed = num;
            num = new FsmFloat {
                UseVariable = true
            };
            this.delay = num;
            FsmBool @bool = new FsmBool {
                Value = true
            };
            this.ignoreCurveOffset = @bool;
            this.resultFloats = new float[0];
            this.fromFloats = new float[0];
            this.toFloats = new float[0];
            this.distances = new float[0];
            this.endTimes = new float[0];
            this.keyOffsets = new float[0];
            this.curves = new AnimationCurve[0];
            this.finishAction = false;
            this.start = false;
        }

        public enum Calculation
        {
            None,
            AddToValue,
            SubtractFromValue,
            SubtractValueFromCurve,
            MultiplyValue,
            DivideValue,
            DivideCurveByValue
        }
    }
}

