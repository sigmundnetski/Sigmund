using System;
using UnityEngine;

public class CameraSelector : MonoBehaviour
{
    public bool activateOnStart;
    public Vector3 cameraPosition;
    public Vector3 cameraRotation;

    private void OnMouseDown()
    {
        Camera.main.transform.rotation = Quaternion.Euler(this.cameraRotation);
        Camera.main.transform.position = this.cameraPosition;
    }

    private void Start()
    {
        if (this.activateOnStart)
        {
            Camera.main.transform.rotation = Quaternion.Euler(this.cameraRotation);
            Camera.main.transform.position = this.cameraPosition;
        }
    }
}

