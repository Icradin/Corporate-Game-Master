using UnityEngine;
using System.Collections;
public enum GameState
{
    Menu, InGame, Paused
}
public class scene_manager : MonoBehaviour {
  
    GameState currentState;
   

    void Awake()
    {
        DontDestroyOnLoad(game_manager.Instance);
    }
    // Use this for initialization
    void Start () {
        currentState = game_manager.Instance.Current_State;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (currentState)
            {
                case GameState.InGame:
                    SetState(GameState.Paused);
                    break;
                case GameState.Paused:
                    SetState(GameState.InGame);
                    break;
                default:
                    print(string.Format("Current state is '{0}'. If not expected state check build settings !!", currentState));
                    break;
            }
        }
    }




    public void SetState(GameState newGameState)
    {
        DisablePreviousState(currentState);
        switch (newGameState)
        {
            case GameState.Menu:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case GameState.InGame:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                //Time.timeScale = 1; //reset time scale
                break;
            case GameState.Paused:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //   Time.timeScale = 0; // stop ime when paused.
                //   activate pause menu

                break;
        }
        currentState = newGameState;

    }


    void DisablePreviousState(GameState previousState)
    {
        switch (previousState)
        {
            case GameState.Menu:
                break;
            case GameState.InGame:
                break;
            case GameState.Paused:
              //deactivat pause menu ???
                break;
        }
    }




    public void SwitchToLevel(int index)
    {
        game_manager.Instance.Current_State = GameState.InGame;
        SetState(GameState.InGame);
        //Application.LoadLevel(index);
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        print("load level " + index);
    }

    public void SwitchToMainMenu()
    {
        game_manager.Instance.Current_State = GameState.Menu;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void CloseGame()
    {
        print("Application shut down !!");
        Application.Quit();
    }
}

