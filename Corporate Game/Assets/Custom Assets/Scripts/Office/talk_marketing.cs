using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class talk_marketing : talk_base
{

    public GameObject transition_image;
    public GameObject nurse_choice;
    public GameObject nurse;
    public GameObject doctor;
    public GameObject manager;

    public AudioClip marketing_1;
    public AudioClip marketing_2;
    public AudioClip double_visit_talk;
    public AudioClip marketing_manager_talk;
    public AudioClip doctor_talking;

    public AudioClip marketing_already_visited;

   

    // Use this for initialization
    override public void Start()
    {
        base.Start();
        doctor.GetComponentInChildren<SpriteRenderer>().enabled = false;
        manager.GetComponentInChildren<SpriteRenderer>().enabled = false;
        transition_image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    IEnumerator advance_time(float firstAudio)
    {

        Debug.Log("waiting for first speech to finish ... ");

        yield return new WaitForSeconds(firstAudio); //audio finished
        speech_bubble.enabled = false;              //disable speech buble and wait 1 sec , so thigns go slower
        yield return new WaitForSeconds(1);
        transition_manager.instance.transition(1, gameObject); //do transition , while doing wait 1 sec and set 2 weeks later image to ture
        Debug.Log("transition happening , transition iamge true ");
        yield return new WaitForSeconds(1);
        transition_image.SetActive(true);

        yield return new WaitForSeconds(2); // show it for 2 sec

        Debug.Log("disabling transition");

        transition_manager.instance.fade(true); // fade out

        yield return new WaitForSeconds(1);  //wait fade out

        transition_image.SetActive(false); //disable 2 weeks later image

        transition_manager.instance.fade(false); //fade in

        yield return new WaitForSeconds(2);

        Debug.Log("playing audio 2 after advanced time -> waiting audio "); //playing other audio 
        speech_bubble.enabled = true;
        audio_source.PlayOneShot(marketing_2);

        yield return new WaitForSeconds(marketing_2.length);
        speech_bubble.enabled = false;
        boss_talk_progression++;


        game_manager.Instance.talked = false;

        Debug.Log("finalized first  talk. boss talk progresion increased and marketing visits ++");

    }



    IEnumerator double_visit(float firstAudio)
    {
        Debug.Log("waiting for first speech to finish ... ");
        yield return new WaitForSeconds(firstAudio);
        transition_manager.instance.transition(2, gameObject);
        yield return new WaitForSeconds(1);
        game_manager.Instance.Player.transform.LookAt(doctor.transform);
        game_manager.Instance.Player.GetComponent<FirstPersonController>().m_WalkSpeed = 0;

        yield return new WaitForSeconds(1);
        audio_source.PlayOneShot(doctor_talking);
        doctor.GetComponentInChildren<SpriteRenderer>().enabled = true;
    
        yield return new WaitForSeconds(doctor_talking.length + 1);
        doctor.GetComponentInChildren<SpriteRenderer>().enabled = false;
        Debug.Log("waiting for marketing manager to talk");
        yield return new WaitForSeconds(3);
        Debug.Log("marketing manager talking ....");
        manager.GetComponentInChildren<SpriteRenderer>().enabled = true;
        audio_source.PlayOneShot(marketing_manager_talk);
        yield return new WaitForSeconds(marketing_manager_talk.length + 1);
        manager.GetComponentInChildren<SpriteRenderer>().enabled = false;
        game_manager.Instance.scene_manager.SetState(GameState.NurseChoice);
        nurse_choice.SetActive(true);

    }

    public void talk_to_nurse()
    {
        game_manager.Instance.scene_manager.SetState(GameState.InGame);
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
        game_manager.Instance.talked = false;
    }


    override public void talk()
    {
        if (conversation_progression == 0)
        {
            speech_bubble.enabled = true;
            audio_source.PlayOneShot(marketing_1);
            StartCoroutine("advance_time", marketing_1.length);

            // --- make newvariable that is marketing visits -- unclear

            return;
        }
        if (boss_double_visit)
        {
            Debug.Log("Load double visit scene !");
            audio_source.PlayOneShot(double_visit_talk);
            StartCoroutine("double_visit", double_visit_talk.length + 1f);
            return;
        }

        if (conversation_progression > 0 && !boss_double_visit)
        {
            Debug.Log("already visited");
            // just play already visited sound.
            game_manager.Instance.talked = false;
        }

    }


    IEnumerator already_visited(float firstAudio)
    {
        yield return new WaitForSeconds(firstAudio);
    }
}
