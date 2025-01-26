using Godot;

namespace ChoosyFoodTutorial.Scenes;

public partial class Food : Node3D
{
	[Export] 
	public string FoodName { get; private set; }

	[Export] 
	public float SpinSpeed = 4.0f;
	
	private GameEvents _gameEvents;
	private SpotLight3D _spotlight;
	private Node3D _foodMesh;

	private bool _isFocused;

	public override void _Ready()
	{
		_gameEvents = GetNode<GameEvents>("/root/GameEvents");
		_gameEvents.Connect(nameof(GameEvents.SignalName.FoodHovered), 
			Callable.From((Food food) => OnFoodHovered(food)));
		_gameEvents.Connect(nameof(GameEvents.SignalName.FoodUnhovered), 
			Callable.From(OnFoodUnhovered));
		
		_spotlight = GetNode<SpotLight3D>("Spotlight");
		_spotlight.Visible = false;
		
		foreach (var child in GetChildren())
		{
			if (child is Node3D foodMesh)
			{
				_foodMesh = foodMesh;
			}
		}
		
		_isFocused = false;
	}

	public override void _Process(double delta)
	{
		if (_isFocused)
		{
			_foodMesh.RotateY(SpinSpeed * (float)delta);
		}
	}

	private void OnFoodHovered(Food food)
	{
		if (this != food) return;
		_spotlight.Visible = true;
		_isFocused = true;
	}

	private void OnFoodUnhovered()
	{
		_spotlight.Visible = false;
		_isFocused = false;
	}
}
