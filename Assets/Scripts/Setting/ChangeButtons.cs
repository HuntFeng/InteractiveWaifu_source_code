using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtons : MonoBehaviour {

    public void SetButtonNum()
    {
        Slider slider = GameObject.Find("ButtonNum").GetComponent<Slider>();
        PlayerPrefs.SetInt("ButtonNum", (int)slider.value);
    }
}
