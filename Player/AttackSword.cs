using Godot;
using System;

public partial class AttackSword : Area2D
{
    public CollisionShape2D Shape { get; set; }

    public override void _Ready()
    {
        Shape = GetNode<CollisionShape2D>("AttackSwordCollision");
        Disable();
    }

    public void Enable()
    {
        Shape.Disabled = false;
    }

    public void Disable()
    {
        Shape.Disabled = true;
    }
}
