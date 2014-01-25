using System;
using UnityEngine;

[Serializable]
public class SpellPath
{
    public Vector3 m_FirstNodeOffset;
    public Vector3 m_LastNodeOffset;
    public string m_PathName;
    public SpellPathType m_Type;
}

