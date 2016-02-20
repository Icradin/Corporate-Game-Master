using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class duct_tape_logic : MonoBehaviour {

	public GameObject duct_tape_text;
	public GameObject tape_image;
	public GameObject duct_tape;

   


	void OnMouseEnter (){
		duct_tape_text.GetComponent<Text> ().enabled = true;
	}

	void OnMouseOver(){
		
		if (Input.GetKeyDown (KeyCode.E)) {
			tape_image.GetComponent <Image> ().enabled = true;
			Destroy (gameObject);
			duct_tape_text.GetComponent<Text> ().enabled = false;
            
		}
			
	}

	void OnMouseExit (){
		duct_tape_text.GetComponent<Text> ().enabled = false;
	}


}
