using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class AnimationUtil
{
    public static void ScaleFade(GameObject go, Vector3 scale)
    {
        ScaleFade(go, scale, null);
    }

    public static void ScaleFade(GameObject go, Vector3 scale, string callbackName)
    {
        Hashtable hashtable;
        iTween.FadeTo(go, 0f, 0.25f);
        if (string.IsNullOrEmpty(callbackName))
        {
            object[] args = new object[] { "scale", scale, "time", 0.25f };
            hashtable = iTween.Hash(args);
        }
        else
        {
            object[] objArray2 = new object[] { "scale", scale, "time", 0.25f, "oncomplete", callbackName, "oncompletetarget", go };
            hashtable = iTween.Hash(objArray2);
        }
        iTween.ScaleTo(go, hashtable);
    }

    public static void ShowPunch(GameObject go, Vector3 scale, string callbackName = "")
    {
        if (string.IsNullOrEmpty(callbackName))
        {
            iTween.ScaleTo(go, scale, 0.15f);
        }
        else
        {
            object[] args = new object[] { "scale", scale, "time", 0.15f, "oncomplete", callbackName, "oncompletetarget", go };
            Hashtable hashtable = iTween.Hash(args);
            iTween.ScaleTo(go, hashtable);
        }
    }

    [DebuggerHidden]
    private static IEnumerator ShowPunchRoutine(PunchData callbackData)
    {
        return new <ShowPunchRoutine>c__IteratorE9 { callbackData = callbackData, <$>callbackData = callbackData };
    }

    public static void ShowWithPunch(GameObject go, Vector3 startScale, Vector3 punchScale, Vector3 afterPunchScale, string callbackName = "")
    {
        iTween.FadeTo(go, 1f, 0.25f);
        go.transform.localScale = startScale;
        object[] args = new object[] { "scale", punchScale, "time", 0.25f };
        iTween.ScaleTo(go, iTween.Hash(args));
        object[] objArray2 = new object[] { "position", go.transform.position + new Vector3(0.02f, 0.02f, 0.02f), "time", 1.5f };
        iTween.MoveTo(go, iTween.Hash(objArray2));
        PunchData data2 = new PunchData {
            m_gameObject = go,
            m_scale = afterPunchScale,
            m_callbackName = callbackName
        };
        PunchData callbackData = data2;
        go.GetComponent<MonoBehaviour>().StartCoroutine(ShowPunchRoutine(callbackData));
    }

    [CompilerGenerated]
    private sealed class <ShowPunchRoutine>c__IteratorE9 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal AnimationUtil.PunchData <$>callbackData;
        internal AnimationUtil.PunchData callbackData;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                    this.$current = new WaitForSeconds(0.25f);
                    this.$PC = 1;
                    return true;

                case 1:
                    AnimationUtil.ShowPunch(this.callbackData.m_gameObject, this.callbackData.m_scale, this.callbackData.m_callbackName);
                    this.$PC = -1;
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    public delegate void DelOnShownWithPunch();

    private class PunchData
    {
        public string m_callbackName;
        public GameObject m_gameObject;
        public Vector3 m_scale;
    }
}

