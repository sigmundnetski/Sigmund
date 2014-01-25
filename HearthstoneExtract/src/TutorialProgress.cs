using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TutorialProgress : MonoBehaviour
{
    private const float AFTER_PUNCH_SCALE_VAL = 0.81f;
    private const float END_SCALE_VAL = 0.83f;
    private Vector3 HERO_COIN_START;
    private const float HERO_SPACING = -0.2f;
    private bool IS_TESTING;
    public HeroCoin m_coinPrefab;
    public GameObject m_currentLessonBone;
    public PegUIElement m_exitButton;
    public TextMesh m_exitButtonLabel;
    private List<HeroCoin> m_heroCoins = new List<HeroCoin>();
    public TextMesh m_lessonTitle;
    public TextMesh m_missionProgressTitle;
    private Hashtable m_tutorialList = new Hashtable();
    private const int NUM_HERO_COINS = 6;
    private static TutorialProgress s_instance;
    private Vector3 START_POSITION = new Vector3(0.89f, 5.5f, 0.56f);
    private const float START_SCALE_VAL = 0.5f;

    private void Awake()
    {
        s_instance = this;
        base.gameObject.transform.localPosition = this.START_POSITION;
        this.HERO_COIN_START = new Vector3(0.5f, 0.1f, 0.32f);
        this.m_lessonTitle.text = GameStrings.Get("TUTORIAL_PROGRESS_LESSON_TITLE");
        this.m_missionProgressTitle.text = GameStrings.Get("TUTORIAL_PROGRESS_TITLE");
        this.m_exitButton.gameObject.SetActive(false);
        Vector3 zero = Vector3.zero;
        for (int i = 0; i < 6; i++)
        {
            Vector2 vector2;
            HeroCoin item = (HeroCoin) UnityEngine.Object.Instantiate(this.m_coinPrefab);
            item.transform.parent = base.transform;
            item.gameObject.SetActive(false);
            switch (UnityEngine.Random.Range(0, 3))
            {
                case 1:
                    vector2 = new Vector2(0.25f, -1f);
                    break;

                case 2:
                    vector2 = new Vector2(0.5f, -1f);
                    break;

                default:
                    vector2 = new Vector2(0f, -1f);
                    break;
            }
            if (i == 0)
            {
                item.transform.localPosition = this.HERO_COIN_START;
            }
            else
            {
                item.transform.localPosition = new Vector3(zero.x + -0.2f, zero.y, zero.z);
            }
            item.SetLessonGameObject("Tutorial_Lesson" + i.ToString());
            switch (((TutorialHeroes) i))
            {
                case TutorialHeroes.HOGGER:
                    item.SetCoinInfo(new Vector2(0f, -0.25f), new Vector2(0.25f, -0.25f), vector2, MissionMgr.MissionID.TUTORIAL1, "Hogger");
                    this.m_heroCoins.Insert(0, item);
                    break;

                case TutorialHeroes.MILLHOUSE:
                    item.SetCoinInfo(new Vector2(0.5f, 0f), new Vector2(0.75f, 0f), vector2, MissionMgr.MissionID.TUTORIAL2, "Millhouse Manastorm");
                    this.m_heroCoins.Insert(1, item);
                    break;

                case TutorialHeroes.CHO:
                    item.SetCoinInfo(new Vector2(0.5f, -0.5f), new Vector2(0.75f, -0.5f), vector2, MissionMgr.MissionID.TUTORIAL6, "Lorewalker Cho");
                    this.m_heroCoins.Insert(2, item);
                    break;

                case TutorialHeroes.MUKLA:
                    item.SetCoinInfo(new Vector2(0.5f, -0.25f), new Vector2(0.75f, -0.25f), vector2, MissionMgr.MissionID.TUTORIAL3, "King Mukla");
                    this.m_heroCoins.Insert(3, item);
                    break;

                case TutorialHeroes.NESINGWARY:
                    item.SetCoinInfo(new Vector2(0f, 0f), new Vector2(0.25f, 0f), vector2, MissionMgr.MissionID.TUTORIAL4, "Hemet Nesingwary");
                    this.m_heroCoins.Insert(4, item);
                    break;

                case TutorialHeroes.ILLIDAN:
                    item.SetCoinInfo(new Vector2(0f, -0.5f), new Vector2(0.25f, -0.5f), vector2, MissionMgr.MissionID.TUTORIAL5, "Illidan Stormrage");
                    this.m_heroCoins.Insert(5, item);
                    break;
            }
            zero = item.transform.localPosition;
        }
        this.m_tutorialList.Add(0, 0);
        this.m_tutorialList.Add(1, 1);
        this.m_tutorialList.Add(2, 2);
        this.m_tutorialList.Add(3, 3);
        this.m_tutorialList.Add(4, 4);
        this.m_tutorialList.Add(5, 5);
        this.m_tutorialList.Add(6, 6);
        SceneUtils.SetLayer(base.gameObject, GameLayer.IgnoreFullScreenEffects);
        if (this.IS_TESTING)
        {
            this.UpdateProgress();
        }
        else
        {
            NetCache.Get().RegisterTutorialEndGameScreen(new NetCache.NetCacheCallback(this.UpdateProgress), new NetCache.ErrorCallback(NetCache.DefaultErrorHandler));
        }
    }

    private void ExitButtonPress(UIEvent e)
    {
        SceneMgr.Get().SetNextMode(SceneMgr.Mode.HUB);
    }

    public static TutorialProgress Get()
    {
        return s_instance;
    }

    private void OnDestroy()
    {
        NetCache.Get().UnregisterNetCacheHandler(new NetCache.NetCacheCallback(this.UpdateProgress));
    }

    private void OnTutorialImageLoaded(string name, GameObject go, object callbackData)
    {
        this.SetupTutorialImage(go);
    }

    [DebuggerHidden]
    private IEnumerator SetActiveToDefeated(HeroCoin coin)
    {
        return new <SetActiveToDefeated>c__IteratorBB { coin = coin, <$>coin = coin };
    }

    [DebuggerHidden]
    private IEnumerator SetUnrevealedToActive(HeroCoin coin)
    {
        return new <SetUnrevealedToActive>c__IteratorBC { coin = coin, <$>coin = coin };
    }

    private void SetupTutorialImage(GameObject go)
    {
        SceneUtils.SetLayer(go, GameLayer.IgnoreFullScreenEffects);
        go.transform.parent = base.transform;
        go.transform.localScale = this.m_currentLessonBone.transform.localScale;
        go.transform.localEulerAngles = this.m_currentLessonBone.transform.localEulerAngles;
        go.transform.localPosition = this.m_currentLessonBone.transform.localPosition;
    }

    public void Show()
    {
        iTween.FadeTo(base.gameObject, 1f, 0.25f);
        base.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        object[] args = new object[] { "scale", new Vector3(0.83f, 0.83f, 0.83f), "time", 0.5f, "oncomplete", "PunchTurnStartInstance", "oncompletetarget", base.gameObject };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ScaleTo(base.gameObject, hashtable);
        object[] objArray2 = new object[] { "position", base.gameObject.transform.position + new Vector3(0.005f, 0.005f, 0.005f), "time", 1.5f };
        Hashtable hashtable2 = iTween.Hash(objArray2);
        iTween.MoveTo(base.gameObject, hashtable2);
    }

    private void UpdateProgress()
    {
        int num;
        if (this.IS_TESTING)
        {
            num = (int) this.m_tutorialList[1];
        }
        else
        {
            NetCache.NetCacheProfileProgress netObject = NetCache.Get().GetNetObject<NetCache.NetCacheProfileProgress>();
            num = (int) this.m_tutorialList[(int) netObject.CampaignProgress];
        }
        for (int i = 0; i < 6; i++)
        {
            HeroCoin coin = this.m_heroCoins[i];
            if (i == (num - 1))
            {
                base.StartCoroutine(this.SetActiveToDefeated(coin));
            }
            else if (i < num)
            {
                coin.SetProgress(HeroCoin.CoinStatus.DEFEATED);
            }
            else if (i == num)
            {
                base.StartCoroutine(this.SetUnrevealedToActive(coin));
                AssetLoader.Get().LoadGameObject(coin.GetLessonGameObject(), new AssetLoader.GameObjectCallback(this.OnTutorialImageLoaded));
            }
            else
            {
                coin.SetProgress(HeroCoin.CoinStatus.UNREVEALED);
            }
        }
    }

    [CompilerGenerated]
    private sealed class <SetActiveToDefeated>c__IteratorBB : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HeroCoin <$>coin;
        internal HeroCoin coin;

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
                    this.coin.SetProgress(HeroCoin.CoinStatus.ACTIVE);
                    this.coin.m_inputEnabled = false;
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.coin.SetProgress(HeroCoin.CoinStatus.ACTIVE_TO_DEFEATED);
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

    [CompilerGenerated]
    private sealed class <SetUnrevealedToActive>c__IteratorBC : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HeroCoin <$>coin;
        internal HeroCoin coin;

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
                    this.coin.SetProgress(HeroCoin.CoinStatus.UNREVEALED);
                    this.coin.m_inputEnabled = false;
                    this.$current = new WaitForSeconds(2f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.coin.SetProgress(HeroCoin.CoinStatus.UNREVEALED_TO_ACTIVE);
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

    public enum TutorialHeroes
    {
        HOGGER,
        MILLHOUSE,
        CHO,
        MUKLA,
        NESINGWARY,
        ILLIDAN
    }
}

