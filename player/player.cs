using Godot;

namespace ActionRPGTutorial.Player;

public partial class Player : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 35;
	public void HandleInput()
	{
		var moveDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Velocity = moveDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		HandleInput();
		MoveAndSlide();
	}
}
