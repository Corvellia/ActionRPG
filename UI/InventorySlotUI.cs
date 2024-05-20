using System.Globalization;
using ActionRPGTutorial.Inventory;
using Godot;

namespace ActionRPGTutorial.UI;

public partial class InventorySlotUI : Panel
{
    private Sprite2D? _backgroundSprite;
    private Sprite2D? _item;
    public Label? AmountLabel;
    public override void _Ready()
    {
        _backgroundSprite = GetNode<Sprite2D>("InventorySlotSprite");
        _item = GetNode<Sprite2D>("CenterContainer/Panel/Item");
        AmountLabel = GetNode<Label>("CenterContainer/Panel/AmountLabel");
    }

    public void Update(InventorySlotResource? inventorySlot)
    {
        if (inventorySlot?.InventoryItem is null)
        {
            if (_backgroundSprite != null)
            {
                _backgroundSprite.Frame = 0;
            }

            if (_item != null)
            {
                _item.Visible = false;
                if (AmountLabel != null)
                {
                    AmountLabel.Visible = false;
                }
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
                _item.Texture = inventorySlot.InventoryItem.Texture;
                if (AmountLabel != null)
                {
                    AmountLabel.Visible = true;
                    AmountLabel.Text = inventorySlot.ItemAmount.ToString(CultureInfo.InvariantCulture);
                }
            }
        }
    }
}