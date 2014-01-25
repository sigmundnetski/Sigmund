using System;

public class ArmorSpell : Spell
{
    private int m_armor;
    public UberText m_ArmorText;

    public int GetArmor()
    {
        return this.m_armor;
    }

    public void SetArmor(int armor)
    {
        this.m_armor = armor;
        this.UpdateArmorText();
    }

    private void UpdateArmorText()
    {
        if (this.m_ArmorText != null)
        {
            string str = this.m_armor.ToString();
            if (this.m_armor == 0)
            {
                str = string.Empty;
            }
            this.m_ArmorText.Text = str;
        }
    }
}

