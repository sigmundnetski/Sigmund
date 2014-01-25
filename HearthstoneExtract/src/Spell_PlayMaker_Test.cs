using System;
using UnityEngine;

public class Spell_PlayMaker_Test : MonoBehaviour
{
    public Spell m_Spell;

    private void LayoutFsmControls()
    {
        if (this.m_Spell != null)
        {
            PlayMakerFSM component = this.m_Spell.GetComponent<PlayMakerFSM>();
            if (component != null)
            {
                Vector2 vector = new Vector2(Screen.width * 0.1f, Screen.height * 0.04f);
                Vector2 vector2 = new Vector2(Screen.width * 0.1f, Screen.height * 0.1f);
                Vector2 vector3 = new Vector2(vector2.x, vector2.y);
                Vector2 vector4 = vector3;
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "FSM go to BIRTH"))
                {
                    component.Fsm.Event(EnumUtils.GetString<SpellStateType>(SpellStateType.BIRTH));
                }
                vector4.y += 1.5f * vector.y;
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "FSM go to CANCEL"))
                {
                    component.Fsm.Event(EnumUtils.GetString<SpellStateType>(SpellStateType.CANCEL));
                }
                vector4.y += 1.5f * vector.y;
                if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "FSM go to ACTION"))
                {
                    component.Fsm.Event(EnumUtils.GetString<SpellStateType>(SpellStateType.ACTION));
                }
                vector4.y += 1.5f * vector.y;
            }
        }
    }

    private void LayoutSpellControls()
    {
        if (this.m_Spell != null)
        {
            Vector2 vector = new Vector2(Screen.width * 0.1f, Screen.height * 0.04f);
            Vector2 vector2 = new Vector2(Screen.width * 0.1f, Screen.height * 0.1f);
            Vector2 vector3 = new Vector2((Screen.width - vector.x) - vector2.x, vector2.y);
            Vector2 vector4 = vector3;
            switch (this.m_Spell.GetActiveState())
            {
                case SpellStateType.NONE:
                    if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Spell go to BIRTH"))
                    {
                        this.m_Spell.ChangeState(SpellStateType.BIRTH);
                    }
                    vector4.y += 1.5f * vector.y;
                    break;

                case SpellStateType.IDLE:
                    if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Spell go to CANCEL"))
                    {
                        this.m_Spell.ChangeState(SpellStateType.CANCEL);
                    }
                    vector4.y += 1.5f * vector.y;
                    if (GUI.Button(new Rect(vector4.x, vector4.y, vector.x, vector.y), "Spell go to ACTION"))
                    {
                        this.m_Spell.ChangeState(SpellStateType.ACTION);
                    }
                    vector4.y += 1.5f * vector.y;
                    break;
            }
        }
    }

    private void OnGUI()
    {
        this.LayoutFsmControls();
        this.LayoutSpellControls();
    }
}

