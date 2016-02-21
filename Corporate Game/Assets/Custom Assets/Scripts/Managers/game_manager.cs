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
                _instance = new GameObject("Game Manager").AddComponent<game_manager>();
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


    public bool gotDuctTape = false;
    void Awake()
    {
        
        if (Application.loadedLevel != 0)
            current_state = GameState.InGame;
        

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
