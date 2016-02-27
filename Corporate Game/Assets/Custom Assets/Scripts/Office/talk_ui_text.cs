using UnityEngine;
using System.Collections;


//base class to control UI text prompts for conversations.

public class talk_ui_text : MonoBehaviour {

    public GameObject ui_text;

	// Use this for initialization
	public virtual void Start () {
        turn_off();

	}
	
	
    public void turn_off()
    {
        ui_text.SetActive(false);
    }

    public void turn_on()
    {
        ui_text.SetActive(true);
    }


}
