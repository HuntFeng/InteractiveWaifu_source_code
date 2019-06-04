using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SFB;

public class CreateInputs : MonoBehaviour {

    public Canvas canvas;
    public Button browsePrefabs;
    public Text filePromptPrefabs;
    public Text inputPromptPrefabs;
    public InputField inputPrefabs;

    List<InputField> input;
    List<Text> prompt;

    private float spacing;
    int buttonNums;
    // Use this for initialization
    private void Start ()
    {
        
        buttonNums = PlayerPrefs.GetInt("ButtonNum", 0);
        if (buttonNums != 0)
        {
            spacing = (500 - 70) / buttonNums;
        }

        input = new List<InputField>();
        prompt = new List<Text>();

        for (int i = 0; i < buttonNums; i++)
        {
            Text inputPrompt;
            Text filePrompt;
            InputField inputfield;
            Button browse;

            
            inputPrompt = Instantiate(inputPromptPrefabs, new Vector3(125, 470 - spacing * i, 0), Quaternion.identity) as Text;
            inputPrompt.text = "Display name for button" + i.ToString() + ":";
            inputPrompt.transform.SetParent(canvas.transform, false);

            inputfield = Instantiate(inputPrefabs, new Vector3(125, 440 - spacing * i, 0), Quaternion.identity) as InputField;
            inputfield.placeholder.GetComponent<Text>().text = PlayerPrefs.GetString("ButtonName" + i.ToString(), "Name");
            inputfield.transform.SetParent(canvas.transform, false);
            input.Add(inputfield);

            filePrompt = Instantiate(filePromptPrefabs, new Vector3(400, 470 - spacing * i, 0), Quaternion.identity) as Text;
            filePrompt.transform.SetParent(canvas.transform, false);
            prompt.Add(filePrompt);

            browse = Instantiate(browsePrefabs, new Vector3(400, 440 - spacing * i, 0), Quaternion.identity) as Button;
            browse.transform.SetParent(canvas.transform, false);
            string n = i.ToString();
            browse.GetComponent<Button>().onClick.AddListener(() => Browse(n));

        }

    }
	
    public void Browse(string n)
    {
        string[] path = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false);
        foreach (string p in path)
        {
            PlayerPrefs.SetString("FilePath" + n, p);
            //Debug.Log("FilePath" + n);
        }
    }

    // Update is called once per frame

    void Update () {
        
        for(int i=0; i<buttonNums;i++)
        {
            if(input[i].text.Length != 0)
                PlayerPrefs.SetString("ButtonName" + i.ToString(), input[i].text);

            string path = PlayerPrefs.GetString("FilePath"+i.ToString(), "");
            string[] splits = path.Split('\\');
            Debug.Log("FilePath" + i.ToString() + "    length = " +path.Length);
            prompt[i].text = "Choose File: " + splits[splits.Length - 1];
        }
        

    }
    
}
 