using ActionRPGTutorial.Player.PlayerDataModels;
using Godot;

namespace ActionRPGTutorial.GlobalTools
{
    internal static class AnimationTools
    {
        public static string? CurrentAttackAnimation { get; set; }
        public static string GetDirection(Vector2 velocity)
        {
            var direction = WalkAnimations.WalkDown;
            CurrentAttackAnimation = AttackAnimations.AttackDown;
            switch (velocity.X)
            {
                case < 0:
                    direction = WalkAnimations.WalkLeft;
                    CurrentAttackAnimation = AttackAnimations.AttackLeft;
                    break;
                case > 0:
                    direction = WalkAnimations.WalkRight;
                    CurrentAttackAnimation = AttackAnimations.AttackRight;
                    break;
                default:
                    {
                        if (velocity.Y < 0)
                        {
                            direction = WalkAnimations.WalkUp;
                            CurrentAttackAnimation = AttackAnimations.AttackUp;
                        }
                        break;
                    }
            }

            return direction;
        }
    }

    internal static class AttackAnimations
    {
        public static string? AttackDown = "AttackDown";
        public static string? AttackLeft = "AttackLeft";
        public static string? AttackRight = "AttackRight";
        public static string? AttackUp = "AttackUp";

    }
}
