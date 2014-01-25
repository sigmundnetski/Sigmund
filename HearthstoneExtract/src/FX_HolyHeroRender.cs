using System;
using UnityEngine;

public class FX_HolyHeroRender : MonoBehaviour
{
    public float AboveClip = 0.4f;
    public float BelowClip = 0.4f;
    public int BlurIterations = 2;
    private static string blurMatString = "Shader \"BlurConeTap\" {\n\tProperties { _MainTex (\"\", any) = \"\" {} }\n\tSubShader {\n\t\tPass {\n\t\t\tZTest Always Cull Off ZWrite Off Fog { Mode Off }\n\t\t\tSetTexture [_MainTex] {constantColor (0,0,0,0.25) combine texture * constant alpha}\n\t\t\tSetTexture [_MainTex] {constantColor (0,0,0,0.25) combine texture * constant + previous}\n\t\t\tSetTexture [_MainTex] {constantColor (0,0,0,0.25) combine texture * constant + previous}\n\t\t\tSetTexture [_MainTex] {constantColor (0,0,0,0.25) combine texture * constant + previous}\n\t\t}\n\t}\n\tFallback off\n}";
    public float BlurSpread = 0.1f;
    private Camera heroCamera;
    private GameObject heroCameraGO;
    private const int IgnoreLayer = 0x15;
    private static Material m_Material;
    public int RenderResolutionX = 0x100;
    public int RenderResolutionY = 0x100;
    private RenderTexture tempRenderBuffer;

    private void BlurImage(RenderTexture source, RenderTexture destination, int iterations, float spread)
    {
        RenderTexture dest = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
        RenderTexture texture2 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
        this.DownSample4x(source, dest);
        bool flag = true;
        for (int i = 0; i < iterations; i++)
        {
            if (flag)
            {
                this.FourTapCone(dest, texture2, i, spread);
            }
            else
            {
                this.FourTapCone(texture2, dest, i, spread);
            }
            flag = !flag;
        }
        if (flag)
        {
            Graphics.Blit(dest, destination);
        }
        else
        {
            Graphics.Blit(texture2, destination);
        }
        RenderTexture.ReleaseTemporary(dest);
        RenderTexture.ReleaseTemporary(texture2);
    }

    private void CameraRender()
    {
        this.heroCamera.Render();
        this.BlurImage(this.tempRenderBuffer, this.tempRenderBuffer, this.BlurIterations, this.BlurSpread);
    }

    private void CreateCamera()
    {
        if (this.heroCameraGO == null)
        {
            if (this.heroCamera != null)
            {
                UnityEngine.Object.DestroyImmediate(this.heroCamera);
            }
            this.heroCameraGO = new GameObject();
            this.heroCamera = this.heroCameraGO.AddComponent<Camera>();
            this.heroCameraGO.name = base.name + "_HeroFXCamera";
            this.heroCameraGO.hideFlags = HideFlags.HideAndDontSave;
        }
    }

    private void CreateRenderTexture()
    {
        this.tempRenderBuffer = RenderTexture.GetTemporary(this.RenderResolutionX, this.RenderResolutionY);
    }

    private void DownSample4x(RenderTexture source, RenderTexture dest)
    {
        float y = 1f;
        Vector2[] offsets = new Vector2[] { new Vector2(-y, -y), new Vector2(-y, y), new Vector2(y, y), new Vector2(y, -y) };
        Graphics.BlitMultiTap(source, dest, material, offsets);
    }

    public void FourTapCone(RenderTexture source, RenderTexture dest, int iteration, float spread)
    {
        float y = 0.5f + (iteration * spread);
        Vector2[] offsets = new Vector2[] { new Vector2(-y, -y), new Vector2(-y, y), new Vector2(y, y), new Vector2(y, -y) };
        Graphics.BlitMultiTap(source, dest, material, offsets);
    }

    private void OnDestroy()
    {
    }

    private void SetupCamera()
    {
        this.heroCamera.orthographic = true;
        this.UpdateOffScreenCamera();
        this.heroCamera.transform.parent = base.transform;
        this.heroCamera.nearClipPlane = -this.AboveClip;
        this.heroCamera.farClipPlane = this.BelowClip;
        this.heroCamera.targetTexture = this.tempRenderBuffer;
        this.heroCamera.depth = Camera.main.depth - 1f;
        this.heroCamera.backgroundColor = Color.black;
        this.heroCamera.clearFlags = CameraClearFlags.Color;
        this.heroCamera.cullingMask &= -2097153;
        this.heroCamera.enabled = false;
    }

    private void SetupMaterial()
    {
        base.gameObject.renderer.material.mainTexture = this.tempRenderBuffer;
    }

    private void Start()
    {
        this.CreateCamera();
        this.CreateRenderTexture();
        this.SetupCamera();
        this.SetupMaterial();
    }

    private void UpdateOffScreenCamera()
    {
        this.heroCamera.orthographicSize = 1f;
        this.heroCameraGO.transform.position = base.transform.position;
        this.heroCameraGO.transform.rotation = base.transform.rotation;
        this.heroCameraGO.transform.Rotate((float) 90f, 180f, (float) 0f);
    }

    protected static Material material
    {
        get
        {
            if (m_Material == null)
            {
                m_Material = new Material(blurMatString);
                m_Material.hideFlags = HideFlags.HideAndDontSave;
                m_Material.shader.hideFlags = HideFlags.HideAndDontSave;
            }
            return m_Material;
        }
    }
}

