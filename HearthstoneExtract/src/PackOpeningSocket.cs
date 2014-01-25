using System;

public class PackOpeningSocket : PegUIElement
{
    private Spell m_alertSpell;

    protected override void Awake()
    {
        base.Awake();
        this.m_alertSpell = base.GetComponent<Spell>();
    }

    public void OnPackHeld()
    {
        this.m_alertSpell.ActivateState(SpellStateType.BIRTH);
    }

    public bool OnPackReleased(UnopenedPack pack)
    {
        this.m_alertSpell.ActivateState(SpellStateType.DEATH);
        return UniversalInputManager.Get().InputIsOver(base.gameObject);
    }
}

