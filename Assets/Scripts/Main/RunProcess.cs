using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using UnityEngine;

public class RunProcess : MonoBehaviour {

    public string appName;

    private void OnMouseDown()
    {
        Process.Start(appName);
    }

}
