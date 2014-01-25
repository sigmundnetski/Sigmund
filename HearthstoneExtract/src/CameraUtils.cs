using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CameraUtils
{
    public static List<GameObject> CreateAllInputBlockers(Camera camera)
    {
        TransformProps source = new TransformProps {
            scale = Vector3.one,
            rotation = Quaternion.Euler(90f, 0f, 0f),
            position = new Vector3(0f, 0f, camera.nearClipPlane + 1f)
        };
        Vector3 vector = TransformUtil.Divide(GetFarClipBounds(camera).size, TransformUtil.ComputeWorldScale(camera.transform));
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < 0x20; i++)
        {
            int num2 = ((int) 1) << i;
            if ((camera.cullingMask & num2) != 0)
            {
                GameObject item = new GameObject {
                    layer = num2
                };
                item.transform.parent = camera.transform;
                TransformUtil.CopyLocal(item.transform, source);
                item.AddComponent<BoxCollider>().size = vector;
                list.Add(item);
            }
        }
        return list;
    }

    public static Plane CreateBottomPlane(Camera camera)
    {
        Vector3 inPoint = camera.ViewportToWorldPoint(new Vector3(0f, 0f, camera.nearClipPlane));
        Vector3 vector2 = camera.ViewportToWorldPoint(new Vector3(1f, 0f, camera.nearClipPlane));
        Vector3 inNormal = Vector3.Cross(camera.ViewportToWorldPoint(new Vector3(0f, 0f, camera.farClipPlane)) - inPoint, vector2 - inPoint);
        inNormal.Normalize();
        return new Plane(inNormal, inPoint);
    }

    public static Rect CreateGUIScreenSpaceRect(Camera camera, Component topLeft, Component bottomRight)
    {
        return CreateGUIScreenSpaceRect(camera, topLeft.transform.position, bottomRight.transform.position);
    }

    public static Rect CreateGUIScreenSpaceRect(Camera camera, Vector3 worldTopLeft, Vector3 worldBottomRight)
    {
        Vector3 vector = camera.WorldToScreenPoint(worldTopLeft);
        Vector3 vector2 = camera.WorldToScreenPoint(worldBottomRight);
        return new Rect(vector.x, vector2.y, vector2.x - vector.x, vector.y - vector2.y);
    }

    public static Rect CreateGUIViewportRect(Camera camera, Component topLeftComponent, Component bottomRightComponent)
    {
        return CreateGUIViewportRect(camera, topLeftComponent.transform.position, bottomRightComponent.transform.position);
    }

    public static Rect CreateGUIViewportRect(Camera camera, Vector3 worldTopLeft, Vector3 worldBottomRight)
    {
        Vector3 vector = camera.WorldToViewportPoint(worldTopLeft);
        Vector3 vector2 = camera.WorldToViewportPoint(worldBottomRight);
        return new Rect(vector.x, 1f - vector.y, vector2.x - vector.x, vector.y - vector2.y);
    }

    public static GameObject CreateInputBlocker(Camera camera)
    {
        return CreateInputBlocker(camera, (GameLayer) camera.gameObject.layer);
    }

    public static GameObject CreateInputBlocker(Camera camera, GameLayer layer)
    {
        GameObject obj2 = new GameObject {
            layer = (int) layer
        };
        obj2.transform.parent = camera.transform;
        obj2.transform.localScale = Vector3.one;
        obj2.transform.rotation = Quaternion.Inverse(camera.transform.rotation);
        obj2.transform.localPosition = new Vector3(0f, 0f, camera.nearClipPlane + 1f);
        obj2.AddComponent<BoxCollider>().size = TransformUtil.Divide(GetFarClipBounds(camera).size, TransformUtil.ComputeWorldScale(camera.transform));
        return obj2;
    }

    public static LayerMask CreateLayerMask(List<Camera> cameras)
    {
        LayerMask mask = 0;
        foreach (Camera camera in cameras)
        {
            mask |= camera.cullingMask;
        }
        return mask;
    }

    public static Plane CreateTopPlane(Camera camera)
    {
        Vector3 inPoint = camera.ViewportToWorldPoint(new Vector3(0f, 1f, camera.nearClipPlane));
        Vector3 vector2 = camera.ViewportToWorldPoint(new Vector3(1f, 1f, camera.nearClipPlane));
        Vector3 inNormal = Vector3.Cross(camera.ViewportToWorldPoint(new Vector3(0f, 1f, camera.farClipPlane)) - inPoint, vector2 - inPoint);
        inNormal.Normalize();
        return new Plane(inNormal, inPoint);
    }

    public static void FindAllByLayer(GameLayer layer, List<Camera> cameras)
    {
        FindAllByLayerMask(layer.LayerBit(), cameras);
    }

    public static void FindAllByLayer(int layer, List<Camera> cameras)
    {
        FindAllByLayerMask(((int) 1) << layer, cameras);
    }

    public static void FindAllByLayerMask(LayerMask mask, List<Camera> cameras)
    {
        foreach (Camera camera in Camera.allCameras)
        {
            if ((camera.cullingMask & mask) != 0)
            {
                cameras.Add(camera);
            }
        }
    }

    public static Camera FindFirstByLayer(GameLayer layer)
    {
        return FindFirstByLayerMask(layer.LayerBit());
    }

    public static Camera FindFirstByLayer(int layer)
    {
        return FindFirstByLayerMask(((int) 1) << layer);
    }

    public static Camera FindFirstByLayerMask(LayerMask mask)
    {
        foreach (Camera camera in Camera.allCameras)
        {
            if ((camera.cullingMask & mask) != 0)
            {
                return camera;
            }
        }
        return null;
    }

    public static Camera FindFullScreenEffectsCamera(bool activeOnly)
    {
        foreach (Camera camera in Camera.allCameras)
        {
            FullScreenEffects component = camera.GetComponent<FullScreenEffects>();
            if ((component != null) && (!activeOnly || component.isActive()))
            {
                return camera;
            }
        }
        return null;
    }

    public static Bounds GetFarClipBounds(Camera camera)
    {
        Vector3 center = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, camera.farClipPlane));
        Vector3 vector2 = camera.ViewportToWorldPoint(new Vector3(0f, 0f, camera.farClipPlane));
        Vector3 vector3 = camera.ViewportToWorldPoint(new Vector3(1f, 1f, camera.farClipPlane));
        return new Bounds(center, new Vector3(vector3.x - vector2.x, vector3.y - vector2.y, vector3.z - vector2.z));
    }

    public static Bounds GetNearClipBounds(Camera camera)
    {
        Vector3 center = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, camera.nearClipPlane));
        Vector3 vector2 = camera.ViewportToWorldPoint(new Vector3(0f, 0f, camera.nearClipPlane));
        Vector3 vector3 = camera.ViewportToWorldPoint(new Vector3(1f, 1f, camera.nearClipPlane));
        return new Bounds(center, new Vector3(vector3.x - vector2.x, vector3.y - vector2.y, vector3.z - vector2.z));
    }

    public static bool Raycast(Camera camera, Vector3 screenPoint, out RaycastHit hitInfo)
    {
        hitInfo = new RaycastHit();
        if (!camera.pixelRect.Contains(screenPoint))
        {
            return false;
        }
        return Physics.Raycast(camera.ScreenPointToRay(screenPoint), out hitInfo, camera.farClipPlane, camera.cullingMask);
    }

    public static bool Raycast(Camera camera, Vector3 screenPoint, LayerMask layerMask, out RaycastHit hitInfo)
    {
        hitInfo = new RaycastHit();
        if (!camera.pixelRect.Contains(screenPoint))
        {
            return false;
        }
        return Physics.Raycast(camera.ScreenPointToRay(screenPoint), out hitInfo, camera.farClipPlane, (int) layerMask);
    }

    public static float ScreenToWorldDist(Camera camera, float dist)
    {
        Vector3 vector = camera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        return (camera.ScreenToWorldPoint(new Vector3(dist, 0f, 0f)).x - vector.x);
    }
}

