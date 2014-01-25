using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDucker : MonoBehaviour
{
    public bool m_DuckAllCategories = true;
    public List<SoundDuckedCategoryDef> m_DuckedCategoryDefs;
    private bool m_ducking;
    public SoundDuckedCategoryDef m_GlobalDuckDef;

    private void Awake()
    {
        this.InitDuckedCategoryDefs();
    }

    public List<SoundDuckedCategoryDef> GetDuckedCategoryDefs()
    {
        return this.m_DuckedCategoryDefs;
    }

    private void InitDuckedCategoryDefs()
    {
        if (this.m_DuckAllCategories && (this.m_GlobalDuckDef != null))
        {
            this.m_DuckedCategoryDefs = new List<SoundDuckedCategoryDef>();
            IEnumerator enumerator = Enum.GetValues(typeof(SoundCategory)).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    SoundCategory current = (SoundCategory) ((int) enumerator.Current);
                    if (current != SoundCategory.NONE)
                    {
                        SoundDuckedCategoryDef dst = new SoundDuckedCategoryDef();
                        SoundUtils.CopyDuckedCategoryDef(this.m_GlobalDuckDef, dst);
                        dst.m_Category = current;
                        this.m_DuckedCategoryDefs.Add(dst);
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                }
                disposable.Dispose();
            }
        }
    }

    public bool IsDucking()
    {
        return this.m_ducking;
    }

    private void OnDestroy()
    {
        this.StopDucking();
    }

    public void StartDucking()
    {
        if ((SoundManager.Get() != null) && !this.m_ducking)
        {
            this.m_ducking = SoundManager.Get().StartDucking(this);
        }
    }

    public void StopDucking()
    {
        if ((SoundManager.Get() != null) && this.m_ducking)
        {
            this.m_ducking = false;
            SoundManager.Get().StopDucking(this);
        }
    }

    public override string ToString()
    {
        return string.Format("[SoundDucker: {0}]", base.name);
    }
}

