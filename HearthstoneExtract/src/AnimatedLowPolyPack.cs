using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimatedLowPolyPack : MonoBehaviour
{
    private static readonly Color DIMMED_COLOR = new Color(0.514f, 0.443f, 0.443f);
    private static readonly Color FULLY_LIT_COLOR = Color.white;
    private Vector3 m_flyInLocalAngles = Vector3.zero;
    private Vector3 m_flyOutLocalAngles = Vector3.zero;
    private State m_state;
    private Vector3 m_targetLocalPos = Vector3.zero;
    private Vector3 m_targetOffScreenLocalPos = Vector3.zero;
    private static readonly string POSITION_TWEEN_NAME = "position";
    private static readonly Vector3 PUNCH_POSITION_AMOUNT = new Vector3(0f, 5f, 0f);
    private static readonly float PUNCH_POSITION_TIME = 0.25f;

    private void Awake()
    {
        this.Dim(false);
    }

    public void Dim(bool dim)
    {
        base.renderer.material.SetColor("_Color", !dim ? FULLY_LIT_COLOR : DIMMED_COLOR);
    }

    public bool FlyIn(float animTime, float delay)
    {
        if (this.m_state == State.FLOWN_IN)
        {
            return false;
        }
        if (this.m_state == State.FLYING_IN)
        {
            return false;
        }
        this.m_state = State.FLYING_IN;
        base.gameObject.SetActive(true);
        base.transform.localEulerAngles = this.m_flyInLocalAngles;
        object[] args = new object[] { "position", this.m_targetLocalPos, "isLocal", true, "time", animTime, "delay", delay, "easetype", iTween.EaseType.easeInCubic, "name", POSITION_TWEEN_NAME, "oncomplete", "OnFlownIn", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(base.gameObject, POSITION_TWEEN_NAME);
        iTween.MoveTo(base.gameObject, hashtable);
        return true;
    }

    public void FlyInImmediate()
    {
        iTween.StopByName(base.gameObject, POSITION_TWEEN_NAME);
        base.transform.localEulerAngles = this.m_flyInLocalAngles;
        base.transform.localPosition = this.m_targetLocalPos;
        this.m_state = State.FLOWN_IN;
        base.gameObject.SetActive(true);
    }

    public bool FlyOut(float animTime, float delay)
    {
        if (this.m_state == State.HIDDEN)
        {
            return false;
        }
        if (this.m_state == State.FLYING_OUT)
        {
            return false;
        }
        this.m_state = State.FLYING_OUT;
        base.transform.localEulerAngles = this.m_flyOutLocalAngles;
        object[] args = new object[] { "position", this.m_targetOffScreenLocalPos, "isLocal", true, "time", animTime, "delay", delay, "easetype", iTween.EaseType.linear, "name", POSITION_TWEEN_NAME, "oncomplete", "OnHidden", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(base.gameObject, POSITION_TWEEN_NAME);
        iTween.MoveTo(base.gameObject, hashtable);
        SoundManager.Get().LoadAndPlay("purchase_pack_lift_whoosh_1");
        return true;
    }

    public void FlyOutImmediate()
    {
        iTween.StopByName(base.gameObject, POSITION_TWEEN_NAME);
        base.transform.localEulerAngles = this.m_flyOutLocalAngles;
        base.transform.localPosition = this.m_targetOffScreenLocalPos;
        this.OnHidden();
    }

    public void Init(int column, Vector3 targetLocalPos, Vector3 offScreenOffset)
    {
        this.m_targetLocalPos = targetLocalPos;
        this.m_targetOffScreenLocalPos = targetLocalPos + offScreenOffset;
        this.Column = column;
        SceneUtils.SetLayer(base.gameObject, GameLayer.IgnoreFullScreenEffects);
        this.PositionOffScreen();
    }

    private void OnFlownIn()
    {
        this.m_state = State.FLOWN_IN;
        iTween.PunchPosition(base.gameObject, PUNCH_POSITION_AMOUNT, PUNCH_POSITION_TIME);
        SoundManager.Get().LoadAndPlay("purchase_pack_drop_impact_1");
    }

    private void OnHidden()
    {
        this.m_state = State.HIDDEN;
        base.gameObject.SetActive(false);
    }

    private void PositionOffScreen()
    {
        iTween.StopByName(base.gameObject, POSITION_TWEEN_NAME);
        base.transform.localPosition = this.m_targetOffScreenLocalPos;
        this.OnHidden();
    }

    public void SetFlyingLocalRotations(Vector3 flyInLocalAngles, Vector3 flyOutLocalAngles)
    {
        this.m_flyInLocalAngles = flyInLocalAngles;
        this.m_flyOutLocalAngles = flyOutLocalAngles;
    }

    public int Column { get; private set; }

    private enum State
    {
        UNKNOWN,
        FLOWN_IN,
        FLYING_IN,
        FLYING_OUT,
        HIDDEN
    }
}

