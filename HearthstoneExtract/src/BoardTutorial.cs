using System;
using UnityEngine;

public class BoardTutorial : MonoBehaviour
{
    public GameObject m_EnemyHighlight;
    private bool m_enemyHighlightEnabled;
    public GameObject m_Highlight;
    private bool m_highlightEnabled;
    public Light m_ManaSpotlight;
    private static BoardTutorial s_instance;

    private void Awake()
    {
        s_instance = this;
        SceneUtils.EnableRenderers(this.m_Highlight, false);
        SceneUtils.EnableRenderers(this.m_EnemyHighlight, false);
        if (LoadingScreen.Get() != null)
        {
            LoadingScreen.Get().NotifyMainSceneObjectAwoke(base.gameObject);
        }
    }

    public void EnableEnemyHighlight(bool enable)
    {
        if (this.m_enemyHighlightEnabled != enable)
        {
            this.m_enemyHighlightEnabled = enable;
            this.UpdateEnemyHighlight();
        }
    }

    public void EnableFullHighlight(bool enable)
    {
        this.EnableHighlight(enable);
        this.EnableEnemyHighlight(enable);
    }

    public void EnableHighlight(bool enable)
    {
        if (this.m_highlightEnabled != enable)
        {
            this.m_highlightEnabled = enable;
            this.UpdateHighlight();
        }
    }

    public static BoardTutorial Get()
    {
        return s_instance;
    }

    public bool IsHighlightEnabled()
    {
        return this.m_highlightEnabled;
    }

    private void UpdateEnemyHighlight()
    {
        if (this.m_enemyHighlightEnabled)
        {
            SceneUtils.EnableRenderers(this.m_EnemyHighlight, this.m_enemyHighlightEnabled);
            this.m_EnemyHighlight.animation.Play("Glow_PlayArea_Player_On");
        }
        else
        {
            this.m_EnemyHighlight.animation.Play("Glow_PlayArea_Player_Off");
        }
    }

    private void UpdateHighlight()
    {
        if (this.m_highlightEnabled)
        {
            SceneUtils.EnableRenderers(this.m_Highlight, this.m_highlightEnabled);
            this.m_Highlight.animation.Play("Glow_PlayArea_Player_On");
        }
        else
        {
            this.m_Highlight.animation.Play("Glow_PlayArea_Player_Off");
        }
    }
}

