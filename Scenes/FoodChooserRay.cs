using Godot;

namespace ChoosyFoodTutorial.Scenes;

public partial class FoodChooserRay : RayCast3D
{
    private GameEvents _gameEvents;
    private bool _isMouseOver;

    public override void _Ready()
    {
        _gameEvents = GetNode<GameEvents>("/root/GameEvents");
        _isMouseOver = false;
    }

    public override void _Input(InputEvent @event)
    {
        var collider = GetCollider();
        if (collider != null)
        {
            var owner = (GodotObject)collider.Get("owner");
            if (owner is Food food)
            {
                if (!_isMouseOver)
                {
                    _gameEvents.EmitSignal(nameof(GameEvents.SignalName.FoodHovered), food);
                    _isMouseOver = true;
                }
                
                if (Input.IsActionJustPressed("Select_Food"))
                {
                    _gameEvents.EmitSignal(nameof(GameEvents.SignalName.FoodSelected), food);
                }
            }
        }
        else if (_isMouseOver)
        {
            _gameEvents.EmitSignal(nameof(GameEvents.SignalName.FoodUnhovered));
            _isMouseOver = false;
        }
    }
}