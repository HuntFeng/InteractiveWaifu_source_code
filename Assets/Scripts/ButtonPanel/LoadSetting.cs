using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSetting : MonoBehaviour
{

    public void ShowPanel()
    {
        SceneManager.LoadScene("SettingPanel");
    }
}

