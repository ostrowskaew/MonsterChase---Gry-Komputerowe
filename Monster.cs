using Godot;
using System;

public class Monster : KinematicBody2D
{
	private float moveSpeed = 600f;
	private float gravity = 20f;
	private Vector2 movement;
	public bool moveLeft;
	public bool isGhost = false;
	private float min_X = -4300f, max_X = 5610f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(this.Name == "Ghost") {
	  isGhost = true;
	}
	if(moveLeft) {
	  moveSpeed *= -1f;
	  GetNode<AnimatedSprite>("Animation").FlipH = true;
	}
	}


  public override void _PhysicsProcess(float delta)
  {
	  if(!isGhost)
		  movement.y += gravity;

	  movement.x = moveSpeed;
	  movement = MoveAndSlide(movement);
	if (Position.x > max_X || Position.x < min_X)
	QueueFree();

  }
}
