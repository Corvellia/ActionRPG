using Godot;
using Godot.Collections;

namespace ActionRPGTutorial.Inventory;

[GlobalClass]
public partial class Inventory : Resource
{
    [Signal]
    public delegate void InventoryUpdatedEventHandler();

    [Export]
    public Array<InventoryItem> InventoryItems { get; set; } = new();

    public void Insert(InventoryItem item)
    {
        for (int i = 0; i < InventoryItems.Count; i++)
        {
            if (InventoryItems[i] is null)
            {
                InventoryItems[i] = item;
                break;
            }
        }

        EmitSignal(nameof(InventoryUpdated));
    }


}
