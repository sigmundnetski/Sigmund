using System;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public PegButton OptionMenuButton;
    public GameObject OptionsMenu;

    private void Awake()
    {
        this.OptionMenuButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.ToggleOptionsMenu));
    }

    private void ToggleOptionsMenu(UIEvent e)
    {
        if (this.OptionsMenu.activeInHierarchy)
        {
            this.OptionsMenu.SetActive(false);
        }
        else
        {
            this.OptionsMenu.SetActive(true);
        }
    }
}

