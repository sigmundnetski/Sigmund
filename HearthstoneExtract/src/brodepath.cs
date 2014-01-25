using System;
using UnityEngine;

public class brodepath : MonoBehaviour
{
    public Vector3 startPoint;
    public float timing = 10f;

    private void GoGoGo()
    {
        object[] args = new object[] { "path", iTweenPath.GetPath("driftPath1"), "time", this.timing, "easetype", iTween.EaseType.linear, "oncomplete", "GoGoGo" };
        iTween.MoveTo(base.gameObject, iTween.Hash(args));
    }

    private void RotateGo()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, 0f, -10f), "time", this.timing / 2f, "easetype", iTween.EaseType.easeInOutSine, "oncomplete", "RotateNext" };
        iTween.RotateTo(base.gameObject, iTween.Hash(args));
    }

    private void RotateNext()
    {
        object[] args = new object[] { "rotation", new Vector3(0f, 0f, 10f), "time", this.timing / 2f, "easetype", iTween.EaseType.easeInOutSine, "oncomplete", "RotateGo" };
        iTween.RotateTo(base.gameObject, iTween.Hash(args));
    }

    private void Start()
    {
        base.transform.position = iTweenPath.GetPath("driftPath1")[0];
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            this.GoGoGo();
            this.RotateGo();
        }
    }
}

