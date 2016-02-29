using UnityEngine;
using System.Collections;

public class talk_marketing : talk_base {

    public GameObject transition_image;
    public GameObject nurse_choice;
    public GameObject nurse;
    public GameObject doctor;
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

        transition_manager.instance.transition(1, gameObject);

        Debug.Log("transition happening , transition iamge true ");
        yield return new WaitForSeconds(1);
        transition_image.SetActive(true);

        yield return new WaitForSeconds(2);

        Debug.Log("disabling transition");

        transition_manager.instance.fade(true);

        yield return new WaitForSeconds(1);

        transition_image.SetActive(false);

        transition_manager.instance.fade(false);

        yield return new WaitForSeconds(2);

        Debug.Log("playing audio 2 after advanced time -> waiting audio ");

        audio_source.PlayOneShot(audio_clips[1]);

        yield return new WaitForSeconds(audio_clips[1].length);

        game_manager.Instance.boss_talk_progression++;

 
        game_manager.Instance.talked = false;

        Debug.Log("finalized first  talk. boss talk progresion increased and marketing visits ++");

    }



    IEnumerator double_visit(float firstAudio)
    {
        Debug.Log("waiting for first speech to finish ... ");
        yield return new WaitForSeconds(firstAudio);
        transition_manager.instance.transition(2, gameObject);
        game_manager.Instance.Player.GetComponent<CharacterController>().enabled = false;
        game_manager.Instance.Player.transform.LookAt(doctor.transform);
        yield return new WaitForSeconds(1);
        audio_source.PlayOneShot(audio_clips[2]);
        yield return new WaitForSeconds(audio_clips[2].length + 1);
   
        Debug.Log("waiting for marketing manager to talk");
        yield return new WaitForSeconds(3);
        Debug.Log("marketing manager talking ....");
        audio_source.PlayOneShot(audio_clips[3]);
        yield return new WaitForSeconds(audio_clips[3].length + 2);
        game_manager.Instance.scene_manager.SetState(GameState.NurseChoice);
        nurse_choice.SetActive(true);
        
    }

    public void talk_to_nurse()
    {
        game_manager.Instance.scene_manager.SetState(GameState.InGame);
        game_manager.Instance.Player.GetComponent<CharacterController>().enabled = false;
        nurse_choice.SetActive(false);
        nurse.GetComponent<NavMeshAgent>().SetDestination(game_manager.Instance.Player.transform.position);
        nurse.GetComponent<nusre_logic>().startLogic = true;
    }

    public void reject_talking()
    {
        nurse_choice.SetActive(false);
        game_manager.Instance.boss_lose = true;
        transition_manager.instance.transition(3, gameObject);
        game_manager.Instance.scene_manager.SetState(GameState.InGame);
        game_manager.Instance.Player.GetComponent<CharacterController>().enabled = false;
        game_manager.Instance.talked = false;
    }


    override public void talk()
    {
        if(conversation_progression == 0)
        {
            audio_source.PlayOneShot(audio_clips[0]);
            StartCoroutine("advance_time", audio_clips[0].length + 1f);
       
            // --- make newvariable that is marketing visits -- unclear

            return;
        }
        if (boss_double_visit)
        {
            Debug.Log("Load double visit scene !");
            audio_source.PlayOneShot(audio_clips[1]);
            StartCoroutine("double_visit", audio_clips[1].length + 1f);
            return;
        }

        if(conversation_progression > 0 && !boss_double_visit)
        {
            Debug.Log("already visited");
            // just play already visited sound.
            game_manager.Instance.talked = false;
        }

    }
}
