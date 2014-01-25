using System;
using System.Text;

public class Compute32
{
    public const uint COMPUTE_32_OFFSET = 0x811c9dc5;
    public const uint FNV_32_PRIME = 0x1000193;

    public static uint Hash(string str)
    {
        uint num = 0x811c9dc5;
        foreach (byte num3 in Encoding.ASCII.GetBytes(str))
        {
            num ^= num3;
            num *= 0x1000193;
        }
        return num;
    }
}

