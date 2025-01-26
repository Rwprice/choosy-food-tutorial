using Godot;

namespace ChoosyFoodTutorial;

public enum GameplayState
{
    OUT_OF_DIALOGUE,
    IN_DIALOGUE,
}

[GlobalClass]
public partial class GlobalState : Resource
{
    [Export]
    public GameplayState CurrentGameplayState { get; set; }
}