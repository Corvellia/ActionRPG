using Godot;

namespace ActionRPGTutorial.Inventory;

[GlobalClass]
public partial class InventoryItem : Resource
{
    [Export] 
    private string _name = "";
    [Export] 
    public Texture2D Texture { get; set; }
}