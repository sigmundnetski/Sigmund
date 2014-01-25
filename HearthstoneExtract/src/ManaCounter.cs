using System;
using UnityEngine;

public class ManaCounter : MonoBehaviour
{
    private Player m_player;
    public Player.Side m_Side;
    private UberText m_textMesh;

    private void Awake()
    {
        this.m_textMesh = base.GetComponent<UberText>();
    }

    public Player GetPlayer()
    {
        return this.m_player;
    }

    public void SetPlayer(Player player)
    {
        this.m_player = player;
    }

    private void Start()
    {
        object[] args = new object[] { "0", "0" };
        this.m_textMesh.Text = GameStrings.Format("GAMEPLAY_MANA_COUNTER", args);
    }

    public void UpdateText()
    {
        int tag = this.m_player.GetTag(GAME_TAG.RESOURCES);
        if (!base.gameObject.activeInHierarchy)
        {
            base.gameObject.SetActive(true);
        }
        int numAvailableResources = this.m_player.GetNumAvailableResources();
        object[] args = new object[] { numAvailableResources, tag };
        this.m_textMesh.Text = GameStrings.Format("GAMEPLAY_MANA_COUNTER", args);
    }
}

