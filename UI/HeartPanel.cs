using Godot;

namespace ActionRPGTutorial.UI;

public partial class HeartPanel : Panel
{
    private Sprite2D? _heartSprite;

    public override void _Ready()
    {
        _heartSprite = GetNode<Sprite2D>("HeartSprite");
    }
    public void Update(bool isWhole)
    {
        if (_heartSprite != null)
        {
            _heartSprite.Frame = isWhole ? 0 : 4;
        }
    }
}