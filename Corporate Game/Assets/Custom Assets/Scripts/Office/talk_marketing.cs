using UnityEngine;
using System.Collections;

public class talk_marketing : talk_base {

    public GameObject transition_image;


    // Use this for initialization
    override public void Start () {
        base.Start();

    }
	
	// Update is called once per frame
	void Update () {
	
	}


    IEnumerator advance_time(float firstAudio)
    {

        Debug.Log("waiting for first speech to finish ... " );
        yield return new WaitForSeconds(firstAudio);
        transition_manager.instance.fade(true);
        transition_manager.instance.transition(1, gameObject);
        yield return new WaitForSeconds(1);
     
        transition_manager.instance.fade(false);
        Debug.Log("showing 2 weeks later");
        transition_image.SetActive(true);
        yield return new WaitForSeconds(2);
        transition_manager.instance.fade(true);
        yield return new WaitForSeconds(1);
        transition_image.SetActive(false);
        transition_manager.instance.fade(false);     
        yield return new WaitForSeconds(2);
        Debug.Log("playing audio 2 after advanced time -> waiting audio ");
        audio_source.PlayOneShot(auido_clips[1]);
        yield return new WaitForSeconds(auido_clips[1].length);
        game_manager.Instance.boss_talk_progression++;
        game_manager.Instance.talked = false;
        Debug.Log("finalized first  talk. boss talk progresion increased and marketing visits ++");
    }

    override public void talk()
    {
        if(conversation_progression == 0)
        {
            audio_source.PlayOneShot(auido_clips[0]);
            StartCoroutine("advance_time", auido_clips[0].length + 1f);
       
            // --- make newvariable that is marketing visits -- unclear

            return;
        }
        if (boss_double_visit)
        {
            Debug.Log("Load double visit scene !");
            //--play audio for double visit 
            // --- fade to black
            // -- > load double visit scene / room 
        }

        if(conversation_progression > 0 && !boss_double_visit)
        {
            Debug.Log("already visited");
            // just play already visited sound.
        }

    }
}
