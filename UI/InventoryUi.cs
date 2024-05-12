using Godot;
using System;

public partial class InventoryUi : Control
{
    [Signal]
    public delegate void OpenedEventHandler(); 
    [Signal]
    public delegate void ClosedEventHandler();
    public bool IsOpen;
    private CustomSignals _customSignals;

    public override void _Ready()
    {
        _customSignals = GetNode<CustomSignals>("/root/CustomSignals"); //root because we set it in autoload
    }

    public void Open()
    {
        Visible = true;
        IsOpen = true;
        _customSignals.EmitSignal(SignalName.Opened);
    }

    public void Close()
    {
        Visible = false;
        IsOpen = false;
        _customSignals.EmitSignal(SignalName.Closed);
    }
}
