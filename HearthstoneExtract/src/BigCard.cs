using System;
using System.Collections.Generic;
using UnityEngine;

public class BigCard : MonoBehaviour
{
    private Actor m_bigCardActor;
    private Card m_card;
    public GameObject m_EnchantmentBanner;
    public GameObject m_EnchantmentBannerBottom;
    public BigCardEnchantmentPanel m_EnchantmentPanelPrefab;
    private Pool<BigCardEnchantmentPanel> m_enchantmentPool = new Pool<BigCardEnchantmentPanel>();
    private Vector3 m_initialBannerBottomScale;
    private float m_initialBannerHeight;
    private Vector3 m_initialBannerScale;
    private bool m_loadingActor;
    public int m_RenderQueueEnchantmentBanner = 1;
    public int m_RenderQueueEnchantmentPanel = 2;
    private static BigCard s_instance;

    private void Awake()
    {
        s_instance = this;
        this.m_initialBannerHeight = this.m_EnchantmentBanner.renderer.bounds.size.z;
        this.m_initialBannerScale = this.m_EnchantmentBanner.transform.localScale;
        this.m_initialBannerBottomScale = this.m_EnchantmentBannerBottom.transform.localScale;
        this.m_enchantmentPool.SetCreateItemCallback(new Pool<BigCardEnchantmentPanel>.CreateItemCallback(this.CreateEnchantmentPanel));
        this.m_enchantmentPool.SetDestroyItemCallback(new Pool<BigCardEnchantmentPanel>.DestroyItemCallback(this.DestroyEnchantmentPanel));
        this.m_enchantmentPool.SetExtensionCount(1);
        this.m_enchantmentPool.SetMaxReleasedItemCount(2);
        this.ResetEnchantments();
    }

    private BigCardEnchantmentPanel CreateEnchantmentPanel(int index)
    {
        BigCardEnchantmentPanel panel = (BigCardEnchantmentPanel) UnityEngine.Object.Instantiate(this.m_EnchantmentPanelPrefab);
        panel.name = string.Format("{0}{1}", typeof(BigCardEnchantmentPanel).ToString(), index);
        SceneUtils.SetRenderQueue(panel.gameObject, this.m_RenderQueueEnchantmentPanel);
        return panel;
    }

    private void DestroyEnchantmentPanel(BigCardEnchantmentPanel panel)
    {
        UnityEngine.Object.Destroy(panel.gameObject);
    }

    private void DisplayBigCard()
    {
        Entity entity = this.m_card.GetEntity();
        bool flag = entity.GetController().IsLocal();
        Zone zone = this.m_card.GetZone();
        Bounds bounds = this.m_bigCardActor.GetMeshRenderer().bounds;
        Vector3 position = this.m_card.GetActor().transform.position;
        Vector3 vector2 = new Vector3(0f, 0f, 0f);
        Vector3 scale = new Vector3(1.1f, 1.1f, 1.1f);
        if (zone is ZoneHero)
        {
            if (flag)
            {
                vector2 = new Vector3(0f, 4f, 0f);
            }
            else
            {
                vector2 = new Vector3(0f, 4f, -bounds.size.z * 0.7f);
            }
        }
        else if (zone is ZoneHeroPower)
        {
            if (flag)
            {
                vector2 = new Vector3(0f, 4f, bounds.size.z * 2.2f);
            }
            else
            {
                vector2 = new Vector3(0f, 4f, -bounds.size.z * 2.7f);
            }
        }
        else if (zone is ZoneWeapon)
        {
            scale = new Vector3(1.65f, 1.65f, 1.65f);
            if (flag)
            {
                vector2 = new Vector3(0f, 0f, bounds.size.z * 0.9f);
            }
            else
            {
                vector2 = new Vector3(-1.57f, 0f, -1f);
            }
        }
        else if (zone is ZoneSecret)
        {
            if (flag)
            {
                vector2 = new Vector3(bounds.size.x * 0.75f, 4f, bounds.size.z * 0.6f);
            }
            else
            {
                vector2 = new Vector3(bounds.size.x * 0.7f, 4f, -bounds.size.z * 0.8f);
            }
        }
        else if (zone is ZoneHand)
        {
            vector2 = new Vector3(bounds.size.x * 0.7f, 8f, -bounds.size.z * 0.8f);
        }
        else
        {
            scale = new Vector3(1.65f, 1.65f, 1.65f);
            if (this.ShowBigCardOnRight())
            {
                vector2 = new Vector3(bounds.size.x + 0.7f, 0f, 0f);
            }
            else
            {
                vector2 = new Vector3(-bounds.size.x - 0.7f, 0f, 0f);
            }
        }
        Vector3 vector4 = new Vector3(0.02f, 0.02f, 0.02f);
        Vector3 vector5 = position + vector2;
        Vector3 vector6 = vector5 + vector4;
        Vector3 vector7 = new Vector3(1f, 1f, 1f);
        Transform parent = this.m_bigCardActor.transform.parent;
        this.m_bigCardActor.transform.localScale = scale;
        this.m_bigCardActor.transform.position = vector6;
        this.m_bigCardActor.transform.parent = null;
        this.UpdateEnchantments();
        this.FitInsideScreen();
        this.m_bigCardActor.transform.parent = parent;
        this.m_bigCardActor.transform.localScale = vector7;
        Vector3 vector8 = this.m_bigCardActor.transform.position;
        Transform transform = this.m_bigCardActor.transform;
        transform.position -= vector4;
        iTween.ScaleTo(this.m_bigCardActor.gameObject, scale, 0.15f);
        iTween.MoveTo(this.m_bigCardActor.gameObject, vector8, 10f);
        this.m_bigCardActor.transform.rotation = Quaternion.identity;
        SceneUtils.SetLayer(this.m_bigCardActor.gameObject, GameLayer.Tooltip);
        this.m_bigCardActor.Show();
        KeywordHelpPanelManager.Get().UpdateKeywordHelp(this.m_card, this.m_bigCardActor, this.ShowBigCardOnRight());
        if (entity.IsSilenced())
        {
            this.m_bigCardActor.ActivateSpell(SpellType.SILENCE);
        }
    }

    private void FitInsideScreen()
    {
        this.FitInsideScreenBottom();
        this.FitInsideScreenTop();
    }

    private bool FitInsideScreenBottom()
    {
        Bounds bounds = !this.m_EnchantmentBanner.activeInHierarchy ? this.m_bigCardActor.GetMeshRenderer().bounds : this.m_EnchantmentBannerBottom.renderer.bounds;
        Vector3 center = bounds.center;
        Vector3 origin = new Vector3(center.x, center.y, center.z - bounds.extents.z);
        Ray ray = new Ray(origin, origin - center);
        Plane plane = CameraUtils.CreateBottomPlane(CameraUtils.FindFirstByLayer(GameLayer.Tooltip));
        float enter = 0f;
        if (plane.Raycast(ray, out enter))
        {
            return false;
        }
        if (object.Equals(enter, 0f))
        {
            return false;
        }
        TransformUtil.SetPosZ(this.m_bigCardActor.gameObject, this.m_bigCardActor.transform.position.z - enter);
        return true;
    }

    private bool FitInsideScreenTop()
    {
        Bounds bounds = this.m_bigCardActor.GetMeshRenderer().bounds;
        Vector3 center = bounds.center;
        Vector3 origin = new Vector3(center.x, center.y, center.z + bounds.extents.z);
        Ray ray = new Ray(origin, origin - center);
        Plane plane = CameraUtils.CreateTopPlane(CameraUtils.FindFirstByLayer(GameLayer.Tooltip));
        float enter = 0f;
        if (plane.Raycast(ray, out enter))
        {
            return false;
        }
        if (object.Equals(enter, 0f))
        {
            return false;
        }
        TransformUtil.SetPosZ(this.m_bigCardActor.gameObject, this.m_bigCardActor.transform.position.z + enter);
        return true;
    }

    public static BigCard Get()
    {
        return s_instance;
    }

    public Card GetCard()
    {
        return this.m_card;
    }

    public Vector3 GetPosition()
    {
        return this.m_bigCardActor.transform.position;
    }

    public void Hide()
    {
        if (GameState.Get() != null)
        {
            GameState.Get().GetGameEntity().NotifyOfCardTooltipDisplayHide(this.m_card);
        }
        if (this.m_bigCardActor != null)
        {
            this.ResetEnchantments();
            iTween.Stop(this.m_bigCardActor.gameObject);
            this.m_bigCardActor.Destroy();
            this.m_bigCardActor = null;
            KeywordHelpPanelManager.Get().HideKeywordHelp();
        }
    }

    public bool Hide(Card card)
    {
        if (this.m_card != card)
        {
            return false;
        }
        this.Hide();
        return true;
    }

    private void LayoutEnchantments(GameObject bone)
    {
        float num3 = 0.1f;
        List<BigCardEnchantmentPanel> activeList = this.m_enchantmentPool.GetActiveList();
        BigCardEnchantmentPanel panel = null;
        for (int i = 0; i < activeList.Count; i++)
        {
            BigCardEnchantmentPanel panel2 = activeList[i];
            panel2.Show();
            float height = panel2.GetHeight();
            if (i == 0)
            {
                TransformUtil.SetPoint(panel2.gameObject, new Vector3(0.5f, 0f, 1f), this.m_bigCardActor.GetMeshRenderer().gameObject, new Vector3(0.5f, 0f, 0f), new Vector3(0.01f, 0.01f, 0f));
            }
            else
            {
                TransformUtil.SetPoint(panel2.gameObject, new Vector3(0f, 0f, 1f), panel.gameObject, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f));
            }
            if (i == (activeList.Count - 1))
            {
                num3 += height;
            }
            else
            {
                num3 += 0f + height;
            }
            panel = panel2;
            panel2.transform.parent = bone.transform;
        }
        this.m_EnchantmentBanner.SetActive(true);
        this.m_EnchantmentBannerBottom.SetActive(true);
        this.m_EnchantmentBannerBottom.transform.localScale = this.m_initialBannerBottomScale;
        TransformUtil.SetPoint(this.m_EnchantmentBanner, new Vector3(0.5f, 0f, 1f), this.m_bigCardActor.GetMeshRenderer().gameObject, new Vector3(0.5f, 0f, 0f), new Vector3(0f, 0f, 0.2f));
        this.m_EnchantmentBanner.transform.localScale = this.m_initialBannerScale;
        TransformUtil.SetLocalScaleZ(this.m_EnchantmentBanner.gameObject, (num3 / this.m_initialBannerHeight) / this.m_initialBannerScale.z);
        this.m_EnchantmentBanner.transform.parent = bone.transform;
        TransformUtil.SetPoint(this.m_EnchantmentBannerBottom, Anchor.FRONT, this.m_EnchantmentBanner, Anchor.BACK);
        this.m_EnchantmentBannerBottom.transform.parent = bone.transform;
    }

    private void LoadBigCardCallback(string actorName, GameObject actorObject, object callbackData)
    {
        this.m_loadingActor = false;
        Card card = callbackData as Card;
        if (actorObject == null)
        {
            Debug.LogWarning(string.Format("Card.LoadBigCardCallback() - FAILED to load actor \"{0}\"", actorName));
        }
        else
        {
            Actor component = actorObject.GetComponent<Actor>();
            if (component == null)
            {
                Debug.LogWarning(string.Format("Card.LoadBigCardCallback() - ERROR actor \"{0}\" has no Actor component", actorName));
            }
            else if (this.m_card != card)
            {
                component.Destroy();
            }
            else
            {
                this.m_bigCardActor = component;
                Entity entity = card.GetEntity();
                component.SetEntity(entity);
                component.SetCard(card);
                component.SetCardDef(card.GetCardDef());
                component.UpdateAllComponents();
                component.GetComponentInChildren<BoxCollider>().enabled = false;
                actorObject.name = "BigCard_" + actorName;
                card.UpdateTooltip();
            }
        }
    }

    private void ResetEnchantments()
    {
        this.m_EnchantmentBanner.SetActive(false);
        this.m_EnchantmentBannerBottom.SetActive(false);
        this.m_EnchantmentBanner.transform.parent = base.transform;
        this.m_EnchantmentBannerBottom.transform.parent = base.transform;
        foreach (BigCardEnchantmentPanel panel in this.m_enchantmentPool.GetActiveList())
        {
            panel.transform.parent = base.transform;
            panel.Hide();
        }
    }

    public void Show(Card card)
    {
        Card card2 = this.m_card;
        this.m_card = card;
        if ((GameState.Get() == null) || GameState.Get().GetGameEntity().NotifyOfCardTooltipDisplayShow(card))
        {
            if (this.m_bigCardActor != null)
            {
                this.DisplayBigCard();
            }
            else if ((card2 != card) || !this.m_loadingActor)
            {
                string bigCardActor = ActorNames.GetBigCardActor(card.GetEntity());
                this.m_loadingActor = true;
                AssetLoader.Get().LoadActor(bigCardActor, new AssetLoader.GameObjectCallback(this.LoadBigCardCallback), card);
            }
        }
    }

    private bool ShowBigCardOnRight()
    {
        if ((!this.m_card.GetEntity().IsHero() && !this.m_card.GetEntity().IsHeroPower()) && !this.m_card.GetEntity().IsSecret())
        {
            ZonePlay zone = this.m_card.GetZone() as ZonePlay;
            if (zone != null)
            {
                return (this.m_card.GetActor().GetMeshRenderer().bounds.center.x < (zone.GetComponent<BoxCollider>().bounds.center.x + 2.5f));
            }
        }
        return true;
    }

    private void UpdateEnchantments()
    {
        this.ResetEnchantments();
        GameObject bone = this.m_bigCardActor.FindBone("EnchantmentTooltip");
        if (bone != null)
        {
            List<Entity> enchantments = this.m_card.GetEntity().GetEnchantments();
            List<BigCardEnchantmentPanel> activeList = this.m_enchantmentPool.GetActiveList();
            int count = enchantments.Count;
            int num2 = activeList.Count;
            int num3 = count - num2;
            if (num3 > 0)
            {
                this.m_enchantmentPool.AcquireBatch(num3);
            }
            else if (num3 < 0)
            {
                this.m_enchantmentPool.ReleaseBatch(count, -num3);
            }
            if (count != 0)
            {
                for (int i = 0; i < activeList.Count; i++)
                {
                    activeList[i].SetEnchantment(enchantments[i]);
                }
                this.LayoutEnchantments(bone);
            }
        }
    }
}

