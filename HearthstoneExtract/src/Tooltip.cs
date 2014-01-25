using System;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public TextMesh descriptionText;
    public TextMesh headlineText;

    public void UpdateText(string headline, string description)
    {
        this.headlineText.text = headline;
        this.descriptionText.text = description;
    }
}

