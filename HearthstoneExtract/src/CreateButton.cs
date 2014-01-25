using System;

public class CreateButton : CraftingButton
{
    public override void EnableButton()
    {
        if (CraftingManager.Get().GetNumTransactions() < 0)
        {
            base.EnterUndoMode();
        }
        else
        {
            base.labelText.Text = GameStrings.Get("GLUE_CRAFTING_CREATE");
            base.EnableButton();
        }
    }

    protected override void OnRelease()
    {
        CraftingManager.Get().craftingUI.DoCreate();
        base.animation.Play("CardExchange_ButtonPress2");
    }
}

