using System;
using System.Collections.Generic;
using UnityEngine;

public class HighlightRender : MonoBehaviour
{
    private readonly string BLEND_SHADER_NAME = "Custom/Selection/HighlightMaskBlend";
    private readonly string HIGHLIGHT_SHADER_NAME = "Custom/Selection/Highlight";
    private Material m_BlendMaterial;
    private Shader m_BlendShader;
    private Camera m_Camera;
    private float m_CameraOrthoSize;
    private RenderTexture m_CameraTexture;
    private Shader m_HighlightShader;
    private bool m_Initialized;
    private Material m_Material;
    private Material m_MultiSampleBlendMaterial;
    private Shader m_MultiSampleBlendShader;
    private Material m_MultiSampleMaterial;
    private Shader m_MultiSampleShader;
    private Dictionary<Transform, Vector3> m_ObjectsOrginalPosition;
    private Vector3 m_OrgPosition;
    private Vector3 m_OrgScale;
    private GameObject m_RenderPlane;
    private float m_RenderScale = 1f;
    public Transform m_RootTransform;
    public float m_SilouetteClipSize = 1f;
    public float m_SilouetteRenderSize = 1f;
    private Shader m_UnlitBlackShader;
    private Shader m_UnlitColorShader;
    private Shader m_UnlitDarkGreyShader;
    private Shader m_UnlitGreyShader;
    private Shader m_UnlitLightGreyShader;
    private Shader m_UnlitWhiteShader;
    private Dictionary<UnityEngine.Renderer, bool> m_VisibilityStates;
    private readonly int MAX_HIGHLIGHT_EXCLUDE_PARENT_SEARCH = 0x19;
    private readonly string MULTISAMPLE_BLEND_SHADER_NAME = "Custom/Selection/HighlightMultiSampleBlend";
    private readonly string MULTISAMPLE_SHADER_NAME = "Custom/Selection/HighlightMultiSample";
    private static float s_offset = -2000f;
    private readonly int SILHOUETTE_RENDER_DEPTH = 0x18;
    private readonly int SILHOUETTE_RENDER_SIZE = 200;
    private readonly string UNLIT_BLACK_SHADER_NAME = "Custom/Unlit/Color/BlackOverlay";
    private readonly string UNLIT_COLOR_SHADER_NAME = "Custom/UnlitColor";
    private readonly string UNLIT_DARKGREY_SHADER_NAME = "Custom/Unlit/Color/DarkGrey";
    private readonly string UNLIT_GREY_SHADER_NAME = "Custom/Unlit/Color/Grey";
    private readonly string UNLIT_LIGHTGREY_SHADER_NAME = "Custom/Unlit/Color/LightGrey";
    private readonly string UNLIT_WHITE_SHADER_NAME = "Custom/Unlit/Color/White";

    private void CreateCamera(Transform renderPlane)
    {
        if (this.m_Camera == null)
        {
            GameObject obj2 = new GameObject();
            this.m_Camera = obj2.AddComponent<Camera>();
            obj2.name = renderPlane.name + "_SilhouetteCamera";
            obj2.hideFlags = HideFlags.HideAndDontSave;
            this.m_Camera.orthographic = true;
            this.m_CameraOrthoSize = this.m_RenderScale / 2f;
            this.m_Camera.orthographicSize = this.m_CameraOrthoSize;
            this.m_Camera.transform.position = renderPlane.position;
            this.m_Camera.transform.rotation = renderPlane.rotation;
            this.m_Camera.transform.Rotate((float) 90f, 180f, (float) 0f);
            this.m_Camera.transform.parent = renderPlane;
            this.m_Camera.nearClipPlane = -this.m_RenderScale + 1f;
            this.m_Camera.farClipPlane = this.m_RenderScale + 1f;
            this.m_Camera.depth = Camera.main.depth - 5f;
            this.m_Camera.backgroundColor = Color.black;
            this.m_Camera.clearFlags = CameraClearFlags.Color;
            this.m_Camera.depthTextureMode = DepthTextureMode.None;
            this.m_Camera.renderingPath = RenderingPath.VertexLit;
            this.m_Camera.SetReplacementShader(this.m_UnlitColorShader, string.Empty);
            this.m_Camera.targetTexture = null;
            this.m_Camera.enabled = false;
        }
    }

    public void CreateSilhouetteTexture()
    {
        this.Initialize();
        if (this.VisibilityStatesChanged())
        {
            this.SetupRenderObjects();
            if (this.m_RenderPlane != null)
            {
                bool enabled = base.renderer.enabled;
                base.renderer.enabled = false;
                RenderTexture source = RenderTexture.GetTemporary(this.SILHOUETTE_RENDER_SIZE, this.SILHOUETTE_RENDER_SIZE, this.SILHOUETTE_RENDER_DEPTH);
                RenderTexture blend = RenderTexture.GetTemporary(this.SILHOUETTE_RENDER_SIZE, this.SILHOUETTE_RENDER_SIZE, this.SILHOUETTE_RENDER_DEPTH);
                this.m_Camera.clearFlags = CameraClearFlags.Color;
                this.m_Camera.depth = Camera.main.depth - 5f;
                this.m_Camera.orthographicSize = this.m_CameraOrthoSize - (0.35f * this.m_SilouetteRenderSize);
                this.m_Camera.targetTexture = source;
                this.m_Camera.RenderWithShader(this.m_UnlitDarkGreyShader, "Highlight");
                this.m_Camera.depth = Camera.main.depth - 4f;
                this.m_Camera.orthographicSize = this.m_CameraOrthoSize - (0.22f * this.m_SilouetteRenderSize);
                this.m_Camera.targetTexture = blend;
                this.m_Camera.RenderWithShader(this.m_UnlitGreyShader, "Highlight");
                this.SampleBlend(source, blend, this.m_CameraTexture, 1.5f);
                this.m_Camera.depth = Camera.main.depth - 3f;
                this.m_Camera.orthographicSize = this.m_CameraOrthoSize - (0.1f * this.m_SilouetteRenderSize);
                this.m_Camera.targetTexture = source;
                this.m_Camera.RenderWithShader(this.m_UnlitLightGreyShader, "Highlight");
                this.SampleBlend(source, this.m_CameraTexture, blend, 2.2f);
                this.m_Camera.depth = Camera.main.depth - 2f;
                this.m_Camera.orthographicSize = this.m_CameraOrthoSize - (0.03f * this.m_SilouetteRenderSize);
                this.m_Camera.targetTexture = source;
                this.m_Camera.RenderWithShader(this.m_UnlitWhiteShader, "Highlight");
                this.SampleBlend(source, blend, this.m_CameraTexture, 2.8f);
                this.Sample(this.m_CameraTexture, blend, 3.4f);
                this.m_Camera.depth = Camera.main.depth - 1f;
                this.m_Camera.clearFlags = CameraClearFlags.Color;
                this.m_Camera.orthographicSize = this.m_CameraOrthoSize + (0.1f * this.m_SilouetteClipSize);
                this.m_Camera.targetTexture = source;
                this.m_Camera.RenderWithShader(this.m_UnlitWhiteShader, "Highlight");
                this.BlendMaterial.SetTexture("_BlendTex", source);
                float y = 0.8f;
                Vector2[] offsets = new Vector2[] { new Vector2(-y, -y), new Vector2(-y, y), new Vector2(y, y), new Vector2(y, -y) };
                Graphics.BlitMultiTap(blend, this.m_CameraTexture, this.BlendMaterial, offsets);
                RenderTexture.ReleaseTemporary(source);
                RenderTexture.ReleaseTemporary(blend);
                this.m_Camera.orthographicSize = this.m_CameraOrthoSize;
                base.renderer.enabled = enabled;
                this.RestoreRenderObjects();
            }
        }
    }

    private List<GameObject> GetExcludedObjects()
    {
        List<GameObject> list = new List<GameObject>();
        HighlightExclude[] componentsInChildren = this.m_RootTransform.GetComponentsInChildren<HighlightExclude>();
        if (componentsInChildren == null)
        {
            return null;
        }
        foreach (HighlightExclude exclude in componentsInChildren)
        {
            Transform[] transformArray = exclude.GetComponentsInChildren<Transform>();
            if (transformArray != null)
            {
                foreach (Transform transform in transformArray)
                {
                    list.Add(transform.gameObject);
                }
            }
        }
        list.Add(base.gameObject);
        list.Add(base.transform.parent.gameObject);
        return list;
    }

    public static Vector3 GetWorldScale(Transform transform)
    {
        Vector3 localScale = transform.localScale;
        for (Transform transform2 = transform.parent; transform2 != null; transform2 = transform2.parent)
        {
            localScale = Vector3.Scale(localScale, transform2.localScale);
        }
        return localScale;
    }

    protected void Initialize()
    {
        if (!this.m_Initialized)
        {
            this.m_Initialized = true;
            if (this.m_HighlightShader == null)
            {
                this.m_HighlightShader = Shader.Find(this.HIGHLIGHT_SHADER_NAME);
            }
            if (this.m_HighlightShader == null)
            {
                Debug.LogError("Failed to load Highlight Shader: " + this.HIGHLIGHT_SHADER_NAME);
                base.enabled = false;
            }
            base.renderer.material.shader = this.m_HighlightShader;
            if (this.m_MultiSampleShader == null)
            {
                this.m_MultiSampleShader = Shader.Find(this.MULTISAMPLE_SHADER_NAME);
            }
            if (this.m_MultiSampleShader == null)
            {
                Debug.LogError("Failed to load Highlight Shader: " + this.MULTISAMPLE_SHADER_NAME);
                base.enabled = false;
            }
            if (this.m_MultiSampleBlendShader == null)
            {
                this.m_MultiSampleBlendShader = Shader.Find(this.MULTISAMPLE_BLEND_SHADER_NAME);
            }
            if (this.m_MultiSampleBlendShader == null)
            {
                Debug.LogError("Failed to load Highlight Shader: " + this.MULTISAMPLE_BLEND_SHADER_NAME);
                base.enabled = false;
            }
            if (this.m_BlendShader == null)
            {
                this.m_BlendShader = Shader.Find(this.BLEND_SHADER_NAME);
            }
            if (this.m_BlendShader == null)
            {
                Debug.LogError("Failed to load Highlight Shader: " + this.BLEND_SHADER_NAME);
                base.enabled = false;
            }
            if (this.m_RootTransform == null)
            {
                Transform parent = base.transform.parent.parent;
                if (parent.GetComponent<ActorStateMgr>() != null)
                {
                    this.m_RootTransform = parent.parent;
                }
                else
                {
                    this.m_RootTransform = parent;
                }
                if (this.m_RootTransform == null)
                {
                    Debug.LogError("m_RootTransform is null. Highlighting disabled!");
                    base.enabled = false;
                }
            }
            this.m_VisibilityStates = new Dictionary<UnityEngine.Renderer, bool>();
            HighlightSilhouetteInclude[] componentsInChildren = this.m_RootTransform.GetComponentsInChildren<HighlightSilhouetteInclude>();
            if (componentsInChildren != null)
            {
                foreach (HighlightSilhouetteInclude include in componentsInChildren)
                {
                    UnityEngine.Renderer key = include.gameObject.renderer;
                    if (key != null)
                    {
                        this.m_VisibilityStates.Add(key, false);
                    }
                }
            }
            this.m_UnlitColorShader = Shader.Find(this.UNLIT_COLOR_SHADER_NAME);
            if (this.m_UnlitColorShader == null)
            {
                Debug.LogError("Failed to load Highlight Rendering Shader: " + this.UNLIT_COLOR_SHADER_NAME);
            }
            this.m_UnlitGreyShader = Shader.Find(this.UNLIT_GREY_SHADER_NAME);
            if (this.m_UnlitGreyShader == null)
            {
                Debug.LogError("Failed to load Highlight Rendering Shader: " + this.UNLIT_GREY_SHADER_NAME);
            }
            this.m_UnlitLightGreyShader = Shader.Find(this.UNLIT_LIGHTGREY_SHADER_NAME);
            if (this.m_UnlitLightGreyShader == null)
            {
                Debug.LogError("Failed to load Highlight Rendering Shader: " + this.UNLIT_LIGHTGREY_SHADER_NAME);
            }
            this.m_UnlitDarkGreyShader = Shader.Find(this.UNLIT_DARKGREY_SHADER_NAME);
            if (this.m_UnlitDarkGreyShader == null)
            {
                Debug.LogError("Failed to load Highlight Rendering Shader: " + this.UNLIT_DARKGREY_SHADER_NAME);
            }
            this.m_UnlitBlackShader = Shader.Find(this.UNLIT_BLACK_SHADER_NAME);
            if (this.m_UnlitBlackShader == null)
            {
                Debug.LogError("Failed to load Highlight Rendering Shader: " + this.UNLIT_BLACK_SHADER_NAME);
            }
            this.m_UnlitWhiteShader = Shader.Find(this.UNLIT_WHITE_SHADER_NAME);
            if (this.m_UnlitWhiteShader == null)
            {
                Debug.LogError("Failed to load Highlight Rendering Shader: " + this.UNLIT_WHITE_SHADER_NAME);
            }
        }
    }

    private bool isHighlighExclude(Transform objXform)
    {
        if (objXform == null)
        {
            return true;
        }
        HighlightExclude component = objXform.GetComponent<HighlightExclude>();
        if ((component != null) && component.enabled)
        {
            return true;
        }
        Transform parent = objXform.transform.parent;
        if (parent != null)
        {
            for (int i = 0; (parent != this.m_RootTransform) || (parent != null); i++)
            {
                if ((parent == null) || (i > this.MAX_HIGHLIGHT_EXCLUDE_PARENT_SEARCH))
                {
                    break;
                }
                HighlightExclude exclude2 = parent.GetComponent<HighlightExclude>();
                if ((exclude2 != null) && exclude2.ExcludeChildren)
                {
                    return true;
                }
                parent = parent.parent;
            }
        }
        return false;
    }

    public bool isTextureCreated()
    {
        return ((this.m_CameraTexture != null) && this.m_CameraTexture.IsCreated());
    }

    protected void OnApplicationFocus(bool state)
    {
    }

    protected void OnDisable()
    {
        if (this.m_Initialized)
        {
            if (this.m_Material != null)
            {
                UnityEngine.Object.Destroy(this.m_Material);
            }
            if (this.m_MultiSampleMaterial != null)
            {
                UnityEngine.Object.Destroy(this.m_MultiSampleMaterial);
            }
            if (this.m_BlendMaterial != null)
            {
                UnityEngine.Object.Destroy(this.m_BlendMaterial);
            }
            if (this.m_VisibilityStates != null)
            {
                this.m_VisibilityStates.Clear();
            }
            if (this.m_CameraTexture != null)
            {
                if (RenderTexture.active == this.m_CameraTexture)
                {
                    RenderTexture.active = null;
                }
                this.m_CameraTexture.Release();
                this.m_CameraTexture = null;
            }
            this.m_Initialized = false;
        }
    }

    private void RestoreRenderObjects()
    {
        this.m_RootTransform.position = this.m_OrgPosition;
        this.m_RootTransform.localScale = this.m_OrgScale;
        this.m_RenderPlane = null;
    }

    private void Sample(RenderTexture source, RenderTexture dest, float off)
    {
        Vector2[] offsets = new Vector2[] { new Vector2(-off, -off), new Vector2(-off, off), new Vector2(off, off), new Vector2(off, -off) };
        Graphics.BlitMultiTap(source, dest, this.MultiSampleMaterial, offsets);
    }

    private void SampleBlend(RenderTexture source, RenderTexture blend, RenderTexture dest, float off)
    {
        this.MultiSampleBlendMaterial.SetTexture("_BlendTex", blend);
        Vector2[] offsets = new Vector2[] { new Vector2(-off, -off), new Vector2(-off, off), new Vector2(off, off), new Vector2(off, -off) };
        Graphics.BlitMultiTap(source, dest, this.MultiSampleBlendMaterial, offsets);
    }

    private void SetupRenderObjects()
    {
        if (this.m_RootTransform == null)
        {
            this.m_RenderPlane = null;
        }
        else
        {
            s_offset -= 10f;
            if (s_offset < -9000f)
            {
                s_offset = -2000f;
            }
            this.m_OrgPosition = this.m_RootTransform.position;
            this.m_OrgScale = this.m_RootTransform.localScale;
            Vector3 vector = (Vector3) (Vector3.left * s_offset);
            this.m_RootTransform.position = vector;
            this.SetWorldScale(this.m_RootTransform, Vector3.one);
            if (this.m_CameraTexture == null)
            {
                this.m_CameraTexture = new RenderTexture(this.SILHOUETTE_RENDER_SIZE, this.SILHOUETTE_RENDER_SIZE, this.SILHOUETTE_RENDER_DEPTH);
                this.m_CameraTexture.format = RenderTextureFormat.ARGB32;
            }
            HighlightState componentInChildren = this.m_RootTransform.GetComponentInChildren<HighlightState>();
            if (componentInChildren == null)
            {
                Debug.LogError("Can not find Highlight(HighlightState component) object for selection highlighting.");
                this.m_RenderPlane = null;
            }
            else
            {
                componentInChildren.transform.localPosition = Vector3.zero;
                HighlightRender render = this.m_RootTransform.GetComponentInChildren<HighlightRender>();
                if (render == null)
                {
                    Debug.LogError("Can not find render plane object(HighlightRender component) for selection highlighting.");
                    this.m_RenderPlane = null;
                }
                else
                {
                    this.m_RenderPlane = render.gameObject;
                    this.m_RenderScale = GetWorldScale(this.m_RenderPlane.transform).x;
                    this.CreateCamera(render.transform);
                }
            }
        }
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

    protected void Update()
    {
        if (((this.m_CameraTexture != null) && this.m_Initialized) && !this.m_CameraTexture.IsCreated())
        {
            this.CreateSilhouetteTexture();
        }
    }

    private bool VisibilityStatesChanged()
    {
        bool flag = false;
        HighlightSilhouetteInclude[] componentsInChildren = this.m_RootTransform.GetComponentsInChildren<HighlightSilhouetteInclude>();
        List<UnityEngine.Renderer> list = new List<UnityEngine.Renderer>();
        foreach (HighlightSilhouetteInclude include in componentsInChildren)
        {
            UnityEngine.Renderer item = include.gameObject.renderer;
            if (item != null)
            {
                list.Add(item);
            }
        }
        Dictionary<UnityEngine.Renderer, bool> dictionary = new Dictionary<UnityEngine.Renderer, bool>();
        foreach (UnityEngine.Renderer renderer2 in list)
        {
            bool flag2 = renderer2.enabled && renderer2.gameObject.activeInHierarchy;
            if (!this.m_VisibilityStates.ContainsKey(renderer2))
            {
                dictionary.Add(renderer2, flag2);
                if (flag2)
                {
                    flag = true;
                }
            }
            else
            {
                if (this.m_VisibilityStates[renderer2] != flag2)
                {
                    flag = true;
                }
                dictionary.Add(renderer2, flag2);
            }
        }
        return flag;
    }

    protected Material BlendMaterial
    {
        get
        {
            if (this.m_BlendMaterial == null)
            {
                this.m_BlendMaterial = new Material(this.m_BlendShader);
                this.m_BlendMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_BlendMaterial;
        }
    }

    protected Material HighlightMaterial
    {
        get
        {
            if (this.m_Material == null)
            {
                this.m_Material = new Material(this.m_HighlightShader);
                this.m_Material.hideFlags = HideFlags.DontSave;
            }
            return this.m_Material;
        }
    }

    protected Material MultiSampleBlendMaterial
    {
        get
        {
            if (this.m_MultiSampleBlendMaterial == null)
            {
                this.m_MultiSampleBlendMaterial = new Material(this.m_MultiSampleBlendShader);
                this.m_MultiSampleBlendMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_MultiSampleBlendMaterial;
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

    public RenderTexture SilhouetteTexture
    {
        get
        {
            return this.m_CameraTexture;
        }
    }
}

