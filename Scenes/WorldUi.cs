using Godot;
using System;

public partial class WorldUi : CanvasLayer
{
    public InventoryUi InventoryGui = new();
    public override void _Ready()
    {
        InventoryGui = GetNode<InventoryUi>("InventoryUi");
        if (InventoryGui is null)
        {
            throw new ArgumentException("Could not load InventoryGui");
        }

        InventoryGui.Call("Close");
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("ToggleInventory"))
        {
            if (InventoryGui.IsOpen)
            {
                InventoryGui.Call("Close");
            }
            else
            {
                InventoryGui.Call("Open");
            }
        }
    }
}
