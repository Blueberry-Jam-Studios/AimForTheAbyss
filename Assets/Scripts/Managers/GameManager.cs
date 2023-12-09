using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStates;
using System;
using System.Linq;
using Patterns;

public class GameManager: Singleton<GameManager>
{

    public Dictionary<GameState, State<GameState>> States { get; set; } = new();
    public State<GameState> CurrentState { get; set; }

    public GameState startingState = GameState.MainMenu;

    public GameManagerConfig gameManagerConfig;

    public GameData gameData;

    public FiniteStateMachine<GameState> fsm { get; private set; } = new();

    new void Awake()
    {
        base.Awake();
        if (gameManagerConfig == null)
            throw new ArgumentException("GameManager configuration is missing..");

        PopulateStates();
        SetState(startingState);
        
        // TODO: Load the data using the DataPersistence
        gameData = new GameData();
    }

    void PopulateStates()
    { 
        fsm.Add(GameState.MainMenu, new MainMenuState(this));
        fsm.Add(GameState.Playing, new PlayingState(this));
        fsm.Add(GameState.Paused, new PausedState(this));
        fsm.Add(GameState.Dialogue, new DialogueState(this));
        fsm.Add(GameState.Dead, new DeadState(this));
    }

    void Update()
    {
        fsm.Update();
    }

    public void StartGame()
    {
        Debug.Log("Starting the Game..");
        SetState(GameState.Playing);
    }

    public bool IsInState(GameState desiredState)
    {
        return fsm.CurrentState == fsm.GetState(desiredState);
    }

    public bool SetState(GameState targetState)
    { 
        // TODO: Save the state and transition to the next one. 
        // Return false if the save of the state failed.

        fsm.SetCurrentState(targetState);
        return true;
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
