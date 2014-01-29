using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Plugin
{
    public class Plugin : MonoBehaviour
    {
        float timeLastRun;
        
        public static void init()
        {
            var go = SceneMgr.Get().gameObject; // attach to SceneMgr since it always exists

            // destroy any old versions of ourself
            GameObject.Destroy(go.GetComponent("Plugin"));
            foreach (var x in go.GetComponents<Plugin>())
            {
                Log.debug("destroying old component: " + x.ToString());
                GameObject.Destroy(x);
            }
            Log.debug("Destroyed old plugin");

            go.AddComponent<Plugin>();
        }

        public void Awake()     // This is called after loading the DLL, before the loader gives back control to Unity
        {
        }
        public void Start()     // This is called after control is given back to Unity
        {
            timeLastRun = Time.realtimeSinceStartup;
            Log.say("Plugin started");
        }
        public void Update()    // This is called every frame from Unity's main thread
        {
            // Wait a few seconds between runs
            if (Time.realtimeSinceStartup - timeLastRun < 3) { return; }
            timeLastRun = Time.realtimeSinceStartup;

            try
            {
                Mainloop();
            }
            catch (Exception ex)
            {
                Log.log(ex.StackTrace.ToString());
            }
        }

        GameState gs;
        Player myPlayer;
        Player ePlayer;

        public void Init_Game()
        {
            gs = GameState.Get();
            myPlayer = gs.GetLocalPlayer();
            ePlayer = gs.GetFirstOpponentPlayer(myPlayer);
        }
        public void Mainloop()
        {
            var curMode = SceneMgr.Get().GetMode();

            switch (curMode)
            {
                case SceneMgr.Mode.HUB:
                    SceneMgr.Get().SetNextMode(SceneMgr.Mode.PRACTICE);
                    break;
                case SceneMgr.Mode.PRACTICE:
                    if (!SceneMgr.Get().IsInGame())
                    {
                        //TODO: make deck and mission id configurable
                        long myDeckId = DeckPickerTrayDisplay.Get().GetSelectedDeckID();
                        var mission = MissionID.AI_NORMAL_MAGE;
                        GameMgr.Get().StartGame(GameMode.PRACTICE, mission, myDeckId);
                    }
                    break;
                case SceneMgr.Mode.GAMEPLAY:
                    Init_Game();
                    if (gs.IsMulliganPhase())
                    {
                        DoMulligan();
                    }
                    else if (gs.IsGameOver())
                    {
                        if (EndGameScreen.Get() != null)
                        {
                            EndGameScreen.Get().ContinueEvents();
                        }
                    }
                    else if (gs.IsLocalPlayerTurn())
                    {
                        bool stop = false;      // flag if we should stop at this step (and cont. next tick) instead of moving on

                        stop = BruteHand();     // drops minions until out of mana
                        if (stop) { return; }

                        stop = BruteAttack();   // attacks enemies with minions randomly
                        if (stop) { return; }

                        DoEndTurn();
                    }
                    else
                    {
                        //Log.log("Unimplemented game state");
                    }
                    break;
            }
        }
        public void DoMulligan()
        {
            InputManager.Get().DoEndTurnButton();
            TurnStartManager.Get().BeginListeningForTurnEvents();
            MulliganManager.Get().EndMulliganEarly();
        }
        public void DoEndTurn()
        {
            InputManager im = InputManager.Get();
            im.DoEndTurnButton();
        }
        public bool BruteHand()
        {
            var drop = NextBestMinionDrop();
            if (drop == null)
            {
                return false;   // no more minions to drop => continue to attacking phase
            }
            if (DoDropMinion(drop))
            {
                return true;    // successfully dropped minion. stop here and continue next frame
            }
            return true;       // had a minion to drop but failed to play it. try again next frame
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
        public bool BruteAttack()
        {
            var attacker = NextBestAttacker();
            var attackee = NextBestAttackee(); // in theory could be null if enemy hero was somehow invulnerable
            if (attacker == null || attackee == null)
            {
                return false;
            }
            if (DoAttack(attacker, attackee))
            {
                return true;    // successful attack. stop here and continue next frame
            }
            return true;        // failed to execute attack. try again next frame
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
                gs.GetGameEntity().NotifyOfCardGrabbed(attacker.GetEntity());
                myPlayer.GetBattlefieldZone().UnHighlightBattlefield();

                Log.log("    DoAttack: noted card grab. doing net response");
                Log.log("    Response mode pre: " + gs.GetResponseMode().ToString());
                if (InputManager.Get().DoNetworkResponse(attacker.GetEntity()))
                {
                    Log.log("    Response mode post: " + gs.GetResponseMode().ToString());
                    EnemyActionHandler.Get().NotifyOpponentOfCardPickedUp(attacker);

                    // attack with picked up minion
                    EnemyActionHandler.Get().NotifyOpponentOfTargetModeBegin(attacker);
                    gs.GetGameEntity().NotifyOfBattlefieldCardClicked(attackee.GetEntity(), true);
                    myPlayer.GetBattlefieldZone().UnHighlightBattlefield();
                    Log.log("    Response mode pre: " + gs.GetResponseMode().ToString());
                    if (InputManager.Get().DoNetworkResponse(attackee.GetEntity()))
                    {
                        Log.log("    Response mode post: " + gs.GetResponseMode().ToString());
                        EnemyActionHandler.Get().NotifyOpponentOfTargetEnd();

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
                c.NotifyPickedUp();
                gs.GetGameEntity().NotifyOfCardGrabbed(c.GetEntity());
                Log.log("    picked card up");

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
                Log.log("    Response mode pre: " + gs.GetResponseMode().ToString());
                if (InputManager.Get().DoNetworkResponse(c.GetEntity()))
                {
                    Log.log("    Response mode post: " + gs.GetResponseMode().ToString());
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
                Log.log("    DoDropMinion exiting");
                return true;
            }
            catch (Exception ex)
            {
                Log.log("    Dropping minion failed (exception): " + ex.StackTrace.ToString());
                return false;
            }
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
            Console.WriteLine( DateTime.Now.ToLongTimeString() + ": " + msg);
        }
        public static void log(int msg)
        {
            log(msg.ToString());
        }
        public static void say(string msg)
        {
            log(msg);
            UIStatus.Get().AddInfo(msg);
        }
    }
}
