using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

[ExecuteInEditMode]
public class UberText : MonoBehaviour
{
    [CompilerGenerated]
    private static Dictionary<string, int> <>f__switch$map8;
    private readonly float BOLD_MAX_SIZE = 10f;
    private readonly string BOLD_OUTLINE_TEXT_SHADER_NAME = "Hidden/TextBoldOutline_Unlit";
    private readonly string BOLD_SHADER_NAME = "Hidden/Text_Bold";
    private readonly float CHARACTER_SIZE_SCALE = 0.01f;
    private readonly string INLINE_IMAGE_SHADER_NAME = "Hero/Unlit_Transparent";
    [SerializeField]
    private AlignmentOptions m_Alignment = AlignmentOptions.Center;
    [SerializeField]
    private float m_AmbientLightBlend;
    [SerializeField]
    private AnchorOptions m_Anchor = AnchorOptions.Middle;
    [SerializeField]
    private bool m_AntiAlias;
    [SerializeField]
    private float m_AntiAliasAmount = 0.5f;
    [SerializeField]
    private float m_AntiAliasEdge = 0.5f;
    private Shader m_AntialiasingTextShader;
    private Material m_BoldMaterial;
    private Shader m_BoldOutlineShader;
    private Shader m_BoldShader;
    [SerializeField]
    private float m_BoldSize;
    private Camera m_Camera;
    private GameObject m_CameraGO;
    [SerializeField]
    private float m_CharacterSize = 5f;
    [SerializeField]
    private Font m_Font;
    [SerializeField]
    private int m_FontSize = 0x23;
    [SerializeField]
    private bool m_ForceWrapLargeWords;
    [SerializeField]
    private Color m_GradientLowerColor = Color.white;
    [SerializeField]
    private Color m_GradientUpperColor = Color.white;
    [SerializeField]
    private float m_Height = 1f;
    private Material m_InlineImageMaterial;
    private Shader m_InlineImageShader;
    [SerializeField]
    private float m_LineSpacing = 1f;
    [SerializeField]
    private int m_MinFontSize = 10;
    private bool m_MultiLine;
    private float m_Offset;
    private int m_OrgRenderQueue = -9999;
    [SerializeField]
    private bool m_Outline;
    [SerializeField]
    private Color m_OutlineColor = Color.black;
    [SerializeField]
    private float m_OutlineSize = 1f;
    private Material m_OutlineTextMaterial;
    private Shader m_OutlineTextShader;
    private GameObject m_PlaneGameObject;
    private Material m_PlaneMaterial;
    private Mesh m_PlaneMesh;
    private Shader m_PlaneShader;
    private float m_PreviousPlaneHeight;
    private float m_PreviousPlaneWidth;
    private int m_PreviousResolution = 0x100;
    private Vector2 m_PreviousTexelSize;
    private string m_PreviousText = string.Empty;
    [SerializeField]
    private GameObject m_RenderOnObject;
    [SerializeField]
    private int m_RenderQueue;
    [SerializeField]
    private bool m_RenderToTexture;
    [SerializeField]
    private bool m_ResizeToFit;
    [SerializeField]
    private int m_Resolution = 0x100;
    [SerializeField]
    private bool m_RichText = true;
    [SerializeField]
    private bool m_Shadow;
    [SerializeField]
    private float m_ShadowBlur = 1.5f;
    [SerializeField]
    private Color m_ShadowColor = new Color(0.1f, 0.1f, 0.1f, 0.333f);
    private Material m_ShadowMaterial;
    [SerializeField]
    private float m_ShadowOffset = 1f;
    private GameObject m_ShadowPlaneGameObject;
    private Shader m_ShadowTextShader;
    [SerializeField]
    private string m_Text = "Uber Text";
    private Material m_TextAntialiasingMaterial;
    [SerializeField]
    private Color m_TextColor = Color.white;
    private Material m_TextMaterial;
    private Dictionary<TextRenderMaterial, int> m_TextMaterialIndices = new Dictionary<TextRenderMaterial, int>();
    private TextMesh m_TextMesh;
    private GameObject m_TextMeshGameObject;
    private Shader m_TextShader;
    private RenderTexture m_TextTexture;
    private static RenderTextureFormat m_TextureFormat = RenderTextureFormat.DefaultHDR;
    [SerializeField]
    private bool m_Underwear;
    [SerializeField]
    private float m_UnderwearHeight = 0.2f;
    [SerializeField]
    private float m_UnderwearWidth = 0.2f;
    private bool m_updated;
    [SerializeField]
    private float m_Width = 1f;
    private string[] m_Words;
    [SerializeField]
    private bool m_WordWrap;
    private float m_WorldHeight;
    private float m_WorldWidth;
    private readonly int MAX_REDUCE_TEXT_COUNT = 20;
    private readonly string OUTLINE_TEXT_SHADER_NAME = "Hidden/TextOutline_Unlit";
    private readonly Vector3[] PLANE_NORMALS = new Vector3[] { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
    private readonly string PLANE_SHADER_NAME = "Hidden/TextPlane";
    private readonly int[] PLANE_TRIANGLES = new int[] { 3, 1, 2, 2, 1, 0 };
    private readonly Vector2[] PLANE_UVS = new Vector2[] { new Vector2(0f, 0f), new Vector2(1f, 0f), new Vector2(0f, 1f), new Vector2(1f, 1f) };
    private static int RENDER_LAYER = 0x1c;
    private static int RENDER_LAYER_BIT = GameLayer.InvisibleRender.LayerBit();
    private static Texture2D s_InlineImageTexture;
    private static bool s_InlineImageTextureLoaded = false;
    private static float s_offset = -3000f;
    private readonly string SHADOW_SHADER_NAME = "Hidden/TextShadow";
    private readonly string TEXT_ANTIALAISING_SHADER_NAME = "Hidden/TextAntialiasing";
    private readonly string TEXT_SHADER_NAME = "Hero/Text_Unlit";
    private Material TextMeshBaseMaterial;

    private void AntiAliasRender()
    {
        if ((this.m_PlaneGameObject != null) || (this.m_RenderOnObject != null))
        {
            if (this.m_AntiAlias)
            {
                Texture texture;
                if (this.m_RenderOnObject != null)
                {
                    texture = this.m_RenderOnObject.renderer.sharedMaterial.GetTexture("_MainTex");
                    this.m_RenderOnObject.renderer.sharedMaterial = this.TextAntialiasingMaterial;
                    this.m_RenderOnObject.renderer.sharedMaterial.SetTexture("_MainTex", texture);
                }
                else
                {
                    texture = this.m_PlaneGameObject.renderer.sharedMaterial.GetTexture("_MainTex");
                    this.m_PlaneGameObject.renderer.sharedMaterial = this.TextAntialiasingMaterial;
                    this.m_PlaneGameObject.renderer.sharedMaterial.SetTexture("_MainTex", texture);
                }
                Vector2 texelSize = texture.texelSize;
                this.m_TextAntialiasingMaterial.SetFloat("_OffsetX", texelSize.x * this.m_AntiAliasAmount);
                this.m_TextAntialiasingMaterial.SetFloat("_OffsetY", texelSize.y * this.m_AntiAliasAmount);
                this.m_TextAntialiasingMaterial.SetFloat("_Edge", this.m_AntiAliasEdge);
            }
            else if (this.m_RenderOnObject != null)
            {
                this.m_RenderOnObject.renderer.sharedMaterial = this.PlaneMaterial;
            }
            else
            {
                this.m_PlaneGameObject.renderer.sharedMaterial = this.PlaneMaterial;
            }
        }
    }

    private void Awake()
    {
        this.FindSupportedTextureFormat();
        if (s_InlineImageTexture == null)
        {
            s_InlineImageTexture = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            s_InlineImageTexture.SetPixel(0, 0, Color.clear);
            s_InlineImageTexture.SetPixel(1, 0, Color.clear);
            s_InlineImageTexture.SetPixel(0, 1, Color.clear);
            s_InlineImageTexture.SetPixel(1, 1, Color.clear);
            s_InlineImageTexture.Apply();
        }
        this.DestroyChildren();
    }

    private void Bold()
    {
        if (this.m_BoldSize > this.BOLD_MAX_SIZE)
        {
            this.m_BoldSize = this.BOLD_MAX_SIZE;
        }
        if (this.m_Outline)
        {
            if (this.m_BoldOutlineShader == null)
            {
                this.m_BoldOutlineShader = Shader.Find(this.BOLD_OUTLINE_TEXT_SHADER_NAME);
                if (this.m_BoldOutlineShader == null)
                {
                    Debug.LogError("UberText Failed to load Shader: " + this.BOLD_OUTLINE_TEXT_SHADER_NAME);
                }
            }
            this.m_BoldMaterial.shader = this.m_BoldOutlineShader;
            Vector2 texelSize = this.m_BoldMaterial.mainTexture.texelSize;
            this.m_BoldMaterial.SetColor("_OutlineColor", this.m_OutlineColor);
            this.m_BoldMaterial.SetFloat("_BoldOffsetX", this.m_BoldSize * texelSize.x);
            this.m_BoldMaterial.SetFloat("_BoldOffsetY", this.m_BoldSize * texelSize.y);
            this.m_BoldMaterial.SetFloat("_OutlineOffsetX", texelSize.x * (this.m_OutlineSize + (this.m_BoldSize * 0.75f)));
            this.m_BoldMaterial.SetFloat("_OutlineOffsetY", texelSize.y * (this.m_OutlineSize + (this.m_BoldSize * 0.75f)));
        }
        else
        {
            this.m_BoldMaterial.shader = this.m_BoldShader;
            Vector2 vector2 = this.m_BoldMaterial.mainTexture.texelSize;
            this.m_BoldMaterial.SetFloat("_BoldOffsetX", this.m_BoldSize * vector2.x);
            this.m_BoldMaterial.SetFloat("_BoldOffsetY", this.m_BoldSize * vector2.y);
            this.m_BoldMaterial.SetColor("_Color", this.m_TextColor);
        }
    }

    private string[] BreakTextIntoWords(string text)
    {
        int[] numArray = FindWordWrapBreaks(text);
        if (numArray.Length < 1)
        {
            return new string[] { text };
        }
        List<string> list = new List<string>();
        int startIndex = 0;
        foreach (int num2 in numArray)
        {
            list.Add(text.Substring(startIndex, num2 - startIndex));
            startIndex = num2;
        }
        list.Add(text.Substring(startIndex));
        return list.ToArray();
    }

    private Vector2 CalcTextureSize()
    {
        Vector2 vector = new Vector2((float) this.m_Resolution, (float) this.m_Resolution);
        if (this.m_Width > this.m_Height)
        {
            vector.x = this.m_Resolution;
            vector.y = this.m_Resolution * (this.m_Height / this.m_Width);
            return vector;
        }
        vector.x = this.m_Resolution * (this.m_Width / this.m_Height);
        vector.y = this.m_Resolution;
        return vector;
    }

    private void CleanUp()
    {
        this.m_Offset = 0f;
        this.DestroyRenderPlane();
        this.DestroyCamera();
        this.DestroyTexture();
        this.DestroyShadow();
        this.DestroyTextMesh();
        this.m_updated = false;
        if (this.m_BoldMaterial != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_BoldMaterial);
        }
        if (this.m_TextMaterial != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_TextMaterial);
        }
        if (this.m_OutlineTextMaterial != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_OutlineTextMaterial);
        }
        if (this.m_TextAntialiasingMaterial != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_TextAntialiasingMaterial);
        }
        if (this.m_ShadowMaterial != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_ShadowMaterial);
        }
        if (this.m_PlaneMaterial != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_PlaneMaterial);
        }
        if (this.m_InlineImageMaterial != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_InlineImageMaterial);
        }
    }

    private void CreateCamera()
    {
        if (this.m_Camera == null)
        {
            this.m_CameraGO = new GameObject();
            this.m_Camera = this.m_CameraGO.AddComponent<Camera>();
            this.m_CameraGO.name = "UberText_RenderCamera_" + base.name;
            this.m_CameraGO.hideFlags = HideFlags.HideAndDontSave;
            this.m_Camera.orthographic = true;
            this.m_CameraGO.transform.parent = this.m_TextMeshGameObject.transform;
            this.m_CameraGO.transform.rotation = Quaternion.identity;
            this.m_CameraGO.transform.position = this.m_TextMeshGameObject.transform.position;
            this.m_Camera.nearClipPlane = -0.1f;
            this.m_Camera.farClipPlane = 0.1f;
            if (Camera.main != null)
            {
                this.m_Camera.depth = Camera.main.depth - 50f;
            }
            Color textColor = this.m_TextColor;
            if (this.m_Outline)
            {
                textColor = this.m_OutlineColor;
            }
            this.m_Camera.backgroundColor = new Color(textColor.r, textColor.g, textColor.b, 0f);
            this.m_Camera.clearFlags = CameraClearFlags.Color;
            this.m_Camera.depthTextureMode = DepthTextureMode.None;
            this.m_Camera.renderingPath = RenderingPath.Forward;
            this.m_Camera.cullingMask = RENDER_LAYER_BIT;
            this.m_Camera.enabled = false;
        }
    }

    private void CreateEditorRoot()
    {
    }

    private void CreateOutlineCamera()
    {
    }

    private void CreateRenderPlane()
    {
        if (((this.m_PlaneMesh == null) || (this.m_Width != this.m_PreviousPlaneWidth)) || ((this.m_Height != this.m_PreviousPlaneHeight) || (this.m_PreviousResolution != this.m_Resolution)))
        {
            if (this.m_PlaneGameObject != null)
            {
                UnityEngine.Object.DestroyImmediate(this.m_PlaneGameObject);
            }
            this.m_PlaneGameObject = new GameObject();
            this.m_PlaneGameObject.name = "UberText_RenderPlane_" + base.name;
            this.m_PlaneGameObject.AddComponent<MeshFilter>();
            this.m_PlaneGameObject.AddComponent<MeshRenderer>();
            Mesh mesh = new Mesh();
            this.m_PlaneGameObject.hideFlags = HideFlags.HideAndDontSave;
            this.m_PlaneGameObject.transform.parent = base.transform;
            this.m_PlaneGameObject.transform.localPosition = Vector3.zero;
            this.m_PlaneGameObject.transform.localRotation = Quaternion.identity;
            this.m_PlaneGameObject.transform.Rotate((float) -90f, 0f, (float) 0f);
            this.m_PlaneGameObject.transform.localScale = Vector3.one;
            float x = this.m_Width * 0.5f;
            float z = this.m_Height * 0.5f;
            mesh.vertices = new Vector3[] { new Vector3(-x, 0f, -z), new Vector3(x, 0f, -z), new Vector3(-x, 0f, z), new Vector3(x, 0f, z) };
            mesh.colors = new Color[] { this.m_GradientLowerColor, this.m_GradientLowerColor, this.m_GradientUpperColor, this.m_GradientUpperColor };
            mesh.uv = this.PLANE_UVS;
            mesh.normals = this.PLANE_NORMALS;
            mesh.triangles = this.PLANE_TRIANGLES;
            Mesh mesh2 = mesh;
            this.m_PlaneGameObject.GetComponent<MeshFilter>().mesh = mesh2;
            this.m_PlaneMesh = mesh2;
            this.m_PlaneMesh.RecalculateBounds();
            this.m_PlaneGameObject.renderer.sharedMaterial = this.PlaneMaterial;
            this.m_PlaneGameObject.renderer.sharedMaterial.mainTexture = this.m_TextTexture;
            this.m_PreviousPlaneWidth = this.m_Width;
            this.m_PreviousPlaneHeight = this.m_Height;
        }
    }

    private void CreateTextMesh()
    {
        if (this.m_TextMeshGameObject == null)
        {
            this.m_TextMeshGameObject = new GameObject();
            this.m_TextMeshGameObject.name = "UberText_RenderObject_" + base.name;
            this.m_TextMeshGameObject.hideFlags = HideFlags.HideAndDontSave;
        }
        else if (this.m_TextMeshGameObject.GetComponent<TextMesh>() != null)
        {
            this.SetText(string.Empty);
        }
        if (this.m_RenderToTexture)
        {
            Vector3 vector = new Vector3(-3000f, 3000f, this.Offset);
            this.m_TextMeshGameObject.transform.parent = null;
            this.m_TextMeshGameObject.transform.position = vector;
            this.m_TextMeshGameObject.transform.rotation = Quaternion.identity;
        }
        else
        {
            this.m_TextMeshGameObject.transform.parent = base.transform;
            this.m_TextMeshGameObject.transform.localPosition = Vector3.zero;
            this.m_TextMeshGameObject.transform.localRotation = Quaternion.identity;
            this.m_TextMeshGameObject.transform.localScale = Vector3.one;
        }
        if (this.m_TextMesh == null)
        {
            this.m_TextMaterialIndices.Clear();
            if (this.m_TextMeshGameObject == null)
            {
                return;
            }
            if (this.m_TextMeshGameObject.GetComponent<MeshRenderer>() == null)
            {
                this.m_TextMeshGameObject.AddComponent<MeshRenderer>();
            }
            TextMesh component = this.m_TextMeshGameObject.GetComponent<TextMesh>();
            if (component != null)
            {
                this.m_TextMesh = component;
            }
            else
            {
                this.m_TextMesh = this.m_TextMeshGameObject.AddComponent<TextMesh>();
            }
            if (this.m_TextMesh == null)
            {
                Debug.LogError("UberText: Faild to create TextMesh");
                return;
            }
            this.SetRichText(this.m_RichText);
            Texture mainTexture = this.m_Font.material.mainTexture;
            this.m_TextMesh.renderer.sharedMaterial = this.TextMaterial;
            this.m_TextMesh.renderer.sharedMaterial.mainTexture = mainTexture;
            this.m_TextMesh.renderer.sharedMaterial.color = this.m_TextColor;
            if (this.m_RichText)
            {
                Material[] materialArray = new Material[2];
                materialArray[0] = this.m_TextMesh.renderer.sharedMaterial;
                this.m_TextMaterialIndices.Add(TextRenderMaterial.Text, 0);
                materialArray[1] = this.BoldMaterial;
                materialArray[1].mainTexture = mainTexture;
                this.m_TextMaterialIndices.Add(TextRenderMaterial.Bold, 1);
                this.m_TextMesh.renderer.sharedMaterials = materialArray;
            }
            else
            {
                Material[] materialArray2 = new Material[] { this.m_TextMesh.renderer.sharedMaterial };
                this.m_TextMaterialIndices.Add(TextRenderMaterial.Text, 0);
                this.m_TextMesh.renderer.sharedMaterials = materialArray2;
            }
        }
        if (!this.m_Outline && (this.m_TextMesh.renderer.sharedMaterial == this.m_OutlineTextMaterial))
        {
            Texture texture2 = this.m_TextMesh.renderer.sharedMaterial.mainTexture;
            this.m_TextMesh.renderer.sharedMaterial = this.TextMaterial;
            this.m_TextMesh.renderer.sharedMaterial.mainTexture = texture2;
        }
        this.SetFont(this.m_Font);
        this.SetFontSize(this.m_FontSize);
        this.SetLineSpacing(this.m_LineSpacing);
        this.SetCharacterSize(this.m_CharacterSize * this.CHARACTER_SIZE_SCALE);
        if (this.m_Text == null)
        {
            this.SetText(string.Empty);
        }
        else
        {
            this.SetText(this.m_Text);
        }
    }

    private void CreateTexture()
    {
        this.DestroyTexture();
        Vector2 vector = this.CalcTextureSize();
        this.m_TextTexture = new RenderTexture((int) vector.x, (int) vector.y, 0, m_TextureFormat);
        this.m_TextTexture.Create();
        this.m_TextTexture.hideFlags = HideFlags.HideAndDontSave;
        if (this.m_Camera != null)
        {
            this.m_Camera.targetTexture = this.m_TextTexture;
        }
        if ((this.m_PlaneGameObject != null) && (this.m_PlaneGameObject.renderer.sharedMaterial != null))
        {
            this.m_PlaneGameObject.renderer.sharedMaterial.mainTexture = this.m_TextTexture;
        }
        this.m_PreviousResolution = this.m_Resolution;
    }

    private void DestroyCamera()
    {
        if (this.m_CameraGO != null)
        {
            this.m_Camera.targetTexture = null;
            UnityEngine.Object.Destroy(this.m_CameraGO);
        }
    }

    private void DestroyChildren()
    {
        GameObject obj2 = new GameObject("UberTextDestroyDummy");
        foreach (Transform transform in base.GetComponentsInChildren<Transform>())
        {
            if ((base.transform != transform) && (transform != null))
            {
                GameObject gameObject = transform.gameObject;
                if ((gameObject != null) && gameObject.name.StartsWith("UberText_"))
                {
                    gameObject.transform.parent = obj2.transform;
                }
            }
        }
        if (Application.isPlaying)
        {
            UnityEngine.Object.Destroy(obj2);
        }
        else
        {
            UnityEngine.Object.DestroyImmediate(obj2);
        }
    }

    private void DestroyRenderPlane()
    {
        if (this.m_PlaneGameObject != null)
        {
            MeshFilter component = this.m_PlaneGameObject.GetComponent<MeshFilter>();
            if (component != null)
            {
                UnityEngine.Object.DestroyImmediate(component.sharedMesh);
                UnityEngine.Object.DestroyImmediate(component);
            }
            UnityEngine.Object.DestroyImmediate(this.m_PlaneGameObject);
        }
    }

    private void DestroyShadow()
    {
        if (this.m_ShadowPlaneGameObject != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_ShadowPlaneGameObject);
        }
    }

    private void DestroyTextMesh()
    {
        if (this.m_TextMeshGameObject != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_TextMeshGameObject);
        }
    }

    private void DestroyTexture()
    {
        if (this.m_TextTexture != null)
        {
            UnityEngine.Object.Destroy(this.m_TextTexture);
        }
    }

    public void EditorAwake()
    {
        this.DestroyChildren();
        this.UpdateText();
    }

    private void FindSupportedTextureFormat()
    {
        if (m_TextureFormat == RenderTextureFormat.DefaultHDR)
        {
            if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGB4444))
            {
                m_TextureFormat = RenderTextureFormat.ARGB4444;
            }
            else
            {
                m_TextureFormat = RenderTextureFormat.Default;
            }
        }
    }

    private static int[] FindWordWrapBreaks(string text)
    {
        List<int> list = new List<int>();
        bool flag = false;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '<')
            {
                flag = true;
            }
            else if (text[i] == '>')
            {
                flag = false;
            }
            else if (!flag && ((text[i] == ' ') || (text[i] == '\n')))
            {
                list.Add(i);
            }
        }
        return list.ToArray();
    }

    public Bounds GetBounds()
    {
        if (!this.m_updated)
        {
            this.UpdateNow();
        }
        Vector3 position = base.transform.position;
        return new Bounds(position, new Vector3(this.m_WorldWidth, this.m_WorldHeight, 0f));
    }

    private Vector3 GetLossyWorldScale(Transform xform)
    {
        Quaternion rotation = xform.rotation;
        xform.rotation = Quaternion.identity;
        Vector3 lossyScale = base.transform.lossyScale;
        xform.rotation = rotation;
        return lossyScale;
    }

    public Bounds GetTextBounds()
    {
        if (!this.m_updated)
        {
            this.UpdateNow();
        }
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        if (this.m_TextMesh != null)
        {
            Quaternion rotation = base.transform.rotation;
            base.transform.rotation = Quaternion.identity;
            bounds = this.m_TextMesh.renderer.bounds;
            base.transform.rotation = rotation;
        }
        return bounds;
    }

    public Bounds GetTextWorldSpaceBounds()
    {
        if (!this.m_updated)
        {
            this.UpdateNow();
        }
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        if (this.m_TextMesh != null)
        {
            bounds = this.m_TextMesh.renderer.bounds;
        }
        return bounds;
    }

    public static Vector3 GetWorldScale(Transform xform)
    {
        Vector3 localScale = xform.localScale;
        if (xform.parent != null)
        {
            for (Transform transform = xform.parent; transform != null; transform = transform.parent)
            {
                localScale.Scale(transform.localScale);
            }
        }
        return localScale;
    }

    private Vector2 GetWorldWidthAndHight()
    {
        Quaternion rotation = base.transform.rotation;
        base.transform.rotation = Quaternion.identity;
        Vector3 lossyScale = base.transform.lossyScale;
        float width = this.m_Width;
        if (lossyScale.x > 0f)
        {
            width = this.m_Width * lossyScale.x;
        }
        float height = this.m_Height;
        if (lossyScale.y > 0f)
        {
            height = this.m_Height * lossyScale.y;
        }
        base.transform.rotation = rotation;
        return new Vector2(width, height);
    }

    private string InlineImage(string tag)
    {
        string str;
        if (tag == string.Empty)
        {
            return string.Empty;
        }
        if (!s_InlineImageTextureLoaded)
        {
            AssetLoader.Get().LoadTexture("mana_in_line", new AssetLoader.ObjectCallback(this.SetManaTexture));
        }
        int index = this.TextEffectsMaterial(TextRenderMaterial.InlineImages, this.InlineImageMaterial);
        float num2 = 0f;
        float num3 = 0f;
        string key = tag;
        if (key != null)
        {
            int num4;
            if (<>f__switch$map8 == null)
            {
                Dictionary<string, int> dictionary = new Dictionary<string, int>(13);
                dictionary.Add("<m>", 0);
                dictionary.Add("<me>", 1);
                dictionary.Add("<m0>", 2);
                dictionary.Add("<m1>", 3);
                dictionary.Add("<m2>", 4);
                dictionary.Add("<m3>", 5);
                dictionary.Add("<m4>", 6);
                dictionary.Add("<m5>", 7);
                dictionary.Add("<m6>", 8);
                dictionary.Add("<m7>", 9);
                dictionary.Add("<m8>", 10);
                dictionary.Add("<m9>", 11);
                dictionary.Add("<m10>", 12);
                <>f__switch$map8 = dictionary;
            }
            if (<>f__switch$map8.TryGetValue(key, out num4))
            {
                switch (num4)
                {
                    case 0:
                        num2 = 0f;
                        num3 = 0f;
                        goto Label_0259;

                    case 1:
                        num2 = 0.75f;
                        num3 = 0.25f;
                        goto Label_0259;

                    case 2:
                        num2 = 0f;
                        num3 = 0.75f;
                        goto Label_0259;

                    case 3:
                        num2 = 0.25f;
                        num3 = 0.75f;
                        goto Label_0259;

                    case 4:
                        num2 = 0.5f;
                        num3 = 0.75f;
                        goto Label_0259;

                    case 5:
                        num2 = 0.75f;
                        num3 = 0.75f;
                        goto Label_0259;

                    case 6:
                        num2 = 0f;
                        num3 = 0.5f;
                        goto Label_0259;

                    case 7:
                        num2 = 0.25f;
                        num3 = 0.5f;
                        goto Label_0259;

                    case 8:
                        num2 = 0.5f;
                        num3 = 0.5f;
                        goto Label_0259;

                    case 9:
                        num2 = 0.75f;
                        num3 = 0.5f;
                        goto Label_0259;

                    case 10:
                        num2 = 0f;
                        num3 = 0.25f;
                        goto Label_0259;

                    case 11:
                        num2 = 0.25f;
                        num3 = 0.25f;
                        goto Label_0259;

                    case 12:
                        num2 = 0.5f;
                        num3 = 0.25f;
                        goto Label_0259;
                }
            }
        }
        return tag;
    Label_0259:
        str = string.Empty;
        this.m_TextMesh.renderer.sharedMaterials[index].mainTexture = s_InlineImageTexture;
        object[] args = new object[] { index, this.m_FontSize, num2, num3 };
        return string.Format("<quad material={0} size={1} x={2} y={3} width=0.25 height=0.25 />", args);
    }

    public bool IsDone()
    {
        return this.m_updated;
    }

    private bool isTextMultiLine(string text)
    {
        return text.Contains("\n");
    }

    private void OnDestroy()
    {
        this.CleanUp();
    }

    private void OnDisable()
    {
        if (this.m_RenderOnObject != null)
        {
            this.m_RenderOnObject.renderer.enabled = false;
        }
        if (this.m_TextTexture != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_TextTexture);
            this.m_TextTexture = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = base.transform.localToWorldMatrix;
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(this.m_Width + (this.m_Width * 0.02f), this.m_Height + (this.m_Height * 0.02f), 0f));
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(this.m_Width, this.m_Height, 0f));
        if (this.m_Underwear)
        {
            float x = (this.m_Width * this.m_UnderwearWidth) * 0.5f;
            float y = this.m_Height * this.m_UnderwearHeight;
            Vector3 center = new Vector3(-((this.m_Width * 0.5f) - (x * 0.5f)), -((this.m_Height * 0.5f) - (y * 0.5f)), 0f);
            Gizmos.DrawWireCube(center, new Vector3(x, y, 0f));
            Vector3 vector2 = new Vector3((this.m_Width * 0.5f) - (x * 0.5f), -((this.m_Height * 0.5f) - (y * 0.5f)), 0f);
            Gizmos.DrawWireCube(vector2, new Vector3(x, y, 0f));
        }
        Gizmos.matrix = Matrix4x4.identity;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.matrix = base.transform.localToWorldMatrix;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(this.m_Width + (this.m_Width * 0.04f), this.m_Height + (this.m_Height * 0.04f), 0f));
        Gizmos.matrix = Matrix4x4.identity;
    }

    private void OnEnable()
    {
        this.m_updated = false;
        this.UpdateNow();
    }

    private void OutlineRender()
    {
        Texture mainTexture = this.m_TextMesh.renderer.sharedMaterial.mainTexture;
        this.m_TextMesh.renderer.sharedMaterial = this.OutlineTextMaterial;
        this.m_OutlineTextMaterial.mainTexture = mainTexture;
        Vector2 texelSize = this.m_OutlineTextMaterial.mainTexture.texelSize;
        float outlineSize = this.m_OutlineSize;
        this.m_OutlineTextMaterial.SetFloat("_OutlineOffsetX", texelSize.x * outlineSize);
        this.m_OutlineTextMaterial.SetFloat("_OutlineOffsetY", texelSize.y * outlineSize);
        this.m_OutlineTextMaterial.SetColor("_Color", this.m_TextColor);
        this.m_OutlineTextMaterial.SetColor("_OutlineColor", this.m_OutlineColor);
        this.m_OutlineTextMaterial.SetFloat("_TexelSizeX", texelSize.x);
        this.m_OutlineTextMaterial.SetFloat("_TexelSizeY", texelSize.y);
    }

    private string ProcessText(string text)
    {
        if (!this.m_TextMesh.richText)
        {
            return text;
        }
        StringBuilder builder = new StringBuilder();
        builder.Append("<material=1></material>");
        builder.Append(text);
        for (int i = 0; i < text.Length; i++)
        {
            if ((text[i] == '<') && (i <= (text.Length - 2)))
            {
                if (text[i + 1] == 'b')
                {
                    this.Bold();
                    if (this.m_TextMesh.renderer.sharedMaterials.Length < 1)
                    {
                        Debug.LogWarning("UberText: Tried to set Bold material, but material missing!");
                    }
                    else
                    {
                        builder.Replace("<b>", "<material=1>");
                        builder.Replace("</b>", "</material>");
                        i++;
                    }
                }
                else if (((text[i + 1] == 'm') && (i <= (text.Length - 3))) && (text[i + 2] != 'a'))
                {
                    int index = text.Substring(i).IndexOf('>');
                    if (index < 1)
                    {
                        i++;
                    }
                    else
                    {
                        string oldValue = text.Substring(i, index + 1);
                        builder.Replace(oldValue, this.InlineImage(oldValue));
                    }
                }
            }
        }
        string str2 = builder.ToString();
        if (str2 == null)
        {
            Debug.LogWarning("UberText: ProcessText returned a null string!");
            str2 = string.Empty;
        }
        return str2;
    }

    private void ReduceText(string text, int step, int newSize)
    {
        if (this.m_FontSize != 1)
        {
            this.SetFontSize(newSize);
            float height = this.m_Height;
            float width = this.m_Width;
            if (!this.m_RenderToTexture)
            {
                height = this.m_WorldHeight;
                width = this.m_WorldWidth;
            }
            float lineSpacing = this.m_TextMesh.lineSpacing;
            if (!this.m_MultiLine)
            {
                this.SetLineSpacing(0f);
            }
            float y = this.m_TextMesh.renderer.bounds.size.y;
            float x = this.m_TextMesh.renderer.bounds.size.x;
            int num6 = 0;
            while ((y > height) || (x > width))
            {
                num6++;
                if (num6 > this.MAX_REDUCE_TEXT_COUNT)
                {
                    break;
                }
                newSize -= step;
                if (newSize < this.m_MinFontSize)
                {
                    newSize = this.m_MinFontSize;
                    break;
                }
                this.SetFontSize(newSize);
                if (this.m_WordWrap)
                {
                    this.SetText(this.WordWrapString(text, width));
                }
                y = this.m_TextMesh.renderer.bounds.size.y;
                x = this.m_TextMesh.renderer.bounds.size.x;
            }
            if (!this.m_MultiLine)
            {
                this.SetLineSpacing(lineSpacing);
            }
            this.m_FontSize = newSize;
        }
    }

    private void ReduceText_CharSize(string text)
    {
        float height = this.m_Height;
        float width = this.m_Width;
        if (!this.m_RenderToTexture)
        {
            height = this.m_WorldHeight;
            width = this.m_WorldWidth;
        }
        float characterSize = this.m_TextMesh.characterSize;
        float lineSpacing = this.m_TextMesh.lineSpacing;
        if (!this.m_MultiLine)
        {
            this.SetLineSpacing(0f);
        }
        float x = this.m_TextMesh.renderer.bounds.size.x;
        float y = this.m_TextMesh.renderer.bounds.size.y;
        int num7 = 0;
        while ((y > height) || (x > width))
        {
            num7++;
            if (num7 > this.MAX_REDUCE_TEXT_COUNT)
            {
                break;
            }
            characterSize *= 0.9f;
            this.SetCharacterSize(characterSize);
            if (this.m_WordWrap)
            {
                this.SetText(this.WordWrapString(text, width));
            }
            x = this.m_TextMesh.renderer.bounds.size.x;
            y = this.m_TextMesh.renderer.bounds.size.y;
        }
        if (!this.m_MultiLine)
        {
            this.SetLineSpacing(lineSpacing);
        }
    }

    private int ReduceText_Optimized(string text)
    {
        if (this.m_FontSize < 6)
        {
            return this.m_FontSize;
        }
        int fontSize = this.m_FontSize;
        float height = this.m_Height;
        float width = this.m_Width;
        if (!this.m_RenderToTexture)
        {
            height = this.m_WorldHeight;
            width = this.m_WorldWidth;
        }
        float y = this.m_TextMesh.renderer.bounds.size.y;
        float x = this.m_TextMesh.renderer.bounds.size.x;
        if ((y < height) && (x < width))
        {
            return this.m_FontSize;
        }
        float lineSpacing = this.m_TextMesh.lineSpacing;
        if (!this.m_MultiLine)
        {
            this.SetLineSpacing(0f);
        }
        this.SetFontSize(this.m_FontSize - 5);
        float num7 = (y - this.m_TextMesh.renderer.bounds.size.y) / 5f;
        float num8 = (x - this.m_TextMesh.renderer.bounds.size.x) / 5f;
        this.SetFontSize(this.m_FontSize - 1);
        int num9 = 1;
        y -= num7;
        x -= num8;
        y = this.m_TextMesh.renderer.bounds.size.y;
        for (x = this.m_TextMesh.renderer.bounds.size.x; (y > height) || (x > width); x -= num8 * num9)
        {
            if (this.m_WordWrap)
            {
                this.SetText(this.WordWrapString(text, width));
            }
            num9++;
            if (num9 > this.m_FontSize)
            {
                break;
            }
            y -= num7 * num9;
        }
        fontSize = this.m_FontSize - num9;
        this.SetFontSize(fontSize);
        if (!this.m_MultiLine)
        {
            this.SetLineSpacing(lineSpacing);
        }
        return fontSize;
    }

    private string RemoveTagsFromWord(string word)
    {
        if (!this.m_TextMesh.richText)
        {
            return word;
        }
        if (!word.Contains("<"))
        {
            return word;
        }
        StringBuilder builder = new StringBuilder();
        bool flag = false;
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == '<')
            {
                if (word[i + 1] == 'q')
                {
                    if (!word.Substring(i).Contains(">"))
                    {
                        return builder.ToString();
                    }
                    int num2 = i + 1;
                    while (word[num2] != '>')
                    {
                        num2++;
                    }
                    builder.Append("W");
                    i = num2;
                }
                else
                {
                    flag = true;
                }
            }
            else if (word[i] == '>')
            {
                flag = false;
            }
            else if (!flag)
            {
                builder.Append(word[i]);
            }
        }
        return builder.ToString();
    }

    private void RenderText()
    {
        if (this.m_TextTexture != null)
        {
            if (this.m_TextTexture.IsCreated() && this.m_updated)
            {
                this.UpdateColor();
                return;
            }
        }
        else if (this.m_updated)
        {
            this.UpdateColor();
            return;
        }
        if (this.m_Font == null)
        {
            Debug.LogWarning(string.Format("UberText error: Font is null for {0}", base.gameObject.name));
        }
        else if (this.m_Text != null)
        {
            Vector2 worldWidthAndHight = this.GetWorldWidthAndHight();
            this.m_WorldWidth = worldWidthAndHight.x;
            this.m_WorldHeight = worldWidthAndHight.y;
            this.CreateTextMesh();
            if (this.m_TextMesh != null)
            {
                this.UpdateTextMesh();
                if (this.m_Outline)
                {
                    this.OutlineRender();
                }
                if (this.m_RenderToTexture)
                {
                    this.CreateCamera();
                    this.CreateTexture();
                    if (this.m_RenderOnObject != null)
                    {
                        this.SetupRenderOnObject();
                    }
                    else
                    {
                        this.CreateRenderPlane();
                    }
                    this.SetupForRender();
                    if (this.m_RenderOnObject == null)
                    {
                        this.ShadowRender();
                    }
                    this.UpdateTexelSize();
                    this.m_Camera.Render();
                    this.AntiAliasRender();
                }
                this.UpdateLayers();
                this.UpdateRenderQueue();
                this.UpdateColor();
                if (this.m_RenderOnObject != null)
                {
                    this.m_RenderOnObject.renderer.enabled = true;
                }
                this.m_PreviousText = this.m_Text;
                this.m_updated = true;
            }
        }
    }

    private void ResizeTextToFit(string text)
    {
        if ((text != null) && (text != string.Empty))
        {
            Quaternion rotation = this.m_TextMeshGameObject.transform.rotation;
            this.m_TextMeshGameObject.transform.rotation = Quaternion.identity;
            float width = this.m_Width;
            if (!this.m_RenderToTexture)
            {
                width = this.m_WorldWidth;
            }
            string str = this.RemoveTagsFromWord(text);
            if (str == null)
            {
                str = string.Empty;
            }
            this.SetText(str);
            if (this.m_WordWrap)
            {
                this.SetText(this.WordWrapString(text, width));
            }
            this.ReduceText_CharSize(text);
            this.m_TextMeshGameObject.transform.rotation = rotation;
            if (!this.m_WordWrap)
            {
                this.SetText(text);
            }
        }
    }

    private void SetCharacterSize(float characterSize)
    {
        if (this.m_TextMesh.characterSize != characterSize)
        {
            this.m_TextMesh.characterSize = characterSize;
        }
    }

    private void SetFont(Font font)
    {
        if (this.m_TextMesh.font != font)
        {
            this.m_TextMesh.font = font;
        }
    }

    private void SetFontSize(int fontSize)
    {
        if (this.m_TextMesh.fontSize != fontSize)
        {
            this.m_TextMesh.fontSize = fontSize;
        }
    }

    private void SetLineSpacing(float lineSpacing)
    {
        if (this.m_TextMesh.lineSpacing != lineSpacing)
        {
            this.m_TextMesh.lineSpacing = lineSpacing;
        }
    }

    private void SetManaTexture(string name, UnityEngine.Object obj, object callbackData)
    {
        s_InlineImageTexture = obj as Texture2D;
        s_InlineImageTextureLoaded = true;
        this.m_TextMesh.renderer.sharedMaterials[this.m_TextMaterialIndices[TextRenderMaterial.InlineImages]].mainTexture = s_InlineImageTexture;
    }

    private void SetRichText(bool richText)
    {
        if (this.m_TextMesh.richText != richText)
        {
            this.m_TextMesh.richText = richText;
        }
    }

    private void SetText(string text)
    {
        if (this.m_TextMesh.text != text)
        {
            this.m_TextMesh.text = text;
        }
    }

    private void SetupForRender()
    {
        if (this.m_RenderToTexture)
        {
            Vector3 vector = new Vector3(-3000f, 3000f, this.Offset);
            this.m_TextMeshGameObject.transform.parent = null;
            this.m_TextMeshGameObject.transform.position = vector;
            this.m_TextMeshGameObject.transform.rotation = Quaternion.identity;
            this.m_TextMeshGameObject.transform.localScale = Vector3.one;
            this.m_TextMeshGameObject.layer = RENDER_LAYER;
            float x = -3000f;
            if (this.Alignment == AlignmentOptions.Left)
            {
                x += this.m_Width * 0.5f;
            }
            if (this.Alignment == AlignmentOptions.Right)
            {
                x -= this.m_Width * 0.5f;
            }
            float num2 = 0f;
            if (this.m_Anchor == AnchorOptions.Upper)
            {
                num2 += this.m_Height * 0.5f;
            }
            if (this.m_Anchor == AnchorOptions.Lower)
            {
                num2 -= this.m_Height * 0.5f;
            }
            Vector3 vector2 = new Vector3(x, 3000f - num2, this.Offset);
            this.m_CameraGO.transform.parent = this.m_TextMeshGameObject.transform;
            this.m_CameraGO.transform.position = vector2;
            Color textColor = this.m_TextColor;
            if (this.m_Outline)
            {
                textColor = this.m_OutlineColor;
            }
            this.m_Camera.backgroundColor = new Color(textColor.r, textColor.g, textColor.b, 0f);
            this.m_Camera.orthographicSize = this.m_Height * 0.5f;
        }
        else
        {
            this.m_TextMeshGameObject.transform.parent = base.transform;
            this.m_TextMeshGameObject.transform.localPosition = Vector3.zero;
            this.m_CameraGO.transform.position = base.transform.position;
        }
    }

    private void SetupRenderOnObject()
    {
        if (this.m_RenderOnObject != null)
        {
            this.m_RenderOnObject.renderer.sharedMaterial = this.PlaneMaterial;
            this.m_RenderOnObject.renderer.sharedMaterial.mainTexture = this.m_TextTexture;
        }
    }

    private void ShadowRender()
    {
        if (!this.m_Shadow)
        {
            this.DestroyShadow();
        }
        else
        {
            if (this.m_ShadowPlaneGameObject != null)
            {
                UnityEngine.Object.DestroyImmediate(this.m_ShadowPlaneGameObject);
            }
            this.m_ShadowPlaneGameObject = new GameObject();
            this.m_ShadowPlaneGameObject.name = "UberText_ShadowPlane_" + base.name;
            this.m_ShadowPlaneGameObject.AddComponent<MeshFilter>();
            this.m_ShadowPlaneGameObject.AddComponent<MeshRenderer>();
            Mesh mesh = new Mesh();
            this.m_ShadowPlaneGameObject.hideFlags = HideFlags.HideAndDontSave;
            this.m_ShadowPlaneGameObject.transform.parent = this.m_PlaneGameObject.transform;
            this.m_ShadowPlaneGameObject.transform.localRotation = Quaternion.identity;
            this.m_ShadowPlaneGameObject.transform.localScale = Vector3.one;
            float x = -this.m_ShadowOffset * 0.01f;
            this.m_ShadowPlaneGameObject.transform.localPosition = new Vector3(x, 0f, x);
            float num2 = this.m_Width * 0.5f;
            float z = this.m_Height * 0.5f;
            mesh.vertices = new Vector3[] { new Vector3(-num2, 0f, -z), new Vector3(num2, 0f, -z), new Vector3(-num2, 0f, z), new Vector3(num2, 0f, z) };
            mesh.uv = this.PLANE_UVS;
            mesh.normals = this.PLANE_NORMALS;
            mesh.triangles = this.PLANE_TRIANGLES;
            Mesh mesh3 = mesh;
            this.m_ShadowPlaneGameObject.GetComponent<MeshFilter>().mesh = mesh3;
            mesh3.RecalculateBounds();
            this.m_ShadowPlaneGameObject.renderer.sharedMaterial = this.ShadowMaterial;
            this.m_ShadowMaterial.mainTexture = this.m_TextTexture;
            Vector2 texelSize = this.m_TextTexture.texelSize;
            this.m_ShadowMaterial.SetColor("_Color", this.m_ShadowColor);
            this.m_ShadowMaterial.SetFloat("_OffsetX", texelSize.x * this.m_ShadowBlur);
            this.m_ShadowMaterial.SetFloat("_OffsetY", texelSize.y * this.m_ShadowBlur);
        }
    }

    private void Start()
    {
        this.m_updated = false;
    }

    private int TextEffectsMaterial(TextRenderMaterial materialKey, Material material)
    {
        if (!this.m_TextMaterialIndices.ContainsKey(materialKey))
        {
            Material[] array = new Material[this.m_TextMesh.renderer.sharedMaterials.Length + 1];
            int index = array.Length - 1;
            this.m_TextMesh.renderer.sharedMaterials.CopyTo(array, 0);
            array[index] = material;
            this.m_TextMesh.renderer.sharedMaterials = array;
            this.m_TextMaterialIndices.Add(materialKey, index);
            return index;
        }
        return this.m_TextMaterialIndices[materialKey];
    }

    private void Update()
    {
        if ((this.m_RenderToTexture && (this.m_TextTexture != null)) && !this.m_TextTexture.IsCreated())
        {
            Log.Kyle.Print("UberText Texture lost 1. UpdateText Called");
            this.m_updated = false;
            this.RenderText();
        }
        else
        {
            this.RenderText();
            this.UpdateTexelSize();
        }
    }

    private void UpdateColor()
    {
        if (this.m_Outline)
        {
            if (this.m_OutlineTextMaterial != null)
            {
                this.m_OutlineTextMaterial.SetColor("_Color", this.m_TextColor);
                this.m_OutlineTextMaterial.SetColor("_OutlineColor", this.m_OutlineColor);
                this.m_OutlineTextMaterial.SetFloat("_LightingBlend", this.m_AmbientLightBlend);
            }
            if (this.m_BoldMaterial != null)
            {
                this.m_BoldMaterial.SetColor("_Color", this.m_TextColor);
                this.m_BoldMaterial.SetColor("_OutlineColor", this.m_OutlineColor);
                this.m_BoldMaterial.SetFloat("_LightingBlend", this.m_AmbientLightBlend);
            }
        }
        else
        {
            if (this.m_TextMaterial != null)
            {
                this.m_TextMaterial.SetColor("_Color", this.m_TextColor);
                this.m_TextMaterial.SetFloat("_LightingBlend", this.m_AmbientLightBlend);
            }
            if (this.m_BoldMaterial != null)
            {
                this.m_BoldMaterial.SetColor("_Color", this.m_TextColor);
                this.m_BoldMaterial.SetFloat("_LightingBlend", this.m_AmbientLightBlend);
            }
        }
        if (this.m_Shadow && (this.m_ShadowMaterial != null))
        {
            this.m_ShadowMaterial.SetColor("_Color", this.m_ShadowColor);
        }
        if (this.m_PlaneMesh != null)
        {
            this.m_PlaneMesh.colors = new Color[] { this.m_GradientLowerColor, this.m_GradientLowerColor, this.m_GradientUpperColor, this.m_GradientUpperColor };
        }
    }

    private void UpdateEditorText()
    {
    }

    private void UpdateFontTextures()
    {
        Texture mainTexture = this.m_Font.material.mainTexture;
        if (this.m_TextMaterial != null)
        {
            this.m_TextMaterial.mainTexture = mainTexture;
        }
        if (this.m_OutlineTextMaterial != null)
        {
            this.m_OutlineTextMaterial.mainTexture = mainTexture;
        }
        if (this.m_BoldMaterial != null)
        {
            this.m_BoldMaterial.mainTexture = mainTexture;
        }
    }

    private void UpdateLayers()
    {
        if (this.m_RenderToTexture)
        {
            this.m_TextMeshGameObject.layer = 0;
            if (this.m_PlaneGameObject != null)
            {
                this.m_PlaneGameObject.layer = base.gameObject.layer;
            }
        }
        else if (this.m_TextMeshGameObject != null)
        {
            this.m_TextMeshGameObject.layer = base.gameObject.layer;
        }
    }

    public void UpdateNow()
    {
        this.m_updated = false;
        this.RenderText();
    }

    private void UpdateRenderQueue()
    {
        GameObject renderOnObject;
        if (this.m_RenderToTexture)
        {
            if (this.m_RenderOnObject != null)
            {
                renderOnObject = this.m_RenderOnObject;
            }
            else
            {
                renderOnObject = this.m_PlaneGameObject;
            }
        }
        else
        {
            renderOnObject = this.m_TextMeshGameObject;
        }
        if (renderOnObject != null)
        {
            if (this.m_OrgRenderQueue == -9999)
            {
                this.m_OrgRenderQueue = renderOnObject.renderer.sharedMaterial.renderQueue;
            }
            foreach (Material material in renderOnObject.renderer.sharedMaterials)
            {
                material.renderQueue = this.m_OrgRenderQueue + this.m_RenderQueue;
            }
            if (this.m_Shadow && (this.m_ShadowPlaneGameObject != null))
            {
                this.m_ShadowPlaneGameObject.renderer.sharedMaterial.renderQueue = renderOnObject.renderer.sharedMaterial.renderQueue - 1;
            }
        }
    }

    private void UpdateTexelSize()
    {
        Vector2 texelSize = this.m_Font.material.mainTexture.texelSize;
        if (texelSize != this.m_PreviousTexelSize)
        {
            if (this.m_BoldMaterial != null)
            {
                this.m_BoldMaterial.SetFloat("_BoldOffsetX", this.m_BoldSize * texelSize.x);
                this.m_BoldMaterial.SetFloat("_BoldOffsetY", this.m_BoldSize * texelSize.y);
            }
            if (this.m_Outline && !this.m_RenderToTexture)
            {
                if (this.m_OutlineTextMaterial != null)
                {
                    this.m_OutlineTextMaterial.SetFloat("_OutlineOffsetX", texelSize.x * this.m_OutlineSize);
                    this.m_OutlineTextMaterial.SetFloat("_OutlineOffsetY", texelSize.y * this.m_OutlineSize);
                    this.m_OutlineTextMaterial.SetFloat("_TexelSizeX", texelSize.x);
                    this.m_OutlineTextMaterial.SetFloat("_TexelSizeY", texelSize.y);
                }
                if (this.m_BoldMaterial != null)
                {
                    this.m_BoldMaterial.SetFloat("_BoldOffsetX", this.m_BoldSize * texelSize.x);
                    this.m_BoldMaterial.SetFloat("_BoldOffsetY", this.m_BoldSize * texelSize.y);
                    this.m_BoldMaterial.SetFloat("_OutlineOffsetX", texelSize.x * this.m_OutlineSize);
                    this.m_BoldMaterial.SetFloat("_OutlineOffsetY", texelSize.y * this.m_OutlineSize);
                }
            }
            if (this.m_Shadow && this.m_RenderToTexture)
            {
                if (this.m_ShadowMaterial != null)
                {
                    this.m_ShadowMaterial.SetFloat("_OffsetX", texelSize.x * this.m_ShadowBlur);
                }
                this.m_ShadowMaterial.SetFloat("_OffsetY", texelSize.y * this.m_ShadowBlur);
            }
            if ((this.m_AntiAlias && this.m_RenderToTexture) && (this.m_TextAntialiasingMaterial != null))
            {
                this.m_TextAntialiasingMaterial.SetFloat("_OffsetX", texelSize.x * this.m_AntiAliasAmount);
                this.m_TextAntialiasingMaterial.SetFloat("_OffsetY", texelSize.y * this.m_AntiAliasAmount);
            }
            this.m_PreviousTexelSize = texelSize;
        }
    }

    public void UpdateText()
    {
        this.m_updated = false;
    }

    private void UpdateTextMesh()
    {
        Quaternion rotation = base.transform.rotation;
        base.transform.rotation = Quaternion.identity;
        string text = this.ProcessText(this.m_Text);
        this.m_MultiLine = this.isTextMultiLine(text);
        if (this.m_WordWrap && !this.m_ResizeToFit)
        {
            this.SetText(this.WordWrapString(text, this.m_WorldWidth));
        }
        else
        {
            this.SetText(text);
        }
        this.m_TextMesh.renderer.enabled = true;
        this.SetFont(this.m_Font);
        this.SetFontSize(this.m_FontSize);
        this.SetLineSpacing(this.m_LineSpacing);
        this.SetCharacterSize(this.m_CharacterSize * this.CHARACTER_SIZE_SCALE);
        switch (this.m_Alignment)
        {
            case AlignmentOptions.Left:
                this.m_TextMesh.alignment = TextAlignment.Left;
                switch (this.m_Anchor)
                {
                    case AnchorOptions.Upper:
                        this.m_TextMesh.transform.localPosition = new Vector3(-this.m_Width * 0.5f, this.m_Height * 0.5f, 0f);
                        this.m_TextMesh.anchor = TextAnchor.UpperLeft;
                        break;

                    case AnchorOptions.Middle:
                        this.m_TextMesh.transform.localPosition = new Vector3(-this.m_Width * 0.5f, 0f, 0f);
                        this.m_TextMesh.anchor = TextAnchor.MiddleLeft;
                        break;

                    case AnchorOptions.Lower:
                        this.m_TextMesh.transform.localPosition = new Vector3(-this.m_Width * 0.5f, -this.m_Height * 0.5f, 0f);
                        this.m_TextMesh.anchor = TextAnchor.LowerLeft;
                        break;
                }
                break;

            case AlignmentOptions.Center:
                this.m_TextMesh.alignment = TextAlignment.Center;
                switch (this.m_Anchor)
                {
                    case AnchorOptions.Upper:
                        this.m_TextMesh.transform.localPosition = new Vector3(0f, this.m_Height * 0.5f, 0f);
                        this.m_TextMesh.anchor = TextAnchor.UpperCenter;
                        break;

                    case AnchorOptions.Middle:
                        this.m_TextMesh.transform.localPosition = new Vector3(0f, 0f, 0f);
                        this.m_TextMesh.anchor = TextAnchor.MiddleCenter;
                        break;

                    case AnchorOptions.Lower:
                        this.m_TextMesh.transform.localPosition = new Vector3(0f, -this.m_Height * 0.5f, 0f);
                        this.m_TextMesh.anchor = TextAnchor.LowerCenter;
                        break;
                }
                break;

            case AlignmentOptions.Right:
                this.m_TextMesh.alignment = TextAlignment.Right;
                switch (this.m_Anchor)
                {
                    case AnchorOptions.Upper:
                        this.m_TextMesh.transform.localPosition = new Vector3(this.m_Width * 0.5f, this.m_Height * 0.5f, 0f);
                        this.m_TextMesh.anchor = TextAnchor.UpperRight;
                        break;

                    case AnchorOptions.Middle:
                        this.m_TextMesh.transform.localPosition = new Vector3(this.m_Width * 0.5f, 0f, 0f);
                        this.m_TextMesh.anchor = TextAnchor.MiddleRight;
                        break;

                    case AnchorOptions.Lower:
                        this.m_TextMesh.transform.localPosition = new Vector3(this.m_Width * 0.5f, -this.m_Height * 0.5f, 0f);
                        this.m_TextMesh.anchor = TextAnchor.LowerRight;
                        break;
                }
                break;
        }
        if (this.m_ResizeToFit)
        {
            this.ResizeTextToFit(text);
        }
        base.transform.rotation = rotation;
    }

    private string WordWrapString(string text, float width)
    {
        float num = 0f;
        float num2 = 0f;
        if (this.m_Underwear)
        {
            num = this.m_WorldHeight * (1f - this.m_UnderwearHeight);
            num2 = width * (1f - this.m_UnderwearWidth);
        }
        Quaternion rotation = this.m_TextMeshGameObject.transform.rotation;
        this.m_TextMeshGameObject.transform.rotation = Quaternion.identity;
        StringBuilder builder = new StringBuilder();
        StringBuilder builder2 = new StringBuilder();
        string[] strArray = this.BreakTextIntoWords(text);
        if (!this.m_ResizeToFit && this.m_ForceWrapLargeWords)
        {
            List<string> list = new List<string>();
            foreach (string str in strArray)
            {
                this.SetText(str);
                float x = this.m_TextMesh.renderer.bounds.size.x;
                if (x < width)
                {
                    list.Add(str);
                }
                else
                {
                    int num5 = Mathf.CeilToInt(x / width);
                    int start = 0;
                    int end = 1;
                    for (int i = 0; i < num5; i++)
                    {
                        this.SetText(str.Slice(start, end));
                        while ((this.m_TextMesh.renderer.bounds.size.x < width) && (end < str.Length))
                        {
                            end++;
                            this.SetText(str.Slice(start, end));
                        }
                        list.Add(str.Slice(start, end - 1));
                        start = end - 1;
                    }
                    list.Add(str.Slice(start, str.Length));
                }
            }
            strArray = list.ToArray();
        }
        int num9 = 0;
        if (text.Contains("\n"))
        {
            foreach (char ch in text)
            {
                if (ch == '\n')
                {
                    num9++;
                }
            }
        }
        foreach (string str3 in strArray)
        {
            string str4 = str3;
            if (str3.Contains("<"))
            {
                str4 = this.RemoveTagsFromWord(str3);
            }
            builder2.Append(str4);
            string str5 = builder2.ToString();
            if (str5 == null)
            {
                Debug.LogWarning("UberText: actualLine is null in WordWrapString!");
                str5 = string.Empty;
            }
            this.SetText(str5);
            float num12 = this.m_TextMesh.renderer.bounds.size.x;
            if (this.m_Underwear && (this.m_TextMesh.renderer.bounds.size.y > num))
            {
                width = num2;
            }
            if (num12 < width)
            {
                builder.Append(str3);
            }
            else
            {
                num9++;
                builder.Append('\n');
                char[] trimChars = new char[] { ' ' };
                builder.Append(str3.TrimStart(trimChars));
                builder2 = new StringBuilder();
                for (int j = 0; j < num9; j++)
                {
                    builder2.Append("\n");
                }
                builder2.Append(str4);
                this.m_MultiLine = true;
            }
        }
        this.m_TextMeshGameObject.transform.rotation = rotation;
        string str6 = builder.ToString();
        if (str6 == null)
        {
            Debug.LogWarning("UberText: Word Wrap returned a null string!");
            str6 = string.Empty;
        }
        return str6;
    }

    public AlignmentOptions Alignment
    {
        get
        {
            return this.m_Alignment;
        }
        set
        {
            this.m_Alignment = value;
            this.UpdateText();
        }
    }

    public float AmbientLightBlend
    {
        get
        {
            return this.m_AmbientLightBlend;
        }
        set
        {
            this.m_AmbientLightBlend = value;
            this.UpdateText();
        }
    }

    public AnchorOptions Anchor
    {
        get
        {
            return this.m_Anchor;
        }
        set
        {
            this.m_Anchor = value;
            this.UpdateText();
        }
    }

    public bool AntiAlias
    {
        get
        {
            return this.m_AntiAlias;
        }
        set
        {
            this.m_AntiAlias = value;
            this.UpdateText();
        }
    }

    public float AntiAliasAmount
    {
        get
        {
            return this.m_AntiAliasAmount;
        }
        set
        {
            this.m_AntiAliasAmount = value;
            this.UpdateText();
        }
    }

    public float AntiAliasEdge
    {
        get
        {
            return this.m_AntiAliasEdge;
        }
        set
        {
            this.m_AntiAliasEdge = value;
            this.UpdateText();
        }
    }

    protected Material BoldMaterial
    {
        get
        {
            if (this.m_BoldMaterial == null)
            {
                if (this.m_BoldShader == null)
                {
                    this.m_BoldShader = Shader.Find(this.BOLD_SHADER_NAME);
                    if (this.m_BoldShader == null)
                    {
                        Debug.LogError("UberText Failed to load Shader: " + this.BOLD_SHADER_NAME);
                    }
                }
                this.m_BoldMaterial = new Material(this.m_BoldShader);
                this.m_BoldMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_BoldMaterial;
        }
    }

    public float BoldSize
    {
        get
        {
            return this.m_BoldSize;
        }
        set
        {
            this.m_BoldSize = value;
            this.UpdateText();
        }
    }

    public float CharacterSize
    {
        get
        {
            return this.m_CharacterSize;
        }
        set
        {
            this.m_CharacterSize = value;
            this.UpdateText();
        }
    }

    public int FontSize
    {
        get
        {
            return this.m_FontSize;
        }
        set
        {
            this.m_FontSize = value;
            if (this.m_FontSize < 1)
            {
                this.m_FontSize = 1;
            }
            if (this.m_FontSize > 120)
            {
                this.m_FontSize = 120;
            }
            this.UpdateText();
        }
    }

    public bool ForceWrapLargeWords
    {
        get
        {
            return this.m_ForceWrapLargeWords;
        }
        set
        {
            this.m_ForceWrapLargeWords = value;
            this.UpdateText();
        }
    }

    public float GradientLowerAlpha
    {
        get
        {
            return this.m_GradientLowerColor.a;
        }
        set
        {
            this.m_GradientLowerColor.a = value;
            this.UpdateColor();
        }
    }

    public Color GradientLowerColor
    {
        get
        {
            return this.m_GradientLowerColor;
        }
        set
        {
            this.m_GradientLowerColor = value;
            this.UpdateColor();
        }
    }

    public float GradientUpperAlpha
    {
        get
        {
            return this.m_GradientUpperColor.a;
        }
        set
        {
            this.m_GradientUpperColor.a = value;
            this.UpdateColor();
        }
    }

    public Color GradientUpperColor
    {
        get
        {
            return this.m_GradientUpperColor;
        }
        set
        {
            this.m_GradientUpperColor = value;
            this.UpdateColor();
        }
    }

    public float Height
    {
        get
        {
            return this.m_Height;
        }
        set
        {
            this.m_Height = value;
            if (this.m_Height < 0.01f)
            {
                this.m_Height = 0.01f;
            }
            this.UpdateText();
        }
    }

    protected Material InlineImageMaterial
    {
        get
        {
            if (this.m_InlineImageMaterial == null)
            {
                if (this.m_InlineImageShader == null)
                {
                    this.m_InlineImageShader = Shader.Find(this.INLINE_IMAGE_SHADER_NAME);
                    if (this.m_InlineImageShader == null)
                    {
                        Debug.LogError("UberText Failed to load Shader: " + this.INLINE_IMAGE_SHADER_NAME);
                    }
                }
                this.m_InlineImageMaterial = new Material(this.m_InlineImageShader);
                this.m_InlineImageMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_InlineImageMaterial;
        }
    }

    public float LineSpacing
    {
        get
        {
            return this.m_LineSpacing;
        }
        set
        {
            this.m_LineSpacing = value;
            this.UpdateText();
        }
    }

    public int MinFontSize
    {
        get
        {
            return this.m_MinFontSize;
        }
        set
        {
            this.m_MinFontSize = value;
            if (this.m_MinFontSize < 1)
            {
                this.m_MinFontSize = 1;
            }
            if (this.m_MinFontSize > this.m_FontSize)
            {
                this.m_MinFontSize = this.m_FontSize;
            }
            this.UpdateText();
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

    public bool Outline
    {
        get
        {
            return this.m_Outline;
        }
        set
        {
            this.m_Outline = value;
            this.UpdateText();
        }
    }

    public float OutlineAlpha
    {
        get
        {
            return this.m_OutlineColor.a;
        }
        set
        {
            this.m_OutlineColor.a = value;
            this.UpdateColor();
        }
    }

    public Color OutlineColor
    {
        get
        {
            return this.m_OutlineColor;
        }
        set
        {
            this.m_OutlineColor = value;
            this.UpdateColor();
        }
    }

    public float OutlineSize
    {
        get
        {
            return this.m_OutlineSize;
        }
        set
        {
            this.m_OutlineSize = value;
            this.UpdateText();
        }
    }

    protected Material OutlineTextMaterial
    {
        get
        {
            if (this.m_OutlineTextMaterial == null)
            {
                if (this.m_OutlineTextShader == null)
                {
                    this.m_OutlineTextShader = Shader.Find(this.OUTLINE_TEXT_SHADER_NAME);
                    if (this.m_OutlineTextShader == null)
                    {
                        Debug.LogError("UberText Failed to load Shader: " + this.OUTLINE_TEXT_SHADER_NAME);
                    }
                }
                this.m_OutlineTextMaterial = new Material(this.m_OutlineTextShader);
                this.m_OutlineTextMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_OutlineTextMaterial;
        }
    }

    protected Material PlaneMaterial
    {
        get
        {
            if (this.m_PlaneMaterial == null)
            {
                if (this.m_PlaneShader == null)
                {
                    this.m_PlaneShader = Shader.Find(this.PLANE_SHADER_NAME);
                    if (this.m_PlaneShader == null)
                    {
                        Debug.LogError("UberText Failed to load Shader: " + this.PLANE_SHADER_NAME);
                    }
                }
                this.m_PlaneMaterial = new Material(this.m_PlaneShader);
                this.m_PlaneMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_PlaneMaterial;
        }
    }

    public GameObject RenderOnObject
    {
        get
        {
            return this.m_RenderOnObject;
        }
        set
        {
            this.m_RenderOnObject = value;
            this.UpdateText();
        }
    }

    public int RenderQueue
    {
        get
        {
            return this.m_RenderQueue;
        }
        set
        {
            this.m_RenderQueue = value;
            this.UpdateText();
        }
    }

    public bool RenderToTexture
    {
        get
        {
            return this.m_RenderToTexture;
        }
        set
        {
            this.m_RenderToTexture = value;
            this.UpdateText();
        }
    }

    public bool ResizeToFit
    {
        get
        {
            return this.m_ResizeToFit;
        }
        set
        {
            this.m_ResizeToFit = value;
            this.UpdateText();
        }
    }

    public bool RichText
    {
        get
        {
            return this.m_RichText;
        }
        set
        {
            this.m_RichText = value;
            this.UpdateText();
        }
    }

    public bool Shadow
    {
        get
        {
            return this.m_Shadow;
        }
        set
        {
            this.m_Shadow = value;
            this.UpdateText();
        }
    }

    public float ShadowAlpha
    {
        get
        {
            return this.m_ShadowColor.a;
        }
        set
        {
            this.m_ShadowColor.a = value;
            this.UpdateColor();
        }
    }

    public float ShadowBlur
    {
        get
        {
            return this.m_ShadowBlur;
        }
        set
        {
            this.m_ShadowBlur = value;
            this.UpdateText();
        }
    }

    public Color ShadowColor
    {
        get
        {
            return this.m_ShadowColor;
        }
        set
        {
            this.m_ShadowColor = value;
            this.UpdateColor();
        }
    }

    protected Material ShadowMaterial
    {
        get
        {
            if (this.m_ShadowMaterial == null)
            {
                if (this.m_ShadowTextShader == null)
                {
                    this.m_ShadowTextShader = Shader.Find(this.SHADOW_SHADER_NAME);
                    if (this.m_ShadowTextShader == null)
                    {
                        Debug.LogError("UberText Failed to load Shader: " + this.SHADOW_SHADER_NAME);
                    }
                }
                this.m_ShadowMaterial = new Material(this.m_ShadowTextShader);
                this.m_ShadowMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_ShadowMaterial;
        }
    }

    public float ShadowOffset
    {
        get
        {
            return this.m_ShadowOffset;
        }
        set
        {
            this.m_ShadowOffset = value;
            this.UpdateText();
        }
    }

    public string Text
    {
        get
        {
            return this.m_Text;
        }
        set
        {
            // This item is obfuscated and can not be translated.
            if (value != null)
            {
                goto Label_000E;
            }
            this.m_Text = string.Empty;
            if (this.m_Text != this.m_PreviousText)
            {
                this.UpdateNow();
            }
        }
    }

    public float TextAlpha
    {
        get
        {
            return this.m_TextColor.a;
        }
        set
        {
            this.m_TextColor.a = value;
            this.UpdateColor();
        }
    }

    protected Material TextAntialiasingMaterial
    {
        get
        {
            if (this.m_TextAntialiasingMaterial == null)
            {
                if (this.m_AntialiasingTextShader == null)
                {
                    this.m_AntialiasingTextShader = Shader.Find(this.TEXT_ANTIALAISING_SHADER_NAME);
                    if (this.m_AntialiasingTextShader == null)
                    {
                        Debug.LogError("UberText Failed to load Shader: " + this.TEXT_ANTIALAISING_SHADER_NAME);
                    }
                }
                this.m_TextAntialiasingMaterial = new Material(this.m_AntialiasingTextShader);
                this.m_TextAntialiasingMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_TextAntialiasingMaterial;
        }
    }

    public Color TextColor
    {
        get
        {
            return this.m_TextColor;
        }
        set
        {
            this.m_TextColor = value;
            this.UpdateColor();
        }
    }

    protected Material TextMaterial
    {
        get
        {
            if (this.m_TextMaterial == null)
            {
                if (this.m_TextShader == null)
                {
                    this.m_TextShader = Shader.Find(this.TEXT_SHADER_NAME);
                    if (this.m_TextShader == null)
                    {
                        Debug.LogError("UberText Failed to load Shader: " + this.TEXT_SHADER_NAME);
                    }
                }
                this.m_TextMaterial = new Material(this.m_TextShader);
                this.m_TextMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_TextMaterial;
        }
    }

    public int TextureResolution
    {
        get
        {
            return this.m_Resolution;
        }
        set
        {
            this.m_Resolution = value;
            this.UpdateText();
        }
    }

    public Font TrueTypeFont
    {
        get
        {
            return this.m_Font;
        }
        set
        {
            this.m_Font = value;
            this.UpdateText();
        }
    }

    public bool Underwear
    {
        get
        {
            return this.m_Underwear;
        }
        set
        {
            this.m_Underwear = value;
            this.UpdateText();
        }
    }

    public float UnderwearHeight
    {
        get
        {
            return this.m_UnderwearHeight;
        }
        set
        {
            this.m_UnderwearHeight = value;
            this.UpdateText();
        }
    }

    public float UnderwearWidth
    {
        get
        {
            return this.m_UnderwearWidth;
        }
        set
        {
            this.m_UnderwearWidth = value;
            this.UpdateText();
        }
    }

    public float Width
    {
        get
        {
            return this.m_Width;
        }
        set
        {
            this.m_Width = value;
            if (this.m_Width < 0.01f)
            {
                this.m_Width = 0.01f;
            }
            this.UpdateText();
        }
    }

    public bool WordWrap
    {
        get
        {
            return this.m_WordWrap;
        }
        set
        {
            this.m_WordWrap = value;
            this.UpdateText();
        }
    }

    public enum AlignmentOptions
    {
        Left,
        Center,
        Right
    }

    public enum AnchorOptions
    {
        Upper,
        Middle,
        Lower
    }

    private enum TextRenderMaterial
    {
        Text,
        Bold,
        Outline,
        InlineImages
    }
}

