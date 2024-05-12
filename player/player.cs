using ActionRPGTutorial.Enums;
using ActionRPGTutorial.GlobalTools;
using Godot;
using Godot.Collections;
using System.Collections.Generic;
using Array = Godot.Collections.Array;

namespace ActionRPGTutorial.Player;

public partial class Player : CharacterBody2D
{
    [Export]
    public int Speed { get; set; } = 35;

    [Export]
    public int MaxHealth { get; set; } = 3;

    [Export] public int KnockBackPower = 500;
    public int CurrentHealth { get; set; }

    private AnimationPlayer _effectsAnimation = new();
    private AnimationPlayer _animationPlayer = new();
    private Area2D _hurtBox;
    private CustomSignals _customSignals;
    private Timer _timer;
    private bool _isHurt;
    private List<Area2D> _enemyCollisions = new();
    /*
	 * Overrides
	 */
    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
        _animationPlayer = GetNode<AnimationPlayer>("PlayerAnimations");
        _effectsAnimation = GetNode<AnimationPlayer>("EffectsAnimations");
        _timer = GetNode<Timer>("PlayerHurtTimer");
        _hurtBox = GetNode<Area2D>("HurtBox");
        _customSignals = GetNode<CustomSignals>("/root/CustomSignals"); //root because we set it in autoload
        /*
         * Leaving the hurtbox event handling code here for future reference.  Instead of using event handling here, I instead am calling the _hurtBox.GetOverlappingAreas in the physicsProcess.
         */
        _hurtBox.AreaEntered += (AreaEnteredEventHandler) => OnHurtBoxAreaEntered(_hurtBox.GetOverlappingAreas());
        //_hurtBox.AreaExited += (AreaExitedEventHandler) => OnHurtBoxAreaExited(_hurtBox.GetOverlappingAreas());
        _customSignals.DamagePlayer += HandleDamagePlayer; //Keeping this code as an example of another way to handle incoming damage via signals.
        _timer.Timeout += TimerTimeout;

        _effectsAnimation.Play("RESET");
    }

    private void HandleDamagePlayer(int damageamount)
    {
        CurrentHealth -= damageamount;
    }

    public override void _PhysicsProcess(double delta)
    {
        HandleInput();
        MoveAndSlide();
        HandleCollision();

        if (!_isHurt)
        {
            foreach (var area in _hurtBox.GetOverlappingAreas())
            {
                if (area.Name == "HitBox")
                {
                    DecreaseHealth(1, area);
                }
            }
        }
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
            //if (area.Name == "HitBox")
            //{
            //    _enemyCollisions.Add(area);
            //}
            if (area.HasMethod("Collect"))
            {
                area.Call("Collect");
            }
        }


        //if (area.Name == "HitBox")
        //{
        //	GD.Print(area.GetParent().Name);
        //}
    }

    private void OnHurtBoxAreaExited(Array<Area2D> areas)
    {
        //_enemyCollisions = areas.ToList();
    }

    private async void DecreaseHealth(int i, Area2D area)
    {
        CurrentHealth -= i;
        if (CurrentHealth < 0)
        {
            CurrentHealth = MaxHealth;
        }
        _customSignals.EmitSignal(nameof(CustomSignals.HealthChanged), CurrentHealth);
        CharacterBody2D characterBody = area.GetParent() as CharacterBody2D;
        if (characterBody != null)
        {
            Knockback(characterBody.Velocity);
            _effectsAnimation.Play("HurtBlinkAnimation");
            _timer.Start();
            _isHurt = true;
        }
    }

    private void TimerTimeout()
    {
        _effectsAnimation.Play("RESET");
        _isHurt = false;
        _timer.Stop();
    }

    private void Knockback(Vector2 enemyVelocity)
    {
        var knockbackDirection = (enemyVelocity - Velocity).Normalized() * KnockBackPower;
        Velocity = knockbackDirection;
        MoveAndSlide();
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
