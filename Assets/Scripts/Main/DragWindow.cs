using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragWindow : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);


    IntPtr Handle;
    float xx;
    bool bx;
    void Start()
    {
        xx = 0f;
        Handle = GetForegroundWindow();
    }


    void Update()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        if(CurrentScene.name == "SettingPanel" || CurrentScene.name == "AudioPanel")
        {
            if(SliderZone.inSlider==false)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    xx = 0f;
                    bx = true;
                }
                if (bx && xx >= 0.1f)
                { //这样做为了区分界面上面其它需要滑动的操作  
                    ReleaseCapture();
                    SendMessage(Handle, 0xA1, 0x02, 0);
                    SendMessage(Handle, 0x0202, 0, 0);


                }
                if (bx)
                    xx += Time.deltaTime;
                if (Input.GetMouseButtonUp(0))
                {

                    xx = 0f;
                    bx = false;

                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {

                xx = 0f;
                bx = true;
            }
            if (bx && xx >= 0.1f)
            { //这样做为了区分界面上面其它需要滑动的操作  
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x02, 0);
                SendMessage(Handle, 0x0202, 0, 0);


            }
            if (bx)
                xx += Time.deltaTime;
            if (Input.GetMouseButtonUp(0))
            {

                xx = 0f;
                bx = false;

            }
        }
        
        

    }

}
