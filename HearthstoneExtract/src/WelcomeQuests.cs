using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class WelcomeQuests : MonoBehaviour
{
    public Animation m_bannerFX;
    public PegUIElement m_clickCatcher;
    private List<QuestTile> m_currentQuests;
    public Banner m_headlineBanner;
    private static DelOnWelcomeQuestsClosed m_onCloseCallback;
    public Collider m_placementCollider;
    public UberText m_questCaption;
    public QuestTile m_questTilePrefab;
    private static WelcomeQuests s_instance;

    private void Awake()
    {
        this.m_headlineBanner.gameObject.SetActive(false);
        this.m_clickCatcher.gameObject.SetActive(false);
    }

    private void CloseWelcomeQuests(UIEvent e)
    {
        s_instance = null;
        this.m_clickCatcher.RemoveEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.CloseWelcomeQuests));
        this.FadeEffectsOut();
        object[] args = new object[] { "scale", Vector3.zero, "time", 0.5f, "oncompletetarget", base.gameObject, "oncomplete", "DestroyWelcomeQuests" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(args));
        this.m_bannerFX.Play("BannerClose");
        if (m_onCloseCallback != null)
        {
            m_onCloseCallback();
        }
    }

    private void DestroyWelcomeQuests()
    {
        UnityEngine.Object.Destroy(base.gameObject);
    }

    private void DoInnkeeperLine(Achievement quest)
    {
        if (quest.ID == 11)
        {
            NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_FIRST_QUEST"), string.Empty, 5f);
        }
    }

    private void FadeEffectsIn()
    {
        FullScreenFXMgr mgr = FullScreenFXMgr.Get();
        mgr.SetBlurBrightness(1f);
        mgr.SetBlurDesaturation(0f);
        mgr.Vignette(0.4f, 0.4f, iTween.EaseType.easeOutCirc, null);
        mgr.Blur(1f, 0.4f, iTween.EaseType.easeOutCirc, null);
    }

    private void FadeEffectsOut()
    {
        FullScreenFXMgr mgr = FullScreenFXMgr.Get();
        mgr.StopVignette(0.2f, iTween.EaseType.easeOutCirc, null);
        mgr.StopBlur(0.2f, iTween.EaseType.easeOutCirc, null);
    }

    private void FlipQuest(QuestTile quest)
    {
        object[] args = new object[] { "rotation", new Vector3(90f, 180f, 0f), "islocal", true, "time", 2f, "delay", 1f };
        iTween.RotateTo(quest.gameObject, iTween.Hash(args));
    }

    private void InitAndShow(bool showAllQuests, DelOnWelcomeQuestsClosed onCloseCallback)
    {
        m_onCloseCallback = onCloseCallback;
        this.m_clickCatcher.gameObject.SetActive(true);
        this.m_headlineBanner.gameObject.SetActive(true);
        if (showAllQuests)
        {
            this.m_headlineBanner.SetText(GameStrings.Get("GLUE_QUEST_NOTIFICATION_HEADER"));
        }
        else
        {
            this.m_headlineBanner.SetText(GameStrings.Get("GLUE_QUEST_NOTIFICATION_HEADER_NEW_ONLY"));
        }
        if (AchieveManager.Get().HasUnlockedFeature(Achievement.UnlockableFeature.DAILY_QUESTS))
        {
            this.m_questCaption.Text = GameStrings.Get("GLUE_QUEST_NOTIFICATION_CAPTION");
        }
        else
        {
            this.m_questCaption.Text = string.Empty;
        }
        this.m_clickCatcher.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.CloseWelcomeQuests));
        this.ShowActiveQuests(showAllQuests);
        base.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        iTween.ScaleTo(base.gameObject, Vector3.one, 0.5f);
    }

    private static void OnWelcomeQuestsLoaded(string name, GameObject go, object callbackData)
    {
        if (go == null)
        {
            Debug.LogError(string.Format("WelcomeQuests.OnWelcomeQuestsLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            s_instance = go.GetComponent<WelcomeQuests>();
            if (s_instance == null)
            {
                Debug.LogError(string.Format("WelcomeQuests.OnWelcomeQuestsLoaded() - ERROR object \"{0}\" has no WelcomeQuests component", name));
            }
            else
            {
                OnLoadedCallbackData data = callbackData as OnLoadedCallbackData;
                s_instance.InitAndShow(data.m_showAllQuests, data.m_onCloseCallback);
            }
        }
    }

    public static void Show(bool showAllQuests, DelOnWelcomeQuestsClosed onCloseCallback = new DelOnWelcomeQuestsClosed())
    {
        if (s_instance != null)
        {
            Debug.LogWarning("WelcomeQuests.Show(): requested to show welcome quests while it was already active!");
            s_instance.InitAndShow(showAllQuests, onCloseCallback);
        }
        else
        {
            OnLoadedCallbackData data2 = new OnLoadedCallbackData {
                m_showAllQuests = showAllQuests,
                m_onCloseCallback = onCloseCallback
            };
            OnLoadedCallbackData callbackData = data2;
            AssetLoader.Get().LoadGameObject("WelcomeQuests", new AssetLoader.GameObjectCallback(WelcomeQuests.OnWelcomeQuestsLoaded), callbackData);
        }
    }

    private void ShowActiveQuests(bool showAllQuests)
    {
        List<Achievement> list2;
        List<Achievement> activeQuests = AchieveManager.Get().GetActiveQuests(false);
        if (showAllQuests)
        {
            list2 = activeQuests;
        }
        else
        {
            list2 = new List<Achievement>();
            foreach (Achievement achievement in activeQuests)
            {
                list2.Add(achievement);
            }
        }
        this.m_currentQuests = new List<QuestTile>();
        float x = 0.4808684f;
        float num2 = this.m_placementCollider.transform.position.x - this.m_placementCollider.collider.bounds.extents.x;
        float num3 = this.m_placementCollider.bounds.size.x / ((float) list2.Count);
        float num4 = num3 / 2f;
        for (int i = 0; i < list2.Count; i++)
        {
            Achievement quest = list2[i];
            bool flag = quest.IsNewlyActive();
            float y = 180f;
            if (flag)
            {
                y = 0f;
                this.DoInnkeeperLine(quest);
            }
            GameObject parentObject = (GameObject) UnityEngine.Object.Instantiate(this.m_questTilePrefab.gameObject);
            SceneUtils.SetLayer(parentObject, GameLayer.UniversalUI);
            parentObject.transform.position = new Vector3(num2 + num4, this.m_placementCollider.transform.position.y, this.m_placementCollider.transform.position.z);
            parentObject.transform.parent = base.transform;
            parentObject.transform.localEulerAngles = new Vector3(90f, y, 0f);
            parentObject.transform.localScale = new Vector3(x, x, x);
            QuestTile component = parentObject.GetComponent<QuestTile>();
            component.SetupTile(quest);
            this.m_currentQuests.Add(component);
            num4 += num3;
            if (flag)
            {
                this.FlipQuest(component);
            }
        }
        this.FadeEffectsIn();
    }

    public delegate void DelOnWelcomeQuestsClosed();

    private class OnLoadedCallbackData
    {
        public WelcomeQuests.DelOnWelcomeQuestsClosed m_onCloseCallback;
        public bool m_showAllQuests;
    }
}

