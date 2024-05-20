using Godot;

namespace ActionRPGTutorial.Inventory;

[GlobalClass]
public partial class InventorySlotResource : Resource
{
    [Export]
    public InventoryItem? InventoryItem { get; set; }
    [Export] 
    public int ItemAmount { get; set; }
}