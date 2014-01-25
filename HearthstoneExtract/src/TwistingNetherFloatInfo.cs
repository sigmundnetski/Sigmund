using System;
using UnityEngine;

[Serializable]
public class TwistingNetherFloatInfo
{
    public float m_DurationMax = 2f;
    public float m_DurationMin = 1.5f;
    public Vector3 m_OffsetMax = new Vector3(1.5f, 1.5f, 1.5f);
    public Vector3 m_OffsetMin = new Vector3(-1.5f, -1.5f, -1.5f);
    public Vector2 m_RotationXZMax = new Vector2(10f, 10f);
    public Vector2 m_RotationXZMin = new Vector2(-10f, -10f);
}

