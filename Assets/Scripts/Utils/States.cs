using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace States
{
    public enum AvailableGameState
    {
        MainMenu,
        Playing,
        Dialogue,
        Paused,
        Dead
    }

    class MainMenuState : State
    {
        public override string Name { get; set; } = AvailableGameState.MainMenu.ToString();

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
        public override string Name { get; set; } = AvailableGameState.Playing.ToString();

        public PlayingState(GameManager context) : base(context)
        {
            if (SceneManager.GetActiveScene().name != context.gameManagerConfig.PlayingScene)
            {
                SceneManager.LoadScene(context.gameManagerConfig.PlayingScene);
            }
            Time.timeScale = 1f;
        }

        public override void HandleEvent(Action action)
        {
            if (action == Action.TogglePause)
            {
                Debug.Log("The Playing state transitions to the Paused state");
                _context.TransitionTo(new PausedState(_context));
            }

            if (action == Action.ToggleDialogue)
            {
                Debug.Log("The Dialogue has started..");
                _context.TransitionTo(new DialogueState(_context));
            }
        }
    }

    class DialogueState : State
    {
        public override string Name { get; set; } = AvailableGameState.Dialogue.ToString();

        public DialogueState(GameManager context) : base(context)
        {
        }

        public override void HandleEvent(Action action)
        {
            if (action == Action.ToggleDialogue)
            {
                Debug.Log("The Dialogue has ended..");
                _context.TransitionTo(new PlayingState(_context));
            }
        }
    }
    class PausedState : State
    {
        public override string Name { get; set; } = AvailableGameState.Paused.ToString();

        readonly MainMenu pausedMenu;

        public PausedState(GameManager context) : base(context)
        {
            pausedMenu = GameObject.FindWithTag("MainMenu").GetComponent<MainMenu>();
            pausedMenu.DisplayMenu();
            Time.timeScale = 0f;
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
        public override string Name { get; set; } = AvailableGameState.Dead.ToString();

        public DeadState(GameManager context) : base(context)
        {
        }

        public override void HandleEvent(Action action)
        {
            Debug.Log("Returning to the MainMenu");
            _context.TransitionTo(new MainMenuState(_context));

            // TODO: return either to the MainMenu or restart the scene
        }
    }
}
