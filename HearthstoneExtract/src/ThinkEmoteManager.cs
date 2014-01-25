using System;
using UnityEngine;

public class ThinkEmoteManager : MonoBehaviour
{
    private float m_secondsSinceAction;
    private static ThinkEmoteManager s_instance;
    private const float SECONDS_BEFORE_EMOTE = 20f;

    private void Awake()
    {
        s_instance = this;
    }

    public static ThinkEmoteManager Get()
    {
        return s_instance;
    }

    public void NotifyOfActivity()
    {
        this.m_secondsSinceAction = 0f;
    }

    private void PlayThinkEmote()
    {
        this.m_secondsSinceAction = 0f;
        EmoteType emoteType = EmoteType.THINK1;
        switch (UnityEngine.Random.Range(1, 4))
        {
            case 1:
                emoteType = EmoteType.THINK1;
                break;

            case 2:
                emoteType = EmoteType.THINK2;
                break;

            case 3:
                emoteType = EmoteType.THINK3;
                break;
        }
        GameState.Get().GetCurrentPlayer().GetHeroCard().PlayEmote(emoteType);
    }

    private void Update()
    {
        if (((MissionMgr.Get() != null) && !MissionMgr.Get().IsPlayingAI()) && !MissionMgr.Get().IsTutorial())
        {
            GameState state = GameState.Get();
            if (((((state != null) && (state.GetGameEntity() != null)) && !state.IsMulliganPhase()) && state.GameHasBegun()) && state.IsMainPhase())
            {
                this.m_secondsSinceAction += UnityEngine.Time.deltaTime;
                if (this.m_secondsSinceAction > 20f)
                {
                    this.PlayThinkEmote();
                }
            }
        }
    }
}

