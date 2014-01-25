using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class QuestLogButton : PegUIElement
{
    private DataState m_currentForgeDataState;
    public HighlightState m_highlight;
    private DataState m_netCacheDataState;
    private QuestLog m_questLog;
    private QuestLog.Data m_questLogData = new QuestLog.Data();
    private bool m_questLogLoading;
    private Vector3 m_questLogPos = Vector3.zero;
    private Vector3 m_questLogScale = Vector3.one;
    private GameObject m_tempInputBlocker;
    private const string SHOW_LOG_COROUTINE = "ShowQuestLogWhenReady";

    private void DestroyQuestLog()
    {
        base.StopCoroutine("ShowQuestLogWhenReady");
        if (this.m_questLog != null)
        {
            this.m_questLog.Hide();
            UnityEngine.Object.Destroy(this.m_questLog.gameObject);
        }
    }

    private void OnButtonOut(UIEvent e)
    {
        this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_OFF);
        TooltipZone component = base.GetComponent<TooltipZone>();
        if (component != null)
        {
            component.HideTooltip();
        }
    }

    private void OnButtonOver(UIEvent e)
    {
        this.m_highlight.ChangeState(ActorStateType.HIGHLIGHT_MOUSE_OVER);
        TooltipZone component = base.GetComponent<TooltipZone>();
        if (component != null)
        {
            component.ShowBoxTooltip(GameStrings.Get("GLUE_TOOLTIP_BUTTON_QUESTLOG_HEADLINE"), GameStrings.Get("GLUE_TOOLTIP_BUTTON_QUESTLOG_DESC"));
        }
    }

    private void OnButtonReleased(UIEvent e)
    {
        this.m_tempInputBlocker = CameraUtils.CreateInputBlocker(Box.Get().GetCamera());
        SceneUtils.SetLayer(this.m_tempInputBlocker, GameLayer.IgnoreFullScreenEffects);
        this.m_tempInputBlocker.name = "QuestLogInputBlocker";
        this.m_tempInputBlocker.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        this.m_tempInputBlocker.AddComponent<PegUIElement>();
        base.StopCoroutine("ShowQuestLogWhenReady");
        base.StartCoroutine("ShowQuestLogWhenReady");
    }

    private void OnDraftChoicesAndContents()
    {
        this.RemoveDraftNetHandlers();
        Network.DraftChoicesAndContents draftChoicesAndContents = Network.GetDraftChoicesAndContents();
        if (this.m_currentForgeDataState != DataState.UNLOADING)
        {
            this.m_questLogData.m_currentForge = new QuestLog.Data.ForgeRecord(draftChoicesAndContents.Wins, draftChoicesAndContents.Losses);
            this.m_currentForgeDataState = DataState.RECEIVED;
        }
    }

    private void OnDraftError()
    {
        this.RemoveDraftNetHandlers();
        Network.GetDraftError();
        if (this.m_currentForgeDataState != DataState.UNLOADING)
        {
            this.m_questLogData.m_currentForge = null;
            this.m_currentForgeDataState = DataState.RECEIVED;
        }
    }

    private void OnNetCacheReady()
    {
        if (this.m_netCacheDataState != DataState.UNLOADING)
        {
            this.m_netCacheDataState = DataState.RECEIVED;
        }
    }

    private void OnQuestLogLoaded(string name, GameObject go, object callbackData)
    {
        this.m_questLogLoading = false;
        if (go == null)
        {
            UnityEngine.Debug.LogError(string.Format("QuestLogButton.OnQuestLogLoaded() - FAILED to load \"{0}\"", name));
        }
        else
        {
            this.m_questLog = go.GetComponent<QuestLog>();
            if (this.m_questLog == null)
            {
                UnityEngine.Debug.LogError(string.Format("QuestLogButton.OnQuestLogLoaded() - ERROR \"{0}\" has no {1} component", name, typeof(QuestLog)));
            }
        }
    }

    private void RegisterDraftNetHandlers()
    {
        Network network = Network.Get();
        network.RegisterNetHandler(Network.PacketID.DRAFT_CHOICES_AND_CONTENTS, new Network.NetHandler(this.OnDraftChoicesAndContents));
        network.RegisterNetHandler(Network.PacketID.DRAFT_ERROR, new Network.NetHandler(this.OnDraftError));
    }

    private void RemoveDraftNetHandlers()
    {
        Network network = Network.Get();
        network.RemoveNetHandler(Network.PacketID.DRAFT_CHOICES_AND_CONTENTS);
        network.RemoveNetHandler(Network.PacketID.DRAFT_ERROR);
    }

    public void SetQuestLogPosAndScale(Vector3 position, Vector3 scale)
    {
        this.m_questLogPos = position;
        this.m_questLogScale = scale;
    }

    private bool ShouldRequestData(DataState state)
    {
        return ((state == DataState.NONE) || (state == DataState.UNLOADING));
    }

    [DebuggerHidden]
    private IEnumerator ShowQuestLogWhenReady()
    {
        return new <ShowQuestLogWhenReady>c__Iterator9C { <>f__this = this };
    }

    private void Start()
    {
        this.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnButtonReleased));
        this.AddEventListener(UIEventType.ROLLOVER, new UIEvent.Handler(this.OnButtonOver));
        this.AddEventListener(UIEventType.ROLLOUT, new UIEvent.Handler(this.OnButtonOut));
    }

    public void Unload()
    {
        this.m_currentForgeDataState = DataState.UNLOADING;
        this.m_netCacheDataState = DataState.UNLOADING;
        this.DestroyQuestLog();
    }

    [CompilerGenerated]
    private sealed class <ShowQuestLogWhenReady>c__Iterator9C : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal QuestLogButton <>f__this;

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
                    if ((this.<>f__this.m_questLog == null) && !this.<>f__this.m_questLogLoading)
                    {
                        this.<>f__this.m_questLogLoading = true;
                        AssetLoader.Get().LoadGameObject("QuestLog", new AssetLoader.GameObjectCallback(this.<>f__this.OnQuestLogLoaded));
                    }
                    if (this.<>f__this.ShouldRequestData(this.<>f__this.m_netCacheDataState))
                    {
                        this.<>f__this.m_netCacheDataState = QuestLogButton.DataState.REQUEST_SENT;
                        NetCache.Get().RegisterScreenQuestLog(new NetCache.NetCacheCallback(this.<>f__this.OnNetCacheReady));
                    }
                    if (this.<>f__this.ShouldRequestData(this.<>f__this.m_currentForgeDataState))
                    {
                        this.<>f__this.m_currentForgeDataState = QuestLogButton.DataState.REQUEST_SENT;
                        this.<>f__this.RegisterDraftNetHandlers();
                        Network.FindOutCurrentDraftState();
                    }
                    break;

                case 1:
                    break;

                case 2:
                    goto Label_013B;

                case 3:
                    goto Label_0164;

                default:
                    goto Label_01BD;
            }
            while (this.<>f__this.m_questLog == null)
            {
                this.$current = null;
                this.$PC = 1;
                goto Label_01BF;
            }
        Label_013B:
            while (this.<>f__this.m_currentForgeDataState != QuestLogButton.DataState.RECEIVED)
            {
                this.$current = null;
                this.$PC = 2;
                goto Label_01BF;
            }
        Label_0164:
            while (this.<>f__this.m_netCacheDataState != QuestLogButton.DataState.RECEIVED)
            {
                this.$current = null;
                this.$PC = 3;
                goto Label_01BF;
            }
            this.<>f__this.m_questLog.Show(this.<>f__this.m_questLogData, this.<>f__this.m_questLogPos, this.<>f__this.m_questLogScale);
            UnityEngine.Object.Destroy(this.<>f__this.m_tempInputBlocker);
            this.$PC = -1;
        Label_01BD:
            return false;
        Label_01BF:
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

    private enum DataState
    {
        NONE,
        REQUEST_SENT,
        RECEIVED,
        UNLOADING
    }
}

