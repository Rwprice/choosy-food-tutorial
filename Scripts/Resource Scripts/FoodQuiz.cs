using ChoosyFoodTutorial.Dialogues.Scripts;
using ChoosyFoodTutorial.Scenes;
using Godot;

namespace ChoosyFoodTutorial.Scripts.Resource_Scripts;

public partial class FoodQuiz : Node3D
{
    [Export] private Dialogue StallDialogue { get; set; }
    [Export] private Dialogue CorrectDialogue { get; set; }
    [Export] private Dialogue IncorrectDialogue { get; set; }
    [Export] private NodePath CorrectFoodPath { get; set; }
    private Food _correctFood;
    
    private GameEvents _gameEvents;

    public override void _Ready()
    {
        _gameEvents = GetNode<GameEvents>("/root/GameEvents");
        _correctFood = GetNode<Food>(CorrectFoodPath);
    }

    private void OnDialogueTriggerBodyEntered(Node3D body)
    {
        _gameEvents.DelayDialogueInitiated(StallDialogue);
    }

    public void OnFoodChosen(Food food)
    {
        if (food == _correctFood)
        {
            _gameEvents.DelayDialogueInitiated(CorrectDialogue);
        }
        else
        {
            _gameEvents.DelayDialogueInitiated(IncorrectDialogue);
        }
    }
}