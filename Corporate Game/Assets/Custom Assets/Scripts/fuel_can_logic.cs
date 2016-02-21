using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fuel_can_logic : MonoBehaviour {

	public GameObject fuel_can_text;
	public GameObject fuel_can_image;
	public GameObject oil_barrel;
    public GameObject oil_level;

    public GameObject david;

    private bool fuel_can_empty = false;
    private int timesUsed = 0;

   // private float oil_height = 1.0f;


	void OnMouseEnter ()
    {
        if (timesUsed == 3)
            fuel_can_empty = true;
        if (!game_manager.Instance.gotDuctTape)
        {
            fuel_can_text.GetComponent<Text>().enabled = true;
        }
        else
        {
            //show text to seal oil leakage from barrel
        }

	}
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
            oil_level.transform.Translate(0, -0.6f, 0);
    }
	void OnMouseOver()
    {

		if (Input.GetKeyDown(KeyCode.E))
        {

            if(game_manager.Instance.gotDuctTape)
            {
                //do action if got ducttape 

            }else if (!fuel_can_empty) //otherwise do action if can get fuel
            {
                
                oil_level.transform.Translate(0, -0.6f, 0);
                timesUsed++;
                fuel_can_image.GetComponent<Image>().enabled = true;
                fuel_can_text.GetComponent<Text>().enabled = false;
                this.GetComponent<MeshCollider>().enabled = false;
                david.GetComponent<conversation_logic>().SetOil();
            }
        }
	}



void OnMouseExit ()
    {
        if (!game_manager.Instance.gotDuctTape)
        {
            fuel_can_text.GetComponent<Text>().enabled = false;
        }
        else
        {
            //hide text to seal oil leakage from barrel;
        }
	}


}