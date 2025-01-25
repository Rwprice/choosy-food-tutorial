using Godot;
using Godot.Collections;

namespace ChoosyFoodTutorial.Dialogues.Scripts;

[Tool]
[GlobalClass]
public partial class Dialogue : Resource
{
    [Export] 
    public Texture2D AvatarTexture {get; private set;}
    
    [Export] 
    public Array<string> DialogueSlides {get; private set;}
}