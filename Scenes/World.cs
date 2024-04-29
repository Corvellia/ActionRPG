using Godot;
using System;
using ActionRPGTutorial.Player;

public partial class World : Node2D
{
    public HeartsContainer HeartsContainer;
    public Player Player;

    public override void _Ready()
    {
        HeartsContainer = GetNode<HeartsContainer>("CanvasLayer/HeartsContainer");
        Player = GetNode<Player>("TileMap/Player");
        HeartsContainer.SetMaxHearts(Player.MaxHealth);
        HeartsContainer.UpdateHearts(1);
        Player.Connect(Player.SignalName.HealthChanged, HeartsContainer.UpdateHearts);
    }
}
