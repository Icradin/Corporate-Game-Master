using UnityEngine;
using System.Collections;

public class talk_boss: talk_base {

    // Use this for initialization
    override public void Start()
    {
        base.Start();

    }
    public override void talk()
    {
       
        if(boss_talk_progression == 1)
        {
            // play boss marketing audio .. informs that plaer can talk to account manager bout the problem
            Debug.Log("boss progress 1 ");
            return;
        }

        if (boss_talk_progression == 2)
        {
            //play audio to inform that player can do a double vist 
            Debug.Log("boss progress 2 ");
            return;
        }


        if (nothing_to_talk)
        {
            Debug.Log("boss says to talk to somebody else");
            conversation_progression++;
            nothing_to_talk = false;
            return;
        }


        Debug.Log("Bosscurrently buzy !!");

    }
}
