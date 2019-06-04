using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderZone : MonoBehaviour {
    public static bool inSlider = false;
    void OnMouseOver()
    {
        inSlider = true;
    }

    void OnMouseExit()
    {
        inSlider = false;
    }

}
