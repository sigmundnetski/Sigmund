using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DamageSplatSpell : Spell
{
    private GameObject m_activeSplat;
    public GameObject m_BloodSplat;
    private int m_damage;
    public UberText m_DamageTextMesh;
    public GameObject m_HealSplat;
    private const float SCALE_IN_TIME = 1f;

    protected override void Awake()
    {
        base.Awake();
        this.EnableAllRenderers(false);
    }

    public void DoSplatAnims()
    {
        base.StopAllCoroutines();
        iTween.Stop(base.gameObject);
        base.StartCoroutine(this.SplatAnimCoroutine());
    }

    private void EnableAllRenderers(bool enabled)
    {
        SceneUtils.EnableRenderers(this.m_BloodSplat.gameObject, enabled);
        SceneUtils.EnableRenderers(this.m_HealSplat.gameObject, enabled);
        this.m_DamageTextMesh.gameObject.SetActive(enabled);
    }

    public float GetDamage()
    {
        return (float) this.m_damage;
    }

    protected override void HideImpl()
    {
        base.HideImpl();
        this.EnableAllRenderers(false);
    }

    protected override void OnAction(SpellStateType prevStateType)
    {
        this.UpdateElements();
        base.OnAction(prevStateType);
    }

    protected override void OnIdle(SpellStateType prevStateType)
    {
        this.UpdateElements();
        base.OnIdle(prevStateType);
    }

    public void SetDamage(int damage)
    {
        this.m_damage = damage;
    }

    protected override void ShowImpl()
    {
        base.ShowImpl();
        if (this.m_activeSplat != null)
        {
            SceneUtils.EnableRenderers(this.m_activeSplat.gameObject, true);
            this.m_DamageTextMesh.gameObject.SetActive(true);
        }
    }

    [DebuggerHidden]
    private IEnumerator SplatAnimCoroutine()
    {
        return new <SplatAnimCoroutine>c__IteratorA8 { <>f__this = this };
    }

    private void UpdateElements()
    {
        if (this.m_damage < 0)
        {
            this.m_DamageTextMesh.Text = string.Format("+{0}", Mathf.Abs(this.m_damage));
            this.m_activeSplat = this.m_HealSplat;
            SceneUtils.EnableRenderers(this.m_BloodSplat.gameObject, false);
            SceneUtils.EnableRenderers(this.m_HealSplat.gameObject, true);
        }
        else
        {
            this.m_DamageTextMesh.Text = string.Format("-{0}", this.m_damage);
            this.m_activeSplat = this.m_BloodSplat;
            SceneUtils.EnableRenderers(this.m_BloodSplat.gameObject, true);
            SceneUtils.EnableRenderers(this.m_HealSplat.gameObject, false);
        }
        this.m_DamageTextMesh.gameObject.SetActive(true);
    }

    [CompilerGenerated]
    private sealed class <SplatAnimCoroutine>c__IteratorA8 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal DamageSplatSpell <>f__this;

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
                    this.<>f__this.UpdateElements();
                    iTween.FadeTo(this.<>f__this.gameObject, 1f, 0f);
                    this.<>f__this.transform.localScale = Vector3.zero;
                    this.$current = null;
                    this.$PC = 1;
                    goto Label_0134;

                case 1:
                {
                    object[] args = new object[] { "scale", Vector3.one, "time", 1f, "easetype", iTween.EaseType.easeOutElastic };
                    iTween.ScaleTo(this.<>f__this.gameObject, iTween.Hash(args));
                    this.$current = new WaitForSeconds(2f);
                    this.$PC = 2;
                    goto Label_0134;
                }
                case 2:
                    iTween.FadeTo(this.<>f__this.gameObject, 0f, 1f);
                    this.$current = new WaitForSeconds(1.1f);
                    this.$PC = 3;
                    goto Label_0134;

                case 3:
                    this.<>f__this.EnableAllRenderers(false);
                    this.$PC = -1;
                    break;
            }
            return false;
        Label_0134:
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

