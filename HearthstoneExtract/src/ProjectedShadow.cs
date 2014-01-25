using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectedShadow : MonoBehaviour
{
    private const string CONTACT_SHADER_NAME = "Custom/ContactShadow";
    private const float CONTACT_SHADOW_FADE_IN_HEIGHT = 0.08f;
    private const float CONTACT_SHADOW_INTENSITY = 3.5f;
    private const int CONTACT_SHADOW_RESOLUTION = 80;
    private const float CONTACT_SHADOW_SCALE = 0.98f;
    private const string GAMEOBJECT_NAME_EXT = "ShadowProjector";
    private float m_AdjustedShadowProjectorSize = 1.5f;
    public bool m_AutoBoardHeightDisable;
    public float m_AutoDisableHeight;
    private float m_BoardHeight = 0.2f;
    private Camera m_Camera;
    public Vector3 m_ContactOffset = Vector3.zero;
    public bool m_ContactShadow;
    private Material m_ContactShadowMaterial;
    private Shader m_ContactShadowShader;
    private RenderTexture m_ContactShadowTexture;
    public bool m_ContinuousRendering;
    public int m_DesktopRenderSize = 0x40;
    public bool m_isDirtyContactShadow = true;
    public int m_MobileRenderSize = 0x20;
    private Material m_MultiSampleMaterial;
    private Shader m_MultiSampleShader;
    private GameObject m_PlaneGameObject;
    private Mesh m_PlaneMesh;
    public float m_ProjectionFarClip = 10f;
    public Vector3 m_ProjectionOffset;
    private Projector m_Projector;
    private GameObject m_ProjectorGameObject;
    private Transform m_ProjectorTransform;
    private GameObject m_RootObject;
    public bool m_ShadowEnabled;
    private Texture2D m_ShadowFalloffRamp;
    private Material m_ShadowMaterial;
    public float m_ShadowProjectorSize = 1.5f;
    private Shader m_ShadowShader;
    private RenderTexture m_ShadowTexture;
    private Shader m_UnlitDarkGreyShader;
    private Shader m_UnlitLightGreyShader;
    private Shader m_UnlitWhiteShader;
    private const string MULTISAMPLE_SHADER_NAME = "Custom/Selection/HighlightMultiSample";
    private const float NEARCLIP_PLANE = 0f;
    private readonly Vector3[] PLANE_NORMALS = new Vector3[] { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
    private readonly int[] PLANE_TRIANGLES = new int[] { 3, 1, 2, 2, 1, 0 };
    private readonly Vector2[] PLANE_UVS = new Vector2[] { new Vector2(0f, 0f), new Vector2(1f, 0f), new Vector2(0f, 1f), new Vector2(1f, 1f) };
    private const float RENDERMASK_BLUR = 0.6f;
    private const float RENDERMASK_OFFSET = 0.11f;
    private static float s_offset = -12000f;
    private static Color s_ShadowColor = new Color(0.098f, 0.098f, 0.235f, 0.45f);
    private const string SHADER_FALLOFF_RAMP = "Textures/ProjectedShadowRamp";
    private const string SHADER_NAME = "Custom/ProjectedShadow";
    private const float SHADOW_OFFSET_SCALE = 0.3f;
    private const string UNLIT_DARKGREY_SHADER_NAME = "Custom/Unlit/Color/DarkGrey";
    private const string UNLIT_LIGHTGREY_SHADER_NAME = "Custom/Unlit/Color/LightGrey";
    private const string UNLIT_WHITE_SHADER_NAME = "Custom/Unlit/Color/White";

    private void CreateCamera()
    {
        if (this.m_Camera != null)
        {
            UnityEngine.Object.Destroy(this.m_Camera);
        }
        GameObject obj2 = new GameObject();
        this.m_Camera = obj2.AddComponent<Camera>();
        obj2.name = base.name + "_ShadowCamera";
        obj2.hideFlags = HideFlags.HideAndDontSave;
        this.m_Camera.orthographic = true;
        this.m_Camera.orthographicSize = this.m_AdjustedShadowProjectorSize;
        this.m_Camera.transform.position = base.transform.position;
        this.m_Camera.transform.rotation = base.transform.rotation;
        this.m_Camera.transform.Rotate((float) 90f, 0f, (float) 0f);
        if (this.m_RootObject != null)
        {
            this.m_Camera.transform.parent = this.m_RootObject.transform;
        }
        this.m_Camera.nearClipPlane = -3f;
        this.m_Camera.farClipPlane = 3f;
        this.m_Camera.depth = Camera.main.depth - 5f;
        this.m_Camera.backgroundColor = Color.black;
        this.m_Camera.clearFlags = CameraClearFlags.Color;
        this.m_Camera.depthTextureMode = DepthTextureMode.None;
        this.m_Camera.renderingPath = RenderingPath.Forward;
        this.m_Camera.SetReplacementShader(this.m_UnlitWhiteShader, "Highlight");
        this.m_Camera.targetTexture = this.m_ShadowTexture;
        this.m_Camera.enabled = false;
    }

    private void CreateProjector()
    {
        if (this.m_Projector != null)
        {
            UnityEngine.Object.Destroy(this.m_Projector);
            this.m_Projector = null;
        }
        if (this.m_ProjectorGameObject != null)
        {
            UnityEngine.Object.Destroy(this.m_ProjectorGameObject);
            this.m_ProjectorGameObject = null;
            this.m_ProjectorTransform = null;
        }
        this.m_ProjectorGameObject = new GameObject(string.Format("{0}_{1}", base.name, "ShadowProjector"));
        this.m_Projector = this.m_ProjectorGameObject.AddComponent<Projector>();
        this.m_ProjectorTransform = this.m_ProjectorGameObject.transform;
        this.m_ProjectorTransform.Rotate((float) 90f, 0f, (float) 0f);
        if (this.m_RootObject != null)
        {
            this.m_ProjectorTransform.parent = this.m_RootObject.transform;
        }
        this.m_Projector.nearClipPlane = 0f;
        this.m_Projector.farClipPlane = this.m_ProjectionFarClip;
        this.m_Projector.isOrthoGraphic = true;
        this.m_Projector.orthoGraphicSize = this.m_AdjustedShadowProjectorSize;
        this.m_Projector.hideFlags = HideFlags.HideAndDontSave;
        this.m_Projector.material = this.m_ShadowMaterial;
    }

    private void CreateRenderPlane()
    {
        if (this.m_PlaneGameObject != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_PlaneGameObject);
        }
        this.m_PlaneGameObject = new GameObject();
        this.m_PlaneGameObject.name = base.name + "_ContactShadowRenderPlane";
        if (this.m_RootObject != null)
        {
            this.m_PlaneGameObject.transform.parent = this.m_RootObject.transform;
        }
        this.m_PlaneGameObject.transform.localPosition = this.m_ContactOffset;
        this.m_PlaneGameObject.transform.localRotation = Quaternion.identity;
        this.m_PlaneGameObject.transform.localScale = new Vector3(0.98f, 1f, 0.98f);
        this.m_PlaneGameObject.AddComponent<MeshFilter>();
        this.m_PlaneGameObject.AddComponent<MeshRenderer>();
        this.m_PlaneGameObject.hideFlags = HideFlags.HideAndDontSave;
        Mesh mesh = new Mesh {
            name = "ContactShadowMeshPlane"
        };
        float shadowProjectorSize = this.m_ShadowProjectorSize;
        float z = this.m_ShadowProjectorSize;
        mesh.vertices = new Vector3[] { new Vector3(-shadowProjectorSize, 0f, -z), new Vector3(shadowProjectorSize, 0f, -z), new Vector3(-shadowProjectorSize, 0f, z), new Vector3(shadowProjectorSize, 0f, z) };
        mesh.uv = this.PLANE_UVS;
        mesh.normals = this.PLANE_NORMALS;
        mesh.triangles = this.PLANE_TRIANGLES;
        Mesh mesh2 = mesh;
        this.m_PlaneGameObject.GetComponent<MeshFilter>().mesh = mesh2;
        this.m_PlaneMesh = mesh2;
        this.m_PlaneMesh.RecalculateBounds();
        this.m_ContactShadowMaterial = this.ContactShadowMaterial;
        this.m_ContactShadowMaterial.color = s_ShadowColor;
        if (this.m_ContactShadowMaterial != null)
        {
            this.m_PlaneGameObject.renderer.sharedMaterial = this.m_ContactShadowMaterial;
        }
    }

    [DebuggerHidden]
    private IEnumerator DelayRenderContactShadow()
    {
        return new <DelayRenderContactShadow>c__IteratorFF { <>f__this = this };
    }

    public void DisableShadow()
    {
        this.DisableShadowProjector();
    }

    public void DisableShadow(float FadeOutTime)
    {
        if ((this.m_Projector != null) && this.m_ShadowEnabled)
        {
            object[] args = new object[] { "from", 1, "to", 0, "time", FadeOutTime, "easetype", iTween.EaseType.easeOutCubic, "onupdate", "UpdateShadowColor", "onupdatetarget", base.gameObject, "name", "ProjectedShadowFade", "oncomplete", "DisableShadowProjector" };
            Hashtable hashtable = iTween.Hash(args);
            iTween.StopByName(base.gameObject, "ProjectedShadowFade");
            iTween.ValueTo(base.gameObject, hashtable);
        }
    }

    private void DisableShadowProjector()
    {
        if (this.m_Projector != null)
        {
            this.m_Projector.enabled = false;
        }
        this.m_ShadowEnabled = false;
    }

    public void EnableShadow()
    {
        this.m_ShadowEnabled = true;
    }

    public void EnableShadow(float FadeInTime)
    {
        this.m_ShadowEnabled = true;
        object[] args = new object[] { "from", 0, "to", 1, "time", FadeInTime, "easetype", iTween.EaseType.easeInCubic, "onupdate", "UpdateShadowColor", "onupdatetarget", base.gameObject, "name", "ProjectedShadowFade" };
        Hashtable hashtable = iTween.Hash(args);
        iTween.StopByName(base.gameObject, "ProjectedShadowFade");
        iTween.ValueTo(base.gameObject, hashtable);
    }

    protected void OnDestroy()
    {
        if (this.m_ShadowMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_ShadowMaterial);
        }
        if (this.m_MultiSampleMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_MultiSampleMaterial);
        }
        if (this.m_Camera != null)
        {
            UnityEngine.Object.Destroy(this.m_Camera.gameObject);
        }
        if (this.m_ProjectorGameObject != null)
        {
            UnityEngine.Object.Destroy(this.m_ProjectorGameObject);
        }
    }

    private void OnDisable()
    {
        if (this.m_Projector != null)
        {
            this.m_Projector.enabled = false;
        }
        if (this.m_PlaneGameObject != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_PlaneGameObject);
        }
        if ((RenderTexture.active == this.m_ShadowTexture) || (RenderTexture.active == this.m_ContactShadowTexture))
        {
            RenderTexture.active = null;
        }
        if (this.m_ShadowTexture != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_ShadowTexture);
        }
        if (this.m_ContactShadowTexture != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_ContactShadowTexture);
        }
    }

    private void OnDrawGizmos()
    {
        float x = (this.m_ShadowProjectorSize * TransformUtil.ComputeWorldScale(base.transform).x) * 2f;
        Gizmos.matrix = base.transform.localToWorldMatrix;
        Gizmos.color = new Color(0.6f, 0.15f, 0.6f);
        if (this.m_ContactShadow)
        {
            Gizmos.DrawWireCube(this.m_ContactOffset, new Vector3(x, 0f, x));
        }
        else
        {
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(x, 0f, x));
        }
        Gizmos.matrix = Matrix4x4.identity;
    }

    public void Render()
    {
        if (!this.m_ShadowEnabled || !this.m_RootObject.activeSelf)
        {
            if ((this.m_Projector != null) && this.m_Projector.enabled)
            {
                this.m_Projector.enabled = false;
            }
            if (this.m_PlaneGameObject != null)
            {
                this.m_PlaneGameObject.SetActive(false);
            }
        }
        else
        {
            float x = TransformUtil.ComputeWorldScale(base.transform).x;
            this.m_AdjustedShadowProjectorSize = this.m_ShadowProjectorSize * x;
            if (this.m_Projector == null)
            {
                this.CreateProjector();
            }
            if (this.m_Camera == null)
            {
                this.CreateCamera();
            }
            float num2 = (base.transform.position.y - this.m_BoardHeight) * 0.3f;
            if (this.m_ContactShadow)
            {
                float num3 = this.m_BoardHeight + 0.08f;
                if (num2 < num3)
                {
                    if (this.m_PlaneGameObject == null)
                    {
                        this.m_isDirtyContactShadow = true;
                    }
                    else if (!this.m_PlaneGameObject.activeSelf)
                    {
                        this.m_isDirtyContactShadow = true;
                    }
                    float num4 = Mathf.Clamp((float) ((num3 - num2) / num3), (float) 0f, (float) 1f);
                    if (this.m_ContactShadowTexture != null)
                    {
                        this.m_PlaneGameObject.renderer.sharedMaterial.mainTexture = this.m_ContactShadowTexture;
                        this.m_PlaneGameObject.renderer.sharedMaterial.color = s_ShadowColor;
                        this.m_PlaneGameObject.renderer.sharedMaterial.SetFloat("_Alpha", num4);
                    }
                }
                else if (this.m_PlaneGameObject != null)
                {
                    this.m_PlaneGameObject.SetActive(false);
                }
            }
            if ((num2 < this.m_AutoDisableHeight) && this.m_AutoBoardHeightDisable)
            {
                this.m_Projector.enabled = false;
                UnityEngine.Object.DestroyImmediate(this.m_ShadowTexture);
                this.m_ShadowTexture = null;
            }
            else
            {
                this.m_Projector.enabled = true;
                Vector3 vector = new Vector3(base.transform.position.x - num2, base.transform.position.y, base.transform.position.z - num2);
                this.m_ProjectorTransform.position = vector;
                this.m_ProjectorTransform.Translate(this.m_ProjectionOffset);
                if (!this.m_ContinuousRendering)
                {
                    Quaternion rotation = base.transform.rotation;
                    float num5 = ((1f - rotation.z) * 0.5f) + 0.5f;
                    float num6 = rotation.x * 0.5f;
                    this.m_Projector.aspectRatio = num5 - num6;
                    this.m_Projector.orthographicSize = this.m_AdjustedShadowProjectorSize + num6;
                    this.m_ProjectorTransform.rotation = Quaternion.identity;
                    this.m_ProjectorTransform.Rotate((float) 90f, rotation.eulerAngles.y, (float) 0f);
                }
                else
                {
                    this.m_ProjectorTransform.rotation = Quaternion.identity;
                    this.m_ProjectorTransform.Rotate((float) 90f, 0f, (float) 0f);
                    this.m_Projector.orthographicSize = this.m_AdjustedShadowProjectorSize;
                }
                int desktopRenderSize = this.m_DesktopRenderSize;
                if (this.m_ShadowTexture == null)
                {
                    this.m_ShadowTexture = new RenderTexture(desktopRenderSize, desktopRenderSize, 0x20);
                    this.m_ShadowTexture.wrapMode = TextureWrapMode.Clamp;
                    this.RenderShadowMask();
                }
                else if (this.m_ContinuousRendering || !this.m_ShadowTexture.IsCreated())
                {
                    this.RenderShadowMask();
                }
            }
        }
    }

    private void RenderContactShadow()
    {
        GraphicsManager manager = GraphicsManager.Get();
        if ((manager != null) && manager.RealtimeShadows)
        {
            base.enabled = false;
        }
        if (((this.m_ContactShadowTexture == null) || this.m_isDirtyContactShadow) || !this.m_ContactShadowTexture.IsCreated())
        {
            float x = TransformUtil.ComputeWorldScale(base.transform).x;
            this.m_AdjustedShadowProjectorSize = this.m_ShadowProjectorSize * x;
            if (this.m_Camera == null)
            {
                this.CreateCamera();
            }
            if (this.m_PlaneGameObject == null)
            {
                this.CreateRenderPlane();
            }
            this.m_PlaneGameObject.SetActive(true);
            if (this.m_ContactShadowTexture == null)
            {
                this.m_ContactShadowTexture = new RenderTexture(80, 80, 0x20);
            }
            Quaternion localRotation = base.transform.localRotation;
            Vector3 position = base.transform.position;
            Vector3 localScale = base.transform.localScale;
            s_offset -= 10f;
            if (s_offset < -19000f)
            {
                s_offset = -12000f;
            }
            Vector3 vector3 = (Vector3) (Vector3.left * s_offset);
            base.transform.position = vector3;
            base.transform.rotation = Quaternion.identity;
            this.SetWorldScale(base.transform, Vector3.one);
            this.m_Camera.transform.position = vector3;
            this.m_Camera.transform.rotation = Quaternion.identity;
            this.m_Camera.transform.Rotate((float) 90f, 0f, (float) 0f);
            this.m_Camera.depth = Camera.main.depth - 3f;
            this.m_Camera.clearFlags = CameraClearFlags.Color;
            this.m_Camera.targetTexture = this.m_ContactShadowTexture;
            this.m_Camera.orthographicSize = this.m_ShadowProjectorSize - 0.11f;
            this.m_Camera.RenderWithShader(this.m_UnlitDarkGreyShader, "Highlight");
            this.Sample(this.m_ContactShadowTexture, this.m_ContactShadowTexture, 0.6f);
            base.transform.localRotation = localRotation;
            base.transform.position = position;
            base.transform.localScale = localScale;
            this.m_PlaneGameObject.renderer.sharedMaterial.mainTexture = this.m_ContactShadowTexture;
            this.m_isDirtyContactShadow = false;
        }
    }

    private void RenderShadowMask()
    {
        Vector3 position = base.transform.position;
        Vector3 localScale = base.transform.localScale;
        s_offset -= 10f;
        if (s_offset < -19000f)
        {
            s_offset = -12000f;
        }
        Vector3 vector3 = (Vector3) (Vector3.left * s_offset);
        base.transform.position = vector3;
        this.SetWorldScale(base.transform, Vector3.one);
        this.m_Camera.transform.position = vector3;
        this.m_Camera.transform.rotation = Quaternion.identity;
        this.m_Camera.transform.Rotate((float) 90f, 0f, (float) 0f);
        this.m_Camera.depth = Camera.main.depth - 3f;
        this.m_Camera.clearFlags = CameraClearFlags.Color;
        this.m_Camera.targetTexture = this.m_ShadowTexture;
        this.m_Camera.orthographicSize = this.m_ShadowProjectorSize - 0.11f;
        this.m_Camera.RenderWithShader(this.m_UnlitDarkGreyShader, "Highlight");
        this.m_Camera.depth = Camera.main.depth - 2f;
        this.m_Camera.clearFlags = CameraClearFlags.Nothing;
        this.m_Camera.orthographicSize = this.m_ShadowProjectorSize;
        this.m_Camera.RenderWithShader(this.m_UnlitLightGreyShader, "Highlight");
        this.m_Camera.depth = Camera.main.depth - 1f;
        this.m_Camera.orthographicSize = this.m_ShadowProjectorSize + 0.11f;
        this.m_Camera.RenderWithShader(this.m_UnlitWhiteShader, "Highlight");
        this.Sample(this.m_ShadowTexture, this.m_ShadowTexture, 0.6f);
        this.m_ShadowMaterial.SetTexture("_MainTex", this.m_ShadowTexture);
        this.m_ShadowMaterial.SetColor("_Color", s_ShadowColor);
        base.transform.position = position;
        base.transform.localScale = localScale;
    }

    private void Sample(RenderTexture source, RenderTexture dest, float off)
    {
        Vector2[] offsets = new Vector2[] { new Vector2(-off, -off), new Vector2(-off, off), new Vector2(off, off), new Vector2(off, -off) };
        Graphics.BlitMultiTap(source, dest, this.MultiSampleMaterial, offsets);
    }

    public static void SetShadowColor(Color color)
    {
        s_ShadowColor = color;
    }

    public void SetWorldScale(Transform xform, Vector3 scale)
    {
        GameObject obj2 = new GameObject();
        Transform transform = obj2.transform;
        transform.parent = null;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
        Transform parent = xform.parent;
        xform.parent = transform;
        xform.localScale = scale;
        xform.parent = parent;
        UnityEngine.Object.Destroy(obj2);
    }

    protected void Start()
    {
        GraphicsManager manager = GraphicsManager.Get();
        if ((manager != null) && manager.RealtimeShadows)
        {
            base.enabled = false;
        }
        if (this.m_ShadowShader == null)
        {
            this.m_ShadowShader = Shader.Find("Custom/ProjectedShadow");
        }
        if (this.m_ShadowShader == null)
        {
            UnityEngine.Debug.LogError("Failed to load Projected Shadow Shader: Custom/ProjectedShadow");
            base.enabled = false;
        }
        if (this.m_ContactShadowShader == null)
        {
            this.m_ContactShadowShader = Shader.Find("Custom/ContactShadow");
        }
        if (this.m_ContactShadowShader == null)
        {
            UnityEngine.Debug.LogError("Failed to load Projected Shadow Shader: Custom/ContactShadow");
            base.enabled = false;
        }
        if (this.m_ShadowFalloffRamp == null)
        {
            this.m_ShadowFalloffRamp = Resources.Load("Textures/ProjectedShadowRamp") as Texture2D;
        }
        if (this.m_ShadowFalloffRamp == null)
        {
            UnityEngine.Debug.LogError("Failed to load Projected Shadow Ramp: Textures/ProjectedShadowRamp");
            base.enabled = false;
        }
        if (this.m_MultiSampleShader == null)
        {
            this.m_MultiSampleShader = Shader.Find("Custom/Selection/HighlightMultiSample");
        }
        if (this.m_MultiSampleShader == null)
        {
            UnityEngine.Debug.LogError("Failed to load Projected Shadow Shader: Custom/Selection/HighlightMultiSample");
            base.enabled = false;
        }
        this.m_UnlitWhiteShader = Shader.Find("Custom/Unlit/Color/White");
        if (this.m_UnlitWhiteShader == null)
        {
            UnityEngine.Debug.LogError("Failed to load Projected Shadow Shader: Custom/Unlit/Color/White");
        }
        this.m_UnlitLightGreyShader = Shader.Find("Custom/Unlit/Color/LightGrey");
        if (this.m_UnlitLightGreyShader == null)
        {
            UnityEngine.Debug.LogError("Failed to load Projected Shadow Shader: Custom/Unlit/Color/LightGrey");
        }
        this.m_UnlitDarkGreyShader = Shader.Find("Custom/Unlit/Color/DarkGrey");
        if (this.m_UnlitDarkGreyShader == null)
        {
            UnityEngine.Debug.LogError("Failed to load Projected Shadow Shader: Custom/Unlit/Color/DarkGrey");
        }
        if (Board.Get() != null)
        {
            Transform transform = Board.Get().FindBone("CenterPointBone");
            if (transform != null)
            {
                this.m_BoardHeight = transform.position.y;
            }
        }
        Actor component = base.GetComponent<Actor>();
        if (component != null)
        {
            this.m_RootObject = component.GetRootObject();
        }
        else
        {
            GameObject obj2 = SceneUtils.FindChildBySubstring(base.gameObject, "RootObject");
            if (obj2 != null)
            {
                this.m_RootObject = obj2;
            }
            else
            {
                this.m_RootObject = base.gameObject;
            }
        }
        this.m_ShadowMaterial = this.ShadowMaterial;
    }

    protected void Update()
    {
        GraphicsManager manager = GraphicsManager.Get();
        if ((manager != null) && manager.RealtimeShadows)
        {
            base.enabled = false;
        }
        else
        {
            this.Render();
            if (this.m_ContactShadow)
            {
                this.RenderContactShadow();
            }
        }
    }

    public void UpdateContactShadow()
    {
        if (this.m_ContactShadow)
        {
            this.m_isDirtyContactShadow = true;
        }
    }

    public void UpdateContactShadow(Spell spell)
    {
        this.UpdateContactShadow();
    }

    public void UpdateContactShadow(Spell spell, object userData)
    {
        this.UpdateContactShadow();
    }

    public void UpdateContactShadow(Spell spell, SpellStateType prevStateType, object userData)
    {
        this.UpdateContactShadow();
    }

    private void UpdateShadowColor(float val)
    {
        if ((this.m_Projector != null) && (this.m_Projector.material != null))
        {
            Color a = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            Color color = Color.Lerp(a, s_ShadowColor, val);
            this.m_Projector.material.SetColor("_Color", color);
        }
    }

    protected Material ContactShadowMaterial
    {
        get
        {
            if (this.m_ContactShadowMaterial == null)
            {
                this.m_ContactShadowMaterial = new Material(this.m_ContactShadowShader);
                this.m_ContactShadowMaterial.SetFloat("_Intensity", 3.5f);
                this.m_ContactShadowMaterial.SetColor("_Color", s_ShadowColor);
                this.m_ContactShadowMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_ContactShadowMaterial;
        }
    }

    protected Material MultiSampleMaterial
    {
        get
        {
            if (this.m_MultiSampleMaterial == null)
            {
                this.m_MultiSampleMaterial = new Material(this.m_MultiSampleShader);
                this.m_MultiSampleMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_MultiSampleMaterial;
        }
    }

    protected Material ShadowMaterial
    {
        get
        {
            if (this.m_ShadowMaterial == null)
            {
                this.m_ShadowMaterial = new Material(this.m_ShadowShader);
                this.m_ShadowMaterial.hideFlags = HideFlags.DontSave;
                this.m_ShadowMaterial.SetTexture("_Ramp", this.m_ShadowFalloffRamp);
                this.m_ShadowMaterial.SetTexture("_MainTex", this.m_ShadowTexture);
                this.m_ShadowMaterial.SetColor("_Color", s_ShadowColor);
            }
            return this.m_ShadowMaterial;
        }
    }

    [CompilerGenerated]
    private sealed class <DelayRenderContactShadow>c__IteratorFF : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ProjectedShadow <>f__this;

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
                    this.$current = null;
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.m_isDirtyContactShadow = true;
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

