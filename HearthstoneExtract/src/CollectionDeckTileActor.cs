using System;
using System.Collections;
using UnityEngine;

public class CollectionDeckTileActor : Actor
{
    private UberText m_countTextMesh;
    private CollectionDeckSlot m_deckSlot;
    public GameObject m_frame;
    private Vector3 m_openSliderLocalPos;
    private Vector3 m_originalSliderLocalPos;
    public Material m_premiumFrameMaterial;
    private GameObject m_slider;
    private bool m_sliderIsOpen;
    public Material m_standardFrameMaterial;
    private GameObject m_uniqueStar;
    private readonly Vector2 PREMIUM_FRAME_MATERIAL_OFFSET = new Vector2(0f, 0.463f);
    private const float SLIDER_ANIM_TIME = 0.35f;
    private readonly Vector2 STANDARD_FRAME_MATERIAL_OFFSET = Vector2.zero;

    private void AssignCardCount()
    {
        this.m_countTextMesh = base.m_rootObject.transform.FindChild("CardCountText").GetComponent<UberText>();
    }

    private void AssignSlider()
    {
        this.m_slider = base.m_rootObject.transform.FindChild("DeckCardBar_ExtraSlider_mesh").gameObject;
        this.m_originalSliderLocalPos = this.m_slider.transform.localPosition;
        this.m_openSliderLocalPos = base.m_rootObject.transform.FindChild("OpenSliderPosition").transform.localPosition;
    }

    private void AssignUniqueStar()
    {
        this.m_uniqueStar = base.m_rootObject.transform.FindChild("UniqueStar").gameObject;
    }

    public override void Awake()
    {
        base.Awake();
        this.AssignSlider();
        this.AssignCardCount();
        this.AssignUniqueStar();
    }

    private void CloseSlider(bool useSliderAnimations)
    {
        if (this.m_sliderIsOpen)
        {
            this.m_sliderIsOpen = false;
            iTween.StopByName(this.m_slider, "position");
            if (useSliderAnimations)
            {
                object[] args = new object[] { "position", this.m_originalSliderLocalPos, "isLocal", true, "time", 0.35f, "easetype", iTween.EaseType.easeOutBounce, "name", "position" };
                Hashtable hashtable = iTween.Hash(args);
                iTween.MoveTo(this.m_slider, hashtable);
            }
            else
            {
                this.m_slider.transform.localPosition = this.m_originalSliderLocalPos;
            }
        }
    }

    protected override Material GetPortraitMaterial()
    {
        return this.GetPotraitRenderer().material;
    }

    private MeshRenderer GetPotraitRenderer()
    {
        return base.m_rootObject.transform.FindChild("DeckCardBar_ExtraSlider_mesh").FindChild("Portrait_mesh").gameObject.GetComponent<MeshRenderer>();
    }

    private void OpenSlider(bool useSliderAnimations)
    {
        if (!this.m_sliderIsOpen)
        {
            this.m_sliderIsOpen = true;
            iTween.StopByName(this.m_slider, "position");
            if (useSliderAnimations)
            {
                object[] args = new object[] { "position", this.m_openSliderLocalPos, "isLocal", true, "time", 0.35f, "easetype", iTween.EaseType.easeOutBounce, "name", "position" };
                Hashtable hashtable = iTween.Hash(args);
                iTween.MoveTo(this.m_slider, hashtable);
            }
            else
            {
                this.m_slider.transform.localPosition = this.m_openSliderLocalPos;
            }
        }
    }

    public override void SetCardFlair(CardFlair cardFlair)
    {
        Vector2 vector;
        Material premiumFrameMaterial;
        base.SetCardFlair(cardFlair);
        if (base.GetCardFlair().Premium == CardFlair.PremiumType.FOIL)
        {
            vector = this.PREMIUM_FRAME_MATERIAL_OFFSET;
            premiumFrameMaterial = this.m_premiumFrameMaterial;
        }
        else
        {
            vector = this.STANDARD_FRAME_MATERIAL_OFFSET;
            premiumFrameMaterial = this.m_standardFrameMaterial;
        }
        this.m_frame.renderer.material = premiumFrameMaterial;
        this.m_frame.renderer.material.mainTextureOffset = vector;
    }

    public void UpdateDeckCardProperties(bool cardIsUnique, int numCards, bool useSliderAnimations)
    {
        if (cardIsUnique)
        {
            this.m_uniqueStar.SetActive(base.m_shown);
            this.m_countTextMesh.gameObject.SetActive(false);
        }
        else
        {
            this.m_uniqueStar.SetActive(false);
            this.m_countTextMesh.gameObject.SetActive(base.m_shown);
            this.m_countTextMesh.Text = Convert.ToString(numCards);
        }
        if (cardIsUnique || (numCards > 1))
        {
            this.OpenSlider(useSliderAnimations);
        }
        else
        {
            this.CloseSlider(useSliderAnimations);
        }
    }

    public void UpdateMaterialForGolden(Material goldenMaterial)
    {
        this.GetPotraitRenderer().material = goldenMaterial;
    }
}

