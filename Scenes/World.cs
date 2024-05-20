using Godot;

namespace ActionRPGTutorial.Scenes;

public partial class World : Node2D
{
    private UI.HeartsContainer? _heartsContainer;
    private Player.Player? _player;
    private GlobalTools.Signals.CustomSignals? _customSignals;

    public override void _Ready()
    {
        _heartsContainer = GetNode<UI.HeartsContainer>("WorldUi/HeartsContainer");
        _player = GetNode<Player.Player>("TileMap/Player");
        _customSignals = GetNode<GlobalTools.Signals.CustomSignals>("/root/CustomSignals");
        _heartsContainer.SetMaxHearts(_player.MaxHealth);
        _customSignals.HealthChanged += _heartsContainer.UpdateHearts;
        _customSignals.Opened += OnInventoryUiOpened;
        _customSignals.Closed += OnInventoryUiClosed;
    }

    public void OnInventoryUiClosed()
    {
        GetTree().Paused = false;
    }

    public void OnInventoryUiOpened()
    {
        GetTree().Paused = true;
    }
}