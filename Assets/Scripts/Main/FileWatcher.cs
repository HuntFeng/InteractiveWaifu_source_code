using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Security.Permissions;
using UnityEngine.UI;


public class FileWatcher : MonoBehaviour {


    bool isDeleted, isCreated;
    public GameObject BGM;


    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]

    // Define the event handlers.
    void OnChanged(object source, FileSystemEventArgs e)
    {
        // Specify what is done when a file is changed, created, or deleted.
        // filter file types 
        if(e.ChangeType == WatcherChangeTypes.Deleted)
        {
            //displayDelete = "File: " + e.FullPath + " " + e.ChangeType;
            isDeleted = true;
        }
        if (e.ChangeType == WatcherChangeTypes.Created)
        {
            //displayCreate = "File: " + e.FullPath + " " + e.ChangeType;
            isCreated = true;
        }
            
    }


    // Update is called once per frame
    void Start () {
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        watcher.IncludeSubdirectories = false;
        /* Watch for changes in LastAccess and LastWrite times, and
           the renaming of files or directories. */
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        // Only watch text files.
       watcher.Filter = "*.*";

        // Add event handlers.
        watcher.Created += new FileSystemEventHandler(OnChanged);
        watcher.Deleted += new FileSystemEventHandler(OnChanged);

        // Begin watching.
        watcher.EnableRaisingEvents = true;

        
    }

    public void playAudio()
    {
        AudioSource audio = BGM.GetComponent<AudioSource>();

        if (isCreated && !isDeleted)
        {
            audio.clip = Resources.Load<AudioClip>("shizuku_voice");
            audio.Play();
            /*
            if (PlayerPrefs.GetString("CreateAudio","") != "")
            {
                var www = new WWW("file://" + PlayerPrefs.GetString("CreateAudio"));    
                audio.clip = www.GetAudioClip();
                audio.Play();
            }
            else
            {
                audio.clip = Resources.Load<AudioClip>("shizuku_voice");
                audio.Play();
            }
            */
               
        }

        if (!isCreated && isDeleted)
        {

            audio.clip = Resources.Load<AudioClip>("Rie Kugimiya");
            audio.Play();
            /*
            if (PlayerPrefs.GetString("DeleteAudio", "") != "")
            {
                var www = new WWW("file://" + PlayerPrefs.GetString("DeleteAudio"));
                Debug.Log("file://" + PlayerPrefs.GetString("DeleteAudio"));
                audio.clip = www.GetAudioClip();
                audio.Play();
            }
            else
            {
                audio.clip = Resources.Load<AudioClip>("Rie Kugimiya");
                audio.Play();
            }
            */
            
        }

        if (isCreated && isDeleted)
        {

            audio.clip = Resources.Load<AudioClip>("takamono");
            audio.Play();
            /*
            if (PlayerPrefs.GetString("RenameAudio", "") != "")
            {
                var www = new WWW("file://" + PlayerPrefs.GetString("RenameAudio").Replace('\\','/'));
                Debug.Log("file://" + PlayerPrefs.GetString("RenameAudio").Replace('\\', '/'));
                while (!www.isDone)
                {
                    //wait until it's done
                }
                audio.clip = www.GetAudioClip(false,false,AudioType.WAV);
                audio.clip.name = "Clip";
                Debug.Log(audio.clip.length);
                audio.Play();
            }
            else
            {
                audio.clip = Resources.Load<AudioClip>("takamono");
                audio.Play();
            }
            */
                
        }

        isCreated = false;
        isDeleted = false;


    }

    void Update()
    {
        playAudio();
    }

}
