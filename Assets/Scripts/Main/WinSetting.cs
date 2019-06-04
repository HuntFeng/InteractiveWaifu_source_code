using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using UnityEngine.UI;


public class WinSetting : MonoBehaviour
{

    #region Win函数常量
    private struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }

    [DllImport("user32.dll")]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll")]
    static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [DllImport("user32.dll")]
    static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

    [DllImport("user32.dll")]
    static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, int bAlpha, int dwFlags);

    [DllImport("Dwmapi.dll")]
    static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
    private const int WS_POPUP = 0x800000;
    private const int GWL_EXSTYLE = -20;
    private const int GWL_STYLE = -16;
    private const int WS_EX_LAYERED = 0x00080000;
    private const int WS_BORDER = 0x00800000;
    private const int WS_CAPTION = 0x00C00000;
    private const int SWP_SHOWWINDOW = 0x0040;
    private const int SWP_HIDEWINDOW = 0x0080;
    private const int LWA_COLORKEY = 0x00000001;
    private const int LWA_ALPHA = 0x00000002;
    private const int WS_EX_TRANSPARENT = 0x20;
    private const int WS_EX_TOOLWINDOW = 0x00000080;
    //
    private const int ULW_COLORKEY = 0x00000001;
    private const int ULW_ALPHA = 0x00000002;
    private const int ULW_OPAQUE = 0x00000004;
    private const int ULW_EX_NORESIZE = 0x00000008;
    #endregion


    //
    public int ResWidth = 800;//window's width
    public int ResHeight = 600;//window's height
    //
    
    // Use this for initialization

    IntPtr hwnd;
    RECT rct = new RECT();
    public static bool isAphaPenetrate;//for window penetration
    bool isShow = true;

    NotifyIcon icon;
    void Awake()
    {
        UnityEngine.Screen.fullScreen = false;
        hwnd = FindWindow(null, "InteractiveWaifu");
        isAphaPenetrate = true;

        icon = new NotifyIcon();
        Bitmap bitmap = new Bitmap(@"C:\Users\space\Desktop\Live2D_SDK_Unity_2.1.04_2_en\sample\Demo\Assets\Resources\maid32.ico");
        IntPtr Hicon = bitmap.GetHicon();
        icon.Icon = Icon.FromHandle(Hicon);
        icon.Text = "Your Waifu";
        icon.ContextMenu = new System.Windows.Forms.ContextMenu(new MenuItem[] {
                    new MenuItem("Hello!", (s, e) => { isShow = true; }),
                    new MenuItem("Hide!", (s, e) => { isShow = false; }),
                    new MenuItem("Exit",(s,e) => {
                        foreach (Process proc in Process.GetProcessesByName("InteractiveWaifu"))
                        {
                            proc.Kill();
                        }
                    }),
        });  
        icon.Visible = true;

        icon.DoubleClick += new EventHandler(this.icon_DoubleClick);
    }

    private void icon_DoubleClick(object sender, EventArgs e)
    {
        isShow = true;
    }

    private void Update()
    {
        if (isShow)
        {
            //tool_window(no task bar icon and hide from alt+tab), borderless and transparent       
            SetWindowLong(hwnd, GWL_EXSTYLE, WS_EX_LAYERED| WS_EX_TOOLWINDOW);
            int intExTemp = GetWindowLong(hwnd, GWL_EXSTYLE);
            if (isAphaPenetrate)//window penetration
            {
                SetWindowLong(hwnd, GWL_EXSTYLE, intExTemp | WS_EX_TRANSPARENT | WS_EX_LAYERED| WS_EX_TOOLWINDOW);
            }
            //
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_BORDER & ~WS_CAPTION);
            GetWindowRect(hwnd, ref rct);
            if (!QuickNote.isNoteOpen)
                SetWindowPos(hwnd, -1, rct.Left, rct.Top, ResWidth, ResHeight, SWP_SHOWWINDOW);


            GetWindowRect(hwnd, ref rct);

            var margins = new MARGINS() { cxLeftWidth = -1 };
            //
            DwmExtendFrameIntoClientArea(hwnd, ref margins);
        }
        else
            SetWindowPos(hwnd, -1, rct.Left, rct.Top, ResWidth, ResHeight, SWP_HIDEWINDOW);

    }
        
    
}
