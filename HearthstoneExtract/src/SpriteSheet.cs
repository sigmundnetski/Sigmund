using System;
using UnityEngine;

public class SpriteSheet : MonoBehaviour
{
    public int _fps = 10;
    private int _lastIndex = -1;
    private UnityEngine.Renderer _myRenderer;
    private Vector2 _size;
    public int _uvTieX = 1;
    public int _uvTieY = 1;

    private void Start()
    {
        this._size = new Vector2(1f / ((float) this._uvTieX), 1f / ((float) this._uvTieY));
        this._myRenderer = base.renderer;
        if (this._myRenderer == null)
        {
            base.enabled = false;
        }
    }

    private void Update()
    {
        int num = ((int) (UnityEngine.Time.timeSinceLevelLoad * this._fps)) % (this._uvTieX * this._uvTieY);
        if (num != this._lastIndex)
        {
            int num2 = num % this._uvTieX;
            int num3 = num / this._uvTieY;
            Vector2 offset = new Vector2(num2 * this._size.x, (1f - this._size.y) - (num3 * this._size.y));
            this._myRenderer.material.SetTextureOffset("_MainTex", offset);
            this._myRenderer.material.SetTextureScale("_MainTex", this._size);
            this._lastIndex = num;
        }
    }
}

