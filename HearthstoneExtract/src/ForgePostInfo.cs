using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ForgePostInfo : MonoBehaviour
{
    public BeveledButton m_doneButton;
    public UberText m_forgeLabel;
    public UberText m_funnyQuoteText;
    public UberText m_instructionText;
    public UberText m_lossesLabel;
    public List<GameObject> m_lossMarkers;
    private DelOnCloseForgePostGameScreen m_onCloseCallback;
    public UberText m_winsAmount;
    public UberText m_winsLabel;

    private void CloseForgePostInfo(UIEvent e)
    {
        UniversalInputManager.Get().SetSystemDialogActive(false);
        this.m_doneButton.RemoveEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.CloseForgePostInfo));
        object[] args = new object[] { "scale", Vector3.zero, "time", 0.5f, "oncompletetarget", base.gameObject, "oncomplete", "DestroyForgePostInfo" };
        iTween.ScaleTo(base.gameObject, iTween.Hash(args));
        if (this.m_onCloseCallback != null)
        {
            this.m_onCloseCallback();
        }
    }

    private void DestroyForgePostInfo()
    {
        UnityEngine.Object.Destroy(base.gameObject);
    }

    private string GetCardID(int assetID)
    {
        return ((assetID != 0) ? CardManifest.Get().Find(assetID).CardID : string.Empty);
    }

    private string GetFunnyQuoteText()
    {
        int num = 0;
        List<string> list = new List<string>();
        while (true)
        {
            string item = GameStrings.Get("GLOBAL_FORGE_END_JOKE_" + num);
            if (item == ("GLOBAL_FORGE_END_JOKE_" + num))
            {
                return list[UnityEngine.Random.Range(0, list.Count)];
            }
            list.Add(item);
            num++;
        }
    }

    private string GetInstructionText()
    {
        string str3;
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        foreach (string str in DraftManager.Get().GetPreviousCards())
        {
            EntityDef entityDef = DefLoader.Get().GetEntityDef(str);
            if (entityDef.GetRarity() == TAG_RARITY.LEGENDARY)
            {
                num3++;
            }
            else
            {
                if (entityDef.GetRarity() == TAG_RARITY.EPIC)
                {
                    num2++;
                    continue;
                }
                if (entityDef.GetRarity() == TAG_RARITY.RARE)
                {
                    num++;
                }
            }
        }
        string str2 = GameStrings.Get("GLOBAL_FORGE_END_INSTRUCT");
        if (num3 == 1)
        {
            str3 = str2;
            object[] objArray1 = new object[] { str3, num3, " ", GameStrings.Get("GLOBAL_FORGE_LIST_L") };
            str2 = string.Concat(objArray1);
        }
        else if (num3 > 1)
        {
            str3 = str2;
            object[] objArray2 = new object[] { str3, num3, " ", GameStrings.Get("GLOBAL_FORGE_LIST_Ls") };
            str2 = string.Concat(objArray2);
        }
        if ((num3 > 0) && ((num2 > 0) || (num > 0)))
        {
            str2 = str2 + ", ";
        }
        if (num2 == 1)
        {
            str3 = str2;
            object[] objArray3 = new object[] { str3, num2, " ", GameStrings.Get("GLOBAL_FORGE_LIST_E") };
            str2 = string.Concat(objArray3);
        }
        else if (num2 > 1)
        {
            str3 = str2;
            object[] objArray4 = new object[] { str3, num2, " ", GameStrings.Get("GLOBAL_FORGE_LIST_Es") };
            str2 = string.Concat(objArray4);
        }
        if ((num2 > 0) && (num > 0))
        {
            str2 = str2 + ", ";
        }
        if (num == 1)
        {
            str3 = str2;
            object[] objArray5 = new object[] { str3, num, " ", GameStrings.Get("GLOBAL_FORGE_LIST_R") };
            return string.Concat(objArray5);
        }
        if (num > 1)
        {
            str3 = str2;
            object[] objArray6 = new object[] { str3, num, " ", GameStrings.Get("GLOBAL_FORGE_LIST_Rs") };
            str2 = string.Concat(objArray6);
        }
        return str2;
    }

    private static void PositionActor(string actorName, GameObject actorObject, object c)
    {
        UniversalInputManager.Get().SetSystemDialogActive(true);
        actorObject.transform.position = new Vector3(593.24f, -441.1f, 281.3823f);
        Vector3 localScale = actorObject.transform.localScale;
        actorObject.transform.localScale = Vector3.one;
        actorObject.SetActive(true);
        iTween.ScaleTo(actorObject, localScale, 0.5f);
        ForgePostInfo component = actorObject.GetComponent<ForgePostInfo>();
        if (component == null)
        {
            Debug.LogWarning("ForgePostInfo.PositionActor(): actor has no ForgePostInfo component");
        }
        else
        {
            DelOnCloseForgePostGameScreen screen = c as DelOnCloseForgePostGameScreen;
            component.m_onCloseCallback = screen;
        }
        if (!Options.Get().GetBool(Option.HAS_SEEN_FORGE_RETIRE, false))
        {
            NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_FORGE_END_26"), "VO_INNKEEPER_FORGE_END_26", 3f);
            Options.Get().SetBool(Option.HAS_SEEN_FORGE_RETIRE, true);
        }
    }

    public static void ShowForgePostGameScreen(DelOnCloseForgePostGameScreen onClosedCallback)
    {
        DraftManager.Get().NotifyOfPostScreenShown();
        AssetLoader.Get().LoadActor("ForgePostInfo", new AssetLoader.GameObjectCallback(ForgePostInfo.PositionActor), onClosedCallback);
    }

    private void Start()
    {
        this.m_winsLabel.Text = GameStrings.Get("GLOBAL_WINS") + ":";
        this.m_lossesLabel.Text = GameStrings.Get("GLOBAL_LOSSES") + ":";
        this.m_forgeLabel.Text = GameStrings.Get("GLOBAL_FORGE_END_TITLE");
        this.m_funnyQuoteText.Text = this.GetFunnyQuoteText();
        this.m_doneButton.SetText(GameStrings.Get("GLOBAL_FORGE_END_DONE"));
        this.m_doneButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.CloseForgePostInfo));
        for (int i = 0; i < DraftManager.Get().GetPreviousLosses(); i++)
        {
            this.m_lossMarkers[i].SetActive(true);
        }
        this.m_winsAmount.Text = DraftManager.Get().GetPreviousWins().ToString();
        this.m_instructionText.Text = this.GetInstructionText();
        DraftManager.Get().ClearDeckInfo();
    }

    public delegate void DelOnCloseForgePostGameScreen();
}

