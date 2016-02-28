using UnityEngine;
using System.Collections;

public class talk_managing : MonoBehaviour {

    
    
    RaycastHit hit; //used to store information of what we are hitting

    //we only care if we hit people
    public LayerMask people_mask;

    //added for flexibility
    talk_base current_talk_text;


    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

       // Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 5f, Color.red);
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,5f, people_mask) && !game_manager.Instance.talked)
        {
            if(current_talk_text == null) //store refference only once.
            {
                current_talk_text = hit.transform.GetComponent< talk_base> (); //store a refference, used for Ui prompt text 
                current_talk_text.turn_on();//turn it on.
            }
            Debug.Log("work");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("work2");
                //check who you talking to.
                Debug.Log(hit.transform.tag);
                switch (hit.transform.tag)
                {
                    case "marketing":
                        hit.transform.GetComponent<talk_marketing>().talk();
                        game_manager.Instance.talked = true;
                        break;
                    case "boss":
                        Debug.Log("work3");
                        hit.transform.GetComponent<talk_boss>().talk();
                        break;
                    case "key_account_manager":
                        break;
                    case "regulatory affairs":
                        break;
                    case "brand_manager":
                        break;
                }
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
