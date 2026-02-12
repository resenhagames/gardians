using Godot;
using System;

public partial class Lixotech : CharacterBody2D
{
	[Export] public float Speed = 150.0f;
	[Export] public float PatrolDistance = 300.0f;
	[Export] public float FloatAmplitude = 10.0f;
	[Export] public float FloatSpeed = 2.0f;
	
	private AnimatedSprite2D animatedSprite;
	private float startX;
	private float startY;
	private int direction = 1;
	private float time = 0f;
	
	public override void _Ready()
	{
		GD.Print("=== INIMIGO INICIADO ===");
		
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
		if (animatedSprite == null)
		{
			GD.PrintErr("ERRO: AnimatedSprite2D não encontrado!");
		}
		else
		{
			GD.Print("AnimatedSprite2D encontrado!");
			// Começa com idle
			if (animatedSprite.SpriteFrames != null && animatedSprite.SpriteFrames.HasAnimation("idle"))
			{
				animatedSprite.Play("idle");
			}
		}
		
		startX = Position.X;
		startY = Position.Y;
		GD.Print("Posição inicial: " + Position);
	}
	
	public override void _PhysicsProcess(double delta)
	{
		time += (float)delta;
		
		// Movimento horizontal
		float moveX = direction * Speed * (float)delta;
		
		// Efeito flutuante
		float floatY = Mathf.Sin(time * FloatSpeed) * FloatAmplitude;
		
		// Atualiza posição
		Position = new Vector2(Position.X + moveX, startY + floatY);
		
		// Vira o sprite
		if (animatedSprite != null)
		{
			animatedSprite.FlipH = direction > 0;
			
			// Alterna animações
			if (Mathf.Abs(moveX) > 0.01f)
			{
				if (animatedSprite.SpriteFrames.HasAnimation("walk") && animatedSprite.Animation != "walk")
				{
					animatedSprite.Play("walk");
				}
			}
			else
			{
				if (animatedSprite.SpriteFrames.HasAnimation("idle") && animatedSprite.Animation != "idle")
				{
					animatedSprite.Play("idle");
				}
			}
		}
		
		// Verifica limite da patrulha
		float distanceFromStart = Position.X - startX;
		if (Mathf.Abs(distanceFromStart) > PatrolDistance)
		{
			direction *= -1;
		}
	}
}
