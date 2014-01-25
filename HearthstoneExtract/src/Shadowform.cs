using System;
using System.Collections;
using UnityEngine;

public class Shadowform : SuperSpell
{
    public float m_Contrast = -0.29f;
    public float m_Desaturate = 0.8f;
    public float m_FadeInTime = 1f;
    public float m_FxIntensity = 4f;
    public float m_Intensity = 0.85f;
    private Material m_MaterialInstance;
    public Material m_ShadowformMaterial;
    public Color m_Tint = new Color(0.6914063f, 0.328125f, 0.8046875f, 1f);

    protected override void OnAction(SpellStateType prevStateType)
    {
        base.OnAction(prevStateType);
        if (this.m_ShadowformMaterial != null)
        {
            Actor actor = base.GetTargetCard().GetEntity().GetHeroCard().GetActor();
            this.m_MaterialInstance = new Material(this.m_ShadowformMaterial);
            Texture portraitTexture = actor.GetPortraitTexture();
            this.m_MaterialInstance.mainTexture = portraitTexture;
            actor.SetPortraitMaterial(this.m_MaterialInstance);
            this.OnSpellFinished();
            Action<object> action = delegate (object desat) {
                this.m_MaterialInstance.SetFloat("_Desaturate", (float) desat);
            };
            object[] args = new object[] { "time", this.m_FadeInTime, "from", 0f, "to", this.m_Desaturate, "onupdate", action, "onupdatetarget", actor.gameObject };
            Hashtable hashtable = iTween.Hash(args);
            iTween.ValueTo(actor.gameObject, hashtable);
            Action<object> action2 = delegate (object col) {
                this.m_MaterialInstance.SetColor("_Color", (Color) col);
            };
            object[] objArray2 = new object[] { "time", this.m_FadeInTime, "from", Color.white, "to", this.m_Tint, "onupdate", action2, "onupdatetarget", actor.gameObject };
            Hashtable hashtable2 = iTween.Hash(objArray2);
            iTween.ValueTo(actor.gameObject, hashtable2);
            Action<object> action3 = delegate (object desat) {
                this.m_MaterialInstance.SetFloat("_Contrast", (float) desat);
            };
            object[] objArray3 = new object[] { "time", this.m_FadeInTime, "from", 0f, "to", this.m_Contrast, "onupdate", action3, "onupdatetarget", actor.gameObject };
            Hashtable hashtable3 = iTween.Hash(objArray3);
            iTween.ValueTo(actor.gameObject, hashtable3);
            Action<object> action4 = delegate (object desat) {
                this.m_MaterialInstance.SetFloat("_Intensity", (float) desat);
            };
            object[] objArray4 = new object[] { "time", this.m_FadeInTime, "from", 1f, "to", this.m_Intensity, "onupdate", action4, "onupdatetarget", actor.gameObject };
            Hashtable hashtable4 = iTween.Hash(objArray4);
            iTween.ValueTo(actor.gameObject, hashtable4);
            Action<object> action5 = delegate (object desat) {
                this.m_MaterialInstance.SetFloat("_FxIntensity", (float) desat);
            };
            object[] objArray5 = new object[] { "time", this.m_FadeInTime, "from", 0f, "to", this.m_FxIntensity, "onupdate", action5, "onupdatetarget", actor.gameObject };
            Hashtable hashtable5 = iTween.Hash(objArray5);
            iTween.ValueTo(actor.gameObject, hashtable5);
        }
    }
}

