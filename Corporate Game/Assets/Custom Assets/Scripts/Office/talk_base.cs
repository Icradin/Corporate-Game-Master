using UnityEngine;
using System.Collections;


//base class to control UI text prompts for conversations.

public class talk_base : MonoBehaviour {

    public GameObject ui_text;
    public AudioSource audio_source;
    public AudioClip[] auido_clips;

    protected int conversation_progression
    {
        get { return game_manager.Instance.conversation_progression; }
        set { game_manager.Instance.conversation_progression = value; }
    }
    protected int boss_talk_progression
    {
        get { return game_manager.Instance.boss_talk_progression; }
        set { game_manager.Instance.boss_talk_progression = value; }
    }
    protected bool nothing_to_talk
    {
        get { return game_manager.Instance.nothing_to_talk; }
        set { game_manager.Instance.nothing_to_talk = value; }
    }
    protected bool boss_lose
    {
        get { return game_manager.Instance.boss_lose; }
        set { game_manager.Instance.boss_lose = value; }
    }
    protected bool boss_double_visit
    {
        get { return game_manager.Instance.boss_double_visit; }
        set { game_manager.Instance.boss_double_visit = value; }
    }


    // Use this for initialization
    public virtual void Start () {
        turn_off();
	}
	
	
    public void turn_off()
    {
        ui_text.SetActive(false);
    }

    public void turn_on()
    {
        ui_text.SetActive(true);
    }

    public virtual void talk()
    {

    }
}
