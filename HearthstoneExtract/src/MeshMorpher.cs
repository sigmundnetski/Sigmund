using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshMorpher : MonoBehaviour
{
    public bool m_AnimateAutomatically = true;
    private float m_AutomaticTime;
    private int m_DstMesh = -1;
    private Mesh m_Mesh;
    public Mesh[] m_Meshes;
    public float m_OneLoopLength = 1f;
    private int m_SrcMesh = -1;
    private float m_Weight = -1f;
    public WrapMode m_WrapMode = WrapMode.Loop;

    private void Awake()
    {
        base.enabled = this.m_AnimateAutomatically;
        MeshFilter component = base.GetComponent(typeof(MeshFilter)) as MeshFilter;
        for (int i = 0; i < this.m_Meshes.Length; i++)
        {
            if (this.m_Meshes[i] == null)
            {
                Debug.Log("MeshMorpher mesh  " + i + " has not been setup correctly");
                this.m_AnimateAutomatically = false;
                return;
            }
        }
        if (this.m_Meshes.Length < 2)
        {
            Debug.Log("The mesh morpher needs at least 2 source meshes");
            this.m_AnimateAutomatically = false;
        }
        else
        {
            component.sharedMesh = this.m_Meshes[0];
            this.m_Mesh = component.mesh;
            int vertexCount = this.m_Mesh.vertexCount;
            for (int j = 0; j < this.m_Meshes.Length; j++)
            {
                if (this.m_Meshes[j].vertexCount != vertexCount)
                {
                    Debug.Log("Mesh " + j + " doesn't have the same number of vertices as the first mesh");
                    this.m_AnimateAutomatically = false;
                    return;
                }
            }
        }
    }

    public void SetComplexMorph(int srcIndex, int dstIndex, float t)
    {
        if (((this.m_SrcMesh != srcIndex) || (this.m_DstMesh != dstIndex)) || !Mathf.Approximately(this.m_Weight, t))
        {
            Vector3[] vertices = this.m_Meshes[srcIndex].vertices;
            Vector3[] vectorArray2 = this.m_Meshes[dstIndex].vertices;
            Vector3[] vectorArray3 = new Vector3[this.m_Mesh.vertexCount];
            for (int i = 0; i < vectorArray3.Length; i++)
            {
                vectorArray3[i] = Vector3.Lerp(vertices[i], vectorArray2[i], t);
            }
            this.m_Mesh.vertices = vectorArray3;
            this.m_Mesh.RecalculateBounds();
        }
    }

    public void SetMorph(float t)
    {
        int num = (int) t;
        num = Mathf.Clamp(num, 0, this.m_Meshes.Length - 2);
        float num2 = t - num;
        num2 = Mathf.Clamp((float) (t - num), (float) 0f, (float) 1f);
        this.SetComplexMorph(num, num + 1, num2);
    }

    private void Update()
    {
        if (this.m_AnimateAutomatically)
        {
            float num2;
            float num = (UnityEngine.Time.deltaTime * (this.m_Meshes.Length - 1)) / this.m_OneLoopLength;
            this.m_AutomaticTime += num;
            if (this.m_WrapMode == WrapMode.Loop)
            {
                num2 = Mathf.Repeat(this.m_AutomaticTime, (float) (this.m_Meshes.Length - 1));
            }
            else if (this.m_WrapMode == WrapMode.PingPong)
            {
                num2 = Mathf.PingPong(this.m_AutomaticTime, (float) (this.m_Meshes.Length - 1));
            }
            else
            {
                num2 = Mathf.Clamp(this.m_AutomaticTime, 0f, (float) (this.m_Meshes.Length - 1));
            }
            this.SetMorph(num2);
        }
    }
}

