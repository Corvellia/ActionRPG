using System.Linq;
using Godot;
using Godot.Collections;

namespace ActionRPGTutorial.Inventory;

[GlobalClass]
public partial class Inventory : Resource
{
    [Signal]
    public delegate void InventoryUpdatedEventHandler();

    [Export]
    public Array<InventorySlotResource> InventorySlots { get; set; } = new();

    public void Insert(InventoryItem item)
    {
        foreach (var slot in InventorySlots)
        {
            if (slot.InventoryItem == item && slot.ItemAmount < slot.InventoryItem.MaximumItemStackAmount)
            {
                slot.ItemAmount += 1;
                EmitSignal(nameof(InventoryUpdated));
                return;
            }
        }

        foreach (var slot in InventorySlots)
        {
            if (slot.InventoryItem is null)
            {
                slot.InventoryItem = item;
                slot.ItemAmount = 1;
                EmitSignal(nameof(InventoryUpdated));
                return;
            }
        }

    }


}
