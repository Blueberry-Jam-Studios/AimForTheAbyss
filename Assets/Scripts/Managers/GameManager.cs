using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;


public class GameManager : MonoBehaviour, IStateMachine
{
    private static readonly Dictionary<KeyCode, Action> inputToAction = new()
    {
        { KeyCode.Return, Action.ToggleMainMenu },
        { KeyCode.Escape, Action.TogglePause }
    };

    public static GameManager Instance;

    public AvailableGameState startingState = AvailableGameState.MainMenu;
    private State currentState;
    public IListener[] listeners;
    public GameManagerConfig gameManagerConfig;

    void Awake()
    {
        if (gameManagerConfig == null)
            throw new ArgumentException("GameManager configuration is missing..");

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(transform.parent.gameObject);
            Instance = this;
        }
        else
        {
            // destroy the newly created one
            Destroy(gameObject);
        }

        if (startingState == AvailableGameState.MainMenu)
            currentState = new MainMenuState(this);
        if (startingState == AvailableGameState.Playing)
            currentState = new PlayingState(this);

        // setup the listeners to listen to the KeyCode Escape
    }

    void Update()
    {
        foreach (KeyValuePair<KeyCode, Action> userInput in inputToAction)
        {
            if (Input.GetKeyDown(userInput.Key))
            {
                Debug.Log(userInput.Key + " was pressed.. Emitting event " + userInput.Value);
                currentState.HandleEvent(userInput.Value);
            }
        }
    }

    public void TransitionTo(State newState)
    {
        currentState = newState;
    }
}
