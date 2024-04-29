using Godot;
using System;

public partial class HeartPanel : Panel
{
    public Sprite2D HeartSprite;

    public override void _Ready()
    {
        HeartSprite = GetNode<Sprite2D>("HeartSprite");
    }
    public void Update(bool isWhole)
    {
        HeartSprite.Frame = isWhole ? 0 : 4;
    }
}
