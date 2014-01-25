using System;
using UnityEngine;

public class GraphicsManager : MonoBehaviour
{
    private GraphicsQuality m_GraphicsQuality;
    private bool m_RealtimeShadows;
    private static GraphicsManager s_instance;

    private void Awake()
    {
        s_instance = this;
        this.m_GraphicsQuality = (GraphicsQuality) Options.Get().GetInt(Option.GFX_QUALITY);
        Log.Kyle.Print("GraphicsManager Awake, Graphics Quality: " + this.m_GraphicsQuality.ToString());
        this.InitializeScreen();
        this.UpdateQualitySettings();
    }

    public static GraphicsManager Get()
    {
        return s_instance;
    }

    private void InitializeScreen()
    {
        int @int;
        int num2;
        bool @bool = Options.Get().GetBool(Option.GFX_FULLSCREEN, Screen.fullScreen);
        if (@bool)
        {
            @int = Options.Get().GetInt(Option.GFX_WIDTH, Screen.currentResolution.width);
            num2 = Options.Get().GetInt(Option.GFX_HEIGHT, Screen.currentResolution.height);
            if (((@int == Screen.currentResolution.width) && (num2 == Screen.currentResolution.height)) && (@bool == Screen.fullScreen))
            {
                return;
            }
        }
        else
        {
            if (!Options.Get().HasOption(Option.GFX_WIDTH) || !Options.Get().HasOption(Option.GFX_HEIGHT))
            {
                return;
            }
            @int = Options.Get().GetInt(Option.GFX_WIDTH);
            num2 = Options.Get().GetInt(Option.GFX_HEIGHT);
        }
        this.SetScreenResolution(@int, num2, @bool);
    }

    private void SetQualityByName(string qualityName)
    {
        string[] names = QualitySettings.names;
        int index = -1;
        int num2 = 0;
        while (num2 < names.Length)
        {
            if (names[num2] == qualityName)
            {
                index = num2;
            }
            num2++;
        }
        if (num2 < 0)
        {
            Debug.LogError(string.Format("GraphicsManager: Quality Level not found: {0}", qualityName));
        }
        else
        {
            QualitySettings.SetQualityLevel(index, true);
        }
    }

    public void SetScreenResolution(int width, int height, bool fullscreen)
    {
        Screen.SetResolution(width, height, fullscreen);
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void UpdateAnitAliasing()
    {
        bool flag = false;
        int num = 0;
        if (this.m_GraphicsQuality == GraphicsQuality.Low)
        {
            num = 0;
            flag = false;
        }
        else if (this.m_GraphicsQuality == GraphicsQuality.Medium)
        {
            num = 4;
            flag = false;
        }
        else if (this.m_GraphicsQuality == GraphicsQuality.High)
        {
            num = 0;
            flag = true;
        }
        QualitySettings.antiAliasing = num;
        FullScreenAntialiasing[] antialiasingArray = UnityEngine.Object.FindObjectsOfType(typeof(FullScreenAntialiasing)) as FullScreenAntialiasing[];
        foreach (FullScreenAntialiasing antialiasing in antialiasingArray)
        {
            antialiasing.enabled = flag;
        }
    }

    private void UpdateQualitySettings()
    {
        Log.Kyle.Print("GraphicsManager Update, Graphics Quality: " + this.m_GraphicsQuality.ToString());
        this.UpdateRenderQualitySettings();
        this.UpdateAnitAliasing();
    }

    private void UpdateRenderQualitySettings()
    {
        if (this.m_GraphicsQuality == GraphicsQuality.Low)
        {
            this.SetQualityByName("Low");
            this.m_RealtimeShadows = false;
        }
        else if (this.m_GraphicsQuality == GraphicsQuality.Medium)
        {
            this.SetQualityByName("Medium");
            this.m_RealtimeShadows = false;
        }
        else if (this.m_GraphicsQuality == GraphicsQuality.High)
        {
            this.SetQualityByName("High");
            this.m_RealtimeShadows = true;
        }
        ProjectedShadow[] shadowArray = UnityEngine.Object.FindObjectsOfType(typeof(ProjectedShadow)) as ProjectedShadow[];
        foreach (ProjectedShadow shadow in shadowArray)
        {
            shadow.enabled = !this.m_RealtimeShadows;
        }
        RenderToTexture[] textureArray = UnityEngine.Object.FindObjectsOfType(typeof(RenderToTexture)) as RenderToTexture[];
        foreach (RenderToTexture texture in textureArray)
        {
            texture.ForceTextureRebuild();
        }
    }

    public bool RealtimeShadows
    {
        get
        {
            return this.m_RealtimeShadows;
        }
    }

    public GraphicsQuality RenderQualityLevel
    {
        get
        {
            return this.m_GraphicsQuality;
        }
        set
        {
            this.m_GraphicsQuality = value;
            Options.Get().SetInt(Option.GFX_QUALITY, (int) this.m_GraphicsQuality);
            this.UpdateQualitySettings();
        }
    }
}

