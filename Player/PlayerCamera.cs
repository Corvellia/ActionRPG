using ActionRPGTutorial.ExtensionMethods;
using Godot;

namespace ActionRPGTutorial.Player;

public partial class PlayerCamera : Camera2D
{
    [Export]
    private TileMap _tileMap;
    private Camera2D _camera;

    private Camera2D _otherCamera;
    /*
	 * Overrides
	 */
    public override void _Ready()
    {
        var worldSizePixels = _tileMap.GetWorldSize();
        LimitRight = worldSizePixels.X;
        //Going to leave this commented out so I can reference it for debugging purposes later
        //GD.Print($"{worldSizePixels.X.ToString()}");
        LimitBottom = worldSizePixels.Y;
        var nodePath = new NodePath("../Player/PlayerCamera");
        _camera = GetNode<Camera2D>("../../Player/PlayerCamera");
        _otherCamera = GetNode<Camera2D>("../../Slime/SlimeCamera");
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionJustPressed("CameraSwap"))
        {
            SwapCameras();
        }
    }

    /*
	 * Custom methods
	 */
    public void SwapCameras()
    {
        _otherCamera.MakeCurrent();
        (_camera, _otherCamera) = (_otherCamera, _camera);
    }
}
