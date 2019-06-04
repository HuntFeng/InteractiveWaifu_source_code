using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongList : MonoBehaviour {
    public GameObject ContentHolder;
    public GameObject textPrefabs;
    GameObject songname;

    private int numofsong;
    public void Start()
    {
        numofsong = PlayerPrefs.GetInt("NumOfSong", 0);
        int i;
        int j = 0;
        for (i=0; i< numofsong; i++)
        {
            
            string path = PlayerPrefs.GetString("SongPath" + i.ToString(), "");
            if( path != "")
            {//if the address is not null, we instantiate a text to diaplay the song name
                songname = Instantiate(textPrefabs);
                songname.transform.SetParent(ContentHolder.transform);
                songname.transform.localScale = new Vector3(1, 1, 0);

                string[] fragments = path.Split('\\');
                songname.GetComponent<Text>().text = (j + 1).ToString() + ". " + fragments[fragments.Length - 1];
                PlayerPrefs.SetString("SongPath"+j.ToString(),path);
                j++;

            }
            
        }

        PlayerPrefs.SetInt("NumOfSong", j);
            
        

    }
}
