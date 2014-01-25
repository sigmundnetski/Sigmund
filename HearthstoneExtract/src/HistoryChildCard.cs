using System;
using UnityEngine;

public class HistoryChildCard : MonoBehaviour
{
    private bool actorHasBeenInitialized;
    private bool dead;
    private Texture m_bigCardPortraitTexture;
    private Material m_bigCardPotraitGoldenMaterial;
    private Entity m_entity;
    public Actor m_mainCardActor;
    private int m_splatAmount;

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

    public int GetSplatAmount()
    {
        return this.m_splatAmount;
    }

    public void InitializeActor()
    {
        this.m_mainCardActor.TurnOffCollider();
        if (this.m_entity.IsCharacter() || this.m_entity.IsWeapon())
        {
            if (this.dead)
            {
                this.DisplaySkullOnActor(this.m_mainCardActor);
            }
            else if (this.m_splatAmount != 0)
            {
                this.DisplaySplatOnActor(this.m_mainCardActor, this.m_splatAmount);
            }
        }
        this.m_mainCardActor.SetActorState(ActorStateType.CARD_HISTORY);
        this.actorHasBeenInitialized = true;
    }

    public bool IsDead()
    {
        return this.dead;
    }

    public bool IsInitialized()
    {
        return this.actorHasBeenInitialized;
    }

    public void LoadActor()
    {
        string historyActor = ActorNames.GetHistoryActor(this.m_entity);
        AssetLoader.Get().LoadActor(historyActor, new AssetLoader.GameObjectCallback(this.LoadActorCallback));
    }

    private void LoadActorCallback(string actorName, GameObject actorObject, object callbackData)
    {
        if (actorObject == null)
        {
            Debug.LogWarning(string.Format("HistoryChildCard.LoadActorCallback() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                Debug.LogWarning(string.Format("HistoryChildCard.LoadActorCallback() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else
            {
                this.m_mainCardActor = component;
                this.m_mainCardActor.SetCardFlair(this.m_entity.GetCardFlair());
                this.m_mainCardActor.SetHistoryChildCard(this);
                SceneUtils.SetLayer(this.m_mainCardActor.gameObject, GameLayer.Tooltip);
                this.m_mainCardActor.Hide();
            }
        }
    }

    public void SetCardInfo(Entity entity, Texture bigTexture, int splatAmount, bool isDead, Material goldenMaterial)
    {
        this.m_entity = entity;
        this.m_bigCardPortraitTexture = bigTexture;
        this.m_splatAmount = splatAmount;
        this.dead = isDead;
        this.m_bigCardPotraitGoldenMaterial = goldenMaterial;
    }

    private void Start()
    {
    }
}

