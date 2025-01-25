using System;
using Godot;

namespace ChoosyFoodTutorial.Scripts.Asset_Scripts;

[Tool]
public partial class ImportFantasyTown : EditorScenePostImport
{
    public override GodotObject _PostImport(Node scene)
    {
        Console.WriteLine("Importing Fantasy Town object");
        var scene3D = scene as Node3D;
        var mesh = scene3D.GetChild<MeshInstance3D>(0);
        mesh.CreateTrimeshCollision();
        return scene3D;
    }
}