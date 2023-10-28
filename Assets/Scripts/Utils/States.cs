using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace States
{
    public enum AvailableGameState
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
            if (SceneManager.GetActiveScene().name != context.gameManagerConfig.MenuScene)
            {
                SceneManager.LoadScene(context.gameManagerConfig.MenuScene);
            }
        }

        public override void HandleEvent(Action action)
        {
            if (action == Action.ToggleMainMenu)
            {
                Debug.Log("The Game was started, loading the scene..");
                _context.TransitionTo(new PlayingState(_context));
            }
        }
    }

    // Concrete States implement various behaviors, associated with a state of
    // the Context.
    class PlayingState : State
    {
        public PlayingState(GameManager context) : base(context)
        {
            if (SceneManager.GetActiveScene().name != context.gameManagerConfig.PlayingScene)
            {
                SceneManager.LoadScene(context.gameManagerConfig.PlayingScene);
            }
            // MainMenu pausedMenu = GameObject.FindWithTag("MainMenu").GetComponent<MainMenu>();
            // pausedMenu.HideMenu();
            Time.timeScale = 1f;
        }

        public override void HandleEvent(Action action)
        {
            if (action == Action.TogglePause)
            {
                Debug.Log("The Playing state transitions to the Paused state");
                _context.TransitionTo(new PausedState(_context));
            }
        }
    }
    class PausedState : State
    {
        MainMenu pausedMenu;
        public PausedState(GameManager context) : base(context)
        {
            pausedMenu = GameObject.FindWithTag("MainMenu").GetComponent<MainMenu>();
            pausedMenu.DisplayMenu();
            Time.timeScale = 0.2f;
        }

        public override void HandleEvent(Action action)
        {
            if (action == Action.TogglePause)
            {
                Debug.Log("The Game was resumed..");
                pausedMenu.HideMenu();
                _context.TransitionTo(new PlayingState(_context));
            }

            if (action == Action.ToggleMainMenu)
            {
                Debug.Log("Returning the to the Main Menu..");
                _context.TransitionTo(new MainMenuState(_context));
            }
        }
    }


    class DeadState : State
    {
        public DeadState(GameManager context) : base(context)
        {
            // _context.mainMenu.HideMenu();
        }

        public override void HandleEvent(Action actions)
        {
            Debug.Log("The Playing state transitions to the Paused state");
            // _context.mainMenu.DisplayMenu();
            _context.TransitionTo(new PausedState(_context));
        }
    }
}
