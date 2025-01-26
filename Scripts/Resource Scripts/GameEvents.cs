using ChoosyFoodTutorial.Dialogues.Scripts;
using ChoosyFoodTutorial.Scenes;
using Godot;

namespace ChoosyFoodTutorial;

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
}