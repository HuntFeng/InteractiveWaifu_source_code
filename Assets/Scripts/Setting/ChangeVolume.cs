using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour {

	public void Changevolume ()
    {
        Slider volume = GameObject.Find("Volume").GetComponent<Slider>();
        PlayerPrefs.SetFloat("Volume", volume.value);
	}
}
