using Godot;
using System;

public partial class Pause : Control
{
	
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("pause"))
		{
			TogglePaused();
		}
	}

	private void _on_ResumeButton_pressed()
	{
		TogglePaused();
	}
	
	private void _on_QuitButton_pressed()
	{
		GetTree().Quit(0);
	}
	
	private void TogglePaused()
	{
		var newPauseState = !GetTree().Paused;
		GetTree().Paused = newPauseState;
		Visible = newPauseState;
	}
}
