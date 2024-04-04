using ActionRPGTutorial.Player.PlayerDataModels;
using Godot;

namespace ActionRPGTutorial.Enemies;

public partial class Slime : CharacterBody2D
{
	private Vector2 _startPosition;
	private Vector2 _endPosition;
	private AnimatedSprite2D _animatedSprite;

	[Export] 
	public int Speed { get; set; } = 15;

	[Export] 
	public double Limit = 0.5;

	[Export]
	public Marker2D Marker { get; set; }
	/*
	 * Overrides
	 */
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("SlimeAnimatedSprite");
		_startPosition = Position;
		//_endPosition = _startPosition + new Vector2(0, 3 * 16);
		_endPosition = Marker.GlobalPosition;
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateVelocity();
		MoveAndSlide();
		UpdateAnimation();
	}

	/*
	 * Custom Methods
	 */
	public void UpdateVelocity()
	{
		var moveDirection = _endPosition - Position;

		if (moveDirection.Length() < Limit)
		{
			Position = _endPosition;
			moveDirection = Vector2.Zero;
			ChangeDirection();
		}
		Velocity = moveDirection.Normalized() * Speed;
	}

	public void ChangeDirection()
	{
		(_endPosition, _startPosition) = (_startPosition, _endPosition);
	}

	public void UpdateAnimation()
	{
		var direction = WalkAnimations.WalkDown;
		if (Velocity.Y < 0)
		{
			direction = WalkAnimations.WalkUp;
		}

		_animatedSprite.Play(direction);
	}
}
