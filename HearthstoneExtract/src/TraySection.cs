using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TraySection : MonoBehaviour
{
    private const float DOOR_ANIM_SPEED = 6f;
    private readonly string DOOR_CLOSE_ANIM_NAME = "Deck_DoorClose";
    private readonly string DOOR_OPEN_ANIM_NAME = "Deck_DoorOpen";
    public GameObject m_door;
    private bool m_isOpen;

    public void CloseDoor()
    {
        this.CloseDoor(null);
    }

    public void CloseDoor(DelOnDoorStateChangedCallback callback)
    {
        this.CloseDoor(callback, null);
    }

    public void CloseDoor(DelOnDoorStateChangedCallback callback, object callbackData)
    {
        this.CloseDoor(false, callback, callbackData);
    }

    private void CloseDoor(bool isImmediate, DelOnDoorStateChangedCallback callback, object callbackData)
    {
        if (!this.m_isOpen)
        {
            if (callback != null)
            {
                callback(callbackData);
            }
        }
        else
        {
            this.m_isOpen = false;
            this.m_door.animation[this.DOOR_CLOSE_ANIM_NAME].time = !isImmediate ? 0f : this.m_door.animation[this.DOOR_CLOSE_ANIM_NAME].length;
            this.m_door.animation[this.DOOR_CLOSE_ANIM_NAME].speed = 6f;
            this.PlayDoorAnimation(this.DOOR_CLOSE_ANIM_NAME, callback, callbackData);
        }
    }

    public void CloseDoorImmediately()
    {
        this.CloseDoorImmediately(null);
    }

    public void CloseDoorImmediately(DelOnDoorStateChangedCallback callback)
    {
        this.CloseDoorImmediately(callback, null);
    }

    public void CloseDoorImmediately(DelOnDoorStateChangedCallback callback, object callbackData)
    {
        this.CloseDoor(true, callback, callbackData);
    }

    public Bounds GetDoorBounds()
    {
        return this.m_door.GetComponent<UnityEngine.Renderer>().bounds;
    }

    public void Hide()
    {
        this.Show(false);
    }

    public bool IsOpen()
    {
        return this.m_isOpen;
    }

    public void OpenDoor()
    {
        this.OpenDoor(null);
    }

    public void OpenDoor(DelOnDoorStateChangedCallback callback)
    {
        this.OpenDoor(callback, null);
    }

    public void OpenDoor(DelOnDoorStateChangedCallback callback, object callbackData)
    {
        this.OpenDoor(false, callback, callbackData);
    }

    private void OpenDoor(bool isImmediate, DelOnDoorStateChangedCallback callback, object callbackData)
    {
        if (this.m_isOpen)
        {
            if (callback != null)
            {
                callback(callbackData);
            }
        }
        else
        {
            this.m_isOpen = true;
            this.m_door.animation[this.DOOR_OPEN_ANIM_NAME].time = !isImmediate ? 0f : this.m_door.animation[this.DOOR_OPEN_ANIM_NAME].length;
            this.m_door.animation[this.DOOR_OPEN_ANIM_NAME].speed = 6f;
            this.PlayDoorAnimation(this.DOOR_OPEN_ANIM_NAME, callback, callbackData);
        }
    }

    public void OpenDoorImmediately()
    {
        this.OpenDoorImmediately(null);
    }

    public void OpenDoorImmediately(DelOnDoorStateChangedCallback callback)
    {
        this.OpenDoorImmediately(callback, null);
    }

    public void OpenDoorImmediately(DelOnDoorStateChangedCallback callback, object callbackData)
    {
        this.OpenDoor(true, callback, callbackData);
    }

    private void PlayDoorAnimation(string animationName, DelOnDoorStateChangedCallback callback, object callbackData)
    {
        this.m_door.animation.Play(animationName);
        OnDoorStateChangedCallbackData data2 = new OnDoorStateChangedCallbackData {
            m_callback = callback,
            m_callbackData = callbackData,
            m_animationName = animationName
        };
        OnDoorStateChangedCallbackData data = data2;
        base.StopCoroutine("WaitThenCallDoorAnimationCallback");
        base.StartCoroutine("WaitThenCallDoorAnimationCallback", data);
    }

    public void Show()
    {
        this.Show(true);
    }

    private void Show(bool show)
    {
        this.m_door.gameObject.SetActive(show);
    }

    [DebuggerHidden]
    private IEnumerator WaitThenCallDoorAnimationCallback(OnDoorStateChangedCallbackData callbackData)
    {
        return new <WaitThenCallDoorAnimationCallback>c__Iterator20 { callbackData = callbackData, <$>callbackData = callbackData, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenCallDoorAnimationCallback>c__Iterator20 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal TraySection.OnDoorStateChangedCallbackData <$>callbackData;
        internal TraySection <>f__this;
        internal TraySection.OnDoorStateChangedCallbackData callbackData;

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
                    if (this.callbackData.m_callback != null)
                    {
                        this.$current = new WaitForSeconds(this.<>f__this.m_door.animation[this.callbackData.m_animationName].length / this.<>f__this.m_door.animation[this.callbackData.m_animationName].speed);
                        this.$PC = 1;
                        return true;
                    }
                    break;

                case 1:
                    this.callbackData.m_callback(this.callbackData.m_callbackData);
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

    public delegate void DelOnDoorStateChangedCallback(object callbackData);

    private class OnDoorStateChangedCallbackData
    {
        public string m_animationName;
        public TraySection.DelOnDoorStateChangedCallback m_callback;
        public object m_callbackData;
    }
}

