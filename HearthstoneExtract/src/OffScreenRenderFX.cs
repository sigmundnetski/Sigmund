using System;
using UnityEngine;

public class OffScreenRenderFX : MonoBehaviour
{
    public float AboveClip = 1f;
    public float BelowClip = 1f;
    public Rect CameraRect = new Rect(0f, 0f, 1f, 1f);
    public float ForceSize;
    private const int IgnoreLayer = 0x15;
    public GameObject ObjectToRender;
    private Camera offscreenFXCamera;
    private GameObject offscreenFXCameraGO;
    private Bounds RenderBounds;
    public int RenderResolutionX = 0x100;
    public int RenderResolutionY = 0x100;
    private static float s_Xoffset = 250f;
    private static float s_Yoffset = 250f;
    private RenderTexture tempRenderBuffer;
    public bool UseBounds = true;
    private float Yoffset;

    private void CreateCamera()
    {
        if (this.offscreenFXCameraGO == null)
        {
            if (this.offscreenFXCamera != null)
            {
                UnityEngine.Object.Destroy(this.offscreenFXCamera);
            }
            this.offscreenFXCameraGO = new GameObject();
            this.offscreenFXCamera = this.offscreenFXCameraGO.AddComponent<Camera>();
            this.offscreenFXCameraGO.name = base.name + "_OffScreenFXCamera";
            this.offscreenFXCameraGO.hideFlags = HideFlags.HideAndDontSave;
        }
    }

    private void CreateRenderTexture()
    {
        this.tempRenderBuffer = RenderTexture.GetTemporary(this.RenderResolutionX, this.RenderResolutionY);
    }

    private void OnDestroy()
    {
        if ((this.tempRenderBuffer != null) && this.tempRenderBuffer.IsCreated())
        {
            RenderTexture.ReleaseTemporary(this.tempRenderBuffer);
        }
    }

    private void PositionObjectToRender()
    {
        Vector3 vector = (Vector3) (Vector3.up * this.Yoffset);
        Vector3 vector2 = (Vector3) (Vector3.right * s_Xoffset);
        if (this.ObjectToRender != null)
        {
            Transform transform1 = this.ObjectToRender.transform;
            transform1.position += vector;
        }
        Transform transform = this.ObjectToRender.transform;
        transform.position += vector2;
    }

    private void SetupCamera()
    {
        this.offscreenFXCamera.orthographic = true;
        this.UpdateOffScreenCamera();
        this.offscreenFXCamera.transform.parent = base.transform;
        this.offscreenFXCamera.nearClipPlane = -this.AboveClip;
        this.offscreenFXCamera.farClipPlane = this.BelowClip;
        this.offscreenFXCamera.targetTexture = this.tempRenderBuffer;
        this.offscreenFXCamera.depth = Camera.main.depth - 1f;
        this.offscreenFXCamera.backgroundColor = Color.black;
        this.offscreenFXCamera.clearFlags = CameraClearFlags.Color;
        this.offscreenFXCamera.rect = this.CameraRect;
        this.offscreenFXCamera.enabled = true;
    }

    private void SetupMaterial()
    {
        base.gameObject.renderer.material.mainTexture = this.tempRenderBuffer;
    }

    private void Start()
    {
        if (this.UseBounds)
        {
            Mesh mesh = base.GetComponent<MeshFilter>().mesh;
            this.RenderBounds = mesh.bounds;
        }
        this.Yoffset = s_Yoffset;
        s_Yoffset += 10f;
        this.PositionObjectToRender();
        this.CreateCamera();
        this.CreateRenderTexture();
        this.SetupCamera();
        this.SetupMaterial();
        base.renderer.enabled = true;
    }

    private void UpdateOffScreenCamera()
    {
        if (this.ObjectToRender != null)
        {
            if (this.ForceSize == 0f)
            {
                float x = base.transform.localScale.x;
                if (this.UseBounds)
                {
                    x *= this.RenderBounds.size.x;
                }
                this.offscreenFXCamera.orthographicSize = x / 2f;
            }
            else
            {
                this.offscreenFXCamera.orthographicSize = this.ForceSize;
            }
            this.offscreenFXCameraGO.transform.position = this.ObjectToRender.transform.position;
            this.offscreenFXCameraGO.transform.rotation = this.ObjectToRender.transform.rotation;
            this.offscreenFXCameraGO.transform.Rotate((float) 90f, 180f, (float) 0f);
        }
    }
}

