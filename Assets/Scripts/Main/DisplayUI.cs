using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour {

    public float fadeTime;
    public bool displayInfo;

    public Image[] image;
    public Text[] buttontext;
    // Use this for initialization
    void Start () {

        for (int i=0;i<PlayerPrefs.GetInt("ButtonNum",0);i++)
        {
            if(CreateButtons.image[i] == null)
                Debug.Log("cannot find image" + i.ToString());
            if(CreateButtons.text[i])
                Debug.Log("cannot find buttontext" + i.ToString());
            if (image[i]==null)
                Debug.Log("cannot find image"+i.ToString());
            if (buttontext[i]==null)
                Debug.Log("cannot find buttontext" + i.ToString());
        }
        
    }

    void OnMouseOver()
    {
        displayInfo = true;
    }

    void OnMouseExit()
    {
        displayInfo = false;
    }

    void FadeButton()
    {
        
        if(displayInfo)
        {
            for(int i=0;i<PlayerPrefs.GetInt("ButtonNum",0);i++)
            {
                image[i].color = Color.Lerp(image[i].color, Color.white, fadeTime * Time.deltaTime);
                buttontext[i].color = Color.Lerp(buttontext[i].color, new Color(160, 0, 188), fadeTime * Time.deltaTime);
            }

          
        }
        else
        {
            for(int i = 0; i < PlayerPrefs.GetInt("ButtonNum", 0); i++)
            {
                image[i].color = Color.Lerp(image[i].color, Color.clear, fadeTime * Time.deltaTime);
                buttontext[i].color = Color.Lerp(buttontext[i].color, Color.clear, fadeTime * Time.deltaTime);
            }

        }
        
    }
    /*
    // Update is called once per frame
    void Update () {
        FadeButton();
	}
    */
}
