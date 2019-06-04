using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;

public class BrowseFile : MonoBehaviour {

    public string[] path;
    public void OnMouseDown()
    {
        path = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false);
        foreach (string p in path)
        PlayerPrefs.SetString("FilePath", p);
    }
}
