using UnityEngine;
using System.Collections;

public class player_stats : MonoBehaviour {


    public int health;
    public int hydration;
    public int hunger;
    public int morale;



	// Use this for initialization
	void Start () {
	
	}
	public void CheckMaxCapStats()
    {
        if (morale > 3)
            morale = 3;
        if (health > 3)
            health = 3;
        if (hydration > 3)
            hydration = 3;
        if (hunger > 3)
            hunger = 3;
    }
	public void CheckDeathStats()
    {
        if (health < 0 || hydration < 0 || hunger < 0 || morale < 0)
        {
            string msg = "You died from ";
            if (health < 0)
                msg += "\"health loss\"";
            if (hydration < 0)
                msg += "\"dehydration\"";
            if (hunger < 0)
                msg += "\"not enough food\"";
            if (morale < 0)
                msg += "\"bad morale\"";

            msg += "..... !";
            print(msg);
        }
    }
}
