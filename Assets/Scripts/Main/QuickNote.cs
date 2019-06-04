using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;
using System;
using System.Linq;

public class QuickNote : MonoBehaviour {

    Form form;
    RichTextBox textBox;
    public static string text;
    public static bool isNoteOpen;

    public void OnMouseDown()
    {
        isNoteOpen = true;

        form = new Form();
        textBox = new RichTextBox();
        form.ShowInTaskbar = false;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        form.TopMost = true;
        form.Text = "Quick Note";
        form.Show();

        
        textBox.Size = form.Size;
        form.Controls.Add(textBox);
        textBox.Text = PlayerPrefs.GetString("QuickNote", "");

        form.SizeChanged += Form_SizeChanged;
        textBox.Click += TextBox_Click;
        textBox.TextChanged += TextBox_TextChanged; 
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        PlayerPrefs.SetString("QuickNote",textBox.Text);
    }

    private void TextBox_Click(object sender, EventArgs e)
    {
        MouseEventArgs me = (MouseEventArgs)e;
        if(me.Button == MouseButtons.Right)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();

            textBox.Font = fontDialog.Font;
        }
    }

    private void TextBox_Close(object sender, EventArgs e)
    {
        FormClosingEventArgs ce = (FormClosingEventArgs)e;

        if (ce.Cancel)
            isNoteOpen = false;
            
    }

    private void Form_SizeChanged(object sender, EventArgs e)
    {
        textBox.Size = form.Size;
    }

}
