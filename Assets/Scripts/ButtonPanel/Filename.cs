using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Filename : MonoBehaviour {


    string path;
    Text prompt;
	// Use this for initialization
	void Start () {
        prompt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        path = PlayerPrefs.GetString("FilePath","");
        string[] splits = path.Split('\\');
        prompt.text = "Choose File: " + splits[splits.Length-1];
	}
}
