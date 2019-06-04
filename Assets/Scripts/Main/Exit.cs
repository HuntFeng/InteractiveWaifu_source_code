using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Exit : MonoBehaviour {

    private void OnMouseDown()
    {
        Process[] process = Process.GetProcessesByName("InteractiveWaifu");
        foreach(Process prs in process)
        {
            prs.Kill();
        }

    }

}
