using System;
using UnityEngine;

public class FriendListItemHeader : MonoBehaviour
{
    private const string COLOR_STR = "c0c0c0ff";
    public ThreeSliceElement m_Background;
    public UberText m_Text;

    public void SetText(string text)
    {
        this.m_Text.Text = string.Format("<color=#{0}>{1}</color>", "c0c0c0ff", text);
    }
}

