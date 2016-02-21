using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class duct_tape_logic : MonoBehaviour {

	public GameObject duct_tape_text;
	public GameObject tape_image;
	public GameObject duct_tape;




    void OnMouseEnter()
    {
        if (!game_manager.Instance.gotDuctTape)
        {
            duct_tape_text.GetComponent<Text>().enabled = true;

        }
    }

	void OnMouseOver(){
		
		if (Input.GetKeyDown (KeyCode.E) && !game_manager.Instance.gotDuctTape) {
			tape_image.GetComponent <Image> ().enabled = true;
			Destroy (gameObject);
			duct_tape_text.GetComponent<Text> ().enabled = false;
            game_manager.Instance.gotDuctTape = true;
		}
			
	}

	void OnMouseExit (){
		duct_tape_text.GetComponent<Text> ().enabled = false;
	}


}
