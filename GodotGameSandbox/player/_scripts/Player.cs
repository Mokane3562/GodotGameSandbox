using Godot;

public partial class Player : CharacterBody2D
{
	[Export] private int _movementSpeed = 256;

	private AnimationNodeStateMachinePlayback _animationState;
	private AnimationTree _animationTree;

	public override void _Ready()
	{
		_animationTree = GetNode<AnimationTree>("AnimationTree");
		_animationState = (AnimationNodeStateMachinePlayback) _animationTree.Get("parameters/playback");
	}

	public override void _PhysicsProcess(double delta)
	{
		var isometric = true;
		var inputVector = Vector2.Zero;
		inputVector.X = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		inputVector.Y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
		inputVector = inputVector.Normalized();
		if (isometric)  inputVector.Y /= 2;
		Velocity = inputVector * _movementSpeed;
		AnimatePlayerMovement();
		MoveAndSlide();
	}

	// private static Vector2 GetPlayerInputVector(bool isometric=false)
	// {
	// 	var inputVector = Vector2.Zero;
	// 	inputVector.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
	// 	inputVector.y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
	// 	inputVector = inputVector.Normalized();
	// 	if (isometric) inputVector.y /= 2;
	// 	return inputVector;
	// }

	private void AnimatePlayerMovement()
	{
		if (Velocity != Vector2.Zero)
		{
			_animationTree.Set("parameters/Idle/blend_position", Velocity);
			_animationTree.Set("parameters/Run/blend_position", Velocity);
			_animationState.Travel("Run");
		}
		else
		{
			_animationState.Travel("Idle");
		}
	}
}
