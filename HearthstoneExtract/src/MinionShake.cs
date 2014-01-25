using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MinionShake : MonoBehaviour
{
    private const float DISABLE_HEIGHT = 0.1f;
    private const float INTENSITY_LARGE = 1f;
    private const float INTENSITY_MEDIUM = 0.5f;
    private const float INTENSITY_SMALL = 0.1f;
    private float m_Angle;
    private bool m_Animating;
    private Animator m_Animator;
    private Transform m_CardPlayAllyTransform;
    private Vector2 m_ImpactDirection;
    private Vector3 m_ImpactPosition;
    private float m_IntensityValue = 0.5f;
    private Vector3 m_MinionOrgPos;
    private Quaternion m_MinionOrgRot;
    public GameObject m_MinionShakeAnimator;
    private GameObject m_MinionShakeInstance;
    private float m_Radius;
    private ShakeMinionIntensity m_ShakeIntensityType = ShakeMinionIntensity.MediumShake;
    private ShakeMinionType m_ShakeType = ShakeMinionType.RandomDirection;
    private float m_StartDelay;
    private const float MAX_START_DELAY = 0.5f;
    private readonly Vector3 OFFSCREEN_POSITION = new Vector3(-400f, -400f, -400f);
    private static int s_IdleState = Animator.StringToHash("Base.Idle");

    private Vector2 AngleToVector(float angle)
    {
        Vector3 vector = (Vector3) (Quaternion.Euler(0f, angle, 0f) * new Vector3(0f, 0f, -1f));
        return new Vector2(vector.x, vector.z);
    }

    private void Awake()
    {
    }

    private static MinionShake[] FindAllMinionShakers(GameObject shakeTrigger)
    {
        Card sourceCard = null;
        Spell spell = SceneUtils.FindComponentInThisOrParents<Spell>(shakeTrigger);
        if (spell != null)
        {
            sourceCard = spell.GetSourceCard();
        }
        List<MinionShake> list = new List<MinionShake>();
        foreach (Zone zone in ZoneMgr.Get().FindZonesForTag(TAG_ZONE.PLAY))
        {
            if (zone.GetType() != typeof(ZoneHero))
            {
                foreach (Card card2 in zone.GetCards())
                {
                    if (card2 != sourceCard)
                    {
                        MinionShake componentInChildren = card2.GetComponentInChildren<MinionShake>();
                        Log.Kyle.Print(string.Format("Minion Shake Search:{0}", card2));
                        if (componentInChildren != null)
                        {
                            list.Add(componentInChildren);
                            Log.Kyle.Print(string.Format("Minion Shake Found:{0}", card2));
                        }
                    }
                }
                continue;
            }
        }
        return list.ToArray();
    }

    public bool isShaking()
    {
        return this.m_Animating;
    }

    private void LateUpdate()
    {
        if ((this.m_Animating && (this.m_Animator != null)) && (this.m_MinionShakeInstance != null))
        {
            if ((this.m_Animator.GetCurrentAnimatorStateInfo(0).nameHash == s_IdleState) && !this.m_Animator.GetBool("shake"))
            {
                base.transform.localPosition = this.m_MinionOrgPos;
                base.transform.localRotation = this.m_MinionOrgRot;
                this.m_Animating = false;
            }
            else
            {
                base.transform.localPosition = this.m_CardPlayAllyTransform.localPosition + this.m_MinionOrgPos;
                base.transform.localRotation = this.m_MinionOrgRot;
                base.transform.Rotate(this.m_CardPlayAllyTransform.localRotation.eulerAngles);
            }
        }
    }

    private void OnDestroy()
    {
        if (this.m_MinionShakeInstance != null)
        {
            UnityEngine.Object.Destroy(this.m_MinionShakeInstance);
        }
    }

    public void RandomShake(float impact)
    {
        this.m_ShakeIntensityType = ShakeMinionIntensity.Custom;
        this.m_IntensityValue = impact;
        this.m_ShakeType = ShakeMinionType.Angle;
        this.m_ShakeType = ShakeMinionType.RandomDirection;
        this.ShakeMinion();
    }

    [DebuggerHidden]
    private IEnumerator ResetShakeAnimator()
    {
        return new <ResetShakeAnimator>c__IteratorFC { <>f__this = this };
    }

    public static void ShakeAllMinions(GameObject shakeTrigger, ShakeMinionType shakeType, Vector3 impactPoint, ShakeMinionIntensity intensityType, float intensityValue, float radius, float startDelay)
    {
        foreach (MinionShake shake in FindAllMinionShakers(shakeTrigger))
        {
            shake.m_StartDelay = 0f;
            shake.m_ShakeType = shakeType;
            shake.m_ImpactPosition = impactPoint;
            shake.m_ShakeIntensityType = intensityType;
            shake.m_IntensityValue = intensityValue;
            shake.m_Radius = radius;
            shake.ShakeMinion();
        }
    }

    public void ShakeAllMinionsRandomLarge()
    {
        Vector3 zero = Vector3.zero;
        Board board = Board.Get();
        if (board != null)
        {
            Transform transform = board.FindBone("CenterPointBone");
            if (transform != null)
            {
                zero = transform.position;
            }
        }
        ShakeAllMinions(base.gameObject, ShakeMinionType.RandomDirection, zero, ShakeMinionIntensity.LargeShake, 1f, 0f, 0f);
    }

    public void ShakeAllMinionsRandomMedium()
    {
        Vector3 zero = Vector3.zero;
        Board board = Board.Get();
        if (board != null)
        {
            Transform transform = board.FindBone("CenterPointBone");
            if (transform != null)
            {
                zero = transform.position;
            }
        }
        ShakeAllMinions(base.gameObject, ShakeMinionType.RandomDirection, zero, ShakeMinionIntensity.MediumShake, 0.5f, 0f, 0f);
    }

    private void ShakeMinion()
    {
        if (this.m_MinionShakeAnimator != null)
        {
            Vector3 zero = Vector3.zero;
            Board board = Board.Get();
            if (board != null)
            {
                Transform transform = board.FindBone("CenterPointBone");
                if (transform != null)
                {
                    zero = transform.position;
                }
            }
            if ((zero.y - base.transform.position.y) <= 0.1f)
            {
                if (this.m_MinionShakeInstance == null)
                {
                    this.m_MinionShakeInstance = (GameObject) UnityEngine.Object.Instantiate(this.m_MinionShakeAnimator, this.OFFSCREEN_POSITION, base.transform.rotation);
                    this.m_CardPlayAllyTransform = this.m_MinionShakeInstance.transform.FindChild("Card_Play_Ally").gameObject.transform;
                }
                if (this.m_Animator == null)
                {
                    this.m_Animator = this.m_MinionShakeInstance.GetComponent<Animator>();
                }
                if (!this.m_Animating)
                {
                    this.m_MinionOrgPos = base.transform.localPosition;
                    this.m_MinionOrgRot = base.transform.localRotation;
                }
                if (this.m_ShakeType == ShakeMinionType.Angle)
                {
                    this.m_ImpactDirection = this.AngleToVector(this.m_Angle);
                }
                else if (this.m_ShakeType == ShakeMinionType.ImpactDirection)
                {
                    this.m_ImpactDirection = Vector3.Normalize(base.transform.position - this.m_ImpactPosition);
                }
                else if (this.m_ShakeType == ShakeMinionType.RandomDirection)
                {
                    this.m_ImpactDirection = this.AngleToVector(UnityEngine.Random.Range((float) 0f, (float) 360f));
                }
                float intensityValue = this.m_IntensityValue;
                if (this.m_ShakeIntensityType == ShakeMinionIntensity.SmallShake)
                {
                    intensityValue = 0.1f;
                }
                else if (this.m_ShakeIntensityType == ShakeMinionIntensity.MediumShake)
                {
                    intensityValue = 0.5f;
                }
                else if (this.m_ShakeIntensityType == ShakeMinionIntensity.LargeShake)
                {
                    intensityValue = 1f;
                }
                this.m_ImpactDirection = (Vector2) (this.m_ImpactDirection * intensityValue);
                this.m_Animator.SetFloat("posx", this.m_ImpactDirection.x);
                this.m_Animator.SetFloat("posy", this.m_ImpactDirection.y);
                if ((this.m_Radius <= 0f) || (Vector3.Distance(base.transform.position, this.m_ImpactPosition) <= this.m_Radius))
                {
                    if (this.m_StartDelay > 0f)
                    {
                        if (this.m_StartDelay > 0.5f)
                        {
                            this.m_StartDelay = 0.5f;
                        }
                        base.StartCoroutine(this.StartShakeAnimation());
                    }
                    else
                    {
                        this.m_Animating = true;
                        this.m_Animator.SetBool("shake", true);
                    }
                    base.StartCoroutine(this.ResetShakeAnimator());
                }
            }
        }
    }

    public static void ShakeTargetMinion(GameObject shakeTarget, ShakeMinionType shakeType, Vector3 impactPoint, ShakeMinionIntensity intensityType, float intensityValue, float radius, float startDelay)
    {
        GameObject visualTarget = SceneUtils.FindComponentInThisOrParents<Spell>(shakeTarget).GetVisualTarget();
        if (visualTarget != null)
        {
            MinionShake componentInChildren = visualTarget.GetComponentInChildren<MinionShake>();
            if (componentInChildren != null)
            {
                componentInChildren.m_StartDelay = 0f;
                componentInChildren.m_ShakeType = shakeType;
                componentInChildren.m_ImpactPosition = impactPoint;
                componentInChildren.m_ShakeIntensityType = intensityType;
                componentInChildren.m_IntensityValue = intensityValue;
                componentInChildren.m_Radius = radius;
                componentInChildren.ShakeMinion();
            }
        }
    }

    private void Start()
    {
    }

    [DebuggerHidden]
    private IEnumerator StartShakeAnimation()
    {
        return new <StartShakeAnimation>c__IteratorFB { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <ResetShakeAnimator>c__IteratorFC : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MinionShake <>f__this;

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
                    this.$current = new WaitForSeconds(this.<>f__this.m_StartDelay);
                    this.$PC = 1;
                    goto Label_009D;

                case 1:
                    this.$current = new WaitForEndOfFrame();
                    this.$PC = 2;
                    goto Label_009D;

                case 2:
                    this.$current = new WaitForEndOfFrame();
                    this.$PC = 3;
                    goto Label_009D;

                case 3:
                    this.<>f__this.m_Animator.SetBool("shake", false);
                    break;
            }
            return false;
        Label_009D:
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

    [CompilerGenerated]
    private sealed class <StartShakeAnimation>c__IteratorFB : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal MinionShake <>f__this;

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
                    this.$current = new WaitForSeconds(this.<>f__this.m_StartDelay);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.m_Animating = true;
                    this.<>f__this.m_Animator.SetBool("shake", true);
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

