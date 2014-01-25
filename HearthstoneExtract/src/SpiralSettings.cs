using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct SpiralSettings
{
    public int numArms;
    public int numPPA;
    public float partSep;
    public float turnDist;
    public float vertDist;
    public float originOffset;
    public float turnSpeed;
    public float fade;
    public float size;
}

