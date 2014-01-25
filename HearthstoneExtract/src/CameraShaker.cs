using System;
using System.Collections;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public Vector3 m_Amount;
    public float m_Time;

    private void OnComplete(GameObject shaker)
    {
        ShakeResetter.Get().DestroyShaker(shaker);
    }

    public void StartShake()
    {
        GameObject target = ShakeResetter.Get().CreateShaker(Camera.main.gameObject);
        object[] args = new object[] { "amount", this.m_Amount, "time", this.m_Time, "oncomplete", "OnComplete", "oncompletetarget", base.gameObject, "oncompleteparams", target };
        Hashtable hashtable = iTween.Hash(args);
        iTween.ShakePosition(target, hashtable);
    }
}

