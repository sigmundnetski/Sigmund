using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VictoryTwoScoop : EndGameTwoScoop
{
    private const float GOD_RAY_ANGLE = 20f;
    private const float GOD_RAY_DURATION = 20f;
    private const float LAUREL_ROTATION = 2f;
    public GameObject m_crown;
    public GameObject m_godRays;
    public GameObject m_godRays2;
    public GameObject m_leftBanner;
    public GameObject m_leftCloud;
    public GameObject m_leftLaurel;
    public GameObject m_leftTrumpet;
    public GameObject m_rightBanner;
    public GameObject m_rightCloud;
    public GameObject m_rightLaurel;
    public GameObject m_rightTrumpet;

    [DebuggerHidden]
    private IEnumerator AnimateAll()
    {
        return new <AnimateAll>c__Iterator33 { <>f__this = this };
    }

    private void AnimateCrownFro()
    {
        object[] args = new object[] { "z", -0.834f, "time", 5, "isLocal", true, "easetype", iTween.EaseType.easeInOutBack, "oncomplete", "AnimateCrownTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(this.m_crown, hashtable);
    }

    private void AnimateCrownTo()
    {
        object[] args = new object[] { "z", -0.92f, "time", 5, "isLocal", true, "easetype", iTween.EaseType.easeInOutBack, "oncomplete", "AnimateCrownFro", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(this.m_crown, hashtable);
    }

    private void AnimateGodraysFro()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, 20f, 0f), "time", 20f, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "AnimateGodraysTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_godRays, hashtable);
        object[] objArray2 = new object[] { "rotation", new Vector3(0f, -20f, 0f), "time", 20f, "isLocal", true, "easetype", iTween.EaseType.linear };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.RotateTo(this.m_godRays2, hashtable2);
    }

    private void AnimateGodraysTo()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, -20f, 0f), "time", 20f, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "AnimateGodraysFro", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_godRays, hashtable);
        object[] objArray2 = new object[] { "rotation", new Vector3(0f, 20f, 0f), "time", 20f, "isLocal", true, "easetype", iTween.EaseType.linear };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.RotateTo(this.m_godRays2, hashtable2);
    }

    private void CloudFro()
    {
        object[] args = new object[] { "x", -1.227438f, "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "CloudTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(this.m_rightCloud, hashtable);
        object[] objArray2 = new object[] { "x", 1.053244f, "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.MoveTo(this.m_leftCloud, hashtable2);
    }

    private void CloudTo()
    {
        object[] args = new object[] { "x", -0.92f, "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "CloudFro", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(this.m_rightCloud, hashtable);
        object[] objArray2 = new object[] { "x", 0.82f, "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.MoveTo(this.m_leftCloud, hashtable2);
    }

    private void LaurelWaveFro()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, 2f, 0f), "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "LaurelWaveTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_rightLaurel, hashtable);
        object[] objArray2 = new object[] { "rotation", new Vector3(0f, -2f, 0f), "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.RotateTo(this.m_leftLaurel, hashtable2);
    }

    private void LaurelWaveTo()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, 0f, 0f), "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "LaurelWaveFro", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_rightLaurel, hashtable);
        object[] objArray2 = new object[] { "rotation", new Vector3(0f, 0f, 0f), "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.RotateTo(this.m_leftLaurel, hashtable2);
    }

    protected override void PositionProgressMedalBarBanner()
    {
        Transform transform = base.m_medalBanner.transform;
        transform.parent = base.transform;
        transform.localPosition = new Vector3(0.025f, 0.087f, 0.92f);
        transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        transform.localScale = new Vector3(0.36f, 0.36f, 0.36f);
    }

    protected override void ResetPositions()
    {
        base.gameObject.transform.position = EndGameTwoScoop.START_POSITION;
        base.gameObject.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        this.m_rightTrumpet.transform.localPosition = new Vector3(0.23f, -0.6f, 0.16f);
        this.m_rightTrumpet.transform.localScale = new Vector3(1f, 1f, 1f);
        this.m_leftTrumpet.transform.localPosition = new Vector3(-0.23f, -0.6f, 0.16f);
        this.m_leftTrumpet.transform.localScale = new Vector3(-1f, 1f, 1f);
        this.m_rightBanner.transform.localScale = new Vector3(1f, 1f, 0.08f);
        this.m_leftBanner.transform.localScale = new Vector3(1f, 1f, 0.08f);
        this.m_rightCloud.transform.localPosition = new Vector3(-0.2f, -0.8f, 0.26f);
        this.m_leftCloud.transform.localPosition = new Vector3(0.16f, -0.8f, 0.2f);
        this.m_godRays.transform.localEulerAngles = new Vector3(0f, 29f, 0f);
        this.m_godRays2.transform.localEulerAngles = new Vector3(0f, -29f, 0f);
        this.m_crown.transform.localPosition = new Vector3(-0.041f, -0.2f, -0.834f);
        this.m_rightLaurel.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
        this.m_rightLaurel.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        this.m_leftLaurel.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
        this.m_leftLaurel.transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
    }

    protected override void ShowImpl()
    {
        base.m_heroActor.SetEntityDef(GameState.Get().GetLocalPlayer().GetHero().GetEntityDef());
        base.m_heroActor.SetCardDef(GameState.Get().GetLocalPlayer().GetHero().GetCard().GetCardDef());
        base.m_heroActor.UpdateAllComponents();
        base.m_heroActor.TurnOffCollider();
        base.m_medalBanner.SetWinsLabel(GameStrings.Get("GLOBAL_WINS"));
        base.SaveBannerText(GameStrings.Get("GAMEPLAY_END_OF_GAME_VICTORY"));
        base.SetBannerLabel(GameStrings.Get("GAMEPLAY_END_OF_GAME_VICTORY"));
        base.GetComponent<PlayMakerFSM>().SendEvent("Action");
        iTween.FadeTo(base.gameObject, 1f, 0.25f);
        base.gameObject.transform.localScale = new Vector3(EndGameTwoScoop.START_SCALE_VAL, EndGameTwoScoop.START_SCALE_VAL, EndGameTwoScoop.START_SCALE_VAL);
        object[] args = new object[] { "scale", new Vector3(EndGameTwoScoop.END_SCALE_VAL, EndGameTwoScoop.END_SCALE_VAL, EndGameTwoScoop.END_SCALE_VAL), "time", 0.5f, "oncomplete", "PunchEndGameTwoScoop", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ScaleTo(base.gameObject, hashtable);
        object[] objArray2 = new object[] { "position", base.gameObject.transform.position + new Vector3(0.005f, 0.005f, 0.005f), "time", 1.5f, "oncomplete", "TokyoDriftTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.MoveTo(base.gameObject, hashtable2);
        this.AnimateGodraysTo();
        this.AnimateCrownTo();
        base.StartCoroutine(this.AnimateAll());
    }

    private void TokyoDriftFro()
    {
        object[] args = new object[] { "position", EndGameTwoScoop.START_POSITION, "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "TokyoDriftTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(base.gameObject, hashtable);
    }

    private void TokyoDriftTo()
    {
        object[] args = new object[] { "position", EndGameTwoScoop.START_POSITION + new Vector3(0.2f, 0.2f, 0.2f), "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "TokyoDriftFro", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(base.gameObject, hashtable);
    }

    [CompilerGenerated]
    private sealed class <AnimateAll>c__Iterator33 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal VictoryTwoScoop <>f__this;
        internal Hashtable <bannerScaleArgsLeft>__6;
        internal Hashtable <bannerScaleArgsRight>__5;
        internal Hashtable <cloudMoveArgsLeft>__8;
        internal Hashtable <cloudMoveArgsRight>__7;
        internal Hashtable <laurelRotateArgsLeft>__11;
        internal Hashtable <laurelRotateArgsRight>__9;
        internal Hashtable <laurelScaleArgsLeft>__12;
        internal Hashtable <laurelScaleArgsRight>__10;
        internal float <TRUMPET_OUT_TIME>__0;
        internal Hashtable <trumpetMoveArgsLeft>__2;
        internal Hashtable <trumpetMoveArgsRight>__1;
        internal Hashtable <trumpetScaleArgsLeft>__4;
        internal Hashtable <trumpetScaleArgsRight>__3;

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
                    this.$current = new WaitForSeconds(0.25f);
                    this.$PC = 1;
                    return true;

                case 1:
                {
                    this.<TRUMPET_OUT_TIME>__0 = 0.4f;
                    object[] args = new object[] { "position", new Vector3(-0.52f, -0.6f, -0.23f), "time", this.<TRUMPET_OUT_TIME>__0, "isLocal", true, "easetype", iTween.EaseType.easeOutElastic };
                    this.<trumpetMoveArgsRight>__1 = iTween.Hash(args);
                    iTween.MoveTo(this.<>f__this.m_rightTrumpet, this.<trumpetMoveArgsRight>__1);
                    object[] objArray2 = new object[] { "position", new Vector3(0.44f, -0.6f, -0.23f), "time", this.<TRUMPET_OUT_TIME>__0, "isLocal", true, "easetype", iTween.EaseType.easeOutElastic };
                    this.<trumpetMoveArgsLeft>__2 = iTween.Hash(objArray2);
                    iTween.MoveTo(this.<>f__this.m_leftTrumpet, this.<trumpetMoveArgsLeft>__2);
                    object[] objArray3 = new object[] { "scale", new Vector3(1.1f, 1.1f, 1.1f), "time", 0.25f, "delay", 0.3f, "isLocal", true, "easetype", iTween.EaseType.easeOutBounce };
                    this.<trumpetScaleArgsRight>__3 = iTween.Hash(objArray3);
                    iTween.ScaleTo(this.<>f__this.m_rightTrumpet, this.<trumpetScaleArgsRight>__3);
                    object[] objArray4 = new object[] { "scale", new Vector3(-1.1f, 1.1f, 1.1f), "time", 0.25f, "delay", 0.3f, "isLocal", true, "easetype", iTween.EaseType.easeOutBounce };
                    this.<trumpetScaleArgsLeft>__4 = iTween.Hash(objArray4);
                    iTween.ScaleTo(this.<>f__this.m_leftTrumpet, this.<trumpetScaleArgsLeft>__4);
                    object[] objArray5 = new object[] { "z", 1, "delay", 0.24f, "time", 1f, "isLocal", true, "easetype", iTween.EaseType.easeOutElastic };
                    this.<bannerScaleArgsRight>__5 = iTween.Hash(objArray5);
                    iTween.ScaleTo(this.<>f__this.m_rightBanner, this.<bannerScaleArgsRight>__5);
                    object[] objArray6 = new object[] { "z", 1, "delay", 0.24f, "time", 1f, "isLocal", true, "easetype", iTween.EaseType.easeOutElastic };
                    this.<bannerScaleArgsLeft>__6 = iTween.Hash(objArray6);
                    iTween.ScaleTo(this.<>f__this.m_leftBanner, this.<bannerScaleArgsLeft>__6);
                    object[] objArray7 = new object[] { "x", -1.227438, "time", 5, "isLocal", true, "easetype", iTween.EaseType.easeOutCubic, "oncomplete", "CloudTo", "oncompletetarget", this.<>f__this.gameObject };
                    this.<cloudMoveArgsRight>__7 = iTween.Hash(objArray7);
                    iTween.MoveTo(this.<>f__this.m_rightCloud, this.<cloudMoveArgsRight>__7);
                    object[] objArray8 = new object[] { "x", 1.053244, "time", 5, "isLocal", true, "easetype", iTween.EaseType.easeOutCubic };
                    this.<cloudMoveArgsLeft>__8 = iTween.Hash(objArray8);
                    iTween.MoveTo(this.<>f__this.m_leftCloud, this.<cloudMoveArgsLeft>__8);
                    object[] objArray9 = new object[] { "rotation", new Vector3(0f, 2f, 0f), "time", 0.5f, "isLocal", true, "easetype", iTween.EaseType.easeOutElastic, "oncomplete", "LaurelWaveTo", "oncompletetarget", this.<>f__this.gameObject };
                    this.<laurelRotateArgsRight>__9 = iTween.Hash(objArray9);
                    iTween.RotateTo(this.<>f__this.m_rightLaurel, this.<laurelRotateArgsRight>__9);
                    object[] objArray10 = new object[] { "scale", new Vector3(1f, 1f, 1f), "time", 0.25f, "isLocal", true, "easetype", iTween.EaseType.easeOutBounce };
                    this.<laurelScaleArgsRight>__10 = iTween.Hash(objArray10);
                    iTween.ScaleTo(this.<>f__this.m_rightLaurel, this.<laurelScaleArgsRight>__10);
                    object[] objArray11 = new object[] { "rotation", new Vector3(0f, -2f, 0f), "time", 0.5f, "isLocal", true, "easetype", iTween.EaseType.easeOutElastic };
                    this.<laurelRotateArgsLeft>__11 = iTween.Hash(objArray11);
                    iTween.RotateTo(this.<>f__this.m_leftLaurel, this.<laurelRotateArgsLeft>__11);
                    object[] objArray12 = new object[] { "scale", new Vector3(-1f, 1f, 1f), "time", 0.25f, "isLocal", true, "easetype", iTween.EaseType.easeOutBounce };
                    this.<laurelScaleArgsLeft>__12 = iTween.Hash(objArray12);
                    iTween.ScaleTo(this.<>f__this.m_leftLaurel, this.<laurelScaleArgsLeft>__12);
                    this.$PC = -1;
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
}

