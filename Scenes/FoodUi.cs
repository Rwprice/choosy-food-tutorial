using Godot;

namespace ChoosyFoodTutorial.Scenes;

public partial class FoodUi : Control
{
	private Label _foodLabel;
	private GameEvents _gameEvents;
	
	public override void _Ready()
	{
		_gameEvents = GetNode<GameEvents>("/root/GameEvents");
		_gameEvents.Connect(nameof(GameEvents.SignalName.FoodHovered),
			Callable.From((Food food) => OnFoodHovered(food)));
		_gameEvents.Connect(nameof(GameEvents.SignalName.FoodUnhovered),
			Callable.From(OnFoodUnhovered));
		
		foreach (var child in GetChildren())
		{
			if (child is Label label)
			{
				_foodLabel = label;
			}
		}
		
		Visible = false;
	}

	private void OnFoodHovered(Food food)
	{
		_foodLabel.Text = food.FoodName;
		Visible = true;
	}

	private void OnFoodUnhovered()
	{
		Visible = false;
	}
}
