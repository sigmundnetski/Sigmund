using System;
using UnityEngine;

public class PlayOnce : MonoBehaviour
{
    public string notes;
    public string notes2;
    public GameObject tester;
    public GameObject tester2;
    public string tester2Anim;
    public GameObject tester3;
    public string tester3Anim;
    public string testerAnim;

    private void OnGUI()
    {
        if (Event.current.isKey)
        {
            if (this.tester != null)
            {
                this.tester.SetActive(true);
                this.tester.animation.Stop(this.testerAnim);
                this.tester.animation.Play(this.testerAnim);
            }
            else
            {
                Debug.Log("NO 'tester' object.");
            }
            if (this.tester2 != null)
            {
                this.tester2.SetActive(true);
                this.tester2.animation.Stop(this.tester2Anim);
                this.tester2.animation.Play(this.tester2Anim);
            }
            else
            {
                Debug.Log("NO 'tester2' object.");
            }
            if (this.tester3 != null)
            {
                this.tester3.SetActive(true);
                this.tester3.animation.Stop(this.tester3Anim);
                this.tester3.animation.Play(this.tester3Anim);
            }
            else
            {
                Debug.Log("NO 'tester3' object.");
            }
        }
    }

    private void Start()
    {
        if (this.tester != null)
        {
            this.tester.SetActive(false);
        }
        if (this.tester2 != null)
        {
            this.tester2.SetActive(false);
        }
        if (this.tester3 != null)
        {
            this.tester3.SetActive(false);
        }
    }

    private void Update()
    {
    }
}

