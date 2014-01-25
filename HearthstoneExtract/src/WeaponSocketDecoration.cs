using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSocketDecoration : MonoBehaviour
{
    public List<WeaponSocketRequirement> m_VisibilityRequirements;

    public bool AreVisibilityRequirementsMet()
    {
        Dictionary<int, Player> playerMap = GameState.Get().GetPlayerMap();
        if (playerMap == null)
        {
            return false;
        }
        if (this.m_VisibilityRequirements == null)
        {
            return false;
        }
        foreach (WeaponSocketRequirement requirement in this.m_VisibilityRequirements)
        {
            bool flag = false;
            foreach (Player player in playerMap.Values)
            {
                if (requirement.m_Side == player.GetSide())
                {
                    Entity hero = player.GetHero();
                    if (hero == null)
                    {
                        Debug.LogWarning(string.Format("WeaponSocketDecoration.AreVisibilityRequirementsMet() - player {0} has no hero", player));
                        return false;
                    }
                    if (requirement.m_HasWeapon != WeaponSocketMgr.ShouldSeeWeaponSocket(hero.GetClass()))
                    {
                        return false;
                    }
                    flag = true;
                }
            }
            if (!flag)
            {
                return false;
            }
        }
        return true;
    }

    public void Hide()
    {
        SceneUtils.EnableRenderers(base.gameObject, false);
    }

    public bool IsShown()
    {
        return base.renderer.enabled;
    }

    public void Show()
    {
        SceneUtils.EnableRenderers(base.gameObject, true);
    }

    public void UpdateVisibility()
    {
        if (this.AreVisibilityRequirementsMet())
        {
            this.Show();
        }
        else
        {
            this.Hide();
        }
    }
}

