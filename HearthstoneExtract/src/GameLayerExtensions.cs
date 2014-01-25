using System;
using System.Runtime.CompilerServices;

public static class GameLayerExtensions
{
    public static int LayerBit(this GameLayer gameLayer)
    {
        return (((int) 1) << gameLayer);
    }
}

