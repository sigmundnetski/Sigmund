using System;
using System.Collections;
using UnityEngine;

public class ElectroScript : MonoBehaviour
{
    private Hashtable branches;
    private Vector3 deltaV1;
    private Vector3 deltaV2;
    public Dynamics dynamics;
    private float lastUpdate;
    public LineSettings lines;
    private int numVertices;
    public Prefabs prefabs;
    private float srcDstDist;
    private float srcTrgDist;
    public TextureSettings tex;
    public Timers timers;

    private void AnimateArc()
    {
        Vector2 mainTextureOffset = this.prefabs.lightning.renderer.material.mainTextureOffset;
        Vector2 mainTextureScale = this.prefabs.lightning.renderer.material.mainTextureScale;
        mainTextureOffset.x += UnityEngine.Time.deltaTime * this.tex.animateSpeed;
        mainTextureOffset.y = this.tex.offsetY;
        mainTextureScale.x = (this.srcTrgDist / this.srcDstDist) * this.tex.scaleX;
        mainTextureScale.y = this.tex.scaleY;
        this.prefabs.lightning.renderer.material.mainTextureOffset = mainTextureOffset;
        this.prefabs.lightning.renderer.material.mainTextureScale = mainTextureScale;
    }

    private void DrawArc()
    {
        this.numVertices = (Mathf.RoundToInt(this.srcTrgDist / this.lines.keyVertexDist) * (1 + this.lines.numInterpoles)) + 1;
        this.deltaV2 = (Vector3) ((this.prefabs.target.localPosition - this.prefabs.source.localPosition) / ((float) this.numVertices));
        Vector3 localPosition = this.prefabs.source.localPosition;
        Vector3[] vectorArray = new Vector3[this.numVertices];
        this.prefabs.lightning.SetVertexCount(this.numVertices);
        for (int i = 0; i < this.numVertices; i++)
        {
            Vector3 position = localPosition;
            position.y += ((UnityEngine.Random.value * 2f) - 1f) * this.lines.keyVertexRange;
            position.z += ((UnityEngine.Random.value * 2f) - 1f) * this.lines.keyVertexRange;
            this.prefabs.lightning.SetPosition(i, position);
            vectorArray[i] = position;
            if (!this.branches.ContainsKey(i))
            {
                if (UnityEngine.Random.value < this.dynamics.chanceToArc)
                {
                    LineRenderer renderer = (LineRenderer) UnityEngine.Object.Instantiate(this.prefabs.branch, Vector3.zero, Quaternion.identity);
                    renderer.GetComponent<BranchScript>().timeSpawned = UnityEngine.Time.time;
                    renderer.transform.parent = this.prefabs.lightning.transform;
                    this.branches.Add(i, renderer);
                    renderer.transform.position = this.prefabs.lightning.transform.TransformPoint(position);
                    position.x = UnityEngine.Random.value - 0.5f;
                    position.y = (UnityEngine.Random.value - 0.5f) * 2f;
                    position.z = (UnityEngine.Random.value - 0.5f) * 2f;
                    renderer.transform.LookAt(renderer.transform.TransformPoint(position));
                    renderer.transform.Find("stop").localPosition = renderer.transform.Find("start").localPosition + new Vector3(0f, 0f, UnityEngine.Random.Range(this.lines.minBranchLength, this.lines.maxBranchLength));
                    int count = (Mathf.RoundToInt(Vector3.Distance(renderer.transform.Find("start").position, renderer.transform.Find("stop").position) / this.lines.keyVertexDist) * (1 + this.lines.numInterpoles)) + 1;
                    Vector3 vector3 = (Vector3) ((renderer.transform.Find("stop").localPosition - renderer.transform.Find("start").localPosition) / ((float) count));
                    Vector3 vector4 = renderer.transform.Find("start").localPosition;
                    Vector3[] vectorArray2 = new Vector3[count];
                    renderer.SetVertexCount(count);
                    for (int k = 0; k < count; k++)
                    {
                        Vector3 vector5 = vector4;
                        vector5.x += ((UnityEngine.Random.value * 2f) - 1f) * this.lines.keyVertexRange;
                        vector5.y += ((UnityEngine.Random.value * 2f) - 1f) * this.lines.keyVertexRange;
                        renderer.SetPosition(k, vector5);
                        vectorArray2[k] = vector5;
                        vector4 += vector3 * (this.lines.numInterpoles + 1);
                        k += this.lines.numInterpoles;
                    }
                    renderer.SetPosition(0, renderer.transform.Find("start").localPosition);
                    renderer.SetPosition(count - 1, renderer.transform.Find("stop").localPosition);
                    for (int m = 0; m < count; m++)
                    {
                        if ((m % (this.lines.numInterpoles + 1)) != 0)
                        {
                            Vector3 a = vectorArray2[m - 1];
                            Vector3 b = vectorArray2[m + this.lines.numInterpoles];
                            float num6 = ((Vector3.Distance(a, b) / ((float) (this.lines.numInterpoles + 1))) / Vector3.Distance(a, b)) * 3.141593f;
                            for (int n = 0; n < this.lines.numInterpoles; n++)
                            {
                                Vector3 vector8;
                                vector8.x = a.x + (vector3.x * (1 + n));
                                vector8.y = a.y + (((Mathf.Sin(num6 - 1.570796f) / 2f) + 0.5f) * (b.y - a.y));
                                vector8.z = a.z + (((Mathf.Sin(num6 - 1.570796f) / 2f) + 0.5f) * (b.z - a.z));
                                renderer.SetPosition(m + n, vector8);
                                num6 += num6;
                            }
                            m += this.lines.numInterpoles;
                        }
                    }
                }
            }
            else
            {
                LineRenderer renderer2 = (LineRenderer) this.branches[i];
                int num8 = (Mathf.RoundToInt(Vector3.Distance(renderer2.transform.Find("start").position, renderer2.transform.Find("stop").position) / this.lines.keyVertexDist) * (1 + this.lines.numInterpoles)) + 1;
                Vector3 vector9 = (Vector3) ((renderer2.transform.Find("stop").localPosition - renderer2.transform.Find("start").localPosition) / ((float) num8));
                Vector3 vector10 = renderer2.transform.Find("start").localPosition;
                Vector3[] vectorArray3 = new Vector3[num8];
                renderer2.SetVertexCount(num8);
                renderer2.SetPosition(0, renderer2.transform.Find("start").localPosition);
                for (int num9 = 0; num9 < num8; num9++)
                {
                    Vector3 vector11 = vector10;
                    vector11.x += ((UnityEngine.Random.value * 2f) - 1f) * this.lines.keyVertexRange;
                    vector11.y += ((UnityEngine.Random.value * 2f) - 1f) * this.lines.keyVertexRange;
                    renderer2.SetPosition(num9, vector11);
                    vectorArray3[num9] = vector11;
                    vector10 += vector9 * (this.lines.numInterpoles + 1);
                    num9 += this.lines.numInterpoles;
                }
                renderer2.SetPosition(0, renderer2.transform.Find("start").localPosition);
                renderer2.SetPosition(num8 - 1, renderer2.transform.Find("stop").localPosition);
                for (int num10 = 0; num10 < num8; num10++)
                {
                    if ((num10 % (this.lines.numInterpoles + 1)) != 0)
                    {
                        Vector3 vector12 = vectorArray3[num10 - 1];
                        Vector3 vector13 = vectorArray3[num10 + this.lines.numInterpoles];
                        float num11 = ((Vector3.Distance(vector12, vector13) / ((float) (this.lines.numInterpoles + 1))) / Vector3.Distance(vector12, vector13)) * 3.141593f;
                        for (int num12 = 0; num12 < this.lines.numInterpoles; num12++)
                        {
                            Vector3 vector14;
                            vector14.x = vector12.x + (vector9.x * (1 + num12));
                            vector14.y = vector12.y + (((Mathf.Sin(num11 - 1.570796f) / 2f) + 0.5f) * (vector13.y - vector12.y));
                            vector14.z = vector12.z + (((Mathf.Sin(num11 - 1.570796f) / 2f) + 0.5f) * (vector13.z - vector12.z));
                            renderer2.SetPosition(num10 + num12, vector14);
                            num11 += num11;
                        }
                        num10 += this.lines.numInterpoles;
                    }
                }
            }
            localPosition += this.deltaV2 * (this.lines.numInterpoles + 1);
            i += this.lines.numInterpoles;
        }
        this.prefabs.lightning.SetPosition(0, this.prefabs.source.localPosition);
        this.prefabs.lightning.SetPosition(this.numVertices - 1, this.prefabs.target.localPosition);
        for (int j = 0; j < this.numVertices; j++)
        {
            if ((j % (this.lines.numInterpoles + 1)) != 0)
            {
                Vector3 vector15 = vectorArray[j - 1];
                Vector3 vector16 = vectorArray[j + this.lines.numInterpoles];
                float num14 = ((Vector3.Distance(vector15, vector16) / ((float) (this.lines.numInterpoles + 1))) / Vector3.Distance(vector15, vector16)) * 3.141593f;
                for (int num15 = 0; num15 < this.lines.numInterpoles; num15++)
                {
                    Vector3 vector17;
                    vector17.x = vector15.x + (this.deltaV2.x * (1 + num15));
                    vector17.y = vector15.y + (((Mathf.Sin(num14 - 1.570796f) / 2f) + 0.5f) * (vector16.y - vector15.y));
                    vector17.z = vector15.z + (((Mathf.Sin(num14 - 1.570796f) / 2f) + 0.5f) * (vector16.z - vector15.z));
                    this.prefabs.lightning.SetPosition(j + num15, vector17);
                    num14 += num14;
                }
                j += this.lines.numInterpoles;
            }
        }
    }

    private void RayCast()
    {
        foreach (RaycastHit hit in Physics.RaycastAll(this.prefabs.source.position, this.prefabs.target.position - this.prefabs.source.position, Vector3.Distance(this.prefabs.source.position, this.prefabs.target.position)))
        {
            UnityEngine.Object.Instantiate(this.prefabs.sparks, hit.point, Quaternion.identity);
        }
        if (this.branches.Count > 0)
        {
            Hashtable hashtable = (Hashtable) this.branches.Clone();
            IEnumerator enumerator = hashtable.Keys.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    int current = (int) enumerator.Current;
                    LineRenderer renderer = (LineRenderer) this.branches[current];
                    foreach (RaycastHit hit2 in Physics.RaycastAll(renderer.transform.Find("start").position, renderer.transform.Find("stop").position - renderer.transform.Find("start").position, Vector3.Distance(renderer.transform.Find("start").position, renderer.transform.Find("stop").position)))
                    {
                        UnityEngine.Object.Instantiate(this.prefabs.sparks, hit2.point, Quaternion.identity);
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                }
                disposable.Dispose();
            }
        }
    }

    private void Start()
    {
        this.srcTrgDist = 0f;
        this.srcDstDist = 0f;
        this.numVertices = 0;
        this.deltaV1 = this.prefabs.destination.position - this.prefabs.source.position;
        this.lastUpdate = 0f;
        this.branches = new Hashtable();
    }

    private void Update()
    {
        this.srcTrgDist = Vector3.Distance(this.prefabs.source.position, this.prefabs.target.position);
        this.srcDstDist = Vector3.Distance(this.prefabs.source.position, this.prefabs.destination.position);
        if (this.branches.Count > 0)
        {
            Hashtable hashtable = (Hashtable) this.branches.Clone();
            IEnumerator enumerator = hashtable.Keys.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    int current = (int) enumerator.Current;
                    LineRenderer renderer = (LineRenderer) this.branches[current];
                    if ((renderer.GetComponent<BranchScript>().timeSpawned + this.timers.branchLife) < UnityEngine.Time.time)
                    {
                        this.branches.Remove(current);
                        UnityEngine.Object.Destroy(renderer.gameObject);
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                }
                disposable.Dispose();
            }
        }
        if (this.prefabs.target.localPosition != this.prefabs.destination.localPosition)
        {
            if (((Vector3.Distance(Vector3.zero, this.deltaV1) * UnityEngine.Time.deltaTime) * (1f / this.timers.timeToPowerUp)) > Vector3.Distance(this.prefabs.target.position, this.prefabs.destination.position))
            {
                this.prefabs.target.position = this.prefabs.destination.position;
            }
            else
            {
                this.prefabs.target.Translate((Vector3) ((this.deltaV1 * UnityEngine.Time.deltaTime) * (1f / this.timers.timeToPowerUp)));
            }
        }
        if ((UnityEngine.Time.time - this.lastUpdate) >= this.timers.timeToUpdate)
        {
            this.lastUpdate = UnityEngine.Time.time;
            this.AnimateArc();
            this.DrawArc();
            this.RayCast();
        }
    }

    [Serializable]
    public class Dynamics
    {
        public float chanceToArc = 0.2f;
    }

    [Serializable]
    public class LineSettings
    {
        public float keyVertexDist = 3f;
        public float keyVertexRange = 4f;
        public float maxBranchLength = 16f;
        public float minBranchLength = 11f;
        public int numInterpoles = 5;
    }

    [Serializable]
    public class Prefabs
    {
        public LineRenderer branch;
        public Transform destination;
        public LineRenderer lightning;
        public Transform source;
        public Transform sparks;
        public Transform target;
    }

    [Serializable]
    public class TextureSettings
    {
        public float animateSpeed;
        public float offsetY;
        public float scaleX;
        public float scaleY;
    }

    [Serializable]
    public class Timers
    {
        public float branchLife = 0.1f;
        public float timeToPowerUp = 0.5f;
        public float timeToUpdate = 0.05f;
    }
}

