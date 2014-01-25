using System;
using UnityEngine;

public class Tournament
{
    private static Tournament s_instance;

    public static Tournament Get()
    {
        if (s_instance == null)
        {
            Debug.LogError("Trying to retrieve the Tournament without calling Tournament.Init()!");
        }
        return s_instance;
    }

    public static void Init()
    {
        if (s_instance != null)
        {
            Debug.LogError("Tournament.Init() has already been called!");
        }
        else
        {
            s_instance = new Tournament();
        }
    }

    public void NotifyOfBoxTransitionStart()
    {
        Box.Get().AddTransitionFinishedListener(new Box.TransitionFinishedCallback(this.OnBoxTransitionFinished));
    }

    public void OnBoxTransitionFinished(object userData)
    {
        Box.Get().RemoveTransitionFinishedListener(new Box.TransitionFinishedCallback(this.OnBoxTransitionFinished));
        if (!Options.Get().GetBool(Option.HAS_SEEN_TOURNAMENT, false))
        {
            Options.Get().SetBool(Option.HAS_SEEN_TOURNAMENT, true);
        }
    }
}

