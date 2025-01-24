using Godot;
using System;

public partial class player : CharacterBody3D
{
    [Export] private float _mouseSensitivity = 0.1f;
    
    private Camera3D _camera;

    public override void _Ready()
    {
        base._Ready();
        Input.SetMouseMode(Input.MouseModeEnum.Captured);

        foreach (var Child in GetChildren())
        {
            if (Child is Camera3D)
            {
                _camera = (Camera3D)Child;
            }
        }
    }

    public override void _Input(InputEvent @event)
    {
        var mouseMotion = @event as InputEventMouseMotion;
        if (mouseMotion != null)
        {
            var horRotation = RotationDegrees.Y - mouseMotion.Relative.X * _mouseSensitivity;
            RotationDegrees = new Vector3(RotationDegrees.X, horRotation, 0);
            
            var verRotation = _camera.RotationDegrees.X - mouseMotion.Relative.Y * _mouseSensitivity;
            _camera.RotationDegrees = new Vector3(Mathf.Clamp(verRotation, -90f, 90f), _camera.RotationDegrees.Y, 0);
        }
    }
}
