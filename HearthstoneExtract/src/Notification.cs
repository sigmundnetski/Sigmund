using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public MeshRenderer artOverlay;
    public GameObject bottomLeftBubble;
    public GameObject bottomPopupArrow;
    public GameObject bottomRightBubble;
    private const float BOUNCE_SPEED = 0.75f;
    public GameObject bounceObject;
    public NormalButton ButtonNO;
    public NormalButton ButtonOK;
    public BeveledButton ButtonStart;
    public NormalButton ButtonYES;
    public Spell destroyEvent;
    public TextMesh headlineText;
    public UberText headlineUberText;
    private bool isDying;
    public GameObject leftPopupArrow;
    private AudioSource m_accompaniedAudio;
    private const int MAX_CHARACTERS = 20;
    private const int MAX_CHARACTERS_IN_DIALOG = 0x1c;
    public GameObject rightPopupArrow;
    public Spell showEvent;
    public TextMesh speechText;
    public UberText speechUberText;
    public Material swapMaterial;
    public GameObject topPopupArrow;
    public GameObject upperLeftBubble;
    public GameObject upperRightBubble;

    public void AssignAudio(AudioSource source)
    {
        this.m_accompaniedAudio = source;
    }

    private void BounceDown()
    {
        object[] args = new object[] { "islocal", true, "z", this.bounceObject.transform.localPosition.z + 0.5f, "time", 0.75f, "easetype", iTween.EaseType.easeOutCubic, "oncomplete", "BounceUp", "oncompletetarget", base.gameObject };
        iTween.MoveTo(this.bounceObject, iTween.Hash(args));
    }

    private void BounceUp()
    {
        object[] args = new object[] { "islocal", true, "z", this.bounceObject.transform.localPosition.z - 0.5f, "time", 0.75f, "easetype", iTween.EaseType.easeInCubic, "oncomplete", "BounceDown", "oncompletetarget", base.gameObject };
        iTween.MoveTo(this.bounceObject, iTween.Hash(args));
    }

    public void ChangeDialogText(string headlineString, string bodyString, string yesOrOKstring, string noString)
    {
        if (this.speechUberText != null)
        {
            this.speechUberText.Text = bodyString;
        }
        else
        {
            string str = TextUtils.HackAutoLineBreakText(bodyString, 0x1c);
            this.speechText.text = str;
        }
        if (this.headlineUberText != null)
        {
            this.headlineUberText.Text = headlineString;
        }
        else
        {
            this.headlineText.text = headlineString;
        }
        if (noString != string.Empty)
        {
            this.ButtonNO.gameObject.SetActive(true);
            this.ButtonNO.SetText(noString);
            this.ButtonOK.gameObject.SetActive(false);
            if (yesOrOKstring != string.Empty)
            {
                this.ButtonYES.gameObject.SetActive(true);
                this.ButtonYES.SetText(yesOrOKstring);
            }
        }
        else if (yesOrOKstring != string.Empty)
        {
            this.ButtonOK.gameObject.SetActive(true);
            this.ButtonOK.SetText(yesOrOKstring);
            if (this.ButtonNO != null)
            {
                this.ButtonNO.gameObject.SetActive(false);
            }
            if (this.ButtonYES != null)
            {
                this.ButtonYES.gameObject.SetActive(false);
            }
        }
    }

    public void ChangeText(string newText)
    {
        if (this.speechUberText != null)
        {
            this.speechUberText.Text = newText;
        }
        else
        {
            string stringToTest = TextUtils.HackAutoLineBreakText(newText, 20);
            int longestLineAssumingTwoOrLessLines = this.GetLongestLineAssumingTwoOrLessLines(stringToTest);
            if (longestLineAssumingTwoOrLessLines > 0)
            {
                int fontSize = this.speechText.fontSize;
                this.speechText.fontSize = (this.speechText.fontSize * 20) / longestLineAssumingTwoOrLessLines;
                if (this.speechText.fontSize > (fontSize * 1.75f))
                {
                    this.speechText.fontSize = (fontSize * 3) / 2;
                }
            }
            this.speechText.text = stringToTest;
        }
    }

    public void FaceDirection(SpeechBubbleDirection direction)
    {
        switch (direction)
        {
            case SpeechBubbleDirection.TopLeft:
                this.upperLeftBubble.renderer.enabled = true;
                break;

            case SpeechBubbleDirection.TopRight:
                this.upperRightBubble.renderer.enabled = true;
                break;

            case SpeechBubbleDirection.BottomLeft:
                this.bottomLeftBubble.renderer.enabled = true;
                break;

            case SpeechBubbleDirection.BottomRight:
                this.bottomRightBubble.renderer.enabled = true;
                break;
        }
    }

    private void FinishDeath()
    {
        UnityEngine.Object.Destroy(base.gameObject);
    }

    public AudioSource GetAudio()
    {
        return this.m_accompaniedAudio;
    }

    private int GetLongestLineAssumingTwoOrLessLines(string stringToTest)
    {
        char[] separator = new char[] { '\n' };
        string[] strArray = stringToTest.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        if (strArray.Length > 2)
        {
            return -1;
        }
        int length = 0;
        foreach (string str in strArray)
        {
            if (str.Length > length)
            {
                length = str.Length;
            }
        }
        return length;
    }

    public bool IsDying()
    {
        return this.isDying;
    }

    public void PlayBirth()
    {
        if (this.showEvent != null)
        {
            this.showEvent.Activate();
        }
        if (this.bounceObject == null)
        {
            Vector3 localScale = base.transform.localScale;
            base.transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
            object[] args = new object[] { "scale", localScale, "easetype", iTween.EaseType.easeOutElastic, "time", 1f };
            iTween.ScaleTo(base.gameObject, iTween.Hash(args));
        }
        else
        {
            this.BounceDown();
        }
    }

    public void PlayBirthWithForcedScale(Vector3 targetScale)
    {
        object[] args = new object[] { "scale", targetScale, "easetype", iTween.EaseType.easeOutElastic, "time", 1f };
        iTween.ScaleTo(base.gameObject, iTween.Hash(args));
    }

    public void PlayDeath()
    {
        if (this.destroyEvent != null)
        {
            this.destroyEvent.Activate();
        }
        if (this.bounceObject != null)
        {
            this.FinishDeath();
        }
        else if (this.ButtonOK != null)
        {
            this.isDying = true;
            object[] args = new object[] { "scale", Vector3.zero, "easetype", iTween.EaseType.easeOutExpo, "time", 0.5f, "oncomplete", "FinishDeath", "oncompletetarget", base.gameObject };
            iTween.ScaleTo(base.gameObject, iTween.Hash(args));
        }
        else
        {
            this.isDying = true;
            object[] objArray2 = new object[] { "scale", Vector3.zero, "easetype", iTween.EaseType.easeInExpo, "time", 0.5f, "oncomplete", "FinishDeath", "oncompletetarget", base.gameObject };
            iTween.ScaleTo(base.gameObject, iTween.Hash(objArray2));
        }
    }

    public void PlaySmallBirthForFakeBubble()
    {
        if (this.showEvent != null)
        {
            this.showEvent.Activate();
        }
        if (this.bounceObject == null)
        {
            float num = 0.25f;
            Vector3 vector = new Vector3(num * base.transform.localScale.x, num * base.transform.localScale.y, num * base.transform.localScale.z);
            base.transform.localScale = Vector3.zero;
            object[] args = new object[] { "scale", vector, "easetype", iTween.EaseType.easeOutElastic, "time", 1f };
            iTween.ScaleTo(base.gameObject, iTween.Hash(args));
        }
        else
        {
            this.BounceDown();
        }
    }

    [DebuggerHidden]
    private IEnumerator PulseReminder(float seconds)
    {
        return new <PulseReminder>c__IteratorE0 { seconds = seconds, <$>seconds = seconds, <>f__this = this };
    }

    public void PulseReminderEveryXSeconds(float seconds)
    {
        base.StartCoroutine(this.PulseReminder(seconds));
    }

    public void SetPosition(Actor actor, SpeechBubbleDirection direction)
    {
        if (actor.GetBones() == null)
        {
            UnityEngine.Debug.LogError("Notification Error - Tried to set the position of a Speech Bubble, but the target actor has no bones!");
        }
        else
        {
            GameObject parentObject = SceneUtils.FindChildBySubstring(actor.GetBones(), "SpeechBubbleBones");
            if (parentObject == null)
            {
                UnityEngine.Debug.LogError("Notification Error - Tried to set the position of a Speech Bubble, but the target actor has no SpeechBubbleBones!");
            }
            else
            {
                Vector3 zero = Vector3.zero;
                switch (direction)
                {
                    case SpeechBubbleDirection.TopLeft:
                        zero = SceneUtils.FindChildBySubstring(parentObject, "BottomRight").transform.position;
                        break;

                    case SpeechBubbleDirection.TopRight:
                        zero = SceneUtils.FindChildBySubstring(parentObject, "BottomLeft").transform.position;
                        break;

                    case SpeechBubbleDirection.BottomLeft:
                        zero = SceneUtils.FindChildBySubstring(parentObject, "TopRight").transform.position;
                        break;

                    case SpeechBubbleDirection.BottomRight:
                        zero = SceneUtils.FindChildBySubstring(parentObject, "TopLeft").transform.position;
                        break;
                }
                base.transform.position = zero;
            }
        }
    }

    public void SetPositionForSmallBubble(Actor actor)
    {
        if (actor.GetBones() == null)
        {
            UnityEngine.Debug.LogError("Notification Error - Tried to set the position of a Speech Bubble, but the target actor has no bones!");
        }
        else
        {
            GameObject parentObject = SceneUtils.FindChildBySubstring(actor.GetBones(), "SpeechBubbleBones");
            if (parentObject == null)
            {
                UnityEngine.Debug.LogError("Notification Error - Tried to set the position of a Speech Bubble, but the target actor has no SpeechBubbleBones!");
            }
            else
            {
                base.transform.position = SceneUtils.FindChildBySubstring(parentObject, "SmallBubble").transform.position;
            }
        }
    }

    public void ShowPopUpArrow(PopUpArrowDirection direction)
    {
        switch (direction)
        {
            case PopUpArrowDirection.Left:
                this.leftPopupArrow.renderer.enabled = true;
                break;

            case PopUpArrowDirection.Right:
                this.rightPopupArrow.renderer.enabled = true;
                break;

            case PopUpArrowDirection.Down:
                this.bottomPopupArrow.renderer.enabled = true;
                break;

            case PopUpArrowDirection.Up:
                this.topPopupArrow.renderer.enabled = true;
                break;
        }
    }

    private void Start()
    {
    }

    [CompilerGenerated]
    private sealed class <PulseReminder>c__IteratorE0 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal float <$>seconds;
        internal Notification <>f__this;
        internal float seconds;

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
                    this.$current = new WaitForSeconds(this.seconds);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (!this.<>f__this.isDying)
                    {
                        object[] args = new object[] { "amount", Vector3.one, "time", 1f };
                        iTween.PunchScale(this.<>f__this.gameObject, iTween.Hash(args));
                        this.<>f__this.StartCoroutine(this.<>f__this.PulseReminder(this.seconds));
                        this.$PC = -1;
                        break;
                    }
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

    public enum PopUpArrowDirection
    {
        Left,
        Right,
        Down,
        Up
    }

    public enum SpeechBubbleDirection
    {
        None,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}

