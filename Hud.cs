using Godot;

public partial class HUD : Control
{
	private TextureRect heart1;
	private TextureRect heart2;
	private TextureRect heart3;
	private Label bottlesLabel;
	
	private int life = 3;
	private int bottles = 0;
	
	public override void _Ready()
	{
		// Pega referências
		heart1 = GetNode<TextureRect>("LifeContainer/Heart1");
		heart2 = GetNode<TextureRect>("LifeContainer/Heart2");
		heart3 = GetNode<TextureRect>("LifeContainer/Heart3");
		bottlesLabel = GetNode<Label>("BottlesLabel");
		
		UpdateHUD();
	}
	
	private void UpdateHUD()
	{
		// Atualiza garrafas
		bottlesLabel.Text = "Garrafas: " + bottles;
		
		// Atualiza corações (mostra/esconde baseado na vida)
		heart1.Visible = life >= 1;
		heart2.Visible = life >= 2;
		heart3.Visible = life >= 3;
		
		// Ou, se preferir deixar meio transparente quando perdido:
		// heart1.Modulate = life >= 1 ? Colors.White : new Color(1, 1, 1, 0.3f);
		// heart2.Modulate = life >= 2 ? Colors.White : new Color(1, 1, 1, 0.3f);
		// heart3.Modulate = life >= 3 ? Colors.White : new Color(1, 1, 1, 0.3f);
	}
	
	public void AddBottle()
	{
		bottles++;
		UpdateHUD();
		GD.Print("Garrafas coletadas: " + bottles);
	}
	
	public void TakeDamage()
	{
		life--;
		if (life < 0) life = 0;
		UpdateHUD();
		
		if (life <= 0)
		{
			GameOver();
		}
	}
	
	public void Heal()
	{
		if (life < 3)
		{
			life++;
			UpdateHUD();
		}
	}
	
	private void GameOver()
	{
		GD.Print("GAME OVER!");
		// Aqui você pode adicionar tela de game over
	}
	
	public int GetLife() { return life; }
	public int GetBottles() { return bottles; }
}
