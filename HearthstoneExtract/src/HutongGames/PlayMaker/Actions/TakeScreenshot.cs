namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using System.IO;
    using UnityEngine;

    [Tooltip("Saves a Screenshot to the users MyPictures folder. TIP: Can be useful for automated testing and debugging."), ActionCategory(ActionCategory.Application)]
    public class TakeScreenshot : FsmStateAction
    {
        public bool autoNumber;
        [RequiredField]
        public FsmString filename;
        private int screenshotCount;

        public override void OnEnter()
        {
            if (!string.IsNullOrEmpty(this.filename.Value))
            {
                string str = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "/";
                string path = str + this.filename.Value + ".png";
                if (this.autoNumber)
                {
                    while (File.Exists(path))
                    {
                        this.screenshotCount++;
                        object[] objArray1 = new object[] { str, this.filename.Value, this.screenshotCount, ".png" };
                        path = string.Concat(objArray1);
                    }
                }
                Application.CaptureScreenshot(path);
                base.Finish();
            }
        }

        public override void Reset()
        {
            this.filename = string.Empty;
            this.autoNumber = false;
        }
    }
}

