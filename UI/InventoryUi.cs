using Godot;
using Godot.Collections;

namespace ActionRPGTutorial.UI;

public partial class InventoryUi : Control
{
    [Signal]
    public delegate void OpenedEventHandler();
    [Signal]
    public delegate void ClosedEventHandler();
    [Export]
    private Inventory.Inventory? _inventory;
    public bool IsOpen { get; set; }
    private GlobalTools.Signals.CustomSignals? _customSignals;
    private Array<Node> _slots = new();
    public override void _Ready()
    {
        _customSignals = GetNode<GlobalTools.Signals.CustomSignals>("/root/CustomSignals"); //root because we set it in autoload
        _slots = GetNode<GridContainer>("NinePatchRect/GridContainer").GetChildren();
        if (_inventory != null)
        {
            _inventory.InventoryUpdated += Update;
        }
        Update();
    }

    public void Update()
    {
        var indexRange = _slots.Count;

        if (_inventory?.InventorySlots.Count < _slots.Count)
        {
            indexRange = _inventory.InventorySlots.Count;
        }

        for (int i = 0; i < indexRange; i++)
        {
            InventorySlotUI? thisSlot = _slots[i] as InventorySlotUI;
            thisSlot?.Update(_inventory?.InventorySlots[i]);
        }
    }

    public void Open()
    {
        Visible = true;
        IsOpen = true;
        _customSignals?.EmitSignal(SignalName.Opened);
    }

    public void Close()
    {
        Visible = false;
        IsOpen = false;
        _customSignals?.EmitSignal(SignalName.Closed);
    }
}