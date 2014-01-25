using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Pixelplacement/iTweenPath")]
public class iTweenPath : MonoBehaviour
{
    public bool initialized;
    public string initialName = string.Empty;
    public List<Vector3> nodes = new List<Vector3> { Vector3.zero, Vector3.zero };
    public Color pathColor = Color.cyan;
    public string pathName = string.Empty;
    public static Dictionary<string, iTweenPath> paths = new Dictionary<string, iTweenPath>();
    public bool pathVisible = true;

    public static string FixupPathName(string name)
    {
        return name.ToLower();
    }

    public static Vector3[] GetPath(string requestedName)
    {
        requestedName = FixupPathName(requestedName);
        if (paths.ContainsKey(requestedName))
        {
            return paths[requestedName].nodes.ToArray();
        }
        Debug.Log("No path with that name (" + requestedName + ") exists! Are you sure you wrote it correctly?");
        return null;
    }

    public static Vector3[] GetPathReversed(string requestedName)
    {
        requestedName = FixupPathName(requestedName);
        if (paths.ContainsKey(requestedName))
        {
            List<Vector3> range = paths[requestedName].nodes.GetRange(0, paths[requestedName].nodes.Count);
            range.Reverse();
            return range.ToArray();
        }
        Debug.Log("No path with that name (" + requestedName + ") exists! Are you sure you wrote it correctly?");
        return null;
    }

    private void OnDisable()
    {
        paths.Remove(FixupPathName(this.pathName));
    }

    private void OnDrawGizmosSelected()
    {
        if (this.pathVisible && (this.nodes.Count > 0))
        {
            iTween.DrawPath(this.nodes.ToArray(), this.pathColor);
        }
    }

    private void OnEnable()
    {
        string key = FixupPathName(this.pathName);
        if (!paths.ContainsKey(key))
        {
            paths.Add(key, this);
        }
    }
}

