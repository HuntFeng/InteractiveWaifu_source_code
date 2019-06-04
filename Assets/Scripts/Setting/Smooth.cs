using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Smooth : MonoBehaviour {

	public void SmoothOnOff()
    {
        Toggle toggle = GameObject.Find("Smoothing").GetComponent<Toggle>();
        if (toggle.isOn)
            PlayerPrefs.SetInt("Smoothing",1);
        else
            PlayerPrefs.SetInt("Smoothing", 0);
    }
}
