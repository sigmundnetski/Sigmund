using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScreenResizeDetector : MonoBehaviour
{
    private float m_screenHeight;
    private float m_screenWidth;
    private List<SizeChangedListener> m_sizeChangedListeners = new List<SizeChangedListener>();

    public bool AddSizeChangedListener(SizeChangedCallback callback)
    {
        return this.AddSizeChangedListener(callback, null);
    }

    public bool AddSizeChangedListener(SizeChangedCallback callback, object userData)
    {
        SizeChangedListener item = new SizeChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        if (this.m_sizeChangedListeners.Contains(item))
        {
            return false;
        }
        this.m_sizeChangedListeners.Add(item);
        return true;
    }

    private void Awake()
    {
        this.SaveScreenSize();
    }

    private void FireSizeChangedEvent()
    {
        SizeChangedListener[] listenerArray = this.m_sizeChangedListeners.ToArray();
        for (int i = 0; i < listenerArray.Length; i++)
        {
            listenerArray[i].Fire();
        }
    }

    private void OnPreCull()
    {
        float width = Screen.width;
        float height = Screen.height;
        if (!object.Equals(this.m_screenWidth, width) || !object.Equals(this.m_screenHeight, height))
        {
            this.SaveScreenSize();
            this.FireSizeChangedEvent();
        }
    }

    public bool RemoveSizeChangedListener(SizeChangedCallback callback)
    {
        return this.RemoveSizeChangedListener(callback, null);
    }

    public bool RemoveSizeChangedListener(SizeChangedCallback callback, object userData)
    {
        SizeChangedListener item = new SizeChangedListener();
        item.SetCallback(callback);
        item.SetUserData(userData);
        return this.m_sizeChangedListeners.Remove(item);
    }

    private void SaveScreenSize()
    {
        this.m_screenWidth = Screen.width;
        this.m_screenHeight = Screen.height;
    }

    public delegate void SizeChangedCallback(object userData);

    private class SizeChangedListener : EventListener<ScreenResizeDetector.SizeChangedCallback>
    {
        public void Fire()
        {
            base.m_callback(base.m_userData);
        }
    }
}

