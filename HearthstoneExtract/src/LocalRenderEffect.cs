using System;
using UnityEngine;

public class LocalRenderEffect : MonoBehaviour
{
    private readonly string ADDITIVE_SHADER_NAME = "Hero/Additive";
    private readonly string BLOOM_SHADER_NAME = "Hidden/LocalRenderBloom";
    private readonly string BLUR_SHADER_NAME = "Hidden/LocalRenderBlur";
    private Material m_AdditiveMaterial;
    private Shader m_AdditiveShader;
    private Material m_BloomMaterial;
    private Shader m_BloomShader;
    public float m_BlurAmount = 0.6f;
    private Material m_BlurMaterial;
    private Shader m_BlurShader;
    private Camera m_Camera;
    private GameObject m_CameraGO;
    public Color m_Color = Color.gray;
    public float m_Depth = 5f;
    public localRenderEffects m_Effect;
    public float m_Height = 1f;
    public LayerMask m_LayerMask = -1;
    private GameObject m_PlaneGameObject;
    private Mesh m_PlaneMesh;
    private float m_PreviousHeight;
    private float m_PreviousWidth;
    private RenderTexture m_RenderTexture;
    public int m_Resolution = 0x80;
    public float m_Width = 1f;
    private readonly Vector3[] PLANE_NORMALS = new Vector3[] { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
    private readonly int[] PLANE_TRIANGLES = new int[] { 3, 1, 2, 2, 1, 0 };
    private readonly Vector2[] PLANE_UVS = new Vector2[] { new Vector2(0f, 0f), new Vector2(1f, 0f), new Vector2(0f, 1f), new Vector2(1f, 1f) };
    private readonly float RENDER_PLANE_OFFSET = 0.05f;

    private Vector2 CalcTextureSize()
    {
        float num = this.m_Height / this.m_Width;
        return new Vector2((float) this.m_Resolution, this.m_Resolution * num);
    }

    private void CreateCamera()
    {
        if (this.m_Camera == null)
        {
            this.m_CameraGO = new GameObject();
            this.m_Camera = this.m_CameraGO.AddComponent<Camera>();
            this.m_CameraGO.name = base.name + "_TextRenderCamera";
            this.m_CameraGO.hideFlags = HideFlags.HideAndDontSave;
            this.m_Camera.orthographic = true;
            this.m_CameraGO.transform.parent = base.transform;
            this.m_CameraGO.transform.rotation = Quaternion.identity;
            this.m_CameraGO.transform.position = base.transform.position;
            this.m_CameraGO.transform.Rotate((float) 90f, 0f, (float) 0f);
            this.m_Camera.nearClipPlane = 0f;
            this.m_Camera.farClipPlane = this.m_Depth;
            this.m_Camera.depth = Camera.main.depth - 1f;
            this.m_Camera.backgroundColor = new Color(0f, 0f, 0f, 0f);
            this.m_Camera.clearFlags = CameraClearFlags.Color;
            this.m_Camera.depthTextureMode = DepthTextureMode.None;
            this.m_Camera.renderingPath = RenderingPath.Forward;
            this.m_Camera.cullingMask = (int) this.m_LayerMask;
            this.m_Camera.targetTexture = this.m_RenderTexture;
            this.m_Camera.enabled = false;
            this.m_Camera.orthographicSize = Mathf.Min((float) (this.m_Width * 0.5f), (float) (this.m_Height * 0.5f));
        }
    }

    private void CreateRenderPlane()
    {
        if ((this.m_Width != this.m_PreviousWidth) || (this.m_Height != this.m_PreviousHeight))
        {
            if (this.m_PlaneGameObject != null)
            {
                UnityEngine.Object.Destroy(this.m_PlaneGameObject);
            }
            this.m_PlaneGameObject = base.gameObject;
            this.m_PlaneGameObject.AddComponent<MeshFilter>();
            this.m_PlaneGameObject.AddComponent<MeshRenderer>();
            Mesh mesh = new Mesh {
                name = "TextMeshPlane"
            };
            float x = this.m_Width * 0.5f;
            float z = this.m_Height * 0.5f;
            mesh.vertices = new Vector3[] { new Vector3(-x, this.RENDER_PLANE_OFFSET, -z), new Vector3(x, this.RENDER_PLANE_OFFSET, -z), new Vector3(-x, this.RENDER_PLANE_OFFSET, z), new Vector3(x, this.RENDER_PLANE_OFFSET, z) };
            mesh.uv = this.PLANE_UVS;
            mesh.normals = this.PLANE_NORMALS;
            mesh.triangles = this.PLANE_TRIANGLES;
            Mesh mesh2 = mesh;
            this.m_PlaneGameObject.GetComponent<MeshFilter>().mesh = mesh2;
            this.m_PlaneMesh = mesh2;
            this.m_PlaneMesh.RecalculateBounds();
            this.BloomMaterial.mainTexture = this.m_RenderTexture;
            this.m_PlaneGameObject.renderer.sharedMaterial = this.AdditiveMaterial;
            this.m_PreviousWidth = this.m_Width;
            this.m_PreviousHeight = this.m_Height;
        }
    }

    private void CreateTexture()
    {
        if (this.m_RenderTexture == null)
        {
            Vector2 vector = this.CalcTextureSize();
            this.m_RenderTexture = new RenderTexture((int) vector.x, (int) vector.y, 0x20, RenderTextureFormat.ARGB32);
        }
    }

    protected void OnDestroy()
    {
        if (this.m_Camera != null)
        {
            this.m_Camera.targetTexture = null;
            this.m_Camera.enabled = false;
            UnityEngine.Object.Destroy(this.m_Camera);
            UnityEngine.Object.Destroy(this.m_CameraGO);
        }
        RenderTexture.active = null;
        if (this.m_BloomMaterial == null)
        {
            UnityEngine.Object.Destroy(this.m_BloomMaterial);
        }
        if (this.m_BlurMaterial == null)
        {
            UnityEngine.Object.Destroy(this.m_BlurMaterial);
        }
        if (this.m_AdditiveMaterial == null)
        {
            UnityEngine.Object.Destroy(this.m_AdditiveMaterial);
        }
        if (this.m_RenderTexture != null)
        {
            UnityEngine.Object.Destroy(this.m_RenderTexture);
        }
    }

    private void OnDrawGizmos()
    {
        if (this.m_Depth < 0f)
        {
            this.m_Depth = 0f;
        }
        Vector3 center = new Vector3(base.transform.position.x, base.transform.position.y - (this.m_Depth * 0.5f), base.transform.position.z);
        Gizmos.DrawWireCube(center, new Vector3(this.m_Width, this.m_Depth, this.m_Height));
    }

    public void Render()
    {
        if ((this.m_Effect == localRenderEffects.Bloom) || (this.m_Effect == localRenderEffects.Blur))
        {
            RenderTexture source = RenderTexture.GetTemporary(this.m_RenderTexture.width, this.m_RenderTexture.height, this.m_RenderTexture.depth, this.m_RenderTexture.format);
            this.m_Camera.targetTexture = source;
            this.m_Camera.Render();
            this.Sample(source, this.m_RenderTexture, this.BlurMaterial, this.m_BlurAmount);
            RenderTexture.ReleaseTemporary(source);
            this.m_PlaneGameObject.renderer.sharedMaterial = this.BloomMaterial;
            this.m_PlaneGameObject.renderer.sharedMaterial.SetColor("_TintColor", this.m_Color);
            this.m_PlaneGameObject.renderer.sharedMaterial.mainTexture = this.m_RenderTexture;
        }
        else
        {
            this.m_Camera.targetTexture = this.m_RenderTexture;
            this.m_Camera.Render();
        }
    }

    private void Sample(RenderTexture source, RenderTexture dest, Material sampleMat, float offset)
    {
        Vector2[] offsets = new Vector2[] { new Vector2(-offset, -offset), new Vector2(-offset, offset), new Vector2(offset, offset), new Vector2(offset, -offset) };
        Graphics.BlitMultiTap(source, dest, sampleMat, offsets);
    }

    protected void Start()
    {
        this.m_BloomShader = Shader.Find(this.BLOOM_SHADER_NAME);
        if (this.m_BloomShader == null)
        {
            Debug.LogError("Failed to load Local Rendering Effect Shader: " + this.BLOOM_SHADER_NAME);
        }
        this.m_BlurShader = Shader.Find(this.BLUR_SHADER_NAME);
        if (this.m_BlurShader == null)
        {
            Debug.LogError("Failed to load Local Rendering Effect Shader: " + this.BLUR_SHADER_NAME);
        }
        this.m_AdditiveShader = Shader.Find(this.ADDITIVE_SHADER_NAME);
        if (this.m_AdditiveShader == null)
        {
            Debug.LogError("Failed to load Local Rendering Effect Shader: " + this.ADDITIVE_SHADER_NAME);
        }
        this.CreateTexture();
        this.CreateCamera();
        this.CreateRenderPlane();
    }

    protected void Update()
    {
        this.Render();
    }

    protected Material AdditiveMaterial
    {
        get
        {
            if (this.m_AdditiveMaterial == null)
            {
                this.m_AdditiveMaterial = new Material(this.m_AdditiveShader);
                this.m_AdditiveMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_AdditiveMaterial;
        }
    }

    protected Material BloomMaterial
    {
        get
        {
            if (this.m_BloomMaterial == null)
            {
                this.m_BloomMaterial = new Material(this.m_BloomShader);
                this.m_BloomMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_BloomMaterial;
        }
    }

    protected Material BlurMaterial
    {
        get
        {
            if (this.m_BlurMaterial == null)
            {
                this.m_BlurMaterial = new Material(this.m_BlurShader);
                this.m_BlurMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_BlurMaterial;
        }
    }
}

