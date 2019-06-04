using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPosition : MonoBehaviour {

    public Slider slider;
    public string key;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (slider == GameObject.Find("ButtonNum").GetComponent<Slider>())
            slider.value = PlayerPrefs.GetInt(key, 0);
        else
            slider.value = PlayerPrefs.GetFloat(key, 0);
    }
}
