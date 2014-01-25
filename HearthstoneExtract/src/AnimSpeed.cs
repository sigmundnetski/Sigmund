using System;
using System.Collections;
using UnityEngine;

public class AnimSpeed : MonoBehaviour
{
    public float animspeed = 1f;

    private void Awake()
    {
        IEnumerator enumerator = base.animation.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                AnimationState current = (AnimationState) enumerator.Current;
                current.speed = this.animspeed;
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }
}

