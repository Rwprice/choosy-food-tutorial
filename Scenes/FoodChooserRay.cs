using System;
using Godot;

namespace ChoosyFoodTutorial.Scenes;

public partial class FoodChooserRay : RayCast3D
{
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed("Select_Food"))
        {
            var collider = GetCollider();
            if (collider != null)
            {
                GD.Print(collider.Get("owner"));
            }
        }
    }
}