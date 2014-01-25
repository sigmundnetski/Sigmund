using System;
using UnityEngine;

public class DebugTakeScreenshot : MonoBehaviour
{
    private int numShots;
    public int sizeFactor;

    private void TakeShot()
    {
        int superSize = Mathf.Clamp(this.sizeFactor, 1, 20);
        this.numShots++;
        object[] objArray1 = new object[] { DateTime.Now.Month, ".", DateTime.Now.Day, ".", DateTime.Now.Year, ".", DateTime.Now.Hour, ".", DateTime.Now.Minute };
        string str = string.Concat(objArray1);
        object[] objArray2 = new object[] { "Hearthstone_Screenshot_", this.numShots, "_", str, ".png" };
        string filename = string.Concat(objArray2);
        Debug.Log("Screenshot Captured! - " + filename);
        Application.CaptureScreenshot(filename, superSize);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            this.TakeShot();
        }
    }
}

