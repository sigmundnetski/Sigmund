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
                        BruteHand();    // drops minions until out of mana
                        Thread.Sleep(1000);
                        BruteAttack();  // attacks enemies with minions randomly
                        Thread.Sleep(1000);
                        DoEndTurn();
                    }
                    else if (gs.IsGameOver())
                    {
                        Log.say("Game over");
                    }
                    else
                    {
                        //Log.log("Unimplemented game state");
                    }
                    break;
            }
            Thread.Sleep(1000 * 2);
        }
        public void DoMulligan()
        {
            //TODO toggle holding as needed
            //var cs = myPlayer.GetHandZone().GetCards();
            //Log.say("Mulligan with " + cs.Count + " cards ");
            //MulliganManager.Get().ToggleHoldState(cs[0]);
            //MulliganManager.Get().SetAllMulliganCardsToHold();

            // End mulligan
            Log.log("Handling mulligan");
            Thread.Sleep(1000 * 5);
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
            Log.log("Attack " + attacker.GetEntity().GetName() + " -> " + attackee.GetEntity().GetName());

            try
            {
                // pick up minion
                gs.GetGameEntity().NotifyOfCardGrabbed(attacker.GetEntity());
                if (InputManager.Get().DoNetworkResponse(attacker.GetEntity()))
                {
                    EnemyActionHandler.Get().NotifyOpponentOfCardPickedUp(attacker);

                    Thread.Sleep(500);

                    Log.log("attacking with picked up minion");
                    // attack with picked up minion
                    EnemyActionHandler.Get().NotifyOpponentOfTargetModeBegin(attacker);
                    Thread.Sleep(500);
                    gs.GetGameEntity().NotifyOfBattlefieldCardClicked(attackee.GetEntity(), true);
                    if (InputManager.Get().DoNetworkResponse(attackee.GetEntity()))
                    {
                        EnemyActionHandler.Get().NotifyOpponentOfTargetEnd();

                        myPlayer.GetHandZone().UpdateLayout(-1, true);
                        myPlayer.GetBattlefieldZone().UpdateLayout();
                        Log.log("DoAttack succeeded");
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.log("DoAttack failed" + ex.StackTrace.ToString());
                return false;
            }
            finally
            {
                Thread.Sleep(1000 * 2);
            }
        }
        public bool DoDropMinion(Card c)
        {
            Log.log("Dropping minion " + c.GetEntity().GetName());
            try
            {
                var destZone = myPlayer.GetBattlefieldZone();
                int slot = destZone.GetCards().Count + 1;
                gs.GetGameEntity().NotifyOfCardDropped(c.GetEntity());
                gs.SetSelectedOptionPosition(slot);
                if (InputManager.Get().DoNetworkResponse(c.GetEntity()))
                {
                    int zonePos = c.GetEntity().GetZonePosition();
                    ZoneMgr.Get().AddLocalZoneChange(c, destZone, slot);

                    myPlayer.GetHandZone().UpdateLayout(-1, true);
                    myPlayer.GetBattlefieldZone().SortWithSpotForHeldCard(-1);

                    if (gs.GetResponseMode() != GameState.ResponseMode.SUB_OPTION)
                    {
                        EnemyActionHandler.Get().NotifyOpponentOfCardDropped();
                    }
                    Log.log("Dropping minion succeeded");
                    return true;

                    // TARGETTING - perhaps spin this off to a separate step
                    /*
                    if (gs.EntityHasTargets(c.GetEntity()))
                    {
                        // do targetting
                        EnemyActionHandler.Get().NotifyOpponentOfTargetModeBegin(c);
                        Thread.Sleep(500);
                        gs.GetGameEntity().NotifyOfBattlefieldCardClicked(target.GetEntity(), true);
                        if (InputManager.Get().DoNetworkResponse(target.GetEntity()))
                        {
                            EnemyActionHandler.Get().NotifyOpponentOfTargetEnd();
                            return true;
                        }
                        return false;
                    }
                    else if (gs.GetResponseMode() != GameState.ResponseMode.SUB_OPTION)
                    {
                        EnemyActionHandler.Get().NotifyOpponentOfCardDropped();
                        return true;
                    }
                    else
                    {
                        // TODO: unsure when this happens
                        return true;
                    }
                    */
                }
                Log.log("Dropping minion failed (network response)");
                return false;
            }
            catch (Exception ex)
            {
                Log.log("Dropping minion failed (exception): " + ex.StackTrace.ToString());
                return false;
            }
            finally
            {
                Thread.Sleep(1000 * 2);
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
            //eCards.Add(ePlayer.GetHeroCard());
            if (eCards.Count == 0)
            {
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
        /*
        public bool PlayCard(Card c)
        {
            var gs = GameState.Get();
            var p = gs.GetLocalPlayer();

            var e = c.GetEntity();
            Log.log("Playing " + e.GetName());

            InputManager im = InputManager.Get();
            var ge = gs.GetGameEntity();
            //ge.NotifyOfCardDropped(e);

            bool isMinion = e.IsMinion();
            bool isWeapon = e.IsWeapon();
            Zone destZone = null;

            try
            {
                if (isMinion)
                {
                    destZone = p.GetBattlefieldZone();
                    int slot = destZone.GetCards().Count + 1;

                    ge.NotifyOfCardDropped(e);
                    gs.SetSelectedOptionPosition(slot);
                    if (im.DoNetworkResponse(e))
                    {
                        int zonePos = e.GetZonePosition();
                        ZoneMgr.Get().AddLocalZoneChange(c, destZone, slot);

                        p.GetHandZone().UpdateLayout(-1, true);
                        p.GetBattlefieldZone().SortWithSpotForHeldCard(-1);

                        if (gs.EntityHasTargets(e))
                        {
                            Log.log("Card has targets");
                            if ((bool)((UnityEngine.Object)EnemyActionHandler.Get()))
                            {
                                EnemyActionHandler.Get().NotifyOpponentOfTargetModeBegin(c);
                            }
                        }
                        else if (gs.GetResponseMode() != GameState.ResponseMode.SUB_OPTION)
                        {
                            EnemyActionHandler.Get().NotifyOpponentOfCardDropped();
                        }
                    }
                    Log.log("Played minion successfully");
                    return true;
                }
                else
                {
                    Log.log("Unsupported card type: " + e.GetCardType().ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.log(ex.StackTrace.ToString());
                return false;
            }
            finally
            {
                Thread.Sleep(1000 * 3); // might be needed?
            }
        }
        public void HandleGameEnd()
        {
            EndGameScreen es = EndGameScreen.Get();
            if (es != null)
            {
                Thread.Sleep(10000); //needed as some Animationspeed stuff breaks otherwise, didnt looked deeper, its a working solution for the moment
                SceneMgr.Get().SetNextMode(SceneMgr.Mode.PRACTICE);  //switch to the Play Pratice Game Menu

            }
        }
        */
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
