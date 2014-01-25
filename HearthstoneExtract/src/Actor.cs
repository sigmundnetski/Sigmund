using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Actor : MonoBehaviour
{
    protected readonly Color CLASS_COLOR_DRUID = new Color(0.42f, 0.29f, 0.14f);
    protected readonly Color CLASS_COLOR_GENERIC = new Color(0.8f, 0.8f, 0.8f);
    protected readonly Color CLASS_COLOR_HUNTER = new Color(0.26f, 0.54f, 0.18f);
    protected readonly Color CLASS_COLOR_MAGE = new Color(0.44f, 0.48f, 0.69f);
    protected readonly Color CLASS_COLOR_PALADIN = new Color(0.71f, 0.49f, 0.2f);
    protected readonly Color CLASS_COLOR_PRIEST = new Color(0.65f, 0.65f, 0.65f);
    protected readonly Color CLASS_COLOR_ROGUE = new Color(0.72f, 0.68f, 0.76f);
    protected readonly Color CLASS_COLOR_SHAMAN = new Color(0f, 0.32f, 0.71f);
    protected readonly Color CLASS_COLOR_WARLOCK = new Color(0.33f, 0.2f, 0.4f);
    protected readonly Color CLASS_COLOR_WARRIOR = new Color(0.43f, 0.14f, 0.14f);
    protected bool forceIdleState;
    protected readonly Color GEM_COLOR_COMMON = new Color(0.549f, 0.549f, 0.549f);
    protected readonly Color GEM_COLOR_EPIC = new Color(0.596f, 0.1568f, 0.7333f);
    protected readonly Color GEM_COLOR_LEGENDARY = new Color(1f, 0.5333f, 0f);
    protected readonly Color GEM_COLOR_RARE = new Color(0.1529f, 0.498f, 1f);
    protected readonly Vector2 GEM_TEXTURE_OFFSET_COMMON = new Vector2(0f, 0f);
    protected readonly Vector2 GEM_TEXTURE_OFFSET_EPIC = new Vector2(0f, 0.5f);
    protected readonly Vector2 GEM_TEXTURE_OFFSET_LEGENDARY = new Vector2(0.5f, 0.5f);
    protected readonly Vector2 GEM_TEXTURE_OFFSET_RARE = new Vector2(0.5f, 0f);
    protected ActorStateType m_actorState = ActorStateType.CARD_IDLE;
    protected ActorStateMgr m_actorStateMgr;
    protected ArmorSpell m_armorSpell;
    public GameObject m_attackObject;
    public UberText m_attackTextMesh;
    protected GameObject m_bones;
    protected Card m_card;
    public int m_cardBackMatIdx = -1;
    protected CardDef m_cardDef;
    protected CardFlair m_cardFlair;
    public int m_cardFrontMatIdx = -1;
    public GameObject m_cardMesh;
    public GameObject m_cardTypeAnchorObject;
    public GameObject m_classIconObject;
    public UberText m_costTextMesh;
    public GameObject m_descriptionMesh;
    public GameObject m_descriptionTrimMesh;
    public GameObject m_eliteObject;
    protected Entity m_entity;
    protected EntityDef m_entityDef;
    public GameObject m_glints;
    public GameObject m_healthObject;
    public UberText m_healthTextMesh;
    public GameObject m_heroSpotLight;
    protected GameObject m_hiddenCardStandIn;
    protected Material m_initialPortraitMaterial;
    protected int m_legacyCardColorMaterialIndex = -1;
    protected int m_legacyPortraitMaterialIndex = -1;
    protected Dictionary<SpellType, Spell> m_localSpellTable;
    public GameObject m_manaObject;
    protected MeshRenderer m_meshRenderer;
    public GameObject m_missingCardEffect;
    public GameObject m_nameBannerMesh;
    public UberText m_nameTextMesh;
    public int m_portraitFrameMatIdx = -1;
    public int m_portraitMatIdx = -1;
    public GameObject m_portraitMesh;
    public UberText m_powersTextMesh;
    public int m_premiumRibbon = -1;
    protected ProjectedShadow m_projectedShadow;
    public GameObject m_racePlateMesh;
    public GameObject m_racePlateObject;
    public UberText m_raceTextMesh;
    public GameObject m_rarityFrameMesh;
    public GameObject m_rarityGemMesh;
    protected GameObject m_rootObject;
    protected SpellTable m_sharedSpellTable;
    protected bool m_shown = true;
    protected SpellTable m_spellTable;
    public string m_spellTableName;
    protected bool m_useSharedSpellTable;

    public Spell ActivateSpell(SpellType spellType)
    {
        Spell spell2;
        if (this.m_useSharedSpellTable)
        {
            Spell loadedSpell = this.GetLoadedSpell(spellType);
            if (loadedSpell != null)
            {
                loadedSpell.Activate();
            }
            return loadedSpell;
        }
        if (this.m_spellTable == null)
        {
            return null;
        }
        if (!this.m_spellTable.FindSpell(spellType, out spell2))
        {
            return null;
        }
        if (spell2.GetActiveState() == SpellStateType.NONE)
        {
            spell2.Activate();
        }
        return spell2;
    }

    public Spell ActivateTaunt()
    {
        if (this.GetCardFlair().Premium == CardFlair.PremiumType.FOIL)
        {
            return this.ActivateSpell(SpellType.TAUNT_PREMIUM);
        }
        return this.ActivateSpell(SpellType.TAUNT);
    }

    private void AssignBones()
    {
        this.m_bones = SceneUtils.FindChildBySubstring(base.gameObject, "Bones");
    }

    private void AssignMaterials(MeshRenderer meshRenderer)
    {
        for (int i = 0; i < meshRenderer.sharedMaterials.Length; i++)
        {
            Material sharedMaterial = RenderUtils.GetSharedMaterial((UnityEngine.Renderer) meshRenderer, i);
            if (sharedMaterial != null)
            {
                if (sharedMaterial.name.LastIndexOf("Portrait", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    this.m_legacyPortraitMaterialIndex = i;
                }
                else if (sharedMaterial.name.IndexOf("Card_Inhand_Ability_Warlock", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    this.m_legacyCardColorMaterialIndex = i;
                }
                else if (sharedMaterial.name.IndexOf("Card_Inhand_Warlock", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    this.m_legacyCardColorMaterialIndex = i;
                }
                else if (sharedMaterial.name.IndexOf("Card_Inhand_Weapon_Warlock", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    this.m_legacyCardColorMaterialIndex = i;
                }
            }
        }
    }

    private void AssignMeshRenderers()
    {
        foreach (MeshRenderer renderer in base.gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            if (renderer.gameObject.name.Equals("Mesh", StringComparison.OrdinalIgnoreCase))
            {
                this.m_meshRenderer = renderer;
                foreach (MeshRenderer renderer2 in renderer.gameObject.GetComponentsInChildren<MeshRenderer>())
                {
                    this.AssignMaterials(renderer2);
                }
                break;
            }
        }
    }

    private void AssignRootObject()
    {
        this.m_rootObject = SceneUtils.FindChildBySubstring(base.gameObject, "RootObject");
    }

    private void AssignSpells()
    {
        this.m_spellTable = base.gameObject.GetComponentInChildren<SpellTable>();
        this.m_actorStateMgr = base.gameObject.GetComponentInChildren<ActorStateMgr>();
        if (this.m_spellTable == null)
        {
            if (!string.IsNullOrEmpty(this.m_spellTableName))
            {
                SpellTable spellTable = SpellCache.Get().GetSpellTable(this.m_spellTableName);
                if (spellTable != null)
                {
                    this.m_useSharedSpellTable = true;
                    this.m_sharedSpellTable = spellTable;
                    this.m_localSpellTable = new Dictionary<SpellType, Spell>();
                }
                else
                {
                    Debug.LogError("failed to load spell table: " + this.m_spellTableName);
                }
            }
        }
        else if (this.m_actorStateMgr != null)
        {
            foreach (SpellTableEntry entry in this.m_spellTable.m_Table)
            {
                if (entry.m_Spell != null)
                {
                    entry.m_Spell.AddStateStartedCallback(new Spell.StateStartedCallback(this.OnSpellStateStarted));
                }
            }
        }
        if (this.m_rootObject != null)
        {
            foreach (Spell spell in this.m_rootObject.GetComponentsInChildren<Spell>())
            {
                if (spell.name.LastIndexOf("Armor", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    this.m_armorSpell = spell as ArmorSpell;
                    if (this.m_armorSpell == null)
                    {
                        Debug.LogWarning(string.Format("Actor.AssignSpells() - {0} has a spell with the word \"Armor\" which is not of type {1}", spell, typeof(ArmorSpell)));
                    }
                    break;
                }
            }
        }
    }

    public virtual void Awake()
    {
        this.AssignRootObject();
        this.AssignBones();
        this.AssignMeshRenderers();
        this.AssignSpells();
    }

    public virtual Actor Clone()
    {
        GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(base.gameObject, base.transform.position, base.transform.rotation);
        Actor component = obj2.GetComponent<Actor>();
        component.SetEntity(this.m_entity);
        component.SetEntityDef(this.m_entityDef);
        component.SetCard(this.m_card);
        component.SetCardFlair(this.m_cardFlair);
        obj2.transform.localScale = base.gameObject.transform.localScale;
        obj2.transform.position = base.gameObject.transform.position;
        component.SetActorState(this.m_actorState);
        if (this.m_shown)
        {
            component.ShowImpl();
            return component;
        }
        component.HideImpl();
        return component;
    }

    private Material CreateReplacementMaterial(Material oldMaterial, Material newMaterialPrefab)
    {
        Material material = (Material) UnityEngine.Object.Instantiate(newMaterialPrefab);
        material.mainTexture = oldMaterial.mainTexture;
        return material;
    }

    public void DeactivateAllPreDeathSpells()
    {
        IEnumerator enumerator = Enum.GetValues(typeof(SpellType)).GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                SpellType current = (SpellType) ((int) enumerator.Current);
                if ((this.IsSpellActive(current) && (current != SpellType.DEATH)) && ((current != SpellType.DEATHRATTLE_DEATH) && (current != SpellType.DAMAGE)))
                {
                    this.DeactivateSpell(current);
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }

    public void DeactivateAllSpells()
    {
        if (this.m_useSharedSpellTable)
        {
            foreach (Spell spell in this.m_localSpellTable.Values)
            {
                if (spell.IsActive())
                {
                    spell.Deactivate();
                }
            }
        }
        else
        {
            IEnumerator enumerator = Enum.GetValues(typeof(SpellType)).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    SpellType current = (SpellType) ((int) enumerator.Current);
                    if (this.IsSpellActive(current))
                    {
                        this.DeactivateSpell(current);
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                }
                disposable.Dispose();
            }
        }
    }

    public void DeactivateSpell(SpellType spellType)
    {
        Spell spell;
        if (this.m_useSharedSpellTable)
        {
            if (!this.GetSpellIfLoaded(spellType, out spell))
            {
                return;
            }
            spell.Deactivate();
        }
        if ((this.m_spellTable != null) && this.m_spellTable.FindSpell(spellType, out spell))
        {
            spell.Deactivate();
        }
    }

    public void DeactivateTaunt()
    {
        if (this.GetCardFlair().Premium == CardFlair.PremiumType.FOIL)
        {
            this.DeactivateSpell(SpellType.TAUNT_PREMIUM);
        }
        else
        {
            this.DeactivateSpell(SpellType.TAUNT);
        }
    }

    public void Destroy()
    {
        if (this.m_localSpellTable != null)
        {
            foreach (Spell spell in this.m_localSpellTable.Values)
            {
                spell.Deactivate();
            }
        }
        if (this.m_spellTable != null)
        {
            foreach (SpellTableEntry entry in this.m_spellTable.m_Table)
            {
                if (entry.m_Spell != null)
                {
                    entry.m_Spell.Deactivate();
                }
            }
        }
        SceneUtils.Destroy(base.gameObject);
    }

    private void DisableTextMesh(UberText mesh)
    {
        if (mesh != null)
        {
            mesh.gameObject.SetActive(false);
        }
    }

    public GameObject FindBone(string boneName)
    {
        if (this.m_bones == null)
        {
            return null;
        }
        return SceneUtils.FindChildBySubstring(this.m_bones, boneName);
    }

    public ActorStateMgr GetActorStateMgr()
    {
        return this.m_actorStateMgr;
    }

    public ActorStateType GetActorStateType()
    {
        return ((this.m_actorStateMgr != null) ? this.m_actorStateMgr.GetActiveStateType() : ActorStateType.NONE);
    }

    public GemObject GetAttackObject()
    {
        if (this.m_attackObject == null)
        {
            return null;
        }
        return this.m_attackObject.GetComponent<GemObject>();
    }

    public GameObject GetAttackTextObject()
    {
        if (this.m_attackTextMesh == null)
        {
            return null;
        }
        return this.m_attackTextMesh.gameObject;
    }

    public GameObject GetBones()
    {
        return this.m_bones;
    }

    public Card GetCard()
    {
        return this.m_card;
    }

    public CardDef GetCardDef()
    {
        return this.m_cardDef;
    }

    public CardFlair GetCardFlair()
    {
        return this.m_cardFlair;
    }

    public TAG_CARD_SET GetCardSet()
    {
        if ((this.m_entityDef == null) && (this.m_entity == null))
        {
            return TAG_CARD_SET.NONE;
        }
        if (this.m_entityDef != null)
        {
            return this.m_entityDef.GetCardSet();
        }
        return this.m_entity.GetCardSet();
    }

    public GameObject GetCardTypeBannerAnchor()
    {
        if (this.m_cardTypeAnchorObject == null)
        {
            return base.gameObject;
        }
        return this.m_cardTypeAnchorObject;
    }

    public Collider GetCollider()
    {
        if (this.GetMeshRenderer() == null)
        {
            return null;
        }
        return this.GetMeshRenderer().gameObject.collider;
    }

    public GameObject GetCostTextObject()
    {
        if (this.m_costTextMesh == null)
        {
            return null;
        }
        return this.m_costTextMesh.gameObject;
    }

    public Entity GetEntity()
    {
        return this.m_entity;
    }

    public EntityDef GetEntityDef()
    {
        return this.m_entityDef;
    }

    public GemObject GetHealthObject()
    {
        if (this.m_healthObject == null)
        {
            return null;
        }
        return this.m_healthObject.GetComponent<GemObject>();
    }

    public GameObject GetHealthTextObject()
    {
        if (this.m_healthTextMesh == null)
        {
            return null;
        }
        return this.m_healthTextMesh.gameObject;
    }

    public Light GetHeroSpotlight()
    {
        if (this.m_heroSpotLight == null)
        {
            return null;
        }
        return this.m_heroSpotLight.light;
    }

    public GameObject GetHiddenStandIn()
    {
        return this.m_hiddenCardStandIn;
    }

    public HistoryCard GetHistoryCard()
    {
        if (base.transform.parent == null)
        {
            return null;
        }
        return base.transform.parent.gameObject.GetComponent<HistoryCard>();
    }

    public Spell GetLoadedSpell(SpellType spellType)
    {
        if ((this.m_localSpellTable != null) && this.m_localSpellTable.ContainsKey(spellType))
        {
            return this.m_localSpellTable[spellType];
        }
        return this.LoadSpell(spellType);
    }

    public MeshRenderer GetMeshRenderer()
    {
        return this.m_meshRenderer;
    }

    protected virtual Material GetPortraitMaterial()
    {
        if (((this.m_portraitMesh != null) && (0 <= this.m_portraitMatIdx)) && (this.m_portraitMatIdx < this.m_portraitMesh.renderer.materials.Length))
        {
            return this.m_portraitMesh.renderer.materials[this.m_portraitMatIdx];
        }
        if (this.m_legacyPortraitMaterialIndex >= 0)
        {
            return this.m_meshRenderer.materials[this.m_legacyPortraitMaterialIndex];
        }
        return null;
    }

    public Texture GetPortraitTexture()
    {
        Material portraitMaterial = this.GetPortraitMaterial();
        if (portraitMaterial == null)
        {
            return null;
        }
        return portraitMaterial.mainTexture;
    }

    public UberText GetPowersTextMesh()
    {
        return this.m_powersTextMesh;
    }

    public TAG_RARITY GetRarity()
    {
        if (this.m_entityDef != null)
        {
            return this.m_entityDef.GetRarity();
        }
        if (this.m_entity != null)
        {
            return this.m_entity.GetRarity();
        }
        return TAG_RARITY.FREE;
    }

    private bool GetRarityTextureOffset(out Vector2 offset, out Color tint)
    {
        offset = this.GEM_TEXTURE_OFFSET_COMMON;
        tint = this.GEM_COLOR_COMMON;
        if ((this.m_entityDef != null) || (this.m_entity != null))
        {
            TAG_CARD_SET cardSet;
            if (this.m_entityDef != null)
            {
                cardSet = this.m_entityDef.GetCardSet();
            }
            else
            {
                cardSet = this.m_entity.GetCardSet();
            }
            if (cardSet != TAG_CARD_SET.EXPERT1)
            {
                return false;
            }
            switch (this.GetRarity())
            {
                case TAG_RARITY.COMMON:
                    offset = this.GEM_TEXTURE_OFFSET_COMMON;
                    tint = this.GEM_COLOR_COMMON;
                    goto Label_0101;

                case TAG_RARITY.RARE:
                    offset = this.GEM_TEXTURE_OFFSET_RARE;
                    tint = this.GEM_COLOR_RARE;
                    goto Label_0101;

                case TAG_RARITY.EPIC:
                    offset = this.GEM_TEXTURE_OFFSET_EPIC;
                    tint = this.GEM_COLOR_EPIC;
                    goto Label_0101;

                case TAG_RARITY.LEGENDARY:
                    offset = this.GEM_TEXTURE_OFFSET_LEGENDARY;
                    tint = this.GEM_COLOR_LEGENDARY;
                    goto Label_0101;
            }
        }
        return false;
    Label_0101:
        return true;
    }

    public GameObject GetRootObject()
    {
        return this.m_rootObject;
    }

    public Spell GetSpell(SpellType spellType)
    {
        Spell spell;
        if (this.m_useSharedSpellTable)
        {
            return this.GetLoadedSpell(spellType);
        }
        if (this.m_spellTable == null)
        {
            return null;
        }
        this.m_spellTable.FindSpell(spellType, out spell);
        return spell;
    }

    public bool GetSpellIfLoaded(SpellType spellType, out Spell result)
    {
        if ((this.m_localSpellTable == null) || !this.m_localSpellTable.ContainsKey(spellType))
        {
            result = null;
            return false;
        }
        result = this.m_localSpellTable[spellType];
        return (result != null);
    }

    public SpellTable GetSpellTable()
    {
        return this.m_spellTable;
    }

    public void Hide()
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            this.HideImpl();
        }
    }

    public void HideAllText()
    {
        this.ToggleTextVisibility(false);
    }

    public void HideForSpells()
    {
        if (this.m_shown)
        {
            this.m_shown = false;
            if (this.m_rootObject != null)
            {
                this.m_rootObject.SetActive(false);
            }
            if (this.m_actorStateMgr != null)
            {
                this.m_actorStateMgr.HideStateMgr();
            }
            if (this.m_projectedShadow != null)
            {
                this.m_projectedShadow.enabled = false;
            }
        }
    }

    protected virtual void HideImpl()
    {
        if (this.m_rootObject != null)
        {
            this.m_rootObject.SetActive(false);
        }
        if (this.m_armorSpell != null)
        {
            this.m_armorSpell.Hide();
        }
        if (this.m_actorStateMgr != null)
        {
            this.m_actorStateMgr.HideStateMgr();
        }
        if (this.m_spellTable != null)
        {
            this.m_spellTable.Hide();
        }
        if (this.m_projectedShadow != null)
        {
            this.m_projectedShadow.enabled = false;
        }
        if (this.m_localSpellTable != null)
        {
            foreach (Spell spell in this.m_localSpellTable.Values)
            {
                if (spell.GetSpellType() != SpellType.NONE)
                {
                    spell.Hide();
                }
            }
        }
        if (this.m_missingCardEffect != null)
        {
            this.UpdateMissingCardArt();
        }
    }

    public void Init()
    {
        if (this.m_portraitMesh != null)
        {
            this.m_initialPortraitMaterial = RenderUtils.GetSharedMaterial(this.m_portraitMesh, this.m_portraitMatIdx);
        }
        else if (this.m_legacyPortraitMaterialIndex >= 0)
        {
            this.m_initialPortraitMaterial = RenderUtils.GetSharedMaterial((UnityEngine.Renderer) this.m_meshRenderer, this.m_legacyPortraitMaterialIndex);
        }
        if (this.m_rootObject != null)
        {
            TransformUtil.Identity(this.m_rootObject.transform);
        }
        if (this.m_actorStateMgr != null)
        {
            this.m_actorStateMgr.ChangeState(this.m_actorState);
        }
        this.m_projectedShadow = base.GetComponent<ProjectedShadow>();
        if (this.m_shown)
        {
            this.ShowImpl();
        }
        else
        {
            this.HideImpl();
        }
    }

    public bool IsElite()
    {
        if (this.m_entityDef != null)
        {
            return this.m_entityDef.IsElite();
        }
        return ((this.m_entity != null) && this.m_entity.IsElite());
    }

    public bool IsShown()
    {
        return this.m_shown;
    }

    public bool IsSpellActive(SpellType spellType)
    {
        Spell spell;
        if (this.m_useSharedSpellTable)
        {
            if (!this.GetSpellIfLoaded(spellType, out spell))
            {
                return false;
            }
            return spell.IsActive();
        }
        if (this.m_spellTable == null)
        {
            return false;
        }
        if (!this.m_spellTable.FindSpell(spellType, out spell))
        {
            return false;
        }
        if (spell == null)
        {
            return false;
        }
        return spell.IsActive();
    }

    public Spell LoadSpell(SpellType spellType)
    {
        if (this.m_sharedSpellTable == null)
        {
            return null;
        }
        Spell spell = this.m_sharedSpellTable.GetSpell(spellType);
        if (spell == null)
        {
            return null;
        }
        Transform source = spell.gameObject.transform;
        Transform transform = base.gameObject.transform;
        this.m_localSpellTable.Add(spellType, spell);
        TransformProps destination = new TransformProps();
        TransformUtil.CopyLocal(destination, source);
        source.parent = transform;
        TransformUtil.CopyLocal(source, destination);
        source.localScale.Scale(this.m_sharedSpellTable.gameObject.transform.localScale);
        SceneUtils.SetLayer(spell.gameObject, (GameLayer) base.gameObject.layer);
        spell.OnLoad();
        if (this.m_actorStateMgr != null)
        {
            spell.AddStateStartedCallback(new Spell.StateStartedCallback(this.OnSpellStateStarted));
        }
        return spell;
    }

    public bool MissingCardEffect()
    {
        if (this.m_missingCardEffect != null)
        {
            RenderToTexture component = this.m_missingCardEffect.GetComponent<RenderToTexture>();
            if (component != null)
            {
                component.enabled = true;
                return true;
            }
        }
        return false;
    }

    private void OnSpellStateStarted(Spell spell, SpellStateType prevStateType, object userData)
    {
        spell.AddStateStartedCallback(new Spell.StateStartedCallback(this.OnSpellStateStarted));
        this.m_actorStateMgr.RefreshStateMgr();
        if (this.m_projectedShadow != null)
        {
            this.m_projectedShadow.UpdateContactShadow();
        }
    }

    public void OverrideAllMeshMaterials(Material material)
    {
        if (this.m_rootObject != null)
        {
            this.RecursivelyReplaceMaterialsList(this.m_rootObject.transform, material);
        }
    }

    private void RecursivelyReplaceMaterialsList(Transform transformToRecurse, Material newMaterialPrefab)
    {
        bool flag = true;
        if (transformToRecurse.GetComponent<MaterialReplacementExclude>() != null)
        {
            flag = false;
        }
        else if (transformToRecurse.GetComponent<UberText>() != null)
        {
            flag = false;
        }
        else if (transformToRecurse.renderer == null)
        {
            flag = false;
        }
        if (flag)
        {
            this.ReplaceMaterialsList(transformToRecurse.renderer, newMaterialPrefab);
        }
        IEnumerator enumerator = transformToRecurse.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                Transform current = (Transform) enumerator.Current;
                this.RecursivelyReplaceMaterialsList(current, newMaterialPrefab);
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }

    private void ReplaceMaterialsList(UnityEngine.Renderer renderer, Material newMaterialPrefab)
    {
        Material[] materialArray = new Material[renderer.materials.Length];
        for (int i = 0; i < renderer.materials.Length; i++)
        {
            Material oldMaterial = renderer.materials[i];
            materialArray[i] = this.CreateReplacementMaterial(oldMaterial, newMaterialPrefab);
        }
        renderer.materials = materialArray;
        if (renderer == this.m_meshRenderer)
        {
            this.UpdatePortraitTexture();
        }
    }

    public void SetActorState(ActorStateType stateType)
    {
        this.m_actorState = stateType;
        if (this.m_actorStateMgr != null)
        {
            if (this.forceIdleState)
            {
                this.m_actorState = ActorStateType.CARD_IDLE;
            }
            this.m_actorStateMgr.ChangeState(this.m_actorState);
        }
    }

    public void SetCard(Card card)
    {
        if (this.m_card != card)
        {
            if (card == null)
            {
                this.m_card = null;
                base.transform.parent = null;
            }
            else
            {
                this.m_card = card;
                base.transform.parent = card.transform;
                TransformUtil.Identity(base.transform);
                if (this.m_rootObject != null)
                {
                    TransformUtil.Identity(this.m_rootObject.transform);
                }
            }
        }
    }

    public void SetCardDef(CardDef cardDef)
    {
        if (this.m_cardDef != cardDef)
        {
            this.m_cardDef = cardDef;
        }
    }

    public virtual void SetCardFlair(CardFlair cardFlair)
    {
        this.m_cardFlair = cardFlair;
    }

    public void SetEntity(Entity entity)
    {
        this.m_entity = entity;
        if (this.m_entity != null)
        {
            this.SetCardFlair(this.m_entity.GetCardFlair());
        }
    }

    public void SetEntityDef(EntityDef entityDef)
    {
        this.m_entityDef = entityDef;
    }

    public void SetHiddenStandIn(GameObject standIn)
    {
        this.m_hiddenCardStandIn = standIn;
    }

    public void SetHistoryCard(HistoryCard card)
    {
        if (card == null)
        {
            base.transform.parent = null;
        }
        else
        {
            base.transform.parent = card.transform;
            TransformUtil.Identity(base.transform);
            if (this.m_rootObject != null)
            {
                TransformUtil.Identity(this.m_rootObject.transform);
            }
            this.m_entity = card.GetEntity();
            this.UpdateTextComponents(this.m_entity);
            this.UpdateMeshComponents();
            if ((this.m_cardFlair.Premium == CardFlair.PremiumType.FOIL) && (card.GetBigCardPotraitGoldenMaterial() != null))
            {
                this.SetPortraitMaterial(card.GetBigCardPotraitGoldenMaterial());
            }
            else
            {
                this.SetPortraitTexture(card.GetBigCardPortraitTexture());
            }
            if (this.m_spellTable != null)
            {
                foreach (SpellTableEntry entry in this.m_spellTable.m_Table)
                {
                    Spell spell = entry.m_Spell;
                    if (spell != null)
                    {
                        spell.m_BlockServerEvents = false;
                    }
                }
            }
        }
    }

    public void SetHistoryChildCard(HistoryChildCard card)
    {
        if (card == null)
        {
            base.transform.parent = null;
        }
        else
        {
            base.transform.parent = card.transform;
            TransformUtil.Identity(base.transform);
            if (this.m_rootObject != null)
            {
                TransformUtil.Identity(this.m_rootObject.transform);
            }
            this.m_entity = card.GetEntity();
            this.UpdateTextComponents(card.GetEntity());
            this.UpdateMeshComponents();
            if ((this.m_cardFlair.Premium == CardFlair.PremiumType.FOIL) && (card.GetBigCardPotraitGoldenMaterial() != null))
            {
                this.SetPortraitMaterial(card.GetBigCardPotraitGoldenMaterial());
            }
            else
            {
                this.SetPortraitTexture(card.GetBigCardPortraitTexture());
            }
            if (this.m_spellTable != null)
            {
                foreach (SpellTableEntry entry in this.m_spellTable.m_Table)
                {
                    Spell spell = entry.m_Spell;
                    if (spell != null)
                    {
                        spell.m_BlockServerEvents = false;
                    }
                }
            }
        }
    }

    public void SetPortraitMaterial(Material material)
    {
        if (material != null)
        {
            if (this.m_portraitMesh != null)
            {
                if (RenderUtils.GetSharedMaterial(this.m_portraitMesh, this.m_portraitMatIdx) != material)
                {
                    if (material == null)
                    {
                        RenderUtils.SetSharedMaterial(this.m_portraitMesh, this.m_portraitMatIdx, this.m_initialPortraitMaterial);
                    }
                    else
                    {
                        RenderUtils.SetSharedMaterial(this.m_portraitMesh, this.m_portraitMatIdx, material);
                    }
                    if ((this.m_entity != null) && (this.m_entity.GetZone() == TAG_ZONE.PLAY))
                    {
                        foreach (Material material3 in this.m_portraitMesh.renderer.sharedMaterials)
                        {
                            if (material3.HasProperty("_LightingBlend"))
                            {
                                material3.SetFloat("_LightingBlend", 1f);
                            }
                        }
                    }
                }
            }
            else if ((this.m_legacyPortraitMaterialIndex >= 0) && (RenderUtils.GetSharedMaterial((UnityEngine.Renderer) this.m_meshRenderer, this.m_legacyPortraitMaterialIndex) != material))
            {
                RenderUtils.SetSharedMaterial((UnityEngine.Renderer) this.m_meshRenderer, this.m_legacyPortraitMaterialIndex, material);
            }
        }
    }

    public void SetPortraitTexture(Texture texture)
    {
        if (((CardFlair.GetPremiumType(this.m_cardFlair) != CardFlair.PremiumType.FOIL) || (this.m_cardDef == null)) || (this.m_cardDef.m_PremiumPortraitMaterial == null))
        {
            Material portraitMaterial = this.GetPortraitMaterial();
            if (portraitMaterial != null)
            {
                portraitMaterial.mainTexture = texture;
            }
        }
    }

    public void Show()
    {
        if (!this.m_shown)
        {
            this.m_shown = true;
            this.ShowImpl();
        }
    }

    public void ShowAllText()
    {
        this.ToggleTextVisibility(true);
    }

    public void ShowForSpells()
    {
        if (!this.m_shown)
        {
            this.m_shown = true;
            if (this.m_rootObject != null)
            {
                this.m_rootObject.SetActive(true);
            }
            if (this.m_actorStateMgr != null)
            {
                this.m_actorStateMgr.ShowStateMgr();
            }
            if (this.m_projectedShadow != null)
            {
                this.m_projectedShadow.enabled = true;
            }
        }
    }

    protected virtual void ShowImpl()
    {
        if (this.m_rootObject != null)
        {
            this.m_rootObject.SetActive(true);
        }
        this.ShowAllText();
        this.UpdateAllComponents();
        if (this.m_projectedShadow != null)
        {
            this.m_projectedShadow.enabled = true;
        }
        if (this.m_actorStateMgr != null)
        {
            this.m_actorStateMgr.ShowStateMgr();
        }
        if (this.m_spellTable != null)
        {
            this.m_spellTable.Show();
        }
        if (this.m_localSpellTable != null)
        {
            foreach (Spell spell in this.m_localSpellTable.Values)
            {
                spell.Show();
            }
        }
    }

    private void Start()
    {
        this.Init();
    }

    public void ToggleForceIdle(bool bOn)
    {
        this.forceIdleState = bOn;
    }

    private void ToggleTextVisibility(bool bOn)
    {
        if (this.m_healthTextMesh != null)
        {
            this.m_healthTextMesh.gameObject.SetActive(bOn);
        }
        if (this.m_attackTextMesh != null)
        {
            this.m_attackTextMesh.gameObject.SetActive(bOn);
        }
        if (this.m_nameTextMesh != null)
        {
            this.m_nameTextMesh.gameObject.SetActive(bOn);
            if (this.m_nameTextMesh.RenderOnObject != null)
            {
                this.m_nameTextMesh.RenderOnObject.renderer.enabled = bOn;
            }
        }
        if (this.m_powersTextMesh != null)
        {
            this.m_powersTextMesh.gameObject.SetActive(bOn);
        }
        if (this.m_costTextMesh != null)
        {
            this.m_costTextMesh.gameObject.SetActive(bOn);
        }
        if (this.m_raceTextMesh != null)
        {
            this.m_raceTextMesh.gameObject.SetActive(bOn);
        }
    }

    public void TurnOffCollider()
    {
        if ((this.GetMeshRenderer() != null) && (this.GetMeshRenderer().gameObject.collider != null))
        {
            this.GetMeshRenderer().gameObject.collider.enabled = false;
        }
    }

    public void TurnOnCollider()
    {
        if ((this.GetMeshRenderer() != null) && (this.GetMeshRenderer().gameObject.collider != null))
        {
            this.GetMeshRenderer().gameObject.collider.enabled = true;
        }
    }

    public void UpdateAllComponents()
    {
        this.UpdateTextComponents();
        this.UpdateMaterials();
        this.UpdateTextures();
        this.UpdateMeshComponents();
        this.UpdateRootObjectSpellComponents();
        this.UpdateMissingCardArt();
    }

    public void UpdateCardColor()
    {
        if (((this.m_legacyPortraitMaterialIndex >= 0) || (this.m_cardMesh != null)) && ((this.GetEntityDef() != null) || (this.GetEntity() != null)))
        {
            TAG_CARDTYPE cardType;
            TAG_CLASS tag_class;
            CardColorSwitcher.CardColorType type2;
            CardFlair.PremiumType premiumType = CardFlair.GetPremiumType(this.m_cardFlair);
            if (this.m_entityDef != null)
            {
                cardType = this.m_entityDef.GetCardType();
                tag_class = this.m_entityDef.GetClass();
            }
            else
            {
                cardType = this.m_entity.GetCardType();
                tag_class = this.m_entity.GetClass();
            }
            Color magenta = Color.magenta;
            switch (tag_class)
            {
                case TAG_CLASS.DRUID:
                    type2 = CardColorSwitcher.CardColorType.TYPE_DRUID;
                    magenta = this.CLASS_COLOR_DRUID;
                    break;

                case TAG_CLASS.HUNTER:
                    type2 = CardColorSwitcher.CardColorType.TYPE_HUNTER;
                    magenta = this.CLASS_COLOR_HUNTER;
                    break;

                case TAG_CLASS.MAGE:
                    type2 = CardColorSwitcher.CardColorType.TYPE_MAGE;
                    magenta = this.CLASS_COLOR_MAGE;
                    break;

                case TAG_CLASS.PALADIN:
                    type2 = CardColorSwitcher.CardColorType.TYPE_PALADIN;
                    magenta = this.CLASS_COLOR_PALADIN;
                    break;

                case TAG_CLASS.PRIEST:
                    type2 = CardColorSwitcher.CardColorType.TYPE_PRIEST;
                    magenta = this.CLASS_COLOR_PRIEST;
                    break;

                case TAG_CLASS.ROGUE:
                    type2 = CardColorSwitcher.CardColorType.TYPE_ROGUE;
                    magenta = this.CLASS_COLOR_ROGUE;
                    break;

                case TAG_CLASS.SHAMAN:
                    type2 = CardColorSwitcher.CardColorType.TYPE_SHAMAN;
                    magenta = this.CLASS_COLOR_SHAMAN;
                    break;

                case TAG_CLASS.WARLOCK:
                    type2 = CardColorSwitcher.CardColorType.TYPE_WARLOCK;
                    magenta = this.CLASS_COLOR_WARLOCK;
                    break;

                case TAG_CLASS.WARRIOR:
                    type2 = CardColorSwitcher.CardColorType.TYPE_WARRIOR;
                    magenta = this.CLASS_COLOR_WARRIOR;
                    break;

                case TAG_CLASS.DREAM:
                    type2 = CardColorSwitcher.CardColorType.TYPE_HUNTER;
                    magenta = this.CLASS_COLOR_HUNTER;
                    break;

                default:
                    type2 = CardColorSwitcher.CardColorType.TYPE_GENERIC;
                    magenta = this.CLASS_COLOR_GENERIC;
                    break;
            }
            switch (cardType)
            {
                case TAG_CARDTYPE.MINION:
                    switch (premiumType)
                    {
                        case CardFlair.PremiumType.STANDARD:
                            if (CardColorSwitcher.Get() != null)
                            {
                                Texture minionTexture = null;
                                if (CardColorSwitcher.Get() != null)
                                {
                                    minionTexture = CardColorSwitcher.Get().GetMinionTexture(type2);
                                }
                                if (this.m_cardMesh != null)
                                {
                                    if (this.m_cardFrontMatIdx > -1)
                                    {
                                        this.m_cardMesh.renderer.materials[this.m_cardFrontMatIdx].mainTexture = minionTexture;
                                    }
                                }
                                else if (this.m_legacyCardColorMaterialIndex >= 0)
                                {
                                    this.m_meshRenderer.renderer.materials[this.m_legacyCardColorMaterialIndex].mainTexture = minionTexture;
                                }
                            }
                            break;

                        case CardFlair.PremiumType.FOIL:
                            if ((this.m_premiumRibbon >= 0) && (this.m_cardMesh != null))
                            {
                                Material material2 = this.m_cardMesh.renderer.materials[this.m_premiumRibbon];
                                material2.color = magenta;
                            }
                            break;
                    }
                    Debug.LogWarning(string.Format("Actor.UpdateCardColor(): unexpected premium type {0}", premiumType));
                    break;

                case TAG_CARDTYPE.ABILITY:
                    switch (premiumType)
                    {
                        case CardFlair.PremiumType.STANDARD:
                            if (CardColorSwitcher.Get() != null)
                            {
                                Texture spellTexture = null;
                                if (CardColorSwitcher.Get() != null)
                                {
                                    spellTexture = CardColorSwitcher.Get().GetSpellTexture(type2);
                                }
                                if (this.m_cardMesh != null)
                                {
                                    if (this.m_cardFrontMatIdx > -1)
                                    {
                                        this.m_cardMesh.renderer.materials[this.m_cardFrontMatIdx].mainTexture = spellTexture;
                                    }
                                    if ((this.m_portraitMesh != null) && (this.m_portraitFrameMatIdx > -1))
                                    {
                                        this.m_portraitMesh.renderer.materials[this.m_portraitFrameMatIdx].mainTexture = spellTexture;
                                    }
                                }
                                else if ((this.m_legacyCardColorMaterialIndex >= 0) && (this.m_meshRenderer != null))
                                {
                                    this.m_meshRenderer.materials[this.m_legacyCardColorMaterialIndex].mainTexture = spellTexture;
                                }
                            }
                            break;

                        case CardFlair.PremiumType.FOIL:
                            if ((this.m_premiumRibbon >= 0) && (this.m_cardMesh != null))
                            {
                                Material material = this.m_cardMesh.renderer.materials[this.m_premiumRibbon];
                                material.color = magenta;
                            }
                            break;
                    }
                    Debug.LogWarning(string.Format("Actor.UpdateCardColor(): unexpected premium type {0}", premiumType));
                    break;

                case TAG_CARDTYPE.WEAPON:
                    switch (premiumType)
                    {
                        case CardFlair.PremiumType.STANDARD:
                            if (this.m_descriptionTrimMesh != null)
                            {
                                this.m_descriptionTrimMesh.renderer.material.SetColor("_Color", magenta);
                            }
                            break;

                        case CardFlair.PremiumType.FOIL:
                            if ((this.m_premiumRibbon >= 0) && (this.m_cardMesh != null))
                            {
                                Material material3 = this.m_cardMesh.renderer.materials[this.m_premiumRibbon];
                                material3.color = magenta;
                            }
                            break;
                    }
                    break;
            }
        }
    }

    private void UpdateEliteComponent()
    {
        if (this.m_eliteObject != null)
        {
            bool enable = this.IsElite();
            SceneUtils.EnableRenderers(this.m_eliteObject, enable);
        }
    }

    public void UpdateMaterials()
    {
        this.UpdatePortraitMaterials();
    }

    public void UpdateMeshComponents()
    {
        this.UpdateRarityComponent();
        this.UpdateWatermark();
        this.UpdateEliteComponent();
        this.UpdatePremiumComponents();
        this.UpdateCardColor();
    }

    public void UpdateMissingCardArt()
    {
        if (this.m_missingCardEffect != null)
        {
            RenderToTexture component = this.m_missingCardEffect.GetComponent<RenderToTexture>();
            if ((component != null) && component.enabled)
            {
                if (this.m_rootObject.activeSelf)
                {
                    component.Show(true);
                }
                else
                {
                    component.Hide();
                }
            }
        }
    }

    private void UpdateNameText()
    {
        if (this.m_nameTextMesh != null)
        {
            string name;
            bool flag = false;
            if (this.m_entityDef != null)
            {
                name = this.m_entityDef.GetName();
            }
            else
            {
                flag = (this.m_entity.IsSecret() && this.m_entity.IsHidden()) && !this.m_entity.IsControlledByLocalPlayer();
                name = this.m_entity.GetName();
            }
            if (flag)
            {
                name = GameStrings.Get("GAMEPLAY_SECRET_NAME");
            }
            this.UpdateText(this.m_nameTextMesh, name);
        }
    }

    private void UpdateNumberText(UberText textMesh, string newText)
    {
        GemObject obj2 = SceneUtils.FindComponentInThisOrParents<GemObject>(textMesh.gameObject);
        if (obj2 != null)
        {
            if (textMesh.Text != newText)
            {
                if (textMesh.Text == "hide")
                {
                    textMesh.gameObject.SetActive(true);
                    obj2.SetToZeroThenEnlarge();
                }
                else if (newText == "hide")
                {
                    textMesh.gameObject.SetActive(false);
                    obj2.ScaleToZero();
                }
                else
                {
                    obj2.Jiggle();
                }
            }
            obj2.Initialize();
        }
        textMesh.Text = newText;
    }

    private void UpdatePortraitMaterials()
    {
        if (((CardFlair.GetPremiumType(this.m_cardFlair) == CardFlair.PremiumType.FOIL) && (this.m_cardDef != null)) && (this.m_cardDef.m_PremiumPortraitMaterial != null))
        {
            this.SetPortraitMaterial(this.m_cardDef.m_PremiumPortraitMaterial);
        }
    }

    private void UpdatePortraitMaterials(Material goldenMaterial)
    {
        if ((CardFlair.GetPremiumType(this.m_cardFlair) == CardFlair.PremiumType.FOIL) && (this.m_cardDef != null))
        {
            this.SetPortraitMaterial(goldenMaterial);
        }
    }

    public void UpdatePortraitTexture()
    {
        if (this.m_cardDef != null)
        {
            this.SetPortraitTexture(this.m_cardDef.m_PortraitTexture);
        }
    }

    public void UpdatePowersText()
    {
        if (this.m_powersTextMesh != null)
        {
            string cardTextInHand;
            bool flag = false;
            if (this.m_entityDef != null)
            {
                cardTextInHand = this.m_entityDef.GetCardTextInHand();
            }
            else
            {
                flag = (this.m_entity.IsSecret() && this.m_entity.IsHidden()) && !this.m_entity.IsControlledByLocalPlayer();
                cardTextInHand = this.m_entity.GetCardTextInHand();
            }
            if (flag)
            {
                cardTextInHand = GameStrings.Get("GAMEPLAY_SECRET_DESC");
            }
            this.UpdateText(this.m_powersTextMesh, cardTextInHand);
        }
    }

    private void UpdatePremiumComponents()
    {
        if ((CardFlair.GetPremiumType(this.m_cardFlair) != CardFlair.PremiumType.STANDARD) && (this.m_glints != null))
        {
            this.m_glints.SetActive(true);
            foreach (UnityEngine.Renderer renderer in this.m_glints.GetComponentsInChildren<UnityEngine.Renderer>())
            {
                renderer.enabled = true;
            }
        }
    }

    private void UpdateRace(string raceText)
    {
        if (this.m_racePlateObject != null)
        {
            bool flag = !string.IsNullOrEmpty(raceText);
            foreach (MeshRenderer renderer in this.m_racePlateObject.GetComponents<MeshRenderer>())
            {
                renderer.enabled = flag;
            }
            if (flag)
            {
                if (this.m_descriptionMesh != null)
                {
                    this.m_descriptionMesh.renderer.material.SetTextureOffset("_SecondTex", new Vector2(-0.04f, 0f));
                }
            }
            else if (this.m_descriptionMesh != null)
            {
                this.m_descriptionMesh.renderer.material.SetTextureOffset("_SecondTex", new Vector2(-0.04f, 0.07f));
            }
            if (this.m_raceTextMesh != null)
            {
                this.m_raceTextMesh.Text = raceText;
            }
        }
    }

    private void UpdateRarityComponent()
    {
        if (this.m_rarityGemMesh != null)
        {
            Vector2 vector;
            Color color;
            bool rarityTextureOffset = this.GetRarityTextureOffset(out vector, out color);
            SceneUtils.EnableRenderers(this.m_rarityGemMesh, rarityTextureOffset, true);
            if (this.m_rarityFrameMesh != null)
            {
                SceneUtils.EnableRenderers(this.m_rarityFrameMesh, rarityTextureOffset, true);
            }
            if (rarityTextureOffset)
            {
                this.m_rarityGemMesh.renderer.material.mainTextureOffset = vector;
                this.m_rarityGemMesh.renderer.material.SetColor("_tint", color);
            }
        }
    }

    private void UpdateRootObjectSpellComponents()
    {
        if ((this.m_entity != null) && (this.m_armorSpell != null))
        {
            int armor = this.m_entity.GetArmor();
            int num2 = this.m_armorSpell.GetArmor();
            this.m_armorSpell.SetArmor(armor);
            if (armor > 0)
            {
                bool flag = this.m_armorSpell.IsShown();
                if (!flag)
                {
                    this.m_armorSpell.Show();
                }
                if (num2 <= 0)
                {
                    this.m_armorSpell.ActivateState(SpellStateType.BIRTH);
                }
                else if (num2 > armor)
                {
                    this.m_armorSpell.ActivateState(SpellStateType.ACTION);
                }
                else if (!flag)
                {
                    this.m_armorSpell.ActivateState(SpellStateType.IDLE);
                }
            }
            else if (num2 > 0)
            {
                this.m_armorSpell.ActivateState(SpellStateType.DEATH);
            }
        }
    }

    private void UpdateText(UberText uberTextMesh, string text)
    {
        if (uberTextMesh != null)
        {
            uberTextMesh.Text = text;
        }
    }

    private void UpdateTextColor(UberText originalMesh, int baseNumber, int currentNumber)
    {
        this.UpdateTextColor(originalMesh, baseNumber, currentNumber, false);
    }

    private void UpdateTextColor(UberText uberTextMesh, int baseNumber, int currentNumber, bool higherIsBetter)
    {
        if (((baseNumber > currentNumber) && higherIsBetter) || ((baseNumber < currentNumber) && !higherIsBetter))
        {
            uberTextMesh.TextColor = Color.green;
        }
        else if (((baseNumber < currentNumber) && higherIsBetter) || ((baseNumber > currentNumber) && !higherIsBetter))
        {
            uberTextMesh.TextColor = Color.red;
        }
        else if (baseNumber == currentNumber)
        {
            uberTextMesh.TextColor = Color.white;
        }
    }

    private void UpdateTextColorToGreenOrWhite(UberText uberTextMesh, int baseNumber, int currentNumber)
    {
        if (baseNumber < currentNumber)
        {
            uberTextMesh.TextColor = Color.green;
        }
        else
        {
            uberTextMesh.TextColor = Color.white;
        }
    }

    public virtual void UpdateTextComponents()
    {
        if (this.m_entityDef != null)
        {
            this.UpdateTextComponentsDef(this.m_entityDef);
        }
        else
        {
            this.UpdateTextComponents(this.m_entity);
        }
    }

    public virtual void UpdateTextComponents(Entity entity)
    {
        if (entity != null)
        {
            if (this.m_costTextMesh != null)
            {
                if ((this.m_entity.IsSecret() && this.m_entity.IsHidden()) && !this.m_entity.IsControlledByLocalPlayer())
                {
                    this.m_costTextMesh.TextColor = Color.white;
                }
                else
                {
                    this.UpdateTextColor(this.m_costTextMesh, entity.GetOriginalCost(), entity.GetCost(), true);
                }
                this.UpdateNumberText(this.m_costTextMesh, Convert.ToString(entity.GetCost()));
            }
            if (this.m_attackTextMesh != null)
            {
                if (entity.IsHero())
                {
                    int aTK = entity.GetATK();
                    if (aTK == 0)
                    {
                        this.UpdateNumberText(this.m_attackTextMesh, "hide");
                    }
                    else
                    {
                        this.UpdateNumberText(this.m_attackTextMesh, Convert.ToString(aTK));
                    }
                }
                else
                {
                    this.UpdateTextColorToGreenOrWhite(this.m_attackTextMesh, entity.GetOriginalATK(), entity.GetATK());
                    this.UpdateNumberText(this.m_attackTextMesh, Convert.ToString(entity.GetATK()));
                }
            }
            if (this.m_healthTextMesh != null)
            {
                int durability;
                int originalDurability;
                if (entity.IsWeapon())
                {
                    durability = entity.GetDurability();
                    originalDurability = entity.GetOriginalDurability();
                }
                else
                {
                    durability = entity.GetHealth();
                    originalDurability = entity.GetOriginalHealth();
                }
                int currentNumber = durability - entity.GetDamage();
                if (entity.GetDamage() > 0)
                {
                    this.UpdateTextColor(this.m_healthTextMesh, durability, currentNumber);
                }
                else if (durability > originalDurability)
                {
                    this.UpdateTextColor(this.m_healthTextMesh, originalDurability, currentNumber);
                }
                else
                {
                    this.UpdateTextColor(this.m_healthTextMesh, currentNumber, currentNumber);
                }
                this.UpdateNumberText(this.m_healthTextMesh, Convert.ToString(currentNumber));
            }
            this.UpdateNameText();
            this.UpdatePowersText();
            this.UpdateRace(entity.GetRaceText());
        }
    }

    public virtual void UpdateTextComponentsDef(EntityDef entityDef)
    {
        if (entityDef != null)
        {
            if (this.m_costTextMesh != null)
            {
                this.m_costTextMesh.Text = Convert.ToString(entityDef.GetTag(GAME_TAG.COST));
            }
            int tag = entityDef.GetTag(GAME_TAG.ATK);
            if (entityDef.IsHero())
            {
                if (tag == 0)
                {
                    if ((this.m_attackObject != null) && this.m_attackObject.activeSelf)
                    {
                        this.m_attackObject.SetActive(false);
                    }
                    if (this.m_attackTextMesh != null)
                    {
                        this.m_attackTextMesh.Text = string.Empty;
                    }
                }
                else
                {
                    if ((this.m_attackObject != null) && !this.m_attackObject.activeSelf)
                    {
                        this.m_attackObject.SetActive(true);
                    }
                    if (this.m_attackTextMesh != null)
                    {
                        this.m_attackTextMesh.Text = Convert.ToString(tag);
                    }
                }
            }
            else if (this.m_attackTextMesh != null)
            {
                this.m_attackTextMesh.Text = Convert.ToString(tag);
            }
            if (this.m_healthTextMesh != null)
            {
                if (entityDef.IsWeapon())
                {
                    this.m_healthTextMesh.Text = Convert.ToString(entityDef.GetTag(GAME_TAG.DURABILITY));
                }
                else
                {
                    this.m_healthTextMesh.Text = Convert.ToString(entityDef.GetTag(GAME_TAG.HEALTH));
                }
            }
            this.UpdateNameText();
            this.UpdatePowersText();
            this.UpdateRace(entityDef.GetRaceText());
        }
    }

    private void UpdateTextures()
    {
        this.UpdatePortraitTexture();
    }

    private void UpdateWatermark()
    {
        if ((this.m_entityDef != null) || (this.m_entity != null))
        {
            TAG_CARD_SET cardSet = this.GetCardSet();
            if ((this.m_descriptionMesh != null) && this.m_descriptionMesh.renderer.material.HasProperty("_SecondTint"))
            {
                Color color = this.m_descriptionMesh.renderer.material.GetColor("_SecondTint");
                if (cardSet == TAG_CARD_SET.EXPERT1)
                {
                    color.a = 0.7734375f;
                }
                else
                {
                    color.a = 0f;
                }
                this.m_descriptionMesh.renderer.material.SetColor("_SecondTint", color);
            }
        }
    }
}

