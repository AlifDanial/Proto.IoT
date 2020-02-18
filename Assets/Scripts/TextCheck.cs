using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCheck : MonoBehaviour
{
    public InputField inputf;
    public string Text;
    public bool empty = true;

    public bool isEmpty()
    {
        if (inputf.text == "")
        {
            return empty = true;
        }
        else
            return empty = false;
    }

    public void savereset()
    {
        Text = inputf.text;
        Debug.Log(Text);
        inputf.text = "";
    }

    public string getText()
    {
        return Text;
    }
}
