using UnityEngine;

public class PegButtonText : MonoBehaviour
{
    public Color downColor;
    public Vector2 downOffset;
    public Color overColor;
    public Vector2 overOffset;
    public Color upColor;

    public Color GetDownColor()
    {
        return this.downColor;
    }
}

