using System;
using Godot;

namespace ChoosyFoodTutorial;

public partial class Player : CharacterBody3D
{
    [Export] private float _mouseSensitivity = 0.1f;
    [Export] private float _playerSpeed = 5.0f;
    
    private Camera3D _camera;

    public override void _Ready()
    {
        base._Ready();
        Initialize();
    }

    private void Initialize()
    {
        _camera = GetNode<Camera3D>("PlayerCamera");
        Input.SetMouseMode(Input.MouseModeEnum.Captured);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Move(delta);
    }

    public override void _Input(InputEvent @event)
    {
        Aim(@event);
    }

    private void Move(double delta)
    {
        Console.WriteLine(Transform.Basis.Z);
        
        Vector3 velocity = Velocity;
        float direction = Input.GetAxis("Move_Forward", "Move_Backward");
        velocity.X = direction * _playerSpeed;

        Velocity = velocity;
        MoveAndSlide();
    }

    private void Aim(InputEvent @event)
    {
        if (@event is not InputEventMouseMotion mouseMotion) return;
        var horRotation = RotationDegrees.Y - mouseMotion.Relative.X * _mouseSensitivity;
        RotationDegrees = new Vector3(RotationDegrees.X, horRotation, 0);
            
        var verRotation = _camera.RotationDegrees.X - mouseMotion.Relative.Y * _mouseSensitivity;
        _camera.RotationDegrees = new Vector3(Mathf.Clamp(verRotation, -90f, 90f), _camera.RotationDegrees.Y, 0);
    }
}