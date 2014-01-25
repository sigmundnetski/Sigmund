using System;
using UnityEngine;

public class MeshAnimation : MonoBehaviour
{
    private float _accumulator;
    private int _index;
    private MeshFilter _meshFilter;
    private bool _playing;
    public float FrameDuration;
    public bool Loop;
    public Mesh[] Meshes;

    public void Play()
    {
        this._playing = true;
    }

    public void Reset()
    {
        this._index = 0;
        this._accumulator = 0f;
        this._meshFilter.mesh = this.Meshes[this._index];
    }

    public void Start()
    {
        this._meshFilter = base.GetComponent<MeshFilter>();
        this._index = 0;
    }

    public void Stop()
    {
        this._playing = false;
    }

    public void Update()
    {
        if (this._playing)
        {
            this._accumulator += UnityEngine.Time.deltaTime;
            if (this._accumulator >= this.FrameDuration)
            {
                this._accumulator -= this.FrameDuration;
                this._index = (this._index + 1) % this.Meshes.Length;
                if ((this._index == 0) && !this.Loop)
                {
                    this.Stop();
                }
                else
                {
                    this._meshFilter.mesh = this.Meshes[this._index];
                }
            }
        }
    }
}

