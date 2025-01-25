using ChoosyFoodTutorial.Dialogues.Scripts;
using Godot;

namespace ChoosyFoodTutorial;

public partial class GameEvents : Node
{
    [Signal]
    public delegate void DialogueInitiatedEventHandler(Dialogue dialogue);
}