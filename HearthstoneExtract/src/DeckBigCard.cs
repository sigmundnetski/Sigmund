using System;
using UnityEngine;

public class DeckBigCard : MonoBehaviour
{
    private HandActorCache m_actorCache = new HandActorCache();
    public GameObject m_bottomPosition;
    private CardDef m_cardDef;
    private EntityDef m_entityDef;
    private CardFlair m_flair;
    private bool m_shown;
    private Actor m_shownActor;
    public GameObject m_topPosition;

    private void Awake()
    {
        this.m_actorCache.AddActorLoadedListener(new HandActorCache.ActorLoadedCallback(this.OnActorLoaded));
        this.m_actorCache.Initialize();
    }

    public void ForceHide()
    {
        this.Hide();
    }

    private void Hide()
    {
        this.m_shown = false;
        if (this.m_shownActor != null)
        {
            this.m_shownActor.Hide();
            this.m_shownActor = null;
        }
    }

    public void Hide(EntityDef entityDef, CardFlair flair)
    {
        if ((this.m_entityDef == entityDef) && this.m_flair.Equals(flair))
        {
            this.Hide();
        }
    }

    private void OnActorLoaded(string name, Actor actor, object callbackData)
    {
        if (actor == null)
        {
            Debug.LogWarning(string.Format("DeckBigCard.OnActorLoaded() - FAILED to load {0}", name));
        }
        else
        {
            actor.Hide();
            actor.transform.parent = base.transform;
            TransformUtil.Identity(actor.transform);
            if (!this.m_actorCache.IsInitializing() && this.m_shown)
            {
                this.Show();
            }
        }
    }

    private void Show()
    {
        this.m_shownActor = this.m_actorCache.GetActor(this.m_entityDef, this.m_flair);
        if (this.m_shownActor != null)
        {
            this.m_shownActor.SetEntityDef(this.m_entityDef);
            this.m_shownActor.SetCardFlair(this.m_flair);
            this.m_shownActor.SetCardDef(this.m_cardDef);
            this.m_shownActor.UpdateAllComponents();
            this.m_shownActor.Show();
        }
    }

    public void Show(EntityDef entityDef, CardFlair flair, CardDef cardDef, Vector3 sourcePosition)
    {
        this.m_shown = true;
        this.m_entityDef = entityDef;
        this.m_flair = flair;
        this.m_cardDef = cardDef;
        float z = this.m_bottomPosition.transform.position.z;
        float max = this.m_topPosition.transform.position.z;
        float num3 = Mathf.Clamp(sourcePosition.z, z, max);
        TransformUtil.SetPosZ(base.transform, num3);
        if (!this.m_actorCache.IsInitializing())
        {
            this.Show();
        }
    }
}

