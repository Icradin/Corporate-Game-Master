﻿using UnityEngine;
using System.Collections;

public class nusre_logic : MonoBehaviour {
    NavMeshAgent agent;
    [HideInInspector]
    public bool startLogic = false;
    public bool talk = false;

    AudioSource audio_source;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        audio_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (startLogic && !talk)
        {
            if ((Vector3.Distance(agent.transform.position, game_manager.Instance.Player.transform.position) < agent.stoppingDistance + 0.5f) )
            {
                talk = true;
                Invoke("end_conversation", 1.0f);
            }
        }
    }
    IEnumerator end (float audiotime)
    {
        Debug.Log("med sister speaking");
        yield return new WaitForSeconds(audiotime + 1);
        transition_manager.instance.transition(1, gameObject);
        game_manager.Instance.scene_manager.SetState(GameState.InGame);
        yield return new WaitForSeconds(1);
        game_manager.Instance.boss_talk_progression++;
        game_manager.Instance.talked = false;
        game_manager.Instance.Player.GetComponent<CharacterController>().enabled = true;
        Debug.Log("successfull meeting");
        Destroy(gameObject, 2f);
    }
    void end_conversation()
    {
        audio_source.Play();
        
        StartCoroutine("end", audio_source.clip.length);
    }
}
