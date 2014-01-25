using System;
using UnityEngine;

public class ClassProgressBar : MonoBehaviour
{
    public TAG_CLASS m_class;
    public GameObject m_classIcon;
    public GameObject m_classLockedGO;
    public UberText m_classNameText;
    public UberText m_levelText;
    public UberText m_lockedText;
    public ProgressBar m_progressBar;

    private void Awake()
    {
        this.m_lockedText.Text = GameStrings.Get("GLUE_QUEST_LOG_CLASS_LOCKED");
    }

    public void Init()
    {
        this.m_classNameText.Text = GameStrings.GetClassName(this.m_class);
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}

