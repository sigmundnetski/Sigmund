using System;
using UnityEngine;

public class ShowAllCardsTab : MonoBehaviour
{
    public CheckBox m_includePremiumsCheckBox;
    public CheckBox m_showAllCardsCheckBox;

    private void Awake()
    {
        this.m_showAllCardsCheckBox.SetButtonText(GameStrings.Get("GLUE_COLLECTION_SHOW_ALL_CARDS"));
        this.m_includePremiumsCheckBox.SetButtonText(GameStrings.Get("GLUE_COLLECTION_INCLUDE_PREMIUMS"));
    }

    public bool IsShowAllChecked()
    {
        return this.m_showAllCardsCheckBox.IsChecked();
    }

    private void Start()
    {
        this.m_showAllCardsCheckBox.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ToggleShowAllCards));
        this.m_includePremiumsCheckBox.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ToggleIncludePremiums));
        this.m_showAllCardsCheckBox.SetChecked(false);
        this.m_includePremiumsCheckBox.SetChecked(false);
        this.m_includePremiumsCheckBox.gameObject.SetActive(false);
    }

    private void ToggleIncludePremiums(UIEvent e)
    {
        bool show = this.m_includePremiumsCheckBox.ToggleChecked();
        CollectionManagerDisplay.Get().ShowPremiumCardsNotOwned(show);
        if (show)
        {
            SoundManager.Get().LoadAndPlay("checkbox_toggle_on", base.gameObject);
        }
        else
        {
            SoundManager.Get().LoadAndPlay("checkbox_toggle_off", base.gameObject);
        }
    }

    private void ToggleShowAllCards(UIEvent e)
    {
        bool flag = this.m_showAllCardsCheckBox.ToggleChecked();
        if (flag)
        {
            SoundManager.Get().LoadAndPlay("checkbox_toggle_on", base.gameObject);
            CollectionManagerDisplay.Get().ShowStandardCardsNotOwned();
            if (!Options.Get().GetBool(Option.HAS_SEEN_UNOWNED_CARDS, false))
            {
                NotificationManager.Get().CreateInnkeeperQuote(new Vector3(427f, -865f, 0f), GameStrings.Get("VO_INNKEEPER_CM_UNOWNED_29"), "VO_INNKEEPER_CM_UNOWNED_29", 3f);
                Options.Get().SetBool(Option.HAS_SEEN_UNOWNED_CARDS, true);
            }
        }
        else
        {
            SoundManager.Get().LoadAndPlay("checkbox_toggle_off", base.gameObject);
            CollectionManagerDisplay.Get().ShowOnlyCardsIOwn();
            this.m_includePremiumsCheckBox.SetChecked(false);
        }
        this.m_includePremiumsCheckBox.gameObject.SetActive(flag);
    }
}

