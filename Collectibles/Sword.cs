using Godot;

namespace ActionRPGTutorial.Collectibles;

public partial class Sword : Collectible
{
    private AnimationPlayer PickupAnimation = new();

    public override void _Ready()
    {
        PickupAnimation = GetNode<AnimationPlayer>("PickupAnimation");
        PickupAnimation.AnimationFinished += (AnimationFinishedEventHandler) => OnPickupAnimationAnimationFinished();
    }

    public new void Collect()
    {
        PickupAnimation.Play("Spin");
    }

    public void OnPickupAnimationAnimationFinished()
    {
        base.Collect();
    }
}