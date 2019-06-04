using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNumPrompt : MonoBehaviour {

    public Text prompt;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        prompt.text = String.Format("{0} Buttons", PlayerPrefs.GetInt("ButtonNum",0));
	}
}
