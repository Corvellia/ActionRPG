using Godot;
using System;

public partial class player : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 35;
	public void handleInput()
	{
		var moveDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Velocity = moveDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		handleInput();
		MoveAndSlide();
	}
}
