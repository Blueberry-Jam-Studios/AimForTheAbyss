using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace States
{
    enum AvailableGameState
    {
        Playing,
        Paused,
        Dead
    }

    class PausedState : State
    {
        Scene pausedScene;
        public PausedState(GameManager context) : base(context)
        {
            pausedScene = SceneManager.GetActiveScene();
        }

        public override void HandleEvent(Action action)
        {
            if (action == Action.StartGame)
            {
                Debug.Log("The Game was started, loading the scene..");
                // _context.mainMenu.HideMenu();
                _context.TransitionTo(new PlayingState(_context));
            }
            if (action == Action.PauseGame)
            {
                SceneManager.SetActiveScene(pausedScene);
            }
        }
    }

    // Concrete States implement various behaviors, associated with a state of
    // the Context.
    class PlayingState : State
    {
        Scene playingScene;

        public PlayingState(GameManager context) : base(context)
        {
            // the Scene is defined on the Config from the User's progress or level select
            string playingSceneName = _context.gameManagerConfig.PlayingScene;

            // TODO: only load the scne if it is not already loaded

            SceneManager.LoadScene(sceneName: playingSceneName);
            playingScene = SceneManager.GetSceneByName(playingSceneName);
            SceneManager.SetActiveScene(playingScene);
        }

        public override void HandleEvent(Action action)
        {
            if (action == Action.PauseGame)
            {
                Debug.Log("The Playing state transitions to the Paused state");
                _context.TransitionTo(new PausedState(_context));
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
