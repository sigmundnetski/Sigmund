using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [CompilerGenerated]
    private static SoundManager.LoadedCallback <>f__am$cache11;
    public CheckBox m_fullScreenCheckbox;
    public UberText m_fullScreenLabel;
    private readonly List<GraphicsResolution> m_fullScreenResolutions = new List<GraphicsResolution>();
    public TextMesh m_graphicsGroupLabel;
    public DropdownControl m_graphicsQuality;
    public TextMesh m_graphicsQualityLabel;
    public DropdownControl m_graphicsRes;
    private hideHandler m_hideHandler;
    public ScrollbarControl m_masterVolume;
    public TextMesh m_masterVolumeLabel;
    public ScrollbarControl m_musicVolume;
    public TextMesh m_musicVolumeLabel;
    public BeveledButton m_okButton;
    public NineSlicePopup m_popup;
    public TextMesh m_resolutionLabel;
    public TextMesh m_soundGroupLabel;
    public UberText m_title;

    public hideHandler getHideHandler()
    {
        return this.m_hideHandler;
    }

    private void hide()
    {
        this.showOrHide(false);
        if (this.m_hideHandler != null)
        {
            this.m_hideHandler();
            this.m_hideHandler = null;
        }
    }

    public void okButtonPressed(UIEvent e)
    {
        this.hide();
    }

    private string onGraphicsResolutionDropdownText(object val)
    {
        GraphicsResolution resolution = (GraphicsResolution) val;
        return string.Format("{0} x {1}", resolution.x, resolution.y);
    }

    private void onMasterVolumeRelease()
    {
        if (<>f__am$cache11 == null)
        {
            <>f__am$cache11 = delegate (AudioSource source, object userData) {
                SoundManager.Get().Set3d(source, false);
            };
        }
        SoundManager.LoadedCallback callback = <>f__am$cache11;
        SoundManager.Get().LoadAndPlay("UI_MouseClick_01", base.gameObject, 1f, callback);
    }

    private void onNewGraphicsQuality(object selection, object prevSelection)
    {
        GraphicsQuality low = GraphicsQuality.Low;
        string str = (string) selection;
        if (str == GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_QUALITY_LOW"))
        {
            low = GraphicsQuality.Low;
        }
        else if (str == GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_QUALITY_MEDIUM"))
        {
            low = GraphicsQuality.Medium;
        }
        else if (str == GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_QUALITY_HIGH"))
        {
            low = GraphicsQuality.High;
        }
        Log.Kyle.Print("Graphics Quality: " + low.ToString());
        GraphicsManager.Get().RenderQualityLevel = low;
    }

    private void onNewGraphicsResolution(object selection, object prevSelection)
    {
        GraphicsResolution resolution = (GraphicsResolution) selection;
        GraphicsManager.Get().SetScreenResolution(resolution.x, resolution.y, this.m_fullScreenCheckbox.IsChecked());
        Options.Get().SetInt(Option.GFX_WIDTH, resolution.x);
        Options.Get().SetInt(Option.GFX_HEIGHT, resolution.y);
    }

    private void onNewMasterVolume(float newVolume)
    {
        Options.Get().SetFloat(Option.SOUND_VOLUME, newVolume);
    }

    private void onNewMusicVolume(float newVolume)
    {
        Options.Get().SetFloat(Option.MUSIC_VOLUME, newVolume);
    }

    public void setHideHandler(hideHandler handler)
    {
        this.m_hideHandler = handler;
    }

    public void show()
    {
        this.showOrHide(true);
    }

    private void showOrHide(bool showOrHide)
    {
        base.gameObject.SetActive(showOrHide);
    }

    private void Start()
    {
        base.transform.parent = BaseUI.Get().transform;
        base.transform.position = BaseUI.Get().GetOptionsMenuBone().position;
        this.m_popup.SetHeaderText(GameStrings.Get("GLOBAL_OPTIONS"));
        this.m_graphicsGroupLabel.text = GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_LABEL");
        this.m_soundGroupLabel.text = GameStrings.Get("GLOBAL_OPTIONS_SOUND_LABEL");
        this.m_resolutionLabel.text = GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_RESOLUTION_LABEL");
        this.m_graphicsRes.setItemTextCallback(new DropdownControl.itemTextCallback(this.onGraphicsResolutionDropdownText));
        this.m_graphicsRes.setItemChosenCallback(new DropdownControl.itemChosenCallback(this.onNewGraphicsResolution));
        foreach (GraphicsResolution resolution in this.GoodGraphicsResolution)
        {
            this.m_graphicsRes.addItem(resolution);
        }
        this.m_graphicsRes.setSelection(this.CurrentGraphicsResolution);
        this.m_fullScreenLabel.Text = GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_FULLSCREEN_LABEL");
        this.m_fullScreenCheckbox.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.toggleFullScreenCheckbox));
        this.m_fullScreenCheckbox.SetChecked(Options.Get().GetBool(Option.GFX_FULLSCREEN, Screen.fullScreen));
        this.m_graphicsQualityLabel.text = GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_QUALITY_LABEL");
        this.m_graphicsQuality.addItem(GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_QUALITY_LOW"));
        this.m_graphicsQuality.addItem(GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_QUALITY_MEDIUM"));
        this.m_graphicsQuality.addItem(GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_QUALITY_HIGH"));
        this.m_graphicsQuality.setSelection(this.CurrentGraphicsQuality);
        this.m_graphicsQuality.setItemChosenCallback(new DropdownControl.itemChosenCallback(this.onNewGraphicsQuality));
        this.m_masterVolumeLabel.text = GameStrings.Get("GLOBAL_OPTIONS_SOUND_MASTER_VOLUME_LABEL");
        this.m_musicVolumeLabel.text = GameStrings.Get("GLOBAL_OPTIONS_SOUND_MUSIC_VOLUME_LABEL");
        this.m_masterVolume.SetValue(Options.Get().GetFloat(Option.SOUND_VOLUME));
        this.m_masterVolume.SetUpdateHandler(new ScrollbarControl.UpdateHandler(this.onNewMasterVolume));
        this.m_masterVolume.SetFinishHandler(new ScrollbarControl.FinishHandler(this.onMasterVolumeRelease));
        this.m_musicVolume.SetValue(Options.Get().GetFloat(Option.MUSIC_VOLUME));
        this.m_musicVolume.SetUpdateHandler(new ScrollbarControl.UpdateHandler(this.onNewMusicVolume));
        this.m_okButton.SetText(GameStrings.Get("GLOBAL_BUTTON_OK"));
        this.m_okButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.okButtonPressed));
    }

    public void toggleFullScreenCheckbox(UIEvent e)
    {
        this.m_fullScreenCheckbox.ToggleChecked();
        GraphicsResolution resolution = this.m_graphicsRes.getSelection() as GraphicsResolution;
        if (resolution != null)
        {
            GraphicsManager.Get().SetScreenResolution(resolution.x, resolution.y, this.m_fullScreenCheckbox.IsChecked());
            Options.Get().SetBool(Option.GFX_FULLSCREEN, this.m_fullScreenCheckbox.IsChecked());
        }
    }

    private string CurrentGraphicsQuality
    {
        get
        {
            switch (Options.Get().GetInt(Option.GFX_QUALITY))
            {
                case 0:
                    return GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_QUALITY_LOW");

                case 1:
                    return GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_QUALITY_MEDIUM");

                case 2:
                    return GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_QUALITY_HIGH");
            }
            return GameStrings.Get("GLOBAL_OPTIONS_GRAPHICS_QUALITY_LOW");
        }
    }

    private GraphicsResolution CurrentGraphicsResolution
    {
        get
        {
            int @int = Options.Get().GetInt(Option.GFX_WIDTH, Screen.currentResolution.width);
            int height = Options.Get().GetInt(Option.GFX_HEIGHT, Screen.currentResolution.height);
            return GraphicsResolution.create(@int, height);
        }
    }

    private List<GraphicsResolution> GoodGraphicsResolution
    {
        get
        {
            if (this.m_fullScreenResolutions.Count == 0)
            {
                foreach (GraphicsResolution resolution in GraphicsResolution.list)
                {
                    if (((resolution.x >= 0x400) && (resolution.y >= 0x2d8)) && (((resolution.aspectRatio - 0.01) <= 1.7777777777777777) && ((resolution.aspectRatio + 0.01) >= 1.3333333333333333)))
                    {
                        this.m_fullScreenResolutions.Add(resolution);
                    }
                }
            }
            return this.m_fullScreenResolutions;
        }
    }

    public delegate void hideHandler();
}

