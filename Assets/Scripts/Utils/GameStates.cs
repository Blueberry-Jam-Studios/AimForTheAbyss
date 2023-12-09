using UnityEngine;
using UnityEngine.SceneManagement;
using Patterns;
using System.Collections.Generic;
using System;

interface ISceneLoader
{
    public void LoadScene();
    public void UnloadScene();
}

namespace GameStates
{
    public enum GameState
    {
        MainMenu,
        Playing,
        Dialogue,
        Paused,
        Dead
    }

    class BaseGameState : State<GameState>
    {
        protected GameManager m_gm;
        public BaseGameState(GameManager gm): base(gm.fsm)
        {
            m_gm = gm;
        }        
    }

    class MainMenuState : BaseGameState, ISceneLoader
    {        
        public MainMenuState(GameManager gm) : base(gm) { }

        public override void Enter()
        { 
            LoadScene();
        }

        public void LoadScene()
        { 
            if (SceneManager.GetActiveScene().name != m_gm.gameManagerConfig.MenuScene)
            {
                SceneManager.LoadScene(m_gm.gameManagerConfig.MenuScene);
            }
        }

        public override void Exit()
        {
            UnloadScene();
        }

        public void UnloadScene()
        { 
            SceneManager.UnloadSceneAsync(m_gm.gameManagerConfig.MenuScene);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("The Game was started, loading the scene..");
                m_gm.SetState(GameState.Playing);
            }
        }
    }

    class PlayingState : BaseGameState, ISceneLoader
    {        
        public PlayingState(GameManager gm) : base(gm) { }

        public override void Enter()
        {
            LoadScene();
            Time.timeScale = 1f;
        }
        public void LoadScene()
        {  
            if (SceneManager.GetActiveScene().name != m_gm.gameManagerConfig.PlayingScene)
            {
                SceneManager.LoadScene(m_gm.gameManagerConfig.PlayingScene);
            }
        }

        public override void Exit()
        {
            UnloadScene();
            Time.timeScale = 0f;
        }   

        public void UnloadScene()
        { 
            SceneManager.UnloadSceneAsync(m_gm.gameManagerConfig.PlayingScene);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                Debug.Log("The Playing state transitions to the Paused state");
                m_gm.SetState(GameState.Paused);
            }
        }
    }

    class DialogueState : BaseGameState
    {
        public DialogueState(GameManager gm) : base(gm) { }

        public override void Update()
        {       
            if (Input.GetKeyDown(KeyCode.Space))
                DialogueManager.Instance.NextMessage();
        }
    }
    
    class PausedState : BaseGameState
    {
        readonly MainMenu pausedMenu;

        public PausedState(GameManager gm) : base(gm) 
        {
            pausedMenu = GameObject.FindWithTag("MainMenu").GetComponent<MainMenu>();
        }

        public override void Enter()
        {
            pausedMenu.DisplayMenu();
            Time.timeScale = 0f;
        }

        public override void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Debug.Log("The Game was resumed..");
                pausedMenu.HideMenu();
                m_gm.SetState(GameState.Playing);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Returning the to the Main Menu..");
                m_gm.SetState(GameState.MainMenu);
            }
        }
    }


    class DeadState : BaseGameState, ISceneLoader
    {
        public DeadState(GameManager gm) : base(gm)
        {
        }

        public void LoadScene()
        { 
            // Load the death scene
        }
        
        public void UnloadScene()
        { 
            // Unload the death scene
        }

        public override void Update()
        {
            if (Input.GetKeyUp(KeyCode.Return))
            { 
                Debug.Log("Returning to the MainMenu");
                m_gm.SetState(GameState.MainMenu);

            }

            // TODO: return either to the MainMenu or restart the scene
        }
    }
}
