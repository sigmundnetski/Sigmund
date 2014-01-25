using System;
using UnityEngine;

public class BasicSetProgress : MonoBehaviour
{
    private static readonly Color BASIC_SET_COLOR_COMPLETE = new Color(0.52f, 0.6f, 0.36f);
    private static readonly Color BASIC_SET_COLOR_IN_PROGRESS = new Color(0.97f, 0.82f, 0.22f);
    public Material m_complete;
    public Material m_inProgress;
    public UberText m_progressText;

    public void UpdateInfo(TAG_CLASS classTag)
    {
        int num = CollectionManager.Get().GetNumCardsIOwn(2, new TAG_CLASS?(classTag), null, null, new CardFlair(CardFlair.PremiumType.STANDARD));
        int num2 = CollectionManager.Get().GetNumAvailableCards(2, new TAG_CLASS?(classTag), null, null);
        if (num == num2)
        {
            this.m_progressText.Text = string.Format(GameStrings.Get("GLUE_PRACTICE_BASIC_SET_COMPLETE"), GameStrings.GetClassName(classTag));
            this.m_progressText.TextColor = BASIC_SET_COLOR_COMPLETE;
            base.gameObject.renderer.material = this.m_complete;
        }
        else
        {
            this.m_progressText.Text = string.Format(GameStrings.Get("GLUE_PRACTICE_BASIC_SET_PROGRESS"), num, num2);
            this.m_progressText.TextColor = BASIC_SET_COLOR_IN_PROGRESS;
            base.gameObject.renderer.material = this.m_inProgress;
        }
    }
}

