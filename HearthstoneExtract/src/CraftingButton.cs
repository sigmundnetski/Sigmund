using System;
using UnityEngine;

public class CraftingButton : PegUIElement
{
    public MeshRenderer buttonRenderer;
    public Material disabledMaterial;
    public Material enabledMaterial;
    private bool isEnabled;
    public UberText labelText;
    public Material undoMaterial;

    public virtual void DisableButton()
    {
        base.collider.enabled = false;
        this.isEnabled = false;
        this.buttonRenderer.material = this.disabledMaterial;
        this.labelText.Text = string.Empty;
    }

    public virtual void EnableButton()
    {
        this.isEnabled = true;
        base.collider.enabled = true;
        this.buttonRenderer.material = this.enabledMaterial;
    }

    public virtual void EnterUndoMode()
    {
        base.collider.enabled = true;
        this.isEnabled = true;
        this.buttonRenderer.material = this.undoMaterial;
        this.labelText.Text = GameStrings.Get("GLUE_CRAFTING_UNDO");
    }

    public bool IsButtonEnabled()
    {
        return this.isEnabled;
    }
}

