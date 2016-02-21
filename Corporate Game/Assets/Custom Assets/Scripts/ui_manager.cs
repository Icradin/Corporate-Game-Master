using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ui_manager : MonoBehaviour {

    player_stats player_stats;

	public GameObject spring_text;
	public GameObject fruit_text;
	public GameObject fishing_text;
	public GameObject duct_tape_text;
    public GameObject dirty_water_text;
    public GameObject sleeping_text;

	public GameObject water_bottle_ui;
	public GameObject apple_ui;
	public GameObject fishing_ui;

    public GameObject david;

    public GameObject spring_collider;
    public GameObject dirty_water_collider;
    public GameObject fruit_collider;
    public GameObject fish_collider;
    public GameObject oil_collider;
    public GameObject duct_tape_collider;
    public GameObject tent_collider;

    [Header("Ui images")]
    public Image health_bar;
    public Image hydration_bar;
    public Image hunger_bar;
    public Image moralle_bar;
    void Start()
    {
        player_stats = GetComponent<player_stats>();
        if (player_stats == null) print(" ERROR !! --- Attach => player_stats script <=  to player !");
    }


    void OnTriggerEnter (Collider transition_collider)
    {
		
		if (transition_collider.name == "spring_transition")
			spring_text.GetComponent<Text> ().enabled = true;

		if (transition_collider.name == "apple_transition")
			fruit_text.GetComponent<Text>().enabled = true;
		
		if (transition_collider.name == "fishing_transition")
			fishing_text.GetComponent<Text>().enabled = true;

        if (transition_collider.name == "dirty_water_transition")
            dirty_water_text.GetComponent<Text>().enabled = true;

        if (transition_collider.name == "sleeping_transition")
            sleeping_text.GetComponent<Text>().enabled = true;

    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    DecreseStatsOnAction();
        //}

      
    }

    #region Increase / decrease stats on actions

    public void IncreaseHunger()
    {
        hunger_bar.rectTransform.localPosition -= new Vector3(85, 0, 0);
        player_stats.hunger++;
        player_stats.CheckMaxCapStats();
    }
    public void DecreaseHunger()
    {
        hunger_bar.rectTransform.localPosition += new Vector3(85, 0, 0);
        player_stats.hunger--;
        player_stats.CheckDeathStats();
    }

    public void DecreaseHealth()
    {
        health_bar.rectTransform.localPosition += new Vector3(85, 0, 0);
        player_stats.health--;
        player_stats.CheckDeathStats();
    }
    public void IncreaseHealth()
    {
        health_bar.rectTransform.localPosition -= new Vector3(85, 0, 0);
        player_stats.health++;
        player_stats.CheckMaxCapStats();
    }

    public void IncreaseHydration()
    {
        hydration_bar.rectTransform.localPosition -= new Vector3(85, 0, 0);
        player_stats.hydration++;
        player_stats.CheckMaxCapStats();
    }

    public void DecreaseHydration()
    {
        hydration_bar.rectTransform.localPosition += new Vector3(85, 0, 0);
        player_stats.hydration--;
        player_stats.CheckDeathStats();
    }

    public void IncreaseMorale()
    {
        moralle_bar.rectTransform.localPosition -= new Vector3(85, 0, 0);
        player_stats.morale++;
        player_stats.CheckMaxCapStats();
    }

    public void DecreaseMorale()
    {
        moralle_bar.rectTransform.localPosition += new Vector3(85, 0, 0);
        player_stats.morale--;
        player_stats.CheckDeathStats();
    }


    void DecreseStatsOnAction()
    {
        DecreaseHunger();
        DecreaseHydration();
        //DecreaseHealth();
    }
    #endregion



    void OnTriggerStay (Collider transition_collider)
    {
		if (transition_collider.name == "spring_transition")
        {
			if (Input.GetKeyDown (KeyCode.E))
            {
				water_bottle_ui.GetComponent<Image> ().enabled = true;
                david.GetComponent<conversation_logic>().SetWater();
                david.GetComponent<conversation_logic>().ActionCount();
                spring_collider.GetComponent<BoxCollider>().enabled = false;
                spring_text.GetComponent<Text>().enabled = false;
                dirty_water_collider.GetComponent<BoxCollider>().enabled = false;
                  Invoke("DecreseStatsOnAction", 2.0f);
            }
		}

		if (transition_collider.name == "apple_transition")
        {
			if (Input.GetKeyDown (KeyCode.E))
            {
				apple_ui.GetComponent<Image> ().enabled = true;
                david.GetComponent<conversation_logic>().SetFruit();
                david.GetComponent<conversation_logic>().ActionCount();
                fruit_collider.GetComponent<BoxCollider>().enabled = false;
                fruit_text.GetComponent<Text>().enabled = false;
                Invoke("DecreseStatsOnAction", 2.0f);
            }
		}

		if (transition_collider.name == "fishing_transition")
        {
			if (Input.GetKeyDown (KeyCode.E))
            {
				fishing_ui.GetComponent<Image> ().enabled = true;
                david.GetComponent<conversation_logic>().SetFish();
                david.GetComponent<conversation_logic>().ActionCount();
                fish_collider.GetComponent<BoxCollider>().enabled = false;
                fishing_text.GetComponent<Text>().enabled = false;
                Invoke("DecreseStatsOnAction", 2.0f);
            }
		}

        if (transition_collider.name == "dirty_water_transition")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                water_bottle_ui.GetComponent<Image>().enabled = true;
                david.GetComponent<conversation_logic>().SetDirtyWater();
                david.GetComponent<conversation_logic>().ActionCount();
                dirty_water_collider.GetComponent<BoxCollider>().enabled = false;
                dirty_water_text.GetComponent<Text>().enabled = false;
                spring_collider.GetComponent<BoxCollider>().enabled = false;
                Invoke("DecreseStatsOnAction", 2.0f);
            }
        }

        if (transition_collider.name == "sleeping_transition")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                david.GetComponent<conversation_logic>().ResetActions();
                tent_collider.GetComponent<BoxCollider>().enabled = false;
                sleeping_text.GetComponent<Text>().enabled = false;
                if(!david.GetComponent<conversation_logic>().fire_place_ON)
                {
                    Invoke("DecreaseMorale", 2.0f);
                    print("Morale has been decreased ( fire not ON when sleeping)");
                }
                 
            }
        }

    }

	void OnTriggerExit (Collider transition_collider)
    {
		
		if (transition_collider.name == "spring_transition")
			spring_text.GetComponent<Text>().enabled = false;

		if (transition_collider.name == "apple_transition")
			fruit_text.GetComponent<Text>().enabled = false;
		
		if (transition_collider.name == "fishing_transition")
			fishing_text.GetComponent<Text>().enabled = false;

        if (transition_collider.name == "dirty_water_transition")
            dirty_water_text.GetComponent<Text>().enabled = false;

        if (transition_collider.name == "sleeping_transition")
            sleeping_text.GetComponent<Text>().enabled = false;
    }
		
}
