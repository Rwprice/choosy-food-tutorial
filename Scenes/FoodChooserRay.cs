using Godot;

namespace ChoosyFoodTutorial.Scenes;

public partial class FoodChooserRay : RayCast3D
{
    [Export] private GlobalState GlobalState { get; set; }
    
    private Scripts.Resource_Scripts.GameEvents _gameEvents;
    private bool _isMouseOver;

    public override void _Ready()
    {
        _gameEvents = GetNode<Scripts.Resource_Scripts.GameEvents>("/root/GameEvents");
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
                    _gameEvents.EmitSignal(nameof(Scripts.Resource_Scripts.GameEvents.SignalName.FoodHovered), food);
                    _isMouseOver = true;
                }
                
                if (Input.IsActionJustPressed("Select_Food") && GlobalState.CurrentGameplayState == GameplayState.OUT_OF_DIALOGUE)
                {
                    _gameEvents.EmitSignal(nameof(Scripts.Resource_Scripts.GameEvents.SignalName.FoodSelected), food);
                }
            }
        }
        else if (_isMouseOver)
        {
            _gameEvents.EmitSignal(nameof(Scripts.Resource_Scripts.GameEvents.SignalName.FoodUnhovered));
            _isMouseOver = false;
        }
    }
}