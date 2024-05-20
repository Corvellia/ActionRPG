using Godot;

namespace ActionRPGTutorial.Collectibles;

public partial class Sword : Collectible
{
    private AnimationPlayer PickupAnimation = new();

    public override void _Ready()
    {
        PickupAnimation = GetNode<AnimationPlayer>("PickupAnimation");
    }

    public new void Collect(Inventory.Inventory inventory)
    {
        PickupAnimation.Play("Spin");
        PickupAnimation.AnimationFinished += (AnimationFinishedEventHandler) => OnPickupAnimationAnimationFinished(inventory);
    }

    public void OnPickupAnimationAnimationFinished(Inventory.Inventory inventory)
    {
        base.Collect(inventory);
    }
}