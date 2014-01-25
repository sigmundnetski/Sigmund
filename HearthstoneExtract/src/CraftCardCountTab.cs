using System;
using UnityEngine;

public class CraftCardCountTab : MonoBehaviour
{
    public TextMesh m_count;
    public TextMesh m_plus;
    private Vector3 origPos = new Vector3(0f, 0f, 0f);

    private void Awake()
    {
        this.origPos = this.m_count.transform.localPosition;
    }

    public void UpdateText(int numCopies)
    {
        if (numCopies > 9)
        {
            this.m_count.text = "9";
            this.m_plus.gameObject.SetActive(true);
            this.m_count.transform.localPosition = new Vector3(0.08628464f, this.origPos.y, this.origPos.z);
        }
        else
        {
            this.m_count.text = numCopies.ToString();
            this.m_plus.gameObject.SetActive(false);
            this.m_count.transform.localPosition = this.origPos;
        }
    }
}

