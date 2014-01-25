using System;
using UnityEngine;

public class DeckEditTouchBehavior : PegUICustomBehavior
{
    private CollectionDeckTileVisual m_currentDeckTile;
    private PegUIElement m_currentUIElement;
    public GameObject m_hitBox;
    private bool m_isActive;
    private Vector3 m_mouseDownLoc;
    public float m_scrollAmount;
    public DeckTrayScrollbar m_scrollBar;
    public GameObject m_scrollBarArea;
    public GameObject m_scrollDown;
    private int m_scrollImpl;
    public GameObject m_scrollUp;
    private bool m_usingScrollbar;

    public override bool UpdateUI()
    {
        return this.m_isActive;
    }
}

