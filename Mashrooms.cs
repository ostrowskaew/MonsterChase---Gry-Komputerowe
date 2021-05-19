using Godot;
using System;

public class Mashrooms : KinematicBody2D
{
	
	public override void _Ready()
	{
		
	}

	void _on_Area2D_body_entered(PhysicsBody2D body)
{
	if(body.IsInGroup("Player")) {
		  QueueFree();
	  }
}

 
}


 
