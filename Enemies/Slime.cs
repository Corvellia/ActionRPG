using ActionRPGTutorial.GlobalTools;
using Godot;

namespace ActionRPGTutorial.Enemies;

public partial class Slime : CharacterBody2D
{
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private AnimationPlayer? _animationPlayer;
    private Area2D? _hurtBox;
    private static Area2D? _hitBox;
    private bool _isDead { get; set; }
    [Export]
    public int Speed { get; set; } = 15;

    [Export]
    public double Limit { get; set; } = 0.5;

    [Export]
    public Marker2D? Marker { get; set; }
    
    //[Signal]
    //public delegate void OnHurtBoxAreaEnteredEventHandler();
    /*
	 * Overrides
	 */
    public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>("SlimeAnimations");
        _hurtBox = GetNode<Area2D>("HurtBox");
        _hitBox = GetNode<Area2D>("HitBox");
        _startPosition = Position;
        _hurtBox.AreaEntered += OnHurtBoxAreaEntered;
        //This was used to move 3 tiles down and 3 tiles up rather than moving to a marker position.Keeping for reference
        //_endPosition = _startPosition + new Vector2(0, 3 * 16);  
        if (Marker != null)
        {
            _endPosition = Marker.GlobalPosition;
        }
    }

    private void _hurtBox_AreaEntered(Area2D area)
    {
        throw new System.NotImplementedException();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_isDead)
        {
            return;
        }
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
        var direction = AnimationTools.GetDirection(Velocity);
        _animationPlayer?.Play(direction);
    }

    private void OnHurtBoxAreaEntered(Area2D area)
    {
        if (area == _hitBox)
        {
            return;
        }
        _animationPlayer?.Play("Death");
        _isDead = true;
        _hitBox?.SetDeferred(Godot.Area2D.PropertyName.Monitorable, false);
        if (_animationPlayer != null)
        {
            _animationPlayer.AnimationFinished +=  (AnimationFinishedEventHandler) => DeathAnimationFinished();
        }
    }

    private void DeathAnimationFinished()
    {
        QueueFree();
    }
}
