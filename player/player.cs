using ActionRPGTutorial.Enums;
using ActionRPGTutorial.GlobalTools;
using ActionRPGTutorial.Player.PlayerDataModels;
using Godot;
using Array = Godot.Collections.Array;

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
	
		if (Input.IsActionPressed(CustomInputMaps.InputMap(CustomInputMapEnum.SPRINT)))
		{
			Velocity *= 2;
		}

		var testData = new Array();

		UpdateAnimation();
	}

	public void UpdateAnimation()
	{

		if (Velocity.Length() == 0 && _animationPlayer.IsPlaying())
		{
			_animationPlayer.Stop();
			return;
		}

        var direction = AnimationTools.GetDirection(Velocity);
		_animationPlayer.Play(direction);
	}
}
