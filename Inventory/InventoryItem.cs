using Godot;

public partial class InventoryItem : Resource
{
    [Export]
    public string Name = "";

    [Export]
    private Texture2D Texture;
}
