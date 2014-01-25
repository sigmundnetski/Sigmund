using System;
using UnityEngine;

[ExecuteInEditMode]
public class ShowFPS : MonoBehaviour
{
    private int frames;
    private GUIText m_GuiText;
    private double m_LastInterval;
    private float m_UpdateInterval = 0.5f;
    private bool m_verbose;
    private static ShowFPS s_instance;

    private void Awake()
    {
        s_instance = this;
    }

    public void DisableNow()
    {
        UnityEngine.Object.DestroyImmediate(base.gameObject);
    }

    public static ShowFPS Get()
    {
        return s_instance;
    }

    private void OnDisable()
    {
        if (this.m_GuiText != null)
        {
            UnityEngine.Object.DestroyImmediate(this.m_GuiText.gameObject);
        }
    }

    private void Start()
    {
        if (!ApplicationMgr.IsInternal())
        {
            UnityEngine.Object.Destroy(this);
        }
        else
        {
            this.m_LastInterval = UnityEngine.Time.realtimeSinceStartup;
            this.frames = 0;
        }
    }

    private void Update()
    {
        bool flag = false;
        foreach (Camera camera in Camera.allCameras)
        {
            FullScreenEffects component = camera.GetComponent<FullScreenEffects>();
            if ((component != null) && component.enabled)
            {
                flag = true;
            }
        }
        this.frames++;
        float realtimeSinceStartup = UnityEngine.Time.realtimeSinceStartup;
        if (realtimeSinceStartup > (this.m_LastInterval + this.m_UpdateInterval))
        {
            string str;
            if (this.m_GuiText == null)
            {
                GameObject obj2 = new GameObject("FPS") {
                    transform = { position = Vector3.zero }
                };
                this.m_GuiText = obj2.AddComponent<GUIText>();
                obj2.hideFlags = HideFlags.HideAndDontSave;
                this.m_GuiText.pixelOffset = new Vector2(Screen.width * 0.7f, 15f);
            }
            float num3 = ((float) this.frames) / (realtimeSinceStartup - ((float) this.m_LastInterval));
            if (this.m_verbose)
            {
                str = string.Format("{0:f2} - {1} frames over {2}sec", num3, this.frames, this.m_UpdateInterval);
            }
            else
            {
                str = string.Format("{0:f2}", num3);
            }
            if (flag)
            {
                this.m_GuiText.text = string.Format("{0} - FSE", str);
            }
            else
            {
                this.m_GuiText.text = str;
            }
            this.frames = 0;
            this.m_LastInterval = realtimeSinceStartup;
        }
    }
}

