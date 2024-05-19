using Godot;

namespace ActionRPGTutorial.Inventory;

public partial class InventoryItem : Resource
{
    [Export] 
    private string _name = "";
    [Export] 
    private Texture2D _texture;
}