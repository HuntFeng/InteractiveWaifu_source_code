using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableText : MonoBehaviour {

    public GameObject songname;
    int count = 0;
    bool clicked = false;

    private void OnMouseEnter()
    {
        if(!clicked)
            songname.GetComponent<Text>().color = Color.green;
    }

    private void OnMouseExit()
    {
        if(!clicked)
            songname.GetComponent<Text>().color = Color.black;
    }

    private void OnMouseDown()
    {
        count++;
        if(count%2==1)
        {
            clicked = true;
            songname.GetComponent<Text>().color = Color.blue;
        } 
        else
        {
            clicked = false;
            songname.GetComponent<Text>().color = Color.black;
        }
    }
}
