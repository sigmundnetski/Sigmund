using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LightningCtrl : MonoBehaviour
{
    public GameObject destination;
    public float lifetime = 1f;
    private GameObject lightningObj;
    public GameObject mylightning;
    public float position_X;
    public float position_Y;
    public float position_Z;
    public float scale = 0.1f;
    public float speed = 1f;
    public GameObject target;

    [DebuggerHidden]
    private IEnumerator DestroyLightning()
    {
        return new <DestroyLightning>c__IteratorBE { <>f__this = this };
    }

    public void Spawn(Transform targetTransform, Transform destinationTransform)
    {
        this.lightningObj = (GameObject) UnityEngine.Object.Instantiate(this.mylightning, new Vector3(this.position_X, this.position_Y, this.position_Z), new Quaternion(0f, 0f, 0f, 0f));
        this.lightningObj.transform.localScale = new Vector3(this.scale, this.scale, this.scale);
        ElectroScript component = this.lightningObj.GetComponent<ElectroScript>();
        component.timers.timeToPowerUp = this.speed;
        component.prefabs.target.position = targetTransform.position;
        component.prefabs.destination.position = destinationTransform.position;
        base.StartCoroutine(this.DestroyLightning());
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.Spawn(this.target.transform, this.destination.transform);
        }
    }

    [CompilerGenerated]
    private sealed class <DestroyLightning>c__IteratorBE : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal LightningCtrl <>f__this;

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
                    this.$current = new WaitForSeconds(this.<>f__this.lifetime);
                    this.$PC = 1;
                    return true;

                case 1:
                    UnityEngine.Object.Destroy(this.<>f__this.lightningObj);
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
}

