using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;

public class FileBrowser : MonoBehaviour {

    public void Browse()
    {
        int numofsong = PlayerPrefs.GetInt("NumOfSong", 0);
        string[] path = StandaloneFileBrowser.OpenFilePanel("Open Files", "", "", true);
        for (int i=0; i<path.Length;i++)
        {
            PlayerPrefs.SetString("SongPath"+(i+numofsong).ToString(), path[i]);
        }
        PlayerPrefs.SetInt("NumOfSong", path.Length + numofsong);
    }
}
