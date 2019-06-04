using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPauseChange : MonoBehaviour {

    int count = 0;
    public Sprite play;
    public Sprite pause;

    GameObject BGM; 
    public static bool isPlayingMusic;

    void Start()
    {
        if(isPlayingMusic)
            GetComponent<SpriteRenderer>().sprite = pause;
        else
            GetComponent<SpriteRenderer>().sprite = play;

    }

    private void OnMouseEnter()
    {
        CreateButtons.displayInfo = true;
    }
    private void OnMouseDown()
    {
        BGM = GameObject.Find("BGM");
        count++;

        if (count % 2 == 1)
        {
            isPlayingMusic = true;
            GetComponent<SpriteRenderer>().sprite = pause;
            if (BGM.GetComponent<AudioSource>().clip == null)
            {
                AudioPlay.playMusic(0);
            }
            else
            {
                BGM.GetComponent<AudioSource>().UnPause();
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = play;
            BGM.GetComponent<AudioSource>().Pause();
            isPlayingMusic = false;
        }
            
    }
}
