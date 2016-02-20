using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class conversation_logic : MonoBehaviour {

    //references game objects
	public GameObject player, talk_to_david, tent_collider,
        water_collider, dirty_water_collider, fruit_collider, fish_collider, oil_collider, camp_fire;
    
	public Button talk_button, map_button, daily_tasks_button, goodbye_button, 
        back_button, what_happened_button, survive_button, dt_explanation_button,
        give_water, give_fruit, give_fish, give_oil, give_dirty_water;

    public bool got_dirty_water = false, got_water = false, got_fruit = false, got_fish = false, got_oil = false;

    // daily tasks inventory images
    public Image inventory_water, inventory_fruit, inventory_fish, inventory_oil, map_1, map_2, map_3, map_4;

    float health_timer, hydration_timer, hunger_timer, moralle_timer;

   
    //skybox materials
    public Material morning_skybox, day_skybox, afternoon_skybox, night_skybox;
   
    //lights
    public Light main_light, night_light;
  
    //day and actions
    private int day_count = 0, action_count = 2, conversation_level = 1;
   
    private bool enable_daily_tasks = false, given_oil;
    
    //references cursor test script
    public cursor_test_class call_cursor_test;

    private ui_manager ui_manager;


    //Just hardcoded bool to know if the fire is ON or OFF.
    [HideInInspector]
    public bool fire_place_ON = false;

    void Start()
    {
        ui_manager = FindObjectOfType<ui_manager>();
        inventory_water = inventory_water.GetComponent<Image>();
        inventory_fruit = inventory_fruit.GetComponent<Image>();
        inventory_fish = inventory_fish.GetComponent<Image>();
        inventory_oil = inventory_oil.GetComponent<Image>();

        ParticleSystem camp_particles = camp_fire.GetComponent<ParticleSystem>();
        
        //camp_fire.GetComponent<ParticleSystem>() = false;
    }

    void Update()
    {
       // health_timer = health_timer * Time.deltaTime*10;
       // hydration_timer = hydration_timer * Time.deltaTime;
       // hunger_timer = hunger_timer * Time.deltaTime;
      //  moralle_timer = hunger_timer * Time.deltaTime;

        //I need this tranform to be a RectTransfom but for some reason it doesn't work. 
        //the healthbar needs to move left constantly during the dame at a slow pace
        //but this formatting doesn't work for some reason.

       // hydration_bar.transform.position = new Vector3(-health_timer, 0.0f, 0.0f);

        if (action_count == 0)
        {
            tent_collider.GetComponent<BoxCollider>().enabled = true;
            RenderSettings.skybox = night_skybox;
            main_light.enabled = false;
            night_light.enabled = true;
            //key_light_1.intensity = 0.1f;
            //key_light_1.intensity = 0.1f;

            if (given_oil)
            {
                //camp_light.enabled = true;
              //  fire_place_ON = true;
                
            }
        }

        if (action_count == 1)
        {
            RenderSettings.skybox = afternoon_skybox;
            main_light.color = new Color(1.0f, 0.937f, 0.435f, 1.0f);
            main_light.intensity = 0.5f;
            //key_light_1.intensity = 0.5f;
            //key_light_1.intensity = 0.5f;
        }

        if (action_count == 2)
        {
            RenderSettings.skybox = day_skybox;
            main_light.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            main_light.intensity = 0.8f;
            //key_light_1.intensity = 0.5f;
            //key_light_1.intensity = 0.5f;
        }

        if (action_count == 3)
        {
            RenderSettings.skybox = morning_skybox;
            main_light.enabled = true;
            night_light.enabled = false;
            main_light.color = new Color(1.0f, 0.956f, 0.839f, 1.0f);
            main_light.intensity = 0.5f;
            //key_light_1.intensity = 0.1f;
            //key_light_1.intensity = 0.1f;
        }
    }

    public void KillingPeople()
    {
        if (day_count == 1)
        {

        }

        if (day_count == 2)
        {

        }

        if (day_count == 3)
        {

        }
    }

    public void ActionCount()
    {
        action_count--;
        Debug.Log(action_count);
        if (action_count == 0)
        {
            water_collider.GetComponent<BoxCollider>().enabled = false;
            dirty_water_collider.GetComponent<BoxCollider>().enabled = false;
            fruit_collider.GetComponent<BoxCollider>().enabled = false;
            fish_collider.GetComponent<BoxCollider>().enabled = false;
            oil_collider.GetComponent<MeshCollider>().enabled = false;
            tent_collider.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void ResetActions()
    {
        action_count = 3;
        day_count++;
        water_collider.GetComponent<BoxCollider>().enabled = true;
        dirty_water_collider.GetComponent<BoxCollider>().enabled = true;
        fruit_collider.GetComponent<BoxCollider>().enabled = true;
        fish_collider.GetComponent<BoxCollider>().enabled = true;
        oil_collider.GetComponent<MeshCollider>().enabled = true;
        tent_collider.GetComponent<BoxCollider>().enabled = false;
        KillingPeople();


    }
    //Button Functions
    public void GiveWater()
    {
        ui_manager.IncreaseHydration();

        inventory_water.enabled = false;
        got_dirty_water = false;
        got_water = false;
        give_water.GetComponent<Image>().enabled = false;
        give_water.GetComponent<Button>().enabled = false;
        give_dirty_water.GetComponent<Image>().enabled = false;
        give_dirty_water.GetComponent<Button>().enabled = false;
    }

    public void GiveDirtyWater()
    {

        ui_manager.IncreaseHydration();
        ui_manager.DecreaseHealth();

        inventory_water.enabled = false;
        got_dirty_water = false;
        got_water = false;
        give_dirty_water.GetComponent<Image>().enabled = false;
        give_dirty_water.GetComponent<Button>().enabled = false;
        give_water.GetComponent<Image>().enabled = false;
        give_water.GetComponent<Button>().enabled = false;

    }

    public void GiveFruit()
    {
        ui_manager.IncreaseHunger();

        inventory_fruit.enabled = false;
        got_fruit = false;
        give_fruit.GetComponent<Image>().enabled = false;
        give_fruit.GetComponent<Button>().enabled = false;
    }

    
    public void GiveFish()
    {
        ui_manager.IncreaseHunger();
        ui_manager.DecreaseHealth();

        inventory_fish.enabled = false;
        got_fish = false;
        give_fish.GetComponent<Image>().enabled = false;
        give_fish.GetComponent<Button>().enabled = false;
    }

   
    public void GiveOil()
    {
        inventory_oil.enabled = false;
        
        got_oil = false;
        give_oil.GetComponent<Image>().enabled = false;
        give_water.GetComponent<Button>().enabled = false;
        given_oil = true;

        fire_place_ON = true;
    }


    public void Talk()
    {
        talk_button.GetComponent<Image>().enabled = false;
        talk_button.GetComponent<Button>().enabled = false;

        map_button.GetComponent<Image>().enabled = false;
        map_button.GetComponent<Image>().enabled = false;

        daily_tasks_button.GetComponent<Image>().enabled = false;
        daily_tasks_button.GetComponent<Button>().enabled = false;

        what_happened_button.GetComponent<Image>().enabled = true;
        what_happened_button.GetComponent<Button>().enabled = true;

        survive_button.GetComponent<Image>().enabled = true;
        survive_button.GetComponent<Image>().enabled = true;

        dt_explanation_button.GetComponent<Image>().enabled = true;
        dt_explanation_button.GetComponent<Image>().enabled = true;

        back_button.GetComponent<Image>().enabled = true;
        back_button.GetComponent<Image>().enabled = true;



        conversation_level = 2;

    }

    public void ShowMap()
    {
        if (day_count == 0)
            map_1.GetComponent<Image>().enabled = true;
        if (day_count == 1)
            map_2.GetComponent<Image>().enabled = true;
        if (day_count == 2)
            map_3.GetComponent<Image>().enabled = true;
        if (day_count == 3)
            map_4.GetComponent<Image>().enabled = true;

        talk_button.GetComponent<Image>().enabled = false;
        talk_button.GetComponent<Button>().enabled = false;

        map_button.GetComponent<Image>().enabled = false;
        map_button.GetComponent<Image>().enabled = false;

        daily_tasks_button.GetComponent<Image>().enabled = false;
        daily_tasks_button.GetComponent<Button>().enabled = false;

        goodbye_button.GetComponent<Image>().enabled = false;
        goodbye_button.GetComponent<Button>().enabled = false;

        back_button.GetComponent<Image>().enabled = true;
        back_button.GetComponent<Image>().enabled = true;

        conversation_level = 2;

    }

    public void DailyTasks()
    {
        talk_button.GetComponent<Image>().enabled = false;
        talk_button.GetComponent<Button>().enabled = false;

        map_button.GetComponent<Image>().enabled = false;
        map_button.GetComponent<Image>().enabled = false;

        daily_tasks_button.GetComponent<Image>().enabled = false;
        daily_tasks_button.GetComponent<Button>().enabled = false;

        goodbye_button.GetComponent<Image>().enabled = false;
        goodbye_button.GetComponent<Button>().enabled = false;

        back_button.GetComponent<Image>().enabled = true;
        back_button.GetComponent<Image>().enabled = true;

        enable_daily_tasks = true;

        conversation_level = 2;

        if (got_dirty_water == true)
        {
            give_dirty_water.GetComponent<Image>().enabled = true;
            give_dirty_water.GetComponent<Button>().enabled = true;
        }

        if (got_water == true)
        {
            give_water.GetComponent<Image>().enabled = true;
            give_water.GetComponent<Button>().enabled = true;
        }

        if (got_fruit == true)
        {
            give_fruit.GetComponent<Image>().enabled = true;
            give_fruit.GetComponent<Button>().enabled = true;
        }

        if (got_fish == true)
        {
            give_fish.GetComponent<Image>().enabled = true;
            give_fish.GetComponent<Button>().enabled = true;
        }

        if (got_oil == true)
        {
            give_oil.GetComponent<Image>().enabled = true;
            give_oil.GetComponent<Button>().enabled = true;

        }


    }

    public void Back()
    {
        if (conversation_level == 2)
        {
            talk_button.GetComponent<Image>().enabled = true;
            talk_button.GetComponent<Button>().enabled = true;

            map_button.GetComponent<Image>().enabled = true;
            map_button.GetComponent<Image>().enabled = true;

            daily_tasks_button.GetComponent<Image>().enabled = true;
            daily_tasks_button.GetComponent<Button>().enabled = true;

            what_happened_button.GetComponent<Image>().enabled = false;
            what_happened_button.GetComponent<Button>().enabled = false;

            survive_button.GetComponent<Image>().enabled = false;
            survive_button.GetComponent<Image>().enabled = false;

            dt_explanation_button.GetComponent<Image>().enabled = false;
            dt_explanation_button.GetComponent<Image>().enabled = false;

            back_button.GetComponent<Image>().enabled = false;
            back_button.GetComponent<Image>().enabled = false;

            goodbye_button.GetComponent<Image>().enabled = true;
            goodbye_button.GetComponent<Button>().enabled = true;

            give_water.GetComponent<Image>().enabled = false;
            give_water.GetComponent<Button>().enabled = false;

            give_water.GetComponent<Image>().enabled = false;
            give_water.GetComponent<Button>().enabled = false;

            give_fruit.GetComponent<Image>().enabled = false;
            give_fruit.GetComponent<Button>().enabled = false;

            give_fish.GetComponent<Image>().enabled = false;
            give_fish.GetComponent<Button>().enabled = false;

            give_oil.GetComponent<Image>().enabled = false;
            give_oil.GetComponent<Button>().enabled = false;
        }

            map_1.GetComponent<Image>().enabled = false;
            map_2.GetComponent<Image>().enabled = false;
            map_3.GetComponent<Image>().enabled = false;
            map_4.GetComponent<Image>().enabled = false;

            conversation_level = 1;

            enable_daily_tasks = false;
        

    }

    public void GoodBye()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        call_cursor_test.ToggleCursorState();
        player.GetComponent<FirstPersonController>().enabled = true;

        talk_button.GetComponent<Image>().enabled = false;
        talk_button.GetComponent<Button>().enabled = false;

        map_button.GetComponent<Image>().enabled = false;
        map_button.GetComponent<Image>().enabled = false;

        daily_tasks_button.GetComponent<Image>().enabled = false;
        daily_tasks_button.GetComponent<Button>().enabled = false;

        goodbye_button.GetComponent<Image>().enabled = false;
        goodbye_button.GetComponent<Button>().enabled = false;

        give_water.GetComponent<Image>().enabled = false;
        give_water.GetComponent<Button>().enabled = false;

        give_fruit.GetComponent<Image>().enabled = false;
        give_fruit.GetComponent<Button>().enabled = false;

        give_fish.GetComponent<Image>().enabled = false;
        give_fish.GetComponent<Button>().enabled = false;

        give_oil.GetComponent<Image>().enabled = false;
        give_oil.GetComponent<Button>().enabled = false;

        what_happened_button.GetComponent<Image>().enabled = false;
        what_happened_button.GetComponent<Button>().enabled = false;

        survive_button.GetComponent<Image>().enabled = false;
        survive_button.GetComponent<Button>().enabled = false;

        dt_explanation_button.GetComponent<Image>().enabled = false;
        dt_explanation_button.GetComponent<Button>().enabled = false;

    }

    //public setter functions
    public void SetOil()
    {
        got_oil = true;
    }

    public void SetWater()
    {
        got_water = true;
    }

    public void SetDirtyWater()
    {
        got_dirty_water = true;
    }

    public void SetFruit()
    {
        got_fruit = true;
    }

    public void SetFish()
    {
        got_fish = true;
    }

    void OnMouseEnter()
    {
        //enables talk to david prompt
		talk_to_david.GetComponent<Text> ().enabled = true;
	}





	void OnMouseOver ()
    {
		
		if (Input.GetKeyDown (KeyCode.E))
        {
            //disables talk to david text 
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            //toggles cursor off
            call_cursor_test.ToggleCursorState();

            //disables player movement and mouselook
            player.GetComponent<FirstPersonController>().enabled = false;

            //enables main conversation buttons
			talk_button.GetComponent<Image> ().enabled = true;
            talk_button.GetComponent<Button>().enabled = true;

			map_button.GetComponent<Image> ().enabled = true;
            map_button.GetComponent<Image>().enabled = true;

			daily_tasks_button.GetComponent<Image> ().enabled = true;
            daily_tasks_button.GetComponent<Button>().enabled = true;

            goodbye_button.GetComponent<Image>().enabled = true;
            goodbye_button.GetComponent<Button>().enabled = true;


            //checks daily tasks buttons and enables them if you have the items
            

        }
			
	}

	void OnMouseExit ()
    {
        //disables talk to david prompt
		talk_to_david.GetComponent<Text> ().enabled = false;
	}

    //quits the application
    public void ApplicationQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }
	

}
