using System;
using System.Collections.Generic;
using UnityEngine;

public class UberTextGrinder : MonoBehaviour
{
    public bool m_bold;
    public bool m_cloned;
    public List<Font> m_fonts;
    public UberText m_mainUberText;
    public string m_text = string.Empty;

    private void PermuteUberText(UberText text)
    {
        if (!this.m_cloned && (UnityEngine.Random.value < 0.8f))
        {
            this.m_cloned = true;
            GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(base.gameObject);
            obj2.transform.parent = base.gameObject.transform.parent;
            obj2.gameObject.name = "UberTextGrinder";
            obj2.transform.localPosition = new Vector3(UnityEngine.Random.value * 50f, UnityEngine.Random.value * 50f, UnityEngine.Random.value * 50f);
            Font font = this.m_fonts[(int) (UnityEngine.Random.value * 3f)];
            text.TrueTypeFont = font;
        }
    }

    private void Start()
    {
        this.m_cloned = false;
        if (UnityEngine.Random.value < 0.5)
        {
            this.m_bold = true;
        }
    }

    private void Update()
    {
        this.PermuteUberText(this.m_mainUberText);
    }
}

