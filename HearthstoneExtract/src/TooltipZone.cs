using System;
using UnityEngine;

public class TooltipZone : MonoBehaviour
{
    public GameObject targetObject;
    private GameObject tooltip;
    public Transform tooltipDisplayLocation;
    public GameObject tooltipPrefab;

    public void HideTooltip()
    {
        if (this.tooltip != null)
        {
            UnityEngine.Object.Destroy(this.tooltip);
        }
    }

    public void ShowBoxTooltip(string headline, string bodytext)
    {
        this.ShowTooltip(headline, bodytext, 8f);
    }

    public void ShowGameplayTooltip(string headline, string bodytext)
    {
        this.ShowTooltip(headline, bodytext, 0.75f);
    }

    public void ShowGameplayTooltipLarge(string headline, string bodytext)
    {
        this.ShowTooltip(headline, bodytext, 0.9f);
    }

    public void ShowStoreTooltip(string headline, string bodytext, float scale)
    {
        this.ShowTooltip(headline, bodytext, scale);
        SceneUtils.SetLayer(this.tooltip, GameLayer.IgnoreFullScreenEffects);
    }

    public KeywordHelpPanel ShowTooltip(string headline, string bodytext, float scale)
    {
        if (this.tooltip != null)
        {
            return this.tooltip.GetComponent<KeywordHelpPanel>();
        }
        this.tooltip = (GameObject) UnityEngine.Object.Instantiate(this.tooltipPrefab, this.tooltipDisplayLocation.position, this.tooltipDisplayLocation.rotation);
        KeywordHelpPanel component = this.tooltip.GetComponent<KeywordHelpPanel>();
        component.SetScale(scale);
        component.Reset();
        component.Initialize(headline, bodytext);
        this.tooltip.transform.parent = base.transform;
        return component;
    }

    private void Start()
    {
    }
}

