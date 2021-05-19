using Godot;
using System;

public class Player : KinematicBody2D
{
	private Vector2 movement = Vector2.Zero;
	private float move_Speed = 400f;
	private float gravity = 18f;
	private float jump_Force = -900f;
	private Vector2 up_Dir = Vector2.Up;
	private AnimatedSprite animation;
	private float min_Y = 1003;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animation = GetNode<AnimatedSprite>("Animation");
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	 public override void _PhysicsProcess(float delta)
  {
	  PlayerMovement();
	  if (Position.y > min_Y) { 
		  GetParent<Gameplay>().playerDied();
		  QueueFree();
	  }
		
  }

  void PlayerMovement() 
  {
	  movement.y += gravity;
	  if(Input.IsActionPressed("move_right")) {
		  
		  movement.x = move_Speed;
		  AnimateMovement(true, true);

	  } else if (Input.IsActionPressed("move_left")) {

		  movement.x = -move_Speed;
		  AnimateMovement(true, false);
		  

	  } else {
		  movement.x = 0f;
		  AnimateMovement(false, true);
		  
	  } 
	  
	  if(IsOnFloor()) {
		  if(Input.IsActionJustPressed("jump")) {
			  movement.y = jump_Force;
			  GetNode<AudioStreamPlayer2D>("JumpSound").Play();
		  }
	  }
	  movement = MoveAndSlide(movement, up_Dir);

  }


  void AnimateMovement(bool moving, bool moveRight) {
	  if(moving) {
		  animation.Play("Walk");

		  if(moveRight) {
			animation.FlipH = false;
		  } else {
			animation.FlipH = true;
		  }
	  }
	  else {
		  animation.Play("Idle");
	  }
  }
	void _on_body_entered(PhysicsBody2D body) {
	  if(body.IsInGroup("Enemy")) {
		  GetParent<Gameplay>().playerDied();
		  QueueFree();

	  }

	  if(body.IsInGroup("Pumpkin")) {
		  GetParent<Gameplay>().pumpkinCollected();
		  
	  }
  	}

}
