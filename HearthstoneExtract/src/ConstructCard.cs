using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ConstructCard : MonoBehaviour
{
    private bool isInit;
    private Actor m_Actor;
    public float m_AnimationRarityScaleCommon = 1f;
    public float m_AnimationRarityScaleEpic = 0.8f;
    public float m_AnimationRarityScaleLegendary = 0.7f;
    public float m_AnimationRarityScaleRare = 0.9f;
    private float m_AnimationScale = 1f;
    public float m_AttackAnimTime = 1f;
    public GameObject m_AttackGlow;
    public ParticleSystem m_AttackHitBlastParticle;
    public Vector3 m_AttackImpactRotation = new Vector3(-15f, 0f, 0f);
    private GameObject m_AttackInstance;
    private GameObject m_AttackMesh;
    public float m_AttackStartDelay;
    public Transform m_AttackStartPosition;
    public Transform m_AttackTargetPosition;
    private int m_CardFrontIdx;
    private GameObject m_CardMesh;
    public float m_DescriptionAnimTime = 1f;
    public GameObject m_DescriptionGlow;
    public ParticleSystem m_DescriptionHitBlastParticle;
    public Vector3 m_DescriptionImpactRotation = new Vector3(-15f, 0f, 0f);
    private GameObject m_DescriptionInstance;
    private GameObject m_DescriptionMesh;
    public float m_DescriptionStartDelay;
    public Transform m_DescriptionStartPosition;
    public Transform m_DescriptionTargetPosition;
    private GameObject m_DescriptionTrimMesh;
    private GameObject m_EliteMesh;
    public GameObject m_FuseGlow;
    public GameObject m_GhostGlow;
    public Material m_GhostMaterial;
    public Material m_GhostMaterialTransparent;
    private Spell m_GhostSpell;
    public Texture m_GhostTextureUnique;
    public float m_HealthAnimTime = 1f;
    public GameObject m_HealthGlow;
    public ParticleSystem m_HealthHitBlastParticle;
    public Vector3 m_HealthImpactRotation = new Vector3(-15f, 0f, 0f);
    private GameObject m_HealthInstance;
    private GameObject m_HealthMesh;
    public float m_HealthStartDelay;
    public Transform m_HealthStartPosition;
    public Transform m_HealthTargetPosition;
    public Vector3 m_ImpactCameraShakeAmount = Vector3.one;
    public float m_ImpactCameraShakeTime = 0.2f;
    public float m_ImpactRotationTime = 0.5f;
    private GameObject m_ManaCostMesh;
    public float m_ManaGemAnimTime = 1f;
    private GameObject m_ManaGemClone;
    public GameObject m_ManaGemGlow;
    public ParticleSystem m_ManaGemHitBlastParticle;
    public Vector3 m_ManaGemImpactRotation = new Vector3(20f, 0f, 20f);
    private GameObject m_ManaGemInstance;
    public float m_ManaGemStartDelay;
    public Transform m_ManaGemStartPosition;
    public Transform m_ManaGemTargetPosition;
    public float m_NameAnimTime = 1f;
    public GameObject m_NameGlow;
    public ParticleSystem m_NameHitBlastParticle;
    public Vector3 m_NameImpactRotation = new Vector3(-15f, 0f, 0f);
    private GameObject m_NameInstance;
    private GameObject m_NameMesh;
    public float m_NameStartDelay;
    public Transform m_NameStartPosition;
    public Transform m_NameTargetPosition;
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
    private Material m_OrgMat_RacePlate;
    private Material m_OrgMat_RarityFrame;
    public float m_PortraitAnimTime = 1f;
    private int m_PortraitFrameIdx;
    public GameObject m_PortraitGlow;
    public GameObject m_PortraitGlowStandard;
    public GameObject m_PortraitGlowUnique;
    public ParticleSystem m_PortraitHitBlastParticle;
    public Vector3 m_PortraitImpactRotation = new Vector3(-15f, 0f, 0f);
    private GameObject m_PortraitInstance;
    private GameObject m_PortraitMesh;
    public float m_PortraitStartDelay;
    public Transform m_PortraitStartPosition;
    public Transform m_PortraitTargetPosition;
    private GameObject m_RacePlateMesh;
    public float m_RandomDelayVariance = 0.2f;
    public float m_RarityAnimTime = 1f;
    public ParticleSystem m_RarityBurstCommon;
    public ParticleSystem m_RarityBurstEpic;
    public ParticleSystem m_RarityBurstLegendary;
    public ParticleSystem m_RarityBurstRare;
    private GameObject m_RarityFrameMesh;
    private GameObject m_RarityGemMesh;
    public GameObject m_RarityGlowCommon;
    public GameObject m_RarityGlowEpic;
    public GameObject m_RarityGlowLegendary;
    public GameObject m_RarityGlowRare;
    public ParticleSystem m_RarityHitBlastParticle;
    public Vector3 m_RarityImpactRotation = new Vector3(-15f, 0f, 0f);
    private GameObject m_RarityInstance;
    public float m_RarityStartDelay;
    public Transform m_RarityStartPosition;
    public Transform m_RarityTargetPosition;

    private void AnimateAttack()
    {
        GameObject attackInstance = this.m_AttackInstance;
        attackInstance.transform.parent = null;
        attackInstance.transform.localScale = this.m_AttackMesh.transform.lossyScale;
        attackInstance.transform.position = this.m_AttackStartPosition.transform.position;
        attackInstance.transform.parent = base.transform.parent;
        attackInstance.renderer.material = this.m_OrgMat_Attack;
        float num = UnityEngine.Random.Range((float) (this.m_AttackStartDelay - (this.m_AttackStartDelay * this.m_RandomDelayVariance)), (float) (this.m_AttackStartDelay + (this.m_AttackStartDelay * this.m_RandomDelayVariance)));
        AnimationData data2 = new AnimationData {
            Name = "Attack",
            AnimateTransform = attackInstance.transform,
            StartTransform = this.m_AttackStartPosition.transform,
            TargetTransform = this.m_AttackTargetPosition.transform,
            HitBlastParticle = this.m_AttackHitBlastParticle,
            AnimationTime = this.m_AttackAnimTime,
            StartDelay = num,
            GlowObject = this.m_AttackGlow,
            ImpactRotation = this.m_AttackImpactRotation,
            OnComplete = "AttackOnComplete"
        };
        AnimationData data = data2;
        base.StartCoroutine("AnimateObject", data);
    }

    private void AnimateDescription()
    {
        GameObject descriptionInstance = this.m_DescriptionInstance;
        descriptionInstance.transform.parent = null;
        descriptionInstance.transform.localScale = this.m_DescriptionMesh.transform.lossyScale;
        descriptionInstance.transform.position = this.m_DescriptionStartPosition.transform.position;
        descriptionInstance.transform.parent = base.transform.parent;
        descriptionInstance.renderer.material = this.m_OrgMat_Description;
        float num = UnityEngine.Random.Range((float) (this.m_DescriptionStartDelay - (this.m_DescriptionStartDelay * this.m_RandomDelayVariance)), (float) (this.m_DescriptionStartDelay + (this.m_DescriptionStartDelay * this.m_RandomDelayVariance)));
        AnimationData data2 = new AnimationData {
            Name = "Description",
            AnimateTransform = descriptionInstance.transform,
            StartTransform = this.m_DescriptionStartPosition.transform,
            TargetTransform = this.m_DescriptionTargetPosition.transform,
            HitBlastParticle = this.m_DescriptionHitBlastParticle,
            AnimationTime = this.m_DescriptionAnimTime,
            StartDelay = num,
            GlowObject = this.m_DescriptionGlow,
            ImpactRotation = this.m_DescriptionImpactRotation,
            OnComplete = "DescriptionOnComplete"
        };
        AnimationData data = data2;
        base.StartCoroutine("AnimateObject", data);
    }

    private void AnimateHealth()
    {
        GameObject healthInstance = this.m_HealthInstance;
        healthInstance.transform.parent = null;
        healthInstance.transform.localScale = this.m_HealthMesh.transform.lossyScale;
        healthInstance.transform.position = this.m_HealthStartPosition.transform.position;
        healthInstance.transform.parent = base.transform.parent;
        healthInstance.renderer.material = this.m_OrgMat_Health;
        float num = UnityEngine.Random.Range((float) (this.m_HealthStartDelay - (this.m_HealthStartDelay * this.m_RandomDelayVariance)), (float) (this.m_HealthStartDelay + (this.m_HealthStartDelay * this.m_RandomDelayVariance)));
        AnimationData data2 = new AnimationData {
            Name = "Health",
            AnimateTransform = healthInstance.transform,
            StartTransform = this.m_HealthStartPosition.transform,
            TargetTransform = this.m_HealthTargetPosition.transform,
            HitBlastParticle = this.m_HealthHitBlastParticle,
            AnimationTime = this.m_HealthAnimTime,
            StartDelay = num,
            GlowObject = this.m_HealthGlow,
            ImpactRotation = this.m_HealthImpactRotation,
            OnComplete = "HealthOnComplete"
        };
        AnimationData data = data2;
        base.StartCoroutine("AnimateObject", data);
    }

    private void AnimateManaGem()
    {
        GameObject manaGemInstance = this.m_ManaGemInstance;
        manaGemInstance.transform.parent = null;
        manaGemInstance.transform.localScale = this.m_ManaCostMesh.transform.lossyScale;
        manaGemInstance.transform.position = this.m_ManaGemStartPosition.transform.position;
        manaGemInstance.transform.parent = base.transform.parent;
        manaGemInstance.renderer.material = this.m_OrgMat_ManaCost;
        float num = UnityEngine.Random.Range((float) (this.m_ManaGemStartDelay - (this.m_ManaGemStartDelay * this.m_RandomDelayVariance)), (float) (this.m_ManaGemStartDelay + (this.m_ManaGemStartDelay * this.m_RandomDelayVariance)));
        AnimationData data2 = new AnimationData {
            Name = "ManaGem",
            AnimateTransform = manaGemInstance.transform,
            StartTransform = this.m_ManaGemStartPosition.transform,
            TargetTransform = this.m_ManaGemTargetPosition.transform,
            HitBlastParticle = this.m_ManaGemHitBlastParticle,
            AnimationTime = this.m_ManaGemAnimTime,
            StartDelay = num,
            GlowObject = this.m_ManaGemGlow,
            ImpactRotation = this.m_ManaGemImpactRotation,
            OnComplete = "ManaGemOnComplete"
        };
        AnimationData data = data2;
        base.StartCoroutine("AnimateObject", data);
    }

    private void AnimateName()
    {
        GameObject nameInstance = this.m_NameInstance;
        nameInstance.transform.parent = null;
        nameInstance.transform.localScale = this.m_NameMesh.transform.lossyScale;
        nameInstance.transform.position = this.m_NameStartPosition.transform.position;
        nameInstance.transform.parent = base.transform.parent;
        nameInstance.renderer.material = this.m_OrgMat_Name;
        float num = UnityEngine.Random.Range((float) (this.m_NameStartDelay - (this.m_NameStartDelay * this.m_RandomDelayVariance)), (float) (this.m_NameStartDelay + (this.m_NameStartDelay * this.m_RandomDelayVariance)));
        AnimationData data2 = new AnimationData {
            Name = "Name",
            AnimateTransform = nameInstance.transform,
            StartTransform = this.m_NameStartPosition.transform,
            TargetTransform = this.m_NameTargetPosition.transform,
            HitBlastParticle = this.m_NameHitBlastParticle,
            AnimationTime = this.m_NameAnimTime,
            StartDelay = num,
            GlowObject = this.m_NameGlow,
            ImpactRotation = this.m_NameImpactRotation,
            OnComplete = "NameOnComplete"
        };
        AnimationData data = data2;
        base.StartCoroutine("AnimateObject", data);
    }

    [DebuggerHidden]
    private IEnumerator AnimateObject(AnimationData animData)
    {
        return new <AnimateObject>c__IteratorF7 { animData = animData, <$>animData = animData, <>f__this = this };
    }

    private void AnimatePortrait()
    {
        GameObject portraitInstance = this.m_PortraitInstance;
        portraitInstance.transform.parent = null;
        portraitInstance.transform.localScale = this.m_PortraitMesh.transform.lossyScale;
        portraitInstance.transform.position = this.m_PortraitStartPosition.transform.position;
        portraitInstance.transform.parent = base.transform.parent;
        float num = UnityEngine.Random.Range((float) (this.m_PortraitStartDelay - (this.m_PortraitStartDelay * this.m_RandomDelayVariance)), (float) (this.m_PortraitStartDelay + (this.m_PortraitStartDelay * this.m_RandomDelayVariance)));
        AnimationData data2 = new AnimationData {
            Name = "Portrait",
            AnimateTransform = portraitInstance.transform,
            StartTransform = this.m_PortraitStartPosition.transform,
            TargetTransform = this.m_PortraitTargetPosition.transform,
            HitBlastParticle = this.m_PortraitHitBlastParticle,
            AnimationTime = this.m_PortraitAnimTime,
            StartDelay = num,
            GlowObject = this.m_PortraitGlow,
            GlowObjectStandard = this.m_PortraitGlowStandard,
            GlowObjectUnique = this.m_PortraitGlowUnique,
            ImpactRotation = this.m_PortraitImpactRotation,
            OnComplete = "PortraitOnComplete"
        };
        AnimationData data = data2;
        base.StartCoroutine("AnimateObject", data);
    }

    private void AnimateRarity()
    {
        if (this.m_Actor.GetCardSet() != TAG_CARD_SET.CORE)
        {
            GameObject rarityInstance = this.m_RarityInstance;
            rarityInstance.transform.parent = null;
            rarityInstance.transform.localScale = this.m_RarityGemMesh.transform.lossyScale;
            rarityInstance.transform.position = this.m_RarityStartPosition.transform.position;
            rarityInstance.transform.parent = base.transform.parent;
            this.m_RarityInstance.renderer.enabled = true;
            GameObject rarityGlowCommon = this.m_RarityGlowCommon;
            switch (this.m_Actor.GetRarity())
            {
                case TAG_RARITY.RARE:
                    rarityGlowCommon = this.m_RarityGlowRare;
                    break;

                case TAG_RARITY.EPIC:
                    rarityGlowCommon = this.m_RarityGlowEpic;
                    break;

                case TAG_RARITY.LEGENDARY:
                    rarityGlowCommon = this.m_RarityGlowLegendary;
                    break;
            }
            float num = UnityEngine.Random.Range((float) (this.m_RarityStartDelay - (this.m_RarityStartDelay * this.m_RandomDelayVariance)), (float) (this.m_RarityStartDelay + (this.m_RarityStartDelay * this.m_RandomDelayVariance)));
            AnimationData data2 = new AnimationData {
                Name = "Rarity",
                AnimateTransform = rarityInstance.transform,
                StartTransform = this.m_RarityStartPosition.transform,
                TargetTransform = this.m_RarityTargetPosition.transform,
                HitBlastParticle = this.m_RarityHitBlastParticle,
                AnimationTime = this.m_RarityAnimTime,
                StartDelay = num,
                GlowObject = rarityGlowCommon,
                ImpactRotation = this.m_RarityImpactRotation,
                OnComplete = "RarityOnComplete"
            };
            AnimationData data = data2;
            base.StartCoroutine("AnimateObject", data);
        }
    }

    private void ApplyGhostMaterials()
    {
        this.ApplyMaterialByIdx(this.m_CardMesh, this.m_GhostMaterial, this.m_CardFrontIdx);
        this.ApplyMaterialByIdx(this.m_PortraitMesh, this.m_GhostMaterial, this.m_PortraitFrameIdx);
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

    [DebuggerHidden]
    private IEnumerator AttackOnComplete()
    {
        return new <AttackOnComplete>c__IteratorF1 { <>f__this = this };
    }

    private void CameraShakeOnComplete(GameObject shaker)
    {
        ShakeResetter.Get().DestroyShaker(shaker);
    }

    private void Cancel()
    {
        base.StopAllCoroutines();
        this.RestoreOrgMaterials();
        this.DisableManaGem();
        this.DisableDescription();
        this.DisableAttack();
        this.DisableHealth();
        this.DisablePortrait();
        this.DisableName();
        this.DisableRarity();
        this.DestroyInstances();
        this.StopAllParticles();
        this.HideAllMeshObjects();
        if (this.m_Actor != null)
        {
            this.m_Actor.ShowAllText();
        }
    }

    public void Construct()
    {
        base.StartCoroutine(this.DoConstruct());
    }

    private void CreateInstances()
    {
        Vector3 vector = new Vector3(0f, -5000f, 0f);
        if (this.m_RarityGemMesh != null)
        {
            this.m_RarityGemMesh.renderer.enabled = false;
        }
        if (this.m_RarityFrameMesh != null)
        {
            this.m_RarityFrameMesh.renderer.enabled = false;
        }
        if (this.m_ManaGemStartPosition != null)
        {
            this.m_ManaGemInstance = UnityEngine.Object.Instantiate(this.m_ManaCostMesh) as GameObject;
            this.m_ManaGemInstance.transform.parent = base.transform.parent;
            this.m_ManaGemInstance.transform.position = vector;
        }
        if (this.m_DescriptionStartPosition != null)
        {
            this.m_DescriptionInstance = UnityEngine.Object.Instantiate(this.m_DescriptionMesh) as GameObject;
            this.m_DescriptionInstance.transform.parent = base.transform.parent;
            this.m_DescriptionInstance.transform.position = vector;
        }
        if (this.m_AttackStartPosition != null)
        {
            this.m_AttackInstance = UnityEngine.Object.Instantiate(this.m_AttackMesh) as GameObject;
            this.m_AttackInstance.transform.parent = base.transform.parent;
            this.m_AttackInstance.transform.position = vector;
        }
        if (this.m_HealthStartPosition != null)
        {
            this.m_HealthInstance = UnityEngine.Object.Instantiate(this.m_HealthMesh) as GameObject;
            this.m_HealthInstance.transform.parent = base.transform.parent;
            this.m_HealthInstance.transform.position = vector;
        }
        if (this.m_PortraitStartPosition != null)
        {
            this.m_PortraitInstance = UnityEngine.Object.Instantiate(this.m_PortraitMesh) as GameObject;
            this.m_PortraitInstance.transform.parent = base.transform.parent;
            this.m_PortraitInstance.transform.position = vector;
        }
        if (this.m_NameStartPosition != null)
        {
            this.m_NameInstance = UnityEngine.Object.Instantiate(this.m_NameMesh) as GameObject;
            this.m_NameInstance.transform.parent = base.transform.parent;
            this.m_NameInstance.transform.position = vector;
        }
        if (this.m_RarityStartPosition != null)
        {
            this.m_RarityInstance = UnityEngine.Object.Instantiate(this.m_RarityGemMesh) as GameObject;
            this.m_RarityInstance.transform.parent = base.transform.parent;
            this.m_RarityInstance.transform.position = vector;
        }
    }

    [DebuggerHidden]
    private IEnumerator DescriptionOnComplete()
    {
        return new <DescriptionOnComplete>c__IteratorF0 { <>f__this = this };
    }

    private void DestroyInstances()
    {
        if (this.m_ManaGemInstance != null)
        {
            UnityEngine.Object.Destroy(this.m_ManaGemInstance);
        }
        if (this.m_DescriptionInstance != null)
        {
            UnityEngine.Object.Destroy(this.m_DescriptionInstance);
        }
        if (this.m_AttackInstance != null)
        {
            UnityEngine.Object.Destroy(this.m_AttackInstance);
        }
        if (this.m_HealthInstance != null)
        {
            UnityEngine.Object.Destroy(this.m_HealthInstance);
        }
        if (this.m_PortraitInstance != null)
        {
            UnityEngine.Object.Destroy(this.m_PortraitInstance);
        }
        if (this.m_NameInstance != null)
        {
            UnityEngine.Object.Destroy(this.m_NameInstance);
        }
        if (this.m_RarityInstance != null)
        {
            UnityEngine.Object.Destroy(this.m_RarityInstance);
        }
    }

    private void DisableAttack()
    {
        if (this.m_AttackGlow != null)
        {
            foreach (ParticleSystem system in this.m_AttackGlow.GetComponentsInChildren<ParticleSystem>())
            {
                system.Stop();
            }
        }
    }

    private void DisableDescription()
    {
        if (this.m_DescriptionGlow != null)
        {
            foreach (ParticleSystem system in this.m_DescriptionGlow.GetComponentsInChildren<ParticleSystem>())
            {
                system.Stop();
            }
        }
    }

    private void DisableHealth()
    {
        if (this.m_HealthGlow != null)
        {
            foreach (ParticleSystem system in this.m_HealthGlow.GetComponentsInChildren<ParticleSystem>())
            {
                system.Stop();
            }
        }
    }

    private void DisableManaGem()
    {
        if (this.m_ManaGemGlow != null)
        {
            foreach (ParticleSystem system in this.m_ManaGemGlow.GetComponentsInChildren<ParticleSystem>())
            {
                system.Stop();
            }
        }
    }

    private void DisableName()
    {
        if (this.m_NameGlow != null)
        {
            foreach (ParticleSystem system in this.m_NameGlow.GetComponentsInChildren<ParticleSystem>())
            {
                system.Stop();
            }
        }
    }

    private void DisablePortrait()
    {
        if (this.m_PortraitGlow != null)
        {
            foreach (ParticleSystem system in this.m_PortraitGlow.GetComponentsInChildren<ParticleSystem>())
            {
                system.Stop();
            }
        }
    }

    private void DisableRarity()
    {
        if (this.m_RarityGlowCommon != null)
        {
            foreach (ParticleSystem system in this.m_RarityGlowCommon.GetComponentsInChildren<ParticleSystem>())
            {
                system.Stop();
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator DoConstruct()
    {
        return new <DoConstruct>c__IteratorEE { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator EndAnimation()
    {
        return new <EndAnimation>c__IteratorF6 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator HealthOnComplete()
    {
        return new <HealthOnComplete>c__IteratorF2 { <>f__this = this };
    }

    private void HideAllMeshObjects()
    {
        foreach (MeshRenderer renderer in base.GetComponentsInChildren<MeshRenderer>())
        {
            renderer.renderer.enabled = false;
        }
    }

    private void Init()
    {
        if (!this.isInit)
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
                this.m_PortraitMesh = this.m_Actor.m_portraitMesh;
                this.m_PortraitFrameIdx = this.m_Actor.m_portraitFrameMatIdx;
                this.m_NameMesh = this.m_Actor.m_nameBannerMesh;
                this.m_DescriptionMesh = this.m_Actor.m_descriptionMesh;
                this.m_DescriptionTrimMesh = this.m_Actor.m_descriptionTrimMesh;
                this.m_RarityGemMesh = this.m_Actor.m_rarityGemMesh;
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
                switch (this.m_Actor.GetRarity())
                {
                    case TAG_RARITY.RARE:
                        this.m_AnimationScale = this.m_AnimationRarityScaleRare;
                        break;

                    case TAG_RARITY.EPIC:
                        this.m_AnimationScale = this.m_AnimationRarityScaleEpic;
                        break;

                    case TAG_RARITY.LEGENDARY:
                        this.m_AnimationScale = this.m_AnimationRarityScaleLegendary;
                        break;

                    default:
                        this.m_AnimationScale = this.m_AnimationRarityScaleCommon;
                        break;
                }
                this.isInit = true;
            }
        }
    }

    [DebuggerHidden]
    private IEnumerator ManaGemOnComplete()
    {
        return new <ManaGemOnComplete>c__IteratorEF { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator NameOnComplete()
    {
        return new <NameOnComplete>c__IteratorF4 { <>f__this = this };
    }

    private void OnDisable()
    {
        this.Cancel();
    }

    [DebuggerHidden]
    private IEnumerator PortraitOnComplete()
    {
        return new <PortraitOnComplete>c__IteratorF3 { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator RarityOnComplete()
    {
        return new <RarityOnComplete>c__IteratorF5 { <>f__this = this };
    }

    private void RestoreOrgMaterials()
    {
        this.ApplyMaterialByIdx(this.m_CardMesh, this.m_OrgMat_CardFront, this.m_CardFrontIdx);
        this.ApplyMaterialByIdx(this.m_PortraitMesh, this.m_OrgMat_PortraitFrame, this.m_PortraitFrameIdx);
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

    private void StopAllParticles()
    {
        foreach (ParticleSystem system in base.GetComponentsInChildren<ParticleSystem>())
        {
            if (system.isPlaying)
            {
                system.Stop();
            }
        }
    }

    private void StoreOrgMaterials()
    {
        if (this.m_CardMesh != null)
        {
            this.m_OrgMat_CardFront = this.m_CardMesh.renderer.materials[this.m_CardFrontIdx];
        }
        if (this.m_PortraitMesh != null)
        {
            this.m_OrgMat_PortraitFrame = this.m_PortraitMesh.renderer.materials[this.m_PortraitFrameIdx];
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

    [CompilerGenerated]
    private sealed class <AnimateObject>c__IteratorF7 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ConstructCard.AnimationData <$>animData;
        internal ParticleSystem[] <$s_1166>__7;
        internal int <$s_1167>__8;
        internal UnityEngine.Renderer[] <$s_1168>__11;
        internal int <$s_1169>__12;
        internal ParticleSystem[] <$s_1170>__19;
        internal int <$s_1171>__20;
        internal ConstructCard <>f__this;
        internal float <animPos>__0;
        internal Hashtable <args>__24;
        internal Quaternion <currCardRot>__2;
        internal Vector3 <currentTargetPosition>__14;
        internal Quaternion <currentTargetRotation>__15;
        internal GameObject <glowObj>__5;
        internal Hashtable <impactAnimArgs>__22;
        internal UnityEngine.Renderer <mesh>__13;
        internal UnityEngine.Renderer[] <meshRenders>__10;
        internal ParticleSystem[] <particles>__18;
        internal ParticleSystem[] <particles>__6;
        internal Vector3 <position>__16;
        internal ParticleSystem <ps>__21;
        internal ParticleSystem <ps>__9;
        internal float <rate>__1;
        internal Quaternion <rotation>__17;
        internal GameObject <shaker>__23;
        internal Vector3 <startPosition>__3;
        internal Quaternion <startRotation>__4;
        internal ConstructCard.AnimationData animData;

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
                    this.$current = new WaitForSeconds(this.animData.StartDelay);
                    this.$PC = 1;
                    goto Label_06A5;

                case 1:
                    this.<animPos>__0 = 0f;
                    this.<rate>__1 = 1f / (this.animData.AnimationTime * this.<>f__this.m_AnimationScale);
                    this.<currCardRot>__2 = this.<>f__this.m_Actor.transform.rotation;
                    this.<>f__this.m_Actor.transform.rotation = Quaternion.identity;
                    this.<startPosition>__3 = this.animData.StartTransform.position;
                    this.<startRotation>__4 = this.animData.StartTransform.rotation;
                    this.<>f__this.m_Actor.transform.rotation = this.<currCardRot>__2;
                    if (this.animData.GlowObject != null)
                    {
                        this.<glowObj>__5 = this.animData.GlowObject;
                        this.<glowObj>__5.transform.parent = this.animData.AnimateTransform;
                        this.<glowObj>__5.transform.localPosition = Vector3.zero;
                        this.<particles>__6 = this.<glowObj>__5.GetComponentsInChildren<ParticleSystem>();
                        this.<$s_1166>__7 = this.<particles>__6;
                        this.<$s_1167>__8 = 0;
                        while (this.<$s_1167>__8 < this.<$s_1166>__7.Length)
                        {
                            this.<ps>__9 = this.<$s_1166>__7[this.<$s_1167>__8];
                            this.<ps>__9.Play();
                            this.<$s_1167>__8++;
                        }
                        if ((this.animData.GlowObjectStandard != null) && (this.animData.GlowObjectUnique != null))
                        {
                            if (this.<>f__this.m_Actor.IsElite())
                            {
                                this.animData.GlowObjectUnique.renderer.enabled = true;
                            }
                            else
                            {
                                this.animData.GlowObjectStandard.renderer.enabled = true;
                            }
                        }
                        else
                        {
                            this.<meshRenders>__10 = this.<glowObj>__5.GetComponentsInChildren<UnityEngine.Renderer>();
                            this.<$s_1168>__11 = this.<meshRenders>__10;
                            this.<$s_1169>__12 = 0;
                            while (this.<$s_1169>__12 < this.<$s_1168>__11.Length)
                            {
                                this.<mesh>__13 = this.<$s_1168>__11[this.<$s_1169>__12];
                                this.<mesh>__13.enabled = true;
                                this.<$s_1169>__12++;
                            }
                        }
                    }
                    break;

                case 2:
                    break;

                default:
                    goto Label_06A3;
            }
            while (this.<animPos>__0 < 1f)
            {
                this.<currentTargetPosition>__14 = this.animData.TargetTransform.position;
                this.<currentTargetRotation>__15 = this.animData.TargetTransform.rotation;
                this.<animPos>__0 += this.<rate>__1 * UnityEngine.Time.deltaTime;
                this.<position>__16 = Vector3.Lerp(this.<startPosition>__3, this.<currentTargetPosition>__14, this.<animPos>__0);
                this.<rotation>__17 = Quaternion.Lerp(this.<startRotation>__4, this.<currentTargetRotation>__15, this.<animPos>__0);
                this.animData.AnimateTransform.position = this.<position>__16;
                this.animData.AnimateTransform.rotation = this.<rotation>__17;
                this.$current = null;
                this.$PC = 2;
                goto Label_06A5;
            }
            if (this.animData.HitBlastParticle != null)
            {
                this.animData.HitBlastParticle.transform.position = this.animData.TargetTransform.position;
                this.animData.HitBlastParticle.renderer.enabled = true;
                this.animData.HitBlastParticle.Play();
            }
            this.animData.AnimateTransform.parent = this.animData.TargetTransform;
            this.animData.AnimateTransform.position = this.animData.TargetTransform.position;
            this.animData.AnimateTransform.rotation = this.animData.TargetTransform.rotation;
            if (this.animData.GlowObject != null)
            {
                this.<particles>__18 = this.animData.GlowObject.GetComponentsInChildren<ParticleSystem>();
                this.<$s_1170>__19 = this.<particles>__18;
                this.<$s_1171>__20 = 0;
                while (this.<$s_1171>__20 < this.<$s_1170>__19.Length)
                {
                    this.<ps>__21 = this.<$s_1170>__19[this.<$s_1171>__20];
                    this.<ps>__21.Stop();
                    this.<$s_1171>__20++;
                }
            }
            this.<>f__this.m_Actor.gameObject.transform.localRotation = Quaternion.Euler(this.animData.ImpactRotation);
            object[] args = new object[] { "rotation", Vector3.zero, "time", this.<>f__this.m_ImpactRotationTime, "easetype", iTween.EaseType.easeOutQuad, "space", Space.Self, "name", "CardConstructImpactRotation" + this.animData.Name };
            this.<impactAnimArgs>__22 = iTween.Hash(args);
            iTween.StopByName(this.<>f__this.m_Actor.gameObject, "CardConstructImpactRotation" + this.animData.Name);
            iTween.RotateTo(this.<>f__this.m_Actor.gameObject, this.<impactAnimArgs>__22);
            this.<shaker>__23 = ShakeResetter.Get().CreateShaker(Camera.main.gameObject);
            object[] objArray2 = new object[] { "amount", this.<>f__this.m_ImpactCameraShakeAmount, "time", this.<>f__this.m_ImpactCameraShakeTime, "oncomplete", "OnComplete", "oncompletetarget", this.<>f__this.gameObject, "oncompleteparams", this.<shaker>__23, "name", "CardConstructImpactRotation" };
            this.<args>__24 = iTween.Hash(objArray2);
            iTween.StopByName(Camera.main.gameObject, "CardConstructImpactRotation");
            iTween.ShakePosition(Camera.main.gameObject, this.<args>__24);
            if (this.animData.OnComplete != string.Empty)
            {
                this.<>f__this.StartCoroutine(this.animData.OnComplete);
            }
        Label_06A3:
            return false;
        Label_06A5:
            return true;
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
    private sealed class <AttackOnComplete>c__IteratorF1 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ConstructCard <>f__this;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            this.$PC = -1;
            if (this.$PC == 0)
            {
                this.<>f__this.DisableAttack();
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
    private sealed class <DescriptionOnComplete>c__IteratorF0 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ConstructCard <>f__this;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            this.$PC = -1;
            if (this.$PC == 0)
            {
                this.<>f__this.DisableDescription();
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
    private sealed class <DoConstruct>c__IteratorEE : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ConstructCard <>f__this;

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
                    this.<>f__this.m_Actor = SceneUtils.FindComponentInThisOrParents<Actor>(this.<>f__this.gameObject);
                    if (this.<>f__this.m_Actor != null)
                    {
                        this.<>f__this.m_Actor.HideAllText();
                        this.<>f__this.m_GhostSpell = this.<>f__this.m_Actor.GetSpell(SpellType.GHOSTMODE);
                        this.<>f__this.m_GhostSpell.ActivateState(SpellStateType.CANCEL);
                        this.<>f__this.m_Actor.DeactivateSpell(SpellType.GHOSTMODE);
                        break;
                    }
                    UnityEngine.Debug.LogError(string.Format("{0} Ghost card effect failed to find Actor!", this.<>f__this.transform.root.name));
                    this.<>f__this.enabled = false;
                    goto Label_0327;

                case 1:
                    break;

                default:
                    goto Label_0327;
            }
            while (this.<>f__this.m_GhostSpell.IsActive())
            {
                this.$current = new WaitForEndOfFrame();
                this.$PC = 1;
                return true;
            }
            this.<>f__this.m_Actor.HideAllText();
            this.<>f__this.Init();
            this.<>f__this.CreateInstances();
            this.<>f__this.ApplyGhostMaterials();
            if (this.<>f__this.m_GhostGlow != null)
            {
                if (this.<>f__this.m_Actor.IsElite() && (this.<>f__this.m_GhostTextureUnique != null))
                {
                    this.<>f__this.m_GhostGlow.renderer.material.mainTexture = this.<>f__this.m_GhostTextureUnique;
                }
                this.<>f__this.m_GhostGlow.renderer.enabled = true;
                this.<>f__this.m_GhostGlow.animation.Play("GhostModeHot", PlayMode.StopAll);
            }
            if (this.<>f__this.m_RarityGemMesh != null)
            {
                this.<>f__this.m_RarityGemMesh.renderer.enabled = false;
            }
            if (this.<>f__this.m_RarityFrameMesh != null)
            {
                this.<>f__this.m_RarityFrameMesh.renderer.enabled = false;
            }
            if (this.<>f__this.m_ManaGemStartPosition != null)
            {
                this.<>f__this.AnimateManaGem();
            }
            if (this.<>f__this.m_DescriptionStartPosition != null)
            {
                this.<>f__this.AnimateDescription();
            }
            if (this.<>f__this.m_AttackStartPosition != null)
            {
                this.<>f__this.AnimateAttack();
            }
            if (this.<>f__this.m_HealthStartPosition != null)
            {
                this.<>f__this.AnimateHealth();
            }
            if (this.<>f__this.m_PortraitStartPosition != null)
            {
                this.<>f__this.AnimatePortrait();
            }
            if (this.<>f__this.m_NameStartPosition != null)
            {
                this.<>f__this.AnimateName();
            }
            if ((this.<>f__this.m_Actor.GetCardSet() != TAG_CARD_SET.CORE) && (this.<>f__this.m_RarityStartPosition != null))
            {
                this.<>f__this.AnimateRarity();
            }
        Label_0327:
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
    private sealed class <EndAnimation>c__IteratorF6 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal UnityEngine.Renderer[] <$s_1164>__3;
        internal int <$s_1165>__4;
        internal ConstructCard <>f__this;
        internal ParticleSystem <burst>__0;
        internal UnityEngine.Renderer[] <burstParticleRenderers>__2;
        internal UnityEngine.Renderer <burstRenderer>__5;
        internal string <fuseAnimation>__6;
        internal TAG_RARITY <rarity>__1;

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
                    this.<burst>__0 = this.<>f__this.m_RarityBurstCommon;
                    this.<rarity>__1 = this.<>f__this.m_Actor.GetRarity();
                    switch (this.<rarity>__1)
                    {
                        case TAG_RARITY.RARE:
                            this.<burst>__0 = this.<>f__this.m_RarityBurstRare;
                            break;

                        case TAG_RARITY.EPIC:
                            this.<burst>__0 = this.<>f__this.m_RarityBurstEpic;
                            break;

                        case TAG_RARITY.LEGENDARY:
                            this.<burst>__0 = this.<>f__this.m_RarityBurstLegendary;
                            break;
                    }
                    break;

                case 1:
                    this.<>f__this.DestroyInstances();
                    this.<>f__this.m_Actor.ShowAllText();
                    this.<>f__this.RestoreOrgMaterials();
                    goto Label_0220;

                default:
                    goto Label_0220;
            }
            if (this.<burst>__0 != null)
            {
                this.<burstParticleRenderers>__2 = this.<burst>__0.GetComponentsInChildren<UnityEngine.Renderer>();
                this.<$s_1164>__3 = this.<burstParticleRenderers>__2;
                this.<$s_1165>__4 = 0;
                while (this.<$s_1165>__4 < this.<$s_1164>__3.Length)
                {
                    this.<burstRenderer>__5 = this.<$s_1164>__3[this.<$s_1165>__4];
                    this.<burstRenderer>__5.enabled = true;
                    this.<$s_1165>__4++;
                }
                this.<burst>__0.Play(true);
            }
            this.<fuseAnimation>__6 = "CardFuse_Common";
            switch (this.<rarity>__1)
            {
                case TAG_RARITY.RARE:
                    this.<fuseAnimation>__6 = "CardFuse_Rare";
                    break;

                case TAG_RARITY.EPIC:
                    this.<fuseAnimation>__6 = "CardFuse_Epic";
                    break;

                case TAG_RARITY.LEGENDARY:
                    this.<fuseAnimation>__6 = "CardFuse_Legendary";
                    break;
            }
            if (this.<>f__this.m_FuseGlow != null)
            {
                this.<>f__this.m_FuseGlow.renderer.enabled = true;
                this.<>f__this.m_FuseGlow.animation.Play(this.<fuseAnimation>__6, PlayMode.StopAll);
            }
            this.$current = new WaitForSeconds(0.25f);
            this.$PC = 1;
            return true;
        Label_0220:
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
    private sealed class <HealthOnComplete>c__IteratorF2 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ConstructCard <>f__this;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            this.$PC = -1;
            if (this.$PC == 0)
            {
                this.<>f__this.DisableHealth();
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
    private sealed class <ManaGemOnComplete>c__IteratorEF : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ConstructCard <>f__this;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            this.$PC = -1;
            if (this.$PC == 0)
            {
                this.<>f__this.DisableManaGem();
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
    private sealed class <NameOnComplete>c__IteratorF4 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ConstructCard <>f__this;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            this.$PC = -1;
            if (this.$PC == 0)
            {
                this.<>f__this.DisableName();
                if (this.<>f__this.m_Actor.GetCardSet() == TAG_CARD_SET.CORE)
                {
                    this.<>f__this.StartCoroutine(this.<>f__this.EndAnimation());
                }
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
    private sealed class <PortraitOnComplete>c__IteratorF3 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ConstructCard <>f__this;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            this.$PC = -1;
            if (this.$PC == 0)
            {
                this.<>f__this.DisablePortrait();
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
    private sealed class <RarityOnComplete>c__IteratorF5 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ConstructCard <>f__this;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            this.$PC = -1;
            if (this.$PC == 0)
            {
                this.<>f__this.DisableRarity();
                if (this.<>f__this.m_Actor.GetCardSet() != TAG_CARD_SET.CORE)
                {
                    if (this.<>f__this.m_RarityGemMesh != null)
                    {
                        this.<>f__this.m_RarityGemMesh.renderer.enabled = true;
                    }
                    if (this.<>f__this.m_RarityFrameMesh != null)
                    {
                        this.<>f__this.m_RarityFrameMesh.renderer.enabled = true;
                    }
                }
                this.<>f__this.StartCoroutine(this.<>f__this.EndAnimation());
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

    private class AnimationData
    {
        public Transform AnimateTransform;
        public float AnimationTime = 1f;
        public GameObject GlowObject;
        public GameObject GlowObjectStandard;
        public GameObject GlowObjectUnique;
        public ParticleSystem HitBlastParticle;
        public Vector3 ImpactRotation;
        public string Name;
        public string OnComplete = string.Empty;
        public float StartDelay;
        public Transform StartTransform;
        public Transform TargetTransform;
    }
}

