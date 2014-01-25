using System;

public class OffClickCatcher : PegUIElement
{
    protected override void OnRelease()
    {
        CraftingManager.Get().CancelCraftMode();
    }

    protected override void OnRightClick()
    {
        CraftingManager.Get().CancelCraftMode();
    }
}

