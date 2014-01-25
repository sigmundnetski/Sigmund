using System;
using UnityEngine;

public class FontDownloadTest : MonoBehaviour
{
    private const string BUNDLE_PATH_FORMAT = "Final/FontDownloadTest/{0}.unity3d";
    private DownloadStatus m_downloadStatus;
    private AssetBundle m_fontBundle;
    public string m_FontName;
    private TextMesh m_textMesh;
    public GameObject m_TextMeshObject;

    private string GenerateBundleFilePath()
    {
        return string.Format("Final/FontDownloadTest/{0}.unity3d", this.m_FontName);
    }

    private void LoadFont()
    {
        this.m_downloadStatus = DownloadStatus.LOADING;
        string path = this.GenerateBundleFilePath();
        AssetLoader.Get().LoadFile(path, new AssetLoader.FileCallback(this.OnFontFileDownloaded), null);
    }

    private void OnDestroy()
    {
        if (this.m_fontBundle != null)
        {
            this.m_fontBundle.Unload(false);
        }
    }

    private void OnFontFileDownloaded(string path, WWW file, object callbackData)
    {
        if (file == null)
        {
            this.m_downloadStatus = DownloadStatus.FAIL;
            Debug.LogError(string.Format("FontDownloadTest.OnFileDownloaded() - file {0} failed to download", path));
        }
        else
        {
            this.m_fontBundle = file.assetBundle;
            if (this.m_fontBundle == null)
            {
                this.m_downloadStatus = DownloadStatus.FAIL;
                Debug.LogError(string.Format("FontDownloadTest.OnFileDownloaded() - file {0} does not contain an assetBundle", path));
            }
            else
            {
                Font mainAsset = this.m_fontBundle.mainAsset as Font;
                if (mainAsset == null)
                {
                    this.m_downloadStatus = DownloadStatus.FAIL;
                    Debug.LogError(string.Format("FontDownloadTest.OnFileDownloaded() - asset bundle {0} does not have a Font as its mainAsset", path));
                }
                else
                {
                    this.m_textMesh.font = mainAsset;
                    this.m_textMesh.renderer.material = mainAsset.material;
                    this.m_downloadStatus = DownloadStatus.SUCCESS;
                    Debug.Log(string.Format("FontDownloadTest.OnFileDownloaded() - successfully applied font {0} to TextMesh {1}", mainAsset.name, this.m_textMesh.gameObject.name));
                }
            }
        }
    }

    private void OnGUI()
    {
        Vector2 vector = new Vector2(Screen.width * 0.05f, Screen.height * 0.05f);
        Vector2 vector2 = new Vector2(vector.x, vector.y);
        Vector2 vector3 = new Vector2();
        vector3 = vector2;
        if (this.m_downloadStatus == DownloadStatus.NONE)
        {
            Vector2 vector4 = new Vector2(150f, 30f);
            if (GUI.Button(new Rect(vector3.x, vector3.y, vector4.x, vector4.y), "Download Font"))
            {
                this.LoadFont();
            }
            vector3.y += 1.5f * vector4.y;
        }
        else
        {
            Vector2 vector5 = new Vector2(500f, 20f);
            Color contentColor = GUI.contentColor;
            if (this.m_downloadStatus == DownloadStatus.SUCCESS)
            {
                GUI.contentColor = Color.green;
                GUI.Box(new Rect(vector3.x, vector3.y, vector5.x, vector5.y), "Download success!");
            }
            else if (this.m_downloadStatus == DownloadStatus.LOADING)
            {
                GUI.contentColor = Color.yellow;
                GUI.Box(new Rect(vector3.x, vector3.y, vector5.x, vector5.y), "Downloading...");
            }
            else if (this.m_downloadStatus == DownloadStatus.FAIL)
            {
                GUI.contentColor = Color.red;
                GUI.Box(new Rect(vector3.x, vector3.y, vector5.x, vector5.y), "Download failed!");
            }
            vector3.y += 1.5f * vector5.y;
            GUI.contentColor = contentColor;
        }
    }

    private void Start()
    {
        if (this.m_TextMeshObject == null)
        {
            Debug.LogError("FontTest.Start() - m_TextMeshObject is null! You must supply an object with a TextMesh to start the test.");
        }
        else
        {
            this.m_textMesh = this.m_TextMeshObject.GetComponent<TextMesh>();
            if (this.m_textMesh == null)
            {
                Debug.LogError(string.Format("FontTest.Start() - {0} has no TextMesh component! The object needs a TextMesh component to start the test.", this.m_TextMeshObject));
            }
        }
    }

    private enum DownloadStatus
    {
        NONE,
        LOADING,
        SUCCESS,
        FAIL
    }
}

