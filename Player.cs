using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 400;
	public Vector2 ScreenSize; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;
		if (Input.IsActionPressed("StrafeLeft"))
		{
			velocity.X -= 1;
		}
        if (Input.IsActionPressed("StrafeRight"))
        {
            velocity.X += 1;
        }

        if (Input.IsActionPressed("MoveDown"))
        {
            velocity.Y += 1;
        }

        if (Input.IsActionPressed("MoveUp"))
        {
            velocity.Y -= 1;
        }
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}
		Position += velocity * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
    }
}
