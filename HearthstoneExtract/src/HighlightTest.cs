using System;
using UnityEngine;

public class HighlightTest : MonoBehaviour
{
    public static void TestSetAllState(ActorStateType stateType)
    {
        HighlightState[] stateArray = UnityEngine.Object.FindObjectsOfType(typeof(HighlightState)) as HighlightState[];
        if (stateArray != null)
        {
            foreach (HighlightState state in stateArray)
            {
                state.ChangeState(stateType);
            }
        }
    }

    public void TestSetAllState_CARD_COMBO()
    {
        TestSetAllState(ActorStateType.CARD_COMBO);
    }

    public void TestSetAllState_CARD_COMBO_MOUSE_OVER()
    {
        TestSetAllState(ActorStateType.CARD_COMBO_MOUSE_OVER);
    }

    public void TestSetAllState_CARD_HISTORY()
    {
        TestSetAllState(ActorStateType.CARD_HISTORY);
    }

    public void TestSetAllState_CARD_IDLE()
    {
        TestSetAllState(ActorStateType.CARD_IDLE);
    }

    public void TestSetAllState_CARD_MOUSE_OVER()
    {
        TestSetAllState(ActorStateType.CARD_MOUSE_OVER);
    }

    public void TestSetAllState_CARD_OPPONENT_MOUSE_OVER()
    {
        TestSetAllState(ActorStateType.CARD_OPPONENT_MOUSE_OVER);
    }

    public void TestSetAllState_CARD_OVER_PLAYFIELD()
    {
        TestSetAllState(ActorStateType.CARD_OVER_PLAYFIELD);
    }

    public void TestSetAllState_CARD_PLAYABLE()
    {
        TestSetAllState(ActorStateType.CARD_PLAYABLE);
    }

    public void TestSetAllState_CARD_PLAYABLE_MOUSE_OVER()
    {
        TestSetAllState(ActorStateType.CARD_PLAYABLE_MOUSE_OVER);
    }

    public void TestSetAllState_CARD_RECENTLY_ACQUIRED()
    {
        TestSetAllState(ActorStateType.CARD_RECENTLY_ACQUIRED);
    }

    public void TestSetAllState_CARD_SELECTABLE()
    {
        TestSetAllState(ActorStateType.CARD_SELECTABLE);
    }

    public void TestSetAllState_CARD_SELECTED()
    {
        TestSetAllState(ActorStateType.CARD_SELECTED);
    }

    public void TestSetAllState_CARD_TARGETABLE()
    {
        TestSetAllState(ActorStateType.CARD_TARGETABLE);
    }

    public void TestSetAllState_CARD_VALID_TARGET()
    {
        TestSetAllState(ActorStateType.CARD_VALID_TARGET);
    }

    public void TestSetAllState_CARD_VALID_TARGET_MOUSE_OVER()
    {
        TestSetAllState(ActorStateType.CARD_VALID_TARGET_MOUSE_OVER);
    }

    public void TestSetAllState_CCARD_RECENTLY_ACQUIRED_MOUSE_OVER()
    {
        TestSetAllState(ActorStateType.CARD_RECENTLY_ACQUIRED_MOUSE_OVER);
    }

    public void TestSetAllState_HIGHLIGHT_OFF()
    {
        TestSetAllState(ActorStateType.HIGHLIGHT_OFF);
    }

    public void TestSetAllState_HIGHLIGHT_PRIMARY_ACTIVE()
    {
        TestSetAllState(ActorStateType.HIGHLIGHT_PRIMARY_ACTIVE);
    }

    public void TestSetAllState_HIGHLIGHT_PRIMARY_MOUSE_DOWN()
    {
        TestSetAllState(ActorStateType.HIGHLIGHT_PRIMARY_MOUSE_DOWN);
    }

    public void TestSetAllState_HIGHLIGHT_PRIMARY_MOUSE_OVER()
    {
        TestSetAllState(ActorStateType.HIGHLIGHT_PRIMARY_MOUSE_OVER);
    }

    public void TestSetAllState_HIGHLIGHT_SECONDARY_ACTIVE()
    {
        TestSetAllState(ActorStateType.HIGHLIGHT_SECONDARY_ACTIVE);
    }

    public void TestSetAllState_HIGHLIGHT_SECONDARY_MOUSE_DOWN()
    {
        TestSetAllState(ActorStateType.HIGHLIGHT_SECONDARY_MOUSE_DOWN);
    }

    public void TestSetAllState_HIGHLIGHT_SECONDARY_MOUSE_OVER()
    {
        TestSetAllState(ActorStateType.HIGHLIGHT_SECONDARY_MOUSE_OVER);
    }

    public void TestSetAllState_NONE()
    {
        TestSetAllState(ActorStateType.NONE);
    }
}

