using ActionRPGTutorial.Inventory;
using Godot;

namespace ActionRPGTutorial;

public partial class Collectible : Area2D
{
    [Export]
    public InventoryItem? ItemResource { get; set; }
    public virtual void Collect(Inventory.Inventory? inventory)
    {
        if (ItemResource != null)
        {
            inventory?.Insert(ItemResource);
        }
        QueueFree();
    }
}
