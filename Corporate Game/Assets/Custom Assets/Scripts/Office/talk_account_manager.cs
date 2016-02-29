using UnityEngine;
using System.Collections;

public class talk_account_manager : talk_base {

    int key_account_visits = 0;

    // Use this for initialization
    override public void Start()
    {
        base.Start();

    }

    public override void talk()
    {
        game_manager.Instance.talked = false;
        if (conversation_progression < 1)
        {
            if(key_account_visits == 0)
            {
                //PLAY first denial ayduo
                Debug.Log(" cant help ");
                key_account_visits++;
            }else if ( key_account_visits ==1)
            {
                //play other denial audio
                Debug.Log(" dude cant help sorry");
            }
            return;
        }

        if(conversation_progression == 1)
        {
            //play success audio
            Debug.Log("boss progression increased ");
            boss_talk_progression++;
            return;
        }

       if(conversation_progression > 1)
        {
            //play  audio that he has done everythng for you
            Debug.Log("thats all i could do , yo");
            return;
        }
    }
}
