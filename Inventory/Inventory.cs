using System.Collections.Generic;
using Godot;
using Godot.Collections;

namespace ActionRPGTutorial.Inventory;

[GlobalClass]
public partial class Inventory : Resource
{
#pragma warning disable GD0102
    [Export]
    public Array<InventoryItem> InventoryItems { get; set; } = new();
#pragma warning restore GD0102
}
