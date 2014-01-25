using System;
using UnityEngine;

public class RenderToTexture : MonoBehaviour
{
    private const string ADDITIVE_SHADER_NAME = "Hidden/R2TAdditive";
    private const string ALPHA_BLEND_SHADER_NAME = "Hidden/R2TColorAlphaCombine";
    private const string ALPHA_CLIP_GRADIENT_SHADER_NAME = "Hidden/R2TAlphaClipGradient";
    private const string ALPHA_CLIP_SHADER_NAME = "Hidden/R2TAlphaClip";
    private readonly Vector3 ALPHA_OBJECT_OFFSET = new Vector3(0f, 1000f, 0f);
    private const RenderTextureFormat ALPHA_TEXTURE_FORMAT = RenderTextureFormat.Default;
    private const string BLOOM_ALPHA_SHADER_NAME = "Hidden/R2TBloomAlpha";
    private const string BLOOM_SHADER_NAME = "Hidden/R2TBloom";
    private const string BLUR_ALPHA_SHADER_NAME = "Hidden/R2TAlphaBlur";
    private const string BLUR_SHADER_NAME = "Hidden/R2TBlur";
    private Material m_AdditiveMaterial;
    private Shader m_AdditiveShader;
    private Material m_AlphaBlendMaterial;
    private Shader m_AlphaBlendShader;
    private Material m_AlphaBlurMaterial;
    private Shader m_AlphaBlurShader;
    private Camera m_AlphaCamera;
    private GameObject m_AlphaCameraGO;
    public float m_AlphaClip = 15f;
    public float m_AlphaClipAlphaIntensity = 1f;
    public Texture2D m_AlphaClipGradientMap;
    private Material m_AlphaClipGradientMaterial;
    private Shader m_AlphaClipGradientShader;
    public float m_AlphaClipIntensity = 1.5f;
    private Material m_AlphaClipMaterial;
    public AlphaClipShader m_AlphaClipRenderStyle;
    private Shader m_AlphaClipShader;
    public GameObject m_AlphaObjectToRender;
    private Vector3 m_AlphaObjectToRenderOffset = Vector3.zero;
    private RenderTexture m_AlphaRenderTexture;
    public float m_BloomAlphaIntensity = 1f;
    public BloomBlendType m_BloomBlend;
    public float m_BloomBlur = 0.3f;
    private Camera m_BloomCaptureCamera;
    private GameObject m_BloomCaptureCameraGO;
    private GameObject m_BloomCapturePlaneGameObject;
    public Color m_BloomColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    public float m_BloomIntensity;
    private Material m_BloomMaterial;
    private Material m_BloomMaterialAlpha;
    private GameObject m_BloomPlaneGameObject;
    private RenderTexture m_BloomRenderBuffer1;
    private RenderTexture m_BloomRenderBuffer2;
    private RenderTexture m_BloomRenderTexture;
    public BloomRenderType m_BloomRenderType;
    public float m_BloomResolutionRatio = 0.5f;
    private Shader m_BloomShader;
    private Shader m_BloomShaderAlpha;
    public float m_BloomThreshold = 0.7f;
    public bool m_BlurAlphaOnly;
    public float m_BlurAmount;
    private Material m_BlurMaterial;
    private Shader m_BlurShader;
    private Camera m_Camera;
    private GameObject m_CameraGO;
    public Color m_ClearColor = Color.clear;
    public bool m_CreateRenderPlane = true;
    public float m_FarClip = 0.5f;
    public float m_Height = 1f;
    public bool m_HideRenderObject = true;
    private bool m_init;
    private bool m_isDirty;
    public bool m_LateUpdate;
    public LayerMask m_LayerMask = -1;
    public Material m_Material;
    public float m_NearClip = -0.1f;
    public GameObject m_ObjectToRender;
    private Vector3 m_ObjectToRenderOffset = Vector3.zero;
    private Vector3 m_ObjectToRenderOrgPosition = Vector3.zero;
    private GameObject m_OffscreenGameObject;
    private Vector3 m_OffscreenPos;
    private float m_Offset;
    private Vector3 m_OriginalRenderPosition = Vector3.zero;
    private GameObject m_PlaneGameObject;
    public Vector3 m_PositionOffset = Vector3.zero;
    private RenderToTextureMaterial m_PreviousRenderMaterial;
    public bool m_RealtimeRender;
    public bool m_RealtimeTranslation;
    public RenderToTextureMaterial m_RenderMaterial;
    public bool m_RenderMeshAsAlpha;
    public bool m_RenderOnEnable = true;
    public bool m_RenderOnStart = true;
    public int m_RenderQueue;
    private RenderTexture m_RenderTexture;
    public RenderTextureFormat m_RenderTextureFormat = RenderTextureFormat.Default;
    public GameObject m_RenderToObject;
    public Shader m_ReplacmentShader;
    public string m_ReplacmentTag;
    public int m_Resolution = 0x80;
    public string m_ShaderTextureName = string.Empty;
    public Color m_TintColor = Color.white;
    private Material m_TransparentMaterial;
    private Shader m_TransparentShader;
    private Shader m_UnlitWhiteShader;
    public float m_Width = 1f;
    private float m_WorldHeight;
    private Vector3 m_WorldScale;
    private float m_WorldWidth;
    private const float OFFSET_DISTANCE = 100f;
    private readonly Vector3[] PLANE_NORMALS = new Vector3[] { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
    private readonly int[] PLANE_TRIANGLES = new int[] { 3, 1, 2, 2, 1, 0 };
    private readonly Vector2[] PLANE_UVS = new Vector2[] { new Vector2(0f, 0f), new Vector2(1f, 0f), new Vector2(0f, 1f), new Vector2(1f, 1f) };
    private const float RENDER_SIZE_QUALITY_HIGH = 1.5f;
    private const float RENDER_SIZE_QUALITY_LOW = 0.75f;
    private const float RENDER_SIZE_QUALITY_MEDIUM = 1f;
    private static float s_offset = -7000f;
    private const string TRANSPARENT_SHADER_NAME = "Hidden/R2TTransparent";
    private const string UNLIT_WHITE_SHADER_NAME = "Custom/Unlit/Color/White";

    private void AlphaCameraRender()
    {
        this.m_AlphaCamera.orthographicSize = this.OrthoSize();
        this.m_AlphaCamera.farClipPlane = this.m_FarClip * this.m_WorldScale.z;
        this.m_AlphaCamera.nearClipPlane = this.m_NearClip * this.m_WorldScale.z;
        if ((this.m_PlaneGameObject != null) && !this.m_HideRenderObject)
        {
            this.m_PlaneGameObject.renderer.enabled = false;
            if (this.m_BloomPlaneGameObject != null)
            {
                this.m_BloomPlaneGameObject.renderer.enabled = false;
            }
        }
        if (this.m_AlphaObjectToRender == null)
        {
            this.m_AlphaCamera.RenderWithShader(this.m_UnlitWhiteShader, this.m_ReplacmentTag);
        }
        else
        {
            this.m_AlphaCamera.Render();
        }
        if ((this.m_PlaneGameObject != null) && !this.m_HideRenderObject)
        {
            this.m_PlaneGameObject.renderer.enabled = true;
            if (this.m_BloomPlaneGameObject != null)
            {
                this.m_BloomPlaneGameObject.renderer.enabled = true;
            }
        }
    }

    private void Awake()
    {
        this.m_UnlitWhiteShader = Shader.Find("Custom/Unlit/Color/White");
        if (this.m_UnlitWhiteShader == null)
        {
            Debug.LogError("Failed to load RenderToTexture Shader: Custom/Unlit/Color/White");
        }
        float offset = this.Offset;
        this.m_OffscreenPos = new Vector3(offset, -7000f, offset);
    }

    private Vector2 CalcTextureSize()
    {
        Vector2 vector = new Vector2((float) this.m_Resolution, (float) this.m_Resolution);
        if (this.m_WorldWidth > this.m_WorldHeight)
        {
            vector.x = this.m_Resolution;
            vector.y = this.m_Resolution * (this.m_WorldHeight / this.m_WorldWidth);
            return vector;
        }
        vector.x = this.m_Resolution * (this.m_WorldWidth / this.m_WorldHeight);
        vector.y = this.m_Resolution;
        return vector;
    }

    private void CalcWorldWidthHeightScale()
    {
        Quaternion rotation = base.transform.rotation;
        Vector3 localScale = base.transform.localScale;
        Transform parent = base.transform.parent;
        base.transform.rotation = Quaternion.identity;
        bool flag = false;
        if (base.transform.lossyScale.magnitude == 0f)
        {
            base.transform.parent = null;
            base.transform.localScale = Vector3.one;
            flag = true;
        }
        this.m_WorldScale = base.transform.lossyScale;
        this.m_WorldWidth = this.m_Width * this.m_WorldScale.x;
        this.m_WorldHeight = this.m_Height * this.m_WorldScale.y;
        if (flag)
        {
            base.transform.parent = parent;
            base.transform.localScale = localScale;
        }
        base.transform.rotation = rotation;
        if ((this.m_WorldWidth == 0f) || (this.m_WorldHeight == 0f))
        {
            Debug.LogError(string.Format(" \"{0}\": RenderToTexture has a world scale of zero. \nm_WorldWidth: {1},   m_WorldHeight: {2}", this.m_WorldWidth, this.m_WorldHeight));
        }
    }

    private void CameraRender()
    {
        this.m_Camera.orthographicSize = this.OrthoSize();
        this.m_Camera.farClipPlane = this.m_FarClip * this.m_WorldScale.z;
        this.m_Camera.nearClipPlane = this.m_NearClip * this.m_WorldScale.z;
        if ((this.m_PlaneGameObject != null) && !this.m_HideRenderObject)
        {
            this.m_PlaneGameObject.renderer.enabled = false;
            if (this.m_BloomPlaneGameObject != null)
            {
                this.m_BloomPlaneGameObject.renderer.enabled = false;
            }
        }
        if (this.m_ReplacmentShader != null)
        {
            this.m_Camera.RenderWithShader(this.m_ReplacmentShader, this.m_ReplacmentTag);
        }
        else
        {
            this.m_Camera.Render();
        }
        if ((this.m_PlaneGameObject != null) && !this.m_HideRenderObject)
        {
            this.m_PlaneGameObject.renderer.enabled = true;
            if (this.m_BloomPlaneGameObject != null)
            {
                this.m_BloomPlaneGameObject.renderer.enabled = true;
            }
        }
    }

    private void CleanUp()
    {
        this.ReleaseTexture();
        if (this.m_CameraGO != null)
        {
            UnityEngine.Object.Destroy(this.m_CameraGO);
        }
        if (this.m_AlphaCameraGO != null)
        {
            UnityEngine.Object.Destroy(this.m_AlphaCameraGO);
        }
        if (this.m_PlaneGameObject != null)
        {
            UnityEngine.Object.Destroy(this.m_PlaneGameObject);
        }
        if (this.m_BloomPlaneGameObject != null)
        {
            UnityEngine.Object.Destroy(this.m_BloomPlaneGameObject);
        }
        if (this.m_BloomCaptureCameraGO != null)
        {
            UnityEngine.Object.Destroy(this.m_BloomCaptureCameraGO);
        }
        if (this.m_BloomCapturePlaneGameObject != null)
        {
            UnityEngine.Object.Destroy(this.m_BloomCapturePlaneGameObject);
        }
        if (this.m_OffscreenGameObject != null)
        {
            UnityEngine.Object.Destroy(this.m_OffscreenGameObject);
        }
        if (this.m_BlurMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_BlurMaterial);
        }
        if (this.m_AlphaBlurMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_AlphaBlurMaterial);
        }
        if (this.m_AlphaBlendMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_AlphaBlendMaterial);
        }
        if (this.m_ObjectToRender != null)
        {
            this.m_ObjectToRender.transform.localPosition = this.m_ObjectToRenderOrgPosition;
        }
        this.m_init = false;
        this.m_isDirty = true;
    }

    private void CreateAlphaCamera()
    {
        if (this.m_AlphaCamera == null)
        {
            this.m_AlphaCameraGO = new GameObject();
            this.m_AlphaCamera = this.m_AlphaCameraGO.AddComponent<Camera>();
            this.m_AlphaCameraGO.name = base.name + "_R2TAlphaRenderCamera";
            this.m_AlphaCameraGO.hideFlags = HideFlags.HideAndDontSave;
            this.m_AlphaCamera.CopyFrom(this.m_Camera);
            this.m_AlphaCamera.enabled = false;
            this.m_AlphaCamera.backgroundColor = Color.clear;
            this.m_AlphaCamera.DoClear();
            this.m_AlphaCameraGO.transform.parent = this.m_CameraGO.transform;
            if (this.m_AlphaObjectToRender != null)
            {
                this.m_AlphaCameraGO.transform.position = this.m_CameraGO.transform.position - this.ALPHA_OBJECT_OFFSET;
            }
            else
            {
                this.m_AlphaCameraGO.transform.position = this.m_CameraGO.transform.position;
            }
            this.m_AlphaCameraGO.transform.localRotation = Quaternion.identity;
        }
    }

    private void CreateBloomCaptureCamera()
    {
        if (this.m_BloomCaptureCamera == null)
        {
            this.m_BloomCaptureCameraGO = new GameObject();
            this.m_BloomCaptureCamera = this.m_BloomCaptureCameraGO.AddComponent<Camera>();
            this.m_BloomCaptureCameraGO.name = base.name + "_R2TBloomRenderCamera";
            this.m_BloomCaptureCameraGO.hideFlags = HideFlags.HideAndDontSave;
            this.m_BloomCaptureCamera.CopyFrom(this.m_Camera);
            this.m_BloomCaptureCamera.enabled = false;
            this.m_BloomCaptureCamera.nearClipPlane = -0.1f;
            this.m_BloomCaptureCamera.farClipPlane = 0.1f;
            this.m_BloomCaptureCamera.depth = this.m_Camera.depth + 1f;
            this.m_BloomCaptureCamera.backgroundColor = Color.clear;
            this.m_BloomCaptureCameraGO.transform.position = this.m_OffscreenPos + new Vector3(0f, 100f, 0f);
            this.m_BloomCaptureCameraGO.transform.rotation = Quaternion.identity;
            this.m_BloomCaptureCameraGO.transform.Rotate((float) 90f, 0f, (float) 0f);
        }
    }

    private void CreateBloomCapturePlane()
    {
        if (this.m_BloomCapturePlaneGameObject != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_BloomCapturePlaneGameObject);
        }
        Material additiveMaterial = this.AdditiveMaterial;
        if (this.m_BloomBlend == BloomBlendType.Transparent)
        {
            additiveMaterial = this.TransparentMaterial;
        }
        this.m_BloomCapturePlaneGameObject = this.CreateMeshPlane(string.Format("{0}_BloomCaptureRenderPlane", base.name), additiveMaterial);
        this.m_BloomCapturePlaneGameObject.transform.parent = this.m_BloomCaptureCameraGO.transform;
        this.m_BloomCapturePlaneGameObject.transform.localPosition = Vector3.zero;
        this.m_BloomCapturePlaneGameObject.transform.localRotation = Quaternion.identity;
        this.m_BloomCapturePlaneGameObject.transform.Rotate((float) -90f, 0f, (float) 0f);
        this.m_BloomCapturePlaneGameObject.transform.localScale = this.m_WorldScale;
        if (this.m_Material != null)
        {
            this.m_BloomCapturePlaneGameObject.renderer.sharedMaterial = this.m_PlaneGameObject.renderer.sharedMaterial;
        }
        if (this.m_RenderTexture != null)
        {
            this.m_BloomCapturePlaneGameObject.renderer.material.mainTexture = this.m_RenderTexture;
        }
        this.m_BloomCapturePlaneGameObject.hideFlags = HideFlags.HideAndDontSave;
    }

    private void CreateBloomPlane()
    {
        if (this.m_BloomPlaneGameObject != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_BloomPlaneGameObject);
        }
        Material additiveMaterial = this.AdditiveMaterial;
        if (this.m_BloomBlend == BloomBlendType.Transparent)
        {
            additiveMaterial = this.TransparentMaterial;
        }
        this.m_BloomPlaneGameObject = this.CreateMeshPlane(string.Format("{0}_BloomRenderPlane", base.name), additiveMaterial);
        this.m_BloomPlaneGameObject.transform.parent = this.m_PlaneGameObject.transform;
        this.m_BloomPlaneGameObject.transform.localPosition = new Vector3(0f, 0.08f, 0f);
        this.m_BloomPlaneGameObject.transform.localRotation = Quaternion.identity;
        this.m_BloomPlaneGameObject.transform.localScale = Vector3.one;
        this.m_BloomPlaneGameObject.renderer.sharedMaterial.color = this.m_BloomColor;
        this.m_BloomPlaneGameObject.hideFlags = HideFlags.HideAndDontSave;
    }

    private void CreateCamera()
    {
        if (this.m_Camera == null)
        {
            this.m_CameraGO = new GameObject();
            this.m_Camera = this.m_CameraGO.AddComponent<Camera>();
            this.m_CameraGO.name = base.name + "_R2TRenderCamera";
            this.m_CameraGO.hideFlags = HideFlags.HideAndDontSave;
            this.m_Camera.orthographic = true;
            if (this.m_HideRenderObject)
            {
                if (this.m_RealtimeTranslation)
                {
                    this.m_OffscreenGameObject.transform.position = base.transform.position;
                    this.m_CameraGO.transform.parent = this.m_OffscreenGameObject.transform;
                    this.m_CameraGO.transform.localPosition = Vector3.zero + this.m_PositionOffset;
                    this.m_CameraGO.transform.rotation = base.transform.rotation;
                    this.m_OffscreenGameObject.transform.position = this.m_OffscreenPos;
                }
                else
                {
                    this.m_CameraGO.transform.parent = null;
                    this.m_CameraGO.transform.position = this.m_OffscreenPos + this.m_PositionOffset;
                    this.m_CameraGO.transform.rotation = base.transform.rotation;
                }
            }
            else
            {
                this.m_CameraGO.transform.parent = base.transform;
                this.m_CameraGO.transform.position = base.transform.position + this.m_PositionOffset;
                this.m_CameraGO.transform.rotation = base.transform.rotation;
            }
            this.m_CameraGO.transform.Rotate((float) 90f, 0f, (float) 0f);
            if (this.m_FarClip < 0f)
            {
                this.m_FarClip = 0f;
            }
            if (this.m_NearClip > 0f)
            {
                this.m_NearClip = 0f;
            }
            this.m_Camera.nearClipPlane = this.m_NearClip * this.m_WorldScale.y;
            this.m_Camera.farClipPlane = this.m_FarClip * this.m_WorldScale.y;
            Camera mainCamera = Camera.mainCamera;
            if (mainCamera != null)
            {
                this.m_Camera.depth = mainCamera.depth - 2f;
            }
            this.m_Camera.clearFlags = CameraClearFlags.Color;
            this.m_Camera.backgroundColor = this.m_ClearColor;
            this.m_Camera.depthTextureMode = DepthTextureMode.None;
            this.m_Camera.renderingPath = RenderingPath.Forward;
            this.m_Camera.cullingMask = (int) this.m_LayerMask;
            this.m_Camera.targetTexture = this.m_RenderTexture;
            this.m_Camera.enabled = false;
        }
    }

    private GameObject CreateMeshPlane(string name, Material material)
    {
        GameObject obj2 = new GameObject {
            name = name
        };
        obj2.transform.parent = base.transform;
        obj2.transform.localPosition = this.m_PositionOffset;
        obj2.transform.localRotation = Quaternion.identity;
        obj2.transform.localScale = Vector3.one;
        obj2.AddComponent<MeshFilter>();
        obj2.AddComponent<MeshRenderer>();
        Mesh mesh = new Mesh();
        float x = this.m_Width * 0.5f;
        float z = this.m_Height * 0.5f;
        mesh.vertices = new Vector3[] { new Vector3(-x, 0f, -z), new Vector3(x, 0f, -z), new Vector3(-x, 0f, z), new Vector3(x, 0f, z) };
        mesh.uv = this.PLANE_UVS;
        mesh.normals = this.PLANE_NORMALS;
        mesh.triangles = this.PLANE_TRIANGLES;
        Mesh mesh3 = mesh;
        obj2.GetComponent<MeshFilter>().mesh = mesh3;
        mesh3.RecalculateBounds();
        if (material != null)
        {
            obj2.renderer.material = material;
        }
        Material material1 = obj2.renderer.material;
        material1.renderQueue += this.m_RenderQueue;
        return obj2;
    }

    private void CreateRenderPlane()
    {
        if (this.m_PlaneGameObject != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_PlaneGameObject);
        }
        this.m_PlaneGameObject = this.CreateMeshPlane(string.Format("{0}_RenderPlane", base.name), this.m_Material);
        this.m_PlaneGameObject.hideFlags = HideFlags.DontSave;
    }

    private void CreateTexture()
    {
        if (this.m_RenderTexture == null)
        {
            Vector2 vector = this.CalcTextureSize();
            GraphicsManager manager = GraphicsManager.Get();
            if (manager != null)
            {
                if (manager.RenderQualityLevel == GraphicsQuality.Low)
                {
                    vector = (Vector2) (vector * 0.75f);
                }
                else if (manager.RenderQualityLevel == GraphicsQuality.Medium)
                {
                    vector = (Vector2) (vector * 1f);
                }
                else if (manager.RenderQualityLevel == GraphicsQuality.High)
                {
                    vector = (Vector2) (vector * 1.5f);
                }
            }
            this.m_RenderTexture = new RenderTexture((int) vector.x, (int) vector.y, 0x20, this.m_RenderTextureFormat);
            this.m_RenderTexture.hideFlags = HideFlags.HideAndDontSave;
            this.m_RenderTexture.Create();
            if (this.m_RenderMeshAsAlpha)
            {
                this.m_AlphaRenderTexture = new RenderTexture((int) vector.x, (int) vector.y, 0x20, this.m_RenderTextureFormat);
                this.m_AlphaRenderTexture.hideFlags = HideFlags.HideAndDontSave;
                this.m_AlphaRenderTexture.Create();
            }
            if (this.m_Camera != null)
            {
                this.m_Camera.targetTexture = this.m_RenderTexture;
            }
            if (this.m_AlphaCamera != null)
            {
                this.m_AlphaCamera.targetTexture = this.m_AlphaRenderTexture;
            }
        }
    }

    public void ForceTextureRebuild()
    {
        if (base.enabled)
        {
            this.ReleaseTexture();
            this.m_isDirty = true;
            this.RenderTex();
        }
    }

    public Material GetRenderMaterial()
    {
        if (this.m_RenderToObject != null)
        {
            return this.m_RenderToObject.renderer.material;
        }
        if (this.m_PlaneGameObject != null)
        {
            return this.m_PlaneGameObject.renderer.material;
        }
        return this.m_Material;
    }

    public RenderTexture GetRenderTexture()
    {
        return this.m_RenderTexture;
    }

    public GameObject GetRenderToObject()
    {
        if (this.m_RenderToObject != null)
        {
            return this.m_RenderToObject;
        }
        if (this.m_PlaneGameObject != null)
        {
            return this.m_PlaneGameObject;
        }
        return this.m_PlaneGameObject;
    }

    public void Hide()
    {
        if (this.m_RenderToObject != null)
        {
            this.m_RenderToObject.renderer.enabled = false;
        }
        else if (this.m_PlaneGameObject != null)
        {
            this.m_PlaneGameObject.renderer.enabled = false;
            if (this.m_BloomPlaneGameObject != null)
            {
                this.m_BloomPlaneGameObject.renderer.enabled = false;
            }
        }
    }

    private void Init()
    {
        if (!this.m_init)
        {
            if (this.m_RealtimeTranslation)
            {
                this.m_OffscreenGameObject = new GameObject();
                this.m_OffscreenGameObject.name = string.Format("R2TOffsetRenderRoot_{0}", base.name);
                this.m_OffscreenGameObject.transform.position = base.transform.position;
            }
            if (this.m_ObjectToRender != null)
            {
                this.m_ObjectToRenderOrgPosition = this.m_ObjectToRender.transform.localPosition;
                if (this.m_HideRenderObject)
                {
                    if (this.m_RealtimeTranslation)
                    {
                        this.m_ObjectToRender.transform.parent = this.m_OffscreenGameObject.transform;
                        if (this.m_AlphaObjectToRender != null)
                        {
                            this.m_AlphaObjectToRender.transform.parent = this.m_OffscreenGameObject.transform;
                        }
                    }
                    if (this.m_RenderToObject != null)
                    {
                        this.m_OriginalRenderPosition = this.m_RenderToObject.transform.position;
                    }
                    else
                    {
                        this.m_OriginalRenderPosition = base.transform.position;
                    }
                    if (this.m_ObjectToRender != null)
                    {
                        this.m_ObjectToRenderOffset = base.transform.position - this.m_ObjectToRender.transform.position;
                    }
                    if (this.m_AlphaObjectToRender != null)
                    {
                        this.m_AlphaObjectToRenderOffset = base.transform.position - this.m_AlphaObjectToRender.transform.position;
                    }
                }
            }
            else
            {
                this.m_ObjectToRenderOrgPosition = base.transform.localPosition;
            }
            if (this.m_HideRenderObject)
            {
                if (this.m_RealtimeTranslation)
                {
                    this.m_OffscreenGameObject.transform.position = this.m_OffscreenPos;
                }
                else if (this.m_ObjectToRender != null)
                {
                    this.m_ObjectToRender.transform.position = this.m_OffscreenPos;
                }
                else
                {
                    base.transform.position = this.m_OffscreenPos;
                }
            }
            if (this.m_ObjectToRender == null)
            {
                this.m_ObjectToRender = base.gameObject;
            }
            this.CalcWorldWidthHeightScale();
            this.CreateTexture();
            this.CreateCamera();
            if (this.m_RenderMeshAsAlpha || (this.m_AlphaObjectToRender != null))
            {
                this.CreateAlphaCamera();
            }
            if ((this.m_RenderToObject == null) && this.m_CreateRenderPlane)
            {
                this.CreateRenderPlane();
            }
            if (this.m_RenderToObject != null)
            {
                Material material = this.m_RenderToObject.renderer.material;
                material.renderQueue += this.m_RenderQueue;
            }
            this.SetupMaterial();
            this.m_init = true;
        }
    }

    private void LateUpdate()
    {
        if (this.m_LateUpdate)
        {
            if (this.m_HideRenderObject && (this.m_ObjectToRender != null))
            {
                this.PositionHiddenObjectsAndCameras();
            }
            if (this.m_RealtimeRender || this.m_isDirty)
            {
                this.RenderTex();
            }
            this.m_RenderTexture.DiscardContents();
        }
    }

    private void OnDestroy()
    {
        this.CleanUp();
    }

    private void OnDisable()
    {
        this.RestoreAfterRender();
        if (this.m_ObjectToRender != null)
        {
            this.m_ObjectToRender.transform.localPosition = this.m_ObjectToRenderOrgPosition;
        }
        if (this.m_PlaneGameObject != null)
        {
            UnityEngine.Object.Destroy(this.m_PlaneGameObject);
        }
        if (this.m_BloomPlaneGameObject != null)
        {
            UnityEngine.Object.Destroy(this.m_BloomPlaneGameObject);
        }
        if (this.m_BloomCapturePlaneGameObject != null)
        {
            UnityEngine.Object.Destroy(this.m_BloomCapturePlaneGameObject);
        }
        if (this.m_BloomCaptureCameraGO != null)
        {
            UnityEngine.Object.Destroy(this.m_BloomCaptureCameraGO);
        }
        this.ReleaseTexture();
        if (this.m_Camera != null)
        {
            this.m_Camera.enabled = false;
        }
        if (this.m_AlphaCamera != null)
        {
            this.m_AlphaCamera.enabled = false;
        }
        this.m_init = false;
        this.m_isDirty = true;
    }

    private void OnDrawGizmos()
    {
        if (base.enabled)
        {
            if (this.m_FarClip < 0f)
            {
                this.m_FarClip = 0f;
            }
            if (this.m_NearClip > 0f)
            {
                this.m_NearClip = 0f;
            }
            Gizmos.matrix = base.transform.localToWorldMatrix;
            Vector3 vector = new Vector3(0f, -this.m_NearClip * 0.5f, 0f);
            Gizmos.color = new Color(0.1f, 0.5f, 0.7f, 0.8f);
            Gizmos.DrawWireCube(vector + this.m_PositionOffset, new Vector3(this.m_Width, -this.m_NearClip, this.m_Height));
            Gizmos.color = new Color(0.2f, 0.2f, 0.9f, 0.8f);
            Vector3 vector2 = new Vector3(0f, -this.m_FarClip * 0.5f, 0f);
            Gizmos.DrawWireCube(vector2 + this.m_PositionOffset, new Vector3(this.m_Width, -this.m_FarClip, this.m_Height));
            Gizmos.color = new Color(0.8f, 0.8f, 1f, 1f);
            Gizmos.DrawWireCube(this.m_PositionOffset, new Vector3(this.m_Width, 0f, this.m_Height));
            Gizmos.matrix = Matrix4x4.identity;
        }
    }

    private void OnEnable()
    {
        if (this.m_RenderOnEnable)
        {
            this.RenderTex();
        }
    }

    private float OrthoSize()
    {
        if (this.m_WorldWidth > this.m_WorldHeight)
        {
            return Mathf.Min((float) (this.m_WorldWidth * 0.5f), (float) (this.m_WorldHeight * 0.5f));
        }
        return (this.m_WorldHeight * 0.5f);
    }

    private void PositionHiddenObjectsAndCameras()
    {
        Vector3 zero = Vector3.zero;
        if (this.m_RenderToObject != null)
        {
            zero = this.m_RenderToObject.transform.position - this.m_OriginalRenderPosition;
        }
        else
        {
            zero = base.transform.position - this.m_OriginalRenderPosition;
        }
        if (this.m_RealtimeTranslation)
        {
            this.m_OffscreenGameObject.transform.position = this.m_OffscreenPos + zero;
            this.m_OffscreenGameObject.transform.rotation = base.transform.rotation;
            if (this.m_AlphaObjectToRender != null)
            {
                this.m_AlphaObjectToRender.transform.position = ((this.m_OffscreenPos - this.ALPHA_OBJECT_OFFSET) - this.m_AlphaObjectToRenderOffset) + zero;
                this.m_AlphaObjectToRender.transform.rotation = base.transform.rotation;
            }
        }
        else
        {
            if (this.m_ObjectToRender != null)
            {
                this.m_ObjectToRender.transform.rotation = Quaternion.identity;
                this.m_ObjectToRender.transform.position = this.m_OffscreenPos - this.m_ObjectToRenderOffset;
                this.m_ObjectToRender.transform.rotation = base.transform.rotation;
            }
            if (this.m_AlphaObjectToRender != null)
            {
                this.m_AlphaObjectToRender.transform.position = (this.m_OffscreenPos - this.ALPHA_OBJECT_OFFSET) - this.m_AlphaObjectToRenderOffset;
                this.m_AlphaObjectToRender.transform.rotation = base.transform.rotation;
            }
            this.m_CameraGO.transform.rotation = Quaternion.identity;
            this.m_CameraGO.transform.position = this.m_OffscreenPos + this.m_PositionOffset;
            this.m_CameraGO.transform.rotation = this.m_ObjectToRender.transform.rotation;
            this.m_CameraGO.transform.Rotate((float) 90f, 0f, (float) 0f);
        }
    }

    private void ReleaseTexture()
    {
        if (RenderTexture.active == this.m_RenderTexture)
        {
            RenderTexture.active = null;
        }
        if (RenderTexture.active == this.m_AlphaRenderTexture)
        {
            RenderTexture.active = null;
        }
        if (RenderTexture.active == this.m_BloomRenderTexture)
        {
            RenderTexture.active = null;
        }
        if (this.m_RenderTexture != null)
        {
            if (this.m_Camera != null)
            {
                this.m_Camera.targetTexture = null;
            }
            UnityEngine.Object.Destroy(this.m_RenderTexture);
            this.m_RenderTexture = null;
        }
        if (this.m_AlphaRenderTexture != null)
        {
            if (this.m_AlphaCamera != null)
            {
                this.m_AlphaCamera.targetTexture = null;
            }
            UnityEngine.Object.Destroy(this.m_AlphaRenderTexture);
            this.m_AlphaRenderTexture = null;
        }
        if (this.m_BloomRenderTexture != null)
        {
            UnityEngine.Object.Destroy(this.m_BloomRenderTexture);
            this.m_BloomRenderTexture = null;
        }
        if (this.m_BloomRenderBuffer1 != null)
        {
            UnityEngine.Object.Destroy(this.m_BloomRenderBuffer1);
            this.m_BloomRenderBuffer1 = null;
        }
        if (this.m_BloomRenderBuffer2 != null)
        {
            UnityEngine.Object.Destroy(this.m_BloomRenderBuffer2);
        }
        this.m_BloomRenderBuffer2 = null;
    }

    public RenderTexture Render()
    {
        this.m_isDirty = true;
        return this.m_RenderTexture;
    }

    private void RenderBloom()
    {
        if (this.m_BloomIntensity == 0f)
        {
            if (this.m_BloomPlaneGameObject != null)
            {
                UnityEngine.Object.DestroyImmediate(this.m_BloomPlaneGameObject);
            }
        }
        else if (this.m_BloomIntensity == 0f)
        {
            if (this.m_BloomPlaneGameObject != null)
            {
                UnityEngine.Object.DestroyImmediate(this.m_BloomPlaneGameObject);
            }
        }
        else
        {
            int width = (int) (this.m_RenderTexture.width * Mathf.Clamp01(this.m_BloomResolutionRatio));
            int height = (int) (this.m_RenderTexture.height * Mathf.Clamp01(this.m_BloomResolutionRatio));
            RenderTexture renderTexture = this.m_RenderTexture;
            if (this.m_RenderMaterial == RenderToTextureMaterial.AlphaClipBloom)
            {
                if (this.m_BloomPlaneGameObject == null)
                {
                    this.CreateBloomPlane();
                }
                if (this.m_BloomRenderTexture == null)
                {
                    this.m_BloomRenderTexture = new RenderTexture(width, height, 0x20, RenderTextureFormat.ARGB32);
                }
            }
            if (this.m_BloomRenderBuffer1 == null)
            {
                this.m_BloomRenderBuffer1 = new RenderTexture(width, height, 0x20, RenderTextureFormat.ARGB32);
            }
            if (this.m_BloomRenderBuffer2 == null)
            {
                this.m_BloomRenderBuffer2 = new RenderTexture(width, height, 0x20, RenderTextureFormat.ARGB32);
            }
            if (this.m_BloomRenderTexture != null)
            {
                this.m_BloomRenderTexture.hideFlags = HideFlags.HideAndDontSave;
            }
            this.m_BloomRenderBuffer1.hideFlags = HideFlags.HideAndDontSave;
            this.m_BloomRenderBuffer2.hideFlags = HideFlags.HideAndDontSave;
            if (this.m_RenderMaterial == RenderToTextureMaterial.AlphaClipBloom)
            {
                renderTexture = this.m_BloomRenderTexture;
                if (this.m_BloomCaptureCameraGO == null)
                {
                    this.CreateBloomCaptureCamera();
                }
                if (this.m_BloomCapturePlaneGameObject == null)
                {
                    this.CreateBloomCapturePlane();
                }
                this.m_BloomCapturePlaneGameObject.renderer.material.mainTexture = this.m_RenderTexture;
                this.m_BloomCaptureCamera.targetTexture = this.m_BloomRenderTexture;
                this.m_BloomCaptureCamera.Render();
            }
            Material bloomMaterial = this.BloomMaterial;
            if (this.m_BloomRenderType == BloomRenderType.Alpha)
            {
                bloomMaterial = this.BloomMaterialAlpha;
                bloomMaterial.SetFloat("_AlphaIntensity", this.m_BloomAlphaIntensity);
            }
            float num3 = 1f / ((float) width);
            float num4 = 1f / ((float) height);
            bloomMaterial.SetFloat("_Threshold", this.m_BloomThreshold);
            bloomMaterial.SetFloat("_Intensity", this.m_BloomIntensity / (1f - this.m_BloomThreshold));
            bloomMaterial.SetVector("_OffsetA", new Vector4(1.5f * num3, 1.5f * num4, -1.5f * num3, 1.5f * num4));
            bloomMaterial.SetVector("_OffsetB", new Vector4(-1.5f * num3, -1.5f * num4, 1.5f * num3, -1.5f * num4));
            Graphics.Blit(renderTexture, this.m_BloomRenderBuffer2, bloomMaterial, 1);
            num3 *= 4f * this.m_BloomBlur;
            num4 *= 4f * this.m_BloomBlur;
            bloomMaterial.SetVector("_OffsetA", new Vector4(1.5f * num3, 0f, -1.5f * num3, 0f));
            bloomMaterial.SetVector("_OffsetB", new Vector4(0.5f * num3, 0f, -0.5f * num3, 0f));
            Graphics.Blit(this.m_BloomRenderBuffer2, this.m_BloomRenderBuffer1, bloomMaterial, 2);
            bloomMaterial.SetVector("_OffsetA", new Vector4(0f, 1.5f * num4, 0f, -1.5f * num4));
            bloomMaterial.SetVector("_OffsetB", new Vector4(0f, 0.5f * num4, 0f, -0.5f * num4));
            Graphics.Blit(this.m_BloomRenderBuffer1, renderTexture, bloomMaterial, 2);
            if (this.m_RenderMaterial == RenderToTextureMaterial.AlphaClipBloom)
            {
                this.m_BloomPlaneGameObject.renderer.material.color = this.m_BloomColor;
                this.m_BloomPlaneGameObject.renderer.material.mainTexture = renderTexture;
                if (this.m_PlaneGameObject != null)
                {
                    this.m_BloomPlaneGameObject.renderer.material.renderQueue = this.m_PlaneGameObject.renderer.material.renderQueue + 1;
                }
            }
            else if (this.m_RenderToObject != null)
            {
                this.m_RenderToObject.renderer.material.color = this.m_BloomColor;
                this.m_RenderToObject.renderer.material.mainTexture = renderTexture;
            }
            else
            {
                this.m_PlaneGameObject.renderer.material.color = this.m_BloomColor;
                this.m_PlaneGameObject.renderer.material.mainTexture = renderTexture;
            }
        }
    }

    public RenderTexture RenderNow()
    {
        this.RenderTex();
        return this.m_RenderTexture;
    }

    private void RenderTex()
    {
        this.Init();
        if (this.m_init)
        {
            this.SetupForRender();
            if (this.m_RenderMaterial != this.m_PreviousRenderMaterial)
            {
                this.SetupMaterial();
            }
            if (this.m_RenderMeshAsAlpha || (this.m_AlphaObjectToRender != null))
            {
                RenderTexture source = RenderTexture.GetTemporary(this.m_RenderTexture.width, this.m_RenderTexture.height, this.m_RenderTexture.depth, this.m_RenderTexture.format);
                this.m_Camera.targetTexture = source;
                this.CameraRender();
                RenderTexture texture = RenderTexture.GetTemporary(this.m_RenderTexture.width, this.m_RenderTexture.height, this.m_RenderTexture.depth, RenderTextureFormat.Default);
                this.m_AlphaCamera.targetTexture = texture;
                this.AlphaCameraRender();
                this.AlphaBlendMaterial.SetTexture("_AlphaTex", texture);
                if (this.m_BlurAmount > 0f)
                {
                    RenderTexture dest = RenderTexture.GetTemporary(this.m_RenderTexture.width, this.m_RenderTexture.height, this.m_RenderTexture.depth, this.m_RenderTexture.format);
                    Graphics.Blit(source, dest, this.AlphaBlendMaterial);
                    this.CameraRender();
                    Material blurMaterial = this.BlurMaterial;
                    if (this.m_BlurAlphaOnly)
                    {
                        blurMaterial = this.AlphaBlurMaterial;
                    }
                    this.Sample(dest, this.m_RenderTexture, blurMaterial, this.m_BlurAmount);
                    RenderTexture.ReleaseTemporary(dest);
                }
                else
                {
                    Graphics.Blit(source, this.m_RenderTexture, this.AlphaBlendMaterial);
                }
                RenderTexture.ReleaseTemporary(source);
                RenderTexture.ReleaseTemporary(texture);
            }
            else if (this.m_BlurAmount > 0f)
            {
                RenderTexture texture4 = RenderTexture.GetTemporary(this.m_RenderTexture.width, this.m_RenderTexture.height, this.m_RenderTexture.depth, this.m_RenderTexture.format);
                this.m_Camera.targetTexture = texture4;
                this.CameraRender();
                Material sampleMat = this.BlurMaterial;
                if (this.m_BlurAlphaOnly)
                {
                    sampleMat = this.m_AlphaBlurMaterial;
                }
                this.Sample(texture4, this.m_RenderTexture, sampleMat, this.m_BlurAmount);
                RenderTexture.ReleaseTemporary(texture4);
            }
            else
            {
                this.m_Camera.targetTexture = this.m_RenderTexture;
                this.CameraRender();
            }
            if (this.m_RenderToObject != null)
            {
                UnityEngine.Renderer componentInChildren = this.m_RenderToObject.renderer;
                if (componentInChildren == null)
                {
                    componentInChildren = this.m_RenderToObject.GetComponentInChildren<UnityEngine.Renderer>();
                }
                if (this.m_ShaderTextureName != string.Empty)
                {
                    componentInChildren.material.SetTexture(this.m_ShaderTextureName, this.m_RenderTexture);
                }
                else
                {
                    componentInChildren.material.mainTexture = this.m_RenderTexture;
                }
            }
            else if (this.m_PlaneGameObject != null)
            {
                if (this.m_ShaderTextureName != string.Empty)
                {
                    this.m_PlaneGameObject.renderer.material.SetTexture(this.m_ShaderTextureName, this.m_RenderTexture);
                }
                else
                {
                    this.m_PlaneGameObject.renderer.material.mainTexture = this.m_RenderTexture;
                }
            }
            if ((this.m_RenderMaterial == RenderToTextureMaterial.AlphaClip) || (this.m_RenderMaterial == RenderToTextureMaterial.AlphaClipBloom))
            {
                GameObject planeGameObject = this.m_PlaneGameObject;
                if (this.m_RenderToObject != null)
                {
                    planeGameObject = this.m_RenderToObject;
                }
                Material sharedMaterial = planeGameObject.renderer.sharedMaterial;
                sharedMaterial.SetFloat("_Cutoff", this.m_AlphaClip);
                sharedMaterial.SetFloat("_Intensity", this.m_AlphaClipIntensity);
                sharedMaterial.SetFloat("_AlphaIntensity", this.m_AlphaClipAlphaIntensity);
                if (this.m_AlphaClipRenderStyle == AlphaClipShader.ColorGradient)
                {
                    sharedMaterial.SetTexture("_GradientTex", this.m_AlphaClipGradientMap);
                }
            }
            if ((this.m_RenderMaterial == RenderToTextureMaterial.AlphaClipBloom) || (this.m_RenderMaterial == RenderToTextureMaterial.Bloom))
            {
                this.RenderBloom();
            }
            else if (this.m_BloomPlaneGameObject != null)
            {
                UnityEngine.Object.DestroyImmediate(this.m_BloomPlaneGameObject);
            }
            if (!this.m_RealtimeRender)
            {
                this.RestoreAfterRender();
            }
            this.m_isDirty = false;
        }
    }

    private void RestoreAfterRender()
    {
        if (!this.m_HideRenderObject)
        {
            if (this.m_ObjectToRender != null)
            {
                this.m_ObjectToRender.transform.localPosition = this.m_ObjectToRenderOrgPosition;
            }
            else
            {
                base.transform.localPosition = this.m_ObjectToRenderOrgPosition;
            }
        }
    }

    private void Sample(RenderTexture source, RenderTexture dest, Material sampleMat, float offset)
    {
        Vector2[] offsets = new Vector2[] { new Vector2(-offset, -offset), new Vector2(-offset, offset), new Vector2(offset, offset), new Vector2(offset, -offset) };
        Graphics.BlitMultiTap(source, dest, sampleMat, offsets);
    }

    private void SetupForRender()
    {
        this.CalcWorldWidthHeightScale();
        if (this.m_RenderTexture == null)
        {
            this.CreateTexture();
        }
        if (this.m_HideRenderObject)
        {
            if (this.m_PlaneGameObject != null)
            {
                this.m_PlaneGameObject.transform.localPosition = this.m_PositionOffset;
                this.m_PlaneGameObject.layer = base.gameObject.layer;
            }
            this.m_Camera.backgroundColor = this.m_ClearColor;
        }
    }

    private void SetupMaterial()
    {
        Material alphaClipMaterial;
        GameObject planeGameObject = this.m_PlaneGameObject;
        if (this.m_RenderToObject != null)
        {
            planeGameObject = this.m_RenderToObject;
            if (this.m_RenderMaterial == RenderToTextureMaterial.Custom)
            {
                return;
            }
        }
        if (planeGameObject == null)
        {
            return;
        }
        switch (this.m_RenderMaterial)
        {
            case RenderToTextureMaterial.Transparent:
                planeGameObject.renderer.sharedMaterial = this.TransparentMaterial;
                goto Label_01F3;

            case RenderToTextureMaterial.Additive:
                planeGameObject.renderer.sharedMaterial = this.AdditiveMaterial;
                goto Label_01F3;

            case RenderToTextureMaterial.Bloom:
                if (this.m_BloomBlend != BloomBlendType.Additive)
                {
                    if (this.m_BloomBlend == BloomBlendType.Transparent)
                    {
                        planeGameObject.renderer.sharedMaterial = this.TransparentMaterial;
                    }
                }
                else
                {
                    planeGameObject.renderer.sharedMaterial = this.AdditiveMaterial;
                }
                goto Label_01F3;

            case RenderToTextureMaterial.AlphaClip:
                if (this.m_AlphaClipRenderStyle != AlphaClipShader.Standard)
                {
                    alphaClipMaterial = this.AlphaClipGradientMaterial;
                    break;
                }
                alphaClipMaterial = this.AlphaClipMaterial;
                break;

            case RenderToTextureMaterial.AlphaClipBloom:
                Material alphaClipGradientMaterial;
                if (this.m_AlphaClipRenderStyle != AlphaClipShader.Standard)
                {
                    alphaClipGradientMaterial = this.AlphaClipGradientMaterial;
                }
                else
                {
                    alphaClipGradientMaterial = this.AlphaClipMaterial;
                }
                planeGameObject.renderer.sharedMaterial = alphaClipGradientMaterial;
                alphaClipGradientMaterial.SetFloat("_Cutoff", this.m_AlphaClip);
                alphaClipGradientMaterial.SetFloat("_Intensity", this.m_AlphaClipIntensity);
                alphaClipGradientMaterial.SetFloat("_AlphaIntensity", this.m_AlphaClipAlphaIntensity);
                if (this.m_AlphaClipRenderStyle == AlphaClipShader.ColorGradient)
                {
                    alphaClipGradientMaterial.SetTexture("_GradientTex", this.m_AlphaClipGradientMap);
                }
                goto Label_01F3;

            default:
                if (this.m_Material != null)
                {
                    planeGameObject.renderer.material = this.m_Material;
                }
                goto Label_01F3;
        }
        planeGameObject.renderer.sharedMaterial = alphaClipMaterial;
        alphaClipMaterial.SetFloat("_Cutoff", this.m_AlphaClip);
        alphaClipMaterial.SetFloat("_Intensity", this.m_AlphaClipIntensity);
        alphaClipMaterial.SetFloat("_AlphaIntensity", this.m_AlphaClipAlphaIntensity);
        if (this.m_AlphaClipRenderStyle == AlphaClipShader.ColorGradient)
        {
            alphaClipMaterial.SetTexture("_GradientTex", this.m_AlphaClipGradientMap);
        }
    Label_01F3:
        if (planeGameObject.renderer.material != null)
        {
            Material material = planeGameObject.renderer.material;
            material.color *= this.m_TintColor;
        }
        if ((this.m_BloomIntensity > 0f) && (this.m_BloomPlaneGameObject != null))
        {
            this.m_BloomPlaneGameObject.renderer.sharedMaterial.color = this.m_BloomColor;
        }
        planeGameObject.renderer.material.renderQueue = planeGameObject.renderer.material.shader.renderQueue + this.m_RenderQueue;
        if (this.m_BloomPlaneGameObject != null)
        {
            this.m_BloomPlaneGameObject.renderer.material.renderQueue = (this.m_BloomPlaneGameObject.renderer.material.shader.renderQueue + this.m_RenderQueue) + 1;
        }
        this.m_PreviousRenderMaterial = this.m_RenderMaterial;
    }

    public void Show()
    {
        this.Show(false);
    }

    public void Show(bool render)
    {
        if (this.m_RenderToObject != null)
        {
            this.m_RenderToObject.renderer.enabled = true;
        }
        else if (this.m_PlaneGameObject != null)
        {
            this.m_PlaneGameObject.renderer.enabled = true;
            if (this.m_BloomPlaneGameObject != null)
            {
                this.m_BloomPlaneGameObject.renderer.enabled = true;
            }
        }
        if (render)
        {
            this.Render();
        }
    }

    private void Start()
    {
        if (this.m_RenderOnStart)
        {
            this.m_isDirty = true;
        }
        this.Init();
    }

    private void Update()
    {
        if ((this.m_RenderTexture != null) && !this.m_RenderTexture.IsCreated())
        {
            Log.Kyle.Print("RenderToTexture Texture lost. Render Called");
            this.m_isDirty = true;
            this.RenderTex();
        }
        else if (!this.m_LateUpdate)
        {
            if (this.m_HideRenderObject && (this.m_ObjectToRender != null))
            {
                this.PositionHiddenObjectsAndCameras();
            }
            if (this.m_RealtimeRender || this.m_isDirty)
            {
                this.RenderTex();
            }
        }
    }

    protected Material AdditiveMaterial
    {
        get
        {
            if (this.m_AdditiveMaterial == null)
            {
                if (this.m_AdditiveShader == null)
                {
                    this.m_AdditiveShader = Shader.Find("Hidden/R2TAdditive");
                    if (this.m_AdditiveShader == null)
                    {
                        Debug.LogError("Failed to load RenderToTexture Shader: Hidden/R2TAdditive");
                    }
                }
                this.m_AdditiveMaterial = new Material(this.m_AdditiveShader);
                this.m_AdditiveMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_AdditiveMaterial;
        }
    }

    protected Material AlphaBlendMaterial
    {
        get
        {
            if (this.m_AlphaBlendMaterial == null)
            {
                if (this.m_AlphaBlendShader == null)
                {
                    this.m_AlphaBlendShader = Shader.Find("Hidden/R2TColorAlphaCombine");
                    if (this.m_AlphaBlendShader == null)
                    {
                        Debug.LogError("Failed to load RenderToTexture Shader: Hidden/R2TColorAlphaCombine");
                    }
                }
                this.m_AlphaBlendMaterial = new Material(this.m_AlphaBlendShader);
                this.m_AlphaBlendMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_AlphaBlendMaterial;
        }
    }

    protected Material AlphaBlurMaterial
    {
        get
        {
            if (this.m_AlphaBlurMaterial == null)
            {
                if (this.m_AlphaBlurShader == null)
                {
                    this.m_AlphaBlurShader = Shader.Find("Hidden/R2TAlphaBlur");
                    if (this.m_AlphaBlurShader == null)
                    {
                        Debug.LogError("Failed to load RenderToTexture Shader: Hidden/R2TAlphaBlur");
                    }
                }
                this.m_AlphaBlurMaterial = new Material(this.m_AlphaBlurShader);
                this.m_AlphaBlurMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_AlphaBlurMaterial;
        }
    }

    protected Material AlphaClipGradientMaterial
    {
        get
        {
            if (this.m_AlphaClipGradientMaterial == null)
            {
                if (this.m_AlphaClipGradientShader == null)
                {
                    this.m_AlphaClipGradientShader = Shader.Find("Hidden/R2TAlphaClipGradient");
                    if (this.m_AlphaClipGradientShader == null)
                    {
                        Debug.LogError("Failed to load RenderToTexture Shader: Hidden/R2TAlphaClipGradient");
                    }
                }
                this.m_AlphaClipGradientMaterial = new Material(this.m_AlphaClipGradientShader);
                this.m_AlphaClipGradientMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_AlphaClipGradientMaterial;
        }
    }

    protected Material AlphaClipMaterial
    {
        get
        {
            if (this.m_AlphaClipMaterial == null)
            {
                if (this.m_AlphaClipShader == null)
                {
                    this.m_AlphaClipShader = Shader.Find("Hidden/R2TAlphaClip");
                    if (this.m_AlphaClipShader == null)
                    {
                        Debug.LogError("Failed to load RenderToTexture Shader: Hidden/R2TAlphaClip");
                    }
                }
                this.m_AlphaClipMaterial = new Material(this.m_AlphaClipShader);
                this.m_AlphaClipMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_AlphaClipMaterial;
        }
    }

    protected Material BloomMaterial
    {
        get
        {
            if (this.m_BloomMaterial == null)
            {
                if (this.m_BloomShader == null)
                {
                    this.m_BloomShader = Shader.Find("Hidden/R2TBloom");
                    if (this.m_BloomShader == null)
                    {
                        Debug.LogError("Failed to load RenderToTexture Shader: Hidden/R2TBloom");
                    }
                }
                this.m_BloomMaterial = new Material(this.m_BloomShader);
                this.m_BloomMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_BloomMaterial;
        }
    }

    protected Material BloomMaterialAlpha
    {
        get
        {
            if (this.m_BloomMaterialAlpha == null)
            {
                if (this.m_BloomShaderAlpha == null)
                {
                    this.m_BloomShaderAlpha = Shader.Find("Hidden/R2TBloomAlpha");
                    if (this.m_BloomShaderAlpha == null)
                    {
                        Debug.LogError("Failed to load RenderToTexture Shader: Hidden/R2TBloomAlpha");
                    }
                }
                this.m_BloomMaterialAlpha = new Material(this.m_BloomShaderAlpha);
                this.m_BloomMaterialAlpha.hideFlags = HideFlags.DontSave;
            }
            return this.m_BloomMaterialAlpha;
        }
    }

    protected Material BlurMaterial
    {
        get
        {
            if (this.m_BlurMaterial == null)
            {
                if (this.m_BlurShader == null)
                {
                    this.m_BlurShader = Shader.Find("Hidden/R2TBlur");
                    if (this.m_BlurShader == null)
                    {
                        Debug.LogError("Failed to load RenderToTexture Shader: Hidden/R2TBlur");
                    }
                }
                this.m_BlurMaterial = new Material(this.m_BlurShader);
                this.m_BlurMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_BlurMaterial;
        }
    }

    protected float Offset
    {
        get
        {
            if (this.m_Offset == 0f)
            {
                s_offset -= 100f;
                this.m_Offset = s_offset;
            }
            return this.m_Offset;
        }
    }

    protected Material TransparentMaterial
    {
        get
        {
            if (this.m_TransparentMaterial == null)
            {
                if (this.m_TransparentShader == null)
                {
                    this.m_TransparentShader = Shader.Find("Hidden/R2TTransparent");
                    if (this.m_TransparentShader == null)
                    {
                        Debug.LogError("Failed to load RenderToTexture Shader: Hidden/R2TTransparent");
                    }
                }
                this.m_TransparentMaterial = new Material(this.m_TransparentShader);
                this.m_TransparentMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_TransparentMaterial;
        }
    }

    public enum AlphaClipShader
    {
        Standard,
        ColorGradient
    }

    public enum BloomBlendType
    {
        Additive,
        Transparent
    }

    public enum BloomRenderType
    {
        Color,
        Alpha
    }

    public enum RenderToTextureMaterial
    {
        Custom,
        Transparent,
        Additive,
        Bloom,
        AlphaClip,
        AlphaClipBloom
    }
}

