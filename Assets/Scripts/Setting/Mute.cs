using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour {

    // Use this for initialization
    public void TurnOnOffMute()
    {
        Toggle toggle =  GameObject.Find("VoiceOn").GetComponent<Toggle>();
        if (toggle.isOn)
            PlayerPrefs.SetInt("VoiceOn", 1);
        else
            PlayerPrefs.SetInt("VoiceOn", 0);
    }
}
