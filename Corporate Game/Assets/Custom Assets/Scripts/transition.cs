using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class transition : MonoBehaviour {


	public int transition_number;



	void OnTriggerStay(){
		if (Input.GetKeyDown (KeyCode.E)) {
            print("kk");
            transition_manager.instance.transition (transition_number, gameObject);	
		}
			

	}
}
