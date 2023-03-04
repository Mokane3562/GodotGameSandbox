using Godot;
using System;

public partial class MainMenu : Control
{
	
	private void _on_PlayGameButton_pressed()
	{
		GetNode<Control>("Sign").Visible = false;
		GetNode<Control>("LevelSelector").Visible = true;
	}

	private void _on_LoadGameButton_pressed()
	{
		GD.Print(new NotImplementedException(nameof(_on_LoadGameButton_pressed)));
	}
	
	private void _on_CreditsButton_pressed()
	{
		GD.Print(new NotImplementedException(nameof(_on_CreditsButton_pressed)));
	}

	private void _on_ExitButton_pressed()
	{
		GetTree().Quit(0);
	}
	
	private void _on_BackButton_pressed()
	{
		GetNode<Control>("Sign").Visible = true;
		GetNode<Control>("LevelSelector").Visible = false;
	}
	
	private void _on_IsoTownButton_pressed()
	{
		GetTree().ChangeSceneToFile("res://levels/iso_town/IsoTown.tscn");
	}

	private void _on_TownButton_pressed()
	{
		GetTree().ChangeSceneToFile("res://levels/town/Town.tscn");
	}
}
