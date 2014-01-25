using System;
using UnityEngine;

public class FullScreenEffects : MonoBehaviour
{
    private readonly string BLEND_SHADER_NAME = "Custom/FullScreen/Blend";
    private readonly string BLEND_TO_COLOR_SHADER_NAME = "Custom/FullScreen/BlendToColor";
    private readonly int BLUR_BUFFER_SIZE = 430;
    private readonly string BLUR_DESATURATION_SHADER_NAME = "Custom/FullScreen/DesaturationBlur";
    private readonly string BLUR_DESATURATION_VIGNETTING_SHADER_NAME = "Custom/FullScreen/BlurDesaturationVignetting";
    private readonly string BLUR_SHADER_NAME = "Custom/FullScreen/Blur";
    private readonly string BLUR_VIGNETTING_SHADER_NAME = "Custom/FullScreen/BlurVignetting";
    private readonly string DESATURATION_SHADER_NAME = "Custom/FullScreen/Desaturation";
    private readonly string DESATURATION_VIGNETTING_SHADER_NAME = "Custom/FullScreen/DesaturationVignetting";
    private Material m_BlendMaterial;
    private Shader m_BlendShader;
    private Color m_BlendToColor = Color.white;
    private float m_BlendToColorAmount;
    private bool m_BlendToColorEnable;
    private Material m_BlendToColorMaterial;
    private Shader m_BlendToColorShader;
    private float m_BlurAmount = 1f;
    private float m_BlurBlend = 1f;
    private float m_BlurBrightness = 1f;
    private RenderTexture m_BlurBuffer1;
    private RenderTexture m_BlurBuffer2;
    private Material m_BlurDesatMaterial;
    private float m_BlurDesaturation;
    private Shader m_BlurDesaturationShader;
    private Material m_BlurDesaturationVignettingMaterial;
    private Shader m_BlurDesaturationVignettingShader;
    private bool m_BlurEnabled;
    private Material m_BlurMaterial;
    private Shader m_BlurShader;
    private Material m_BlurVignettingMaterial;
    private Shader m_BlurVignettingShader;
    private bool m_CaptureFrozenImage;
    private int m_DeactivateFrameCount;
    private float m_Desaturation;
    private bool m_DesaturationEnabled;
    private Material m_DesaturationMaterial;
    private Shader m_DesaturationShader;
    private Material m_DesaturationVignettingMaterial;
    private Shader m_DesaturationVignettingShader;
    private Texture2D m_FrozenScreenTexture;
    private bool m_FrozenState;
    private bool m_VignettingEnable;
    private float m_VignettingIntensity;
    private Texture2D m_VignettingMask;
    private Material m_VignettingMaterial;
    private Shader m_VignettingShader;
    private bool m_WireframeRender;
    private readonly int NO_WORK_FRAMES_BEFORE_DEACTIVATE = 2;
    private readonly string VIGNETTING_SHADER_NAME = "Custom/FullScreen/Vignetting";

    private void Blur(RenderTexture source, RenderTexture destination, Material blurMat)
    {
        if (this.m_BlurBuffer1 == null)
        {
            this.m_BlurBuffer1 = RenderTexture.GetTemporary(this.BLUR_BUFFER_SIZE, this.BLUR_BUFFER_SIZE, 0);
        }
        if (this.m_BlurBuffer2 == null)
        {
            this.m_BlurBuffer2 = RenderTexture.GetTemporary(this.BLUR_BUFFER_SIZE, this.BLUR_BUFFER_SIZE, 0);
        }
        this.Sample(source, this.m_BlurBuffer1, 1f, blurMat);
        this.Sample(this.m_BlurBuffer1, this.m_BlurBuffer2, 0.5f, blurMat);
        this.Sample(this.m_BlurBuffer2, destination, this.m_BlurAmount, blurMat);
    }

    public void Disable()
    {
        base.enabled = false;
    }

    public void Freeze()
    {
        base.enabled = true;
        if (!this.m_FrozenState)
        {
            this.m_CaptureFrozenImage = true;
            this.m_FrozenScreenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false, true);
            this.m_FrozenScreenTexture.filterMode = FilterMode.Point;
            this.m_FrozenScreenTexture.wrapMode = TextureWrapMode.Clamp;
        }
    }

    public bool isActive()
    {
        if (!base.enabled)
        {
            return false;
        }
        return (this.m_FrozenState || ((this.m_BlurEnabled && (this.m_BlurBlend > 0f)) || (this.m_VignettingEnable || (this.m_BlendToColorEnable || (this.m_DesaturationEnabled || this.m_WireframeRender)))));
    }

    private void LateUpdate()
    {
        if (!this.m_BlurEnabled)
        {
            if (this.m_BlurBuffer1 != null)
            {
                if (this.m_BlurBuffer1.IsCreated())
                {
                    RenderTexture.ReleaseTemporary(this.m_BlurBuffer1);
                }
                UnityEngine.Object.Destroy(this.m_BlurBuffer1);
                this.m_BlurBuffer1 = null;
            }
            if (this.m_BlurBuffer2 != null)
            {
                if (this.m_BlurBuffer2.IsCreated())
                {
                    RenderTexture.ReleaseTemporary(this.m_BlurBuffer2);
                }
                UnityEngine.Object.Destroy(this.m_BlurBuffer2);
                this.m_BlurBuffer2 = null;
            }
        }
    }

    protected void OnDestroy()
    {
        CheatMgr mgr = CheatMgr.Get();
        if (mgr != null)
        {
            mgr.UnregisterCheatHandler("wireframe", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_RenderWireframe));
        }
    }

    protected void OnDisable()
    {
        this.SetDefaults();
        if (this.m_BlurMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_BlurMaterial);
        }
        if (this.m_BlurVignettingMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_BlurVignettingMaterial);
        }
        if (this.m_BlurDesatMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_BlurDesatMaterial);
        }
        if (this.m_BlendMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_BlendMaterial);
        }
        if (this.m_VignettingMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_VignettingMaterial);
        }
        if (this.m_BlendToColorMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_BlendToColorMaterial);
        }
        if (this.m_DesaturationMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_DesaturationMaterial);
        }
        if (this.m_DesaturationVignettingMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_DesaturationVignettingMaterial);
        }
        if (this.m_BlurDesaturationVignettingMaterial != null)
        {
            UnityEngine.Object.Destroy(this.m_BlurDesaturationVignettingMaterial);
        }
        if (this.m_BlurBuffer1 != null)
        {
            if (this.m_BlurBuffer1.IsCreated())
            {
                RenderTexture.ReleaseTemporary(this.m_BlurBuffer1);
            }
            UnityEngine.Object.Destroy(this.m_BlurBuffer1);
            this.m_BlurBuffer1 = null;
        }
        if (this.m_BlurBuffer2 != null)
        {
            if (this.m_BlurBuffer2.IsCreated())
            {
                RenderTexture.ReleaseTemporary(this.m_BlurBuffer2);
            }
            UnityEngine.Object.Destroy(this.m_BlurBuffer2);
            this.m_BlurBuffer2 = null;
        }
    }

    private void OnPostRender()
    {
        GL.wireframe = false;
    }

    private void OnPreRender()
    {
        if (this.m_WireframeRender)
        {
            GL.wireframe = true;
        }
    }

    private bool OnProcessCheat_RenderWireframe(string func, string[] args, string rawArgs)
    {
        if (this.m_WireframeRender)
        {
            this.m_WireframeRender = false;
            return true;
        }
        this.m_WireframeRender = true;
        base.enabled = true;
        return true;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (((source != null) && (source.width != 0)) && (source.height != 0))
        {
            bool flag = false;
            if (this.m_FrozenState)
            {
                if (this.m_FrozenScreenTexture != null)
                {
                    Material blendMaterial = this.blendMaterial;
                    blendMaterial.SetFloat("_Amount", 1f);
                    blendMaterial.SetTexture("_BlendTex", this.m_FrozenScreenTexture);
                    if (QualitySettings.antiAliasing > 0)
                    {
                        blendMaterial.SetFloat("_Flip", 1f);
                    }
                    else
                    {
                        blendMaterial.SetFloat("_Flip", 0f);
                    }
                    Graphics.Blit(source, destination, blendMaterial);
                    this.m_DeactivateFrameCount = 0;
                    return;
                }
                Debug.LogWarning("m_FrozenScreenTexture is null. FullScreenEffect Freeze disabled");
                this.m_FrozenState = false;
            }
            if (this.m_BlurEnabled && (this.m_BlurBlend > 0f))
            {
                Material blurMaterial = this.blurMaterial;
                blurMaterial.SetFloat("_Brightness", this.m_BlurBrightness);
                if ((this.m_BlurDesaturation > 0f) && !this.m_VignettingEnable)
                {
                    blurMaterial = this.blurDesatMaterial;
                    blurMaterial.SetFloat("_Desaturation", this.m_BlurDesaturation);
                }
                else if (this.m_VignettingEnable && (this.m_BlurDesaturation == 0f))
                {
                    blurMaterial = this.blurVignettingMaterial;
                    blurMaterial.SetFloat("_Amount", this.m_VignettingIntensity);
                    blurMaterial.SetTexture("_MaskTex", this.m_VignettingMask);
                }
                else if (this.m_VignettingEnable && (this.m_BlurDesaturation > 0f))
                {
                    blurMaterial = this.BlurDesaturationVignettingMaterial;
                    blurMaterial.SetFloat("_Amount", this.m_VignettingIntensity);
                    blurMaterial.SetTexture("_MaskTex", this.m_VignettingMask);
                    blurMaterial.SetFloat("_Desaturation", this.m_BlurDesaturation);
                }
                if (this.m_BlurBlend >= 1f)
                {
                    this.Blur(source, destination, blurMaterial);
                    flag = true;
                }
                else
                {
                    RenderTexture texture = RenderTexture.GetTemporary(this.BLUR_BUFFER_SIZE, this.BLUR_BUFFER_SIZE, 0);
                    this.Blur(source, texture, blurMaterial);
                    Material mat = this.blendMaterial;
                    mat.SetFloat("_Amount", this.m_BlurBlend);
                    mat.SetTexture("_BlendTex", texture);
                    Graphics.Blit(source, destination, mat);
                    RenderTexture.ReleaseTemporary(texture);
                    flag = true;
                }
            }
            if (this.m_DesaturationEnabled && !flag)
            {
                Material desaturationMaterial = this.DesaturationMaterial;
                if (this.m_VignettingEnable)
                {
                    desaturationMaterial = this.DesaturationVignettingMaterial;
                    desaturationMaterial.SetFloat("_Amount", this.m_VignettingIntensity);
                    desaturationMaterial.SetTexture("_MaskTex", this.m_VignettingMask);
                }
                desaturationMaterial.SetFloat("_Desaturation", this.m_Desaturation);
                Graphics.Blit(source, destination, desaturationMaterial);
                flag = true;
            }
            if (this.m_VignettingEnable && !flag)
            {
                Material vignettingMaterial = this.VignettingMaterial;
                vignettingMaterial.SetFloat("_Amount", this.m_VignettingIntensity);
                vignettingMaterial.SetTexture("_MaskTex", this.m_VignettingMask);
                Graphics.Blit(source, destination, vignettingMaterial);
                flag = true;
            }
            if (this.m_BlendToColorEnable && !flag)
            {
                Material blendToColorMaterial = this.BlendToColorMaterial;
                blendToColorMaterial.SetFloat("_Amount", this.m_BlendToColorAmount);
                blendToColorMaterial.SetColor("_Color", this.m_BlendToColor);
                Graphics.Blit(source, destination, blendToColorMaterial);
                flag = true;
            }
            if (this.m_CaptureFrozenImage && !this.m_FrozenState)
            {
                if (!flag)
                {
                    Graphics.Blit(source, destination);
                }
                this.m_FrozenScreenTexture.ReadPixels(new Rect(0f, 0f, (float) Screen.width, (float) Screen.height), 0, 0, false);
                this.m_FrozenScreenTexture.Apply();
                this.m_CaptureFrozenImage = false;
                this.m_FrozenState = true;
                flag = true;
                this.m_DeactivateFrameCount = 0;
            }
            else if (!flag)
            {
                Graphics.Blit(source, destination);
                if (this.m_DeactivateFrameCount > this.NO_WORK_FRAMES_BEFORE_DEACTIVATE)
                {
                    this.m_DeactivateFrameCount = 0;
                    this.Disable();
                }
                else
                {
                    this.m_DeactivateFrameCount++;
                }
            }
        }
    }

    private void Sample(RenderTexture source, RenderTexture dest, float off, Material mat)
    {
        Vector2[] offsets = new Vector2[] { new Vector2(-off, -off), new Vector2(-off, off), new Vector2(off, off), new Vector2(off, -off) };
        Graphics.BlitMultiTap(source, dest, mat, offsets);
    }

    private void SetDefaults()
    {
        this.m_BlurEnabled = false;
        this.m_BlurBlend = 1f;
        this.m_BlurAmount = 1f;
        this.m_BlurDesaturation = 0f;
        this.m_BlurBrightness = 1f;
        this.m_VignettingEnable = false;
        this.m_VignettingIntensity = 0f;
        this.m_BlendToColorEnable = false;
        this.m_BlendToColor = Color.white;
        this.m_BlendToColorAmount = 0f;
        this.m_DesaturationEnabled = false;
        this.m_Desaturation = 0f;
    }

    protected void Start()
    {
        CheatMgr mgr = CheatMgr.Get();
        if (mgr != null)
        {
            mgr.RegisterCheatHandler("wireframe", new CheatMgr.ProcessCheatCallback(this.OnProcessCheat_RenderWireframe));
        }
        Camera component = base.gameObject.GetComponent<Camera>();
        if (component != null)
        {
            component.clearFlags = CameraClearFlags.Nothing;
        }
        if (!SystemInfo.supportsImageEffects)
        {
            Debug.LogError("Fullscreen Effects not supported");
            base.enabled = false;
        }
        else
        {
            if (this.m_BlurShader == null)
            {
                this.m_BlurShader = Shader.Find(this.BLUR_SHADER_NAME);
            }
            if (this.m_BlurShader == null)
            {
                Debug.LogError("Fullscreen Effect Failed to load Shader: " + this.BLUR_SHADER_NAME);
                base.enabled = false;
            }
            if ((this.m_BlurShader == null) || !this.blurMaterial.shader.isSupported)
            {
                Debug.LogError("Fullscreen Effect Shader not supported: " + this.BLUR_SHADER_NAME);
                base.enabled = false;
            }
            else
            {
                if (this.m_BlurVignettingShader == null)
                {
                    this.m_BlurVignettingShader = Shader.Find(this.BLUR_VIGNETTING_SHADER_NAME);
                }
                if (this.m_BlurVignettingShader == null)
                {
                    Debug.LogError("Fullscreen Effect Failed to load Shader: " + this.BLUR_VIGNETTING_SHADER_NAME);
                    base.enabled = false;
                }
                if (this.m_BlurDesaturationShader == null)
                {
                    this.m_BlurDesaturationShader = Shader.Find(this.BLUR_DESATURATION_SHADER_NAME);
                }
                if (this.m_BlurDesaturationShader == null)
                {
                    Debug.LogError("Fullscreen Effect Failed to load Shader: " + this.BLUR_DESATURATION_SHADER_NAME);
                    base.enabled = false;
                }
                if (this.m_BlendShader == null)
                {
                    this.m_BlendShader = Shader.Find(this.BLEND_SHADER_NAME);
                }
                if (this.m_BlendShader == null)
                {
                    Debug.LogError("Fullscreen Effect Failed to load Shader: " + this.BLEND_SHADER_NAME);
                    base.enabled = false;
                }
                if (this.m_VignettingShader == null)
                {
                    this.m_VignettingShader = Shader.Find(this.VIGNETTING_SHADER_NAME);
                }
                if (this.m_VignettingShader == null)
                {
                    Debug.LogError("Fullscreen Effect Failed to load Shader: " + this.VIGNETTING_SHADER_NAME);
                    base.enabled = false;
                }
                if (this.m_BlendToColorShader == null)
                {
                    this.m_BlendToColorShader = Shader.Find(this.BLEND_TO_COLOR_SHADER_NAME);
                }
                if (this.m_BlendToColorShader == null)
                {
                    Debug.LogError("Fullscreen Effect Failed to load Shader: " + this.BLEND_TO_COLOR_SHADER_NAME);
                    base.enabled = false;
                }
                if (this.m_DesaturationShader == null)
                {
                    this.m_DesaturationShader = Shader.Find(this.DESATURATION_SHADER_NAME);
                }
                if (this.m_DesaturationShader == null)
                {
                    Debug.LogError("Fullscreen Effect Failed to load Shader: " + this.DESATURATION_SHADER_NAME);
                    base.enabled = false;
                }
                if (this.m_DesaturationVignettingShader == null)
                {
                    this.m_DesaturationVignettingShader = Shader.Find(this.DESATURATION_VIGNETTING_SHADER_NAME);
                }
                if (this.m_DesaturationVignettingShader == null)
                {
                    Debug.LogError("Fullscreen Effect Failed to load Shader: " + this.DESATURATION_VIGNETTING_SHADER_NAME);
                    base.enabled = false;
                }
                if (this.m_BlurDesaturationVignettingShader == null)
                {
                    this.m_BlurDesaturationVignettingShader = Shader.Find(this.BLUR_DESATURATION_VIGNETTING_SHADER_NAME);
                }
                if (this.m_BlurDesaturationVignettingShader == null)
                {
                    Debug.LogError("Fullscreen Effect Failed to load Shader: " + this.BLUR_DESATURATION_VIGNETTING_SHADER_NAME);
                    base.enabled = false;
                }
            }
        }
    }

    public void Unfreeze()
    {
        this.m_FrozenState = false;
        UnityEngine.Object.Destroy(this.m_FrozenScreenTexture);
        this.m_FrozenScreenTexture = null;
    }

    protected Material blendMaterial
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

    public Color BlendToColor
    {
        get
        {
            return this.m_BlendToColor;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_BlendToColorEnable = true;
            this.m_BlendToColor = value;
        }
    }

    public float BlendToColorAmount
    {
        get
        {
            return this.m_BlendToColorAmount;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_BlendToColorEnable = true;
            this.m_BlendToColorAmount = value;
        }
    }

    public bool BlendToColorEnable
    {
        get
        {
            return this.m_BlendToColorEnable;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_BlendToColorEnable = value;
        }
    }

    protected Material BlendToColorMaterial
    {
        get
        {
            if (this.m_BlendToColorMaterial == null)
            {
                this.m_BlendToColorMaterial = new Material(this.m_BlendToColorShader);
                this.m_BlendToColorMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_BlendToColorMaterial;
        }
    }

    public float BlurAmount
    {
        get
        {
            return this.m_BlurAmount;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_BlurEnabled = true;
            this.m_BlurAmount = value;
        }
    }

    public float BlurBlend
    {
        get
        {
            return this.m_BlurBlend;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_BlurEnabled = true;
            this.m_BlurBlend = value;
        }
    }

    public float BlurBrightness
    {
        get
        {
            return this.m_BlurBrightness;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_BlurEnabled = true;
            this.m_BlurBrightness = value;
        }
    }

    protected Material blurDesatMaterial
    {
        get
        {
            if (this.m_BlurDesatMaterial == null)
            {
                this.m_BlurDesatMaterial = new Material(this.m_BlurDesaturationShader);
                this.m_BlurDesatMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_BlurDesatMaterial;
        }
    }

    public float BlurDesaturation
    {
        get
        {
            return this.m_BlurDesaturation;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_BlurEnabled = true;
            this.m_BlurDesaturation = value;
        }
    }

    protected Material BlurDesaturationVignettingMaterial
    {
        get
        {
            if (this.m_BlurDesaturationVignettingMaterial == null)
            {
                this.m_BlurDesaturationVignettingMaterial = new Material(this.m_BlurDesaturationVignettingShader);
                this.m_BlurDesaturationVignettingMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_BlurDesaturationVignettingMaterial;
        }
    }

    public bool BlurEnabled
    {
        get
        {
            return this.m_BlurEnabled;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_BlurEnabled = value;
        }
    }

    protected Material blurMaterial
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

    protected Material blurVignettingMaterial
    {
        get
        {
            if (this.m_BlurVignettingMaterial == null)
            {
                this.m_BlurVignettingMaterial = new Material(this.m_BlurVignettingShader);
                this.m_BlurVignettingMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_BlurVignettingMaterial;
        }
    }

    public float Desaturation
    {
        get
        {
            return this.m_Desaturation;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_DesaturationEnabled = true;
            this.m_Desaturation = value;
        }
    }

    public bool DesaturationEnabled
    {
        get
        {
            return this.m_DesaturationEnabled;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_DesaturationEnabled = value;
        }
    }

    protected Material DesaturationMaterial
    {
        get
        {
            if (this.m_DesaturationMaterial == null)
            {
                this.m_DesaturationMaterial = new Material(this.m_DesaturationShader);
                this.m_DesaturationMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_DesaturationMaterial;
        }
    }

    protected Material DesaturationVignettingMaterial
    {
        get
        {
            if (this.m_DesaturationVignettingMaterial == null)
            {
                this.m_DesaturationVignettingMaterial = new Material(this.m_DesaturationVignettingShader);
                this.m_DesaturationVignettingMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_DesaturationVignettingMaterial;
        }
    }

    public bool VignettingEnable
    {
        get
        {
            return this.m_VignettingEnable;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_VignettingEnable = value;
        }
    }

    public float VignettingIntensity
    {
        get
        {
            return this.m_VignettingIntensity;
        }
        set
        {
            if (!base.enabled)
            {
                base.enabled = true;
            }
            this.m_VignettingEnable = true;
            this.m_VignettingIntensity = value;
        }
    }

    protected Material VignettingMaterial
    {
        get
        {
            if (this.m_VignettingMaterial == null)
            {
                this.m_VignettingMaterial = new Material(this.m_VignettingShader);
                this.m_VignettingMaterial.hideFlags = HideFlags.DontSave;
            }
            return this.m_VignettingMaterial;
        }
    }
}

