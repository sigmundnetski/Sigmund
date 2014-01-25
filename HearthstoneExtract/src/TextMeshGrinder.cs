using System;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshGrinder : MonoBehaviour
{
    private float m_characterSize = 1f;
    private bool m_cloned;
    private Font m_currentFont;
    public List<Font> m_fonts;
    private int m_fontSize;
    private float m_lineSpacing = 1f;
    private string m_text = string.Empty;
    public TextMesh m_textMesh;
    public GameObject m_textMeshGameObject;

    private void BuildTextMesh()
    {
        Material material = this.m_textMesh.renderer.material;
        Texture mainTexture = this.m_textMesh.font.material.mainTexture;
        if (this.m_textMesh != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_textMesh);
        }
        this.m_textMesh = null;
        this.m_textMesh = this.m_textMeshGameObject.AddComponent<TextMesh>();
        this.m_textMesh.renderer.sharedMaterial = material;
        this.m_textMesh.richText = true;
        this.m_textMesh.renderer.material.mainTexture = mainTexture;
        this.m_textMesh.renderer.material.color = Color.white;
        this.m_textMesh.text = this.m_text;
        this.m_textMesh.fontSize = this.m_fontSize;
        this.m_textMesh.lineSpacing = this.m_lineSpacing;
        this.m_textMesh.characterSize = this.m_characterSize;
        this.m_textMesh.font = this.m_currentFont;
    }

    private void PermuteTextMesh(TextMesh text)
    {
        this.m_fontSize += (UnityEngine.Random.value <= 0.5) ? 1 : -1;
        if (this.m_fontSize < 1)
        {
            this.m_fontSize = 1;
        }
        if (this.m_fontSize > 100)
        {
            this.m_fontSize = 100;
        }
        if (UnityEngine.Random.value < 0.1f)
        {
            this.m_currentFont = this.m_fonts[(int) (UnityEngine.Random.value * this.m_fonts.Count)];
        }
        if (!this.m_cloned && (UnityEngine.Random.value < 0.1f))
        {
            this.m_cloned = true;
            GameObject obj2 = (GameObject) UnityEngine.Object.Instantiate(base.gameObject);
            obj2.transform.parent = base.gameObject.transform.parent;
            obj2.gameObject.name = "TextMeshGrinder";
            Transform transform = obj2.transform;
            transform.localPosition += new Vector3(UnityEngine.Random.value - 0.5f, UnityEngine.Random.value - 0.5f, UnityEngine.Random.value - 0.5f);
        }
        if (UnityEngine.Random.value < 0.1)
        {
            this.BuildTextMesh();
        }
    }

    private void Start()
    {
        this.m_text = this.m_textMesh.text;
        this.m_lineSpacing = this.m_textMesh.lineSpacing;
        this.m_characterSize = this.m_textMesh.characterSize;
        this.m_currentFont = this.m_textMesh.font;
        this.m_fontSize = this.m_textMesh.fontSize;
        this.m_cloned = false;
    }

    private void Update()
    {
        this.PermuteTextMesh(this.m_textMesh);
    }
}

