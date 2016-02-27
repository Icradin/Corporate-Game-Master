using UnityEngine;
using System.Collections;

public class talk_managing : MonoBehaviour {



    RaycastHit hit;
    public LayerMask people_mask;
    talk_ui_text current_talk_text;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       // Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 5f, Color.red);
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,5f, people_mask))
        {
            if(current_talk_text == null) //store refference only once.
            {
                current_talk_text = hit.transform.GetComponent<talk_ui_text>(); //store a refference, used for Ui prompt text 
                current_talk_text.turn_on();//turn it on.
            }

            //check who you talking to.
            switch (hit.transform.tag)
            {
                case "marketing":
                   
                    break;
                case "boss":
                    break;
                case "key_account_manager":
                    break;
                case "regulatory affairs":
                    break;
                case "brand_manager":
                    break;
           }
        }
        else
        {
            if(current_talk_text != null)
            {
                current_talk_text.turn_off(); // if not hitting and not disalbed ( means is not null)
                current_talk_text = null; //as we are not hitting anymore, we reset the reffrence.
            }
        }
	}
}
