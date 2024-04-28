using ActionRPGTutorial.Enums;
using ActionRPGTutorial.GlobalTools;
using Godot;
using Godot.Collections;
using Array = Godot.Collections.Array;

namespace ActionRPGTutorial.Player;

public partial class Player : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 35;

    [Export] 
    public int MaxHealth { get; set; } = 3;
    public int CurrentHealth { get; set; }

	private AnimationPlayer _animationPlayer = new();

	private Area2D _hurtBox;
	/*
	 * Overrides
	 */
	public override void _Ready()
    {
        CurrentHealth = MaxHealth;
		_animationPlayer = GetNode<AnimationPlayer>("PlayerAnimations");
		_hurtBox = GetNode<Area2D>("HurtBox");
		_hurtBox.AreaEntered += (AreaEnteredEventHandler) => OnHurtBoxAreaEntered(_hurtBox.GetOverlappingAreas());
	}
	public override void _PhysicsProcess(double delta)
	{
		HandleInput();
		MoveAndSlide();
		HandleCollision();
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

	public void HandleCollision()
	{
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var collision = GetSlideCollision(i);
			var collider = collision.GetCollider();
			var colliderDict = collider.GetPropertyList();
			//GD.Print(collider.Get("name"));
		}
	}

	private void OnHurtBoxAreaEntered(Array<Area2D> areas)
	{
		foreach (var area in areas)
		{
			if (area.Name == "HitBox")
            {
                DecreaseHealth(1);
				GD.Print(CurrentHealth);
            }
		}

		//if (area.Name == "HitBox")
		//{
		//	GD.Print(area.GetParent().Name);
		//}
	}

    private void DecreaseHealth(int i)
    {
        CurrentHealth -= i;
        if (CurrentHealth < 0)
        {
            CurrentHealth = MaxHealth;
        }
    }
}


//private void _on_hurt_box_area_entered(Area2D area)
//{
//	if (area.Name == "HitBox")
//	{
//		GD.Print(area.GetParent().Name);
//	}
//}


//private void OnHurtBoxAreaEntered(Area2D area)
//{
//	// Replace with function body.
//}
