using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PageTurn : MonoBehaviour
{
    private readonly string BACK_PAGE_NAME = "PageTurnBack";
    private readonly string FRONT_PAGE_NAME = "PageTurnFront";
    private GameObject m_BackPageGameObject;
    private GameObject m_FrontPageGameObject;
    private Vector3 m_initialPosition;
    public Shader m_MaskShader;
    private GameObject m_MeshGameObject;
    private Camera m_OffscreenPageTurnCamera;
    private GameObject m_OffscreenPageTurnCameraGO;
    private Camera m_OffscreenPageTurnMaskCamera;
    private Bounds m_RenderBounds;
    private float m_RenderOffset = 500f;
    private RenderTexture m_TempMaskBuffer;
    private RenderTexture m_TempRenderBuffer;
    private GameObject m_TheBoxFrame;
    public float m_TurnLeftSpeed = 1.65f;
    public float m_TurnRightSpeed = 1.65f;
    private readonly string PAGE_CENTER_NAME = "PageCenter";
    private readonly string PAGE_TURN_LEFT_ANIM = "PageTurnLeft";
    private readonly string PAGE_TURN_MAT_ANIM = "PageTurnMaterialAnimation";
    private readonly string PAGE_TURN_RIGHT_ANIM = "PageTurnRight";
    private readonly string THE_BOX_FRAME = "TheBox_OuterFrame";
    private readonly string WAIT_THEN_COMPLETE_PAGE_TURN_COROUTINE = "WaitThenCompletePageTurn";

    private void CreateCamera()
    {
        if (this.m_OffscreenPageTurnCameraGO == null)
        {
            if (this.m_OffscreenPageTurnCamera != null)
            {
                UnityEngine.Object.DestroyImmediate(this.m_OffscreenPageTurnCamera);
            }
            this.m_OffscreenPageTurnCameraGO = new GameObject();
            this.m_OffscreenPageTurnCamera = this.m_OffscreenPageTurnCameraGO.AddComponent<Camera>();
            this.m_OffscreenPageTurnCameraGO.name = base.name + "_OffScreenPageTurnCamera";
            this.SetupCamera(this.m_OffscreenPageTurnCamera);
            this.m_OffscreenPageTurnCamera.targetTexture = this.m_TempRenderBuffer;
        }
        if (this.m_OffscreenPageTurnMaskCamera == null)
        {
            GameObject obj2 = new GameObject();
            this.m_OffscreenPageTurnMaskCamera = obj2.AddComponent<Camera>();
            obj2.name = base.name + "_OffScreenPageTurnMaskCamera";
            this.SetupCamera(this.m_OffscreenPageTurnMaskCamera);
            this.m_OffscreenPageTurnMaskCamera.SetReplacementShader(this.m_MaskShader, "BasePage");
            this.m_OffscreenPageTurnMaskCamera.targetTexture = this.m_TempMaskBuffer;
        }
    }

    private void CreateRenderTexture()
    {
        Log.Kyle.Print("PageTurn Create Texture");
        int width = Screen.currentResolution.width;
        if (width < Screen.currentResolution.height)
        {
            width = Screen.currentResolution.height;
        }
        int num2 = 0x200;
        if (width > 640)
        {
            num2 = 0x400;
        }
        if (width > 0x500)
        {
            num2 = 0x800;
        }
        if (width > 0x9c4)
        {
            num2 = 0x1000;
        }
        this.m_TempRenderBuffer = new RenderTexture(num2, num2, 0x20);
        this.m_TempRenderBuffer.Create();
        this.m_TempMaskBuffer = new RenderTexture(num2, num2, 0x20);
        this.m_TempMaskBuffer.Create();
    }

    private Transform FindPageCenter(GameObject page)
    {
        Transform transform = page.transform.Find(this.PAGE_CENTER_NAME);
        if (transform == null)
        {
            UnityEngine.Debug.LogError("Failed to find " + this.PAGE_CENTER_NAME + " Object.");
        }
        return transform;
    }

    public float GetLeftTurnAnimTime()
    {
        return (base.animation[this.PAGE_TURN_LEFT_ANIM].length / this.m_TurnLeftSpeed);
    }

    public static Vector3 GetWorldScale(Transform transform)
    {
        Vector3 localScale = transform.localScale;
        for (Transform transform2 = transform.parent; transform2 != null; transform2 = transform2.parent)
        {
            localScale = Vector3.Scale(localScale, transform2.localScale);
        }
        return localScale;
    }

    private void Render(GameObject page)
    {
        Log.Kyle.Print("PageTurn Render");
        this.Show(true);
        bool flag = true;
        if (this.m_TheBoxFrame != null)
        {
            flag = this.m_TheBoxFrame.renderer.enabled;
            this.m_TheBoxFrame.renderer.enabled = false;
        }
        this.m_OffscreenPageTurnCameraGO.transform.position = base.transform.position;
        bool enabled = this.m_FrontPageGameObject.renderer.enabled;
        bool flag3 = this.m_BackPageGameObject.renderer.enabled;
        this.m_FrontPageGameObject.renderer.enabled = false;
        this.m_BackPageGameObject.renderer.enabled = false;
        this.m_OffscreenPageTurnCamera.Render();
        this.m_OffscreenPageTurnMaskCamera.transform.position = base.transform.position;
        this.m_OffscreenPageTurnMaskCamera.RenderWithShader(this.m_MaskShader, "BasePage");
        this.m_FrontPageGameObject.renderer.enabled = enabled;
        this.m_BackPageGameObject.renderer.enabled = flag3;
        if (this.m_TheBoxFrame != null)
        {
            this.m_TheBoxFrame.renderer.enabled = flag;
        }
    }

    private void SetupCamera(Camera camera)
    {
        camera.orthographic = true;
        camera.orthographicSize = GetWorldScale(this.m_FrontPageGameObject.transform).x / 2f;
        camera.transform.parent = base.transform;
        camera.nearClipPlane = -20f;
        camera.farClipPlane = 20f;
        camera.depth = (Camera.main != null) ? (Camera.main.depth + 100f) : 0f;
        camera.backgroundColor = Color.black;
        camera.clearFlags = CameraClearFlags.Color;
        camera.enabled = false;
        camera.renderingPath = RenderingPath.Forward;
        camera.transform.Rotate((float) 90f, 0f, (float) 0f);
        camera.hideFlags = HideFlags.HideAndDontSave;
    }

    private void SetupMaterial()
    {
        Material material = this.m_FrontPageGameObject.renderer.material;
        material.mainTexture = this.m_TempRenderBuffer;
        material.SetTexture("_MaskTex", this.m_TempMaskBuffer);
        material.renderQueue = 0xbb9;
        Material material2 = this.m_BackPageGameObject.renderer.material;
        material2.SetTexture("_MaskTex", this.m_TempMaskBuffer);
        material2.renderQueue = 0xbba;
    }

    private void Show(bool show)
    {
        base.transform.position = !show ? ((Vector3) (Vector3.right * this.m_RenderOffset)) : this.m_initialPosition;
    }

    private void Start()
    {
        this.m_initialPosition = base.transform.position;
        Transform transform = base.transform.Find(this.FRONT_PAGE_NAME);
        if (transform != null)
        {
            this.m_FrontPageGameObject = transform.gameObject;
        }
        if (this.m_FrontPageGameObject == null)
        {
            UnityEngine.Debug.LogError("Failed to find " + this.FRONT_PAGE_NAME + " Object.");
        }
        transform = base.transform.Find(this.BACK_PAGE_NAME);
        if (transform != null)
        {
            this.m_BackPageGameObject = transform.gameObject;
        }
        if (this.m_BackPageGameObject == null)
        {
            UnityEngine.Debug.LogError("Failed to find " + this.BACK_PAGE_NAME + " Object.");
        }
        this.Show(false);
        this.m_TheBoxFrame = GameObject.Find(this.THE_BOX_FRAME);
        this.CreateRenderTexture();
        this.CreateCamera();
        this.SetupMaterial();
    }

    public void TurnLeft(GameObject flippingPage, GameObject otherPage)
    {
        this.TurnLeft(flippingPage, otherPage, null);
    }

    public void TurnLeft(GameObject flippingPage, GameObject otherPage, DelOnPageTurnComplete callback)
    {
        this.TurnLeft(flippingPage, otherPage, callback, null);
    }

    public void TurnLeft(GameObject flippingPage, GameObject otherPage, DelOnPageTurnComplete callback, object callbackData)
    {
        TurnPageData data = new TurnPageData {
            flippingPage = flippingPage,
            otherPage = otherPage,
            callback = callback,
            callbackData = callbackData
        };
        base.StartCoroutine("TurnLeftPage", data);
    }

    [DebuggerHidden]
    private IEnumerator TurnLeftPage(TurnPageData pageData)
    {
        return new <TurnLeftPage>c__Iterator1E { pageData = pageData, <$>pageData = pageData, <>f__this = this };
    }

    public void TurnRight(GameObject flippingPage, GameObject otherPage)
    {
        this.TurnRight(flippingPage, otherPage, null);
    }

    public void TurnRight(GameObject flippingPage, GameObject otherPage, DelOnPageTurnComplete callback)
    {
        this.TurnRight(flippingPage, otherPage, callback, null);
    }

    public void TurnRight(GameObject flippingPage, GameObject otherPage, DelOnPageTurnComplete callback, object callbackData)
    {
        this.Render(flippingPage);
        base.animation[this.PAGE_TURN_RIGHT_ANIM].time = 0f;
        base.animation[this.PAGE_TURN_RIGHT_ANIM].speed = this.m_TurnRightSpeed;
        base.animation.Play(this.PAGE_TURN_RIGHT_ANIM);
        this.m_FrontPageGameObject.renderer.material.SetFloat("_Alpha", 1f);
        this.m_BackPageGameObject.renderer.material.SetFloat("_Alpha", 1f);
        float num = base.animation[this.PAGE_TURN_RIGHT_ANIM].length / this.m_TurnRightSpeed;
        PageTurningData data2 = new PageTurningData {
            m_secondsToWait = num,
            m_callback = callback,
            m_callbackData = callbackData
        };
        PageTurningData data = data2;
        base.StopCoroutine(this.WAIT_THEN_COMPLETE_PAGE_TURN_COROUTINE);
        base.StartCoroutine(this.WAIT_THEN_COMPLETE_PAGE_TURN_COROUTINE, data);
    }

    [DebuggerHidden]
    private IEnumerator WaitThenCompletePageTurn(PageTurningData pageTurningData)
    {
        return new <WaitThenCompletePageTurn>c__Iterator1F { pageTurningData = pageTurningData, <$>pageTurningData = pageTurningData, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <TurnLeftPage>c__Iterator1E : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal PageTurn.TurnPageData <$>pageData;
        internal PageTurn <>f__this;
        internal float <actualAnimLength>__6;
        internal PageTurn.DelOnPageTurnComplete <callback>__2;
        internal object <callbackData>__3;
        internal GameObject <flippingPage>__0;
        internal GameObject <otherPage>__1;
        internal Vector3 <otherPagePos>__5;
        internal Vector3 <pagePos>__4;
        internal PageTurn.PageTurningData <pageTurningData>__7;
        internal PageTurn.TurnPageData pageData;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.$current = new WaitForEndOfFrame();
                    this.$PC = 1;
                    return true;

                case 1:
                {
                    this.<flippingPage>__0 = this.pageData.flippingPage;
                    this.<otherPage>__1 = this.pageData.otherPage;
                    this.<callback>__2 = this.pageData.callback;
                    this.<callbackData>__3 = this.pageData.callbackData;
                    this.<pagePos>__4 = this.<flippingPage>__0.transform.position;
                    this.<otherPagePos>__5 = this.<otherPage>__1.transform.position;
                    this.<flippingPage>__0.transform.position = this.<otherPagePos>__5;
                    this.<otherPage>__1.transform.position = this.<pagePos>__4;
                    this.<>f__this.Render(this.<flippingPage>__0);
                    this.<flippingPage>__0.transform.position = this.<pagePos>__4;
                    this.<otherPage>__1.transform.position = this.<otherPagePos>__5;
                    this.<>f__this.m_FrontPageGameObject.renderer.material.SetFloat("_Alpha", 1f);
                    this.<>f__this.m_BackPageGameObject.renderer.material.SetFloat("_Alpha", 1f);
                    this.<>f__this.animation[this.<>f__this.PAGE_TURN_LEFT_ANIM].time = 0f;
                    this.<>f__this.animation[this.<>f__this.PAGE_TURN_LEFT_ANIM].speed = this.<>f__this.m_TurnLeftSpeed;
                    this.<>f__this.animation.Play(this.<>f__this.PAGE_TURN_LEFT_ANIM);
                    this.<>f__this.animation[this.<>f__this.PAGE_TURN_MAT_ANIM].time = 0f;
                    this.<>f__this.animation[this.<>f__this.PAGE_TURN_MAT_ANIM].speed = this.<>f__this.m_TurnLeftSpeed;
                    this.<>f__this.animation.Blend(this.<>f__this.PAGE_TURN_MAT_ANIM, 1f, 0f);
                    this.<actualAnimLength>__6 = this.<>f__this.animation[this.<>f__this.PAGE_TURN_LEFT_ANIM].length / this.<>f__this.m_TurnLeftSpeed;
                    PageTurn.PageTurningData data = new PageTurn.PageTurningData {
                        m_secondsToWait = this.<actualAnimLength>__6,
                        m_callback = this.<callback>__2,
                        m_callbackData = this.<callbackData>__3
                    };
                    this.<pageTurningData>__7 = data;
                    this.<>f__this.StopCoroutine(this.<>f__this.WAIT_THEN_COMPLETE_PAGE_TURN_COROUTINE);
                    this.<>f__this.StartCoroutine(this.<>f__this.WAIT_THEN_COMPLETE_PAGE_TURN_COROUTINE, this.<pageTurningData>__7);
                    this.$PC = -1;
                    break;
                }
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <WaitThenCompletePageTurn>c__Iterator1F : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal PageTurn.PageTurningData <$>pageTurningData;
        internal PageTurn <>f__this;
        internal PageTurn.PageTurningData pageTurningData;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.$current = new WaitForSeconds(this.pageTurningData.m_secondsToWait);
                    this.$PC = 1;
                    return true;

                case 1:
                    this.<>f__this.Show(false);
                    if (this.pageTurningData.m_callback != null)
                    {
                        this.pageTurningData.m_callback(this.pageTurningData.m_callbackData);
                        this.$PC = -1;
                        break;
                    }
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    public delegate void DelOnPageTurnComplete(object callbackData);

    private class PageTurningData
    {
        public PageTurn.DelOnPageTurnComplete m_callback;
        public object m_callbackData;
        public float m_secondsToWait;
    }

    private class TurnPageData
    {
        public PageTurn.DelOnPageTurnComplete callback;
        public object callbackData;
        public GameObject flippingPage;
        public GameObject otherPage;
    }
}

