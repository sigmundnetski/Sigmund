using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RandomSpawnTimed : MonoBehaviour
{
    public float killX = 10f;
    public float killZ = 10f;
    private List<GameObject> listOfObjs;
    public float maxWaitTime = 15f;
    public float minWaitTime = 5f;
    public GameObject objPrefab;

    [DebuggerHidden]
    private IEnumerator RespawnLoop()
    {
        return new <RespawnLoop>c__Iterator100 { <>f__this = this };
    }

    private void Start()
    {
        this.listOfObjs = new List<GameObject>();
        base.StartCoroutine(this.RespawnLoop());
    }

    private void Update()
    {
        for (int i = 0; i < this.listOfObjs.Count; i++)
        {
            if ((Mathf.Abs((float) (this.listOfObjs[i].transform.position.x - base.gameObject.transform.position.x)) > this.killX) || (Mathf.Abs((float) (this.listOfObjs[i].transform.position.z - base.gameObject.transform.position.z)) > this.killZ))
            {
                GameObject obj2 = this.listOfObjs[i];
                this.listOfObjs.Remove(this.listOfObjs[i]);
                UnityEngine.Object.Destroy(obj2);
                i--;
            }
        }
    }

    [CompilerGenerated]
    private sealed class <RespawnLoop>c__Iterator100 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal RandomSpawnTimed <>f__this;
        internal float <timeToWait>__0;

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
                    break;

                case 1:
                    this.<>f__this.listOfObjs.Add((GameObject) UnityEngine.Object.Instantiate(this.<>f__this.objPrefab, this.<>f__this.transform.position, UnityEngine.Random.rotation));
                    break;

                default:
                    return false;
            }
            this.<timeToWait>__0 = UnityEngine.Random.Range(this.<>f__this.minWaitTime, this.<>f__this.maxWaitTime);
            this.$current = new WaitForSeconds(this.<timeToWait>__0);
            this.$PC = 1;
            return true;
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

