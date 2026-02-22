using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public float WalkSpeed = 300.0f;
	[Export] public float RunSpeed = 500.0f;
	[Export] public float JumpVelocity = -520.0f;
	[Export] public float FallAnimationDelay = 0.3f;

	private AnimatedSprite2D animatedSprite;
	private float currentSpeed;
	private float timeInAir = 0f;

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		bool isRunning = Input.IsActionPressed("ui_shift");
		currentSpeed = isRunning ? RunSpeed : WalkSpeed;

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
			timeInAir += (float)delta;
		}
		else
		{
			timeInAir = 0f;
		}

		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if (direction.X != 0)
		{
			velocity.X = direction.X * currentSpeed;
			animatedSprite.FlipH = direction.X < 0;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, currentSpeed);
		}

		UpdateAnimation(direction.X, isRunning);
		Velocity = velocity;
		MoveAndSlide();
	}

	private void UpdateAnimation(float directionX, bool isRunning)
	{
		if (!IsOnFloor())
		{
			if (Velocity.Y < 0) animatedSprite.Play("jump");
			else if (timeInAir >= FallAnimationDelay) animatedSprite.Play("fall");
		}
		else
		{
			if (directionX != 0) animatedSprite.Play(isRunning ? "run" : "walk");
			else animatedSprite.Play("idle");
		}
	}
}
