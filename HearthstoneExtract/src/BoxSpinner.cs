using System;
using UnityEngine;

public class BoxSpinner : MonoBehaviour
{
    private BoxSpinnerStateInfo m_info;
    private Box m_parent;
    private bool m_spinning;
    private float m_spinY;

    public BoxSpinnerStateInfo GetInfo()
    {
        return this.m_info;
    }

    public Box GetParent()
    {
        return this.m_parent;
    }

    public bool IsSpinning()
    {
        return this.m_spinning;
    }

    public void Reset()
    {
        this.m_spinning = false;
        base.transform.localRotation = Quaternion.identity;
    }

    public void SetInfo(BoxSpinnerStateInfo info)
    {
        this.m_info = info;
    }

    public void SetParent(Box parent)
    {
        this.m_parent = parent;
    }

    public void Spin()
    {
        this.m_spinning = true;
    }

    public void Stop()
    {
        this.m_spinning = false;
    }

    private void Update()
    {
        if (this.IsSpinning())
        {
            base.transform.localRotation = Quaternion.Euler(new Vector3(0f, this.m_spinY, 0f));
            this.m_spinY += this.m_info.m_DegreesPerSec * UnityEngine.Time.deltaTime;
            if (Mathf.Abs(this.m_spinY) >= 360f)
            {
                this.m_spinY = this.m_spinY % 360f;
            }
        }
    }
}

