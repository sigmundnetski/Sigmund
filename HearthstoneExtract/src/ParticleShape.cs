using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ParticleShape : MonoBehaviour
{
    private Vector3[] posEnd;
    public Vector3 scale = new Vector3(10f, 10f, 10f);
    public Texture2D shapeTexture;

    private int CountOpaquePixels(Texture2D texture)
    {
        int num = 0;
        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                if (texture.GetPixel(i, j).a > 0f)
                {
                    num++;
                }
            }
        }
        return num;
    }

    [DebuggerHidden]
    private IEnumerator SnapToPosition()
    {
        return new <SnapToPosition>c__IteratorFE { <>f__this = this };
    }

    private void Start()
    {
        this.posEnd = new Vector3[this.CountOpaquePixels(this.shapeTexture)];
        int index = 0;
        float num2 = this.shapeTexture.width / this.shapeTexture.height;
        for (int i = 0; i < this.shapeTexture.width; i++)
        {
            for (int j = 0; j < this.shapeTexture.height; j++)
            {
                Color pixel = this.shapeTexture.GetPixel(i, j);
                if (pixel.a > 0f)
                {
                    base.particleEmitter.Emit((Vector3) (UnityEngine.Random.insideUnitSphere * 1f), (Vector3) (UnityEngine.Random.insideUnitSphere * 1f), 0.5f, 100f, pixel);
                    this.posEnd[index] = new Vector3(0f, (((float) j) / ((float) this.shapeTexture.height)) - 0.5f, ((((float) i) / ((float) this.shapeTexture.width)) - 0.5f) * num2);
                    this.posEnd[index].Scale(this.scale);
                    index++;
                }
            }
        }
        base.StartCoroutine("SnapToPosition");
    }

    [CompilerGenerated]
    private sealed class <SnapToPosition>c__IteratorFE : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ParticleShape <>f__this;
        internal bool <go>__6;
        internal int <i>__5;
        internal int <i>__8;
        internal int <length>__2;
        internal UnityEngine.Particle[] <particles>__4;
        internal float <pos>__7;
        internal Vector3[] <posStart>__3;
        internal float <timeElapsed>__0;
        internal float <timeLength>__1;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    goto Label_0025;

                case 1:
                    this.<timeElapsed>__0 = 1f;
                    this.<timeLength>__1 = 1f;
                    this.<length>__2 = this.<>f__this.particleEmitter.particles.Length;
                    this.<posStart>__3 = new Vector3[this.<length>__2];
                    this.<particles>__4 = this.<>f__this.particleEmitter.particles;
                    this.<i>__5 = 0;
                    while (this.<i>__5 < this.<particles>__4.Length)
                    {
                        this.<posStart>__3[this.<i>__5] = this.<particles>__4[this.<i>__5].position;
                        this.<particles>__4[this.<i>__5].velocity = Vector3.zero;
                        this.<i>__5++;
                    }
                    this.<go>__6 = true;
                    goto Label_0229;

                case 2:
                    goto Label_0229;

                default:
                    return false;
            }
        Label_0025:
            this.$current = new WaitForSeconds(0f);
            this.$PC = 1;
            goto Label_0258;
        Label_0229:
            while (this.<go>__6)
            {
                this.<pos>__7 = this.<timeElapsed>__0 / this.<timeLength>__1;
                if (this.<pos>__7 >= 1f)
                {
                    this.<go>__6 = false;
                    this.<pos>__7 = 1f;
                }
                this.<particles>__4 = this.<>f__this.particleEmitter.particles;
                this.<i>__8 = 0;
                while (this.<i>__8 < this.<particles>__4.Length)
                {
                    this.<particles>__4[this.<i>__8].position = Vector3.Lerp(this.<posStart>__3[this.<i>__8], this.<>f__this.posEnd[this.<i>__8], this.<pos>__7);
                    this.<particles>__4[this.<i>__8].velocity = Vector3.zero;
                    this.<i>__8++;
                }
                this.<>f__this.particleEmitter.particles = this.<particles>__4;
                this.$current = 0;
                this.$PC = 2;
                goto Label_0258;
            }
            this.<>f__this.particleEmitter.particles = this.<particles>__4;
            goto Label_0025;
        Label_0258:
            return true;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }
}

