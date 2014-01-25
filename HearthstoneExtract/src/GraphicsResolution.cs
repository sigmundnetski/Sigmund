using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GraphicsResolution : IComparable
{
    public static readonly List<GraphicsResolution> resolutions_ = new List<GraphicsResolution>();

    private GraphicsResolution()
    {
    }

    private GraphicsResolution(int width, int height)
    {
        this.x = width;
        this.y = height;
        this.aspectRatio = ((float) this.x) / ((float) this.y);
    }

    private static bool add(int width, int height)
    {
        GraphicsResolution item = new GraphicsResolution(width, height);
        if (resolutions_.BinarySearch(item) >= 0)
        {
            return false;
        }
        resolutions_.Add(item);
        resolutions_.Sort();
        return true;
    }

    public int CompareTo(object obj)
    {
        GraphicsResolution resolution = obj as GraphicsResolution;
        if (resolution == null)
        {
            return 1;
        }
        if (this.x < resolution.x)
        {
            return -1;
        }
        if (this.x > resolution.x)
        {
            return 1;
        }
        if (this.y < resolution.y)
        {
            return -1;
        }
        if (this.y > resolution.y)
        {
            return 1;
        }
        return 0;
    }

    public static GraphicsResolution create(Resolution res)
    {
        return new GraphicsResolution(res.width, res.height);
    }

    public static GraphicsResolution create(int width, int height)
    {
        return new GraphicsResolution(width, height);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        GraphicsResolution resolution = obj as GraphicsResolution;
        if (resolution == null)
        {
            return false;
        }
        return ((this.x == resolution.x) && (this.y == resolution.y));
    }

    public override int GetHashCode()
    {
        int num = 0x17;
        num = (num * 0x11) + this.x.GetHashCode();
        return ((num * 0x11) + this.y.GetHashCode());
    }

    public float aspectRatio { get; private set; }

    public static GraphicsResolution current
    {
        get
        {
            return create(Screen.currentResolution);
        }
    }

    public static List<GraphicsResolution> list
    {
        get
        {
            if (resolutions_.Count == 0)
            {
                List<GraphicsResolution> list = resolutions_;
                lock (list)
                {
                    foreach (Resolution resolution in Screen.resolutions)
                    {
                        add(resolution.width, resolution.height);
                    }
                }
            }
            return resolutions_;
        }
    }

    public int x { get; private set; }

    public int y { get; private set; }
}

