using ActionRPGTutorial.Player.PlayerDataModels;
using Godot;

namespace ActionRPGTutorial.GlobalTools
{
    internal static class AnimationTools
    {
        public static string GetDirection(Vector2 velocity)
        {
            var direction = WalkAnimations.WalkDown;

            switch (velocity.X)
            {
                case < 0:
                    direction = WalkAnimations.WalkLeft;
                    break;
                case > 0:
                    direction = WalkAnimations.WalkRight;
                    break;
                default:
                {
                    if (velocity.Y < 0)
                    {
                        direction = WalkAnimations.WalkUp;
                    }
                    break;
                }
            }

            return direction;
        }
    }
}
