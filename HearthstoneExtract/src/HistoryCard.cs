using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HistoryCard : MonoBehaviour
{
    private const float ABILITY_CARD_ANIMATE_TO_BIG_CARD_AREA_TIME = 1f;
    private bool actorHasBeenInitializied;
    private const float BIG_CARD_SCALE = 1.03f;
    private bool dead;
    private bool finishedCallbackHasRun;
    private HistoryManager.FinishedCallback finishedLoadingCallback;
    private bool halfSize;
    private bool hasBeenShown;
    private List<HistoryChildCard> historyChildren;
    private bool isFatigue;
    private Texture m_bigCardPortraitTexture;
    private Material m_bigCardPotraitGoldenMaterial;
    private Entity m_entity;
    private Material m_fullHistory;
    private Material m_halfHistory;
    public Actor m_mainCardActor;
    private int m_splatAmount;
    public Actor m_tileActor;
    private float MOUSE_OVER_HEIGHT_OFFSET = 7.524521f;
    private float MOUSE_OVER_X_OFFSET = 4.326718f;
    private float MOUSE_OVER_Z_OFFSET_BOTTOM = 0.1681719f;
    private float MOUSE_OVER_Z_OFFSET_TOP = -1.404475f;
    private bool mousedOver;
    private bool secretFinished;
    private Actor seperator;
    private bool seperatorStartedLoading;
    private const float TIME_TO_WAIT_BEFORE_RUNNING_SPELL_EFFECTS = 1f;
    private bool waitingForSecretToFinish;
    private bool wasCountered;
    private float X_SIZE_OF_MOUSE_OVER_CARD = 2.5f;

    public void AddHistoryChild(HistoryChildCard childCard)
    {
        this.historyChildren.Add(childCard);
        if ((this.seperator == null) && !this.seperatorStartedLoading)
        {
            this.LoadArrow();
        }
    }

    public void AssignMaterials(CardDef cardDef)
    {
        this.m_fullHistory = cardDef.m_HistoryTileFullPortrait;
        this.m_halfHistory = cardDef.m_HistoryTileHalfPortrait;
    }

    private void Awake()
    {
        this.historyChildren = new List<HistoryChildCard>();
    }

    private void DisplaySkullOnActor(Actor actor)
    {
        Spell spell = actor.GetSpell(SpellType.SKULL);
        if (spell != null)
        {
            spell.Activate();
        }
    }

    private void DisplaySplatOnActor(Actor actor, int damage)
    {
        Spell spell = actor.GetSpell(SpellType.DAMAGE);
        if (spell != null)
        {
            DamageSplatSpell spell2 = (DamageSplatSpell) spell;
            spell2.SetDamage(damage);
            spell2.Activate();
        }
    }

    public Texture GetBigCardPortraitTexture()
    {
        return this.m_bigCardPortraitTexture;
    }

    public Material GetBigCardPotraitGoldenMaterial()
    {
        return this.m_bigCardPotraitGoldenMaterial;
    }

    public Entity GetEntity()
    {
        return this.m_entity;
    }

    public bool GetHalfSize()
    {
        return this.halfSize;
    }

    private Vector3 GetHistoryTokenScale()
    {
        return HistoryManager.Get().transform.localScale;
    }

    public Collider GetTileCollider()
    {
        if (this.m_tileActor == null)
        {
            return null;
        }
        if (this.m_tileActor.GetMeshRenderer() == null)
        {
            return null;
        }
        Transform transform = this.m_tileActor.GetMeshRenderer().transform.FindChild("Collider");
        if (transform == null)
        {
            return null;
        }
        return transform.collider;
    }

    private float GetZOffsetForThisTilesMouseOverCard()
    {
        HistoryManager manager = HistoryManager.Get();
        float num2 = Mathf.Abs((float) (this.MOUSE_OVER_Z_OFFSET_TOP - this.MOUSE_OVER_Z_OFFSET_BOTTOM)) / ((float) manager.GetNumHistoryTiles());
        int num3 = (manager.GetNumHistoryTiles() - manager.GetIndexForTile(this)) - 1;
        return (this.MOUSE_OVER_Z_OFFSET_TOP + (num2 * num3));
    }

    public bool HasBeenShown()
    {
        return this.hasBeenShown;
    }

    private void InitializeActor()
    {
        this.m_mainCardActor.TurnOffCollider();
        if (!this.isFatigue && (this.m_entity.IsCharacter() || this.m_entity.IsWeapon()))
        {
            if (this.dead || (this.m_splatAmount >= this.m_entity.GetRemainingHP()))
            {
                this.DisplaySkullOnActor(this.m_mainCardActor);
            }
            else if (this.m_splatAmount != 0)
            {
                this.DisplaySplatOnActor(this.m_mainCardActor, this.m_splatAmount);
            }
        }
        this.m_mainCardActor.SetActorState(ActorStateType.CARD_HISTORY);
        this.actorHasBeenInitializied = true;
    }

    private void LoadArrow()
    {
        this.seperatorStartedLoading = true;
        AssetLoader.Get().LoadActor("History_Arrow", new AssetLoader.GameObjectCallback(this.LoadSeperatorCallback));
    }

    public void LoadAttackTileActor()
    {
        this.halfSize = true;
        AssetLoader.Get().LoadActor("HistoryTile_Attack", new AssetLoader.GameObjectCallback(this.LoadTileActorCallback));
        this.LoadCrossedSwords();
    }

    public void LoadBigCardActor(bool andShowBigCard)
    {
        if (this.isFatigue)
        {
            AssetLoader.Get().LoadActor("Card_Hand_Fatigue", new AssetLoader.GameObjectCallback(this.LoadBigCardActorCallbackAndDontShowBigCard));
        }
        else
        {
            string historyActor = ActorNames.GetHistoryActor(this.m_entity);
            if (andShowBigCard)
            {
                AssetLoader.Get().LoadActor(historyActor, new AssetLoader.GameObjectCallback(this.LoadBigCardActorCallbackAndShowBigCard));
            }
            else
            {
                AssetLoader.Get().LoadActor(historyActor, new AssetLoader.GameObjectCallback(this.LoadBigCardActorCallbackAndDontShowBigCard));
            }
        }
    }

    private void LoadBigCardActorCallback(string actorName, GameObject actorObject, object callbackData, bool showBigCard)
    {
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("HistoryCard.LoadBigCardActorCallback() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("HistoryCard.LoadBigCardActorCallback() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                this.m_mainCardActor = component;
                this.m_mainCardActor.SetCardFlair(this.m_entity.GetCardFlair());
                this.m_mainCardActor.SetHistoryCard(this);
                if (!showBigCard)
                {
                    SceneUtils.SetLayer(this.m_mainCardActor.gameObject, GameLayer.Tooltip);
                }
                if (this.isFatigue)
                {
                    this.m_mainCardActor.GetPowersTextMesh().Text = GameStrings.Get("GAMEPLAY_FATIGUE_HISTORY_TEXT");
                }
                if (showBigCard)
                {
                    HistoryManager.Get().SetBigCard(this, this.waitingForSecretToFinish);
                    base.StartCoroutine(this.WaitForSecretIfNecessary(actorObject));
                }
                else
                {
                    this.PositionMouseOverCard();
                }
            }
        }
    }

    private void LoadBigCardActorCallbackAndDontShowBigCard(string actorName, GameObject actorObject, object callbackData)
    {
        this.LoadBigCardActorCallback(actorName, actorObject, callbackData, false);
    }

    private void LoadBigCardActorCallbackAndShowBigCard(string actorName, GameObject actorObject, object callbackData)
    {
        this.LoadBigCardActorCallback(actorName, actorObject, callbackData, true);
    }

    public void LoadCorrectTileActor(HistoryInfo sourceCard)
    {
        switch (sourceCard.infoType)
        {
            case HistoryInfoType.NONE:
            case HistoryInfoType.CARD_PLAYED:
            case HistoryInfoType.FATIGUE:
                this.LoadTileActor();
                break;

            case HistoryInfoType.ATTACK:
                this.LoadAttackTileActor();
                break;

            case HistoryInfoType.TRIGGER:
                this.LoadTriggerTileActor();
                break;

            case HistoryInfoType.WEAPON_BREAK:
                this.LoadWeaponBreakActor();
                break;
        }
    }

    private void LoadCrossedSwords()
    {
        this.seperatorStartedLoading = true;
        AssetLoader.Get().LoadActor("History_Swords", new AssetLoader.GameObjectCallback(this.LoadSeperatorCallback));
    }

    private void LoadSeperatorCallback(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("HistoryCard.LoadTileActorCallback() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("HistoryCard.LoadTileActorCallback() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                this.seperator = component;
                MeshRenderer renderer = this.seperator.GetRootObject().transform.FindChild("Blue").gameObject.GetComponent<MeshRenderer>();
                MeshRenderer renderer2 = this.seperator.GetRootObject().transform.FindChild("Red").gameObject.GetComponent<MeshRenderer>();
                if (this.isFatigue)
                {
                    renderer2.enabled = true;
                    renderer.enabled = false;
                }
                else
                {
                    bool flag = this.m_entity.IsControlledByLocalPlayer();
                    renderer.enabled = flag;
                    renderer2.enabled = !flag;
                }
                this.seperator.transform.parent = base.transform;
                TransformUtil.Identity(this.seperator.transform);
                if (this.seperator.GetRootObject() != null)
                {
                    TransformUtil.Identity(this.seperator.GetRootObject().transform);
                }
                this.seperator.Hide();
            }
        }
    }

    public void LoadTileActor()
    {
        this.halfSize = false;
        AssetLoader.Get().LoadActor("HistoryTile_Card", new AssetLoader.GameObjectCallback(this.LoadTileActorCallback));
        if (this.historyChildren.Count > 0)
        {
            this.LoadArrow();
        }
    }

    private void LoadTileActorCallback(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("HistoryCard.LoadTileActorCallback() - FAILED to load actor \"{0}\"", actorName));
            HistoryManager.Get().OnHistoryTileComplete();
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                UnityEngine.Debug.LogWarning(string.Format("HistoryCard.LoadTileActorCallback() - ERROR actor \"{0}\" has no Actor component", actorName));
                HistoryManager.Get().OnHistoryTileComplete();
            }
            else
            {
                this.m_tileActor = component;
                this.m_tileActor.transform.parent = base.transform;
                TransformUtil.Identity(this.m_tileActor.transform);
                this.m_tileActor.transform.localScale = this.GetHistoryTokenScale();
                Material[] materialArray = new Material[2];
                materialArray[0] = this.m_tileActor.GetMeshRenderer().materials[0];
                if (this.halfSize)
                {
                    if (this.m_halfHistory != null)
                    {
                        materialArray[1] = this.m_halfHistory;
                        this.m_tileActor.GetMeshRenderer().materials = materialArray;
                    }
                    else
                    {
                        this.m_tileActor.GetMeshRenderer().materials[1].mainTexture = this.m_bigCardPortraitTexture;
                    }
                }
                else if (this.m_fullHistory != null)
                {
                    materialArray[1] = this.m_fullHistory;
                    this.m_tileActor.GetMeshRenderer().materials = materialArray;
                }
                else
                {
                    this.m_tileActor.GetMeshRenderer().materials[1].mainTexture = this.m_bigCardPortraitTexture;
                }
                if (!this.isFatigue)
                {
                    if (this.m_entity.IsControlledByLocalPlayer())
                    {
                        this.m_tileActor.GetMeshRenderer().materials[0].color = new Color(0.6509804f, 0.6705883f, 0.9843137f, 1f);
                    }
                    else
                    {
                        this.m_tileActor.GetMeshRenderer().materials[0].color = new Color(0.7176471f, 0.2f, 0.1333333f, 1f);
                    }
                }
                if ((this.GetTileCollider() != null) && !this.GetHalfSize())
                {
                    HistoryManager.Get().SetBigTileSize(this.GetTileCollider().bounds.size.z);
                }
                HistoryManager.Get().SetAsideTileAndTryToUpdate(this);
                HistoryManager.Get().OnHistoryTileComplete();
            }
        }
    }

    private void LoadTriggerTileActor()
    {
        this.halfSize = true;
        AssetLoader.Get().LoadActor("HistoryTile_Trigger", new AssetLoader.GameObjectCallback(this.LoadTileActorCallback));
        if (this.historyChildren.Count > 0)
        {
            this.LoadArrow();
        }
    }

    public void LoadWeaponBreakActor()
    {
        this.halfSize = true;
        AssetLoader.Get().LoadActor("HistoryTile_Attack", new AssetLoader.GameObjectCallback(this.LoadTileActorCallback));
    }

    public void MarkAsShown()
    {
        this.hasBeenShown = true;
    }

    public void NotifyMousedOut()
    {
        if (this.mousedOver)
        {
            this.mousedOver = false;
            GameState.Get().GetGameEntity().NotifyOfHistoryTokenMousedOff();
            KeywordHelpPanelManager.Get().HideKeywordHelp();
            if (this.m_mainCardActor != null)
            {
                this.m_mainCardActor.DeactivateAllSpells();
                this.m_mainCardActor.Hide();
            }
            for (int i = 0; i < this.historyChildren.Count; i++)
            {
                this.historyChildren[i].m_mainCardActor.DeactivateAllSpells();
                this.historyChildren[i].m_mainCardActor.Hide();
            }
            if (this.seperator != null)
            {
                this.seperator.Hide();
            }
            HistoryManager.Get().UpdateLayout();
        }
    }

    public void NotifyMousedOver()
    {
        if (!this.mousedOver && (this != HistoryManager.Get().GetCurrentBigCard()))
        {
            this.mousedOver = true;
            GameState.Get().GetGameEntity().NotifyOfHistoryTokenMousedOver(base.gameObject);
            if (this.m_mainCardActor != null)
            {
                this.PositionMouseOverCard();
            }
            else
            {
                this.LoadBigCardActor(false);
            }
        }
    }

    public void NotifyOfSecretFinished()
    {
        this.secretFinished = true;
    }

    private void PositionMouseOverCard()
    {
        this.m_mainCardActor.Show();
        if (!this.actorHasBeenInitializied)
        {
            this.InitializeActor();
        }
        this.m_mainCardActor.transform.position = new Vector3(base.transform.position.x + this.MOUSE_OVER_X_OFFSET, base.transform.position.y + this.MOUSE_OVER_HEIGHT_OFFSET, base.transform.position.z + this.GetZOffsetForThisTilesMouseOverCard());
        if (!this.isFatigue)
        {
            KeywordHelpPanelManager.Get().UpdateKeywordHelpForHistoryCard(this.m_entity, this.m_mainCardActor);
        }
        if (this.historyChildren.Count > 0)
        {
            float max = 1f;
            float num2 = 1f;
            if ((this.historyChildren.Count > 4) && (this.historyChildren.Count < 9))
            {
                num2 = 2f;
                max = 0.5f;
            }
            else if (this.historyChildren.Count >= 9)
            {
                num2 = 3f;
                max = 0.3f;
            }
            int num3 = Mathf.CeilToInt(((float) this.historyChildren.Count) / num2);
            float num4 = num3 * this.X_SIZE_OF_MOUSE_OVER_CARD;
            float num5 = this.X_SIZE_OF_MOUSE_OVER_CARD * 2f;
            float num6 = num5 / num4;
            num6 = Mathf.Clamp(num6, 0.1f, max);
            int num7 = 0;
            int num8 = 1;
            for (int i = 0; i < this.historyChildren.Count; i++)
            {
                this.historyChildren[i].m_mainCardActor.Show();
                if (!this.historyChildren[i].IsInitialized())
                {
                    this.historyChildren[i].InitializeActor();
                }
                float z = this.m_mainCardActor.transform.position.z;
                switch (num2)
                {
                    case 2f:
                        if (num8 == 1)
                        {
                            z += 0.78f;
                        }
                        else
                        {
                            z -= 0.78f;
                        }
                        break;

                    case 3f:
                        switch (num8)
                        {
                            case 1:
                                z += 0.98f;
                                break;

                            case 3:
                                z -= 0.93f;
                                break;
                        }
                        break;
                }
                this.historyChildren[i].m_mainCardActor.transform.position = new Vector3((this.m_mainCardActor.transform.position.x + this.X_SIZE_OF_MOUSE_OVER_CARD) + ((this.X_SIZE_OF_MOUSE_OVER_CARD * num7) * num6), this.m_mainCardActor.transform.position.y, z);
                this.historyChildren[i].m_mainCardActor.transform.localScale = new Vector3(num6, num6, num6);
                num7++;
                if (num7 >= num3)
                {
                    num7 = 0;
                    num8++;
                }
            }
            if (this.seperator != null)
            {
                float num11 = 0.4f;
                float num12 = this.X_SIZE_OF_MOUSE_OVER_CARD / 2f;
                this.seperator.Show();
                this.seperator.transform.position = new Vector3(this.m_mainCardActor.transform.position.x + num12, this.m_mainCardActor.transform.position.y + num11, this.m_mainCardActor.transform.position.z);
            }
        }
    }

    public void RunCallbackNow()
    {
        if (!this.finishedCallbackHasRun)
        {
            this.finishedCallbackHasRun = true;
            this.finishedLoadingCallback();
        }
    }

    public void SetCardInfo(Entity entity, Texture bigTexture, int splatAmount, bool isDead, HistoryManager.FinishedCallback callbackFunc, bool counterspelled, bool waitForSecret, Material goldenMat)
    {
        this.m_entity = entity;
        this.m_bigCardPortraitTexture = bigTexture;
        this.m_bigCardPotraitGoldenMaterial = goldenMat;
        this.m_splatAmount = splatAmount;
        this.dead = isDead;
        this.finishedLoadingCallback = callbackFunc;
        this.wasCountered = counterspelled;
        this.waitingForSecretToFinish = waitForSecret;
    }

    public void SetFatigue(Texture bigTexture)
    {
        this.m_bigCardPortraitTexture = bigTexture;
        this.isFatigue = true;
    }

    [DebuggerHidden]
    private IEnumerator WaitAndThenContinueWithGameEvents()
    {
        return new <WaitAndThenContinueWithGameEvents>c__IteratorDE { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator WaitForSecretIfNecessary(GameObject actorObject)
    {
        return new <WaitForSecretIfNecessary>c__IteratorDD { actorObject = actorObject, <$>actorObject = actorObject, <>f__this = this };
    }

    public bool WasCountered()
    {
        return this.wasCountered;
    }

    [CompilerGenerated]
    private sealed class <WaitAndThenContinueWithGameEvents>c__IteratorDE : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal HistoryCard <>f__this;

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
                    this.$current = new WaitForSeconds(1f);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.RunCallbackNow();
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
    private sealed class <WaitForSecretIfNecessary>c__IteratorDD : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal GameObject <$>actorObject;
        internal HistoryCard <>f__this;
        internal Vector3[] <pathToFollow>__0;
        internal GameObject actorObject;

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
                    if (!this.<>f__this.waitingForSecretToFinish)
                    {
                        goto Label_008C;
                    }
                    this.<>f__this.gameObject.transform.localScale = new Vector3(1E-05f, 1E-05f, 1E-05f);
                    break;

                case 1:
                    break;

                default:
                    goto Label_01B0;
            }
            if (!this.<>f__this.secretFinished)
            {
                this.$current = null;
                this.$PC = 1;
                return true;
            }
            HistoryManager.Get().StartBigCardTimer();
        Label_008C:
            this.actorObject.transform.localScale = new Vector3(1.03f, 1.03f, 1.03f);
            if ((this.<>f__this.m_entity != null) && ((this.<>f__this.m_entity.GetCardType() == TAG_CARDTYPE.ABILITY) || (this.<>f__this.m_entity.GetCardType() == TAG_CARDTYPE.HERO_POWER)))
            {
                this.<pathToFollow>__0 = HistoryManager.Get().GetBigCardPath();
                this.<pathToFollow>__0[0] = this.actorObject.transform.position;
                object[] args = new object[] { "path", this.<pathToFollow>__0, "time", 1f };
                iTween.MoveTo(this.actorObject, iTween.Hash(args));
                iTween.ScaleTo(this.<>f__this.gameObject, new Vector3(1f, 1f, 1f), 1f);
                SoundManager.Get().LoadAndPlay("play_card_from_hand_1");
            }
            this.<>f__this.StartCoroutine(this.<>f__this.WaitAndThenContinueWithGameEvents());
            this.$PC = -1;
        Label_01B0:
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
}

