using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCheck : MonoBehaviour
{

    public InputField inputf;
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
}
