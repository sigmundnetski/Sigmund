using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GhostCard : MonoBehaviour
{
    private Actor m_Actor;
    private GameObject m_AttackMesh;
    private int m_CardFrontIdx;
    private GameObject m_CardMesh;
    private GameObject m_DescriptionMesh;
    private GameObject m_DescriptionTrimMesh;
    public GameObject m_EffectRoot;
    private GameObject m_EliteMesh;
    public Material m_GhostMaterial;
    public Material m_GhostMaterialTransparent;
    public GameObject m_GlowPlane;
    public GameObject m_GlowPlaneElite;
    private GameObject m_HealthMesh;
    private bool m_Init;
    private GameObject m_ManaCostMesh;
    private GameObject m_NameMesh;
    private Material m_OrgMat_Attack;
    private Material m_OrgMat_CardFront;
    private Material m_OrgMat_Description;
    private Material m_OrgMat_Description2;
    private Material m_OrgMat_DescriptionTrim;
    private Material m_OrgMat_Elite;
    private Material m_OrgMat_Health;
    private Material m_OrgMat_ManaCost;
    private Material m_OrgMat_Name;
    private Material m_OrgMat_PortraitFrame;
    private Material m_OrgMat_PremiumRibbon;
    private Material m_OrgMat_RacePlate;
    private Material m_OrgMat_RarityFrame;
    private int m_PortraitFrameIdx;
    private GameObject m_PortraitMesh;
    private int m_PremiumRibbonIdx = -1;
    private RenderToTexture m_R2T_BaseCard;
    public RenderToTexture m_R2T_EffectGhost;
    private GameObject m_RacePlateMesh;
    private GameObject m_RarityFrameMesh;

    private void ApplyGhostMaterials()
    {
        this.ApplyMaterialByIdx(this.m_CardMesh, this.m_GhostMaterial, this.m_CardFrontIdx);
        this.ApplyMaterialByIdx(this.m_CardMesh, this.m_GhostMaterial, this.m_PremiumRibbonIdx);
        this.ApplySharedMaterialByIdx(this.m_PortraitMesh, this.m_GhostMaterial, this.m_PortraitFrameIdx);
        this.ApplyMaterialByIdx(this.m_DescriptionMesh, this.m_GhostMaterial, 0);
        this.ApplyMaterialByIdx(this.m_DescriptionMesh, this.m_GhostMaterial, 1);
        this.ApplyMaterial(this.m_NameMesh, this.m_GhostMaterial);
        this.ApplyMaterial(this.m_ManaCostMesh, this.m_GhostMaterial);
        this.ApplyMaterial(this.m_AttackMesh, this.m_GhostMaterial);
        this.ApplyMaterial(this.m_HealthMesh, this.m_GhostMaterial);
        this.ApplyMaterial(this.m_RacePlateMesh, this.m_GhostMaterial);
        this.ApplyMaterial(this.m_RarityFrameMesh, this.m_GhostMaterial);
        if (this.m_GhostMaterialTransparent != null)
        {
            this.ApplyMaterial(this.m_DescriptionTrimMesh, this.m_GhostMaterialTransparent);
        }
        this.ApplyMaterial(this.m_EliteMesh, this.m_GhostMaterial);
    }

    private void ApplyMaterial(GameObject go, Material mat)
    {
        if (go != null)
        {
            Texture mainTexture = go.renderer.material.mainTexture;
            go.renderer.material = mat;
            go.renderer.material.mainTexture = mainTexture;
        }
    }

    private void ApplyMaterialByIdx(GameObject go, Material mat, int idx)
    {
        if (((go != null) && (mat != null)) && (idx >= 0))
        {
            Material[] materials = go.renderer.materials;
            if (idx < materials.Length)
            {
                Texture mainTexture = go.renderer.materials[idx].mainTexture;
                materials[idx] = mat;
                go.renderer.materials = materials;
                go.renderer.materials[idx].mainTexture = mainTexture;
            }
        }
    }

    private void ApplySharedMaterialByIdx(GameObject go, Material mat, int idx)
    {
        if (((go != null) && (mat != null)) && (idx >= 0))
        {
            Material[] sharedMaterials = go.renderer.sharedMaterials;
            if (idx < sharedMaterials.Length)
            {
                Texture mainTexture = go.renderer.sharedMaterials[idx].mainTexture;
                sharedMaterials[idx] = mat;
                go.renderer.sharedMaterials = sharedMaterials;
                go.renderer.sharedMaterials[idx].mainTexture = mainTexture;
            }
        }
    }

    private void Disable()
    {
        this.RestoreOrgMaterials();
        if (this.m_R2T_BaseCard != null)
        {
            this.m_R2T_BaseCard.enabled = false;
        }
        if (this.m_R2T_EffectGhost != null)
        {
            this.m_R2T_EffectGhost.enabled = false;
        }
        if (this.m_EffectRoot != null)
        {
            ParticleSystem componentInChildren = this.m_EffectRoot.GetComponentInChildren<ParticleSystem>();
            if (componentInChildren != null)
            {
                componentInChildren.Stop();
                componentInChildren.renderer.enabled = false;
            }
        }
    }

    public void DisableGhost()
    {
        this.Disable();
        base.enabled = false;
    }

    private void Init()
    {
        if (!this.m_Init)
        {
            this.m_Actor = SceneUtils.FindComponentInThisOrParents<Actor>(base.gameObject);
            if (this.m_Actor == null)
            {
                UnityEngine.Debug.LogError(string.Format("{0} Ghost card effect failed to find Actor!", base.transform.root.name));
                base.enabled = false;
            }
            else
            {
                this.m_CardMesh = this.m_Actor.m_cardMesh;
                this.m_CardFrontIdx = this.m_Actor.m_cardFrontMatIdx;
                this.m_PremiumRibbonIdx = this.m_Actor.m_premiumRibbon;
                this.m_PortraitMesh = this.m_Actor.m_portraitMesh;
                this.m_PortraitFrameIdx = this.m_Actor.m_portraitFrameMatIdx;
                this.m_NameMesh = this.m_Actor.m_nameBannerMesh;
                this.m_DescriptionMesh = this.m_Actor.m_descriptionMesh;
                this.m_DescriptionTrimMesh = this.m_Actor.m_descriptionTrimMesh;
                this.m_RarityFrameMesh = this.m_Actor.m_rarityFrameMesh;
                if (this.m_Actor.m_attackObject != null)
                {
                    UnityEngine.Renderer component = this.m_Actor.m_attackObject.GetComponent<UnityEngine.Renderer>();
                    if (component != null)
                    {
                        this.m_AttackMesh = component.gameObject;
                    }
                    if (this.m_AttackMesh == null)
                    {
                        foreach (UnityEngine.Renderer renderer2 in this.m_Actor.m_attackObject.GetComponentsInChildren<UnityEngine.Renderer>())
                        {
                            if (renderer2.GetComponent<UberText>() == null)
                            {
                                this.m_AttackMesh = renderer2.gameObject;
                            }
                        }
                    }
                }
                if (this.m_Actor.m_healthObject != null)
                {
                    UnityEngine.Renderer renderer3 = this.m_Actor.m_healthObject.GetComponent<UnityEngine.Renderer>();
                    if (renderer3 != null)
                    {
                        this.m_HealthMesh = renderer3.gameObject;
                    }
                    if (this.m_HealthMesh == null)
                    {
                        foreach (UnityEngine.Renderer renderer4 in this.m_Actor.m_healthObject.GetComponentsInChildren<UnityEngine.Renderer>())
                        {
                            if (renderer4.GetComponent<UberText>() == null)
                            {
                                this.m_HealthMesh = renderer4.gameObject;
                            }
                        }
                    }
                }
                this.m_ManaCostMesh = this.m_Actor.m_manaObject;
                this.m_RacePlateMesh = this.m_Actor.m_racePlateObject;
                this.m_EliteMesh = this.m_Actor.m_eliteObject;
                this.StoreOrgMaterials();
                this.m_R2T_BaseCard = base.GetComponent<RenderToTexture>();
                this.m_R2T_BaseCard.m_ObjectToRender = this.m_Actor.GetRootObject();
                this.m_Init = true;
            }
        }
    }

    private void OnDestroy()
    {
        if (this.m_EffectRoot != null)
        {
            ParticleSystem componentInChildren = this.m_EffectRoot.GetComponentInChildren<ParticleSystem>();
            if (componentInChildren != null)
            {
                componentInChildren.Stop();
            }
        }
    }

    private void OnDisable()
    {
        this.Disable();
    }

    private void OnEnable()
    {
    }

    [DebuggerHidden]
    private IEnumerator RenderGhost()
    {
        return new <RenderGhost>c__IteratorF9 { <>f__this = this };
    }

    public void RenderGhostCard()
    {
        base.StartCoroutine(this.RenderGhost());
    }

    private void RestoreOrgMaterials()
    {
        this.ApplyMaterialByIdx(this.m_CardMesh, this.m_OrgMat_CardFront, this.m_CardFrontIdx);
        this.ApplyMaterialByIdx(this.m_CardMesh, this.m_OrgMat_PremiumRibbon, this.m_PremiumRibbonIdx);
        this.ApplySharedMaterialByIdx(this.m_PortraitMesh, this.m_OrgMat_PortraitFrame, this.m_PortraitFrameIdx);
        this.ApplyMaterialByIdx(this.m_DescriptionMesh, this.m_OrgMat_Description, 0);
        this.ApplyMaterialByIdx(this.m_DescriptionMesh, this.m_OrgMat_Description2, 1);
        this.ApplyMaterial(this.m_NameMesh, this.m_OrgMat_Name);
        this.ApplyMaterial(this.m_ManaCostMesh, this.m_OrgMat_ManaCost);
        this.ApplyMaterial(this.m_AttackMesh, this.m_OrgMat_Attack);
        this.ApplyMaterial(this.m_HealthMesh, this.m_OrgMat_Health);
        this.ApplyMaterial(this.m_RacePlateMesh, this.m_OrgMat_RacePlate);
        this.ApplyMaterial(this.m_RarityFrameMesh, this.m_OrgMat_RarityFrame);
        this.ApplyMaterial(this.m_DescriptionTrimMesh, this.m_OrgMat_DescriptionTrim);
        this.ApplyMaterial(this.m_EliteMesh, this.m_OrgMat_Elite);
    }

    private void Start()
    {
    }

    private void StoreOrgMaterials()
    {
        if (this.m_CardMesh != null)
        {
            this.m_OrgMat_CardFront = this.m_CardMesh.renderer.materials[this.m_CardFrontIdx];
            if (this.m_PremiumRibbonIdx > -1)
            {
                this.m_OrgMat_PremiumRibbon = this.m_CardMesh.renderer.materials[this.m_PremiumRibbonIdx];
            }
        }
        if (this.m_PortraitMesh != null)
        {
            this.m_OrgMat_PortraitFrame = this.m_PortraitMesh.renderer.sharedMaterials[this.m_PortraitFrameIdx];
        }
        if (this.m_NameMesh != null)
        {
            this.m_OrgMat_Name = this.m_NameMesh.renderer.material;
        }
        if (this.m_ManaCostMesh != null)
        {
            this.m_OrgMat_ManaCost = this.m_ManaCostMesh.renderer.material;
        }
        if (this.m_AttackMesh != null)
        {
            this.m_OrgMat_Attack = this.m_AttackMesh.renderer.material;
        }
        if (this.m_HealthMesh != null)
        {
            this.m_OrgMat_Health = this.m_HealthMesh.renderer.material;
        }
        if (this.m_RacePlateMesh != null)
        {
            this.m_OrgMat_RacePlate = this.m_RacePlateMesh.renderer.material;
        }
        if (this.m_RarityFrameMesh != null)
        {
            this.m_OrgMat_RarityFrame = this.m_RarityFrameMesh.renderer.material;
        }
        if (this.m_DescriptionMesh != null)
        {
            Material[] materials = this.m_DescriptionMesh.renderer.materials;
            if (materials.Length > 1)
            {
                this.m_OrgMat_Description = materials[0];
                this.m_OrgMat_Description2 = materials[1];
            }
            else
            {
                this.m_OrgMat_Description = this.m_DescriptionMesh.renderer.material;
            }
        }
        if (this.m_DescriptionTrimMesh != null)
        {
            this.m_OrgMat_DescriptionTrim = this.m_DescriptionTrimMesh.renderer.material;
        }
        if (this.m_EliteMesh != null)
        {
            this.m_OrgMat_Elite = this.m_EliteMesh.renderer.material;
        }
    }

    private void Update()
    {
    }

    [CompilerGenerated]
    private sealed class <RenderGhost>c__IteratorF9 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal GhostCard <>f__this;
        internal RenderTexture <effectTexture>__1;
        internal ParticleSystem <particle>__2;
        internal Material <renderMat>__0;

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
                    this.<>f__this.Init();
                    this.<>f__this.m_R2T_BaseCard.enabled = true;
                    this.<>f__this.m_R2T_EffectGhost.enabled = true;
                    this.<>f__this.m_R2T_BaseCard.m_ObjectToRender = this.<>f__this.m_Actor.GetRootObject();
                    this.<>f__this.m_Actor.ShowAllText();
                    this.<>f__this.ApplyGhostMaterials();
                    this.<>f__this.m_R2T_BaseCard.Render();
                    this.<renderMat>__0 = this.<>f__this.m_R2T_BaseCard.GetRenderMaterial();
                    if (this.<>f__this.m_EffectRoot == null)
                    {
                        break;
                    }
                    this.<>f__this.m_EffectRoot.transform.parent = null;
                    this.<>f__this.m_EffectRoot.transform.position = new Vector3(-500f, -500f, -500f);
                    this.<>f__this.m_EffectRoot.transform.localScale = Vector3.one;
                    this.<>f__this.m_R2T_EffectGhost.enabled = true;
                    this.<effectTexture>__1 = this.<>f__this.m_R2T_EffectGhost.RenderNow();
                    this.<renderMat>__0.SetTexture("_FxTex", this.<effectTexture>__1);
                    if (this.<>f__this.m_GlowPlane != null)
                    {
                        this.<>f__this.m_GlowPlane.renderer.material.SetTexture("_FxTex", this.<effectTexture>__1);
                    }
                    if (this.<>f__this.m_GlowPlaneElite != null)
                    {
                        this.<>f__this.m_GlowPlaneElite.renderer.material.SetTexture("_FxTex", this.<effectTexture>__1);
                    }
                    this.$current = new WaitForEndOfFrame();
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<particle>__2 = this.<>f__this.m_EffectRoot.GetComponentInChildren<ParticleSystem>();
                    if (this.<particle>__2 != null)
                    {
                        this.<particle>__2.Play();
                    }
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
}

