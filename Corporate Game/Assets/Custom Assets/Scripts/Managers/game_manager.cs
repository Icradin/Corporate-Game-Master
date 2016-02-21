using UnityEngine;
using System.Collections;

public class game_manager : MonoBehaviour {

    //Singleton for game manager.
    private static game_manager _instance;
    public static game_manager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<game_manager>();
                _instance.tag = "GameManager";
            }
            return _instance;
        }
    }

    private GameState current_state;
    public GameState Current_State
    {
        get { return current_state; }
        set { current_state = value; }
    }

    public pause_menu_manager pause_menu;
    public scene_manager scene_manager;
    private GameObject _player;
    public GameObject Player
    {
        get
        {
            if (_player == null)
                _player = GameObject.FindGameObjectWithTag("player");
            return _player;
        }
    }



    public bool gotDuctTape = false;
    void Awake()
    {

        if (Application.loadedLevel != 0)
        {
            current_state = GameState.InGame;
            FindRefferenceToGameObject();
        }  

    }


    void OnLevelWasLoaded()
    {
        if(current_state == GameState.InGame)
        {
            FindRefferenceToGameObject();
        }

    }

    void FindRefferenceToGameObject()
    {
        pause_menu = FindObjectOfType<pause_menu_manager>();
        scene_manager = FindObjectOfType<scene_manager>();
    }
}
