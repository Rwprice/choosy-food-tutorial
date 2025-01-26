using ChoosyFoodTutorial.Dialogues.Scripts;
using ChoosyFoodTutorial.Scenes;
using Godot;

namespace ChoosyFoodTutorial.Scripts.Resource_Scripts;

public partial class GameEvents : Node
{
    [Signal]
    public delegate void DialogueInitiatedEventHandler(Dialogue dialogue);
    
    [Signal]
    public delegate void DialogueEndedEventHandler();
    
    [Signal]
    public delegate void FoodHoveredEventHandler(Food food);
    
    [Signal]
    public delegate void FoodUnhoveredEventHandler();
    
    [Signal]
    public delegate void FoodSelectedEventHandler(Food food);

    public void DelayDialogueInitiated(Dialogue dialogue)
    {
        CallDeferred(nameof(EmitDialogueInitiated), dialogue);
    }

    public void DelayDialogueEnded()
    {
        CallDeferred(nameof(EmitDialogueEnded));
    }

    private void EmitDialogueInitiated(Dialogue dialogue)
    {
        EmitSignal(nameof(DialogueInitiated), dialogue);
    }

    private void EmitDialogueEnded()
    {
        EmitSignal(nameof(DialogueEnded));
    }
}