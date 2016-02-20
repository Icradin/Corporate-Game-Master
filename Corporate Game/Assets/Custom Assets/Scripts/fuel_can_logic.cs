using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fuel_can_logic : MonoBehaviour {

	public GameObject fuel_can_text;
	public GameObject fuel_can_image;
	public GameObject oil_barrel;
    public GameObject oil_level;

    public GameObject david;

    private bool set_got_oil;


    private float oil_height = 1.0f;


	void OnMouseEnter ()
    {
		fuel_can_text.GetComponent<Text> ().enabled = true;
        
	}

	void OnMouseOver()
    {

		if (Input.GetKeyDown(KeyCode.E))
        {
            oil_height -= 1.0f;
            oil_level.transform.transform.Translate(0, oil_height, 0);

            fuel_can_image.GetComponent<Image>().enabled = true;
            fuel_can_text.GetComponent<Text>().enabled = false;
            this.GetComponent<MeshCollider>().enabled = false;
            david.GetComponent<conversation_logic>().SetOil();
            
        }
	}



void OnMouseExit ()
    {
		fuel_can_text.GetComponent<Text> ().enabled = false;
	}


}