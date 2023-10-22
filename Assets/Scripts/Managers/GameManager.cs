using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;


public class GameManager : MonoBehaviour, IStateMachine
{

    private State currentState;
    public IListener[] listeners;

    public MainMenu mainMenu;

    void Start()
    {
        mainMenu = GameObject.FindWithTag("MainMenu").GetComponent<MainMenu>();

        currentState = new PausedState(this);
        // setup the listeners to listen to the KeyCode Escape
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape was pressed..");
            currentState.HandleEvent(KeyCode.Escape);
        }
    }

    public void TransitionTo(State newState)
    {
        currentState = newState;
    }
}
