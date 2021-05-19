using Godot;
using System;

public class Gameplay : Node
{
	[Export]
	private PackedScene greenZombie, redZombie, ghost;

	private Vector2 spawn_Left = new Vector2(-4200f,541f);
	private Vector2 spawn_Right = new Vector2(5600f,541f);
	private Timer restart;
	public int points = 0;
	RichTextLabel label; 
	
	public override void _Ready()
	
	{
		restart = GetNode<Timer>("Restart");
	}

	void _on_Monster_Spawn() {
		
		int randEnemy = new Random().Next(0, 3);
		Monster newMonster = null;
		
		switch(randEnemy) {
			case 0:
				newMonster = greenZombie.Instance() as Monster;
				break;

			case 1:
				newMonster = redZombie.Instance() as Monster;
				break;

			case 2:
				newMonster = ghost.Instance() as Monster;
				break;
		}

		Vector2 temp;

		if(new Random().Next(0,2) > 0) {
			temp = spawn_Right;
			newMonster.moveLeft = true;

		} else {
			temp = spawn_Left;
		}
		newMonster.SetPosition(temp);
		AddChild(newMonster);
	}
	  
	public void playerDied() {
		restart.Start();
	} 

	void _on_Player_Died() {
		GetTree().ReloadCurrentScene();
	}
  
	public void pumpkinCollected() {
		points ++;
		GetNode<AudioStreamPlayer2D>("CollectSound").Play();

	}
}




