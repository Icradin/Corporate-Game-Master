using UnityEngine;
using System.Collections;

public class talk_account_manager : talk_base {

    int key_account_visits = 0;
    public AudioClip cant_help_talk;
    public AudioClip cant_help_talk2;
    public AudioClip all_could_do;
    public AudioClip success_talk;


    // Use this for initialization
    override public void Start()
    {
        base.Start();

    }

    public override void talk()
    {
        
        if (conversation_progression < 1)
        {
            if(key_account_visits == 0)
            {
                //PLAY first denial ayduo
              
                audio_source.PlayOneShot(cant_help_talk);
                StartCoroutine("cant_help", cant_help_talk.length);
            }
            else if ( key_account_visits ==1)
            {
                audio_source.PlayOneShot(cant_help_talk2);
                StartCoroutine("cant_help_insist", cant_help_talk2.length);
           
            }
            return;
        }

        if(conversation_progression == 1 && boss_talk_progression ==1)
        {
            audio_source.PlayOneShot(success_talk);
            StartCoroutine("success_talking", success_talk.length);
            return;
        }

       if(conversation_progression > 1)
        {
            audio_source.PlayOneShot(all_could_do);
            StartCoroutine("all_could_do_talking", all_could_do.length);
            return;
        }

        Debug.Log("i am busy leave me");
        game_manager.Instance.talked = false;
    }


    IEnumerator cant_help(float time)
    {
        Debug.Log(" cant help    -- start");
        speech_bubble.enabled = true;
        yield return new WaitForSeconds(time);
        speech_bubble.enabled = false;
        Debug.Log(" cant help    -- end");
        key_account_visits++;
        game_manager.Instance.talked = false;
    }
    IEnumerator cant_help_insist(float time)
    {
        Debug.Log(" dude cant help sorry --- start");
        speech_bubble.enabled = true;
        yield return new WaitForSeconds(time);
        speech_bubble.enabled = false;
        Debug.Log(" dude cant help sorry --- end");
        game_manager.Instance.talked = false;
    }
    IEnumerator success_talking(float time)
    {
        Debug.Log("boss progression increased  -- start ");
        speech_bubble.enabled = true;
        yield return new WaitForSeconds(time);
        boss_talk_progression++;
        speech_bubble.enabled = false;
        Debug.Log("boss progression increased  -- end ");
        game_manager.Instance.talked = false;
    }

    IEnumerator all_could_do_talking(float time)
    {
        Debug.Log("thats all i could do , yo    --- start");
        speech_bubble.enabled = true;
        yield return new WaitForSeconds(time);


        speech_bubble.enabled = false;
        Debug.Log("thats all i could do , yo    --- end");
        game_manager.Instance.talked = false;
    }
}
