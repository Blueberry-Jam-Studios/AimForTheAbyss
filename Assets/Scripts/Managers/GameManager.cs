using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;
using System.Linq;


public class GameManager : MonoBehaviour, IStateMachine
{
    private static readonly Dictionary<KeyCode, Action> inputToAction = new()
    {
        { KeyCode.Return, Action.ToggleMainMenu },
        { KeyCode.Escape, Action.TogglePause }
    };

    public static GameManager Instance;

    public AvailableGameState startingState = AvailableGameState.MainMenu;

    public State CurrentState { get; set; }

    public GameManagerConfig gameManagerConfig;

    public GameData gameData;

    void Awake()
    {
        if (gameManagerConfig == null)
            throw new ArgumentException("GameManager configuration is missing..");

        if (Instance == null)
        {
            DontDestroyOnLoad(transform.parent.gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (startingState == AvailableGameState.MainMenu)
            CurrentState = new MainMenuState(this);
        if (startingState == AvailableGameState.Playing)
            CurrentState = new PlayingState(this);

        // TODO: Load the data using the DataPersistence
        gameData = new GameData();
    }

    void Update()
    {
        foreach (KeyValuePair<KeyCode, Action> userInput in inputToAction.Where(userInput => Input.GetKeyDown(userInput.Key)))
        {
            Debug.Log(userInput.Key + " was pressed.. Emitting event " + userInput.Value);
            CurrentState.HandleEvent(userInput.Value);
        }
    }

    public void TransitionTo(State newState)
    {
        CurrentState = newState;
    }

    public void StartGame()
    {
        Debug.Log("Starting the Game..");
        CurrentState.HandleEvent(Action.ToggleMainMenu);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting the Game..");
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
