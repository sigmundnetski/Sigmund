using System;
using UnityEngine;

public class DragTesting : MonoBehaviour
{
    public TestDragableObj dragableObj;
    private Vector3 m_lastPos = Vector3.zero;

    private void Start()
    {
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 zero = Vector3.zero;
        if (UniversalInputManager.Get().GetInputHitInfo(GameLayer.DragPlane.LayerBit(), out hit))
        {
            zero = hit.point;
        }
        if (Mathf.Sign(zero.x) != Mathf.Sign(this.m_lastPos.x))
        {
            this.dragableObj.SwapActiveObj();
        }
        this.m_lastPos = zero;
        this.dragableObj.transform.position = zero;
    }
}

