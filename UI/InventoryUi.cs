using Godot;
using System;

public partial class InventoryUi : Control
{
    public bool IsOpen = false;
    public void Open()
    {
        Visible = true;
        IsOpen = true;
    }

    public void Close()
    {
        Visible = false;
        IsOpen = false;
    }
}
