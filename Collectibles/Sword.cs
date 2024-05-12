using System.Transactions;
using ActionRPGTutorial;
using Godot;

public partial class Sword : Collectible
{
    public AnimationPlayer PickupAnimation = new();

    private Test testing;
    private delegate void Test();
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
