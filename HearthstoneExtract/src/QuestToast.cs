using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class QuestToast : MonoBehaviour
{
    private static QuestToast m_activeQuest;
    public PegUIElement m_clickCatcher;
    public HighlightState m_highlight;
    public GameObject m_nameLine;
    private DelOnCloseQuestToast m_onCloseCallback;
    private Achievement m_quest;
    private static bool m_questActive;
    public UberText m_questName;
    public UberText m_requirement;
    public Transform m_rewardBone;
    private static readonly Vector3 REWARD_SCALE = new Vector3(1.42f, 1.42f, 1.42f);

    public void CloseQuestToast()
    {
        m_questActive = false;
        this.m_clickCatcher.RemoveEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.CloseQuestToast));
        this.FadeEffectsOut();
        object[] args = new object[] { "scale", Vector3.zero, "time", 0.5f, "oncompletetarget", base.gameObject, "oncomplete", "DestroyQuestToast" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(args));
        if (this.m_onCloseCallback != null)
        {
            this.m_onCloseCallback();
        }
    }

    private void CloseQuestToast(UIEvent e)
    {
        this.CloseQuestToast();
    }

    private void DestroyQuestToast()
    {
        UnityEngine.Object.Destroy(base.gameObject);
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

    public static QuestToast GetCurrentToast()
    {
        return m_activeQuest;
    }

    public static bool IsQuestActive()
    {
        return m_questActive;
    }

    private static void PositionActor(string actorName, GameObject actorObject, object c)
    {
        actorObject.transform.position = new Vector3(606.9359f, -499.9216f, -35.94187f);
        Vector3 localScale = actorObject.transform.localScale;
        actorObject.transform.localScale = Vector3.one;
        actorObject.SetActive(true);
        iTween.ScaleTo(actorObject, localScale, 0.5f);
        QuestToast component = actorObject.GetComponent<QuestToast>();
        if (component == null)
        {
            Debug.LogWarning("QuestToast.PositionActor(): actor has no QuestToast component");
        }
        else
        {
            m_activeQuest = component;
            ToastCallbackData data = c as ToastCallbackData;
            component.m_onCloseCallback = data.c_onCloseCallback;
            component.m_quest = data.c_quest;
            component.SetUpToast();
        }
    }

    private void RewardObjectLoaded(Reward reward, object callbackData)
    {
        reward.Hide();
        reward.transform.parent = this.m_rewardBone;
        reward.transform.localEulerAngles = Vector3.zero;
        reward.transform.localScale = REWARD_SCALE;
        reward.transform.localPosition = Vector3.zero;
        SceneUtils.SetLayer(reward.gameObject, GameLayer.UniversalUI);
        RenderUtils.SetAlpha(reward.gameObject, 0f);
        reward.Show();
    }

    public void SetUpToast()
    {
        this.m_clickCatcher.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.CloseQuestToast));
        this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE);
        this.m_questName.Text = this.m_quest.Name;
        this.m_requirement.Text = this.m_quest.Description;
        RewardData data = null;
        if (this.m_quest.Rewards != null)
        {
            foreach (RewardData data2 in this.m_quest.Rewards)
            {
                if (data2.RewardType != Reward.Type.MOUNT)
                {
                    data = data2;
                    break;
                }
            }
        }
        if (data != null)
        {
            data.LoadRewardObject(new Reward.DelOnRewardLoaded(this.RewardObjectLoaded));
        }
        this.FadeEffectsIn();
    }

    public static void ShowQuestToast(DelOnCloseQuestToast onClosedCallback, Achievement quest)
    {
        m_questActive = true;
        quest.AckCurrentProgressAndRewardNotices();
        ToastCallbackData callbackData = new ToastCallbackData {
            c_quest = quest,
            c_onCloseCallback = onClosedCallback
        };
        AssetLoader.Get().LoadActor("QuestToast", new AssetLoader.GameObjectCallback(QuestToast.PositionActor), callbackData);
        SoundManager.Get().LoadAndPlay("Quest_Complete_Jingle");
    }

    public delegate void DelOnCloseQuestToast();

    private class ToastCallbackData
    {
        public QuestToast.DelOnCloseQuestToast c_onCloseCallback;
        public Achievement c_quest;
    }
}

