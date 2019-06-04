using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Remove : MonoBehaviour {
    public void removeName()
    {
        GameObject[] game =  GameObject.FindGameObjectsWithTag("Removable") ;

        int j = 0;
        for(int i=0; i<game.Length;i++)
        {
            Text name = game[i].GetComponent<Text>();
            if (name.color == Color.blue)
            {
                PlayerPrefs.SetString("SongPath"+i.ToString(),"");
                Destroy(game[i]);
                j++;
            }
        }

    }
}
