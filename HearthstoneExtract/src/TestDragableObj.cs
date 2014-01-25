using System;
using UnityEngine;

public class TestDragableObj : MonoBehaviour
{
    private GameObject activeObj;
    public GameObject card;
    public PlayMakerFSM cardDeath;
    public PlayMakerFSM deckCardBarDeath;
    private GameObject inActiveObj;
    public GameObject tile;

    private void Start()
    {
        this.activeObj = this.card;
        this.inActiveObj = this.tile;
        this.activeObj.SetActive(true);
        this.inActiveObj.SetActive(false);
    }

    public void SwapActiveObj()
    {
        GameObject inActiveObj = this.inActiveObj;
        this.inActiveObj = this.activeObj;
        this.activeObj = inActiveObj;
        this.activeObj.SetActive(true);
        this.inActiveObj.SetActive(false);
        if (this.inActiveObj.activeInHierarchy)
        {
            this.cardDeath.SendEvent("Birth");
        }
        else
        {
            this.deckCardBarDeath.SendEvent("Birth");
            this.cardDeath.SendEvent("Birth");
        }
    }

    private void Update()
    {
    }
}

