using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    private List<Notification> arrows;
    public GameObject bounceArrowPrefab;
    public GameObject dialogBoxPrefab;
    private Notification innkeeperQuote;
    public GameObject innkeeperQuotePrefab;
    private List<Notification> notificationsToDestroyUponNewNotifier;
    private Notification popUpDialog;
    public GameObject popupTextPrefab;
    private List<Notification> popUpTexts;
    private static NotificationManager s_instance;
    public GameObject speechBubblePrefab;
    public GameObject speechIndicatorPrefab;

    private void Awake()
    {
        s_instance = this;
    }

    public Notification CreateBouncingArrow(bool addToList)
    {
        Notification component = ((GameObject) UnityEngine.Object.Instantiate(this.bounceArrowPrefab)).GetComponent<Notification>();
        component.PlayBirth();
        if (addToList)
        {
            this.arrows.Add(component);
        }
        return component;
    }

    public Notification CreateBouncingArrow(Vector3 position, Vector3 rotation)
    {
        return this.CreateBouncingArrow(position, rotation, true);
    }

    public Notification CreateBouncingArrow(Vector3 position, Vector3 rotation, bool addToList)
    {
        Notification notification = this.CreateBouncingArrow(addToList);
        notification.transform.position = position;
        notification.transform.localEulerAngles = rotation;
        return notification;
    }

    public Notification CreateInnkeeperQuote(Vector3 position, string text, string soundName)
    {
        return this.CreateInnkeeperQuote(position, text, soundName, 0f);
    }

    public Notification CreateInnkeeperQuote(Vector3 position, string text, string soundName, float seconds)
    {
        if (this.innkeeperQuote != null)
        {
            UnityEngine.Object.Destroy(this.innkeeperQuote.gameObject);
        }
        this.innkeeperQuote = ((GameObject) UnityEngine.Object.Instantiate(this.innkeeperQuotePrefab)).GetComponent<Notification>();
        this.innkeeperQuote.ChangeText(text);
        this.innkeeperQuote.transform.position = position;
        this.innkeeperQuote.transform.localScale = Vector3.zero;
        if (!soundName.Equals(string.Empty))
        {
            SoundManager.Get().LoadAndPlay(soundName, null, 1f, new SoundManager.LoadedCallback(this.OnInnkeeperSoundLoaded), seconds);
        }
        else
        {
            this.PlayInnkeeperLineWithoutSound(seconds);
        }
        return this.innkeeperQuote;
    }

    public Notification CreatePopupDialog(string headlineText, string bodyText, string yesOrOKButtonText, string noButtonText)
    {
        return this.CreatePopupDialog(headlineText, bodyText, yesOrOKButtonText, noButtonText, new Vector3(0f, 0f, 0f));
    }

    public Notification CreatePopupDialog(string headlineText, string bodyText, string yesOrOKButtonText, string noButtonText, Vector3 offset)
    {
        if (this.popUpDialog != null)
        {
            UnityEngine.Object.Destroy(this.popUpDialog.gameObject);
        }
        GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(this.dialogBoxPrefab);
        Vector3 position = Camera.main.transform.position;
        obj2.transform.position = (position + new Vector3(-0.07040818f, -16.10709f, 1.79612f)) + offset;
        this.popUpDialog = obj2.GetComponent<Notification>();
        this.popUpDialog.ChangeDialogText(headlineText, bodyText, yesOrOKButtonText, noButtonText);
        this.popUpDialog.PlayBirth();
        UniversalInputManager.Get().SetGameDialogActive(true);
        return this.popUpDialog;
    }

    public void CreatePopupDialogFromObject(Notification passedInNotification, string headlineString, string bodyText, string OkButtonText)
    {
        if (this.popUpDialog != null)
        {
            UnityEngine.Object.Destroy(this.popUpDialog.gameObject);
        }
        this.popUpDialog = passedInNotification;
        this.popUpDialog.transform.position = Board.Get().FindBone("TutorialDialogPopupBone").position;
        this.popUpDialog.ButtonStart.SetText(OkButtonText);
        if (this.popUpDialog.speechUberText != null)
        {
            this.popUpDialog.speechUberText.Text = bodyText;
        }
        else
        {
            int maxCharsPerLine = 0x18;
            string str = TextUtils.HackAutoLineBreakText(bodyText, maxCharsPerLine);
            this.popUpDialog.speechText.text = str;
        }
        if (this.popUpDialog.headlineUberText != null)
        {
            this.popUpDialog.headlineUberText.Text = headlineString;
        }
        else
        {
            this.popUpDialog.headlineText.text = headlineString;
        }
        this.popUpDialog.PlayBirth();
        UniversalInputManager.Get().SetGameDialogActive(true);
    }

    public Notification CreatePopupText(Vector3 position, string text)
    {
        return this.CreatePopupText(position, new Vector3(1.3f, 1.3f, 1.3f), text);
    }

    public Notification CreatePopupText(Vector3 position, Vector3 scale, string text)
    {
        GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(this.popupTextPrefab);
        obj2.transform.position = position;
        obj2.transform.localScale = scale;
        Notification component = obj2.GetComponent<Notification>();
        component.ChangeText(text);
        component.PlayBirth();
        this.popUpTexts.Add(component);
        return component;
    }

    public Notification CreateSpeechBubble(string speechText, Actor actor)
    {
        return this.CreateSpeechBubble(speechText, Notification.SpeechBubbleDirection.BottomLeft, actor, false);
    }

    public Notification CreateSpeechBubble(string speechText, Actor actor, bool bDestroyWhenNewCreated)
    {
        return this.CreateSpeechBubble(speechText, Notification.SpeechBubbleDirection.BottomLeft, actor, bDestroyWhenNewCreated);
    }

    public Notification CreateSpeechBubble(string speechText, Notification.SpeechBubbleDirection direction, Actor actor)
    {
        return this.CreateSpeechBubble(speechText, direction, actor, false);
    }

    public Notification CreateSpeechBubble(string speechText, Notification.SpeechBubbleDirection direction, Actor actor, bool bDestroyWhenNewCreated)
    {
        Notification component;
        this.DestroyOtherNotifications();
        if (speechText == string.Empty)
        {
            GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(this.speechIndicatorPrefab);
            component = obj2.GetComponent<Notification>();
            component.PlaySmallBirthForFakeBubble();
            component.SetPositionForSmallBubble(actor);
        }
        else
        {
            component = ((GameObject) UnityEngine.Object.Instantiate(this.speechBubblePrefab)).GetComponent<Notification>();
            component.ChangeText(speechText);
            component.FaceDirection(direction);
            component.PlayBirth();
            component.SetPosition(actor, direction);
        }
        if (bDestroyWhenNewCreated)
        {
            this.notificationsToDestroyUponNewNotifier.Add(component);
        }
        component.transform.parent = actor.transform;
        return component;
    }

    public void DestroyActiveNotification(float seconds)
    {
        if (this.popUpDialog != null)
        {
            if (seconds == 0f)
            {
                this.NukeNotification(this.popUpDialog);
            }
            else
            {
                base.StartCoroutine(this.WaitAndThenDestroyNotification(this.popUpDialog, seconds));
            }
        }
    }

    public void DestroyAllArrows()
    {
        if (this.arrows.Count != 0)
        {
            for (int i = 0; i < this.arrows.Count; i++)
            {
                if (this.arrows[i] != null)
                {
                    this.NukeNotificationWithoutPlayingAnim(this.arrows[i]);
                }
            }
        }
    }

    public void DestroyAllPopUps()
    {
        if (this.popUpTexts.Count != 0)
        {
            for (int i = 0; i < this.popUpTexts.Count; i++)
            {
                if (this.popUpTexts[i] != null)
                {
                    this.NukeNotification(this.popUpTexts[i]);
                }
            }
            this.popUpTexts = new List<Notification>();
        }
    }

    public void DestroyNotification(Notification notification, float seconds)
    {
        if (notification != null)
        {
            if (seconds == 0f)
            {
                this.NukeNotification(notification);
            }
            else
            {
                base.StartCoroutine(this.WaitAndThenDestroyNotification(notification, seconds));
            }
        }
    }

    public void DestroyNotificationNowWithNoAnim(Notification notification)
    {
        if (notification != null)
        {
            this.NukeNotificationWithoutPlayingAnim(notification);
        }
    }

    private void DestroyOtherNotifications()
    {
        if (this.notificationsToDestroyUponNewNotifier.Count != 0)
        {
            for (int i = 0; i < this.notificationsToDestroyUponNewNotifier.Count; i++)
            {
                if (this.notificationsToDestroyUponNewNotifier[i] != null)
                {
                    this.NukeNotificationWithoutPlayingAnim(this.notificationsToDestroyUponNewNotifier[i]);
                }
            }
        }
    }

    public static NotificationManager Get()
    {
        return s_instance;
    }

    public Notification MessageBox(string headlineText, string bodyText, string yesOrOKButtonText, UIEvent.Handler callback, Vector3 offset)
    {
        Notification notification = Get().CreatePopupDialog(headlineText, bodyText, yesOrOKButtonText, string.Empty, offset);
        notification.ButtonOK.AddEventListener(UIEventType.RELEASE, callback);
        return notification;
    }

    private void NukeNotification(Notification notification)
    {
        if (this.notificationsToDestroyUponNewNotifier.Contains(notification))
        {
            this.notificationsToDestroyUponNewNotifier.Remove(notification);
        }
        if (!notification.IsDying())
        {
            notification.PlayDeath();
            UniversalInputManager.Get().SetGameDialogActive(false);
        }
    }

    private void NukeNotificationWithoutPlayingAnim(Notification notification)
    {
        if (this.notificationsToDestroyUponNewNotifier.Contains(notification))
        {
            this.notificationsToDestroyUponNewNotifier.Remove(notification);
        }
        UnityEngine.Object.Destroy(notification.gameObject);
        UniversalInputManager.Get().SetGameDialogActive(false);
    }

    private void OnInnkeeperSoundLoaded(AudioSource source, object userData)
    {
        if (this.innkeeperQuote != null)
        {
            float a = (float) userData;
            float seconds = Mathf.Max(a, source.clip.length);
            this.innkeeperQuote.AssignAudio(source);
            this.innkeeperQuote.PlayBirthWithForcedScale(Vector3.one);
            this.DestroyNotification(this.innkeeperQuote, seconds);
        }
    }

    private void PlayInnkeeperLineWithoutSound(float seconds)
    {
        this.innkeeperQuote.PlayBirthWithForcedScale(Vector3.one);
        if (seconds > 0f)
        {
            this.DestroyNotification(this.innkeeperQuote, seconds);
        }
    }

    private void Start()
    {
        this.notificationsToDestroyUponNewNotifier = new List<Notification>();
        this.arrows = new List<Notification>();
        this.popUpTexts = new List<Notification>();
    }

    [DebuggerHidden]
    private IEnumerator WaitAndThenDestroyNotification(Notification notification, float seconds)
    {
        return new <WaitAndThenDestroyNotification>c__IteratorE1 { seconds = seconds, notification = notification, <$>seconds = seconds, <$>notification = notification, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitAndThenDestroyNotification>c__IteratorE1 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Notification <$>notification;
        internal float <$>seconds;
        internal NotificationManager <>f__this;
        internal Notification notification;
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
                    if (this.notification != null)
                    {
                        this.<>f__this.NukeNotification(this.notification);
                    }
                    this.$PC = -1;
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

