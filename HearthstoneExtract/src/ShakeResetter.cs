using System;
using System.Collections.Generic;
using UnityEngine;

public class ShakeResetter
{
    private int m_nextId = 1;
    private Dictionary<GameObject, Vector3> m_shakedObjects = new Dictionary<GameObject, Vector3>();
    private static ShakeResetter s_instance;

    public GameObject CreateShaker(GameObject shakedObject)
    {
        GameObject obj2 = new GameObject();
        int nextId = this.GetNextId();
        obj2.name = string.Format("Shaker {0}", nextId);
        obj2.AddComponent<Shaker>();
        Vector3 vector = this.RegisterShakedObject(shakedObject);
        obj2.transform.localScale = Vector3.one;
        obj2.transform.rotation = Quaternion.identity;
        obj2.transform.position = vector;
        obj2.transform.parent = shakedObject.transform.parent;
        shakedObject.transform.parent = obj2.transform;
        return obj2;
    }

    public void DestroyShaker(GameObject shaker)
    {
        Transform parent = shaker.transform;
        Transform transform2 = SceneUtils.FindFirstChild(parent);
        if (transform2 != null)
        {
            Transform transform3 = parent.parent;
            transform2.parent = transform3;
            parent.parent = null;
            if ((transform2.GetComponent<Shaker>() == null) && ((transform3 == null) || (transform3.GetComponent<Shaker>() == null)))
            {
                this.UnregisterShakedObject(transform2.gameObject);
            }
        }
        UnityEngine.Object.Destroy(shaker);
    }

    public static ShakeResetter Get()
    {
        if (s_instance == null)
        {
            s_instance = new ShakeResetter();
            s_instance.Initialize();
        }
        return s_instance;
    }

    public Vector3 GetInitialPosition(GameObject shakedObject)
    {
        Vector3 vector;
        this.m_shakedObjects.TryGetValue(shakedObject, out vector);
        return vector;
    }

    private int GetNextId()
    {
        int nextId = this.m_nextId;
        this.m_nextId = (this.m_nextId + 1) & 0x7fffffff;
        return nextId;
    }

    private void Initialize()
    {
        if (SceneMgr.Get() != null)
        {
            SceneMgr.Get().RegisterSceneLoadedEvent(new SceneMgr.SceneLoadedCallback(this.OnSceneLoaded));
        }
    }

    private void OnSceneLoaded(SceneMgr.Mode mode, Scene scene, object userData)
    {
        List<GameObject> list = new List<GameObject>();
        foreach (GameObject obj2 in this.m_shakedObjects.Keys)
        {
            if (obj2 == null)
            {
                list.Add(obj2);
            }
        }
        foreach (GameObject obj3 in list)
        {
            this.m_shakedObjects.Remove(obj3);
        }
    }

    private Vector3 RegisterShakedObject(GameObject shakedObject)
    {
        Vector3 position;
        if (!this.m_shakedObjects.TryGetValue(shakedObject, out position))
        {
            position = shakedObject.transform.position;
            this.m_shakedObjects[shakedObject] = position;
        }
        return position;
    }

    private bool UnregisterShakedObject(GameObject shakedObject)
    {
        shakedObject.transform.position = this.m_shakedObjects[shakedObject];
        return this.m_shakedObjects.Remove(shakedObject);
    }
}

