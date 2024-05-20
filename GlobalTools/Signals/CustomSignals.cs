using Godot;

namespace ActionRPGTutorial.GlobalTools.Signals;

public partial class CustomSignals : Node
{
    [Signal]
    public delegate void DamagePlayerEventHandler(int damageAmount);

    [Signal]
    public delegate void HealthChangedEventHandler(int currentHealth);

    [Signal]
    public delegate void OpenedEventHandler();

    [Signal]
    public delegate void ClosedEventHandler();

    [Signal]
    public delegate void InventoryUpdatedEventHandler();
}