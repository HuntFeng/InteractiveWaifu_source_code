using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPanel : MonoBehaviour {

    public string panelName;
	public void LoadScene(string panelName)
    {
        SceneManager.LoadScene(panelName);
    }
}
