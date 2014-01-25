using System;
using UnityEngine;

[Serializable]
public class SpellMissileInfo
{
    public float m_CenterOffsetPercent = 50f;
    public float m_CenterPointHeightMax;
    public float m_CenterPointHeightMin;
    public bool m_DebugForceMax;
    public float m_DistanceScaleFactor = 8f;
    public bool m_Enabled = true;
    public Vector3 m_JointUpVector = Vector3.up;
    public float m_LeftMax;
    public float m_LeftMin;
    public bool m_OrientToPath;
    public float m_PathDurationMax = 1f;
    public float m_PathDurationMin = 0.5f;
    public iTween.EaseType m_PathEaseType = iTween.EaseType.linear;
    public Spell m_Prefab;
    public float m_RightMax;
    public float m_RightMin;
    public bool m_SpawnInSequence;
    public float m_TargetHeightOffset = 0.5f;
    public string m_TargetJoint = "TargetJoint";
    public bool m_UseSuperSpellLocation = true;
}

