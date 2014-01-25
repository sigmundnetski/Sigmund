using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSocketMgr : MonoBehaviour
{
    public List<WeaponSocketDecoration> m_Decorations;

    public static bool ShouldSeeWeaponSocket(TAG_CLASS tagVal)
    {
        switch (tagVal)
        {
            case TAG_CLASS.DRUID:
            case TAG_CLASS.MAGE:
            case TAG_CLASS.PRIEST:
            case TAG_CLASS.WARLOCK:
                return false;
        }
        return true;
    }

    public void UpdateSockets()
    {
        if (this.m_Decorations != null)
        {
            foreach (WeaponSocketDecoration decoration in this.m_Decorations)
            {
                decoration.UpdateVisibility();
            }
        }
    }
}

