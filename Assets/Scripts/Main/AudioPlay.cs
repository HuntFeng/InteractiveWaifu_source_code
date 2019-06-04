using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour {

    public static AudioSource audioSource;
    // Use this for initialization
    public void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame

    public static void playMusic(int iterator)
    {
        string url = "file://" + PlayerPrefs.GetString("SongPath" + iterator.ToString()).Replace('\\', '/');

        var www = new WWW(url);
        Debug.Log(url);
        while (!www.isDone)
        {
            //wait
        }

        audioSource.clip = www.GetAudioClip();
        audioSource.Play();

    }




    private static float timer;                         // Timer that keeps track of how long the audio clip has been playing
    private int iterator = 0;                     // The index of the active audio clip
    private bool playlistEnded = false;        // Whether or not the playlist has ended
    private bool loop = true;

    private void Update()
    {
        if (PlayerPrefs.GetInt("VoiceOn") == 1)
        {
            audioSource.mute = false;
            audioSource.volume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            audioSource.mute = true;
        }

        // If atleast one audio clip exists and the play list has ended, update:

        if (audioSource.clip != null && PlayPauseChange.isPlayingMusic == true)
        {
            if (PlayerPrefs.GetInt("NumOfSong", 0) > 0 && !playlistEnded)
            {

                // Increase timer with the time difference between this and the previous frame:
                timer += Time.deltaTime;

                // Check whether the timer has exceeded the length of the audio clip:
                if (timer > audioSource.clip.length)
                {

                    timer = 0;
                    // Either start from the beginning if the last clip is played
                    // or go to next audio clip:
                    if (iterator + 1 == PlayerPrefs.GetInt("NumOfSong", 0))
                    {
                        if (loop)
                        {
                            iterator = 0;
                        }
                        else
                        {
                            // Stop the active audio clip:
                            audioSource.Stop();

                            // Set the playlist as ended:
                            playlistEnded = true;

                            // No more playing, so return:
                            return;
                        }


                    }
                    else
                    {
                        iterator++;
                    }

                    // Play the next audio clip:
                    playMusic(iterator);
                }
            }
        }
    }
}
            
