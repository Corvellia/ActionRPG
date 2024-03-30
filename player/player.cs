using System;
using System.Runtime.CompilerServices;
using ActionRPGTutorial.Player.PlayerDataModels;
using Godot;

namespace ActionRPGTutorial.Player;

public partial class Player : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 35;

	private AnimationPlayer _animationPlayer = new();

	/*
	 * Overrides
	 */
	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("PlayerAnimations");
	}
	public override void _PhysicsProcess(double delta)
	{
		HandleInput();
		MoveAndSlide();
	}

	/*
	 * Custom Methods
	 */
	public void HandleInput()
	{
		var moveDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Velocity = moveDirection * Speed;
		UpdateAnimation();
	}

	public void UpdateAnimation()
	{

		if (Velocity.Length() == 0 && _animationPlayer.IsPlaying())
		{
			_animationPlayer.Stop();
			return;
		}

		var direction = WalkAnimations.WalkDown;

		switch (Velocity.X)
		{
			case < 0:
				direction = WalkAnimations.WalkLeft;
				break;
			case > 0:
				direction = WalkAnimations.WalkRight;
				break;
			default:
			{
				if (Velocity.Y < 0)
				{
					direction = WalkAnimations.WalkUp;
				}
				break;
			}
		}
		_animationPlayer.Play(direction);
	}
}
