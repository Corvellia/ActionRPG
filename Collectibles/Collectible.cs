using Godot;

namespace ActionRPGTutorial;

public partial class Collectible : Area2D
{
    public virtual void Collect()
    {
        QueueFree();
    }
}
