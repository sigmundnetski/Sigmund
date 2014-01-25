using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class Misdirection : Spell
{
    private Card m_AttackingMinionCard;
    private Color m_OrgAmbient;
    private Card m_PlayerHeroCard;
    public GameObject m_Reticle;
    public Color m_ReticleAttackColor = Color.red;
    public float m_ReticleAttackHold = 0.25f;
    public Vector3 m_ReticleAttackRotate = new Vector3(0f, 90f, 0f);
    public float m_ReticleAttackScale = 1.1f;
    public float m_ReticleAttackTime = 0.3f;
    public float m_ReticleBlur = 0.005f;
    public float m_ReticleBlurFocusTime = 0.8f;
    public float m_ReticleFadeInTime = 0.8f;
    public float m_ReticleFadeOutTime = 0.4f;
    private GameObject m_ReticleInstance;
    public float m_ReticlePathTime = 3f;

    [DebuggerHidden]
    private IEnumerator AnimateReticle()
    {
        return new <AnimateReticle>c__IteratorC1 { <>f__this = this };
    }

    private Vector3[] BuildAnimationPath()
    {
        Card[] cardArray = this.FindPossibleTargetCards();
        int num = UnityEngine.Random.Range(3, 4);
        if (num >= (cardArray.Length + 2))
        {
            num = cardArray.Length + 2;
        }
        if (cardArray.Length <= 1)
        {
            return new Vector3[] { this.m_PlayerHeroCard.transform.position, base.GetTarget().transform.position };
        }
        List<Vector3> list = new List<Vector3> {
            this.m_PlayerHeroCard.transform.position
        };
        GameObject gameObject = this.m_PlayerHeroCard.gameObject;
        for (int i = 1; i < num; i++)
        {
            GameObject obj3 = cardArray[UnityEngine.Random.Range(0, cardArray.Length - 1)].gameObject;
            if (obj3 == gameObject)
            {
                obj3 = cardArray[UnityEngine.Random.Range(0, cardArray.Length - 1)].gameObject;
                if (obj3 == gameObject)
                {
                    if (obj3 == cardArray[cardArray.Length - 1])
                    {
                        obj3 = cardArray[0].gameObject;
                    }
                    else
                    {
                        obj3 = cardArray[cardArray.Length - 1].gameObject;
                    }
                }
            }
            if (((i == (num - 1)) && (obj3 == base.GetTarget())) && (obj3 == gameObject))
            {
                if (obj3 == cardArray[cardArray.Length - 1])
                {
                    obj3 = cardArray[0].gameObject;
                }
                else
                {
                    obj3 = cardArray[cardArray.Length - 1].gameObject;
                }
            }
            list.Add(obj3.transform.position);
        }
        list.Add(base.GetTarget().transform.position);
        return list.ToArray();
    }

    private Card[] FindPossibleTargetCards()
    {
        List<Card> list = new List<Card>();
        ZoneMgr mgr = ZoneMgr.Get();
        if (mgr != null)
        {
            foreach (ZonePlay play in mgr.FindZonesOfType<ZonePlay>())
            {
                foreach (Card card in play.GetCards())
                {
                    if (card != this.m_AttackingMinionCard)
                    {
                        list.Add(card);
                    }
                }
            }
            list.Add(this.GetOpponentHeroCard());
        }
        return list.ToArray();
    }

    private Card GetCurrentPlayerHeroCard()
    {
        return base.GetSourceCard().GetController().GetHeroCard();
    }

    private Card GetOpponentHeroCard()
    {
        return GameState.Get().GetFirstOpponentPlayer(base.GetSourceCard().GetController()).GetHeroCard();
    }

    private Card[] GetOpponentZoneMinions()
    {
        List<Card> list = new List<Card>();
        ZoneMgr mgr = ZoneMgr.Get();
        Player firstOpponentPlayer = GameState.Get().GetFirstOpponentPlayer(base.GetSourceCard().GetController());
        foreach (Card card in mgr.FindZoneOfType<ZonePlay>(TAG_ZONE.PLAY, firstOpponentPlayer.GetSide()).GetCards())
        {
            if (card != this.m_AttackingMinionCard)
            {
                list.Add(card);
            }
        }
        return list.ToArray();
    }

    protected override Card GetTargetCardFromPowerTask(PowerTask task)
    {
        Network.PowerHistory power = task.GetPower();
        if (power.Type != Network.PowerHistory.PowType.TAG_CHANGE)
        {
            return null;
        }
        Network.HistTagChange change = power as Network.HistTagChange;
        if (change.Tag != 0x25)
        {
            return null;
        }
        Entity entity = GameState.Get().GetEntity(change.Value);
        if (entity == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("{0}.GetTargetCardFromPowerTask() - WARNING trying to target entity with id {1} but there is no entity with that id", this, change.Value));
            return null;
        }
        return entity.GetCard();
    }

    protected override void OnAction(SpellStateType prevStateType)
    {
        this.StartAnimation();
    }

    private void ReticleAnimationComplete()
    {
        base.StartCoroutine(this.ReticleAttackAnimation());
    }

    [DebuggerHidden]
    private IEnumerator ReticleAttackAnimation()
    {
        return new <ReticleAttackAnimation>c__IteratorC2 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator ReticleFadeIn()
    {
        return new <ReticleFadeIn>c__IteratorC0 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator ReticleFadeOut()
    {
        return new <ReticleFadeOut>c__IteratorC3 { <>f__this = this };
    }

    private void SetReticleAlphaValue(float val)
    {
        this.m_ReticleInstance.GetComponent<RenderToTexture>().GetRenderMaterial().SetFloat("_Alpha", val);
    }

    private void StartAnimation()
    {
        GameState state = GameState.Get();
        GameEntity gameEntity = state.GetGameEntity();
        this.m_AttackingMinionCard = state.GetEntity(gameEntity.GetTag(GAME_TAG.PROPOSED_ATTACKER)).GetCard();
        this.m_PlayerHeroCard = this.GetCurrentPlayerHeroCard();
        this.m_ReticleInstance = (GameObject) UnityEngine.Object.Instantiate(this.m_Reticle, this.m_PlayerHeroCard.transform.position, Quaternion.identity);
        Material renderMaterial = this.m_ReticleInstance.GetComponent<RenderToTexture>().GetRenderMaterial();
        renderMaterial.SetFloat("_Alpha", 0f);
        renderMaterial.SetFloat("_blur", this.m_ReticleBlur);
        base.StartCoroutine(this.ReticleFadeIn());
        base.StartCoroutine(this.AnimateReticle());
        AudioSource component = base.GetComponent<AudioSource>();
        if (component != null)
        {
            SoundManager.Get().Play(component);
        }
    }

    [CompilerGenerated]
    private sealed class <AnimateReticle>c__IteratorC1 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Misdirection <>f__this;
        internal Hashtable <reticalArgs>__0;

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
                    this.$current = new WaitForSeconds(this.<>f__this.m_ReticleFadeInTime);
                    this.$PC = 1;
                    return true;

                case 1:
                {
                    object[] args = new object[] { "path", this.<>f__this.BuildAnimationPath(), "time", this.<>f__this.m_ReticlePathTime, "easetype", iTween.EaseType.easeInOutQuad, "oncomplete", "ReticleAnimationComplete", "oncompletetarget", this.<>f__this.gameObject, "orienttopath", false };
                    this.<reticalArgs>__0 = iTween.Hash(args);
                    iTween.MoveTo(this.<>f__this.m_ReticleInstance, this.<reticalArgs>__0);
                    break;
                }
            }
            return false;
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

    [CompilerGenerated]
    private sealed class <ReticleAttackAnimation>c__IteratorC2 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Misdirection <>f__this;
        internal Hashtable <reticleAttackColorArgs>__1;
        internal Action<object> <reticleAttackColorUpdate>__0;
        internal Hashtable <reticleAttackRotArgs>__3;
        internal Hashtable <reticleAttackScaleArgs>__2;
        internal Hashtable <reticleFocusArgs>__5;
        internal Action<object> <reticleFocusUpdate>__4;

        internal void <>m__48(object col)
        {
            if (this.<>f__this.m_ReticleInstance != null)
            {
                this.<>f__this.m_ReticleInstance.GetComponent<RenderToTexture>().GetRenderMaterial().SetColor("_Color", (Color) col);
            }
        }

        internal void <>m__49(object amount)
        {
            if (this.<>f__this.m_ReticleInstance != null)
            {
                this.<>f__this.m_ReticleInstance.GetComponent<RenderToTexture>().GetRenderMaterial().SetFloat("_Blur", (float) amount);
            }
        }

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
                {
                    this.<reticleAttackColorUpdate>__0 = new Action<object>(this.<>m__48);
                    object[] args = new object[] { "time", this.<>f__this.m_ReticleAttackTime, "from", this.<>f__this.m_ReticleInstance.GetComponent<RenderToTexture>().GetRenderMaterial().color, "to", this.<>f__this.m_ReticleAttackColor, "onupdate", this.<reticleAttackColorUpdate>__0, "onupdatetarget", this.<>f__this.gameObject };
                    this.<reticleAttackColorArgs>__1 = iTween.Hash(args);
                    iTween.ValueTo(this.<>f__this.gameObject, this.<reticleAttackColorArgs>__1);
                    object[] objArray2 = new object[] { "time", this.<>f__this.m_ReticleAttackTime, "scale", this.<>f__this.m_ReticleAttackScale, "easetype", iTween.EaseType.easeOutBounce };
                    this.<reticleAttackScaleArgs>__2 = iTween.Hash(objArray2);
                    iTween.ScaleTo(this.<>f__this.m_ReticleInstance, this.<reticleAttackScaleArgs>__2);
                    object[] objArray3 = new object[] { "time", this.<>f__this.m_ReticleAttackTime, "rotation", this.<>f__this.m_ReticleAttackRotate, "easetype", iTween.EaseType.easeOutBounce };
                    this.<reticleAttackRotArgs>__3 = iTween.Hash(objArray3);
                    iTween.RotateTo(this.<>f__this.m_ReticleInstance, this.<reticleAttackRotArgs>__3);
                    this.<reticleFocusUpdate>__4 = new Action<object>(this.<>m__49);
                    object[] objArray4 = new object[] { "time", this.<>f__this.m_ReticleBlurFocusTime, "from", this.<>f__this.m_ReticleBlur, "to", 0f, "onupdate", this.<reticleFocusUpdate>__4, "onupdatetarget", this.<>f__this.gameObject };
                    this.<reticleFocusArgs>__5 = iTween.Hash(objArray4);
                    iTween.ValueTo(this.<>f__this.gameObject, this.<reticleFocusArgs>__5);
                    this.$current = new WaitForSeconds(this.<>f__this.m_ReticleBlurFocusTime + this.<>f__this.m_ReticleAttackHold);
                    this.$PC = 1;
                    return true;
                }
                case 1:
                    this.<>f__this.StartCoroutine(this.<>f__this.ReticleFadeOut());
                    break;
            }
            return false;
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

    [CompilerGenerated]
    private sealed class <ReticleFadeIn>c__IteratorC0 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Misdirection <>f__this;
        internal Hashtable <reticleAttackScaleArgs>__2;
        internal Hashtable <reticleFadeInArgs>__1;
        internal Action<object> <reticleFadeInUpdate>__0;

        internal void <>m__47(object amount)
        {
            this.<>f__this.m_ReticleInstance.GetComponent<RenderToTexture>().GetRenderMaterial().SetFloat("_Alpha", (float) amount);
        }

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            this.$PC = -1;
            if (this.$PC == 0)
            {
                this.<reticleFadeInUpdate>__0 = new Action<object>(this.<>m__47);
                object[] args = new object[] { "time", this.<>f__this.m_ReticleFadeInTime, "from", 0f, "to", 1f, "onupdate", this.<reticleFadeInUpdate>__0, "onupdatetarget", this.<>f__this.m_ReticleInstance.gameObject };
                this.<reticleFadeInArgs>__1 = iTween.Hash(args);
                iTween.ValueTo(this.<>f__this.m_ReticleInstance.gameObject, this.<reticleFadeInArgs>__1);
                object[] objArray2 = new object[] { "time", this.<>f__this.m_ReticleFadeInTime, "scale", Vector3.one, "easetype", iTween.EaseType.easeOutBounce };
                this.<reticleAttackScaleArgs>__2 = iTween.Hash(objArray2);
                iTween.ScaleTo(this.<>f__this.m_ReticleInstance.gameObject, this.<reticleAttackScaleArgs>__2);
            }
            return false;
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

    [CompilerGenerated]
    private sealed class <ReticleFadeOut>c__IteratorC3 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Misdirection <>f__this;
        internal Hashtable <reticleFadeOutArgs>__1;
        internal Action<object> <reticleFadeOutUpdate>__0;

        internal void <>m__4A(object amount)
        {
            if (this.<>f__this.m_ReticleInstance != null)
            {
                this.<>f__this.m_ReticleInstance.GetComponent<RenderToTexture>().GetRenderMaterial().SetFloat("_Alpha", (float) amount);
            }
        }

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
                {
                    this.<>f__this.OnSpellFinished();
                    this.<reticleFadeOutUpdate>__0 = new Action<object>(this.<>m__4A);
                    object[] args = new object[] { "time", this.<>f__this.m_ReticleFadeOutTime, "from", 1f, "to", 0f, "onupdate", this.<reticleFadeOutUpdate>__0, "onupdatetarget", this.<>f__this.gameObject };
                    this.<reticleFadeOutArgs>__1 = iTween.Hash(args);
                    iTween.ValueTo(this.<>f__this.gameObject, this.<reticleFadeOutArgs>__1);
                    this.$current = new WaitForSeconds(this.<>f__this.m_ReticleFadeOutTime);
                    this.$PC = 1;
                    return true;
                }
                case 1:
                    UnityEngine.Object.Destroy(this.<>f__this.m_ReticleInstance);
                    break;
            }
            return false;
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

