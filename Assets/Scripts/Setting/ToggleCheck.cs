using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCheck : MonoBehaviour {

    public Toggle toggle;
    public string key;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt(key) == 1)
            toggle.isOn = true;
        else
            toggle.isOn = false;
	}
}
