using ActionRPGTutorial.Player;
using Godot;

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
