using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DefeatTwoScoop : EndGameTwoScoop
{
    public GameObject m_crown;
    public GameObject m_defeatBanner;
    public GameObject m_leftBanner;
    public GameObject m_leftBannerFront;
    public GameObject m_leftCloud;
    public GameObject m_leftTrumpet;
    public GameObject m_rightBanner;
    public GameObject m_rightBannerShred;
    public GameObject m_rightCloud;
    public GameObject m_rightTrumpet;

    [DebuggerHidden]
    private IEnumerator AnimateAll()
    {
        return new <AnimateAll>c__Iterator32 { <>f__this = this };
    }

    private void AnimateCrownFro()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, 17f, 0f), "time", 0.75f, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "AnimateCrownTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_crown, hashtable);
    }

    private void AnimateCrownTo()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, 1.8f, 0f), "time", 0.75f, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "AnimateCrownFro", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_crown, hashtable);
    }

    private void AnimateLeftTrumpetFro()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, -180f, 0f), "time", 5f, "isLocal", true, "easetype", iTween.EaseType.easeInOutCirc, "oncomplete", "AnimateLeftTrumpetTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_leftTrumpet, hashtable);
    }

    private void AnimateLeftTrumpetTo()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, -184f, 0f), "time", 5f, "isLocal", true, "easetype", iTween.EaseType.easeInOutCirc, "oncomplete", "AnimateLeftTrumpetFro", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_leftTrumpet, hashtable);
    }

    private void AnimateRightTrumpetFro()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, -180f, 0f), "time", 8f, "isLocal", true, "easetype", iTween.EaseType.easeInOutCirc, "oncomplete", "AnimateRightTrumpetTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_rightTrumpet, hashtable);
    }

    private void AnimateRightTrumpetTo()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, -172f, 0f), "time", 8f, "isLocal", true, "easetype", iTween.EaseType.easeInOutCirc, "oncomplete", "AnimateRightTrumpetFro", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_rightTrumpet, hashtable);
    }

    private void AnimateWoodBannerFro()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, 215f, 0f), "time", 5f, "isLocal", true, "easetype", iTween.EaseType.easeInOutCirc, "oncomplete", "AnimateWoodBannerTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_defeatBanner, hashtable);
    }

    private void AnimateWoodBannerTo()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, 223f, 0f), "time", 5f, "isLocal", true, "easetype", iTween.EaseType.easeInOutCirc, "oncomplete", "AnimateWoodBannerFro", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.RotateTo(this.m_defeatBanner, hashtable);
    }

    private void CloudFro()
    {
        object[] args = new object[] { "x", -0.81f, "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "CloudTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(this.m_rightCloud, hashtable);
        object[] objArray2 = new object[] { "x", 0.824f, "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.MoveTo(this.m_leftCloud, hashtable2);
    }

    private void CloudTo()
    {
        object[] args = new object[] { "x", -0.38f, "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear, "oncomplete", "CloudFro", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.MoveTo(this.m_rightCloud, hashtable);
        object[] objArray2 = new object[] { "x", 0.443f, "time", 10, "isLocal", true, "easetype", iTween.EaseType.linear };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.MoveTo(this.m_leftCloud, hashtable2);
    }

    protected override void PositionProgressMedalBarBanner()
    {
        Transform transform = base.m_medalBanner.transform;
        transform.parent = this.m_defeatBanner.transform;
        transform.localPosition = new Vector3(0.67f, 0.075f, -1.64f);
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
    }

    protected override void ResetPositions()
    {
        base.gameObject.transform.position = EndGameTwoScoop.START_POSITION;
        base.gameObject.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        this.m_rightTrumpet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        this.m_rightTrumpet.transform.localEulerAngles = new Vector3(0f, -180f, 0f);
        this.m_leftTrumpet.transform.localEulerAngles = new Vector3(0f, -180f, 0f);
        this.m_rightBanner.transform.localScale = new Vector3(1f, 1f, -0.0375f);
        this.m_rightBannerShred.transform.localScale = new Vector3(1f, 1f, 0.05f);
        this.m_rightCloud.transform.localPosition = new Vector3(-0.036f, -0.28f, 0.46f);
        this.m_leftCloud.transform.localPosition = new Vector3(-0.047f, -0.3f, 0.41f);
        this.m_crown.transform.localEulerAngles = new Vector3(-0.026f, 17f, 0.2f);
        this.m_defeatBanner.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
    }

    protected override void ShowImpl()
    {
        base.m_heroActor.SetEntityDef(GameState.Get().GetLocalPlayer().GetHero().GetEntityDef());
        base.m_heroActor.SetCardDef(GameState.Get().GetLocalPlayer().GetHero().GetCard().GetCardDef());
        base.m_heroActor.UpdateAllComponents();
        base.m_heroActor.TurnOffCollider();
        base.m_medalBanner.SetWinsLabel(GameStrings.Get("GLOBAL_WINS"));
        base.SaveBannerText(GameStrings.Get("GAMEPLAY_END_OF_GAME_DEFEAT"));
        base.SetBannerLabel(GameStrings.Get("GAMEPLAY_END_OF_GAME_DEFEAT"));
        base.GetComponent<PlayMakerFSM>().SendEvent("Action");
        iTween.FadeTo(base.gameObject, 1f, 0.25f);
        base.gameObject.transform.localScale = new Vector3(EndGameTwoScoop.START_SCALE_VAL, EndGameTwoScoop.START_SCALE_VAL, EndGameTwoScoop.START_SCALE_VAL);
        object[] args = new object[] { "scale", new Vector3(EndGameTwoScoop.END_SCALE_VAL, EndGameTwoScoop.END_SCALE_VAL, EndGameTwoScoop.END_SCALE_VAL), "time", 0.5f, "oncomplete", "PunchEndGameTwoScoop", "oncompletetarget", base.gameObject, "easetype", iTween.EaseType.easeOutBounce };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ScaleTo(base.gameObject, hashtable);
        object[] objArray2 = new object[] { "position", base.gameObject.transform.position + new Vector3(0.005f, 0.005f, 0.005f), "time", 1.5f, "oncomplete", "TokyoDriftTo", "oncompletetarget", base.gameObject };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.MoveTo(base.gameObject, hashtable2);
        this.AnimateCrownTo();
        this.AnimateLeftTrumpetTo();
        this.AnimateRightTrumpetTo();
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
    private sealed class <AnimateAll>c__Iterator32 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal DefeatTwoScoop <>f__this;
        internal Hashtable <bannerScaleArgsRight>__1;
        internal Hashtable <bannerShredScaleArgsRight>__2;
        internal Hashtable <cloudMoveArgsLeft>__4;
        internal Hashtable <cloudMoveArgsRight>__3;
        internal Hashtable <trumpetScaleArgsRight>__0;
        internal Hashtable <woodBannerRotateArgs>__5;

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
                    object[] args = new object[] { "scale", new Vector3(1f, 1f, 1.1f), "time", 0.25f, "isLocal", true, "easetype", iTween.EaseType.easeOutBounce };
                    this.<trumpetScaleArgsRight>__0 = iTween.Hash(args);
                    iTween.ScaleTo(this.<>f__this.m_rightTrumpet, this.<trumpetScaleArgsRight>__0);
                    object[] objArray2 = new object[] { "z", 1, "delay", 0.5f, "time", 1f, "isLocal", true, "easetype", iTween.EaseType.easeOutElastic };
                    this.<bannerScaleArgsRight>__1 = iTween.Hash(objArray2);
                    iTween.ScaleTo(this.<>f__this.m_rightBanner, this.<bannerScaleArgsRight>__1);
                    object[] objArray3 = new object[] { "z", 1, "delay", 0.5f, "time", 1f, "isLocal", true, "easetype", iTween.EaseType.easeOutElastic };
                    this.<bannerShredScaleArgsRight>__2 = iTween.Hash(objArray3);
                    iTween.ScaleTo(this.<>f__this.m_rightBannerShred, this.<bannerShredScaleArgsRight>__2);
                    object[] objArray4 = new object[] { "x", -0.81f, "time", 5, "isLocal", true, "easetype", iTween.EaseType.easeOutCubic, "oncomplete", "CloudTo", "oncompletetarget", this.<>f__this.gameObject };
                    this.<cloudMoveArgsRight>__3 = iTween.Hash(objArray4);
                    iTween.MoveTo(this.<>f__this.m_rightCloud, this.<cloudMoveArgsRight>__3);
                    object[] objArray5 = new object[] { "x", 0.824f, "time", 5, "isLocal", true, "easetype", iTween.EaseType.easeOutCubic };
                    this.<cloudMoveArgsLeft>__4 = iTween.Hash(objArray5);
                    iTween.MoveTo(this.<>f__this.m_leftCloud, this.<cloudMoveArgsLeft>__4);
                    object[] objArray6 = new object[] { "rotation", new Vector3(0f, 215f, 0f), "time", 1f, "delay", 0.75f, "isLocal", true, "easetype", iTween.EaseType.easeOutBounce, "oncomplete", "AnimateWoodBannerTo", "oncompletetarget", this.<>f__this.gameObject };
                    this.<woodBannerRotateArgs>__5 = iTween.Hash(objArray6);
                    iTween.RotateTo(this.<>f__this.m_defeatBanner, this.<woodBannerRotateArgs>__5);
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

