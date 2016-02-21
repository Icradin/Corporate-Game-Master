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


        if (health <= 0)
            print("You died from health loss ");
        if (hydration <= 0)
            print("You died from health dehydration ");
        if (hunger <= 0)
            print("You died from starving ");
        if (morale <= 0)
            print("You died from loosing hope of living ");


    }
    
}
