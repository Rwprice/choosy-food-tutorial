using System;
using ChoosyFoodTutorial.Dialogues.Scripts;
using Godot;

namespace ChoosyFoodTutorial;

public partial class FoodQuiz : Node3D
{
    [Export] 
    private Dialogue StallDialogue { get; set; }
    
    private GameEvents _gameEvents;

    public override void _Ready()
    {
        _gameEvents = GetNode<GameEvents>("/root/GameEvents");
    }

    public void OnDialogueTriggerBodyEntered(Node3D body)
    {
        _gameEvents.EmitSignal(nameof(GameEvents.SignalName.DialogueInitiated), StallDialogue);
    }
}