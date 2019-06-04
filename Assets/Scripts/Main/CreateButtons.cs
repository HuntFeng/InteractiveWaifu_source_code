using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CreateButtons : MonoBehaviour {

    public static float fadeTime=5;
    public static bool displayInfo;

    public Button buttonPrefeb;
    public Canvas canvas;
    public GameObject cube;
    static public List<Image> image;
    static public List<Text> text;
    static public List<Button> buttonList;

    private float spacing;
    // intantiate
    void Start () {
        buttonList = new List<Button>();
        text = new List<Text>();
        image = new List<Image>();
        canvas.transform.SetParent(cube.transform, false);
        int buttonNums = PlayerPrefs.GetInt("ButtonNum", 0);
        if(buttonNums!= 0)
        {
            spacing = (150 - (-300)) / buttonNums;
        }

        for (int i=0; i<buttonNums;i++)
        {
            Button button;
            button = Instantiate(buttonPrefeb, new Vector3(-200,150 - spacing *i,0),Quaternion.identity) as Button;
            button.transform.SetParent(canvas.transform, false);
            button.name = String.Format("Button{0}",i);
            button.GetComponentInChildren<Text>().text = PlayerPrefs.GetString("ButtonName"+i.ToString(),"Null");
            string path = PlayerPrefs.GetString("FilePath"+i.ToString(),"");
            button.GetComponent<Button>().onClick.AddListener(() => startProcess(path));
            buttonList.Add(button);
            image.Add(button.GetComponent<Image>());
            text.Add(button.GetComponentInChildren<Text>());
        }
	}

    void startProcess(string path)
    {
        Process.Start(path);
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
        GameObject[] icon = GameObject.FindGameObjectsWithTag("Icon");
        if (displayInfo)
        {
            for(int i=0;i<icon.Length;i++)
            {
                SpriteRenderer sprite = icon[i].GetComponent<SpriteRenderer>();
                sprite.color = Color.Lerp(sprite.color, Color.white, fadeTime * Time.deltaTime);
            }

            for (int i = 0; i < PlayerPrefs.GetInt("ButtonNum", 0); i++)
            {
                image[i].color = Color.Lerp(image[i].color, Color.white, fadeTime * Time.deltaTime);
                text[i].color = Color.Lerp(text[i].color, new Color(160, 0, 188), fadeTime * Time.deltaTime);
            }


        }
        else
        {
            for (int i = 0; i < icon.Length; i++)
            {
                SpriteRenderer sprite = icon[i].GetComponent<SpriteRenderer>();
                sprite.color = Color.Lerp(sprite.color, Color.clear, fadeTime * Time.deltaTime);
            }

            for (int i = 0; i < PlayerPrefs.GetInt("ButtonNum", 0); i++)
            {
                image[i].color = Color.Lerp(image[i].color, Color.clear, fadeTime * Time.deltaTime);
                text[i].color = Color.Lerp(text[i].color, Color.clear, fadeTime * Time.deltaTime);
            }

        }

    }

    // Update is called once per frame
    void Update () {
        FadeButton();
        
	}
    
}
