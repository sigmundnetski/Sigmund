using System;
using UnityEngine;

public class Stealth : MonoBehaviour
{
    public float AboveClip = 0.4f;
    public float BelowClip = 0.4f;
    private const int IgnoreLayer = 0x15;
    public int RenderResolutionX = 0x100;
    public int RenderResolutionY = 0x100;
    private Camera stealthCamera;
    private GameObject stealthCameraGO;
    private RenderTexture tempRenderBuffer;

    private void CameraRender()
    {
        this.stealthCamera.Render();
    }

    private void CreateCamera()
    {
        if (this.stealthCameraGO == null)
        {
            if (this.stealthCamera != null)
            {
                UnityEngine.Object.Destroy(this.stealthCamera);
            }
            this.stealthCameraGO = new GameObject();
            this.stealthCamera = this.stealthCameraGO.AddComponent<Camera>();
            this.stealthCameraGO.name = base.name + "_StealthFXCamera";
            this.stealthCameraGO.hideFlags = HideFlags.HideAndDontSave;
        }
    }

    private void CreateRenderTexture()
    {
        this.tempRenderBuffer = RenderTexture.GetTemporary(this.RenderResolutionX, this.RenderResolutionY);
    }

    private void OnDestroy()
    {
        this.tempRenderBuffer.Release();
    }

    private void SetupCamera()
    {
        this.stealthCamera.orthographic = true;
        this.UpdateOffScreenCamera();
        this.stealthCamera.transform.parent = base.transform;
        this.stealthCamera.nearClipPlane = -this.AboveClip;
        this.stealthCamera.farClipPlane = this.BelowClip;
        this.stealthCamera.targetTexture = this.tempRenderBuffer;
        this.stealthCamera.depth = Camera.main.depth - 1f;
        this.stealthCamera.backgroundColor = Color.black;
        this.stealthCamera.clearFlags = CameraClearFlags.Color;
        this.stealthCamera.cullingMask &= -2097153;
        this.stealthCamera.enabled = false;
    }

    private void SetupMaterial()
    {
        base.gameObject.renderer.material.mainTexture = this.tempRenderBuffer;
    }

    private void Start()
    {
        this.CreateCamera();
        this.CreateRenderTexture();
        this.SetupCamera();
        this.SetupMaterial();
    }

    private void UpdateOffScreenCamera()
    {
        this.stealthCamera.orthographicSize = 1f;
        this.stealthCameraGO.transform.position = base.transform.position;
        this.stealthCameraGO.transform.rotation = base.transform.rotation;
        this.stealthCameraGO.transform.Rotate((float) 90f, 180f, (float) 0f);
    }
}

