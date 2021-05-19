using Godot;
using System;

public class Collectable : KinematicBody2D
{

	void _on_body_entered(PhysicsBody2D body)
	{
	if(body.IsInGroup("Player")) {
		  QueueFree();
	  }
	}
}



