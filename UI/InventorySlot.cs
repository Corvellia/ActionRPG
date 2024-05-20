using ActionRPGTutorial.Inventory;
using Godot;

namespace ActionRPGTutorial.UI;

public partial class InventorySlot : Panel
{
    private Sprite2D _backgroundSprite;
    private Sprite2D _item;
    public override void _Ready()
    {
        _backgroundSprite = GetNode<Sprite2D>("InventorySlotSprite");
        _item = GetNode<Sprite2D>("CenterContainer/Panel/Item");
    }

    public void Update(InventoryItem? item)
    {
        if (item is null)
        {
            _backgroundSprite.Frame = 0;
            _item.Visible = false;
        }
        else
        {
            _backgroundSprite.Frame = 1;
            _item.Visible = true;
            _item.Texture = item.Texture;
        }
    }
}