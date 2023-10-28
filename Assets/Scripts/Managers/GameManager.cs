using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;


public class GameManager : MonoBehaviour, IStateMachine
{
    private static readonly Dictionary<KeyCode, Action> inputToAction = new()
    {
        { KeyCode.Return, Action.StartGame },
        { KeyCode.Escape, Action.PauseGame }
    };

    private State currentState;
    public IListener[] listeners;
    public GameManagerConfig gameManagerConfig;

    void Start()
    {
        if (gameManagerConfig == null) { throw new ArgumentException("GameManager configuration is missing.."); }

        currentState = new PausedState(this);
        // setup the listeners to listen to the KeyCode Escape
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter was pressed.. Starting the Game..");
            currentState.HandleEvent(inputToAction[KeyCode.Return]);
        }
    }

    public void TransitionTo(State newState)
    {
        currentState = newState;
    }
}
