using System;
using ChoosyFoodTutorial.Dialogues.Scripts;
using Godot;

namespace ChoosyFoodTutorial.Scenes;

public partial class DialogueManager : Control
{
	[Export] 
	private NodePath DialogueTextPath { get; set; }
	[Export] 
	private NodePath AvatarPath { get; set; }
	[Export] 
	private Dialogue CurrentDialogue { get; set; }
	
	private Label _dialogueText;
	private TextureRect _avatarTextureRect;
	private GameEvents _gameEvents;

	private int _currentSlideIndex;
	
	public override void _Ready()
	{
		Initialize();
	}

	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionJustPressed("Advance_Slide"))
		{
			OnSlideAction();
		}
	}

	private void Initialize()
	{
		_gameEvents = GetNode<GameEvents>("/root/GameEvents");
		_gameEvents.Connect(nameof(GameEvents.SignalName.DialogueInitiated), 
			Callable.From((Dialogue dialogue) => OnDialogueInitiated(dialogue)));
		
		_dialogueText = GetNode<Label>(DialogueTextPath);
		_avatarTextureRect = GetNode<TextureRect>(AvatarPath);
		InitializeDialogue();
	}

	private void InitializeDialogue()
	{
		_avatarTextureRect.Texture = CurrentDialogue.AvatarTexture;
		_dialogueText.Text = CurrentDialogue.DialogueSlides[_currentSlideIndex];
		Visible = true;
	}

	private void OnSlideAction()
	{
		if (_currentSlideIndex < CurrentDialogue.DialogueSlides.Count - 1)
		{
			_currentSlideIndex++;
			_dialogueText.Text = CurrentDialogue.DialogueSlides[_currentSlideIndex];
		}
		else
		{
			Visible = false;
		}
	}

	private void OnDialogueInitiated(Dialogue newDialogue)
	{
		CurrentDialogue = newDialogue;
		_currentSlideIndex = 0;
		InitializeDialogue();
	}
}