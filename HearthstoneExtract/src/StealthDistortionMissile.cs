using System;
using UnityEngine;

public class StealthDistortionMissile : MonoBehaviour
{
    private Camera boardCamera;
    private GameObject boardCameraGO;
    private RenderTexture boardRenderBuffer;
    public float DistortionAboveClip = -0.1f;
    public float DistortionBelowClip = 10f;
    public int DistortionResolutionX = 0x100;
    public int DistortionResolutionY = 0x100;
    private const int IgnoreLayer = 0x15;
    public GameObject ObjectToRender;
    public float ParticleAboveClip = 1f;
    public float ParticleBelowClip = 1f;
    private Camera particleCamera;
    private GameObject particleCameraGO;
    private RenderTexture particleRenderBuffer;
    public int ParticleResolutionX = 0x100;
    public int ParticleResolutionY = 0x100;
    public float RenderOffsetX;
    public float RenderOffsetY;
    public float RenderOffsetZ;
    private static float s_Yoffset = 50f;
    private float Yoffset;

    private void CreateCameras()
    {
        if (this.particleCameraGO == null)
        {
            if (this.particleCamera != null)
            {
                UnityEngine.Object.Destroy(this.particleCamera);
            }
            this.particleCameraGO = new GameObject();
            this.particleCamera = this.particleCameraGO.AddComponent<Camera>();
            this.particleCameraGO.name = base.name + "_DistortionParticleFXCamera";
        }
        if (this.boardCameraGO == null)
        {
            if (this.boardCamera != null)
            {
                UnityEngine.Object.Destroy(this.boardCamera);
            }
            this.boardCameraGO = new GameObject();
            this.boardCamera = this.boardCameraGO.AddComponent<Camera>();
            this.boardCameraGO.name = base.name + "_DistortionBoardFXCamera";
        }
    }

    private void CreateRenderTextures()
    {
        this.particleRenderBuffer = RenderTexture.GetTemporary(this.ParticleResolutionX, this.ParticleResolutionY);
        this.boardRenderBuffer = RenderTexture.GetTemporary(this.DistortionResolutionX, this.DistortionResolutionY);
    }

    private void OnDestroy()
    {
        this.particleRenderBuffer.Release();
        this.boardRenderBuffer.Release();
    }

    private void PositionObjectToRender()
    {
        Vector3 vector = (Vector3) (Vector3.up * this.Yoffset);
        Transform transform = this.ObjectToRender.transform;
        transform.position += vector;
    }

    private void SetupCameras()
    {
        this.particleCamera.orthographic = true;
        this.particleCamera.orthographicSize = base.transform.localScale.x / 2f;
        this.particleCameraGO.transform.position = this.ObjectToRender.transform.position;
        this.particleCameraGO.transform.Translate(this.RenderOffsetX, this.RenderOffsetY, this.RenderOffsetZ);
        this.particleCameraGO.transform.rotation = this.ObjectToRender.transform.rotation;
        this.particleCameraGO.transform.Rotate((float) 90f, 180f, (float) 0f);
        this.particleCamera.transform.parent = base.transform;
        this.particleCamera.nearClipPlane = -this.ParticleAboveClip;
        this.particleCamera.farClipPlane = this.ParticleBelowClip;
        this.particleCamera.targetTexture = this.particleRenderBuffer;
        this.particleCamera.depth = Camera.main.depth - 1f;
        this.particleCamera.backgroundColor = Color.black;
        this.particleCamera.clearFlags = CameraClearFlags.Color;
        this.particleCamera.cullingMask &= -2097153;
        this.particleCamera.enabled = true;
        this.boardCamera.orthographic = true;
        this.boardCamera.orthographicSize = base.transform.localScale.x / 2f;
        this.boardCameraGO.transform.position = base.transform.position;
        this.boardCameraGO.transform.rotation = base.transform.rotation;
        this.boardCameraGO.transform.Rotate((float) 90f, 180f, (float) 0f);
        this.boardCamera.transform.parent = base.transform;
        this.boardCamera.nearClipPlane = -this.DistortionAboveClip;
        this.boardCamera.farClipPlane = this.DistortionBelowClip;
        this.boardCamera.targetTexture = this.boardRenderBuffer;
        this.boardCamera.depth = Camera.main.depth - 1f;
        this.boardCamera.backgroundColor = Color.black;
        this.boardCamera.clearFlags = CameraClearFlags.Color;
        this.boardCamera.cullingMask &= -2097153;
        this.boardCamera.enabled = true;
    }

    private void SetupMaterial()
    {
        Material material = base.gameObject.renderer.material;
        material.mainTexture = this.boardRenderBuffer;
        material.SetTexture("_ParticleTex", this.particleRenderBuffer);
    }

    private void Start()
    {
        this.Yoffset = s_Yoffset;
        s_Yoffset += 10f;
        this.PositionObjectToRender();
        this.CreateCameras();
        this.CreateRenderTextures();
        this.SetupCameras();
        this.SetupMaterial();
        base.renderer.enabled = true;
    }
}

