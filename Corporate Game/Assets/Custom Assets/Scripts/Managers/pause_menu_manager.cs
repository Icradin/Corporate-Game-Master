using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pause_menu_manager : MonoBehaviour {


    [SerializeField]
    GameObject pause_menu;

    void Start()
    {
        pause_menu.SetActive(false);
    }
	public void DeactivatePauseMenu()
    {
        pause_menu.SetActive(false);
    }
    public void ActivatePauseMenu()
    {
        pause_menu.SetActive(true);
    }

}
