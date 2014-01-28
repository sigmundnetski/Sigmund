using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Plugin
{
    public class Plugin
    {
        public static void init()
        {
            Test t = new Test();
            while (true)
            {
                try
                {
                    t.MainLoop();
                }
                catch (Exception ex)
                {
                    Log.say(ex.StackTrace.ToString());
                }
            }
        }
    }

    public class Test
    {
        GameState gs;
        Player myPlayer;
        Player ePlayer;
        public void Init_Game()
        {
            gs = GameState.Get();
            myPlayer = gs.GetLocalPlayer();
            ePlayer = gs.GetFirstOpponentPlayer(myPlayer);
        }
        public void MainLoop()
        {
            var curMode = SceneMgr.Get().GetMode();
            switch (curMode)
            {
                case SceneMgr.Mode.HUB:
                    SceneMgr.Get().SetNextMode(SceneMgr.Mode.PRACTICE);
                    Thread.Sleep(1000 * 2);
                    break;
                case SceneMgr.Mode.PRACTICE:
                    //TODO: make deck and mission id configurable
                    long myDeckId = DeckPickerTrayDisplay.Get().GetSelectedDeckID();
                    var mission = MissionID.AI_NORMAL_MAGE;
                    GameMgr.Get().StartGame(GameMode.PRACTICE, mission, myDeckId);
                    Thread.Sleep(1000 * 5);
                    break;
                case SceneMgr.Mode.GAMEPLAY:
                    Init_Game();
                    if (gs.IsMulliganPhase())
                    {
                        DoMulligan();
                    }
                    else if (gs.IsLocalPlayerTurn())
                    {
                        // should we wait until also gs.IsMainPhase() ?
                        Log.log("Start our turn");
                        Log.log("Response mode: " + gs.GetResponseMode().ToString());
                        BruteHand();    // drops minions until out of mana
                        Thread.Sleep(1000);
                        BruteAttack();  // attacks enemies with minions randomly
                        Thread.Sleep(1000);
                        DoEndTurn();
                    }
                    else if (gs.IsGameOver())
                    {
                        Log.say("Game over");
                        Thread.Sleep(1000 * 3);
                        Network.EndGame();
                        SceneMgr.Get().SetNextMode(SceneMgr.Get().GetPrevMode());
                    }
                    else
                    {
                        //Log.log("Unimplemented game state");
                    }
                    break;
            }
            Thread.Sleep(1000 * 2);
        }
        public void DoMulligan() //TODO: this triggers way too earlier, look for better solution than 7sec sleep
        {
            //TODO toggle holding as needed
            //var cs = myPlayer.GetHandZone().GetCards();
            //Log.say("Mulligan with " + cs.Count + " cards ");
            //MulliganManager.Get().ToggleHoldState(cs[0]);
            //MulliganManager.Get().SetAllMulliganCardsToHold();

            // End mulligan
            Log.log("Handling mulligan");
            Thread.Sleep(1000 * 7);
            //MulliganManager.Get().SetAllMulliganCardsToHold();
            InputManager.Get().DoEndTurnButton();
            TurnStartManager.Get().BeginListeningForTurnEvents();
            MulliganManager.Get().EndMulliganEarly();
            Thread.Sleep(1000 * 5);
            Log.log("Done handling mulligan");
        }
        public void DoEndTurn()
        {
            Log.log("Ending turn");
            InputManager im = InputManager.Get();
            im.DoEndTurnButton();
            Thread.Sleep(5000);
            Log.log("Done ending turn");
        }
        public bool DoAttack(Card attacker, Card attackee)
        {
            Log.log("DoAttack " + attacker.GetEntity().GetName() + " -> " + attackee.GetEntity().GetName());

            try
            {
                // stop stuff
                attacker.SetDoNotSort(true);
                iTween.Stop(attacker.gameObject);
                KeywordHelpPanelManager.Get().HideKeywordHelp();
                CardTypeBanner.Hide();
                attacker.NotifyPickedUp();

                // pick up minion
                Thread.Sleep(1000);
                gs.GetGameEntity().NotifyOfCardGrabbed(attacker.GetEntity());
                myPlayer.GetBattlefieldZone().UnHighlightBattlefield();
                Thread.Sleep(1000);

                Log.log("    DoAttack: noted card grab. doing net response");
                Log.log("    Response mode: " + gs.GetResponseMode().ToString());
                if (InputManager.Get().DoNetworkResponse(attacker.GetEntity()))
                {
                    Log.log("    Response mode: " + gs.GetResponseMode().ToString());
                    Log.log("    DoAttack: did outer DoNetworkReponse");
                    Thread.Sleep(1000);
                    EnemyActionHandler.Get().NotifyOpponentOfCardPickedUp(attacker);

                    Thread.Sleep(1000);

                    Log.log("    DoAttack: notified opponent of card picked up");
                    // attack with picked up minion
                    EnemyActionHandler.Get().NotifyOpponentOfTargetModeBegin(attacker);
                    Thread.Sleep(1000);
                    gs.GetGameEntity().NotifyOfBattlefieldCardClicked(attackee.GetEntity(), true);
                    myPlayer.GetBattlefieldZone().UnHighlightBattlefield();
                    Thread.Sleep(1000);
                    Log.log("    Response mode: " + gs.GetResponseMode().ToString());
                    if (InputManager.Get().DoNetworkResponse(attackee.GetEntity()))
                    {
                        Log.log("    Response mode: " + gs.GetResponseMode().ToString());
                        Log.log("    DoAttack did inner network response");
                        Thread.Sleep(1000);
                        //EnemyActionHandler.Get().NotifyOpponentOfTargetEnd();
                        Thread.Sleep(1000);

                        myPlayer.GetHandZone().UpdateLayout(-1, true);
                        myPlayer.GetBattlefieldZone().UpdateLayout();
                        Log.log("    DoAttack succeeded");
                        return true;
                    }
                    else
                    {
                        Log.log("    DoAttack inner DoNetworkResponse failed");
                    }
                }
                else
                {
                    Log.log("    DoAttack outer DoNetworkReponse failed");
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.log("    DoAttack failed" + ex.StackTrace.ToString());
                return false;
            }
            finally
            {
                Thread.Sleep(1000 * 2);
            }
        }
        public bool DoDropMinion(Card c) // if card needs to specify targets, you need to do that immediately after this
        {
            Log.log("DoDropMinion " + c.GetEntity().GetName());
            try
            {
                // stop stuff
                PegCursor.Get().SetMode(PegCursor.Mode.STOPDRAG);
                c.SetDoNotSort(true);
                iTween.Stop(c.gameObject);
                KeywordHelpPanelManager.Get().HideKeywordHelp();
                CardTypeBanner.Hide();

                var sfx = c.GetActor().GetComponent<DragCardSoundEffects>();
                if (sfx != null)
                {
                    sfx.Disable();
                }
                var pshadow = c.GetActor().GetComponentInChildren<ProjectedShadow>();
                if (pshadow != null)
                {
                    pshadow.DisableShadow();
                }

                // pick up card
                Thread.Sleep(1000);
                c.NotifyPickedUp();
                gs.GetGameEntity().NotifyOfCardGrabbed(c.GetEntity());
                Log.log("    picked card up");
                Thread.Sleep(1000);

                // drop minion
                c.SetDoNotSort(false);
                c.NotifyLeftPlayfield();

                bool doTargetting = false;
                var destZone = myPlayer.GetBattlefieldZone();
                int slot = destZone.GetCards().Count + 1;

                Log.log("    DoDropMinion: did pre-action layout update and calculated slot/zone " + slot + " / " + destZone.ToString());
                gs.GetGameEntity().NotifyOfCardDropped(c.GetEntity());
                destZone.UnHighlightBattlefield();

                gs.SetSelectedOptionPosition(slot);
                Thread.Sleep(1000);
                Log.log("    DoDropMinion: set position");
                Log.log("    Response mode: " + gs.GetResponseMode().ToString());
                if (InputManager.Get().DoNetworkResponse(c.GetEntity()))
                {
                    Log.log("    Response mode: " + gs.GetResponseMode().ToString());
                    Thread.Sleep(1000);
                    Log.log("    DoDropMinion: did DoNetworkResponse");
                    // Update local ui
                    int zonePos = c.GetEntity().GetZonePosition();
                    ZoneMgr.Get().AddLocalZoneChange(c, destZone, slot);

                        // InputManager.ForceManaUpdate
                    myPlayer.NotifyOfSpentMana(c.GetEntity().GetRealTimeCost());
                    myPlayer.UpdateManaCounter();
                    ManaCrystalMgr.Get().UpdateSpentMana(c.GetEntity().GetRealTimeCost());

                    // handle battlecry targets
                    if (gs.EntityHasTargets(c.GetEntity()))
                    {
                        doTargetting = true;
                    }
                    Log.log("    DoDropMinion: did inner updates");
                }
                else
                {
                    Log.log("    DropMinion DoNetworkReponse failed, unsetting position");
                    gs.SetSelectedOptionPosition(Network.NoPosition);
                }

                // update layout
                myPlayer.GetHandZone().UpdateLayout(-1, true);
                myPlayer.GetBattlefieldZone().SortWithSpotForHeldCard(-1);
                Log.log("    DropMinion: updated layouts");

                // do notifies
                Thread.Sleep(1000);
                if (doTargetting)
                {
                    Log.log("    DoDropMinion doing targetting");
                    if (EnemyActionHandler.Get() != null)
                    {
                        EnemyActionHandler.Get().NotifyOpponentOfTargetModeBegin(c);
                    }
                }
                else
                {
                    EnemyActionHandler.Get().NotifyOpponentOfCardDropped();
                }
                Log.log("    DoDropMinion exiting sucessfully?");
                return true;
            }
            catch (Exception ex)
            {
                Log.log("    Dropping minion failed (exception): " + ex.StackTrace.ToString());
                return false;
            }
            finally
            {
                Thread.Sleep(1000 * 3);
            }
        }
        
        public void BruteHand()
        {
            int numCardsPlayed = 0;
            for (int i = 0; i < myPlayer.GetHandZone().GetCards().Count + 10; i++) // count is temp hack
            {
                var drop = NextBestMinionDrop();
                if (drop == null)
                {
                    Log.log("Played " + numCardsPlayed + " cards from hand");
                    return;
                }
                Thread.Sleep(1000);
                if (DoDropMinion(drop))
                {
                    numCardsPlayed += 1;
                }
            }
            Log.log("BruteHand shouldn't be here");
        }
        public Card NextBestMinionDrop()
        {
            var myCards = myPlayer.GetHandZone().GetCards();
            foreach (Card c in myCards)
            {
                var e = c.GetEntity();

                // skip if not the right type, mana cost, etc
                if (e.GetCardType() != TAG_CARDTYPE.MINION || e.GetCost() > myPlayer.GetNumAvailableResources())
                {
                    continue;
                }
                return c;
            }
            return null;
        }
        public void BruteAttack()
        {
            int numAttacks = 0;
            for (int i = 0; i < myPlayer.GetBattlefieldZone().GetCards().Count + 10; i++) // count is temp hack
            {
                var attacker = NextBestAttacker();
                var attackee = NextBestAttackee(); // TODO can't be null in theory, but keep check in anyways for now
                if (attacker == null || attackee == null)
                {
                    Log.log("Did " + numAttacks + " attacks");
                    return;
                }
                Thread.Sleep(1000);
                if (DoAttack(attacker, attackee))
                {
                    numAttacks += 1;
                }
            }
            Log.log("BruteAttack shouldn't be here");
        }
        public Card NextBestAttacker()
        {
            //TODO: consider weapons, hero, hero power
            var myCards = myPlayer.GetBattlefieldZone().GetCards();
            foreach (Card c in myCards)
            {
                var e = c.GetEntity();

                // skip if can't attack at all
                if (e.IsAsleep() || e.IsExhausted() || e.IsFrozen() || e.IsRecentlyArrived() || !e.CanAttack() || e.GetATK() < 1)
                {
                    continue;
                }
                return c;
            }
            return null;
        }
        public Card NextBestAttackee()
        {
            var eCards = ePlayer.GetBattlefieldZone().GetCards().ToList();

            // attack enemy hero iff no enemy minions
            //eCards.Add(ePlayer.GetHeroCard());
            if (eCards.Count == 0)
            {
                var c = ePlayer.GetHeroCard();
                if (c.GetEntity().CanBeAttacked())
                {
                    return c;
                }
                return null;
            }

            Card best = eCards[0];

            // look for a better option
            foreach (Card c in eCards)
            {
                var e = c.GetEntity();

                // skip if somehow immune to being attacked
                if (!e.CanBeAttacked())
                {
                    continue;
                }

                // always take taunter over non-taunter
                if (e.HasTaunt() || !best.GetEntity().HasTaunt())
                {
                    best = c;
                }
            }
            return best;
        }
    }
    public class Log
    {
        public static void debug(string msg)
        {
            log(msg);
        }
        public static void log(string msg)
        {
            Console.WriteLine(msg);
        }
        public static void log(int msg)
        {
            log(msg);
        }
        public static void say(string msg)
        {
            log(msg);
            UIStatus.Get().AddInfo(msg);
        }
    }
}
