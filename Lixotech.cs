using Godot;

public partial class lixotech : CharacterBody2D
{
	private float speed = 100f;
	
	public override void _Ready()
	{
		GD.Print("INIMIGO READY!");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		// Move para a direita constantemente
		Position += new Vector2(speed * (float)delta, 0);
		GD.Print("Posição do inimigo: " + Position.X);
	}
}
