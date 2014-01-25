using System;
using UnityEngine;

public class HeroPickerDisplay : MonoBehaviour
{
    private static readonly Vector3 HERO_PICKER_END_POSITION = new Vector3(40.6f, 2.4869f, -28.6f);
    private static readonly float HERO_PICKER_SCALE = 0.95f;
    private static readonly Vector3 HERO_PICKER_START_POSITION = new Vector3(-57.36467f, 2.4869f, -28.6f);
    public GameObject m_deckPickerBone;
    private DeckPickerTrayDisplay m_deckPickerTray;
    private static HeroPickerDisplay s_instance;

    private void Awake()
    {
        base.transform.localPosition = HERO_PICKER_START_POSITION;
        AssetLoader.Get().LoadActor("DeckPickerTray", new AssetLoader.GameObjectCallback(this.DeckPickerTrayLoaded));
        s_instance = this;
    }

    private void DeckPickerTrayLoaded(string name, GameObject go, object callbackData)
    {
        this.m_deckPickerTray = go.GetComponent<DeckPickerTrayDisplay>();
        this.m_deckPickerTray.SetHeaderText(GameStrings.Get("GLUE_CREATE_DECK"));
        this.m_deckPickerTray.transform.parent = base.transform;
        this.m_deckPickerTray.transform.localScale = new Vector3(HERO_PICKER_SCALE, HERO_PICKER_SCALE, HERO_PICKER_SCALE);
        this.m_deckPickerTray.transform.localPosition = this.m_deckPickerBone.transform.localPosition;
        this.m_deckPickerTray.Init();
        this.ShowTray();
    }

    public static HeroPickerDisplay Get()
    {
        return s_instance;
    }

    public void HideTray()
    {
        object[] args = new object[] { "position", HERO_PICKER_START_POSITION, "time", 0.5f, "isLocal", true, "oncomplete", "KillHeroPicker", "oncompletetarget", base.gameObject, "easeType", iTween.EaseType.easeInCubic };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
    }

    private void KillHeroPicker()
    {
        UnityEngine.Object.DestroyImmediate(base.gameObject);
    }

    public void ShowTray()
    {
        object[] args = new object[] { "position", HERO_PICKER_END_POSITION, "time", 0.5f, "isLocal", true, "easeType", iTween.EaseType.easeOutBounce };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
    }
}

