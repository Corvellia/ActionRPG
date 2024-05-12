using Godot;
using System;
using ActionRPGTutorial.Player;

public partial class World : Node2D
{
    public HeartsContainer HeartsContainer;
    public Player Player;
    private CustomSignals _customSignals;

    public override void _Ready()
    {
        HeartsContainer = GetNode<HeartsContainer>("WorldUi/HeartsContainer");
        Player = GetNode<Player>("TileMap/Player");
        _customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        HeartsContainer.SetMaxHearts(Player.MaxHealth);
        _customSignals.HealthChanged += HeartsContainer.UpdateHearts;
    }
}
