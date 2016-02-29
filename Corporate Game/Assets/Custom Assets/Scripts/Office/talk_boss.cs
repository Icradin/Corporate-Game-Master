using UnityEngine;
using System.Collections;

public class talk_boss: talk_base {

    public GameObject game_over_screen;
    bool bossImrpessed = false;

    // Use this for initialization
    override public void Start()
    {
        base.Start();

    }
    public override void talk()
    {
        game_manager.Instance.talked = false;
      

        if (boss_talk_progression == 1 && conversation_progression == 0)
        {
            // play boss marketing audio .. informs that plaer can talk to account manager bout the problem
            Debug.Log("maybe talk to account manager");
            conversation_progression++;
            nothing_to_talk = true;
            return;
        }

        if (boss_talk_progression == 2 && boss_lose == false && !boss_double_visit)
        {
            //play audio to inform that player can do a double vist 
            conversation_progression++;
            boss_double_visit = true;
            nothing_to_talk = true;
            Debug.Log("boss progress - tells you can do double visit");
          
            return;
        }
   
        if(boss_talk_progression == 3 && !bossImrpessed)
        {
            bossImrpessed = true;
            Debug.Log("boss is impressed from the double visit meeting");
            conversation_progression++;
            nothing_to_talk = true;
            return;
        }

        if (boss_talk_progression == 2 && boss_lose == true)
        {
            Debug.Log("boss is dissapointed .. you loose your job..");
            audio_source.PlayOneShot(audio_clips[2]);
            StartCoroutine("game_over", audio_clips[2].length + 1);
            return;
        }



        if (boss_talk_progression == 4)
        {
            //play win audio
            // fade black after audio
            // win screen.
            return;
        }
        if (nothing_to_talk)
        {
            Debug.Log("boss says to talk to somebody else");
            nothing_to_talk = false;

            return;
        }

        Debug.Log("Bosscurrently buzy !!");
        game_manager.Instance.talked = false;

    }

    IEnumerator game_over(float audiolenght)
    {
        yield return new WaitForSeconds(audiolenght);
        transition_manager.instance.fade(true);
        yield return new WaitForSeconds(1);
        transition_manager.instance.fade(false);
        game_over_screen.SetActive(true);
        game_manager.Instance.scene_manager.SetState(GameState.InteractBarrel);
        Debug.Log("gameover");
    }
}

