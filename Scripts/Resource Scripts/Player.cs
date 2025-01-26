using Godot;

namespace ChoosyFoodTutorial.Scripts.Resource_Scripts;

public partial class Player : CharacterBody3D
{
    // Mouse Variables
    [Export] 
    private float _mouseSensitivity = 0.1f;
    
    // Movement Variables
    [Export] 
    private float _playerSpeed = 3.5f;
    [Export] 
    private float _groundFriction = 0.9f;
    
    // Game State
    [Export] 
    private GlobalState _globalState;
    
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
        if (_globalState.CurrentGameplayState == GameplayState.OUT_OF_DIALOGUE)
        {
            Move(delta);
        }
    }

    public override void _Input(InputEvent @event)
    {
        Aim(@event);
    }

    private void Move(double delta)
    {
        var movementVec2 = Input.GetVector("Move_Left", "Move_Right", "Move_Forward", "Move_Backward");
        var movement = Transform.Basis * new Vector3(movementVec2.X, 0, movementVec2.Y);
        movement *= _playerSpeed;
        var velocity = new Vector3(movement.X, 0, movement.Z);
        velocity.X *= _groundFriction;
        velocity.Z *= _groundFriction;
        

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