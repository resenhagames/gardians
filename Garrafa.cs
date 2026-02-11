using Godot;
using System;

public partial class Garrafa : Area2D
{
	// Usamos _PhysicsProcess para checar a colisão de forma constante e automática
	public override void _PhysicsProcess(double delta)
	{
		// Obtém a lista de corpos que estão dentro da área da garrafa
		var corpos = GetOverlappingBodies();

		foreach (Node2D corpo in corpos)
		{
			// Verifica se o corpo é o seu Player (CharacterBody2D)
			// Se o seu script do player se chamar 'Player', você pode usar: if (corpo is Player)
			if (corpo is CharacterBody2D)
			{
				GD.Print("Garrafa coletada!");
				QueueFree(); // Remove a garrafa da cena
				return; // Para o loop após coletar
			}
		}
	}
}
