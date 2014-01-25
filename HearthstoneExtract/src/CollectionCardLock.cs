using System;
using UnityEngine;

public class CollectionCardLock : MonoBehaviour
{
    public TextMesh m_lockText;

    public void SetLockText(string text)
    {
        this.m_lockText.text = text;
        TextUtils.HackAssignOutlineText(this.m_lockText, this.m_lockText.text);
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}

