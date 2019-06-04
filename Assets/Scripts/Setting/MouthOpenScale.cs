using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouthOpenScale : MonoBehaviour {

    public void ChangeScaleVolume()
    {
        Slider slider = GameObject.Find("MouthOpenAmp").GetComponent<Slider>();
        PlayerPrefs.SetFloat("scaleVolume", slider.value);
    }
}
