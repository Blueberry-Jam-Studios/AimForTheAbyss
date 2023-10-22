using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    enum AvailableGameState
    {
        MainMenu,
        Playing,
        Paused,
        Dead
    }

    class MainMenuState : State
    {
        public MainMenuState(GameManager context) : base(context)
        {
            _context.mainMenu.HideMenu();
        }

        public override void HandleEvent(KeyCode keycode)
        {
            Debug.Log("The Playing state transitions to the Paused state");
            _context.mainMenu.DisplayMenu();
            _context.TransitionTo(new PausedState(_context));
        }
    }
    class DeadState : State
    {
        public DeadState(GameManager context) : base(context)
        {
            _context.mainMenu.HideMenu();
        }

        public override void HandleEvent(KeyCode keycode)
        {
            Debug.Log("The Playing state transitions to the Paused state");
            _context.mainMenu.DisplayMenu();
            _context.TransitionTo(new PausedState(_context));
        }
    }

    // Concrete States implement various behaviors, associated with a state of
    // the Context.
    class PlayingState : State
    {
        public PlayingState(GameManager context) : base(context)
        {
            _context.mainMenu.HideMenu();
        }

        public override void HandleEvent(KeyCode keycode)
        {
            Debug.Log("The Playing state transitions to the Paused state");
            _context.mainMenu.DisplayMenu();
            _context.TransitionTo(new PausedState(_context));
        }
    }

    class PausedState : State
    {
        public PausedState(GameManager context) : base(context)
        {
            _context.mainMenu.DisplayMenu();
        }

        public override void HandleEvent(KeyCode keycode)
        {
            Debug.Log("The Paused state transitions to the Playing state");
            _context.mainMenu.HideMenu();
            _context.TransitionTo(new PlayingState(_context));
        }
    }

}
