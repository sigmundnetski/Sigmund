using System;
using UnityEngine;

public class TransformUtil
{
    public static Bounds ComputeSetPointBounds(Component c)
    {
        return ComputeSetPointBounds(c.gameObject, false);
    }

    public static Bounds ComputeSetPointBounds(GameObject go)
    {
        return ComputeSetPointBounds(go, false);
    }

    public static Bounds ComputeSetPointBounds(Component c, bool includeInactive)
    {
        return ComputeSetPointBounds(c.gameObject, includeInactive);
    }

    public static Bounds ComputeSetPointBounds(GameObject go, bool includeInactive)
    {
        UberText component = go.GetComponent<UberText>();
        if (component != null)
        {
            return component.GetTextWorldSpaceBounds();
        }
        UnityEngine.Renderer renderer = go.renderer;
        if (renderer != null)
        {
            return renderer.bounds;
        }
        Collider collider = go.collider;
        if (collider != null)
        {
            return collider.bounds;
        }
        return GetBoundsOfChildren(go, includeInactive);
    }

    public static Vector2 ComputeUnitAnchor(Bounds bounds, Vector2 worldPoint)
    {
        return new Vector2 { x = (worldPoint.x - bounds.min.x) / bounds.size.x, y = (worldPoint.y - bounds.min.y) / bounds.size.y };
    }

    public static Vector3 ComputeWorldPoint(Bounds bounds, Vector3 selfUnitAnchor)
    {
        return new Vector3 { x = Mathf.Lerp(bounds.min.x, bounds.max.x, selfUnitAnchor.x), y = Mathf.Lerp(bounds.min.y, bounds.max.y, selfUnitAnchor.y), z = Mathf.Lerp(bounds.min.z, bounds.max.z, selfUnitAnchor.z) };
    }

    public static Vector3 ComputeWorldScale(Component c)
    {
        return ComputeWorldScale(c.gameObject);
    }

    public static Vector3 ComputeWorldScale(GameObject go)
    {
        Vector3 localScale = go.transform.localScale;
        if (go.transform.parent != null)
        {
            for (Transform transform = go.transform.parent; transform != null; transform = transform.parent)
            {
                localScale.Scale(transform.localScale);
            }
        }
        return localScale;
    }

    public static void CopyLocal(TransformProps destination, Component source)
    {
        CopyLocal(destination, source.gameObject);
    }

    public static void CopyLocal(TransformProps destination, GameObject source)
    {
        destination.scale = source.transform.localScale;
        destination.rotation = source.transform.localRotation;
        destination.position = source.transform.localPosition;
    }

    public static void CopyLocal(Component destination, TransformProps source)
    {
        CopyLocal(destination.gameObject, source);
    }

    public static void CopyLocal(Component destination, Component source)
    {
        CopyLocal(destination.gameObject, source.gameObject);
    }

    public static void CopyLocal(Component destination, GameObject source)
    {
        CopyLocal(destination.gameObject, source);
    }

    public static void CopyLocal(GameObject destination, TransformProps source)
    {
        destination.transform.localScale = source.scale;
        destination.transform.localRotation = source.rotation;
        destination.transform.localPosition = source.position;
    }

    public static void CopyLocal(GameObject destination, Component source)
    {
        CopyLocal(destination, source.gameObject);
    }

    public static void CopyLocal(GameObject destination, GameObject source)
    {
        destination.transform.localScale = source.transform.localScale;
        destination.transform.localRotation = source.transform.localRotation;
        destination.transform.localPosition = source.transform.localPosition;
    }

    public static void CopyWorld(TransformProps destination, Component source)
    {
        CopyWorld(destination, source.gameObject);
    }

    public static void CopyWorld(TransformProps destination, GameObject source)
    {
        destination.scale = ComputeWorldScale(source);
        destination.rotation = source.transform.rotation;
        destination.position = source.transform.position;
    }

    public static void CopyWorld(Component destination, TransformProps source)
    {
        CopyWorld(destination.gameObject, source);
    }

    public static void CopyWorld(Component destination, Component source)
    {
        CopyWorld(destination.gameObject, source);
    }

    public static void CopyWorld(Component destination, GameObject source)
    {
        CopyWorld(destination.gameObject, source);
    }

    public static void CopyWorld(GameObject destination, TransformProps source)
    {
        SetWorldScale(destination, source.scale);
        destination.transform.rotation = source.rotation;
        destination.transform.position = source.position;
    }

    public static void CopyWorld(GameObject destination, Component source)
    {
        CopyWorld(destination, source.gameObject);
    }

    public static void CopyWorld(GameObject destination, GameObject source)
    {
        CopyWorldScale(destination, source);
        destination.transform.rotation = source.transform.rotation;
        destination.transform.position = source.transform.position;
    }

    public static void CopyWorldScale(Component destination, Component source)
    {
        CopyWorldScale(destination.gameObject, source.gameObject);
    }

    public static void CopyWorldScale(Component destination, GameObject source)
    {
        CopyWorldScale(destination.gameObject, source);
    }

    public static void CopyWorldScale(GameObject destination, Component source)
    {
        CopyWorldScale(destination, source.gameObject);
    }

    public static void CopyWorldScale(GameObject destination, GameObject source)
    {
        Vector3 scale = ComputeWorldScale(source);
        SetWorldScale(destination, scale);
    }

    public static Vector3 Divide(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
    }

    public static Bounds GetBoundsOfChildren(Component c)
    {
        return GetBoundsOfChildren(c.gameObject, false);
    }

    public static Bounds GetBoundsOfChildren(GameObject go)
    {
        return GetBoundsOfChildren(go, false);
    }

    public static Bounds GetBoundsOfChildren(Component c, bool includeInactive)
    {
        return GetBoundsOfChildren(c.gameObject, includeInactive);
    }

    public static Bounds GetBoundsOfChildren(GameObject go, bool includeInactive)
    {
        UnityEngine.Renderer[] componentsInChildren = go.GetComponentsInChildren<UnityEngine.Renderer>(includeInactive);
        if (componentsInChildren.Length == 0)
        {
            return new Bounds(go.transform.position, Vector3.zero);
        }
        Bounds bounds = componentsInChildren[0].bounds;
        for (int i = 1; i < componentsInChildren.Length; i++)
        {
            UnityEngine.Renderer renderer = componentsInChildren[i];
            Bounds bounds2 = renderer.bounds;
            Vector3 max = Vector3.Max(bounds2.max, bounds.max);
            Vector3 min = Vector3.Min(bounds2.min, bounds.min);
            bounds.SetMinMax(min, max);
        }
        return bounds;
    }

    public static Vector3 GetUnitAnchor(Anchor anchor)
    {
        Vector3 vector = new Vector3();
        switch (anchor)
        {
            case Anchor.TOP_LEFT:
                vector.x = 0f;
                vector.y = 1f;
                vector.z = 0f;
                return vector;

            case Anchor.TOP:
                vector.x = 0.5f;
                vector.y = 1f;
                vector.z = 0f;
                return vector;

            case Anchor.TOP_RIGHT:
                vector.x = 1f;
                vector.y = 1f;
                vector.z = 0f;
                return vector;

            case Anchor.LEFT:
                vector.x = 0f;
                vector.y = 0.5f;
                vector.z = 0f;
                return vector;

            case Anchor.CENTER:
                vector.x = 0.5f;
                vector.y = 0.5f;
                vector.z = 0f;
                return vector;

            case Anchor.RIGHT:
                vector.x = 1f;
                vector.y = 0.5f;
                vector.z = 0f;
                return vector;

            case Anchor.BOTTOM_LEFT:
                vector.x = 0f;
                vector.y = 0f;
                vector.z = 0f;
                return vector;

            case Anchor.BOTTOM:
                vector.x = 0.5f;
                vector.y = 0f;
                vector.z = 0f;
                return vector;

            case Anchor.BOTTOM_RIGHT:
                vector.x = 1f;
                vector.y = 0f;
                vector.z = 0f;
                return vector;

            case Anchor.FRONT:
                vector.x = 0.5f;
                vector.y = 0f;
                vector.z = 1f;
                return vector;

            case Anchor.BACK:
                vector.x = 0.5f;
                vector.y = 0f;
                vector.z = 0f;
                return vector;
        }
        return vector;
    }

    public static void Identity(Component c)
    {
        c.transform.localScale = Vector3.one;
        c.transform.localRotation = Quaternion.identity;
        c.transform.localPosition = Vector3.zero;
    }

    public static void Identity(GameObject go)
    {
        go.transform.localScale = Vector3.one;
        go.transform.localRotation = Quaternion.identity;
        go.transform.localPosition = Vector3.zero;
    }

    public static Vector3 Multiply(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
    }

    public static void OrientTo(Component source, Component target)
    {
        OrientTo(source.transform, target.transform);
    }

    public static void OrientTo(Component source, GameObject target)
    {
        OrientTo(source.transform, target.transform);
    }

    public static void OrientTo(GameObject source, Component target)
    {
        OrientTo(source.transform, target.transform);
    }

    public static void OrientTo(GameObject source, GameObject target)
    {
        OrientTo(source.transform, target.transform);
    }

    public static void OrientTo(Transform source, Transform target)
    {
        OrientTo(source, source.transform.position, target.transform.position);
    }

    public static void OrientTo(Transform source, Vector3 sourcePosition, Vector3 targetPosition)
    {
        Vector3 forward = targetPosition - sourcePosition;
        if (forward.sqrMagnitude > float.Epsilon)
        {
            source.rotation = Quaternion.LookRotation(forward);
        }
    }

    public static Vector3 RandomVector3(Vector3 min, Vector3 max)
    {
        return new Vector3 { x = UnityEngine.Random.Range(min.x, max.x), y = UnityEngine.Random.Range(min.y, max.y), z = UnityEngine.Random.Range(min.z, max.z) };
    }

    public static void SetEulerAngleX(GameObject go, float x)
    {
        Vector3 eulerAngles = go.transform.rotation.eulerAngles;
        eulerAngles = new Vector3(x, eulerAngles.y, eulerAngles.z);
        go.transform.rotation = Quaternion.Euler(eulerAngles);
    }

    public static void SetEulerAngleY(GameObject go, float y)
    {
        Vector3 eulerAngles = go.transform.rotation.eulerAngles;
        eulerAngles = new Vector3(eulerAngles.x, y, eulerAngles.z);
        go.transform.rotation = Quaternion.Euler(eulerAngles);
    }

    public static void SetEulerAngleZ(GameObject go, float z)
    {
        Vector3 eulerAngles = go.transform.rotation.eulerAngles;
        eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, z);
        go.transform.rotation = Quaternion.Euler(eulerAngles);
    }

    public static void SetLocalPosX(Component component, float x)
    {
        Transform transform = component.transform;
        transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
    }

    public static void SetLocalPosX(GameObject go, float x)
    {
        Transform transform = go.transform;
        transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
    }

    public static void SetLocalPosY(Component component, float y)
    {
        Transform transform = component.transform;
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }

    public static void SetLocalPosY(GameObject go, float y)
    {
        Transform transform = go.transform;
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }

    public static void SetLocalPosZ(Component component, float z)
    {
        Transform transform = component.transform;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
    }

    public static void SetLocalPosZ(GameObject go, float z)
    {
        Transform transform = go.transform;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
    }

    public static void SetLocalScaleX(Component component, float x)
    {
        Transform transform = component.transform;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    public static void SetLocalScaleX(GameObject go, float x)
    {
        Transform transform = go.transform;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    public static void SetLocalScaleXY(Component component, Vector2 v)
    {
        Transform transform = component.transform;
        transform.localScale = new Vector3(v.x, v.y, transform.localScale.z);
    }

    public static void SetLocalScaleXY(GameObject go, Vector2 v)
    {
        Transform transform = go.transform;
        transform.localScale = new Vector3(v.x, v.y, transform.localScale.z);
    }

    public static void SetLocalScaleXY(Component component, float x, float y)
    {
        Transform transform = component.transform;
        transform.localScale = new Vector3(x, y, transform.localScale.z);
    }

    public static void SetLocalScaleXY(GameObject go, float x, float y)
    {
        Transform transform = go.transform;
        transform.localScale = new Vector3(x, y, transform.localScale.z);
    }

    public static void SetLocalScaleXZ(Component component, Vector2 v)
    {
        Transform transform = component.transform;
        transform.localScale = new Vector3(v.x, transform.localScale.y, v.y);
    }

    public static void SetLocalScaleXZ(GameObject go, Vector2 v)
    {
        Transform transform = go.transform;
        transform.localScale = new Vector3(v.x, transform.localScale.y, v.y);
    }

    public static void SetLocalScaleXZ(Component component, float x, float z)
    {
        Transform transform = component.transform;
        transform.localScale = new Vector3(x, transform.localScale.y, z);
    }

    public static void SetLocalScaleXZ(GameObject go, float x, float z)
    {
        Transform transform = go.transform;
        transform.localScale = new Vector3(x, transform.localScale.y, z);
    }

    public static void SetLocalScaleY(Component component, float y)
    {
        Transform transform = component.transform;
        transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z);
    }

    public static void SetLocalScaleY(GameObject go, float y)
    {
        Transform transform = go.transform;
        transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z);
    }

    public static void SetLocalScaleYZ(Component component, Vector2 v)
    {
        Transform transform = component.transform;
        transform.localScale = new Vector3(transform.localScale.x, v.x, v.y);
    }

    public static void SetLocalScaleYZ(GameObject go, Vector2 v)
    {
        Transform transform = go.transform;
        transform.localScale = new Vector3(transform.localScale.x, v.x, v.y);
    }

    public static void SetLocalScaleYZ(Component component, float y, float z)
    {
        Transform transform = component.transform;
        transform.localScale = new Vector3(transform.localScale.x, y, z);
    }

    public static void SetLocalScaleYZ(GameObject go, float y, float z)
    {
        Transform transform = go.transform;
        transform.localScale = new Vector3(transform.localScale.x, y, z);
    }

    public static void SetLocalScaleZ(Component component, float z)
    {
        Transform transform = component.transform;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, z);
    }

    public static void SetLocalScaleZ(GameObject go, float z)
    {
        Transform transform = go.transform;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, z);
    }

    public static void SetPoint(Component src, Anchor srcAnchor, Component dst, Anchor dstAnchor)
    {
        SetPoint(src.gameObject, GetUnitAnchor(srcAnchor), dst.gameObject, GetUnitAnchor(dstAnchor), Vector3.zero, false);
    }

    public static void SetPoint(Component src, Anchor srcAnchor, GameObject dst, Anchor dstAnchor)
    {
        SetPoint(src.gameObject, GetUnitAnchor(srcAnchor), dst, GetUnitAnchor(dstAnchor), Vector3.zero, false);
    }

    public static void SetPoint(Component self, Vector3 selfUnitAnchor, Component relative, Vector3 relativeUnitAnchor)
    {
        SetPoint(self.gameObject, selfUnitAnchor, relative.gameObject, relativeUnitAnchor, Vector3.zero, false);
    }

    public static void SetPoint(Component self, Vector3 selfUnitAnchor, GameObject relative, Vector3 relativeUnitAnchor)
    {
        SetPoint(self.gameObject, selfUnitAnchor, relative, relativeUnitAnchor, Vector3.zero, false);
    }

    public static void SetPoint(GameObject src, Anchor srcAnchor, Component dst, Anchor dstAnchor)
    {
        SetPoint(src, GetUnitAnchor(srcAnchor), dst.gameObject, GetUnitAnchor(dstAnchor), Vector3.zero, false);
    }

    public static void SetPoint(GameObject src, Anchor srcAnchor, GameObject dst, Anchor dstAnchor)
    {
        SetPoint(src, GetUnitAnchor(srcAnchor), dst, GetUnitAnchor(dstAnchor), Vector3.zero, false);
    }

    public static void SetPoint(GameObject self, Vector3 selfUnitAnchor, Component relative, Vector3 relativeUnitAnchor)
    {
        SetPoint(self, selfUnitAnchor, relative.gameObject, relativeUnitAnchor, Vector3.zero, false);
    }

    public static void SetPoint(GameObject self, Vector3 selfUnitAnchor, GameObject relative, Vector3 relativeUnitAnchor)
    {
        SetPoint(self, selfUnitAnchor, relative, relativeUnitAnchor, Vector3.zero, false);
    }

    public static void SetPoint(Component src, Anchor srcAnchor, Component dst, Anchor dstAnchor, bool includeInactive)
    {
        SetPoint(src.gameObject, GetUnitAnchor(srcAnchor), dst.gameObject, GetUnitAnchor(dstAnchor), Vector3.zero, includeInactive);
    }

    public static void SetPoint(Component src, Anchor srcAnchor, Component dst, Anchor dstAnchor, Vector3 offset)
    {
        SetPoint(src.gameObject, GetUnitAnchor(srcAnchor), dst.gameObject, GetUnitAnchor(dstAnchor), offset, false);
    }

    public static void SetPoint(Component src, Anchor srcAnchor, GameObject dst, Anchor dstAnchor, bool includeInactive)
    {
        SetPoint(src.gameObject, GetUnitAnchor(srcAnchor), dst, GetUnitAnchor(dstAnchor), Vector3.zero, includeInactive);
    }

    public static void SetPoint(Component src, Anchor srcAnchor, GameObject dst, Anchor dstAnchor, Vector3 offset)
    {
        SetPoint(src.gameObject, GetUnitAnchor(srcAnchor), dst, GetUnitAnchor(dstAnchor), offset, false);
    }

    public static void SetPoint(Component self, Vector3 selfUnitAnchor, Component relative, Vector3 relativeUnitAnchor, Vector3 offset)
    {
        SetPoint(self.gameObject, selfUnitAnchor, relative.gameObject, relativeUnitAnchor, offset, false);
    }

    public static void SetPoint(Component self, Vector3 selfUnitAnchor, GameObject relative, Vector3 relativeUnitAnchor, Vector3 offset)
    {
        SetPoint(self.gameObject, selfUnitAnchor, relative, relativeUnitAnchor, offset, false);
    }

    public static void SetPoint(GameObject src, Anchor srcAnchor, Component dst, Anchor dstAnchor, bool includeInactive)
    {
        SetPoint(src, GetUnitAnchor(srcAnchor), dst.gameObject, GetUnitAnchor(dstAnchor), Vector3.zero, includeInactive);
    }

    public static void SetPoint(GameObject src, Anchor srcAnchor, Component dst, Anchor dstAnchor, Vector3 offset)
    {
        SetPoint(src, GetUnitAnchor(srcAnchor), dst.gameObject, GetUnitAnchor(dstAnchor), offset, false);
    }

    public static void SetPoint(GameObject src, Anchor srcAnchor, GameObject dst, Anchor dstAnchor, bool includeInactive)
    {
        SetPoint(src, GetUnitAnchor(srcAnchor), dst, GetUnitAnchor(dstAnchor), Vector3.zero, includeInactive);
    }

    public static void SetPoint(GameObject src, Anchor srcAnchor, GameObject dst, Anchor dstAnchor, Vector3 offset)
    {
        SetPoint(src, GetUnitAnchor(srcAnchor), dst, GetUnitAnchor(dstAnchor), offset, false);
    }

    public static void SetPoint(GameObject self, Vector3 selfUnitAnchor, Component relative, Vector3 relativeUnitAnchor, Vector3 offset)
    {
        SetPoint(self, selfUnitAnchor, relative.gameObject, relativeUnitAnchor, offset, false);
    }

    public static void SetPoint(GameObject self, Vector3 selfUnitAnchor, GameObject relative, Vector3 relativeUnitAnchor, Vector3 offset)
    {
        SetPoint(self, selfUnitAnchor, relative, relativeUnitAnchor, offset, false);
    }

    public static void SetPoint(Component src, Anchor srcAnchor, Component dst, Anchor dstAnchor, Vector3 offset, bool includeInactive)
    {
        SetPoint(src.gameObject, GetUnitAnchor(srcAnchor), dst.gameObject, GetUnitAnchor(dstAnchor), offset, includeInactive);
    }

    public static void SetPoint(Component src, Anchor srcAnchor, GameObject dst, Anchor dstAnchor, Vector3 offset, bool includeInactive)
    {
        SetPoint(src.gameObject, GetUnitAnchor(srcAnchor), dst, GetUnitAnchor(dstAnchor), offset, includeInactive);
    }

    public static void SetPoint(Component self, Vector3 selfUnitAnchor, Component relative, Vector3 relativeUnitAnchor, Vector3 offset, bool includeInactive)
    {
        SetPoint(self.gameObject, selfUnitAnchor, relative.gameObject, relativeUnitAnchor, offset, includeInactive);
    }

    public static void SetPoint(Component self, Vector3 selfUnitAnchor, GameObject relative, Vector3 relativeUnitAnchor, Vector3 offset, bool includeInactive)
    {
        SetPoint(self.gameObject, selfUnitAnchor, relative, relativeUnitAnchor, offset, includeInactive);
    }

    public static void SetPoint(GameObject src, Anchor srcAnchor, Component dst, Anchor dstAnchor, Vector3 offset, bool includeInactive)
    {
        SetPoint(src, GetUnitAnchor(srcAnchor), dst.gameObject, GetUnitAnchor(dstAnchor), offset, includeInactive);
    }

    public static void SetPoint(GameObject src, Anchor srcAnchor, GameObject dst, Anchor dstAnchor, Vector3 offset, bool includeInactive)
    {
        SetPoint(src, GetUnitAnchor(srcAnchor), dst, GetUnitAnchor(dstAnchor), offset, includeInactive);
    }

    public static void SetPoint(GameObject self, Vector3 selfUnitAnchor, Component relative, Vector3 relativeUnitAnchor, Vector3 offset, bool includeInactive)
    {
        SetPoint(self, selfUnitAnchor, relative.gameObject, relativeUnitAnchor, offset, includeInactive);
    }

    public static void SetPoint(GameObject self, Vector3 selfUnitAnchor, GameObject relative, Vector3 relativeUnitAnchor, Vector3 offset, bool includeInactive)
    {
        Bounds bounds = ComputeSetPointBounds(self, includeInactive);
        Bounds bounds2 = ComputeSetPointBounds(relative, includeInactive);
        Vector3 vector = ComputeWorldPoint(bounds, selfUnitAnchor);
        Vector3 vector2 = ComputeWorldPoint(bounds2, relativeUnitAnchor);
        Vector3 translation = new Vector3((vector2.x - vector.x) + offset.x, (vector2.y - vector.y) + offset.y, (vector2.z - vector.z) + offset.z);
        self.transform.Translate(translation, Space.World);
    }

    public static void SetPosX(Component component, float x)
    {
        Transform transform = component.transform;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public static void SetPosX(GameObject go, float x)
    {
        Transform transform = go.transform;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public static void SetPosY(Component component, float y)
    {
        Transform transform = component.transform;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    public static void SetPosY(GameObject go, float y)
    {
        Transform transform = go.transform;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    public static void SetPosZ(Component component, float z)
    {
        Transform transform = component.transform;
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }

    public static void SetPosZ(GameObject go, float z)
    {
        Transform transform = go.transform;
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }

    public static void SetWorldScale(Component destination, Vector3 scale)
    {
        SetWorldScale(destination.gameObject, scale);
    }

    public static void SetWorldScale(GameObject destination, Vector3 scale)
    {
        if (destination.transform.parent != null)
        {
            for (Transform transform = destination.transform.parent; transform != null; transform = transform.parent)
            {
                scale.Scale(Vector3Reciprocal(transform.localScale));
            }
        }
        destination.transform.localScale = scale;
    }

    public static Vector3 Vector3Reciprocal(Vector3 source)
    {
        Vector3 vector = source;
        if (vector.x != 0f)
        {
            vector.x = 1f / vector.x;
        }
        if (vector.y != 0f)
        {
            vector.y = 1f / vector.y;
        }
        if (vector.z != 0f)
        {
            vector.z = 1f / vector.z;
        }
        return vector;
    }
}

