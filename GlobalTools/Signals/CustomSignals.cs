using Godot;

public partial class CustomSignals : Node
{
    [Signal]
    public delegate void DamagePlayerEventHandler(int damageAmount);

    [Signal]
    public delegate void HealthChangedEventHandler(int currentHealth);
}
