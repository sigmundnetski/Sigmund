using System;
using System.Collections.Generic;
using UnityEngine;

public class Gryphon : MonoBehaviour
{
    private static int cleanState = Animator.StringToHash("Base Layer.Clean");
    private static int lookState = Animator.StringToHash("Base Layer.Look");
    private Animator m_Animator;
    private AnimatorStateInfo m_CurrentBaseLayerState;
    private EndTurnButton m_EndTurnButton;
    private Transform m_EndTurnButtonTransform;
    public Transform m_HeadBone;
    public float m_HeadRotationSpeed = 15f;
    private float m_LastSnapTime = -1f;
    public int m_LookAtHeroesPercent = 20;
    private Vector3 m_LookAtPosition;
    private bool m_LookAtTarget;
    public int m_LookAtTurnButtonPercent = 0x4b;
    private bool m_LookingAtEndTurnButton;
    public float m_MaxFocusTime = 5.5f;
    public float m_MinFocusTime = 1.2f;
    public float m_MinSnapTime = 2f;
    public int m_PlayAnimationPercent = 20;
    private float m_RandomWeightsTotal;
    private AudioSource m_ScreechSound;
    public GameObject m_SnapCollider;
    private float m_SnapStartTime = -1f;
    public float m_SnapWaitTime = 1f;
    public float m_TurnButtonLookAwayTime = 0.5f;
    private UniversalInputManager m_UniversalInputManager;
    private float m_WaitStartTime;
    private float m_WaitTime = 1f;
    private static int screechState = Animator.StringToHash("Base Layer.Screech");
    private static int snapState = Animator.StringToHash("Base Layer.Snap");

    private void AniamteHead()
    {
        if (this.m_LookAtTarget)
        {
            Vector3 forward = this.m_LookAtPosition - this.m_HeadBone.position;
            Quaternion to = Quaternion.LookRotation(forward);
            this.m_HeadBone.rotation = Quaternion.Slerp(this.m_HeadBone.rotation, to, UnityEngine.Time.deltaTime * this.m_HeadRotationSpeed);
        }
    }

    private void FindEndTurnButton()
    {
        this.m_EndTurnButton = EndTurnButton.Get();
        if (this.m_EndTurnButton != null)
        {
            this.m_EndTurnButtonTransform = this.m_EndTurnButton.transform;
        }
    }

    private void FindSomethingToLookAt()
    {
        List<Vector3> list = new List<Vector3>();
        ZoneMgr mgr = ZoneMgr.Get();
        if (mgr == null)
        {
            this.PlayAniamtion();
        }
        else
        {
            foreach (ZonePlay play in mgr.FindZonesOfType<ZonePlay>())
            {
                foreach (Card card in play.GetCards())
                {
                    if (card.IsMousedOver())
                    {
                        this.m_LookAtPosition = card.transform.position;
                        this.m_LookAtTarget = true;
                        return;
                    }
                    list.Add(card.transform.position);
                }
            }
            if (UnityEngine.Random.Range(0, 100) < this.m_LookAtHeroesPercent)
            {
                foreach (ZoneHero hero in ZoneMgr.Get().FindZonesOfType<ZoneHero>())
                {
                    foreach (Card card2 in hero.GetCards())
                    {
                        if (card2.IsMousedOver())
                        {
                            this.m_LookAtPosition = card2.transform.position;
                            this.m_LookAtTarget = true;
                            return;
                        }
                        list.Add(card2.transform.position);
                    }
                }
            }
            if (list.Count > 0)
            {
                int num = UnityEngine.Random.Range(0, list.Count);
                this.m_LookAtPosition = list[num];
                this.m_LookAtTarget = true;
            }
            else
            {
                this.m_LookAtTarget = false;
                this.PlayAniamtion();
            }
        }
    }

    private void LateUpdate()
    {
        bool flag = false;
        bool mouseButtonDown = false;
        this.m_CurrentBaseLayerState = this.m_Animator.GetCurrentAnimatorStateInfo(0);
        if (((this.m_CurrentBaseLayerState.nameHash != lookState) && (this.m_CurrentBaseLayerState.nameHash != cleanState)) && (this.m_CurrentBaseLayerState.nameHash != screechState))
        {
            this.m_Animator.SetBool("Look", false);
            this.m_Animator.SetBool("Clean", false);
            if (this.m_UniversalInputManager != null)
            {
                if (this.m_SnapCollider != null)
                {
                    if (UniversalInputManager.IsTouchDevice != null)
                    {
                        if (Input.GetMouseButton(0))
                        {
                            flag = this.m_UniversalInputManager.InputIsOver(this.m_SnapCollider);
                        }
                    }
                    else
                    {
                        flag = this.m_UniversalInputManager.InputIsOver(this.m_SnapCollider);
                    }
                }
                if (this.m_UniversalInputManager.InputIsOver(base.gameObject))
                {
                    mouseButtonDown = Input.GetMouseButtonDown(0);
                }
                if (mouseButtonDown)
                {
                    this.m_Animator.SetBool("Screech", true);
                    SoundManager.Get().Play(this.m_ScreechSound);
                }
                else
                {
                    this.m_Animator.SetBool("Screech", false);
                }
                if (flag)
                {
                    if (this.m_CurrentBaseLayerState.nameHash == snapState)
                    {
                        this.m_Animator.SetBool("Snap", false);
                    }
                    else
                    {
                        if (this.m_LastSnapTime < 0f)
                        {
                            this.m_LastSnapTime = UnityEngine.Time.time;
                        }
                        if ((UnityEngine.Time.time - this.m_LastSnapTime) > this.m_MinSnapTime)
                        {
                            if (this.m_SnapStartTime < 0f)
                            {
                                this.m_SnapStartTime = UnityEngine.Time.time;
                            }
                            if ((UnityEngine.Time.time - this.m_SnapStartTime) > this.m_SnapWaitTime)
                            {
                                this.m_Animator.SetBool("Snap", true);
                                this.m_LastSnapTime = UnityEngine.Time.time;
                                this.m_SnapStartTime = -1f;
                                this.m_WaitStartTime = 0f;
                            }
                        }
                    }
                    RaycastHit hitInfo = new RaycastHit();
                    this.m_UniversalInputManager.GetInputHitInfo(out hitInfo);
                    this.m_LookAtPosition = hitInfo.point;
                    this.AniamteHead();
                    return;
                }
                this.m_Animator.SetBool("Snap", false);
            }
            if (this.m_LookingAtEndTurnButton)
            {
                if (this.m_EndTurnButton.IsInNMPState())
                {
                    this.m_WaitStartTime = 0f;
                    this.m_LookAtPosition = this.m_EndTurnButtonTransform.position;
                }
                else if ((UnityEngine.Time.time - this.m_WaitStartTime) > this.m_TurnButtonLookAwayTime)
                {
                    this.m_WaitTime = UnityEngine.Random.Range(this.m_MinFocusTime, this.m_MaxFocusTime);
                    this.FindSomethingToLookAt();
                    this.m_LookingAtEndTurnButton = false;
                }
            }
            else if ((UnityEngine.Time.time - this.m_WaitStartTime) > this.m_WaitTime)
            {
                this.m_WaitStartTime = UnityEngine.Time.time;
                this.m_WaitTime = UnityEngine.Random.Range(this.m_MinFocusTime, this.m_MaxFocusTime);
                if (UnityEngine.Random.Range(0, 100) < this.m_PlayAnimationPercent)
                {
                    this.m_LookAtTarget = false;
                    this.PlayAniamtion();
                    return;
                }
                this.FindSomethingToLookAt();
                if (UnityEngine.Random.Range(0, 100) < this.m_LookAtTurnButtonPercent)
                {
                    this.LookAtTurnButton();
                }
            }
            this.AniamteHead();
        }
    }

    private bool LookAtTurnButton()
    {
        if (this.m_EndTurnButton == null)
        {
            this.FindEndTurnButton();
        }
        if (this.m_EndTurnButton != null)
        {
            if (this.m_EndTurnButton.IsInNMPState() && (this.m_EndTurnButtonTransform != null))
            {
                this.m_LookAtPosition = this.m_EndTurnButtonTransform.position;
                this.m_LookAtTarget = true;
                this.m_LookingAtEndTurnButton = true;
                return true;
            }
            this.m_LookingAtEndTurnButton = false;
        }
        return false;
    }

    private void PlayAniamtion()
    {
        if (UnityEngine.Random.value > 0.2f)
        {
            this.m_Animator.SetBool("Look", true);
        }
        else
        {
            this.m_Animator.SetBool("Clean", true);
        }
    }

    private void Start()
    {
        this.m_Animator = base.GetComponent<Animator>();
        this.m_UniversalInputManager = UniversalInputManager.Get();
        this.m_ScreechSound = base.GetComponent<AudioSource>();
        this.m_Animator.SetLayerWeight(1, 1f);
    }
}

