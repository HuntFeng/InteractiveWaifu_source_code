using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SystemTime : MonoBehaviour {

    Text Time;
	// Use this for initialization
	void Start () {
        Time = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Time.text = DateTime.Now.ToString();
    }
}
