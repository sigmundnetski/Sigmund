using System;
using UnityEngine;

public class DrawWireframe : MonoBehaviour
{
    private void OnPostRender()
    {
        GL.wireframe = false;
    }

    private void OnPreRender()
    {
        GL.wireframe = true;
    }
}

