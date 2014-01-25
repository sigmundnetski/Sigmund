using System;
using UnityEngine;

public class StandardGameEntity : GameEntity
{
    private void EmoteHandlerDoneLoadingCallback(string actorName, GameObject actorObject, object callbackData)
    {
        actorObject.transform.position = ZoneMgr.Get().FindZoneOfType<ZoneHero>(TAG_ZONE.PLAY, Player.Side.FRIENDLY).transform.position;
    }

    public override void NotifyOfMulliganEnded()
    {
        if (!MissionMgr.Get().IsTutorial())
        {
            AssetLoader.Get().LoadActor("EmoteHandler", new AssetLoader.GameObjectCallback(this.EmoteHandlerDoneLoadingCallback));
        }
    }

    public override void OnTagChanged(TagDelta change)
    {
        switch (((GAME_TAG) change.tag))
        {
            case GAME_TAG.MISSION_EVENT:
                if ((change.newValue == 0x3e7) && (EmoteHandler.Get() == null))
                {
                    AssetLoader.Get().LoadActor("EmoteHandler", new AssetLoader.GameObjectCallback(this.EmoteHandlerDoneLoadingCallback));
                }
                break;

            case GAME_TAG.STEP:
                if (change.newValue == 4)
                {
                    MulliganManager.Get().BeginMulligan();
                    goto Label_00DE;
                }
                if (((change.newValue == 10) && (change.oldValue == 9)) && GameState.Get().IsLocalPlayerTurn())
                {
                    if (!GameState.Get().IsMulliganPhase())
                    {
                        TurnStartManager.Get().BeginPlayingTurnEvents();
                    }
                    else
                    {
                        MulliganManager.Get().NotifyOfTurnBegun();
                    }
                }
                break;
        }
    Label_00DE:
        base.OnTagChanged(change);
    }
}

