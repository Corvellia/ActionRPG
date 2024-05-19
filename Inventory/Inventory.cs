using System.Collections.Generic;
using Godot;

namespace ActionRPGTutorial.Inventory;

public partial class Inventory : Resource
{
    [Export]
#pragma warning disable GD0102
    private List<InventoryItem> InventoryItems = new List<InventoryItem>();
#pragma warning restore GD0102
}