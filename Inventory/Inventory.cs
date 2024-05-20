using System.Collections.Generic;
using Godot;
using Godot.Collections;

namespace ActionRPGTutorial.Inventory;

[GlobalClass]
public partial class Inventory : Resource
{
    [Export]
    public Array<InventoryItem> InventoryItems { get; set; } = new();

    public void Insert(InventoryItem item)
    {

    }
}
