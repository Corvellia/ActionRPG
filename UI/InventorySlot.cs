using ActionRPGTutorial.Inventory;
using Godot;

namespace ActionRPGTutorial.UI;

public partial class InventorySlot : Panel
{
    private Sprite2D? _backgroundSprite;
    private Sprite2D? _item;
    public override void _Ready()
    {
        _backgroundSprite = GetNode<Sprite2D>("InventorySlotSprite");
        _item = GetNode<Sprite2D>("CenterContainer/Panel/Item");
    }

    public void Update(InventoryItem? item)
    {
        if (item is null)
        {
            if (_backgroundSprite != null)
            {
                _backgroundSprite.Frame = 0;
            }

            if (_item != null)
            {
                _item.Visible = false;
            }
        }
        else
        {
            if (_backgroundSprite != null)
            {
                _backgroundSprite.Frame = 1;
            }

            if (_item != null)
            {
                _item.Visible = true;
                _item.Texture = item.Texture;
            }
        }
    }
}